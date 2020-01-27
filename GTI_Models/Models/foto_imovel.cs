using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Foto_imovel {
        [Key]
        [Column(Order = 1)]
        public int Codigo { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Seq { get; set; }
        public short Pasta { get; set; }
        public string Arquivo { get; set; }
    }
}
