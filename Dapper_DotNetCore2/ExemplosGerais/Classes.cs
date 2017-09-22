namespace ExemplosGerais
{
    public class Regiao
    {
        public int IdRegiao { get; set; }
        public string NomeRegiao { get; set; }
        public int QtdEstados { get; set; }
    }

    public class Estado
    {
        public string SiglaEstado { get; set; }
        public string NomeEstado { get; set; }
        public string NomeCapital { get; set; }
        public string NomeRegiao { get; set; }
    }
}