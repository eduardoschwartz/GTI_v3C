using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Carta_cobranca {
        [Key]
        [Column(Order =1)]
        public short Remessa { get; set; }
        [Column(Order = 2)]
        public int Codigo { get; set; }
        [Column(Order = 3)]
        public short Parcela { get; set; }
        public short Total_Parcela { get; set; }
        public string Parcela_Label { get; set; }
        public string Nome { get; set; }
        public string Cpf_cnpj { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Endereco_Entrega { get; set; }
        public string Bairro_Entrega { get; set; }
        public string Cidade_Entrega { get; set; }
        public string Cep_Entrega { get; set; }
        public DateTime Data_Vencimento { get; set; }
        public DateTime Data_Documento { get; set; }
        public string Inscricao { get; set; }
        public string Lote { get; set; }
        public string Quadra { get; set; }
        public string Atividade { get; set; }
        public int Numero_Documento { get; set; }
        public string Nosso_Numero { get; set; }
        public decimal Valor_Boleto { get; set; }
        public string Digitavel { get; set; }
        public string Codbarra { get; set; }
        public int Cep_entrega_cod { get; set; }
        public string Lancamento { get; set; }
    }
}
