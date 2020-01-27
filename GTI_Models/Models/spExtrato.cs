using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class SpExtrato {
        [Key]
        [Column(Order=1)]
        public string Usuario { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Codreduzido { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Anoexercicio { get; set; }
        [Key]
        [Column(Order = 4)]
        public short Codlancamento { get; set; }
        public string Desclancamento { get; set; }
        [Key]
        [Column(Order = 5)]
        public short Seqlancamento { get; set; }
        [Key]
        [Column(Order = 6)]
        public short Numparcela { get; set; }
        [Key]
        [Column(Order = 7)]
        public byte Codcomplemento { get; set; }
        public DateTime Datavencimento { get; set; }
        public DateTime Datavencimentocalc { get; set; }
        public short Statuslanc { get; set; }
        public string Situacao { get; set; }
        public string Numprocesso { get; set; }
        [Key]
        [Column(Order = 8)]
        public short Codtributo { get; set; }
        public decimal Valortributo { get; set; }
        public decimal Valorcorrecao { get; set; }
        public decimal Valormulta { get; set; }
        public decimal Valorjuros { get; set; }
        public decimal Valortotal { get; set; }
        public DateTime? Dataajuiza { get; set; }
        public DateTime? Datainscricao { get; set; }
        public bool? Valorporbaixa { get; set; }
        public string Abrevtributo { get; set; }
        public int? Numlivro { get; set; }
        public int? Pagina { get; set; }
        public int? Certidao { get; set; }
        public DateTime Datadebase { get; set; }
        public bool? Notificado { get; set; }
        public DateTime? Datapagamento { get; set; }
        public int? Numdocumento { get; set; }
        public decimal? Valorpago { get; set; }
        public decimal? Valorpagoreal { get; set; }
        public float? Percdesconto { get; set; }
        public int? Numexecfiscal { get; set; }
        public short? Anoexecfiscal { get; set; }
        public string Processocnj { get; set; }
        public int? Prot_certidao { get; set; }
        public DateTime? Prot_dtremessa { get; set; }
        public int? UserId { get; set; }
        
    }

    
}

