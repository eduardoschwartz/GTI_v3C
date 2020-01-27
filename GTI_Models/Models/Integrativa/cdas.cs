using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Cdas {
        [Key]
        public int Idcda { get; set; }
        public string Iddevedor { get; set; }
        public string Setordevedor { get; set; }
        public DateTime Dtinscricao { get; set; }
        public int Nrocertidao { get; set; }
        public int Nrolivro { get; set; }
        public int Nrofolha { get; set; }
        public string Nroordem { get; set; }
        public DateTime Dtgeracao { get; set; }
        public DateTime? Dtleitura { get; set; }
    }
}
