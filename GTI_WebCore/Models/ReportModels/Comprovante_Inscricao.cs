using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTI_WebCore.Models.ReportModels {
    public class Comprovante_Inscricao {
        public int Numero { get; set; }
        public int Ano { get; set; }
        public DateTime Data_Emissao { get; set; }
        public string Controle { get; set; }
        public string Endereco { get; set; }
        public int Codigo { get; set; }
        public string Razao_Social { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Atividade { get; set; }
        public DateTime Data_Abertura { get; set; }
        public string Inscricao_Estadual { get; set; }
        public string Nome_Fantasia { get; set; }
        public string Cep { get; set; }
        public string Atividade2 { get; set; }
        public string Atividade_Extenso { get; set; }
        public string Complemento { get; set; }
        public string Situacao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Taxa_Licenca { get; set; }
        public string Vigilancia_Sanitaria { get; set; }
        public string Mei { get; set; }
        public decimal Area { get; set; }
        public string Rg { get; set; }
        public string Processo_Abertura { get; set; }
        public string Processo_Encerramento { get; set; }
        public DateTime Data_Encerramento { get; set; }
    }
}
