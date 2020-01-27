using GTI_WebCore.Models;
using GTI_WebCore.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace GTI_WebCore.Repository {
    public class EmpresaRepository : IEmpresaRepository {
        private readonly AppDbContext context;

        public EmpresaRepository(AppDbContext context) {
            this.context = context;
        }

        public bool Existe_Empresa_Codigo(int nCodigo) {
            bool bRet = false;
            var existingReg = context.Mobiliario.Count(a => a.Codigomob == nCodigo);
            if (existingReg != 0) 
                bRet = true;
            return bRet;
        }

        public int Existe_Empresa_Cnpj(string Cnpj) {
            int nCodigo = 0;
            var existingReg = context.Mobiliario.Count(a => a.Cnpj == Cnpj);
            if (existingReg != 0) {
                int reg = (from m in context.Mobiliario where m.Cnpj == Cnpj select m.Codigomob).FirstOrDefault();
                nCodigo = reg;
            }
            return nCodigo;
        }

        public int Existe_Empresa_Cpf(string Cpf) {
            int nCodigo = 0;
            var existingReg = context.Mobiliario.Count(a => a.Cpf == Cpf);
            if (existingReg != 0) {
                int reg = (from m in context.Mobiliario where m.Cnpj == Cpf select m.Codigomob).FirstOrDefault();
                nCodigo = reg;
            }
            return nCodigo;
        }

        public bool Empresa_Suspensa(int nCodigo) {
            bool bRet = false;
                var existingReg = context.Mobiliarioevento.Count(a => a.Codmobiliario == nCodigo);
            if (existingReg != 0) {
                int sit = (from m in context.Mobiliarioevento where m.Codmobiliario == nCodigo orderby m.Dataevento descending select m.Codtipoevento).FirstOrDefault();
                if (sit == 2)
                    bRet = true;
            }
            return bRet;
        }

        public bool Empresa_tem_VS(int nCodigo) {
            bool bRet = false;
                var existingReg = context.Mobiliariovs.Count(a => a.Codigo == nCodigo);
                if (existingReg != 0) {
                    bRet = true;
                }
            return bRet;
        }

        public bool Empresa_tem_TL(int nCodigo) {
            bool ret = true;
                byte? isento = (from m in context.Mobiliario where m.Codigomob == nCodigo && m.Isentotaxa == 1 select m.Isentotaxa).FirstOrDefault();
                if (Convert.ToBoolean(isento))
                    return false;
            return ret;
        }

        public EmpresaStruct Dados_Empresa(int Codigo) {
            var reg = (from m in context.Mobiliario
                       join b in context.Bairro on new { p1 = (short)m.Codbairro, p2 = (short)m.Codcidade, p3 = m.Siglauf } equals new { p1 = b.Codbairro, p2 = b.Codcidade, p3 = b.Siglauf } into mb from b in mb.DefaultIfEmpty()
                       join c in context.Cidade on new { p1 = (short)m.Codcidade, p2 = m.Siglauf } equals new { p1 = c.Codcidade, p2 = c.Siglauf } into mc from c in mc.DefaultIfEmpty()
                       join l in context.Logradouro on m.Codlogradouro equals l.Codlogradouro into lm from l in lm.DefaultIfEmpty()
                       join a in context.Atividade on m.Codatividade equals a.Codatividade into am from a in am.DefaultIfEmpty()
                       join h in context.Horario_funcionamento on a.Horario equals h.Id into ha from h in ha.DefaultIfEmpty()
                       join p in context.Cidadao on m.Codprofresp equals p.Codcidadao into mp from p in mp.DefaultIfEmpty()
                       where m.Codigomob == Codigo
                       select new EmpresaStruct {
                           Codigo = m.Codigomob, Razao_social = m.Razaosocial, Nome_fantasia = m.Nomefantasia, Endereco_codigo = m.Codlogradouro, Endereco_nome = l.Endereco, Numero = m.Numero, Complemento = m.Complemento,
                           Bairro_codigo = m.Codbairro, Bairro_nome = b.Descbairro, Cidade_codigo = m.Codcidade, Cidade_nome = c.Desccidade, UF = m.Siglauf, Cep = m.Cep, Homepage = m.Homepage, Horario = m.Horario,
                           Data_abertura = m.Dataabertura, Numprocesso = m.Numprocesso, Dataprocesso = m.Dataprocesso, Data_Encerramento = m.Dataencerramento, Numprocessoencerramento = m.Numprocencerramento,
                           Dataprocencerramento = m.Dataprocencerramento, Inscricao_estadual = m.Inscestadual, Isencao = m.Isencao, Atividade_codigo = m.Codatividade, Atividade_extenso = m.Ativextenso, Area = m.Areatl,
                           Codigo_aliquota = m.Codigoaliq, Data_inicial_desconto = m.Datainicialdesc, Data_final_desconto = m.Datafinaldesc, Percentual_desconto = m.Percdesconto, Capital_social = m.Capitalsocial,
                           Nome_orgao = m.Nomeorgao, prof_responsavel_codigo = m.Codprofresp, Numero_registro_resp = m.Numregistroresp, Qtde_socio = m.Qtdesocio, Qtde_empregado = m.Qtdeempregado, Responsavel_contabil_codigo = m.Respcontabil,
                           Rg_responsavel = m.Rgresp, Orgao_emissor_resp = m.Orgaoemisresp, Nome_contato = m.Nomecontato, Cargo_contato = m.Cargocontato, Fone_contato = m.Fonecontato, Fax_contato = m.Faxcontato,
                           Email_contato = m.Emailcontato, Vistoria = m.Vistoria, Qtde_profissionais = m.Qtdeprof, Rg = m.Rg, Orgao = m.Orgao, Nome_logradouro = m.Nomelogradouro, Simples = m.Simples, Regime_especial = m.Regespecial,
                           Alvara = m.Alvara, Data_simples = m.Datasimples, Isento_taxa = m.Isentotaxa, Mei = m.Mei, Horario_extenso = m.Horarioext, Iss_eletro = m.Isseletro, Dispensa_ie_data = m.Dispensaiedata,
                           Dispensa_ie_processo = m.Dispensaieproc, Data_alvara_provisorio = m.Dtalvaraprovisorio, Senha_iss = m.Senhaiss, Inscricao_temporaria = m.Insctemp, Horas_24 = m.Horas24, Isento_iss = m.Isentoiss,
                           Bombonieri = m.Bombonieri, Emite_nf = m.Emitenf, Danfe = m.Danfe, Imovel = m.Imovel, Sil = m.Sil, Substituto_tributario_issqn = m.Substituto_tributario_issqn, Individual = m.Individual,
                           Ponto_agencia = m.Ponto_agencia, Cadastro_vre = m.Cadastro_vre, Liberado_vre = m.Liberado_vre, Cpf = m.Cpf, Cnpj = m.Cnpj, Prof_responsavel_registro = m.Numregistroresp,
                           Prof_responsavel_conselho = m.Nomeorgao, prof_responsavel_nome = p.Nomecidadao, Horario_Nome = h.Descricao, Atividade_nome = a.Descatividade, Endereco_nome_abreviado = l.Endereco_resumido
                       }).FirstOrDefault();


            EmpresaStruct row = new EmpresaStruct();
            if (reg == null)
                return row;
            row.Codigo = Codigo;
            row.Razao_social = reg.Razao_social;
            row.Nome_fantasia = reg.Nome_fantasia;
            row.Cpf_cnpj = "";
            if (!string.IsNullOrEmpty(reg.Cpf) && reg.Cpf.Length > 10) {
                row.Juridica = false;
                row.Cpf_cnpj = Convert.ToUInt64(reg.Cpf).ToString(@"000\.000\.000\-00");
                row.Cpf = reg.Cpf;
            } else {
                if (!string.IsNullOrEmpty(reg.Cnpj) && reg.Cnpj.Length > 13) {
                    row.Cpf_cnpj = Convert.ToUInt64(reg.Cnpj).ToString(@"00\.000\.000\/0000\-00");
                    row.Cnpj = reg.Cnpj;
                    row.Juridica = true;
                }
            }
            if (reg.Rg != null)
                row.Rg = reg.Rg.Trim();
            if (reg.Orgao != null)
                row.Rg += ' ' + reg.Orgao.Trim();
            row.Bairro_nome = reg.Bairro_nome;
            row.Cidade_nome = reg.Cidade_nome;
            row.UF = reg.UF;
            row.Endereco_codigo = reg.Endereco_codigo;
            row.Endereco_nome = reg.Endereco_nome ?? reg.Nome_logradouro;
            row.Endereco_nome_abreviado = reg.Endereco_nome_abreviado ?? reg.Nome_logradouro;
            row.Numero = reg.Numero;
            row.Complemento = reg.Complemento;

            row.Inscricao_estadual = reg.Inscricao_estadual ?? "";
            row.Data_abertura = Convert.ToDateTime(reg.Data_abertura);
            row.Numprocesso = reg.Numprocesso;
            row.Dataprocesso = reg.Dataprocesso;
            row.Data_Encerramento = reg.Data_Encerramento != null ? reg.Data_Encerramento : (DateTime?)null;
            row.Numprocessoencerramento = reg.Numprocessoencerramento;
            row.Dataprocencerramento = reg.Dataprocencerramento;
            row.Horario = reg.Horario;
            row.Horario_Nome = reg.Horario_Nome;
            row.Ponto_agencia = reg.Ponto_agencia;
            string horario = reg.Horario_extenso == null || reg.Horario_extenso == "" ? "" : reg.Horario_extenso;
            row.Horario_extenso = horario;

            row.Qtde_empregado = reg.Qtde_empregado;
            row.Capital_social = reg.Capital_social;
            row.Inscricao_temporaria = reg.Inscricao_temporaria == null ? 0 : reg.Inscricao_temporaria;
            row.Substituto_tributario_issqn = reg.Substituto_tributario_issqn == null ? false : reg.Substituto_tributario_issqn;
            row.Isento_iss = reg.Isento_iss == null ? 0 : reg.Isento_iss;
            row.Isento_taxa = reg.Isento_taxa == null ? 0 : reg.Isento_taxa;
            row.Individual = reg.Individual == null ? false : reg.Individual;
            row.Liberado_vre = reg.Liberado_vre == null ? false : reg.Liberado_vre;
            row.Horas_24 = reg.Horas_24 == null ? 0 : reg.Horas_24;
            row.Bombonieri = reg.Bombonieri == null ? 0 : reg.Bombonieri;
            row.Vistoria = reg.Vistoria == null ? 0 : reg.Vistoria;

            string sSituacao = "";
            if (Functions.IsDate(row.Data_Encerramento.ToString()))
                sSituacao = "ENCERRADA";
            else {
                if (Empresa_Suspensa(Codigo))
                    sSituacao = "SUSPENSA";
                else
                    sSituacao = "ATIVA";
            }
            row.Situacao = sSituacao;
            row.Email_contato = reg.Email_contato ?? "";
            row.Fone_contato = reg.Fone_contato ?? "";
            row.Area = reg.Area == 0 ? 0 : Convert.ToSingle(reg.Area);

            row.Qtde_profissionais = reg.Qtde_profissionais;
            row.Codigo_aliquota = reg.Codigo_aliquota;
            row.Atividade_codigo = reg.Atividade_codigo;
            row.Atividade_nome = reg.Atividade_nome ?? "";
            row.Atividade_extenso = reg.Atividade_extenso ?? "";

            row.Cep = reg.Cep ?? "00000-000";
            if (row.Cidade_codigo == 413) {
                EnderecoRepository _enderecoRepository = new EnderecoRepository(context);
                int nCep = _enderecoRepository.RetornaCep((int)reg.Endereco_codigo, (short)reg.Numero);
                if (nCep > 0)
                    row.Cep = nCep.ToString("00000-000");
                else {
                    row.Cep = reg.Cep;
                }
            }

            //Imovel_Data imovel_Class = new Imovel_Data(_connection);
            //ImovelStruct regImovel = imovel_Class.Inscricao_imovel((int)reg.Endereco_codigo, (short)reg.Numero);
            //if (regImovel != null) {
            //    row.Distrito = regImovel.Distrito;
            //    row.Setor = regImovel.Setor;
            //    row.Quadra = regImovel.Quadra;
            //    row.Lote = regImovel.Lote;
            //    row.Seq = regImovel.Seq;
            //    row.Unidade = regImovel.Unidade;
            //    row.Subunidade = regImovel.SubUnidade;
            //    row.Imovel = regImovel.Codigo;
            //}

            row.Nome_contato = reg.Nome_contato;
            row.Fone_contato = reg.Fone_contato;
            row.Email_contato = reg.Email_contato;
            row.Cargo_contato = reg.Cargo_contato;
            row.prof_responsavel_codigo = reg.prof_responsavel_codigo;
            row.prof_responsavel_nome = reg.prof_responsavel_nome;
            row.Prof_responsavel_registro = reg.Prof_responsavel_registro;
            row.Prof_responsavel_conselho = reg.Prof_responsavel_conselho;
            row.Responsavel_contabil_codigo = reg.Responsavel_contabil_codigo;

            return row;
        }

        public List<CnaeStruct> Lista_Cnae_Empresa(int nCodigo) {
            List<CnaeStruct> Lista = new List<CnaeStruct>();
                var rows = (from m in context.Mobiliariocnae where m.Codmobiliario == nCodigo
                            select new { m.Cnae, m.Principal });
                foreach (var reg in rows) {
                    CnaeStruct Linha = new CnaeStruct {
                        CNAE = reg.Cnae,
                        Descricao = Retorna_Descricao_Cnae(reg.Cnae),
                        Principal = reg.Principal == 1 ? true : false
                    };
                    Lista.Add(Linha);
                }
                return Lista;
        }
        
        public string Retorna_Descricao_Cnae(string cnae) {
            string _cnae = Functions.RetornaNumero(cnae);
                var Sql = (from h in context.Cnae where h.cnae == _cnae select h.Descricao).FirstOrDefault();
                return Sql;
        }

        public string Regime_Empresa(int Codigo) {
                int tributo = (from m in context.Mobiliarioatividadeiss where m.Codmobiliario == Codigo select m.Codtributo).FirstOrDefault();
                if (tributo == 11)
                    return "F";
                else {
                    if (tributo == 12)
                        return "E";
                    else {
                        if (tributo == 13)
                            return "V";
                        else
                            return "N";
                    }
                }
        }

        public bool Empresa_Mei(int nCodigo) {
            bool ret = true;
                var existingReg = context.Periodomei.Count(a => a.Codigo == nCodigo);
                if (existingReg == 0) {
                    ret = false;
                } else {
                    DateTime? datafim = (from m in context.Periodomei orderby m.Datainicio descending where m.Codigo == nCodigo select m.Datafim).FirstOrDefault();
                    if (Functions.IsDate(datafim))
                        return false;
                }
            return ret;
        }

        public List<int> Retorna_Codigo_por_CPF(string CPF) {
            List<int> Sql = (from c in context.Mobiliario where c.Cpf == CPF orderby c.Codigomob select c.Codigomob).ToList();
            return Sql;
        }

        public List<int> Retorna_Codigo_por_CNPJ(string CNPJ) {
            List<int> Sql = (from c in context.Mobiliario where c.Cnpj == CNPJ orderby c.Codigomob descending select c.Codigomob).ToList();
            return Sql;
        }

       

    }
}
