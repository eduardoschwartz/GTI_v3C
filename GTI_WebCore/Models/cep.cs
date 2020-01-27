using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_WebCore.Models {
    public class Cep {
        [Key]
        [Column(Order = 1)]
        public int Codlogr { get; set; }
        [Key]
        [Column(Order = 2)]
        public int cep { get; set; }
        [Key]
        [Column(Order = 3)]
        public int Valor1 { get; set; }
        [Required]
        public int Valor2 { get; set; }
        [Required]
        public bool Impar { get; set; }
        [Required]
        public bool Par { get; set; }
        public short? Codbairro { get; set; }
    }

}
