using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Logradouro {
        [Key]
        public int Codlogradouro { get; set; }
        [Required]
        [StringLength(150)]
        public string Endereco { get; set; }
        public string Endereco_resumido { get; set; }
    }
}
