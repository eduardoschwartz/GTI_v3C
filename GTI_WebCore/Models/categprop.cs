using System.ComponentModel.DataAnnotations;

namespace GTI_WebCore.Models {
    public class Categprop {
        [Key]
        public short Codcategprop { get; set; }
        public string Desccategprop { get; set; }
    }
}
