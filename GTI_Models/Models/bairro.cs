using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Bairro {
        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string Siglauf { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Codcidade { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Codbairro { get; set; }
        [Required]
        [StringLength(50)]
        public string Descbairro { get; set; }

    }
}
