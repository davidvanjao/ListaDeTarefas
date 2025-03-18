using ListaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Data {
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { // Define configurações do modelo do banco.

            modelBuilder.Entity<Categoria>().HasData( //Adiciona dados iniciais nas tabelas automaticamente
                new Categoria { CategoriaId = "trabalho", Nome = "Trabalho"},
                new Categoria { CategoriaId = "casa", Nome = "Casa" },
                new Categoria { CategoriaId = "faculdade", Nome = "Faculdade" },
                new Categoria { CategoriaId = "compras", Nome = "Compras" },
                new Categoria { CategoriaId = "academia", Nome = "Academia" }
            );

            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "aberto", Nome = "Aberto"},
                new Status { StatusId = "completo", Nome = "Completo"}
            );

            modelBuilder.Entity<Tarefa>().HasData(
                new Tarefa { Id = 1, Descricao = "Limpar Casa", DataDeVencimento = new DateTime(2025, 3, 16, 0, 0, 0), CategoriaId = "casa", StatusId = "aberto" },
                new Tarefa { Id = 2,  Descricao = "Fazer tarefa", DataDeVencimento = new DateTime(2025, 3, 16, 0, 0, 0), CategoriaId = "faculdade", StatusId = "aberto" }
            );

            base.OnModelCreating(modelBuilder); //garante que qualquer configuração adicional feita pelo EF Core seja aplicada corretamente
        }

        /*NO CONSOLE
         
            add-migration CriandoBanco   --comandos SQL necessários para criar ou modificar tabelas
            update-database              --executa os scripts SQL gerados pelo add-migration

         */


    }
}
