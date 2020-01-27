using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GTI_WebCore.Models {
    public class Mobiliarioatividadeiss {
        [Key]
        [Column(Order = 1)]
        public int Codmobiliario { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Codtributo { get; set; }
        [Key]
        [Column(Order = 3)]
        public int Codatividade { get; set; }
        [Key]
        [Column(Order = 4)]
        public byte Seq { get; set; }
        public short Qtdeiss { get; set; }
        public decimal Valoriss { get; set; }
    }

    public class MobiliarioAtividadeISSStruct {
        public int Codigo_empresa { get; set; }
        public short Codigo_tributo { get; set; }
        public int Codigo_atividade { get; set; }
        public string Descricao { get; set; }
        public string Item { get; set; }
        public short Quantidade { get; set; }
        public float Valor { get; set; }
    }


}