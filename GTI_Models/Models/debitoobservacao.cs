using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Debitoobservacao {
        [Key]
        [Column(Order = 1)]
        public int Codreduzido { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Seq { get; set; }
        public DateTime? Dataobs { get; set; }
        public string Obs { get; set; }
        public int Userid { get; set; }
    }

    public class DebitoobservacaoStruct {
        [Key]
        [Column(Order = 1)]
        public int Codreduzido { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Seq { get; set; }
        public DateTime? Dataobs { get; set; }
        public string Obs { get; set; }
        public int Userid { get; set; }
        public string NomeLogin { get; set; }
        public string NomeCompleto { get; set; }
    }


}
