using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Comunicado_isencao {
        [Key]
        [Column(Order =1)]
        public short Remessa { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Cpf_cnpj { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Endereco_entrega { get; set; }
        public string Bairro_entrega { get; set; }
        public string Cidade_entrega { get; set; }
        public string Cep_entrega { get; set; }
        public DateTime Data_documento { get; set; }
        public string Inscricao { get; set; }
        public string Lote { get; set; }
        public string Quadra { get; set; }
        public int Cep_entrega_cod { get; set; }
    }
}
