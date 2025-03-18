namespace ListaDeTarefas.Models {
    public class Filtros {
        public string FiltroString { get; set; }
        public string CategoriaId { get; set; }
        public string StatusId { get; set; }
        public string Vencimento { get; set; }

        public Filtros(string filtroString) {
            FiltroString = filtroString ?? "todos-todos-todos"; //se estiver null, recebe valor todos-todos-todos, se não, recebe o que esta vindo.
            string[] filtros = FiltroString.Split('-');

            CategoriaId = filtros[0];
            Vencimento = filtros[1];
            StatusId = filtros[2];
        }

        public bool TemCategoria => CategoriaId.ToLower() != "todos"; //expressao lambda
        public bool TemVencimento => Vencimento.ToLower() != "todos";
        public bool TemStatus => StatusId.ToLower() != "todos";

        public static Dictionary<string, string> VencimentoValoresFiltro => //colecao que armagina chave e valor
            new Dictionary<string, string> {
                {"futuro", "Futuro"},
                {"passado", "Passado"},
                {"hoje", "Hoje"}
            };

        public bool EPassado => Vencimento.ToLower() == "passado";
        public bool EFuturo => Vencimento.ToLower() == "futuro";
        public bool EHoje => Vencimento.ToLower() == "hoje";

    }
}
