using Dapper.Contrib.Extensions;

namespace ExemploDapperContrib
{
    [Table("dbo.Estados")]
    public class Estado
    {
        [ExplicitKey]
        public string SiglaEstado { get; set; }
        public string NomeEstado { get; set; }
        public string NomeCapital { get; set; }
        public int IdRegiao { get; set; }
    }
}