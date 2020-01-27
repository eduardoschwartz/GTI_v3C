using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Situacaolancamento {
        [Key]
        public byte Codsituacao { get; set; }
        public string Descsituacao { get; set; }
    }
}
