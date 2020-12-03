using System;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper.Contrib.Extensions;
using ProcessadorAcoes.Models;

namespace ProcessadorAcoes.Data
{
    public class AcoesRepository
    {
        private readonly IConfiguration _configuration;

        public AcoesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Save(Acao acao)
        {
            using var conexaoSQL = new SqlConnection(
                _configuration.GetConnectionString("BaseAcoes"));
            conexaoSQL.Insert(new HistoricoAcao()
            {
                Codigo = acao.Codigo,
                CodReferencia = $"{acao.Codigo}{DateTime.Now:yyyyMMddHHmmss}",
                DataReferencia = DateTime.Now,
                Valor = acao.Valor,
                CodCorretora = acao.CodCorretora,
                NomeCorretora = acao.NomeCorretora
            });
        }
    }
}