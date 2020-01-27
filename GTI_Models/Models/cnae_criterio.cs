
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Cnae_criterio {
        [Key]
        [Column(Order = 1)]
        public string Cnae { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Criterio { get; set; }
    }
}
