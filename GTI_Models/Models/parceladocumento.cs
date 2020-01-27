using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Parceladocumento {
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
        public int Numdocumento { get; set; }
        public decimal? Valorjuros { get; set; }
        public int? Codbanco { get; set; }
        public decimal? Valormulta { get; set; }
        public decimal? Valorcorrecao { get; set; }
        public bool? Intacto { get; set; }
        public short? Plano { get; set; }
    }

    public class ParceladocumentoStruct {
        [Key]
        [Column(Order = 1)]
        public byte Documento { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Codigo { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Exercicio { get; set; }
        [Key]
        [Column(Order = 4)]
        public short Lancamento { get; set; }
        [Key]
        [Column(Order = 5)]
        public short Sequencia { get; set; }
        [Key]
        [Column(Order = 6)]
        public byte Parcela { get; set; }
        [Key]
        [Column(Order = 7)]
        public byte Complemento { get; set; }
        public DateTime Data_Vencimento { get; set; }
        public decimal Valor_Principal { get; set; }
    }


}
