using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_WebCore.Models {
    public class Centrocusto {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Codigo { get; set; }
        [Required]
        [StringLength(50)]
        [Index("LocalNome_Index", IsUnique = true)]
        public string Descricao { get; set; }
        [StringLength(18)]
        public string Telefone { get; set; }
        public short Vinculo { get; set; }
        public bool Ativo { get; set; }
        public bool? Local { get; set; }
    }
}
