using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_WebCore.Models {
    public class Documento {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Codigo { get; set; }
        [Required]
        [StringLength(100)]
        [Index("DocumentoNome_Index", IsUnique = true)]
        public string Nome { get; set; }
    }
}
