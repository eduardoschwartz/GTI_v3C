using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Tramitacaocc {
        [Key]
        [Column(Order = 1)]
        public short Ano { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Numero { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Seq { get; set; }
        public short Ccusto { get; set; }
    }
}
