using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Logevento {
        [Key]
        public int Seq { get; set; }
        public DateTime Datahoraevento { get; set; }
        public string Computador { get; set; }
        public string Form { get; set; }
        public short Evento { get; set; }
        public short Secevento { get; set; }
        public string LogEvento { get; set; }
        public int? Userid { get; set; }
    }
}
