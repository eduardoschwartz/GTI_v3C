using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_WebCore.Models {
    public class Areas {
        [Key]
        [Column(Order = 1)]
        public int Codreduzido { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Seqarea { get; set; }
        public string Tipoarea { get; set; }
        public decimal? Areaconstr { get; set; }
        public short Usoconstr { get; set; }
        public short Tipoconstr { get; set; }
        public short Catconstr { get; set; }
        public DateTime? Dataaprova { get; set; }
        public string Numprocesso { get; set; }
        public DateTime? Dataprocesso { get; set; }
        public short Qtdepav { get; set; }
    }

    public class AreaStruct {
        [Key]
        [Column(Order = 1)]
        public int Codigo { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Seq { get; set; }
        public string Tipo_Area { get; set; }
        public decimal Area { get; set; }
        public short Uso_Codigo { get; set; }
        public string Uso_Nome { get; set; }
        public short Tipo_Codigo { get; set; }
        public string Tipo_Nome { get; set; }
        public short Categoria_Codigo { get; set; }
        public string Categoria_Nome { get; set; }
        public DateTime? Data_Aprovacao { get; set; }
        public string Numero_Processo { get; set; }
        public DateTime? Data_Processo { get; set; }
        public short Pavimentos { get; set; }
    }


}
