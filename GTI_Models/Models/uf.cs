using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {

    public class Uf {
        [Key]
        [StringLength(2)]
        public string Siglauf { get; set; }
        [Required]
        [StringLength(30)]
        [Index("UFNome_Index", IsUnique = true)]
        public string Descuf{ get; set; }

        public List<Cidade> Cidades { get; set; }
    }

}
