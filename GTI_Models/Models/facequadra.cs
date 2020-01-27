using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Facequadra {
        [Key]
        [Column(Order = 1)]
        public short Coddistrito { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Codsetor { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Codquadra { get; set; }
        [Key]
        [Column(Order = 4)]
        public short Codface { get; set; }
        public int? Codlogr { get; set; }
        public short? Codagrupa { get; set; }
        public byte? Pavimento { get; set; }
        public string Quadras { get; set; }
        public short? Codagrupanovo { get; set; }
        public string Alterado { get; set; }
    }

    public class FacequadraStruct {
        [Key]
        [Column(Order = 1)]
        public short Distrito { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Setor { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Quadra { get; set; }
        [Key]
        [Column(Order = 4)]
        public short Face { get; set; }
        public int? Logradouro_codigo { get; set; }
        public string Logradouro_nome { get; set; }
        public short? Agrupamento { get; set; }
    }


}
