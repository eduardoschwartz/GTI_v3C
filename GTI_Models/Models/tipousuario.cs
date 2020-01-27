using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Tipousuario {
        [Key]
        public int Codigo { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}
