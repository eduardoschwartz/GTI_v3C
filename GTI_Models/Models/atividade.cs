using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Atividade {
        [Key]
        public int Codatividade { get; set; }
        public string Descatividade { get; set; }
        public decimal? Valoraliq1 { get; set; }
        public decimal? Valoraliq2 { get; set; }
        public decimal? Valoraliq3 { get; set; }
        public string Tipo { get; set; }
        public byte? Alvara { get; set; }
        public int? Horario { get; set; }
    }
}
