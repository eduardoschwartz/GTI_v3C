using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GTI_Models.Models {
    public class Mei {
        [Key]
        [Column(Order = 1)]
        public int Codigo { get; set; }
        [Key]
        [Column(Order = 2)]
        public DateTime Datainicio { get; set; }
        public DateTime? Datafim { get; set; }
    }
}
