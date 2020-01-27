using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_WebCore.Models
{
    public class Cidade
    {
        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string Siglauf { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Codcidade { get; set; }
        [Required]
        [StringLength(50)]
        public string Desccidade { get; set; }

    }

}
