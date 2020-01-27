using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTI_WebCore.Models.ReportModels {
    public class Empresa_Detalhe {
        public int Codigo { get; set; }
        public string Razao_Social { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Inscricao_Estadual { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string Data_Abertura { get; set; }
        public string Data_Encerramento { get; set; }
        public string Atividade { get; set; }
        public string Situacao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string RegimeISS { get; set; }
        public string Taxa_Licenca { get; set; }
        public string Vigilancia_Sanitaria { get; set; }
        public string Cnae { get; set; }
        public string Mei { get; set; }
        public decimal Area { get; set; }
        public string Proprietario { get; set; }
    }
}
