using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Segunda_via_web {
        [Key]
        [Column(Order =1)]
        public int Id { get; set; }
        public int Numero_documento { get; set; }
        public DateTime Data { get; set; }
    }
}
