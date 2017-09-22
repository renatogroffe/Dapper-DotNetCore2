using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace ExemploUpdateTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            var configuration = builder.Build();

            using (SqlConnection conexao = new SqlConnection(
                configuration.GetConnectionString("ExemplosDapper")))
            {
                Console.WriteLine("Atualizando o preço dos produtos...");

                conexao.Open();
                var transacao = conexao.BeginTransaction();

                conexao.Execute("UPDATE dbo.Produtos SET PrecoAnterior = Preco",
                    transaction: transacao);
                conexao.Execute("UPDATE dbo.Produtos SET Preco = Preco * 1.1",
                    transaction: transacao);

                transacao.Commit();
                conexao.Close();

                Console.WriteLine("Processo finalizado!");
                Console.ReadKey();
            }
        }
    }
}