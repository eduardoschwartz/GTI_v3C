using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Processocidadao {
        [Key]
        [Column(Order = 1)]
        public short Anoproc { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Numproc { get; set; }
        public int Codcidadao { get; set; }
        [Required]
        [StringLength(100)]
        public string Nomecidadao { get; set; }
        [StringLength(18)]
        public string Doc { get; set; }
        public int Codlogradouro { get; set; }
        public short Numimovel { get; set; }
        [StringLength(50)]
        public string Complemento { get; set; }
        public short Codbairro { get; set; }
        public short Codcidade { get; set; }
        [StringLength(2)]
        public string Siglauf { get; set; }
        public int Cep { get; set; }
        [StringLength(25)]
        public string Rg { get; set; }
        [StringLength(25)]
        public string Orgao { get; set; }
    }
}
