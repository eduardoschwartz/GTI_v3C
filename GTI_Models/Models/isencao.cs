
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Isencao {
        [Key]
        [Column(Order =1)]
        public int Codreduzido { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Anoisencao { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Codisencao { get; set; }
        public string Numprocesso { get; set; }
        public DateTime? dataprocesso { get; set; }
        public decimal? Percisencao { get; set; }
        public bool? Filantropico { get; set; }
        public byte? Periodo { get; set; }
        public string Motivo { get; set; }
        public short? Anoproc { get; set; }
        public int? Numproc { get; set; }
        public DateTime? dataaltera { get; set; }
        public int? Userid { get; set; }
    }

    public class IsencaoStruct {
        [Key]
        [Column(Order = 1)]
        public int Codreduzido { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Anoisencao { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Codisencao { get; set; }
        public string Numprocesso { get; set; }
        public DateTime? dataprocesso { get; set; }
        public decimal? Percisencao { get; set; }
        public bool? Filantropico { get; set; }
        public byte? Periodo { get; set; }
        public string Motivo { get; set; }
        public short? Anoproc { get; set; }
        public int? Numproc { get; set; }
        public DateTime? dataaltera { get; set; }
        public int? Userid { get; set; }
    }


}
