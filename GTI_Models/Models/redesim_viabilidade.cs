using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Redesim_viabilidade {
        [Key]
        public string Protocolo { get; set; }
        public string Analise { get; set; }
        public string Nire { get; set; }
        public string Cnpj { get; set; }
        public string EmpresaEstabelecida { get; set; }
        public string AtividadeAuxiliar { get; set; }
        public DateTime? DataProtocolo { get; set; }
        public DateTime? DataResultadoAnalise { get; set; }
        public DateTime? DataResultadoViabilidade { get; set; }
        public string TempoAndamento { get; set; }
        public string Cep { get; set; }
        public string TipoInscricaoImovel { get; set; }
        public string NumeroInscricaoImovel { get; set; }
        public string TipoLogradouro { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string TipoUnidade { get; set; }
        public string FormaAtuacao { get; set; }
        public string Municipio { get; set; }
        public string RazaoSocial { get; set; }
        public string Orgao { get; set; }
        public decimal AreaImovel { get; set; }
        public decimal AreaEstabelecimento { get; set; }
        public string Cpf { get; set; }
        public string NomeArquivo { get; set; }
        public string Evento_codigo { get; set; }
        public string Evento_nome { get; set; }
        public string Cnae { get; set; }
        public DateTime Data_Importacao { get; set; }
    }

    public class Redesim_viabilidadeStuct {
        public string Protocolo { get; set; }
        public string Analise { get; set; }
        public string Nire { get; set; }
        public string Cnpj { get; set; }
        public string EmpresaEstabelecida { get; set; }
        public string AtividadeAuxiliar { get; set; }
        public DateTime? DataProtocolo { get; set; }
        public DateTime? DataResultadoAnalise { get; set; }
        public DateTime? DataResultadoViabilidade { get; set; }
        public string TempoAndamento { get; set; }
        public string Cep { get; set; }
        public string TipoInscricaoImovel { get; set; }
        public string NumeroInscricaoImovel { get; set; }
        public string TipoLogradouro { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string TipoUnidade { get; set; }
        public string FormaAtuacao { get; set; }
        public string Municipio { get; set; }
        public string RazaoSocial { get; set; }
        public string Orgao { get; set; }
        public decimal AreaImovel { get; set; }
        public decimal AreaEstabelecimento { get; set; }
        public string Cpf { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime Data_Importacao { get; set; }
        public string Evento_codigo { get; set; }
        public string Evento_nome { get; set; }
        public string Cnae { get; set; }
        public bool Already_inDB { get; set; }
    }

    public class Redesim_evento {
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }

}
