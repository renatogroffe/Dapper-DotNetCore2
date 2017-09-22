using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper;
using Slapper;

namespace ExemploOneToMany.Controllers
{
    [Route("api/[controller]")]
    public class RegioesController : Controller
    {
        [HttpGet]
        public IEnumerable<Regiao> Get(
             [FromServices]IConfiguration config)
        {
            using (SqlConnection conexao = new SqlConnection(
                config.GetConnectionString("ExemplosDapper")))
            {
                var dados = conexao.Query<dynamic>(
                    "SELECT R.IdRegiao, " +
                           "R.NomeRegiao, " +
                           "E.SiglaEstado AS Estados_SiglaEstado, " +
                           "E.NomeEstado AS Estados_NomeEstado, " +
                           "E.NomeCapital AS Estados_NomeCapital " +
                    "FROM dbo.Regioes R " +
                    "INNER JOIN dbo.Estados E " +
                        "ON E.IdRegiao = R.IdRegiao " +
                    "ORDER BY R.NomeRegiao, E.NomeEstado");

                AutoMapper.Configuration.AddIdentifier(
                    typeof(Regiao), "IdRegiao");
                AutoMapper.Configuration.AddIdentifier(
                    typeof(Estado), "SiglaEstado");

                List<Regiao> regioes = (AutoMapper.MapDynamic<Regiao>(dados)
                    as IEnumerable<Regiao>).ToList();

                return regioes;
            }
        }
    }
}