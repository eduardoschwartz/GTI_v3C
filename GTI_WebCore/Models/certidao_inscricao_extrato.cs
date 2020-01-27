using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_WebCore.Models {
    public class Certidao_Inscricao_Extrato {
        public string Id { get; set; }
        [Key]
        [Column(Order = 1)]
        public int Numero_certidao { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Ano_certidao { get; set; }
        [Key]
        [Column(Order = 3)]
        public int Codigo { get; set; }
        [Key]
        [Column(Order = 4)]
        public short Ano { get; set; }
        [Key]
        [Column(Order = 5)]
        public short Lancamento_Codigo { get; set; }
        [Key]
        [Column(Order = 6)]
        public byte Sequencia { get; set; }
        [Key]
        [Column(Order = 7)]
        public byte Parcela { get; set; }
        [Key]
        [Column(Order = 8)]
        public byte Complemento { get; set; }
        public string Lancamento_Descricao { get; set; }
        public DateTime Data_Vencimento { get; set; }
        public DateTime Data_Pagamento { get; set; }
        public decimal Valor_Pago { get; set; }
    }
}
