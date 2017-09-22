using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace ExemplosGerais.Controllers
{
    [Produces("application/json")]
    [Route("api/Regioes")]
    public class RegioesController : Controller
    {
        [HttpGet]
        public IEnumerable<Regiao> GetRegioes(
            [FromServices]IConfiguration config)
        {
            using (SqlConnection conexao = new SqlConnection(
                config.GetConnectionString("ExemplosDapper")))
            {
                return conexao.Query<Regiao>(
                    "SELECT * " +
                    "FROM dbo.VW_DETALHESREGIOES " +
                    "ORDER BY NomeRegiao");
            }
        }
    }
}