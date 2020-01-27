using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Cadastro {
        [Key]
        public int Idcadastro { get; set; }
        public int Idcda { get; set; }
        public string Setordevedor { get; set; }
        public int? Crc { get; set; }
        public string Nome { get; set; }
        public string Inscricao { get; set; }
        public string Cpfcnpj { get; set; }
        public string Rginscrestadual { get; set; }
        public string Localcep { get; set; }
        public string Localendereco { get; set; }
        public int? Localnumero { get; set; }
        public string Localcomplemento { get; set; }
        public string Localbairro { get; set; }
        public string Localcidade { get; set; }
        public string LocalEstado { get; set; }
        public string Quadra { get; set; }
        public string Lote { get; set; }
        public string Entregacep { get; set; }
        public string Entregaendereco { get; set; }
        public int? Entreganumero { get; set; }
        public string Entregacomplemento { get; set; }
        public string Entregabairro { get; set; }
        public string Entregacidade { get; set; }
        public string Entregaestado { get; set; }
        public DateTime? Dtgeracao { get; set; }
        public DateTime? Dtleitura { get; set; }
    }
}
