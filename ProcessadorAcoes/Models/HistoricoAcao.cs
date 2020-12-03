using System;
using Dapper.Contrib.Extensions;

namespace ProcessadorAcoes.Models
{
    [Table("dbo.HistoricoAcoes")]
    public class HistoricoAcao
    {
        [Key]
        public int Id { get; set; }
        public string CodReferencia { get; set; }
        public string Codigo { get; set; }
        public DateTime? DataReferencia { get; set; }
        public double? Valor { get; set; }
        public string CodCorretora { get; set; }
        public string NomeCorretora { get; set; }
    }
}