using System.Diagnostics;
using ListaDeTarefas.Data;
using ListaDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly AppDbContext _context; //injecao de dependencia

        public HomeController(AppDbContext context) {
            _context = context;
        }

        public IActionResult Index(string id)
        {
            var filtros = new Filtros(id);

            ViewBag.Filtros = filtros;
            ViewBag.Categorias = _context.Categorias.ToList();
            ViewBag.Status = _context.Statuses.ToList();
            ViewBag.VencimentoValores = Filtros.VencimentoValoresFiltro;

            IQueryable<Tarefa> consulta = _context.Tarefas
                .Include(c => c.Categoria)
                .Include(s => s.Status);

            if(filtros.TemCategoria) { //se for true
                consulta = consulta.Where(t => t.CategoriaId == filtros.CategoriaId); //t é a informacao do banco

            }

            if (filtros.TemStatus) { //se for true
                consulta = consulta.Where(t => t.StatusId == filtros.StatusId); //t é a informacao do banco

            }

            if (filtros.TemVencimento) { //se for true
                var hoje = DateTime.Today;

                if(filtros.EPassado) {
                    consulta = consulta.Where(t => t.DataDeVencimento < hoje);
                }

                if (filtros.EFuturo) {
                    consulta = consulta.Where(t => t.DataDeVencimento > hoje);
                }

                if (filtros.EHoje) {
                    consulta = consulta.Where(t => t.DataDeVencimento == hoje);
                }


            }

            var tarefas = consulta.OrderBy(t => t.DataDeVencimento).ToList(); //pega a consulta, e ordena por data de vencimento


            return View(tarefas);
        }

        [HttpGet]
        public IActionResult Adicionar() {

            ViewBag.Categorias = _context.Categorias.ToList();
            ViewBag.Status = _context.Statuses.ToList();

            var tarefa = new Tarefa { StatusId = "aberto" };
            return View(tarefa);

        }

        [HttpPost]
        public IActionResult Filtrar(string[] filtro) {

            string id = string.Join('-', filtro); //junta os valores dos select enviados na view
            return RedirectToAction("Index", new {ID = id});
        }

        [HttpPost]
        public IActionResult MarcarCompleto([FromRoute] string id, Tarefa tarefaSelecionada) {     

            tarefaSelecionada = _context.Tarefas.Find(tarefaSelecionada.Id);

            if (tarefaSelecionada != null) {
                tarefaSelecionada.StatusId = "completo";
                _context.SaveChanges();
            }

            return RedirectToAction("Index", new { ID = id }); //redireciona com a rota ja filtrada

        }

        [HttpPost]
        public IActionResult Adicionar(Tarefa tarefa) {
            if (ModelState.IsValid) { 

                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();

                return RedirectToAction("Index");

            } else {

                ViewBag.Categorias = _context.Categorias.ToList();
                ViewBag.Status = _context.Statuses.ToList();

                return View(tarefa);

            }

        }

        [HttpPost]
        public IActionResult DeletarCompletos(string id) {
            var paraDeletar = _context.Tarefas.Where(s => s.StatusId == "completo").ToList();

            foreach (var tarefa in paraDeletar) { 
                _context.Tarefas.Remove(tarefa);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", new {ID = id});
        
        }
    }
}
