using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Debitotributo {
        [Key]
        [Column(Order = 1)]
        public int Codreduzido { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Anoexercicio { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Codlancamento { get; set; }
        [Key]
        [Column(Order = 4)]
        public short Seqlancamento { get; set; }
        [Key]
        [Column(Order = 5)]
        public byte Numparcela { get; set; }
        [Key]
        [Column(Order = 6)]
        public byte Codcomplemento { get; set; }
        [Key]
        [Column(Order = 7)]
        public short Codtributo { get; set; }
        public decimal? Valortributo { get; set; }
        public decimal? Valorcorrecao { get; set; }
        public decimal? Valormulta { get; set; }
        public decimal? Valorjuros { get; set; }
        public bool? Intacto { get; set; }
        public bool? Valorporbaixa { get; set; }
    }

    public class TributoStructure {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public Decimal Valor_Principal { get; set; }
        public Decimal Valor_Multa { get; set; }
        public Decimal Valor_Juros { get; set; }
        public Decimal Valor_Correcao { get; set; }
        public Decimal Valor_Total { get; set; }
    }
}
