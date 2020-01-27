using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Cidadao {
        [Key]
        public int Codcidadao { get; set; }
        [Required]
        [StringLength(100)]
        public string Nomecidadao { get; set; }
        [StringLength(14)]
        public string Cpf { get; set; }
        [StringLength(18)]
        public string Cnpj { get; set; }
        public int? Codlogradouro { get; set; }
        public short? Numimovel { get; set; }
        [StringLength(50)]
        public string Complemento { get; set; }
        public short? Codbairro { get; set; }
        public short? Codcidade { get; set; }
        public string Siglauf { get; set; }
        public int? Cep { get; set; }
        [StringLength(30)]
        public string Telefone { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(25)]
        public string Rg { get; set; }
        [StringLength(50)]
        public string Nomelogradouro { get; set; }
        [StringLength(25)]
        public string Orgao { get; set; }
        [StringLength(50)]
        public string Nomecidade { get; set; }
        [StringLength(50)]
        public string Nomebairro { get; set; }
        [StringLength(2)]
        public string Nomeuf { get; set; }
        public bool? Juridica { get; set; }
        [StringLength(50)]
        public string Pais { get; set; }
        public int? Codlogradouro2 { get; set; }
        public short? Numimovel2 { get; set; }
        [StringLength(50)]
        public string Complemento2 { get; set; }
        public short? Codbairro2 { get; set; }
        public short? Codcidade2 { get; set; }
        public string Siglauf2 { get; set; }
        public int? Cep2 { get; set; }
        [StringLength(50)]
        public string Nomelogradouro2 { get; set; }
        [StringLength(1)]
        public string Etiqueta { get; set; }
        [StringLength(50)]
        public string Pais2 { get; set; }
        [StringLength(30)]
        public string Telefone2 { get; set; }
        [StringLength(50)]
        public string Email2 { get; set; }
        [StringLength(1)]
        public string Etiqueta2 { get; set; }
        public DateTime? Data_nascimento { get; set; }
        [StringLength(50)]
        public string Profissao { get; set; }
        public int? Codprofissao { get; set; }
        public int? Codpais { get; set; }
        public int? Codpais2 { get; set; }
        public bool? Temfone { get; set; }
        public bool? Temfone2 { get; set; }
        public bool? Whatsapp { get; set; }
        public bool? Whatsapp2 { get; set; }
    }

    public class CidadaoStruct {
        public int Codigo { get; set; }
        public String Nome { get; set; }
        public DateTime? DataNascto { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Rg { get; set; }
        public string Orgao { get; set; }
        public bool Juridica { get; set; }
        public string Profissao { get; set; }
        public int? CodigoProfissao { get; set; }
        public int? CodigoLogradouroR { get; set; }
        public string EnderecoR { get; set; }
        public short? NumeroR { get; set; }
        public string ComplementoR { get; set; }
        public short? CodigoBairroR { get; set; }
        public string NomeBairroR { get; set; }
        public short? CodigoCidadeR { get; set; }
        public string NomeCidadeR { get; set; }
        public string UfR { get; set; }
        public int? CepR { get; set; }
        public string PaisR { get; set; }
        public string TelefoneR { get; set; }
        public string EmailR { get; set; }
        public int? CodigoLogradouroC { get; set; }
        public string EnderecoC { get; set; }
        public short? NumeroC { get; set; }
        public string ComplementoC { get; set; }
        public short? CodigoBairroC { get; set; }
        public string NomeBairroC { get; set; }
        public short? CodigoCidadeC { get; set; }
        public string NomeCidadeC { get; set; }
        public string UfC { get; set; }
        public int? CepC { get; set; }
        public string PaisC { get; set; }
        public string TelefoneC { get; set; }
        public string EmailC { get; set; }
        public string EtiquetaR { get; set; }
        public string EtiquetaC { get; set; }
        public byte Tipodoc { get; set; }
        public int? CodigoPaisR { get; set; }
        public int? CodigoPaisC { get; set; }
        public bool? Temfone { get; set; }
        public bool? Temfone2 { get; set; }
        public bool? Whatsapp { get; set; }
        public bool? Whatsapp2 { get; set; }
    }

}
