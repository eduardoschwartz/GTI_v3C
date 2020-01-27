using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_WebCore.Models {
    public class Certidao_Inscricao {
        [Key]
        [Column(Order = 1)]
        public int Numero { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Ano { get; set; }
        public DateTime Data_emissao { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public int Cadastro { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Documento { get; set; }
        public string Cidade { get; set; }
        public string Atividade { get; set; }
        public DateTime  Data_abertura { get; set; }
        public string Processo_abertura { get; set; }
        public DateTime? Data_encerramento { get; set; }
        public string Processo_encerramento { get; set; }
        public string Inscricao_estadual { get; set; }
        public string Nome_fantasia { get; set; }
        public string Atividade_secundaria { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Situacao { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Taxa_licenca { get; set; }
        public string Vigilancia_sanitaria { get; set; }
        public string Mei { get; set; }
        public decimal Area { get; set; }
        public string Atividade_Extenso { get; set; }
    }
}
