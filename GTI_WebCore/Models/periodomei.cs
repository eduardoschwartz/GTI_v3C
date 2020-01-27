using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_WebCore.Models {
    public class Periodomei {
        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public DateTime Datainicio { get; set; }
        public DateTime? Datafim { get; set; }
        public string Cnpj_base { get; set; }
        public DateTime? Data_exportacao { get; set; }
    }
}
