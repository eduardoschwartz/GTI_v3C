using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Cancelamentos {
        [Key]
        public int Idcancelamento { get; set; }
        public DateTime? Dtcancelamento { get; set; }
        public int? Iddevedor { get; set; }
        public int? Nrolivro { get; set; }
        public int? Nrofolha { get; set; }
        public int? Seq { get; set; }
        public int? Lancamento { get; set; }
        public int? Exercicio { get; set; }
        public decimal? Vlroriginal { get; set; }
        public decimal? Vlrjuros { get; set; }
        public decimal? Vlrmulta { get; set; }
        public decimal? Vlrtotal { get; set; }
        public int? Nroparcela { get; set; }
        public int? Complparcela { get; set; }
        public bool? Ajuizado { get; set; }
        public DateTime? Dtgeracao { get; set; }
        public DateTime? Dtleitura { get; set; }
    }
}
