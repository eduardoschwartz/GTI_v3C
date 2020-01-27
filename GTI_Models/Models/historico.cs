using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Historico {
        [Key]
        [Column(Order =1)]
        public int Codreduzido { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Seq { get; set; }
        public string Datahist { get; set; }
        public string Deschist { get; set; }
        public DateTime? Datahist2 { get; set; }
        public int? Userid { get; set; }
    }

    public class HistoricoStruct {
        public int Codigo { get; set; }
        public short Seq { get; set; }
        public DateTime? Data { get; set; }
        public string Descricao { get; set; }
        public int? Usuario_Codigo { get; set; }
        public string Usuario_Nome { get; set; }
    }

}
