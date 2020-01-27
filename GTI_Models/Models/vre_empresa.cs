

using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Vre_empresa {
        [Key]
        public int Sid { get; set; }
        public int Id { get; set; }
        public string Razao_social { get; set; }
        public string Cnpj { get; set; }
        public DateTime? Data_abertura { get; set; }
        public Byte? Porte { get; set; }
        public string Numero_registro { get; set; }
        public byte? Tipo_registro { get; set; }
        public byte? Tipo_mei { get; set; }
        public string Cpf_responsavel { get; set; }
        public string Nome_responsavel { get; set; }
        public string Fone_contato1 { get; set; }
        public string Fone_contato2 { get; set; }
        public string Email_contato { get; set; }
        public string Setor_quadra_lote { get; set; }
        public string Tipo_logradouro { get; set; }
        public string Nome_logradouro { get; set; }
        public int? Numero_imovel { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Cep { get; set; }
        public float? Area_estabelecimento { get; set; }
        public string Nome_proprietario { get; set; }
        public string Email_proprietario { get; set; }
        public string Fone_proprietario { get; set; }
        public string Nome_responsavel_uso { get; set; }
        public string Fone_responsavel_uso { get; set; }
        public float? Area_total { get; set; }
        public byte? Pavimentos { get; set; }
        public byte? Contiguo { get; set; }
        public byte? Outros_usos { get; set; }
        public byte? Classif_CRC_PJ { get; set; }
        public byte? Classif_CRC_PF { get; set; }
        public string Numero_CRC_PJ { get; set; }
        public string Cnpj_contador { get; set; }
        public string Tipo_CRC_PF { get; set; }
        public string Tipo_CRC_PJ { get; set; }
        public string Numero_CRC_PF { get; set; }
        public string Uf_CRC_PF { get; set; }
        public string Uf_CRC_PJ { get; set; }
        public string Cpf_contador { get; set; }
        public string Nome_arquivo { get; set; }
        public DateTime? Data_importacao { get; set; }
        public string Situacao { get; set; }
        public int? Codreduzido { get; set; }
        public DateTime? Data_emissao { get; set; }
        public DateTime? Data_validade { get; set; }
        public string Protocolo { get; set; }
    }
}
