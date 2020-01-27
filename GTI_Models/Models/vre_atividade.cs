
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Vre_atividade {
        [Key]
        [Column(Order=1)]
        public int Id { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Cnae { get; set; }
        public bool Principal { get; set; }
        public bool Exercida { get; set; }
    }
}
