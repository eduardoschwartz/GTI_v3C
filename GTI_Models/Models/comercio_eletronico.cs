using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class comercio_eletronico {
        [Key]
        public int Numdoc { get; set; }
        public string Nossonumero { get; set; }
        public string Usuario { get; set; }
        public DateTime? Dataemissao { get; set; }
        public string Nome { get; set; }
        public string Cpfcnpj { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public int? Cep { get; set; }
        public DateTime? Datavencto { get; set; }
        public decimal? Valorguia { get; set; }
    }
}
