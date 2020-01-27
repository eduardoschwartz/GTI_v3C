using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace GTI_Dal.Classes {
    public class Empresa_Data {

        private readonly string _connection;

        public Empresa_Data(string sConnection) {
            _connection = sConnection;
        }
        
        public bool Existe_Empresa(int nCodigo) {
            bool bRet = false;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var existingReg = db.Mobiliario.Count(a => a.Codigomob == nCodigo);
                if (existingReg != 0) {
                    bRet = true;
                }
            }
            return bRet;
        }

        public bool Empresa_Suspensa(int nCodigo) {
            bool bRet = false;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var existingReg = db.Mobiliarioevento.Count(a => a.Codmobiliario == nCodigo);
                if (existingReg != 0) {
                    int sit = (from m in db.Mobiliarioevento where m.Codmobiliario == nCodigo orderby m.Dataevento descending select m.Codtipoevento).FirstOrDefault();
                    if (sit == 2)
                        bRet = true;
                }
            }
            return bRet;
        }

        public List<int> Lista_Empresas_Ativas() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                List<int> ListaFinal = new List<int>();
                List<int> ListaAtivos = (from m in db.Mobiliario where m.Dataencerramento==null && m.Insctemp!=1 orderby m.Codigomob select m.Codigomob).ToList();
                List<int> ListaSuspenso = Lista_Empresas_Suspensas();
                for (int i = 0; i < ListaAtivos.Count; i++) {
                    bool _find = false;
                    for (int w = 0; w < ListaSuspenso.Count; w++) {
                        if (ListaAtivos[i] == ListaSuspenso[w]) {
                            _find = true;
                            break;
                        }
                    }
                    if (!_find)
                        ListaFinal.Add(ListaAtivos[i]);
                }

                return ListaFinal;
            }
        }

        public int Qtde_Parcelas_TLL_Vencidas(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int _qtde = db.Debitoparcela.Count(d => d.Codreduzido == Codigo && d.Anoexercicio <= DateTime.Now.Year &&
                             d.Codlancamento == 6 && d.Numparcela > 0 && d.Statuslanc == 3 && d.Datavencimento < DateTime.Now);
                return _qtde;
            }
        }

        public List<int> Lista_Empresas_Suspensas() {
            List<int> Lista = new List<int>();

            string Sql = "SELECT X.codmobiliario FROM(SELECT codmobiliario, MAX(dataevento) AS DataEv FROM mobiliarioevento GROUP BY codmobiliario) AS X INNER JOIN ";
            Sql+="mobiliarioevento AS f ON f.codmobiliario = X.codmobiliario AND f.dataevento = X.DataEv where f.codtipoevento = 2 ORDER BY X.codmobiliario";
            SqlConnection cn = new SqlConnection(_connection);
            cn.Open();
            SqlCommand cmd = new SqlCommand(Sql, cn);
            DbDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                Lista.Add((int)dr.GetValue(0));
            }
            dr.Close();
            cn.Close();
            return Lista;
        }

        public List<MobiliariovsStruct> Lista_Empresas_Vigilancia_Sanitaria() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                List<MobiliariovsStruct> ListaFinal = new List<MobiliariovsStruct>();
                List<MobiliariovsStruct> ListaGeral = (from m in db.Mobiliariovs join c in db.Cnaecriteriodesc on m.Criterio equals c.Criterio
                                                       orderby m.Codigo select new MobiliariovsStruct {Codigo=m.Codigo,Cnae=m.Cnae,Criterio=m.Criterio,Qtde=m.Qtde,Valor=c.Valor }).ToList();
                List<int> ListaAtivos = Lista_Empresas_Ativas();
                for (int i = 0; i < ListaGeral.Count; i++) {
                    for (int w = 0; w < ListaAtivos.Count; w++) {
                        if (ListaGeral[i].Codigo == ListaAtivos[w]) {
                            MobiliariovsStruct reg = new MobiliariovsStruct {
                                Codigo = ListaGeral[i].Codigo,
                                Qtde = ListaGeral[i].Qtde,
                                Valor = ListaGeral[i].Valor
                            };
                            ListaFinal.Add(reg);
                        }
                    }
                }

                return ListaFinal;
            }
        }

        public List<EmpresaStruct> Lista_Empresas_Taxa_Licenca() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                List<EmpresaStruct> ListaFinal = new List<EmpresaStruct>();
                var ListaGeral = (from m in db.Mobiliario join a in db.Atividade on m.Codatividade equals a.Codatividade into ma from a in ma.DefaultIfEmpty()
                                  orderby m.Codigomob
                                  select new EmpresaStruct { Codigo=m.Codigomob,Area=m.Areatl,Codigo_aliquota=m.Codigoaliq,Valor_aliquota1=(float)a.Valoraliq1,
                                  Valor_aliquota2= (float)a.Valoraliq2,Valor_aliquota3= (float)a.Valoraliq3,Isento_taxa=m.Isentotaxa,Vistoria=m.Vistoria});

                List<int> ListaAtivos = Lista_Empresas_Ativas();

                foreach (EmpresaStruct item in ListaGeral) {
                    if (item.Isento_taxa == null || item.Isento_taxa == 0) {
                        if (!Empresa_Mei(item.Codigo)) {
                            for (int w = 0; w < ListaAtivos.Count; w++) {
                                if (item.Codigo == ListaAtivos[w]) {
                                    EmpresaStruct reg = new EmpresaStruct {
                                        Codigo = item.Codigo,
                                        Area = item.Area,
                                        Codigo_aliquota = item.Codigo_aliquota,
                                        Valor_aliquota1 = item.Valor_aliquota1,
                                        Valor_aliquota2 = item.Valor_aliquota2,
                                        Valor_aliquota3 = item.Valor_aliquota3,
                                        Vistoria = item.Vistoria
                                    };
                                    ListaFinal.Add(reg);
                                }
                            }
                        }
                    }
                }

                return ListaFinal;
            }
        }

        public List<Mobiliarioatividadeiss> Lista_Empresas_ISS_Fixo() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                List<Mobiliarioatividadeiss> ListaFinal = new List<Mobiliarioatividadeiss>();
                List<Mobiliarioatividadeiss> ListaGeral = (from m in db.Mobiliarioatividadeiss where m.Codtributo==11 orderby m.Codmobiliario select m).ToList();
                List<int> ListaAtivos = Lista_Empresas_Ativas();
                for (int i = 0; i < ListaGeral.Count; i++) {
                    for (int w = 0; w < ListaAtivos.Count; w++) {
                        if (ListaGeral[i].Codmobiliario == ListaAtivos[w]) {
                            Mobiliarioatividadeiss reg = new Mobiliarioatividadeiss {
                                Codmobiliario = ListaGeral[i].Codmobiliario,
                                Qtdeiss = ListaGeral[i].Qtdeiss,
                                Valoriss = ListaGeral[i].Valoriss
                            };
                            ListaFinal.Add(reg);
                        }
                    }
                }

                return ListaFinal;
            }
        }

        public decimal Aliquota_Taxa_Licenca(int _codigo) {
            decimal _aliquota = 0;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from m in db.Mobiliario join a in db.Atividade on m.Codatividade equals a.Codatividade into ma from a in ma.DefaultIfEmpty()
                           where m.Codigomob==_codigo select new  {a.Valoraliq1,a.Valoraliq2,a.Valoraliq3 }).FirstOrDefault();
                if (Sql != null) {
                    if (Sql.Valoraliq1 > 0)
                        _aliquota = (decimal)Sql.Valoraliq1;
                    else {
                        if (Sql.Valoraliq2 > 0)
                            _aliquota = (decimal)Sql.Valoraliq2;
                        else {
                            if (Sql.Valoraliq3 > 0)
                                _aliquota = (decimal)Sql.Valoraliq3;
                        }
                    }
                }
            }
            return _aliquota;
        }

        public int Existe_EmpresaCnpj(string sCNPJ) {
            int nCodigo = 0;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var existingReg = db.Mobiliario.Count(a => a.Cnpj == sCNPJ);
                if (existingReg != 0) {
                    int reg = (from m in db.Mobiliario where m.Cnpj == sCNPJ select m.Codigomob).FirstOrDefault();
                    nCodigo = reg;
                }
            }
            return nCodigo;
        }

        public int Existe_EmpresaCpf(string sCPF) {
            int nCodigo = 0;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var existingReg = db.Mobiliario.Count(a => a.Cpf == sCPF);
                if (existingReg != 0) {
                    int reg = (from m in db.Mobiliario where m.Cpf == sCPF select m.Codigomob).FirstOrDefault();
                    nCodigo = reg;
                }
            }
            return nCodigo;
        }

        public bool Empresa_tem_VS(int nCodigo) {
            bool bRet = false;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var existingReg = db.Mobiliariovs.Count(a => a.Codigo == nCodigo);
                if (existingReg != 0) {
                    bRet = true;
                }
            }
            return bRet;
        }

        public bool Empresa_tem_TL(int nCodigo) {
            bool ret = true;
            using (GTI_Context db = new GTI_Context(_connection)) {
                byte? isento = (from m in db.Mobiliario where m.Codigomob == nCodigo && m.Isentotaxa ==1 select m.Isentotaxa).FirstOrDefault();
                if (Convert.ToBoolean(isento))
                    return false;
            }
            return ret;
        }

        public bool Empresa_tem_Alvara(int nCodigo) {
            bool ret;
            using (GTI_Context db = new GTI_Context(_connection)) {
                byte? alvara = (from m in db.Mobiliario where m.Codigomob == nCodigo && m.Alvara == 1 select m.Alvara).FirstOrDefault();
                if (alvara == null)
                    ret = false;
                else
                    ret = Convert.ToBoolean(alvara);
            }
            return ret;
        }

        public bool Atividade_tem_Alvara(int Codigo_Atividade) {
            bool ret;
            using (GTI_Context db = new GTI_Context(_connection)) {
                byte? alvara = (from m in db.Atividade where m.Codatividade == Codigo_Atividade && m.Alvara == 1 select m.Alvara).FirstOrDefault();
                if (alvara == null)
                    ret = false;
                else
                    ret = Convert.ToBoolean(alvara);
            }
            return ret;
        }

        public string Regime_Empresa(int nCodigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int tributo = (from m in db.Mobiliarioatividadeiss where m.Codmobiliario == nCodigo select m.Codtributo).FirstOrDefault();
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
        }

        public bool Empresa_Mei(int nCodigo) {
            bool ret = true;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var existingReg = db.Periodomei.Count(a => a.Codigo == nCodigo);
                if (existingReg == 0) {
                    ret = false;
                } else {
                    DateTime? datafim = (from m in db.Periodomei orderby m.Datainicio descending where m.Codigo == nCodigo select m.Datafim).FirstOrDefault();
                    if (dalCore.IsDate(datafim))
                        return false;
                }
            }
            return ret;
        }

        public bool Empresa_Simples(int Codigo,DateTime Data) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                short nRet = db.Database.SqlQuery<short>("SELECT dbo.RETORNASN(@Codigo,@Data)", new SqlParameter("@Codigo", Codigo), new SqlParameter("@Data", Data)).Single();
                return nRet == 1 ? true : false;
            }
        }

        public EmpresaStruct Retorna_Empresa(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from m in db.Mobiliario
                           join b in db.Bairro on new { p1 = (short)m.Codbairro, p2 = (short)m.Codcidade, p3 = m.Siglauf } equals new { p1 = b.Codbairro, p2 = b.Codcidade, p3 = b.Siglauf } into mb from b in mb.DefaultIfEmpty()
                           join c in db.Cidade on new { p1 = (short)m.Codcidade, p2 = m.Siglauf } equals new { p1 = c.Codcidade, p2 = c.Siglauf } into mc from c in mc.DefaultIfEmpty()
                           join l in db.Logradouro on m.Codlogradouro equals l.Codlogradouro into lm from l in lm.DefaultIfEmpty()
                           join a in db.Atividade on m.Codatividade equals a.Codatividade into am from a in am.DefaultIfEmpty()
                           join h in db.Horario_funcionamento on a.Horario equals h.Id into ha from h in ha.DefaultIfEmpty()
                           join p in db.Cidadao on m.Codprofresp equals p.Codcidadao into mp from p in mp.DefaultIfEmpty()
                           where m.Codigomob == Codigo
                           select new EmpresaStruct{Codigo= m.Codigomob, Razao_social= m.Razaosocial,Nome_fantasia=m.Nomefantasia,Endereco_codigo=m.Codlogradouro,Endereco_nome= l.Endereco,Numero=  m.Numero,Complemento= m.Complemento,
                                                    Bairro_codigo=m.Codbairro,Bairro_nome=b.Descbairro,Cidade_codigo=m.Codcidade,Cidade_nome=c.Desccidade,UF=m.Siglauf,Cep=m.Cep,Homepage=m.Homepage,Horario=m.Horario,
                                                    Data_abertura=m.Dataabertura,Numprocesso=m.Numprocesso,Dataprocesso=m.Dataprocesso,Data_Encerramento=m.Dataencerramento,Numprocessoencerramento=m.Numprocencerramento,
                                                    Dataprocencerramento=m.Dataprocencerramento,Inscricao_estadual=m.Inscestadual,Isencao=m.Isencao,Atividade_codigo=m.Codatividade,Atividade_extenso=m.Ativextenso,Area=m.Areatl,
                                                    Codigo_aliquota=m.Codigoaliq,Data_inicial_desconto=m.Datainicialdesc,Data_final_desconto=m.Datafinaldesc,Percentual_desconto=m.Percdesconto,Capital_social=m.Capitalsocial,
                                                    Nome_orgao=m.Nomeorgao,prof_responsavel_codigo=m.Codprofresp,Numero_registro_resp=m.Numregistroresp,Qtde_socio=m.Qtdesocio,Qtde_empregado=m.Qtdeempregado,Responsavel_contabil_codigo=m.Respcontabil,
                                                    Rg_responsavel=m.Rgresp,Orgao_emissor_resp=m.Orgaoemisresp,Nome_contato=m.Nomecontato,Cargo_contato=m.Cargocontato,Fone_contato=m.Fonecontato,Fax_contato=m.Faxcontato,
                                                    Email_contato=m.Emailcontato,Vistoria=m.Vistoria,Qtde_profissionais=m.Qtdeprof,Rg=m.Rg,Orgao=m.Orgao,Nome_logradouro=m.Nomelogradouro,Simples=m.Simples,Regime_especial=m.Regespecial,
                                                    Alvara=m.Alvara,Data_simples=m.Datasimples,Isento_taxa=m.Isentotaxa,Mei=m.Mei,Horario_extenso=m.Horarioext,Iss_eletro=m.Isseletro,Dispensa_ie_data=m.Dispensaiedata,
                                                    Dispensa_ie_processo=m.Dispensaieproc,Data_alvara_provisorio=m.Dtalvaraprovisorio,Senha_iss=m.Senhaiss,Inscricao_temporaria=m.Insctemp,Horas_24=m.Horas24,Isento_iss=m.Isentoiss,
                                                    Bombonieri=m.Bombonieri,Emite_nf=m.Emitenf,Danfe=m.Danfe,Imovel=m.Imovel,Sil=m.Sil,Substituto_tributario_issqn=m.Substituto_tributario_issqn,Individual=m.Individual,
                                                    Ponto_agencia=m.Ponto_agencia,Cadastro_vre=m.Cadastro_vre,Liberado_vre=m.Liberado_vre,Cpf=m.Cpf,Cnpj=m.Cnpj,Prof_responsavel_registro=m.Numregistroresp,
                                                    Prof_responsavel_conselho=m.Nomeorgao,prof_responsavel_nome=p.Nomecidadao,Horario_Nome=h.descricao,Atividade_nome=a.Descatividade,Endereco_nome_abreviado=l.Endereco_resumido
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
                    row.Cpf_cnpj = reg.Cpf;
                    row.Cpf = reg.Cpf;
                } else {
                    if (!string.IsNullOrEmpty(reg.Cnpj) && reg.Cnpj.Length > 13) {
                        row.Cpf_cnpj = reg.Cnpj;
                        row.Cnpj = reg.Cnpj;
                        row.Juridica = true;
                    }
                }
                if(reg.Rg!=null)
                    row.Rg = reg.Rg.Trim() ;
                if (reg.Orgao != null)
                    row.Rg +=  ' ' + reg.Orgao.Trim();
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
                row.Data_Encerramento = reg.Data_Encerramento != null ? reg.Data_Encerramento :(DateTime?)null;
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
                if (dalCore.IsDate(row.Data_Encerramento.ToString()))
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
                if (reg.Cidade_codigo == 413) {
                    Endereco_Data Cep_Class = new Endereco_Data(_connection);
                    int nCep = Cep_Class.RetornaCep((int)reg.Endereco_codigo, (short)reg.Numero);
                    if (nCep>0)
                      row.Cep =  nCep.ToString("00000-000");
                    else {
                        row.Cep = reg.Cep;
                    }
                        
                }

                Imovel_Data imovel_Class = new Imovel_Data(_connection);
                ImovelStruct regImovel = imovel_Class.Inscricao_imovel((int)reg.Endereco_codigo,(short)reg.Numero);
                if (regImovel != null) {
                    row.Distrito = regImovel.Distrito;
                    row.Setor = regImovel.Setor;
                    row.Quadra = regImovel.Quadra;
                    row.Lote = regImovel.Lote;
                    row.Seq = regImovel.Seq;
                    row.Unidade = regImovel.Unidade;
                    row.Subunidade = regImovel.SubUnidade;
                    row.Imovel = regImovel.Codigo;
                }

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
        }

        public List<CidadaoStruct> Lista_Socio(int nCodigo) {
            List<CidadaoStruct> Lista = new List<CidadaoStruct>();
            Cidadao_Data cidadao_classs = new Cidadao_Data(_connection);
            using (GTI_Context db = new GTI_Context(_connection)) {
                List<int> Socios = (from m in db.Mobiliarioproprietario where m.Codmobiliario == nCodigo select m.Codcidadao).ToList();
                foreach (int Cod in Socios) {
                    CidadaoStruct reg = cidadao_classs.LoadReg(Cod);
                    Lista.Add(reg);
                }
                return Lista;
            }
        }

        public List<Horariofunc> Lista_Horario() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from h in db.Horariofunc orderby h.Deschorario  select h).ToList();
                return Sql;
            }
        }

        public List<Atividade> Lista_Atividade() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from h in db.Atividade orderby h.Descatividade select h).ToList();
                return Sql;
            }
        }

        public string Retorna_Nome_Atividade(int id_atividade) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from h in db.Atividade where h.Codatividade==id_atividade select h.Descatividade).FirstOrDefault();
                return Sql;
            }
        }

        public string Retorna_Descricao_Cnae(string cnae) {
            string _cnae = dalCore.RetornaNumero(cnae);
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from h in db.Cnae where h.cnae == _cnae select h.Descricao).FirstOrDefault();
                return Sql;
            }
        }
        
        public List<string> Lista_Placas(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from p in db.Mobiliarioplaca where p.Codigo==Codigo orderby p.placa select  p.placa).Distinct().ToList();
                return Sql;
            }
        }

        public List<sil> Lista_Sil(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from s in db.Sil where s.Codigo==Codigo orderby s.Data_emissao descending select s).ToList();
                return Sql;
            }
        }

        public mobiliarioendentrega Empresa_Endereco_entrega(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from m in db.Mobiliarioendentrega
                           join b in db.Bairro on new { p1 = m.Codbairro, p2 = m.Codcidade, p3 = m.Uf } equals new { p1 = b.Codbairro, p2 = b.Codcidade, p3 = b.Siglauf } into mb from b in mb.DefaultIfEmpty()
                           join c in db.Cidade on new { p1 = m.Codcidade, p2 = m.Uf } equals new { p1 = c.Codcidade, p2 = c.Siglauf } into mc from c in mc.DefaultIfEmpty()
                           join l in db.Logradouro on m.Codlogradouro equals l.Codlogradouro into lm from l in lm.DefaultIfEmpty()
                           where m.Codmobiliario == Codigo
                           select new  { m.Codmobiliario,m.Codlogradouro,Nomelogradouro=l.Endereco,m.Numimovel, m.Complemento,m.Uf,m.Codcidade,m.Codbairro,m.Cep,b.Descbairro,c.Desccidade
                           }).FirstOrDefault();

                mobiliarioendentrega row = new mobiliarioendentrega();
                if (reg == null)
                    return row;
                row.Descbairro = reg.Descbairro;
                row.Desccidade = reg.Desccidade;
                row.Uf = reg.Uf;
                row.Codlogradouro = reg.Codlogradouro;
                row.Nomelogradouro = reg.Nomelogradouro;
                row.Numimovel = reg.Numimovel;
                row.Complemento = reg.Complemento;
                row.Cep = reg.Cep;
                if (reg.Codcidade == 413) {
                    Endereco_Data Cep_Class = new Endereco_Data(_connection);
                    int nCep = Cep_Class.RetornaCep(reg.Codlogradouro, reg.Numimovel);
                    row.Cep = nCep == 0 ? "00000000" : nCep.ToString("0000");
                }

                return row;
            }
        }

        public List<MobiliarioHistoricoStruct> Lista_Empresa_Historico(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from m in db.Mobiliariohist
                           join u in db.Usuario on m.Userid equals u.Id where m.Codmobiliario == Codigo
                           orderby m.Datahist select new MobiliarioHistoricoStruct { Codigo=Codigo,Seq=m.Seq,Data=m.Datahist,Observacao=m.Obs,Usuario_id=m.Userid,Usuario_Nome=u.Nomelogin }).ToList();
                List<MobiliarioHistoricoStruct> Lista = new List<MobiliarioHistoricoStruct>();
                foreach (MobiliarioHistoricoStruct item in Sql) {
                    MobiliarioHistoricoStruct reg = new MobiliarioHistoricoStruct {
                        Codigo = Codigo,
                        Seq = item.Seq,
                        Data = item.Data,
                        Observacao = item.Observacao,
                        Usuario_id = item.Usuario_id == null ? 0 : item.Usuario_id,
                        Usuario_Nome = item.Usuario_Nome.ToString()
                    };
                    Lista.Add(reg);
                }

                return Lista;
            }
        }

        public Exception Incluir_Empresa_Historico(List<MobiliarioHistoricoStruct> historicos) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Database.ExecuteSqlCommand("DELETE FROM MOBILIARIOHIST WHERE CODMOBILIARIO=@Codigo",
                        new SqlParameter("@Codigo", historicos[0].Codigo));
                } catch (Exception ex) {
                    return ex;
                }
                short x = 0;
                foreach (MobiliarioHistoricoStruct item in historicos) {
                    Mobiliariohist reg = new Mobiliariohist {
                        Codmobiliario = item.Codigo,
                        Seq = x,
                        Datahist = item.Data,
                        Obs = item.Observacao,
                        Userid = item.Usuario_id
                    };
                    db.Mobiliariohist.Add(reg);
                    try {
                        db.SaveChanges();
                    } catch (Exception ex) {
                        return ex;
                    }
                    x++;
                }
                return null;
            }
        }

        public List<MobiliarioproprietarioStruct> Lista_Empresa_Proprietario(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from m in db.Mobiliarioproprietario
                           join c in db.Cidadao on m.Codcidadao equals c.Codcidadao where  m.Codmobiliario==Codigo
                           orderby c.Nomecidadao select new MobiliarioproprietarioStruct {Codcidadao=m.Codcidadao,Nome=c.Nomecidadao }).ToList();
                return Sql;
            }
        }

        public List<Escritoriocontabil> Lista_Escritorio_Contabil() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from e in db.Escritoriocontabil where e.Codigoesc>0 orderby e.Nomeesc  select e).ToList();
                return Sql;
            }
        }

        public EscritoriocontabilStruct Dados_Escritorio_Contabil(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from m in db.Escritoriocontabil
                           join b in db.Bairro on m.Codbairro equals b.Codbairro into mb from b in mb.DefaultIfEmpty()
                           join c in db.Cidade on new { p1 = (short)m.Codcidade, p2 = m.UF } equals new { p1 = c.Codcidade, p2 = c.Siglauf } into mc from c in mc.DefaultIfEmpty()
                           join l in db.Logradouro on m.Codlogradouro equals l.Codlogradouro into lm from l in lm.DefaultIfEmpty()
                           where m.Codigoesc == Codigo
                           select new EscritoriocontabilStruct {
                               Codigo = m.Codigoesc, Nome = m.Nomeesc, Logradouro_Codigo = m.Codlogradouro, Logradouro_Nome = l.Endereco, Numero = m.Numero,
                               Complemento = m.Complemento, Bairro_Codigo = m.Codbairro, Bairro_Nome = b.Descbairro, Cidade_Nome = c.Desccidade, UF = m.UF, Telefone = m.Telefone, Email = m.Email,
                               Cpf = m.Cpf, Cnpj = m.Cnpj, Im = m.Im, Crc = m.Crc, Recebecarne = m.Recebecarne, Cidade_Codigo = m.Codcidade, Logradouro_Nome_Fora = m.Nomelogradouro
                           }).FirstOrDefault();

                EscritoriocontabilStruct row = new EscritoriocontabilStruct();
                if (reg == null)
                    return row;
                row.Codigo = reg.Codigo;
                row.Nome = reg.Nome;
                row.Logradouro_Codigo = reg.Logradouro_Codigo;
                row.Logradouro_Nome = reg.Logradouro_Nome ?? reg.Logradouro_Nome_Fora;
                row.Numero = reg.Numero;
                row.Complemento = reg.Complemento;
                row.Bairro_Codigo = reg.Bairro_Codigo;
                row.Bairro_Nome = reg.Bairro_Nome;
                row.Cidade_Codigo = reg.Cidade_Codigo;
                row.Cidade_Nome = reg.Cidade_Nome;
                row.UF = reg.UF;
                row.Cpf = reg.Cpf;
                row.Cnpj = reg.Cnpj;
                row.Crc = reg.Crc;
                row.Email = reg.Email;
                row.Im = reg.Im;
                row.Telefone = reg.Telefone;
                row.Recebecarne = reg.Recebecarne == null ? false : reg.Recebecarne;

                if (reg.Logradouro_Codigo > 0) {
                    Endereco_Data Cep_Class = new Endereco_Data(_connection);
                    int nCep = Cep_Class.RetornaCep((int)reg.Logradouro_Codigo, (short)reg.Numero);
                    row.Cep = nCep == 0 ? "00000000" : nCep.ToString("0000");
                }

                return row;
            }
        }

        public Certidao_inscricao Certidao_inscricao_gravada(int Ano,int Numero) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Certidao_inscricao where c.Ano == Ano && c.Numero==Numero select c).FirstOrDefault();
                return Sql;
            }
        }

        public Alvara_funcionamento Alvara_Funcionamento_gravado(string Controle) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Alvara_funcionamento where c.Controle==Controle select c).FirstOrDefault();
                return Sql;
            }
        }

        public Exception Incluir_escritorio(Escritoriocontabil reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                object[] Parametros = new object[17];
                Parametros[0] = new SqlParameter { ParameterName = "@Codigoesc", SqlDbType = SqlDbType.Int, SqlValue = reg.Codigoesc };
                Parametros[1] = new SqlParameter { ParameterName = "@Nomeesc", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Nomeesc };
                Parametros[2] = new SqlParameter { ParameterName = "@Codlogradouro", SqlDbType = SqlDbType.Int, SqlValue = reg.Codlogradouro };
                Parametros[3] = new SqlParameter { ParameterName = "@Nomelogradouro", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Nomelogradouro };
                Parametros[4] = new SqlParameter { ParameterName = "@Numero", SqlDbType = SqlDbType.Int, SqlValue = reg.Numero };
                Parametros[5] = new SqlParameter { ParameterName = "@Codbairro", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Codbairro };
                Parametros[6] = new SqlParameter { ParameterName = "@Cep", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Cep };
                Parametros[7] = new SqlParameter { ParameterName = "@UF", SqlDbType = SqlDbType.VarChar, SqlValue = reg.UF };
                Parametros[8] = new SqlParameter { ParameterName = "@Telefone", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Telefone };
                Parametros[9] = new SqlParameter { ParameterName = "@Email", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Email };
                Parametros[10] = new SqlParameter { ParameterName = "@Recebecarne", SqlDbType = SqlDbType.Bit, SqlValue = reg.Recebecarne };
                Parametros[11] = new SqlParameter { ParameterName = "@Crc", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Crc };
                Parametros[12] = new SqlParameter { ParameterName = "@Cpf", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Cpf };
                Parametros[13] = new SqlParameter { ParameterName = "@Cnpj", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Cnpj };
                Parametros[14] = new SqlParameter { ParameterName = "@Im", SqlDbType = SqlDbType.Int, SqlValue = reg.Im };
                Parametros[15] = new SqlParameter { ParameterName = "@Complemento", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Complemento };
                Parametros[16] = new SqlParameter { ParameterName = "@Codcidade", SqlDbType = SqlDbType.Int, SqlValue = reg.Codcidade };

                db.Database.ExecuteSqlCommand("INSERT INTO escritoriocontabil(codigoesc,nomeesc,codlogradouro,nomelogradouro,numero,codbairro,cep,uf,telefone," +
                                              "email,recebecarne,crc,cpf,cnpj,im,complemento,codcidade) VALUES(@Codigoesc,@nomeesc,@Codlogradouro,@Nomelogradouro," +
                                              "@Numero,@Codbairro,@Cep,@UF,@Telefone,@Email,@Recebecarne,@Crc,@Cpf,@Cnpj,@Im,@Complemento,@Codcidade)", Parametros);

                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_escritorio(Escritoriocontabil reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Escritoriocontabil b = db.Escritoriocontabil.First(i => i.Codigoesc == reg.Codigoesc);
                b.Nomeesc = reg.Nomeesc;
                b.Cep = reg.Cep;
                b.Cnpj = reg.Cnpj;
                b.Cpf = reg.Cpf;
                b.Codbairro = reg.Codbairro;
                b.Codcidade = reg.Codcidade;
                b.Codlogradouro = reg.Codlogradouro;
                b.Complemento = reg.Complemento;
                b.Crc = reg.Crc;
                b.Email = reg.Email;
                b.Im = reg.Im;
                b.Nomelogradouro = reg.Nomelogradouro;
                b.Numero = reg.Numero;
                b.Recebecarne = reg.Recebecarne;
                b.Telefone = reg.Telefone;
                b.UF = reg.UF;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public int Retorna_Ultimo_Codigo_Escritorio() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Escritoriocontabil orderby c.Codigoesc descending select c.Codigoesc).FirstOrDefault();
                return Sql;
            }
        }

        public Exception Excluir_Escritorio(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    Escritoriocontabil b = db.Escritoriocontabil.First(i => i.Codigoesc == Codigo);
                    db.Escritoriocontabil.Remove(b);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public bool Empresa_Escritorio(int id_escritorio) {
            int _contador = 0;
            using (GTI_Context db = new GTI_Context(_connection)) {
                db.Database.CommandTimeout = 180;
                _contador = (from p in db.Mobiliario where p.Respcontabil == id_escritorio select p.Codigomob).Count();
                return _contador > 0 ? true : false;
            }
        }

        public Exception Incluir_DEmp(List<DEmpresa> Lista) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    foreach (DEmpresa reg in Lista) {
                        db.DEmpresa.Add(reg);
                        db.SaveChanges();
                    }
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public List<DEmpresa> ListaDEmpresa(int nSid) {
            List<DEmpresa> reg;
            using (GTI_Context db = new GTI_Context(_connection)) {
                reg = (from b in db.DEmpresa where b.sid == nSid select b).ToList();
                return reg;
            }
        }

        public Exception Delete_DEmpresa(int nSid) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.DEmpresa.RemoveRange(db.DEmpresa.Where(i => i.sid == nSid));
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public List<MobiliarioAtividadeISSStruct> Lista_AtividadeISS_Empresa(int nCodigo) {
            List<MobiliarioAtividadeISSStruct> Lista = new List<MobiliarioAtividadeISSStruct>();
            using (GTI_Context db = new GTI_Context(_connection)) {
                var rows = (from m in db.Mobiliarioatividadeiss join a in db.Atividadeiss on m.Codatividade equals a.Codatividade join t in db.Tabelaiss on m.Codatividade equals t.Codigoativ
                            where m.Codmobiliario==nCodigo
                            select new  MobiliarioAtividadeISSStruct{Codigo_empresa=  m.Codmobiliario,Codigo_atividade=m.Codatividade,Codigo_tributo =m.Codtributo,
                                                                     Descricao =a.Descatividade,Item=a.Item,Quantidade=m.Qtdeiss,Valor=t.Aliquota });
                foreach (var reg in rows) {
                    MobiliarioAtividadeISSStruct Linha = new MobiliarioAtividadeISSStruct {
                        Codigo_empresa = reg.Codigo_empresa,
                        Codigo_atividade = reg.Codigo_atividade,
                        Codigo_tributo = reg.Codigo_tributo,
                        Descricao = reg.Descricao,
                        Quantidade = reg.Quantidade,
                        Valor = reg.Valor,
                        Item = reg.Item
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<AtividadeIssStruct> Lista_AtividadeISS() {
            List<AtividadeIssStruct> Lista = new List<AtividadeIssStruct>();
            using (GTI_Context db = new GTI_Context(_connection)) {
                var rows = (from a in db.Atividadeiss join t in db.Tabelaiss on a.Codatividade equals t.Codigoativ
                            orderby a.Codatividade
                            select new AtividadeIssStruct {
                                Codigo_atividade = a.Codatividade, Tipo=t.Tipoiss,
                                Descricao = a.Descatividade, Aliquota   = t.Aliquota
                            });
                foreach (var reg in rows) {
                    AtividadeIssStruct Linha = new AtividadeIssStruct {
                        Codigo_atividade = reg.Codigo_atividade,
                        Tipo = reg.Tipo,
                        Descricao = reg.Descricao,
                        Aliquota = reg.Aliquota
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<CnaeStruct> Lista_Cnae_Empresa(int nCodigo) {
            List<CnaeStruct> Lista = new List<CnaeStruct>();
            using (GTI_Context db = new GTI_Context(_connection)) {
                var rows = (from m in db.Mobiliariocnae where m.Codmobiliario == nCodigo
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
        }

        public List<CnaeStruct> Lista_Cnae_Empresa_VS(int nCodigo) {
            List<CnaeStruct> Lista = new List<CnaeStruct>();
            using (GTI_Context db = new GTI_Context(_connection)) {
                var rows = (from m in db.Mobiliariovs join c in db.Cnae on m.Cnae equals c.cnae join a in db.Cnaecriteriodesc on m.Criterio equals a.Criterio
                            where m.Codigo == nCodigo
                            select new { m.Cnae, c.Descricao, m.Criterio, m.Qtde, a.Valor });
                foreach (var reg in rows) {
                    CnaeStruct Linha = new CnaeStruct {
                        Descricao = reg.Descricao.ToUpper(),
                        Criterio = reg.Criterio,
                        Qtde = (int)reg.Qtde,
                        Valor = (decimal)reg.Valor,
                        CNAE = Convert.ToInt32(reg.Cnae).ToString("0000-0/00")
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<CnaeStruct> Lista_Cnae() {
            List<CnaeStruct> Lista = new List<CnaeStruct>();
            using (GTI_Context db = new GTI_Context(_connection)) {
                var rows = (from c in db.Cnaesubclasse 
                            select new { c.Divisao, c.Grupo, c.Classe,c.Subclasse,c.Descricao });
                foreach (var reg in rows) {
                    CnaeStruct Linha = new CnaeStruct {
                        Divisao = reg.Divisao,
                        Grupo = reg.Grupo,
                        Classe = reg.Classe,
                        Subclasse = reg.Subclasse,
                        Descricao = reg.Descricao,
                        CNAE = dalCore.Unifica_Cnae(reg.Divisao, reg.Grupo, reg.Classe, reg.Subclasse)
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<CnaecriterioStruct> Lista_Cnae_Criterio(string Cnae) {
            List<CnaecriterioStruct> Lista = new List<CnaecriterioStruct>();
            using(GTI_Context db = new GTI_Context(_connection)) {
                var rows = (from c in db.Cnae_criterio join d in db.Cnaecriteriodesc on c.Criterio equals d.Criterio where c.Cnae==Cnae
                            select new CnaecriterioStruct { Cnae=c.Cnae,Criterio=c.Criterio,Valor=(decimal)d.Valor,Descricao=d.Descricao});
                foreach (var reg in rows) {
                    CnaecriterioStruct Linha = new CnaecriterioStruct {
                        Cnae = reg.Cnae,
                        Valor = reg.Valor,
                        Criterio = reg.Criterio,
                        Descricao = reg.Descricao
                    };
                    Lista.Add(Linha);
                }
            }
            return Lista;
        }

        public List<Cnaecriteriodesc> Lista_Cnae_Criterio() {
            List<Cnaecriteriodesc> Lista = new List<Cnaecriteriodesc>();
            using (GTI_Context db = new GTI_Context(_connection)) {
                var rows = (from c in db.Cnaecriteriodesc orderby c.Descricao select c).ToList();
                foreach (var reg in rows) {
                    Cnaecriteriodesc Linha = new Cnaecriteriodesc {
                        Valor = reg.Valor,
                        Criterio = reg.Criterio,
                        Descricao = reg.Descricao
                    };
                    Lista.Add(Linha);
                }
            }
            return Lista;
        }

        public SilStructure CarregaSil(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from s in db.Sil where s.Codigo == Codigo
                           select new {
                               s.Codigo, s.Protocolo, s.Data_emissao, s.Data_validade, s.Area_imovel
                           }).FirstOrDefault();

                SilStructure row = new SilStructure();
                if (reg == null)
                    return row;
                row.Codigo = Codigo;
                row.Data_Emissao = reg.Data_emissao;
                row.Data_Validade = reg.Data_validade;
                row.Protocolo = reg.Protocolo;
                row.AreaImovel = reg.Area_imovel;
                return (row);
            }
        }

        public bool Existe_Empresa_Vre(int nCodigo) {
            bool bRet = false;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var existingReg = db.Vre_empresa.Count(a => a.Id == nCodigo);
                if (existingReg != 0) {
                    bRet = true;
                }
            }
            return bRet;
        }

        public bool Existe_redeSim_Viabilidade(string Protocolo) {
            bool bRet = false;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var existingReg = db.Redesim_viabilidade.Count(a => a.Protocolo == Protocolo);
                if (existingReg != 0) {
                    bRet = true;
                }
            }
            return bRet;
        }

        public Exception Incluir_Empresa(Mobiliario reg) {
            string query = "INSERT INTO mobiliario (codigomob,razaosocial,nomefantasia,codlogradouro,numero,complemento,codbairro,codcidade,siglauf,cep,homepage,horario,dataabertura,";
            query += "numprocesso,dataprocesso,dataencerramento,numprocencerramento,dataprocencerramento,inscestadual,cnpj,cpf,isencao,codatividade,ativextenso,areatl,codigoaliq,datainicialdesc,";
            query += "datafinaldesc,percdesconto,capitalsocial,nomeorgao,codprofresp,numregistroresp,qtdesocio,qtdeempregado,respcontabil,rgresp,orgaoemisresp,nomecontato,cargocontato,";
            query += "fonecontato,faxcontato,emailcontato,vistoria,qtdeprof,rg,orgao,nomelogradouro,alvara,isentotaxa,horarioext,insctemp,horas24,isentoiss,bombonieri,imovel,substituto_tributario_issqn,individual,ponto_agencia) ";
            query += "VALUES(@codigomob,@razaosocial,@nomefantasia,@codlogradouro,@numero,@complemento,@codbairro,@codcidade,@siglauf,@cep,@homepage,@horario,@dataabertura,";
            query += "@numprocesso,@dataprocesso,@dataencerramento,@numprocencerramento,@dataprocencerramento,@inscestadual,@cnpj,@cpf,@isencao,@codatividade,@ativextenso,@areatl,@codigoaliq,@datainicialdesc,";
            query += "@datafinaldesc,@percdesconto,@capitalsocial,@nomeorgao,@codprofresp,@numregistroresp,@qtdesocio,@qtdeempregado,@respcontabil,@rgresp,@orgaoemisresp,@nomecontato,@cargocontato,";
            query += "@fonecontato,@faxcontato,@emailcontato,@vistoria,@qtdeprof,@rg,@orgao,@nomelogradouro,@alvara,@isentotaxa,@horarioext,@insctemp,@horas24,@isentoiss,@bombonieri,@imovel,@substituto_tributario_issqn,@individual,@ponto_agencia )";
            using (GTI_Context db = new GTI_Context(_connection)) {
                object[] Parametros = new object[59];
                Parametros[0] = new SqlParameter { ParameterName = "@Codigomob", SqlDbType = SqlDbType.Int, SqlValue = reg.Codigomob };
                Parametros[1] = new SqlParameter { ParameterName = "@razaosocial", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Razaosocial };
                if (reg.Nomefantasia != null)
                    Parametros[2] = new SqlParameter { ParameterName = "@nomefantasia", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Nomefantasia };
                else
                    Parametros[2] = new SqlParameter { ParameterName = "@nomefantasia", SqlValue = DBNull.Value };
                if (reg.Numero != null)
                    Parametros[3] = new SqlParameter { ParameterName = "@numero", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Numero };
                else
                    Parametros[3] = new SqlParameter { ParameterName = "@numero", SqlValue = DBNull.Value };
                if (reg.Complemento != null)
                    Parametros[4] = new SqlParameter { ParameterName = "@complemento", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Complemento };
                else
                    Parametros[4] = new SqlParameter { ParameterName = "@complemento", SqlValue = DBNull.Value };
                if (reg.Codbairro != null)
                    Parametros[5] = new SqlParameter { ParameterName = "@codbairro", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Codbairro };
                else
                    Parametros[5] = new SqlParameter { ParameterName = "@codbairro", SqlValue = DBNull.Value };
                if (reg.Codcidade != null)
                    Parametros[6] = new SqlParameter { ParameterName = "@codcidade", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Codcidade };
                else
                    Parametros[6] = new SqlParameter { ParameterName = "@codcidade", SqlValue = DBNull.Value };
                if (reg.Siglauf != null)
                    Parametros[7] = new SqlParameter { ParameterName = "@siglauf", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Siglauf };
                else
                    Parametros[7] = new SqlParameter { ParameterName = "@siglauf", SqlValue = DBNull.Value };
                if (reg.Cep != null)
                    Parametros[8] = new SqlParameter { ParameterName = "@cep", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Cep };
                else
                    Parametros[8] = new SqlParameter { ParameterName = "@cep", SqlValue = DBNull.Value };
                if (reg.Homepage != null)
                    Parametros[9] = new SqlParameter { ParameterName = "@homepage", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Homepage };
                else
                    Parametros[9] = new SqlParameter { ParameterName = "@homepage", SqlValue = DBNull.Value };
                if (reg.Horario != null)
                    Parametros[10] = new SqlParameter { ParameterName = "@horario", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Horario };
                else
                    Parametros[10] = new SqlParameter { ParameterName = "@horario", SqlValue = DBNull.Value };
                if(reg.Dataabertura!=null)
                    Parametros[11] = new SqlParameter { ParameterName = "@dataabertura", SqlDbType = SqlDbType.SmallDateTime, SqlValue = reg.Dataabertura };
                else
                    Parametros[11] = new SqlParameter { ParameterName = "@dataabertura",  SqlValue = DBNull.Value };
                if (reg.Numprocesso != null)
                    Parametros[12] = new SqlParameter { ParameterName = "@numprocesso", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Numprocesso };
                else
                    Parametros[12] = new SqlParameter { ParameterName = "@numprocesso", SqlValue = DBNull.Value };
                if (reg.Dataprocesso != null)
                    Parametros[13] = new SqlParameter { ParameterName = "@dataprocesso", SqlDbType = SqlDbType.SmallDateTime, SqlValue = reg.Dataprocesso };
                else
                    Parametros[13] = new SqlParameter { ParameterName = "@dataprocesso", SqlValue = DBNull.Value };
                if (reg.Dataencerramento != null)
                    Parametros[14] = new SqlParameter { ParameterName = "@dataencerramento", SqlDbType = SqlDbType.SmallDateTime, SqlValue = reg.Dataencerramento };
                else
                    Parametros[14] = new SqlParameter { ParameterName = "@dataencerramento", SqlValue = DBNull.Value };
                if (reg.Numprocencerramento != null)
                    Parametros[15] = new SqlParameter { ParameterName = "@numprocencerramento", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Numprocencerramento };
                else
                    Parametros[15] = new SqlParameter { ParameterName = "@numprocencerramento", SqlValue = DBNull.Value };
                if(reg.Dataprocencerramento!=null)
                    Parametros[16] = new SqlParameter { ParameterName = "@dataprocencerramento", SqlDbType = SqlDbType.SmallDateTime, SqlValue = reg.Dataprocencerramento };
                else
                    Parametros[16] = new SqlParameter { ParameterName = "@dataprocencerramento",  SqlValue = DBNull.Value };
                if (reg.Inscestadual!=null)
                    Parametros[17] = new SqlParameter { ParameterName = "@inscestadual", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Inscestadual };
                else
                    Parametros[17] = new SqlParameter { ParameterName = "@inscestadual",  SqlValue = DBNull.Value };
                if(reg.Cnpj!=null)
                    Parametros[18] = new SqlParameter { ParameterName = "@cnpj", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Cnpj };
                else
                    Parametros[18] = new SqlParameter { ParameterName = "@cnpj",  SqlValue = DBNull.Value };
                if(reg.Cpf!=null)
                    Parametros[19] = new SqlParameter { ParameterName = "@cpf", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Cpf };
                else
                    Parametros[19] = new SqlParameter { ParameterName = "@cpf",  SqlValue = DBNull.Value };
                if(reg.Isencao!=null)
                    Parametros[20] = new SqlParameter { ParameterName = "@isencao", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Isencao };
                else
                    Parametros[20] = new SqlParameter { ParameterName = "@isencao",  SqlValue = DBNull.Value };
                if(reg.Codatividade!=null)
                    Parametros[21] = new SqlParameter { ParameterName = "@codatividade", SqlDbType = SqlDbType.Int, SqlValue = reg.Codatividade };
                else
                    Parametros[21] = new SqlParameter { ParameterName = "@codatividade",  SqlValue = DBNull.Value };
                if (reg.Ativextenso!=null)
                    Parametros[22] = new SqlParameter { ParameterName = "@ativextenso", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Ativextenso };
                else
                    Parametros[22] = new SqlParameter { ParameterName = "@ativextenso",  SqlValue = DBNull.Value };
                if(reg.Areatl!=null)
                    Parametros[23] = new SqlParameter { ParameterName = "@areatl", SqlDbType = SqlDbType.Real, SqlValue = reg.Areatl };
                else
                    Parametros[23] = new SqlParameter { ParameterName = "@areatl",  SqlValue = DBNull.Value };
                if(reg.Codigoaliq!=null)
                    Parametros[24] = new SqlParameter { ParameterName = "@codigoaliq", SqlDbType = SqlDbType.TinyInt, SqlValue = reg.Codigoaliq };
                else
                    Parametros[24] = new SqlParameter { ParameterName = "@codigoaliq",  SqlValue = DBNull.Value };
                if(reg.Datainicialdesc!=null)
                    Parametros[25] = new SqlParameter { ParameterName = "@datainicialdesc", SqlDbType = SqlDbType.SmallDateTime, SqlValue = reg.Datainicialdesc };
                else
                    Parametros[25] = new SqlParameter { ParameterName = "@datainicialdesc",  SqlValue = DBNull.Value };
                if(reg.Datafinaldesc!=null)
                    Parametros[26] = new SqlParameter { ParameterName = "@datafinaldesc", SqlDbType = SqlDbType.SmallDateTime, SqlValue = reg.Datafinaldesc };
                else
                    Parametros[26] = new SqlParameter { ParameterName = "@datafinaldesc",  SqlValue = DBNull.Value };
                if(reg.Percdesconto!=null)
                    Parametros[27] = new SqlParameter { ParameterName = "@percdesconto", SqlDbType = SqlDbType.Real, SqlValue = reg.Percdesconto };
                else
                    Parametros[27] = new SqlParameter { ParameterName = "@percdesconto",  SqlValue = DBNull.Value };
                if(reg.Capitalsocial!=null)
                    Parametros[28] = new SqlParameter { ParameterName = "@capitalsocial", SqlDbType = SqlDbType.Real, SqlValue = reg.Capitalsocial };
                else
                    Parametros[28] = new SqlParameter { ParameterName = "@capitalsocial",  SqlValue = DBNull.Value };
                if(reg.Nomeorgao!=null)
                    Parametros[29] = new SqlParameter { ParameterName = "@nomeorgao", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Nomeorgao };
                else
                    Parametros[29] = new SqlParameter { ParameterName = "@nomeorgao",  SqlValue = DBNull.Value };
                if(reg.Codprofresp!=null)
                    Parametros[30] = new SqlParameter { ParameterName = "@codprofresp", SqlDbType = SqlDbType.Int, SqlValue = reg.Codprofresp };
                else
                    Parametros[30] = new SqlParameter { ParameterName = "@codprofresp",  SqlValue = DBNull.Value};
                if(reg.Numregistroresp!=null)
                    Parametros[31] = new SqlParameter { ParameterName = "@numregistroresp", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Numregistroresp };
                else
                    Parametros[31] = new SqlParameter { ParameterName = "@numregistroresp",  SqlValue =DBNull.Value};
                if(reg.Qtdesocio!=null)
                    Parametros[32] = new SqlParameter { ParameterName = "@qtdesocio", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Qtdesocio };
                else
                    Parametros[32] = new SqlParameter { ParameterName = "@qtdesocio",  SqlValue = DBNull.Value };
                if(reg.Qtdeempregado!=null)
                    Parametros[33] = new SqlParameter { ParameterName = "@qtdeempregado", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Qtdeempregado };
                else
                    Parametros[33] = new SqlParameter { ParameterName = "@qtdeempregado",  SqlValue = DBNull.Value };
                if(reg.Respcontabil!=null)
                    Parametros[34] = new SqlParameter { ParameterName = "@respcontabil", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Respcontabil };
                else
                    Parametros[34] = new SqlParameter { ParameterName = "@respcontabil",  SqlValue = DBNull.Value };
                if(reg.Rgresp!=null)
                    Parametros[35] = new SqlParameter { ParameterName = "@rgresp", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Rgresp };
                else
                    Parametros[35] = new SqlParameter { ParameterName = "@rgresp",  SqlValue = DBNull.Value};
                if (reg.Orgaoemisresp != null)
                    Parametros[36] = new SqlParameter { ParameterName = "@orgaoemisresp", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Orgaoemisresp };
                else
                    Parametros[36] = new SqlParameter { ParameterName = "@orgaoemisresp", SqlValue = DBNull.Value };
                if(reg.Nomecontato!=null)
                    Parametros[37] = new SqlParameter { ParameterName = "@nomecontato", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Nomecontato };
                else
                    Parametros[37] = new SqlParameter { ParameterName = "@nomecontato",  SqlValue = DBNull.Value };
                if(reg.Cargocontato!=null)
                    Parametros[38] = new SqlParameter { ParameterName = "@cargocontato", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Cargocontato };
                else
                    Parametros[38] = new SqlParameter { ParameterName = "@cargocontato",  SqlValue = DBNull.Value };
                if(reg.Fonecontato!=null)
                    Parametros[39] = new SqlParameter { ParameterName = "@fonecontato", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Fonecontato };
                else
                    Parametros[39] = new SqlParameter { ParameterName = "@fonecontato",  SqlValue = DBNull.Value };
                if(reg.Faxcontato!=null)
                    Parametros[40] = new SqlParameter { ParameterName = "@faxcontato", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Faxcontato };
                else
                    Parametros[40] = new SqlParameter { ParameterName = "@faxcontato",  SqlValue = DBNull.Value };
                if(reg.Emailcontato!=null)
                    Parametros[41] = new SqlParameter { ParameterName = "@emailcontato", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Emailcontato };
                else
                    Parametros[41] = new SqlParameter { ParameterName = "@emailcontato",  SqlValue = DBNull.Value };
                if(reg.Vistoria!=null)
                    Parametros[42] = new SqlParameter { ParameterName = "@vistoria", SqlDbType = SqlDbType.TinyInt, SqlValue = reg.Vistoria };
                else
                    Parametros[42] = new SqlParameter { ParameterName = "@vistoria",  SqlValue = DBNull.Value };
                if(reg.Qtdeprof!=null)
                    Parametros[43] = new SqlParameter { ParameterName = "@qtdeprof", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Qtdeprof };
                else
                    Parametros[43] = new SqlParameter { ParameterName = "@qtdeprof",  SqlValue = DBNull.Value };
                if(reg.Rg!=null)
                    Parametros[44] = new SqlParameter { ParameterName = "@rg", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Rg };
                else
                    Parametros[44] = new SqlParameter { ParameterName = "@rg",  SqlValue = DBNull.Value};
                if(reg.Orgao!=null)
                    Parametros[45] = new SqlParameter { ParameterName = "@orgao", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Orgao };
                else
                    Parametros[45] = new SqlParameter { ParameterName = "@orgao",  SqlValue = DBNull.Value };
                if(reg.Nomelogradouro!=null)
                    Parametros[46] = new SqlParameter { ParameterName = "@nomelogradouro", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Nomelogradouro };
                else
                    Parametros[46] = new SqlParameter { ParameterName = "@nomelogradouro",  SqlValue = DBNull.Value };
                if(reg.Alvara!=null)
                    Parametros[47] = new SqlParameter { ParameterName = "@alvara", SqlDbType = SqlDbType.TinyInt, SqlValue = reg.Alvara };
                else
                    Parametros[47] = new SqlParameter { ParameterName = "@alvara",  SqlValue =DBNull.Value };
                if(reg.Isentotaxa!=null)
                    Parametros[48] = new SqlParameter { ParameterName = "@isentotaxa", SqlDbType = SqlDbType.TinyInt, SqlValue = reg.Isentotaxa };
                else
                    Parametros[48] = new SqlParameter { ParameterName = "@isentotaxa",  SqlValue = DBNull.Value };
                if(reg.Horarioext!=null)
                    Parametros[49] = new SqlParameter { ParameterName = "@horarioext", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Horarioext };
                else
                    Parametros[49] = new SqlParameter { ParameterName = "@horarioext",  SqlValue = DBNull.Value};
                if(reg.Insctemp!=null)
                    Parametros[50] = new SqlParameter { ParameterName = "@insctemp", SqlDbType = SqlDbType.TinyInt, SqlValue = reg.Insctemp };
                else
                    Parametros[50] = new SqlParameter { ParameterName = "@insctemp",  SqlValue = DBNull.Value };
                if(reg.Horas24!=null)
                    Parametros[51] = new SqlParameter { ParameterName = "@horas24", SqlDbType = SqlDbType.TinyInt, SqlValue = reg.Horas24 };
                else
                    Parametros[51] = new SqlParameter { ParameterName = "@horas24",  SqlValue = DBNull.Value};
                if(reg.Isentoiss!=null)
                    Parametros[52] = new SqlParameter { ParameterName = "@isentoiss", SqlDbType = SqlDbType.TinyInt, SqlValue = reg.Isentoiss };
                else
                    Parametros[52] = new SqlParameter { ParameterName = "@isentoiss",  SqlValue = DBNull.Value };
                if(reg.Bombonieri!=null)
                    Parametros[53] = new SqlParameter { ParameterName = "@bombonieri", SqlDbType = SqlDbType.TinyInt, SqlValue = reg.Bombonieri };
                else
                    Parametros[53] = new SqlParameter { ParameterName = "@bombonieri",  SqlValue = DBNull.Value };
                if(reg.Imovel!=null)
                    Parametros[54] = new SqlParameter { ParameterName = "@imovel", SqlDbType = SqlDbType.Int, SqlValue = reg.Imovel };
                else
                    Parametros[54] = new SqlParameter { ParameterName = "@imovel",  SqlValue = DBNull.Value };
                if(reg.Substituto_tributario_issqn!=null)
                    Parametros[55] = new SqlParameter { ParameterName = "@substituto_tributario_issqn", SqlDbType = SqlDbType.Bit, SqlValue = reg.Substituto_tributario_issqn };
                else
                    Parametros[55] = new SqlParameter { ParameterName = "@substituto_tributario_issqn",  SqlValue = DBNull.Value };
                if(reg.Individual!=null)
                    Parametros[56] = new SqlParameter { ParameterName = "@individual", SqlDbType = SqlDbType.Bit, SqlValue = reg.Individual };
                else
                    Parametros[56] = new SqlParameter { ParameterName = "@individual",  SqlValue = DBNull.Value };
                if(reg.Ponto_agencia!=null)
                    Parametros[57] = new SqlParameter { ParameterName = "@ponto_agencia", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Ponto_agencia };
                else
                    Parametros[57] = new SqlParameter { ParameterName = "@ponto_agencia",  SqlValue = DBNull.Value };
                if(reg.Codlogradouro!=null)
                    Parametros[58] = new SqlParameter { ParameterName = "@codlogradouro", SqlDbType = SqlDbType.Int, SqlValue = reg.Codlogradouro };
                else
                    Parametros[58] = new SqlParameter { ParameterName = "@codlogradouro",  SqlValue = DBNull.Value };

                db.Database.ExecuteSqlCommand(query, Parametros);

                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;

            }
        }

        public Exception Incluir_Empresa_Placa(List<mobiliarioplaca> Lista,int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Database.ExecuteSqlCommand("DELETE FROM MOBILIARIOPLACA WHERE Codigo=@Codigo",
                        new SqlParameter("@Codigo", Codigo));
                } catch (Exception ex) {
                    return ex;
                }
                foreach (mobiliarioplaca item in Lista) {
                    try {
                        db.Database.ExecuteSqlCommand("INSERT INTO mobiliarioplaca(Codigo,placa) VALUES(@Codigo,@placa)",
                        new SqlParameter("@Codigo", item.Codigo),
                        new SqlParameter("@placa", item.placa));
                    } catch (Exception ex) {
                        return ex;
                    }
                }
                return null;

            }
        }

        public Exception Incluir_Empresa_Proprietario(List<Mobiliarioproprietario> Lista,int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Database.ExecuteSqlCommand("DELETE FROM MOBILIARIOPROPRIETARIO WHERE Codmobiliario=@Codigo",
                        new SqlParameter("@Codigo", Codigo));
                } catch (Exception ex) {
                    return ex;
                }
                foreach (Mobiliarioproprietario item in Lista) {
                    try {
                        db.Database.ExecuteSqlCommand("INSERT INTO mobiliarioproprietario(Codmobiliario,codcidadao) VALUES(@Codmobiliario,@codcidadao)",
                        new SqlParameter("@Codmobiliario", item.Codmobiliario),
                        new SqlParameter("@codcidadao", item.Codcidadao));
                    } catch (Exception ex) {
                        return ex;
                    }
                }
                return null;

            }
        }

        public Exception Incluir_Empresa_AtividadeISS(List<Mobiliarioatividadeiss> Lista, int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Database.ExecuteSqlCommand("DELETE FROM MOBILIARIOATIVIDADEISS WHERE Codmobiliario=@Codigo",
                        new SqlParameter("@Codigo", Codigo));
                } catch (Exception ex) {
                    return ex;
                }
                foreach (Mobiliarioatividadeiss item in Lista) {
                    try {
                        db.Database.ExecuteSqlCommand("INSERT INTO mobiliarioatividadeiss(Codmobiliario,codtributo,codatividade,seq,qtdeiss,valoriss) " +
                            "VALUES(@Codmobiliario,@codtributo,@codatividade,@seq,@qtdeiss,@valoriss)",
                        new SqlParameter("@Codmobiliario", item.Codmobiliario),
                        new SqlParameter("@codtributo", item.Codtributo), 
                        new SqlParameter("@codatividade", item.Codatividade),
                        new SqlParameter("@seq", item.Seq), 
                        new SqlParameter("@qtdeiss", item.Qtdeiss),
                        new SqlParameter("@valoriss", item.Valoriss));
                    } catch (Exception ex) {
                        return ex;
                    }
                }
                return null;
            }
        }

        public Exception Incluir_Empresa_CNAE(List<CnaeStruct> Lista, int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Database.ExecuteSqlCommand("DELETE FROM MOBILIARIOCNAE WHERE Codmobiliario=@Codigo",
                        new SqlParameter("@Codigo", Codigo));
                } catch (Exception ex) {
                    return ex;
                }
                foreach (CnaeStruct item in Lista) {
                    try {
                        db.Database.ExecuteSqlCommand("INSERT INTO mobiliariocnae (Codmobiliario,secao,divisao,grupo,classe,subclasse,principal,cnae) " +
                            "VALUES(@Codmobiliario,@secao,@divisao,@grupo,@classe,@subclasse,@principal,@cnae)",
                        new SqlParameter("@Codmobiliario", Codigo),
                        new SqlParameter("@secao", " "),
                        new SqlParameter("@divisao", item.Divisao),
                        new SqlParameter("@grupo", item.Grupo),
                        new SqlParameter("@classe", item.Classe),
                        new SqlParameter("@subclasse", item.Subclasse),
                        new SqlParameter("@principal", item.Principal),
                        new SqlParameter("@cnae", item.CNAE));
                    } catch (Exception ex) {
                        return ex;
                    }
                }
                return null;
            }
        }

        public Exception Incluir_Empresa_AtividadeVS(List<Mobiliariovs> Lista, int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Database.ExecuteSqlCommand("DELETE FROM MOBILIARIOVS WHERE codigo=@Codigo",
                        new SqlParameter("@Codigo", Codigo));
                } catch (Exception ex) {
                    return ex;
                }
                foreach (Mobiliariovs item in Lista) {
                    try {
                        db.Database.ExecuteSqlCommand("INSERT INTO mobiliariovs(Codigo,cnae,criterio,qtde) " +
                            "VALUES(@Codigo,@cnae,@criterio,@qtde)",
                        new SqlParameter("@Codigo", item.Codigo),
                        new SqlParameter("@cnae", item.Cnae),
                        new SqlParameter("@criterio", item.Criterio),
                        new SqlParameter("@qtde", item.Qtde));
                    } catch (Exception ex) {
                        return ex;
                    }
                }
                return null;
            }
        }

        //public Exception Insert_Empresa_Vre(Vre_empresa reg) {

        //    string query = "INSERT INTO vre_empresa(id,razao_social,cnpj,data_abertura,porte,numero_registro,tipo_registro,tipo_mei,cpf_responsavel,nome_responsavel,fone_contato1," +
        //            "fone_contato2,email_contato,setor_quadra_lote,tipo_logradouro,nome_logradouro,numero_imovel,complemento,bairro,cidade,uf,cep,area_estabelecimento,nome_proprietario,email_proprietario," +
        //            "fone_proprietario,nome_responsavel,fone_responsavel,area_total,pavimentos,contiguo,outros_usos,classif_CRC_PJ,classif_CRC_PF,numero_CRC_PJ,cnpj_contador,tipo_CRC_PF,tipo_CRC_PJ," +
        //            "numero_CRC_PF,uf_CRC_PF,uf_CRC_PJ,cpf_contador,nome_arquivo,data_importacao,situacao,codreduzido,data_emissao,data_validade,protocolo) VALUES(@id,@razao_social,@cnpj,data_abertura,@porte," +
        //            "@numero_registro,@tipo_registro,@tipo_mei,@cpf_responsavel,@nome_responsavel,@fone_contato1,@fone_contato2,@email_contato,@setor_quadra_lote,@tipo_logradouro,@nome_logradouro,@numero_imovel," +
        //            "@complemento,@bairro,@cidade,@uf,@cep,@area_estabelecimento,@nome_proprietario,@email_proprietario,@fone_proprietario,@nome_responsavel,@fone_responsavel,@area_total,@pavimentos,@contiguo," +
        //            "@outros_usos,@classif_CRC_PJ,@classif_CRC_PF,@numero_CRC_PJ,@cnpj_contador,@tipo_CRC_PF,@tipo_CRC_PJ,@numero_CRC_PF,@uf_CRC_PF,@uf_CRC_PJ,@cpf_contador,@nome_arquivo,@data_importacao," +
        //            "@situacao,@codreduzido,@data_emissao,@data_validade,@protocolo)";

        //    using (GTI_Context db = new GTI_Context(_connection)) {
        //            params object[] aPrm = new object;
        //            cmd.Parameters.Add("@id", SqlDbType.Int).Value = reg.Id;
        //            cmd.Parameters.Add("@Razao_social", SqlDbType.VarChar).Value = reg.Razao_social;
        //            cmd.Parameters.Add("@Cnpj", SqlDbType.VarChar).Value = reg.Cnpj;
        //            cmd.Parameters.Add("@Data_abertura", SqlDbType.DateTime).Value = reg.Data_abertura;
        //            cmd.Parameters.Add("@Porte", SqlDbType.TinyInt).Value = reg.Porte;
        //            cmd.Parameters.Add("@Numero_registro", SqlDbType.VarChar).Value = reg.Numero_registro;
        //            cmd.Parameters.Add("@Tipo_registro", SqlDbType.TinyInt).Value = reg.Numero_registro;
        //            cmd.Parameters.Add("@Tipo_mei", SqlDbType.TinyInt).Value = reg.Tipo_mei;
        //            cmd.Parameters.Add("@Cpf_responsavel", SqlDbType.VarChar).Value = reg.Cpf_responsavel;
        //            cmd.Parameters.Add("@Nome_responsavel", SqlDbType.VarChar).Value = reg.Nome_responsavel;
        //            cmd.Parameters.Add("@Fone_contato1", SqlDbType.VarChar).Value = reg.Fone_contato1;
        //            cmd.Parameters.Add("@Fone_contato2", SqlDbType.VarChar).Value = reg.Fone_contato2;
        //            cmd.Parameters.Add("@Email_contato", SqlDbType.VarChar).Value = reg.Email_contato;
        //            cmd.Parameters.Add("@Setor_quadra_lote", SqlDbType.VarChar).Value = reg.Setor_quadra_lote;
        //            cmd.Parameters.Add("@Tipo_logradouro", SqlDbType.VarChar).Value = reg.Tipo_logradouro;
        //            cmd.Parameters.Add("@Nome_logradouro", SqlDbType.VarChar).Value = reg.Nome_logradouro;
        //            cmd.Parameters.Add("@Numero_imovel", SqlDbType.Int).Value = reg.Numero_imovel;
        //            cmd.Parameters.Add("@Complemento", SqlDbType.VarChar).Value = reg.Complemento;
        //            cmd.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = reg.Bairro;
        //            cmd.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = reg.Cidade;
        //            cmd.Parameters.Add("@UF", SqlDbType.VarChar).Value = reg.UF;
        //            cmd.Parameters.Add("@Cep", SqlDbType.VarChar).Value = reg.Cep;
        //            cmd.Parameters.Add("@Area_estabelecimento", SqlDbType.Float).Value = reg.Area_estabelecimento;
        //            cmd.Parameters.Add("@Nome_proprietario", SqlDbType.VarChar).Value = reg.Nome_proprietario;
        //            cmd.Parameters.Add("@Email_proprietario", SqlDbType.VarChar).Value = reg.Email_proprietario;
        //            cmd.Parameters.Add("@Fone_proprietario", SqlDbType.Float).Value = reg.Fone_proprietario;
        //            cmd.Parameters.Add("@Nome_responsavel_uso", SqlDbType.VarChar).Value = reg.Nome_responsavel_uso;
        //            cmd.Parameters.Add("@Fone_responsavel_uso", SqlDbType.VarChar).Value = reg.Fone_responsavel_uso;
        //            cmd.Parameters.Add("@Area_total", SqlDbType.Float).Value = reg.Area_total;
        //            cmd.Parameters.Add("@Pavimentos", SqlDbType.VarChar).Value = reg.Pavimentos;
        //            cmd.Parameters.Add("@Contiguo", SqlDbType.VarChar).Value = reg.Contiguo;
        //            cmd.Parameters.Add("@Outros_usos", SqlDbType.Float).Value = reg.Outros_usos;
        //            cmd.Parameters.Add("@Classif_CRC_PJ", SqlDbType.TinyInt).Value = reg.Classif_CRC_PF;
        //            cmd.Parameters.Add("@Classif_CRC_PF", SqlDbType.TinyInt).Value = reg.Classif_CRC_PJ;
        //            cmd.Parameters.Add("@Numero_CRC_PJ", SqlDbType.VarChar).Value = reg.Numero_CRC_PJ;
        //            cmd.Parameters.Add("@Cnpj_contador", SqlDbType.VarChar).Value = reg.Cnpj_contador;
        //            cmd.Parameters.Add("@Tipo_CRC_PF", SqlDbType.VarChar).Value = reg.Tipo_CRC_PF;
        //            cmd.Parameters.Add("@Tipo_CRC_PJ", SqlDbType.VarChar).Value = reg.Tipo_CRC_PJ;
        //            cmd.Parameters.Add("@Numero_CRC_PF", SqlDbType.VarChar).Value = reg.Numero_CRC_PF;
        //            cmd.Parameters.Add("@UF_CRC_PF", SqlDbType.VarChar).Value = reg.Uf_CRC_PF;
        //            cmd.Parameters.Add("@UF_CRC_PJ", SqlDbType.VarChar).Value = reg.Tipo_CRC_PJ;
        //            cmd.Parameters.Add("@Cpf_contador", SqlDbType.VarChar).Value = reg.Cpf_contador;
        //            cmd.Parameters.Add("@Nome_arquivo", SqlDbType.VarChar).Value = reg.Nome_arquivo;
        //            cmd.Parameters.Add("@Data_importacao", SqlDbType.DateTime).Value = reg.Data_importacao;
        //            cmd.Parameters.Add("@Situacao", SqlDbType.VarChar).Value = reg.Situacao;
        //            cmd.Parameters.Add("@Codreduzido", SqlDbType.Int).Value = reg.Codreduzido;
        //            cmd.Parameters.Add("@Data_emissao", SqlDbType.DateTime).Value = reg.Data_emissao;
        //            cmd.Parameters.Add("@Data_validade", SqlDbType.VarChar).Value = reg.Data_validade;
        //            cmd.Parameters.Add("@Protocolo", SqlDbType.VarChar).Value = reg.Protocolo;
        //            try {
        //                db.Database.ExecuteSqlCommand(query,)
        //                } catch (Exception ex) {
        //                return ex;
        //            }
        //            return null;
        //    }

        //}

        public Exception Incluir_Empresa_Vre(Vre_empresa reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Vre_empresa.Add(reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Incluir_Atividade_Vre(Vre_atividade reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Vre_atividade.Add(reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Incluir_Socio_Vre(Vre_socio reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Vre_socio.Add(reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Incluir_Licenciamento_Vre(Vre_licenciamento reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Vre_licencimento.Add(reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public List<int> Retorna_Codigo_por_CPF(string CPF) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                List<int> Sql = (from c in db.Mobiliario where c.Cpf==CPF orderby c.Codigomob select c.Codigomob).ToList();
                return Sql;
            }
        }

        public List<int> Retorna_Codigo_por_CNPJ(string CNPJ) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                List<int> Sql = (from c in db.Mobiliario where c.Cnpj == CNPJ orderby c.Codigomob descending select c.Codigomob).ToList();
                return Sql;
            }
        }

        public bool Existe_Atividade_Empresa(int id_Atividade) {
            int _contador = 0;
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    _contador = (from p in db.Mobiliario where p.Codatividade == id_Atividade select p.Codigomob).Count();
                } catch {
                  
                }
                return _contador > 0 ? true : false;
            }
        }

        public Exception Excluir_Atividade(int id_atividade) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    Atividade b = db.Atividade.First(i => i.Codatividade == id_atividade);
                    db.Atividade.Remove(b);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public bool Empresa_Alvara_Automatico(int Codigo_Atividade) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from a in db.Atividade where a.Codatividade == Codigo_Atividade select new { a.Descatividade, a.Alvara }).FirstOrDefault();
                Atividade row = new Atividade();
                if (reg == null)
                    return false;
                else {
                    row.Descatividade = reg.Descatividade;
                    if (reg.Alvara == null)
                        return false;
                    else 
                        return reg.Alvara==0?false:true;
                }
            }
        }

        public int Retorna_Codigo_Disponivel() {
            int maxCod = 0,minCod=0;
            using (GTI_Context db = new GTI_Context(_connection)) {
                List<int>Lista = (from c in db.Mobiliario where c.Codigomob < 200000 select c.Codigomob).ToList();
                foreach (int item in Lista) {
                    if (minCod == 0)
                        minCod = item;
                    else {
                        maxCod = item;
                        if ((maxCod - minCod) > 1) {
                            maxCod = minCod + 1;
                            break;
                        } else
                            minCod = maxCod;
                    }
                }
            }
            return maxCod;
        }

        public Exception Alterar_Empresa(Mobiliario reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Mobiliario m = db.Mobiliario.First(i => i.Codigomob == reg.Codigomob);
                m.Alvara = reg.Alvara;
                m.Areatl = reg.Areatl;
                m.Ativextenso = reg.Ativextenso;
                m.Bombonieri = reg.Bombonieri;
                m.Cadastro_vre = reg.Cadastro_vre;
                m.Capitalsocial = reg.Capitalsocial;
                m.Cargocontato = reg.Cargocontato;
                m.Cep = reg.Cep;
                m.Cnpj = reg.Cnpj;
                m.Codatividade = reg.Codatividade;
                m.Codbairro = reg.Codbairro;
                m.Codcidade = reg.Codcidade;
                m.Codigoaliq = reg.Codigoaliq;
                m.Codlogradouro = reg.Codlogradouro;
                m.Codprofresp = reg.Codprofresp;
                m.Complemento = reg.Complemento;
                m.Cpf = reg.Cpf;
                m.Dataabertura = reg.Dataabertura;
                m.Dataencerramento = reg.Dataencerramento;
                m.Datafinaldesc = reg.Datafinaldesc;
                m.Datainicialdesc = reg.Datainicialdesc;
                m.Dataprocencerramento = reg.Dataprocencerramento;
                m.Dataprocesso = reg.Dataprocesso;
                m.Emailcontato = reg.Emailcontato;
                m.Emitenf = reg.Emitenf;
                m.Fonecontato = reg.Fonecontato;
                m.Homepage = reg.Homepage;
                m.Horario = reg.Horario;
                m.Horarioext = reg.Horarioext;
                m.Horas24 = reg.Horas24;
                m.Imovel = reg.Imovel;
                m.Individual = reg.Individual;
                m.Inscestadual = reg.Inscestadual;
                m.Insctemp = reg.Insctemp;
                m.Isencao = reg.Isencao;
                m.Isentoiss = reg.Isentoiss;
                m.Isentotaxa = reg.Isentotaxa;
                m.Liberado_vre = reg.Liberado_vre;
                m.Nomecontato = reg.Nomecontato;
                m.Nomefantasia = reg.Nomefantasia;
                m.Nomelogradouro = reg.Nomelogradouro;
                m.Nomeorgao = reg.Nomeorgao;
                m.Numero = reg.Numero;
                m.Numprocencerramento = reg.Numprocencerramento;
                m.Numprocesso = reg.Numprocesso;
                m.Numregistroresp = reg.Numregistroresp;
                m.Orgao = reg.Orgao;
                m.Orgaoemisresp = reg.Orgaoemisresp;
                m.Ponto_agencia = reg.Ponto_agencia;
                m.Qtdeempregado = reg.Qtdeempregado;
                m.Qtdeprof = reg.Qtdeprof;
                m.Razaosocial = reg.Razaosocial;
                m.Regespecial = reg.Regespecial;
                m.Respcontabil = reg.Respcontabil;
                m.Rg = reg.Rg;
                m.Siglauf = reg.Siglauf;
                m.Substituto_tributario_issqn = reg.Substituto_tributario_issqn;
                m.Vistoria = reg.Vistoria;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public int Retorna_Alvara_Disponivel(int Ano) {
            int maxCod = 0;
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    maxCod = (from c in db.Alvara_funcionamento where c.Ano == Ano select c.Numero).Max();
                    maxCod = Convert.ToInt32(maxCod + 1);
                } catch (Exception) {
                    maxCod = 1;     
                }
            }
            return maxCod;
        }

        public Horario_funcionamento Retorna_Horario_Funcionamento(int Codigo_Atividade){
            using (GTI_Context db = new GTI_Context(_connection))
            {
                return (from a in db.Atividade join h in db.Horario_funcionamento on a.Horario equals h.Id where a.Codatividade == Codigo_Atividade select h).FirstOrDefault();
            }
        }

        public List<EmpresaStruct> Lista_Empresa(EmpresaStruct Filter) {
            List<EmpresaStruct> Lista = new List<EmpresaStruct>();
            GTI_Context db = new GTI_Context(_connection);
            var Sql = (from m in db.Mobiliario
                       join a in db.Atividade on m.Codatividade equals a.Codatividade into am from a in am.DefaultIfEmpty()
                       join b in db.Bairro on new { p1 = (short)m.Codbairro, p2 = (short)m.Codcidade, p3 = m.Siglauf } equals new { p1 = b.Codbairro, p2 = b.Codcidade, p3 = b.Siglauf } into mb from b in mb.DefaultIfEmpty()
                       join c in db.Cidade on new { p1 = (short)m.Codcidade, p2 = m.Siglauf } equals new { p1 = c.Codcidade, p2 = c.Siglauf } into mc from c in mc.DefaultIfEmpty()
                       join l in db.Logradouro on m.Codlogradouro equals l.Codlogradouro into lm from l in lm.DefaultIfEmpty()
                       select new EmpresaStruct {
                           Codigo = m.Codigomob, Razao_social = m.Razaosocial, Atividade_codigo = m.Codatividade, Atividade_nome = a.Descatividade,Bairro_codigo=m.Codbairro,
                           Nome_logradouro = l.Endereco,Endereco_codigo=m.Codlogradouro, Numero = m.Numero, Complemento = m.Complemento, Bairro_nome = b.Descbairro
                       });

            if (Filter.Codigo > 0)
                Sql = Sql.Where(c => c.Codigo == Filter.Codigo);
            if (!string.IsNullOrWhiteSpace(Filter.Razao_social))
                Sql = Sql.Where(c => c.Razao_social.Contains(Filter.Razao_social));
            if(Filter.Atividade_codigo>0)
                Sql = Sql.Where(c => c.Atividade_codigo == Filter.Atividade_codigo);
            if (Filter.Endereco_codigo > 0)
                Sql = Sql.Where(c => c.Endereco_codigo == Filter.Endereco_codigo);
            if (Filter.Bairro_codigo > 0)
                Sql = Sql.Where(c => c.Bairro_codigo == Filter.Bairro_codigo);

            foreach (var reg in Sql) {
                EmpresaStruct Linha = new EmpresaStruct {
                    Codigo = reg.Codigo,
                    Razao_social = reg.Razao_social,
                    Atividade_nome = reg.Atividade_nome,
                    Atividade_codigo = reg.Atividade_codigo,
                    Endereco_nome=reg.Nome_logradouro,
                    Numero=reg.Numero,
                    Complemento=reg.Complemento,
                    Bairro_nome=reg.Bairro_nome
                };
                if (!string.IsNullOrEmpty(reg.Cpf) && reg.Cpf.Length > 10) {
                    Linha.Juridica = false;
                    Linha.Cpf_cnpj = reg.Cpf;
                    Linha.Cpf = reg.Cpf;
                } else {
                    if (!string.IsNullOrEmpty(reg.Cnpj) && reg.Cnpj.Length > 13) {
                        Linha.Cpf_cnpj = reg.Cnpj;
                        Linha.Cnpj = reg.Cnpj;
                        Linha.Juridica = true;
                    }
                }
                Lista.Add(Linha);
            }
            db.Dispose();
            db = new GTI_Context(_connection);

            foreach (var reg in Lista) {
                List<MobiliarioproprietarioStruct> _listaSocios = (from p in db.Mobiliarioproprietario
                                                                   join c in db.Cidadao on p.Codcidadao equals c.Codcidadao into pc from c in pc where p.Codmobiliario == reg.Codigo
                                                                   select new MobiliarioproprietarioStruct { Codmobiliario = reg.Codigo, Nome = c.Nomecidadao, Codcidadao = p.Codcidadao, Principal = p.Principal }).ToList();
                reg.Socios = _listaSocios;
            }
            return Lista;
        }

        public bool Existe_Debito_TaxaLicenca(int Codigo,int Ano) {
            int _contador = 0;
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    _contador = db.Debitoparcela.Count(d => d.Codreduzido == Codigo && d.Anoexercicio==Ano && d.Codlancamento == 6 && d.Numparcela > 0);
                } catch {

                }
                return _contador > 0 ? true : false;
            }
        }

        public Exception Incluir_Cnae_Criterio(Cnae_criterio reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Cnae_criterio.Add(reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Excluir_Cnae_Criterio(string _cnae,int _criterio) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    Cnae_criterio b = db.Cnae_criterio.First(i => i.Cnae == _cnae && i.Criterio==_criterio);
                    db.Cnae_criterio.Remove(b);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public bool Existe_Cnae_Criterio_Empresa(string _cnae,int _criterio) {
            int _contador = 0;
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    _contador = (from p in db.Mobiliariovs where p.Cnae == _cnae && p.Criterio==_criterio select p.Codigo).Count();
                } catch {

                }
                return _contador > 0 ? true : false;
            }
        }

        public Exception Incluir_redeSim_Viabilidade(Redesim_viabilidade reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Redesim_viabilidade.Add(reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

    }
}
