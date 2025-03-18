using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefas.Models
{
    public class Tarefa
    {
        [Key] //define chave primaria
        public int Id { get; set; } //chave primaria

        [Required(ErrorMessage = "Preencha a descrição")] //validacao
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha a data de vencimento")] //validacao
        public DateTime? DataDeVencimento { get; set; } //pode ser nulo]

        [Required(ErrorMessage = "Selecione uma categoria!")] //validacao
        public string CategoriaId { get; set; } //chave estrangeira

        [ValidateNever] //não tentará validar a propriedade Categoria quando um objeto Tarefa for submetido via formulário
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Selecione um status!")] //validacao
        public string StatusId { get; set; } //chave estrangeira

        [ValidateNever]
        public Status Status { get; set; }
        public bool Atrasado => StatusId == "aberto" && DataDeVencimento < DateTime.Today; //lambda

    }
}
