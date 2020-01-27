using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace GTI_Models.Models {
    public class Mobiliario {
        [Key]
        public int Codigomob { get; set; }
        public string Razaosocial { get; set; }
        public string Nomefantasia { get; set; }
        public int? Codlogradouro { get; set; }
        public short? Numero { get; set; }
        public string Complemento { get; set; }
        public short? Codbairro { get; set; }
        public short? Codcidade { get; set; }
        public string Siglauf { get; set; }
        public string Cep { get; set; }
        public string Homepage { get; set; }
        public short? Horario { get; set; }
        public DateTime Dataabertura { get; set; }
        public string Numprocesso { get; set; }
        public DateTime? Dataprocesso { get; set; }
        public DateTime? Dataencerramento { get; set; }
        public string Numprocencerramento { get; set; }
        public DateTime? Dataprocencerramento { get; set; }
        public string Inscestadual { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public short? Isencao { get; set; }
        public int? Codatividade { get; set; }
        public string Ativextenso { get; set; }
        public float? Areatl { get; set; }
        public byte? Codigoaliq { get; set; }
        public DateTime? Datainicialdesc { get; set; }
        public DateTime? Datafinaldesc { get; set; }
        public float? Percdesconto { get; set; }
        public float? Capitalsocial { get; set; }
        public string Nomeorgao { get; set; }
        public int? Codprofresp { get; set; }
        public string Numregistroresp { get; set; }
        public short? Qtdesocio { get; set; }
        public short? Qtdeempregado { get; set; }
        public short? Respcontabil { get; set; }
        public string Rgresp { get; set; }
        public string Orgaoemisresp { get; set; }
        public string Nomecontato { get; set; }
        public string Cargocontato { get; set; }
        public string Fonecontato { get; set; }
        public string Faxcontato { get; set; }
        public string Emailcontato { get; set; }
        public byte? Vistoria { get; set; }
        public short? Qtdeprof { get; set; }
        public string Rg { get; set; }
        public string Orgao { get; set; }
        public string Nomelogradouro { get; set; }
        public byte? Simples { get; set; }
        public byte? Regespecial { get; set; }
        public byte? Alvara { get; set; }
        public DateTime? Datasimples { get; set; }
        public byte? Isentotaxa { get; set; }
        public byte? Mei { get; set; }
        public string Horarioext { get; set; }
        public byte? Isseletro { get; set; }
        public DateTime? Dispensaiedata { get; set; }
        public string Dispensaieproc { get; set; }
        public DateTime? Dtalvaraprovisorio { get; set; }
        public string Senhaiss { get; set; }
        public byte? Insctemp { get; set; }
        public byte? Horas24 { get; set; }
        public byte? Isentoiss { get; set; }
        public byte? Bombonieri { get; set; }
        public byte? Emitenf { get; set; }
        public byte? Danfe { get; set; }
        public int? Imovel { get; set; }
        public string Sil { get; set; }
        public bool? Substituto_tributario_issqn { get; set; }
        public bool? Individual { get; set; }
        public string Ponto_agencia { get; set; }
        public bool? Cadastro_vre { get; set; }
        public bool? Liberado_vre { get; set; }
    }

    public class EmpresaStruct {
        public int Codigo { get; set; }
        public string Razao_social { get; set; }
        public string Nome_fantasia { get; set; }
        public int? Endereco_codigo { get; set; }
        public string Endereco_nome { get; set; }
        public string Endereco_nome_abreviado { get; set; }
        public short? Numero { get; set; }
        public string Complemento { get; set; }
        public short? Bairro_codigo { get; set; }
        public string Bairro_nome { get; set; }
        public short? Cidade_codigo { get; set; }
        public string Cidade_nome { get; set; }
        public string UF { get; set; }
        public string Cep { get; set; }
        public string Homepage { get; set; }
        public short? Horario { get; set; }
        public string Horario_Nome { get; set; }
        public DateTime? Data_abertura { get; set; }
        public string Numprocesso { get; set; }
        public DateTime? Dataprocesso { get; set; }
        public DateTime? Data_Encerramento { get; set; }
        public string Numprocessoencerramento { get; set; }
        public DateTime? Dataprocencerramento { get; set; }
        public string Inscricao_estadual { get; set; }
        public bool Juridica { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string Cpf_cnpj { get; set; }
        public short? Isencao { get; set; }
        public int? Atividade_codigo { get; set; }
        public string Atividade_nome { get; set; }
        public string Atividade_extenso { get; set; }
        public float? Area { get; set; }
        public byte? Codigo_aliquota { get; set; }
        public float? Valor_aliquota1 { get; set; }
        public float? Valor_aliquota2 { get; set; }
        public float? Valor_aliquota3 { get; set; }
        public DateTime? Data_inicial_desconto { get; set; }
        public DateTime? Data_final_desconto { get; set; }
        public float? Percentual_desconto { get; set; }
        public float? Capital_social { get; set; }
        public string Nome_orgao { get; set; }
        public int? prof_responsavel_codigo { get; set; }
        public string prof_responsavel_nome { get; set; }
        public string Prof_responsavel_conselho { get; set; }
        public string Prof_responsavel_registro { get; set; }
        public string Numero_registro_resp { get; set; }
        public short? Qtde_socio { get; set; }
        public short? Qtde_empregado { get; set; }
        public short? Responsavel_contabil_codigo { get; set; }
        public string Rg_responsavel { get; set; }
        public string Orgao_emissor_resp { get; set; }
        public string Nome_contato { get; set; }
        public string Cargo_contato { get; set; }
        public string Fone_contato { get; set; }
        public string Fax_contato { get; set; }
        public string Email_contato { get; set; }
        public byte? Vistoria { get; set; }
        public short? Qtde_profissionais { get; set; }
        public string Rg { get; set; }
        public string Orgao { get; set; }
        public string Nome_logradouro { get; set; }
        public byte? Simples { get; set; }
        public byte? Regime_especial { get; set; }
        public byte? Alvara { get; set; }
        public DateTime? Data_simples { get; set; }
        public byte? Isento_taxa { get; set; }
        public byte? Mei { get; set; }
        public string Horario_extenso { get; set; }
        public byte? Iss_eletro { get; set; }
        public DateTime? Dispensa_ie_data { get; set; }
        public string Dispensa_ie_processo { get; set; }
        public DateTime? Data_alvara_provisorio { get; set; }
        public string Senha_iss { get; set; }
        public byte? Inscricao_temporaria { get; set; }
        public byte? Horas_24 { get; set; }
        public byte? Isento_iss { get; set; }
        public byte? Bombonieri { get; set; }
        public byte? Emite_nf { get; set; }
        public byte? Danfe { get; set; }
        public int? Imovel { get; set; }
        public string Sil { get; set; }
        public bool? Substituto_tributario_issqn { get; set; }
        public bool? Individual { get; set; }
        public string Ponto_agencia { get; set; }
        public bool? Cadastro_vre { get; set; }
        public bool? Liberado_vre { get; set; }
        public string Situacao { get; set; }
        public short Distrito { get; set; }
        public short Setor { get; set; }
        public short Quadra { get; set; }
        public int Lote { get; set; }
        public short Seq { get; set; }
        public short Unidade { get; set; }
        public short Subunidade { get; set; }
        public List<MobiliarioproprietarioStruct> Socios { get; set; }
    }

    //public class CnaeStruct {
    //    public string Cnae { get; set; }
    //    public string Descricao { get; set; }
    //}

    public class SilStructure {
        public int Codigo { get; set; }
        public string Protocolo { get; set; }
        public DateTime? Data_Emissao { get; set; }
        public DateTime? Data_Validade { get; set; }
        public double? AreaImovel { get; set; }
    }

}
