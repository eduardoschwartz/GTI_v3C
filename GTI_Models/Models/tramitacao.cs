using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Tramitacao {
        [Key]
        [Column(Order = 1)]
        public short Ano { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Numero { get; set; }
        [Key]
        [Column(Order = 3)]
        public byte Seq { get; set; }
        public short Ccusto { get; set; }
        public DateTime Datahora { get; set; }
        public short? Despacho { get; set; }
        public DateTime? Dataenvio { get; set; }
        public string Obs { get; set; }
        public string Obsinterna { get; set; }
        public int? Userid { get; set; }
        public int? Userid2 { get; set; }
    }

    public class TramiteStruct {
        public int Ano { get; set; }
        public int Numero { get; set; }
        public int Seq { get; set; }
        public short CentroCustoCodigo { get; set; }
        public string CentroCustoNome { get; set; }
        public string DataEntrada { get; set; }
        public string HoraEntrada { get; set; }
        public int? Userid1 { get; set; }
        public string Usuario1 { get; set; }
        public short DespachoCodigo { get; set; }
        public string DespachoNome { get; set; }
        public string DataEnvio { get; set; }
        public int? Userid2 { get; set; }
        public string Usuario2 { get; set; }
        public string Nome_usuario { get; set; }
        public string Obs { get; set; }
        public string Telefone { get; set; }
    }
}
