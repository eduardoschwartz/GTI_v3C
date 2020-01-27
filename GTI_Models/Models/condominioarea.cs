using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GTI_Models.Models {
    public class Condominioarea {
        [Key]
        [Column(Order = 1)]
        public int Codcondominio { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Seqarea { get; set; }
        public string Tipoarea { get; set; }
        public decimal Areaconstr { get; set; }
        public short Usoconstr { get; set; }
        public short Tipoconstr { get; set; }
        public short Catconstr { get; set; }
        public DateTime? Dataaprova { get; set; }
        public string Numprocesso { get; set; }
        public DateTime? Dataprocesso { get; set; }
        public short Qtdepav { get; set; }

    }
}
