using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Despacho {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Codigo { get; set; }
        [Required]
        [StringLength(40)]
        [Index("DespachoNome_Index", IsUnique = true)]
        public string Descricao { get; set; }
        public bool? Ativo { get; set; }
    }
}
