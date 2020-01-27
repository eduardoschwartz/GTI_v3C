using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_WebCore.Models {
    public class Condominio {
        [Key]
        public int Cd_codigo { get; set; }
        public string Cd_nomecond { get; set; }
        public short Cd_distrito { get; set; }
        public short Cd_setor { get; set; }
        public short Cd_quadra { get; set; }
        public int Cd_lote { get; set; }
        public short Cd_seq { get; set; }
        public short? Cd_num { get; set; }
        public string Cd_compl { get; set; }
        public string Cd_uf { get; set; }
        public short Cd_codcidade { get; set; }
        public short Cd_codbairro { get; set; }
        public string Cd_cep { get; set; }
        public string Cd_quadras { get; set; }
        public string Cd_lotes { get; set; }
        public decimal? Cd_areaterreno { get; set; }
        public short Cd_codusoterreno { get; set; }
        public short Cd_codbenf { get; set; }
        public short  Cd_codtopog { get; set; }
        public short Cd_codcategprop { get; set; }
        public short Cd_codsituacao { get; set; }
        public short Cd_codpedol { get; set; }
        public decimal? Cd_areatotconstr { get; set; }
        public short? Cd_numunid { get; set; }
        public int? Cd_prop { get; set; }
        public decimal? Cd_fracao { get; set; }
    }

    public class CondominioStruct {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public short Distrito { get; set; }
        public short Setor { get; set; }
        public short Quadra { get; set; }
        public int Lote { get; set; }
        public short Seq { get; set; }
        public int? Codigo_Logradouro { get; set; }
        public string Nome_Logradouro { get; set; }
        public short? Numero { get; set; }
        public string Complemento { get; set; }
        public short? Codigo_Bairro { get; set; }
        public string Nome_Bairro { get; set; }
        public string Quadra_Original { get; set; }
        public string Lote_Original { get; set; }
        public string Cep { get; set; }
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
        public decimal? Area_Construida { get; set; }
        public short? Qtde_Unidade { get; set; }
        public int? Codigo_Proprietario { get; set; }
        public decimal? Fracao_Ideal { get; set; }
    }
}
