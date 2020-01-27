using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Condominiounidade {
        [Key]
        [Column(Order = 1)]
        public int Cd_codigo { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Cd_unidade { get; set; }
        public short Cd_subunidades { get; set; }
    }
}
