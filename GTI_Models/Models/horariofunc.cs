using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Horariofunc {
        [Key]
        public short Codhorario { get; set; }
        [StringLength(30)]
        public string Deschorario { get; set; }

    }
}
