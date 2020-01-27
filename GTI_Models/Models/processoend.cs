using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Processoend {
        [Key]
        [Column(Order = 1)]
        public short Ano { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Numprocesso { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Codlogr { get; set; }
        [Key]
        [Column(Order = 4)]
        [Required]
        [StringLength(15)]
        [Index("DocumentoNome_Index", IsUnique = true)]
        public string Numero { get; set; }
    }
}
