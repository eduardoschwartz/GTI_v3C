using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Processogti {
        [Key]
        [Column(Order = 1)]
        [Index("ProcessoNumero_Index", IsUnique = true, Order = 1)]
        public short Ano { get; set; }
        [Key]
        [Column(Order = 2)]
        [Index("ProcessoNumero_Index", IsUnique = true, Order = 2)]
        public int Numero { get; set; }
        [Required]
        public bool Fisico { get; set; }
        [Required]
        public short Origem { get; set; }
        [Required]
        public bool Interno { get; set; }
        [Required]
        public short Codassunto { get; set; }
        [StringLength(150)]
        public string Complemento { get; set; }
        [StringLength(5000)]
        public string Observacao { get; set; }
        public DateTime Dataentrada { get; set; }
        public DateTime? Datareativa { get; set; }
        public DateTime? Datacancel{ get; set; }
        public DateTime? Dataarquiva { get; set; }
        public DateTime? Datasuspenso { get; set; }
        [StringLength(250)]
        public string Obsa { get; set; }
        [StringLength(250)]
        public string Obsr { get; set; }
        [StringLength(250)]
        public string Obsc { get; set; }
        [StringLength(250)]
        public string Obss { get; set; }
        public int? Insc { get; set; }
        public int? Codcidadao { get; set; }
        public string Motivocancel { get; set; }
        public int? Centrocusto { get; set; }
        public string Tipoend { get; set; }
        public bool? Etiqueta { get; set; }
        public string Hora { get; set; }
        public int? Userid { get; set; }
    }

    public class ProcessoStruct {
        public string SNumero { get; set; }
        public int Numero { get; set; }
        public int Ano { get; set; }
        public int Dv { get; set; }
        public string Message { get; set; }
        public bool Valido { get; set; }
        public string Complemento { get; set; }
        public int? AtendenteId { get; set; }
        public string AtendenteNome { get; set; }
        public string Assunto { get; set; }
        public string Hora { get; set; }
        public int? CodigoAssunto { get; set; }
        public string Observacao { get; set; }
        public int? Inscricao { get; set; }
        public DateTime? DataEntrada { get; set; }
        public DateTime? DataSuspensao { get; set; }
        public DateTime? DataReativacao { get; set; }
        public DateTime? DataArquivado { get; set; }
        public DateTime? DataCancelado { get; set; }
        public List<ProcessoAnexoStruct> ListaAnexo { get; set; }
        public List<Anexo_logStruct> ListaAnexoLog { get; set; }
        public string Anexo { get; set; }
        public bool Interno { get; set; }
        public bool Fisico { get; set; }
        public int? Origem { get; set; }
        public int? CentroCusto { get; set; }
        public string CentroCustoNome { get; set; }
        public int? CodigoCidadao { get; set; }
        public string NomeCidadao { get; set; }
        public List<ProcessoEndStruct> ListaProcessoEndereco { get; set; }
        public string ObsArquiva { get; set; }
        public string ObsSuspensao { get; set; }
        public string ObsReativa { get; set; }
        public string ObsCancela { get; set; }
        public List<ProcessoDocStruct> ListaProcessoDoc { get; set; }
        public string TipoEnd { get; set; }
        public string ObsAnexo { get; set; }
        public string LogradouroNome { get; set; }
        public string LogradouroNumero { get; set; }
    }

    public class ProcessoEndStruct {
        public int? CodigoLogradouro { get; set; }
        public string NomeLogradouro { get; set; }
        public string Numero { get; set; }
    }

    public class ProcessoDocStruct {
        public int CodigoDocumento { get; set; }
        public string NomeDocumento { get; set; }
        public DateTime? DataEntrega { get; set; }
    }

    public class ProcessoAnexoStruct {
        public int AnoAnexo { get; set; }
        public int NumeroAnexo { get; set; }
        public string Requerente { get; set; }
        public string CentroCusto { get; set; }
        public string Complemento { get; set; }
    }

    public class AssuntoDocStruct {
        public int Codigo { get; set; }
        public String Nome { get; set; }
    }

    public class AssuntoLocal {
        public short Seq { get; set; }
        public short Codigo { get; set; }
        public String Nome { get; set; }
    }

    public class DespachoStruct {
        public int Codigo { get; set; }
        public String Nome { get; set; }
    }

    public class ProcessoCidadaoStruct {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string RG { get; set; }
        public string Orgao { get; set; }
        public int Logradouro_Codigo { get; set; }
        public string Logradouro_Nome { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }
        public int Bairro_Codigo { get; set; }
        public string Bairro_Nome { get; set; }
        public int Cidade_Codigo { get; set; }
        public string Cidade_Nome { get; set; }
        public string UF { get; set; }
        public int Cep { get; set; }
    }

    public class ProcessoFilter {
        public string SNumProcesso { get; set; }
        public int Ano { get; set; }
        public int Numero { get; set; }
        public int? AnoIni { get; set; }
        public int? AnoFim { get; set; }
        public int? Requerente { get; set; }
        public int? Setor { get; set; }
        public int? AssuntoCodigo { get; set; }
        public string AssuntoNome { get; set; }
        public bool? Interno { get; set; }
        public bool? Fisico { get; set; }
        public DateTime? DataEntrada { get; set; }
        public int CodLogradouro { get; set; }
        public int NumEnd { get; set; }
        public string Complemento { get; set; }
        public bool? Arquivado { get; set; }
        public int? Inscricao { get; set; }
    }

    public class UsuariocentroCusto {
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }

    public class UsuarioFuncStruct {
        public int FuncLogin { get; set; }
        public string NomeCompleto { get; set; }
    }

    public class ProcessoNumero {
        public int Ano { get; set; }
        public int Numero { get; set; }
    }



}
