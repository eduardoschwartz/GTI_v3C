using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Tipolivro {
        [Key]
        public short Codtipo { get; set; }
        public string Desctipo { get; set; }
    }
}
