using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Tabelaiss {
        [Key]
        [Column(Order =1)]
        public int Tipoiss { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Codigoativ { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Seq { get; set; }
        public int? Codigo { get; set; }
        public string Descativ { get; set; }
        public float Aliquota { get; set; }
        public DateTime Data { get; set; }
    }
}
