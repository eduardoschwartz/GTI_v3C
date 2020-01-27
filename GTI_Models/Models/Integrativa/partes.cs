using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Partes {
        [Key]
        public int Idparte { get; set; }
        public int Idcda { get; set; }
        public string Tipo { get; set; }
        public int? Crc { get; set; }
        public string Nome { get; set; }
        public string Cpfcnpj { get; set; }
        public string Rginscrestadual { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public int? Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime? Dtgeracao { get; set; }
        public DateTime? Dtleitura { get; set; }
    }
}
