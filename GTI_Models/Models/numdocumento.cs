using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Numdocumento {
        [Key]
        public int numdocumento { get; set; }
        public DateTime? Datadocumento { get; set; }
        public short? Codbanco { get; set; }
        public string Codagencia { get; set; }
        public decimal? Valorpago { get; set; }
        public decimal? Valortaxadoc { get; set; }
        public byte? Isentomj { get; set; }
        public decimal? Percisencao { get; set; }
        public short? Tipodoc { get; set; }
        public string Emissor { get; set; }
        public decimal? Valorguia { get; set; }
        public bool? Registrado { get; set; }
        public int? Userid { get; set; }
    }


    public class Documento_parcela_valor {
        public int Numero { get; set; }
        public int Codigo { get; set; }
        public  short Ano { get; set; }
        public short Lancamento_codigo { get; set; }
        public string Lancamento_nome { get; set; }
        public short Sequencia { get; set; }
        public byte Parcela { get; set; }
        public byte Complemento { get; set; }
        public DateTime Data_vencimento { get; set; }
        public decimal Valor_parcela { get; set; }
    }

}
