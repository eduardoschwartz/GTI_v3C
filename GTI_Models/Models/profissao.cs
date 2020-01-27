using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Profissao {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Codigo { get; set; }
        [Required]
        [Index("ProfissaoNome_Index", IsUnique = true)]
        [StringLength(100)]
        public string Nome { get; set; }


    }
}
