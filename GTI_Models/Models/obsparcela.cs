using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models { 
    public class Obsparcela {
        [Key]
        [Column(Order = 1)]
        public int Codreduzido { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Anoexercicio { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Codlancamento { get; set; }
        [Key]
        [Column(Order = 4)]
        public short Seqlancamento { get; set; }
        [Key]
        [Column(Order = 5)]
        public byte Numparcela { get; set; }
        [Key]
        [Column(Order = 6)]
        public byte Codcomplemento { get; set; }
        [Key]
        [Column(Order = 7)]
        public short Seq { get; set; }
        public string Obs { get; set; }
        public DateTime? Data { get; set; }
        public int Userid { get; set; }
    }

    public class ObsparcelaStruct {
        [Key]
        [Column(Order = 1)]
        public int Codreduzido { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Anoexercicio { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Codlancamento { get; set; }
        [Key]
        [Column(Order = 4)]
        public short Seqlancamento { get; set; }
        [Key]
        [Column(Order = 5)]
        public byte Numparcela { get; set; }
        [Key]
        [Column(Order = 6)]
        public byte Codcomplemento { get; set; }
        [Key]
        [Column(Order = 7)]
        public short Seq { get; set; }
        public string Obs { get; set; }
        public DateTime? Data { get; set; }
        public int Userid { get; set; }
        public string NomeLogin { get; set; }
        public string NomeCompleto { get; set; }
    }



}
