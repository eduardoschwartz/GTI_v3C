using System.ComponentModel.DataAnnotations;

namespace GTI_WebCore.Models {
    public class Usoterreno {
        [Key]
        public short Codusoterreno { get; set; }
        public string Descusoterreno { get; set; }
    }
}
