using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GTI_Models.Models {
    public class Mobiliarioproprietario {
        [Key]
        [Column(Order = 1)]
        public int Codmobiliario { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Codcidadao { get; set; }
        public int Principal { get; set; }
    }

    public class MobiliarioproprietarioStruct {
        public int Codmobiliario { get; set; }
        public int Codcidadao { get; set; }
        public string Nome { get; set; }
        public int? Principal { get; set; }
    }
}