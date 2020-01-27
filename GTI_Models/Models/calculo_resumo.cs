using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Calculo_resumo {
        [Key]
        [Column(Order =1)]
        public short Ano { get; set; }
        public int Codigo { get; set; }
        public short Lancamento { get; set; }
        public byte Qtde_parcela { get; set; }
        public decimal? Valor0 { get; set; }
        public decimal? Valor1 { get; set; }
        public decimal? Valor91 { get; set; }
        public decimal? Valor92 { get; set; }
        public int? Documento0 { get; set; }
        public int? Documento91 { get; set; }
        public int? Documento92 { get; set; }
        public int? Documento1 { get; set; }
        public DateTime? Vencimento1 { get; set; }
        public int? Documento2 { get; set; }
        public DateTime? Vencimento2 { get; set; }
        public int? Documento3 { get; set; }
        public DateTime? Vencimento3 { get; set; }
        public int? Documento4 { get; set; }
        public DateTime? Vencimento4 { get; set; }
        public int? Documento5 { get; set; }
        public DateTime? Vencimento5 { get; set; }
        public int? Documento6 { get; set; }
        public DateTime? Vencimento6 { get; set; }
        public int? Documento7 { get; set; }
        public DateTime? Vencimento7 { get; set; }
        public int? Documento8 { get; set; }
        public DateTime? Vencimento8 { get; set; }
        public int? Documento9 { get; set; }
        public DateTime? Vencimento9 { get; set; }
        public int? Documento10 { get; set; }
        public DateTime? Vencimento10 { get; set; }
        public int? Documento11 { get; set; }
        public DateTime? Vencimento11 { get; set; }
        public int? Documento12 { get; set; }
        public DateTime? Vencimento12 { get; set; }
    }
}
