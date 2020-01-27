using System;

namespace GTI_WebCore.Models.ReportModels {
    public class Certidao {
        public int Codigo { get; set; }
        public int Ano { get; set; }
        public int Numero { get; set; }
        public string Numero_Ano { get; set; }
        public string Inscricao { get; set; }
        public string Nome_Requerente { get; set; }
        public string Endereco { get; set; }
        public int Endereco_Numero { get; set; }
        public string Endereco_Complemento { get; set; }
        public string Bairro { get; set; }
        public string Quadra_Original { get; set; }
        public string Lote_Original { get; set; }
        public string Controle { get; set; }
        public DateTime Data_Geracao { get; set; }
        public decimal Area { get; set; }
        public decimal VVT { get; set; }
        public decimal VVP { get; set; }
        public decimal VVI { get; set; }
        public string Numero_Processo { get; set; }
        public DateTime Data_Processo { get; set; }
        public decimal Percentual_Isencao { get; set; }
        public string Insc_Estadual { get; set; }
        public DateTime Data_Abertura { get; set; }
        public DateTime Data_Encerramento { get; set; }
        public string Processo_Abertura { get; set; }
        public string Processo_Encerramento { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Razao_Social { get; set; }
        public string Nome_Fantasia { get; set; }
        public string Atividade_Extenso { get; set; }
        public string Cnae_Principal { get; set; }
        public string Cnae_Secundario { get; set; }
        public string Rg { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public short Exercicio { get; set; }
        public byte Lancamento_codigo { get; set; }
        public string Lancamento_Nome { get; set; }
        public byte Sequencia_Lancamento { get; set; }
        public byte Parcela { get; set; }
        public byte Complemento { get; set; }
        public DateTime Data_Vencimento { get; set; }
        public DateTime Data_Pagamento { get; set; }
        public decimal Valor_Pago { get; set; }
        public string Tipo_Certidao { get; set; }
        public string Nao { get; set; }
        public string Certifica { get; set; }
        public string Tributo { get; set; }
    }
}
