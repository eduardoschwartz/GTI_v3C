using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Comprovante_pagamento {
        [Key]
        [Column(Order =1)]
        public int Ano { get; set; }
        public int Numero { get; set; }
        public string Controle { get; set; }
        public DateTime Data_emissao { get; set; }
        public string Banco { get; set; }
        public string Nome { get; set; }
        public DateTime Data_pagamento { get; set; }
        public decimal Valor { get; set; }
        public string Documento { get; set; }
        public string Cpfcnpj { get; set; }
    }
}
