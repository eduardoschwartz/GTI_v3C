using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Ficha_compensacao_documento {
        [Key]
        public int Numero_documento { get; set; }
        public DateTime Data_vencimento { get; set; }
        public decimal Valor_documento { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public DateTime? Data_lote { get; set; }
        public int? Numero_lote { get; set; }
        public String Cidade { get; set; }
        public string Uf { get; set; }
    }
}
