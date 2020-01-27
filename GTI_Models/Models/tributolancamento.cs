
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Tributolancamento {
        [Key]
        [Column(Order=1)]
        public short Codlancamento { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Codtributo { get; set; }
    }
}
