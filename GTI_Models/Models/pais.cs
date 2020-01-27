using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Pais {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_pais { get; set; }
        [Required]
        [StringLength(50)]
        [Index("PaisNome_Index", IsUnique = true)]
        public string Nome_pais { get; set; }
    }
}
