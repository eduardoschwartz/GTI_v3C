using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Serasa {
        [Key]
        [Column(Order =1)]
        public int Codigo { get; set; }
        [Key]
        [Column(Order = 2)]
        public DateTime Dtentrada { get; set; }
        public DateTime? Dtsaida { get; set; }
    }
}
