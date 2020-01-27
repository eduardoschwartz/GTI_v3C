using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Cnaecriteriodesc {
        [Key]
        [Column(Order = 1)]
        public int Criterio { get; set; }
        public string Descricao { get; set; }
        public decimal? Valor { get; set; }
    }
}
