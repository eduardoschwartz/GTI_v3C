using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Categconstr {
        [Key]
        public short Codcategconstr { get; set; }
        public string Desccategconstr { get; set; }
    }
}
