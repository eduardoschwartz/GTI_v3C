using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Vre_socio {
        [Key]
        [Column(Order =1)]
        public int Id { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Numero { get; set; }
        public string Nome { get; set; }
    }
}
