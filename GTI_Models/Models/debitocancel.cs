using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Debitocancel {
        [Key]
        [Column(Order =1)]
        public string Numprocesso { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Codreduzido { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Anoexercicio { get; set; }
        [Key]
        [Column(Order = 4)]
        public short Codlancamento { get; set; }
        [Key]
        [Column(Order = 5)]
        public short Seqlancamento { get; set; }
        [Key]
        [Column(Order = 6)]
        public byte Numparcela { get; set; }
        [Key]
        [Column(Order = 7)]
        public byte Codcomplemento { get; set; }
        public string Usuario_apagar { get; set; }
        public DateTime Datacancel { get; set; }
        public string Motivo { get; set; }
        public int Userid { get; set; }
    }
}
