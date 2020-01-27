using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Escritoriocontabil {
        [Key]
        public int Codigoesc { get; set; }
        public string Nomeesc { get; set; }
        public int? Codlogradouro { get; set; }
        public string Nomelogradouro { get; set; }
        public int? Numero { get; set; }
        public short? Codbairro { get; set; }
        public string Cep { get; set; }
        public string UF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool? Recebecarne { get; set; }
        public string Crc { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public int? Im { get; set; }
        public string Complemento { get; set; }
        public int? Codcidade { get; set; }
    }

    public class EscritoriocontabilStruct {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int? Logradouro_Codigo { get; set; }
        public string Logradouro_Nome { get; set; }
        public string Logradouro_Nome_Fora { get; set; }
        public int? Numero { get; set; }
        public string Complemento { get; set; }
        public short? Bairro_Codigo { get; set; }
        public string Bairro_Nome { get; set; }
        public string Cep { get; set; }
        public int? Cidade_Codigo { get; set; }
        public string Cidade_Nome { get; set; }
        public string UF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool? Recebecarne { get; set; }
        public string Crc { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public int? Im { get; set; }
    }


}
