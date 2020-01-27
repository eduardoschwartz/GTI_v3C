
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class DEmpresa {
        [Key]
        [Column(Order=1)]
        public int sid { get; set; }
        [Key]
        [Column(Order = 2)]
        public string nome { get; set; }
        public string valor { get; set; }
        public int? principal { get; set; }
    }
}
