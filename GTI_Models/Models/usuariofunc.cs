using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Usuariofunc {
        [Key]
        [Column(Order = 1)]
        public int Userid { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Funclogin { get; set; }
    }
}
