using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Testadacondominio {
        [Key]
        [Column(Order = 1)]
        public int Codcond { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Numface { get; set; }
        public decimal Areatestada { get; set; }
    }
}
