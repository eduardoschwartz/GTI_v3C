

using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Banco {
        [Key]
        public short Codbanco { get; set; }
        public string Nomebanco { get; set; }
        public string Agcontapref { get; set; }
        public string Numcontapref { get; set; }
        public byte Dvcontapref { get; set; }
        public string Nomereduz { get; set; }
    }
}
