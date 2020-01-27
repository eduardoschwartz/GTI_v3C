using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Cdadebitos {
        [Key]
        public int Idcdadebitos { get; set; }
        public int Idcda { get; set; }
        public int Codtributo { get; set; }
        public string Tributo { get; set; }
        public int Exercicio { get; set; }
        public int Lancamento { get; set; }
        public int Seq { get; set; }
        public int Nroparcela { get; set; }
        public int Complparcela { get; set; }
        public DateTime Dtvencimento { get; set; }
        public decimal Vlroriginal { get; set; }
        public decimal Vlrmultas { get; set; }
        public decimal Vlrjuros { get; set; }
        public decimal Vlrcorrecao { get; set; }
        public DateTime Dtgeracao { get; set; }
        public DateTime Dtleitura { get; set; }
    }
}
