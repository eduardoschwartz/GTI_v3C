using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Carta_cobranca_detalhe {
        [Key]
        [Column(Order = 1)]
        public short Remessa { get; set; }
        [Column(Order = 2)]
        public int Codigo { get; set; }
        [Column(Order = 3)]
        public short Parcela { get; set; }
        [Column(Order = 4)]
        public short Ano { get; set; }
        public decimal Principal { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public decimal Correcao { get; set; }
        public decimal Total { get; set; }
        public short Ordem { get; set; }
    }
}
