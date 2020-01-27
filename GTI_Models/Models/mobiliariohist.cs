using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Mobiliariohist {
        [Key]
        [Column(Order =1)]
        public int Codmobiliario { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Seq { get; set; }
        public DateTime Datahist { get; set; }
        public string Obs { get; set; }
        public string Usuario_apagar { get; set; }
        public int? Userid { get; set; }
    }

    public class MobiliarioHistoricoStruct {
        public int Codigo { get; set; }
        public short Seq { get; set; }
        public DateTime Data { get; set; }
        public String Observacao { get; set; }
        public int? Usuario_id { get; set; }
        public string Usuario_Nome { get; set; }
    }


}
