using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Carta_cobranca_exclusao {
        [Key]
        [Column(Order = 1)]
        public short Remessa { get; set; }
        [Column(Order = 2)]
        public int Codigo { get; set; }
    }
}
