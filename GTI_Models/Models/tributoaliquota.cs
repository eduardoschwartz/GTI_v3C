
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Tributoaliquota {
        [Key]
        [Column(Order=1)]
        public short Ano { get; set; }
        [Key]
        [Column(Order = 2)]
        public  short Codtributo { get; set; }
        public decimal Valoraliq { get; set; }
    }
}
