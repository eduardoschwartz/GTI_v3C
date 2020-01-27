using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Paramparcela {
        [Key]
        [Column(Order =1)]
        public short Codtipo { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Ano { get; set; }
        public short? Qtdeparcela { get; set; }
        public string Parcelaunica { get; set; }
        public decimal? Descontounica { get; set; }
        public decimal? Descontounica2 { get; set; }
        public decimal? Descontounica3 { get; set; }
        public DateTime? Venc01 { get; set; }
        public DateTime? Venc02 { get; set; }
        public DateTime? Venc03 { get; set; }
        public DateTime? Venc04 { get; set; }
        public DateTime? Venc05 { get; set; }
        public DateTime? Venc06 { get; set; }
        public DateTime? Venc07 { get; set; }
        public DateTime? Venc08 { get; set; }
        public DateTime? Venc09 { get; set; }
        public DateTime? Venc10 { get; set; }
        public DateTime? Venc11 { get; set; }
        public DateTime? Venc12 { get; set; }
    }
}
