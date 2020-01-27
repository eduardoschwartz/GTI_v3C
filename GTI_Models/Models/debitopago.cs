using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Debitopago {
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
        public byte Seqpag { get; set; }
        public DateTime Datapagamento { get; set; }
        public DateTime Datarecebimento { get; set; }
        public decimal Valorpago { get; set; }
        public short? Codbanco { get; set; }
        public int? Codagencia { get; set; }
        public DateTime? Restituido { get; set; }
        public int? Numdocumento { get; set; }
        public decimal? Valorpagoreal { get; set; }
        public bool? Intacto { get; set; }
        public decimal? Valortarifa { get; set; }
        public string Arquivobanco { get; set; }
        public decimal? Valordif { get; set; }
        public DateTime? Datapagamentocalc { get; set; }
        public DateTime? Dataintegracao { get; set; }
        public string Contacorrente { get; set; }
    }

    public class DebitoPagoStruct {
        [Key]
        [Column(Order = 1)]
        public int Codigo { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Ano { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Lancamento { get; set; }
        [Key]
        [Column(Order = 4)]
        public short Sequencia { get; set; }
        [Key]
        [Column(Order = 5)]
        public byte Parcela { get; set; }
        [Key]
        [Column(Order = 6)]
        public byte Complemento { get; set; }
        [Key]
        [Column(Order = 7)]
        public byte Sequencia_Pagamento { get; set; }
        public DateTime Data_Pagamento { get; set; }
        public DateTime? Data_Pagamento_Calc { get; set; }
        public DateTime Data_Recebimento { get; set; }
        public decimal Valor_Pago { get; set; }
        public decimal? Valor_Tarifa { get; set; }
        public short? Banco_Codigo { get; set; }
        public string Banco_Nome { get; set; }
        public int? Codigo_Agencia { get; set; }
        public DateTime? Restituido { get; set; }
        public int? Numero_Documento { get; set; }
        public decimal? Valor_Pago_Real { get; set; }
        public decimal? Valor_Dif { get; set; }
    }

}
