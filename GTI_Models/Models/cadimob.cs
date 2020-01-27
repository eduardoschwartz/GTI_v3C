using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Cadimob {
        [Key]
        public int Codreduzido { get; set; }
        public short Dv { get; set; }
        public int Codcondominio { get; set; }
        public short Distrito { get; set; }
        public short Setor { get; set; }
        public short Quadra { get; set; }
        public int Lote { get; set; }
        public short Seq { get; set; }
        public short Unidade { get; set; }
        public short Subunidade { get; set; }
        public short? Li_num { get; set; }
        public string Li_compl { get; set; }
        public string Li_cep { get; set; }
        public string Li_uf { get; set; }
        public short? Li_codcidade { get; set; }
        public short? Li_codbairro { get; set; }
        public string Li_quadras { get; set; }
        public string Li_lotes { get; set; }
        public decimal? Dt_areaterreno { get; set; }
        public short? Dt_codusoterreno { get; set; }
        public short? Dt_codbenf { get; set; }
        public short? Dt_codtopog { get; set; }
        public short? Dt_codcategprop { get; set; }
        public short? Dt_codsituacao { get; set; }
        public short? Dt_codpedol { get; set; }
        public string Dt_numagua { get; set; }
        public decimal? Dt_fracaoideal { get; set; }
        public short? Dc_qtdeedif { get; set; }
        public short? Dc_qtdepav { get; set; }
        public short Ee_tipoend { get; set; }
        public bool? Inativo { get; set; }
        public string Tipomat { get; set; }
        public Int64? Nummat { get; set; }
        public DateTime? Datainclusao { get; set; }
        public bool? Imune { get; set; }
        public bool? Conjugado { get; set; }
        public bool? Resideimovel { get; set; }
        public bool? Cip { get; set; }
    }

    public class ImovelStruct {
        public int Codigo { get; set; }
        public short Distrito { get; set; }
        public short Setor { get; set; }
        public short Quadra { get; set; }
        public int Lote { get; set; }
        public short Seq { get; set; }
        public short Unidade { get; set; }
        public short SubUnidade { get; set; }
        public int? CodigoCondominio { get; set; }
        public string NomeCondominio { get; set; }
        public bool? Imunidade { get; set; }
        public bool? Cip { get; set; }
        public bool? Conjugado { get; set; }
        public string TipoMat { get; set; }
        public long? NumMatricula { get; set; }
        public int? CodigoLogradouro { get; set; }
        public string NomeLogradouro { get; set; }
        public string NomeLogradouroAbreviado { get; set; }
        public short? Numero { get; set; }
        public string Complemento { get; set; }
        public short? CodigoBairro { get; set; }
        public string NomeBairro { get; set; }
        public string QuadraOriginal { get; set; }
        public string LoteOriginal { get; set; }
        public bool? Inativo { get; set; }
        public bool? ResideImovel { get; set; }
        public string Cep { get; set; }
        public short? EE_TipoEndereco { get; set; }
        public decimal? FracaoIdeal { get; set; }
        public decimal? Area_Terreno { get; set; }
        public short? Uso_terreno { get; set; }
        public string Uso_terreno_Nome { get; set; }
        public short? Benfeitoria { get; set; }
        public string Benfeitoria_Nome { get; set; }
        public short? Topografia { get; set; }
        public string Topografia_Nome { get; set; }
        public short? Categoria { get; set; }
        public string Categoria_Nome { get; set; }
        public short? Situacao { get; set; }
        public string Situacao_Nome { get; set; }
        public short? Pedologia { get; set; }
        public string Pedologia_Nome { get; set; }
        public string Inscricao { get; set; }
        public int? Proprietario_Codigo { get; set; }
        public string Proprietario_Nome { get; set; }
        public bool? Proprietario_Principal { get; set; }
    }

    public class LogradouroStruct {
        public int? CodLogradouro { get; set; }
        public string Endereco { get; set; }
    }

    public class EnderecoStruct {
        public int? CodLogradouro { get; set; }
        public string Endereco { get; set; }
        public string Endereco_Abreviado { get; set; }
        public short? Numero { get; set; }
        public string Complemento { get; set; }
        public string UF { get; set; }
        public short? CodigoBairro { get; set; }
        public string NomeBairro { get; set; }
        public short? CodigoCidade { get; set; }
        public string NomeCidade { get; set; }
        public string Cep { get; set; }
    }


}
