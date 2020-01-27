using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GTI_Models.Models {
    public class Assuntodoc {
        [Key]
        [Column(Order = 1)]
        public short Codassunto { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Coddoc { get; set; }
    }
}
