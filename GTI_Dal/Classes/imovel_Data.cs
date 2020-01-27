using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static GTI_Models.modelCore;

namespace GTI_Dal.Classes {
    public class Imovel_Data {

        private readonly string _connection;

        public Imovel_Data(string sConnection) {
            _connection = sConnection;
        }

        public ImovelStruct Dados_Imovel(int nCodigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from i in db.Cadimob
                           join c in db.Condominio on i.Codcondominio equals c.Cd_codigo into ic from c in ic.DefaultIfEmpty()
                           join b in db.Benfeitoria on i.Dt_codbenf equals b.Codbenfeitoria into ib from b in ib.DefaultIfEmpty()
                           join p in db.Pedologia on i.Dt_codpedol equals p.Codpedologia into ip from p in ip.DefaultIfEmpty()
                           join t in db.Topografia on i.Dt_codtopog equals t.Codtopografia into it from t in it.DefaultIfEmpty()
                           join s in db.Situacao on i.Dt_codsituacao equals s.Codsituacao into ist from s in ist.DefaultIfEmpty()
                           join cp in db.Categprop on i.Dt_codcategprop equals cp.Codcategprop into icp from cp in icp.DefaultIfEmpty()
                           join u in db.Usoterreno on i.Dt_codusoterreno equals u.Codusoterreno into iu from u in iu.DefaultIfEmpty()
                           where i.Codreduzido == nCodigo
                           select new ImovelStruct { Codigo = i.Codreduzido, Distrito = i.Distrito, Setor = i.Setor, Quadra = i.Quadra, Lote = i.Lote, Seq = i.Seq,
                               Unidade = i.Unidade, SubUnidade = i.Subunidade, NomeCondominio = c.Cd_nomecond, Imunidade = i.Imune, TipoMat = i.Tipomat, NumMatricula = i.Nummat,
                               Numero = i.Li_num, Complemento = i.Li_compl, QuadraOriginal = i.Li_quadras, LoteOriginal = i.Li_lotes, ResideImovel = i.Resideimovel, Inativo = i.Inativo,
                               FracaoIdeal = i.Dt_fracaoideal, Area_Terreno = i.Dt_areaterreno, Benfeitoria = i.Dt_codbenf, Categoria = i.Dt_codcategprop, Pedologia = i.Dt_codpedol, Topografia = i.Dt_codtopog,
                               Uso_terreno = i.Dt_codusoterreno, Situacao = i.Dt_codsituacao, EE_TipoEndereco = i.Ee_tipoend, Benfeitoria_Nome = b.Descbenfeitoria, Pedologia_Nome = p.Descpedologia,
                               Topografia_Nome = t.Desctopografia, Situacao_Nome = s.Descsituacao, Categoria_Nome = cp.Desccategprop, Uso_terreno_Nome = u.Descusoterreno, CodigoCondominio = c.Cd_codigo
                           }).FirstOrDefault();

                ImovelStruct row = new ImovelStruct();
                if (reg == null)
                    return row;
                row.Codigo = nCodigo;
                row.Distrito = reg.Distrito;
                row.Setor = reg.Setor;
                row.Quadra = reg.Quadra;
                row.Lote = reg.Lote;
                row.Seq = reg.Seq;
                row.Unidade = reg.Unidade;
                row.SubUnidade = reg.SubUnidade;
                row.Inscricao = reg.Distrito.ToString() + "." + reg.Setor.ToString("00") + "." + reg.Quadra.ToString("0000") + "." + reg.Lote.ToString("00000") + "." + reg.Seq.ToString("00") + "." + reg.Unidade.ToString("00") + "." + reg.SubUnidade.ToString("000");
                row.CodigoCondominio = reg.CodigoCondominio==null?0:reg.CodigoCondominio;
                row.NomeCondominio =  reg.NomeCondominio??"";
                row.Imunidade = reg.Imunidade == null ? false : Convert.ToBoolean(reg.Imunidade);
                row.Cip = reg.Cip == null ? false : Convert.ToBoolean(reg.Cip);
                row.ResideImovel = reg.ResideImovel == null ? false : Convert.ToBoolean(reg.ResideImovel);
                row.Inativo = reg.Inativo == null ? false : Convert.ToBoolean(reg.Inativo);
                if (reg.TipoMat == null || reg.TipoMat == "M")
                    row.TipoMat =  "M";
                else
                    row.TipoMat ="T";
                row.NumMatricula = reg.NumMatricula;
                row.QuadraOriginal = reg.QuadraOriginal == null ? "" : reg.QuadraOriginal.ToString();
                row.LoteOriginal = reg.LoteOriginal == null ? "" : reg.LoteOriginal.ToString();
                row.FracaoIdeal = reg.FracaoIdeal;
                row.Area_Terreno = reg.Area_Terreno;
                row.Benfeitoria = reg.Benfeitoria;
                row.Benfeitoria_Nome = reg.Benfeitoria_Nome;
                row.Categoria = reg.Categoria;
                row.Categoria_Nome = reg.Categoria_Nome;
                row.Pedologia = reg.Pedologia;
                row.Pedologia_Nome = reg.Pedologia_Nome;
                row.Situacao = reg.Situacao;
                row.Situacao_Nome = reg.Situacao_Nome;
                row.Topografia = reg.Topografia;
                row.Topografia_Nome = reg.Topografia_Nome;
                row.Uso_terreno = reg.Uso_terreno;
                row.Uso_terreno_Nome = reg.Uso_terreno_Nome;
                row.EE_TipoEndereco = reg.EE_TipoEndereco;

                EnderecoStruct regEnd = Dados_Endereco(nCodigo, TipoEndereco.Local);
                row.CodigoLogradouro = regEnd.CodLogradouro;
                row.NomeLogradouro = regEnd.Endereco;
                row.NomeLogradouroAbreviado = regEnd.Endereco_Abreviado;
                row.Numero = regEnd.Numero;
                row.Complemento = regEnd.Complemento;
                row.Cep = regEnd.Cep;
                row.CodigoBairro = regEnd.CodigoBairro;
                row.NomeBairro = regEnd.NomeBairro;
                
                return row;
            }
        }//End LoadReg

        public decimal Soma_Area(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var sum = db.Areas.Where(x=>x.Codreduzido==Codigo).Sum(x => x.Areaconstr);
                return Convert.ToDecimal(sum);
            }
        }

        public int Qtde_Imovel_Cidadao(int CodigoImovel) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int Sql = (from v in db.Vwproprietarioduplicado join p in db.Proprietario on v.Codproprietario equals p.Codcidadao where p.Codreduzido == CodigoImovel && p.Tipoprop == "P" select v.Qtdeimovel).FirstOrDefault();
                    return Sql;
            }
        }

        public List<ProprietarioStruct> Lista_Proprietario(int CodigoImovel, bool Principal = false) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from p in db.Proprietario
                           join c in db.Cidadao on p.Codcidadao equals c.Codcidadao
                           where p.Codreduzido == CodigoImovel
                           select new { p.Codcidadao, c.Nomecidadao, p.Tipoprop, p.Principal,c.Cpf,c.Cnpj,c.Rg });

                if (Principal)
                    reg = reg.Where(u => u.Tipoprop == "P" && u.Principal == true);

                List<ProprietarioStruct> Lista = new List<ProprietarioStruct>();
                foreach (var query in reg) {
                    string sDoc;
                    if (!string.IsNullOrEmpty(query.Cpf) && query.Cpf.ToString().Length > 5)
                        sDoc = query.Cpf;
                    else {
                        if (!string.IsNullOrEmpty(query.Cnpj) && query.Cnpj.ToString().Length > 10)
                            sDoc = query.Cnpj;
                        else
                            sDoc = "";
                    }

                    ProprietarioStruct Linha = new ProprietarioStruct {
                        Codigo = query.Codcidadao,
                        Nome = query.Nomecidadao,
                        Tipo = query.Tipoprop,
                        Principal = Convert.ToBoolean(query.Principal),
                        CPF= sDoc,
                        RG=query.Rg
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<LogradouroStruct> Lista_Logradouro(String Filter = "") {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from l in db.Logradouro
                           select new { l.Codlogradouro, l.Endereco });
                if (!String.IsNullOrEmpty(Filter))
                    reg = reg.Where(u => u.Endereco.Contains(Filter));

                List<LogradouroStruct> Lista = new List<LogradouroStruct>();
                foreach (var query in reg) {
                    LogradouroStruct Linha = new LogradouroStruct {
                        CodLogradouro = query.Codlogradouro,
                        Endereco = query.Endereco
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<FacequadraStruct> Lista_FaceQuadra(int distrito,int setor,int quadra,int face) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from f in db.Facequadra
                           join l in db.Logradouro on f.Codlogr equals l.Codlogradouro into lf from l in lf.DefaultIfEmpty()
                           where f.Coddistrito==distrito && f.Codsetor==setor  && f.Codquadra==quadra && f.Codface==face
                           select new FacequadraStruct { Agrupamento=f.Codagrupa,Logradouro_codigo=f.Codlogr,Logradouro_nome=l.Endereco });

                List<FacequadraStruct> Lista = new List<FacequadraStruct>();
                foreach (var query in reg) {
                    FacequadraStruct Linha = new FacequadraStruct {
                        Logradouro_codigo = query.Logradouro_codigo,
                        Logradouro_nome = query.Logradouro_nome,
                        Agrupamento=query.Agrupamento
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public bool Existe_Imovel(int nCodigo) {
            bool bRet = false;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var existingReg = db.Cadimob.Count(a => a.Codreduzido == nCodigo);
                if (existingReg != 0) {
                    bRet = true;
                }
            }
            return bRet;
        }

        public int Existe_Imovel(int distrito, int setor, int quadra, int lote, int unidade, int subunidade) {
            int nRet = 0;
            using (GTI_Context db = new GTI_Context(_connection)) {
                nRet = (from a in db.Cadimob where a.Distrito == distrito && a.Setor == setor && a.Quadra == quadra && a.Lote == lote && a.Unidade == unidade && a.Subunidade == subunidade select a.Codreduzido).FirstOrDefault();
            }
            return nRet;
        }

        public int Retorna_Imovel_Inscricao(int distrito,int setor,int quadra,int lote,int face,int unidade,int subunidade) {
            int nRet = 0;
            using (GTI_Context db = new GTI_Context(_connection)) {
                nRet = (from a in db.Cadimob where a.Distrito == distrito && a.Setor==setor && a.Quadra==quadra && a.Lote==lote && a.Seq==face && a.Unidade==unidade&& a.Subunidade==subunidade select a.Codreduzido).FirstOrDefault();
            }
            return nRet;
        }

        public EnderecoStruct Dados_Endereco(int Codigo, TipoEndereco Tipo) {
            EnderecoStruct regEnd = new EnderecoStruct();
            using (GTI_Context db = new GTI_Context(_connection)) {
                if (Tipo == TipoEndereco.Local) {
                    var reg = (from i in db.Cadimob
                               join b in db.Bairro on i.Li_codbairro equals b.Codbairro into ib from b in ib.DefaultIfEmpty()
                               join fq in db.Facequadra on new { p1 = i.Distrito, p2 = i.Setor, p3 = i.Quadra, p4 = i.Seq } equals new { p1 = fq.Coddistrito, p2 = fq.Codsetor, p3 = fq.Codquadra, p4 = fq.Codface } into ifq from fq in ifq.DefaultIfEmpty()
                               join l in db.Logradouro on fq.Codlogr equals l.Codlogradouro into lfq from l in lfq.DefaultIfEmpty()
                               where i.Codreduzido == Codigo && b.Siglauf == "SP" && b.Codcidade == 413
                               select new {
                                   i.Li_num, i.Li_codbairro, b.Descbairro, fq.Codlogr, l.Endereco, i.Li_compl,l.Endereco_resumido
                               }).FirstOrDefault();
                    if (reg == null)
                        return regEnd;
                    else {
                        regEnd.CodigoBairro = reg.Li_codbairro;
                        regEnd.NomeBairro = reg.Descbairro.ToString();
                        regEnd.CodigoCidade = 413;
                        regEnd.NomeCidade = "JABOTICABAL";
                        regEnd.UF = "SP";
                        regEnd.CodLogradouro = reg.Codlogr;
                        regEnd.Endereco = reg.Endereco ?? "";
                        regEnd.Endereco_Abreviado = reg.Endereco_resumido ?? "";
                        regEnd.Numero = reg.Li_num;
                        regEnd.Complemento = reg.Li_compl ?? "";
                        regEnd.CodigoBairro = reg.Li_codbairro;
                        regEnd.NomeBairro = reg.Descbairro;
                        Endereco_Data clsCep = new Endereco_Data(_connection);
                        regEnd.Cep = clsCep.RetornaCep(Convert.ToInt32(reg.Codlogr), Convert.ToInt16(reg.Li_num)) == 0 ? "14870000" : clsCep.RetornaCep(Convert.ToInt32(reg.Codlogr), Convert.ToInt16(reg.Li_num)).ToString("0000");
                    }
                } else if (Tipo ==TipoEndereco.Entrega) {
                    var reg = (from ee in db.Endentrega
                               join b in db.Bairro on new { p1 = ee.Ee_uf, p2 = ee.Ee_cidade, p3 = ee.Ee_bairro } equals new { p1 = b.Siglauf, p2 = (short?)b.Codcidade, p3 = (short?)b.Codbairro } into eeb from b in eeb.DefaultIfEmpty()
                               join c in db.Cidade on new { p1 = ee.Ee_uf, p2 = ee.Ee_cidade } equals new { p1 = c.Siglauf, p2 = (short?)c.Codcidade } into eec from c in eec.DefaultIfEmpty()
                               join l in db.Logradouro on ee.Ee_codlog equals l.Codlogradouro into lee from l in lee.DefaultIfEmpty()
                               where ee.Codreduzido == Codigo
                               select new {
                                   ee.Ee_numimovel, ee.Ee_bairro, b.Descbairro, c.Desccidade, ee.Ee_uf, ee.Ee_cidade, ee.Ee_codlog, ee.Ee_nomelog, l.Endereco, ee.Ee_complemento,l.Endereco_resumido,ee.Ee_cep
                               }).FirstOrDefault();
                    if (reg == null)
                        return regEnd;
                    else {
                        regEnd.CodigoBairro = reg.Ee_bairro;
                        regEnd.NomeBairro = reg.Descbairro==null?"": reg.Descbairro.ToString();
                        regEnd.CodigoCidade = reg.Ee_cidade==null?0: reg.Ee_cidade;
                        regEnd.NomeCidade = reg.Descbairro==null?"": reg.Desccidade;
                        regEnd.UF = "SP";
                        regEnd.CodLogradouro = reg.Ee_codlog;
                        regEnd.Endereco = reg.Ee_nomelog??"";
                        regEnd.Endereco_Abreviado = reg.Endereco_resumido ?? "";
                        if (!String.IsNullOrEmpty(reg.Endereco))
                            regEnd.Endereco = reg.Endereco.ToString();
                        regEnd.Numero = reg.Ee_numimovel;
                        regEnd.Complemento = reg.Ee_complemento ?? "";
                        regEnd.CodigoBairro = reg.Ee_bairro;
                        regEnd.NomeBairro = reg.Descbairro;
                        Endereco_Data clsCep = new Endereco_Data(_connection);
                        if(regEnd.CodLogradouro==0)
                            regEnd.Cep = dalCore.RetornaNumero(reg.Ee_cep)==""?"00000000": Convert.ToInt32 (dalCore.RetornaNumero(  reg.Ee_cep)).ToString("00000000");
                        else
                            regEnd.Cep = clsCep.RetornaCep( Convert.ToInt32(regEnd.CodLogradouro), Convert.ToInt16(reg.Ee_numimovel)) == 0 ? "00000000" : clsCep.RetornaCep(Convert.ToInt32(regEnd.CodLogradouro), Convert.ToInt16(reg.Ee_numimovel)).ToString("0000");
                    }
                } else if (Tipo == TipoEndereco.Proprietario) {
                    List<ProprietarioStruct> _lista_proprietario = Lista_Proprietario(Codigo, true);
                    int _codigo_proprietario = _lista_proprietario[0].Codigo;
                    Cidadao_Data clsCidadao = new Cidadao_Data(_connection);
                    CidadaoStruct _cidadao = clsCidadao.LoadReg(_codigo_proprietario);
                    if (_cidadao.EtiquetaC == "S" ) {
                        regEnd.Endereco = _cidadao.EnderecoC;
                        regEnd.Endereco_Abreviado = _cidadao.EnderecoC;
                        regEnd.Numero = _cidadao.NumeroC;
                        regEnd.Complemento = _cidadao.ComplementoC;
                        regEnd.CodigoBairro = _cidadao.CodigoBairroC;
                        regEnd.NomeBairro = _cidadao.NomeBairroC;
                        regEnd.CodigoCidade = _cidadao.CodigoCidadeC;
                        regEnd.NomeCidade = _cidadao.NomeCidadeC;
                        regEnd.UF = _cidadao.UfC;
                        regEnd.Cep = _cidadao.CepC.ToString();
                    } else {
                        regEnd.Endereco = _cidadao.EnderecoR;
                        regEnd.Endereco_Abreviado = _cidadao.EnderecoR;
                        regEnd.Numero = _cidadao.NumeroR;
                        regEnd.Complemento = _cidadao.ComplementoR;
                        regEnd.CodigoBairro = _cidadao.CodigoBairroR;
                        regEnd.NomeBairro = _cidadao.NomeBairroR;
                        regEnd.CodigoCidade = _cidadao.CodigoCidadeR;
                        regEnd.NomeCidade = _cidadao.NomeCidadeR;
                        regEnd.UF = _cidadao.UfR;
                        regEnd.Cep = _cidadao.CepR.ToString();
                    }
                }
            }

            return regEnd;
        }

        public List<Categprop> Lista_Categoria_Propriedade() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from c in db.Categprop where c.Codcategprop != 999 orderby c.Desccategprop select new {c.Codcategprop,c.Desccategprop}).ToList();
                List<Categprop> Lista = new List<Categprop>();
                foreach (var item in reg) {
                    Categprop Linha = new Categprop {
                        Codcategprop = item.Codcategprop,
                        Desccategprop = item.Desccategprop
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Topografia> Lista_Topografia() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from t in db.Topografia where t.Codtopografia != 999 orderby t.Desctopografia select new { t.Codtopografia,t.Desctopografia }).ToList();
                List<Topografia> Lista = new List<Topografia>();
                foreach (var item in reg) {
                    Topografia Linha = new Topografia {
                        Codtopografia = item.Codtopografia,
                        Desctopografia = item.Desctopografia
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Situacao> Lista_Situacao() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from t in db.Situacao where t.Codsituacao != 999 orderby t.Descsituacao select new { t.Codsituacao, t.Descsituacao }).ToList();
                List<Situacao> Lista = new List<Situacao>();
                foreach (var item in reg) {
                    Situacao Linha = new Situacao {
                        Codsituacao = item.Codsituacao,
                        Descsituacao = item.Descsituacao
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Benfeitoria> Lista_Benfeitoria() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from t in db.Benfeitoria where t.Codbenfeitoria != 999 orderby t.Descbenfeitoria select new { t.Codbenfeitoria, t.Descbenfeitoria }).ToList();
                List<Benfeitoria> Lista = new List<Benfeitoria>();
                foreach (var item in reg) {
                    Benfeitoria Linha = new Benfeitoria {
                        Codbenfeitoria = item.Codbenfeitoria,
                        Descbenfeitoria = item.Descbenfeitoria
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Pedologia> Lista_Pedologia() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from t in db.Pedologia where t.Codpedologia != 999 orderby t.Descpedologia select new { t.Codpedologia, t.Descpedologia }).ToList();
                List<Pedologia> Lista = new List<Pedologia>();
                foreach (var item in reg) {
                    Pedologia Linha = new Pedologia {
                        Codpedologia = item.Codpedologia,
                        Descpedologia = item.Descpedologia
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Usoterreno> Lista_Uso_Terreno() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from t in db.Usoterreno where t.Codusoterreno != 999 orderby t.Descusoterreno select new { t.Codusoterreno, t.Descusoterreno }).ToList();
                List<Usoterreno> Lista = new List<Usoterreno>();
                foreach (var item in reg) {
                    Usoterreno Linha = new Usoterreno {
                        Codusoterreno = item.Codusoterreno,
                        Descusoterreno = item.Descusoterreno
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Usoconstr> Lista_Uso_Construcao() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from t in db.Usoconstr where t.Codusoconstr != 999 orderby t.Descusoconstr select new { t.Codusoconstr, t.Descusoconstr }).ToList();
                List<Usoconstr> Lista = new List<Usoconstr>();
                foreach (var item in reg) {
                    Usoconstr Linha = new Usoconstr {
                        Codusoconstr = item.Codusoconstr,
                        Descusoconstr = item.Descusoconstr
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Categconstr> Lista_Categoria_Construcao() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from c in db.Categconstr where c.Codcategconstr != 999 orderby c.Desccategconstr select new { c.Codcategconstr, c.Desccategconstr }).ToList();
                List<Categconstr> Lista = new List<Categconstr>();
                foreach (var item in reg) {
                    Categconstr Linha = new Categconstr {
                        Codcategconstr = item.Codcategconstr,
                        Desccategconstr = item.Desccategconstr
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Tipoconstr> Lista_Tipo_Construcao() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from c in db.Tipoconstr where c.Codtipoconstr != 999 orderby c.Desctipoconstr select new { c.Codtipoconstr, c.Desctipoconstr }).ToList();
                List<Tipoconstr> Lista = new List<Tipoconstr>();
                foreach (var item in reg) {
                    Tipoconstr Linha = new Tipoconstr {
                        Codtipoconstr = item.Codtipoconstr,
                        Desctipoconstr = item.Desctipoconstr
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Testada> Lista_Testada(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from t in db.Testada where t.Codreduzido == Codigo orderby t.Numface select t).ToList();
                List<Testada> Lista = new List<Testada>();
                foreach (var item in reg) {
                    Testada Linha = new Testada {
                        Codreduzido = item.Codreduzido,
                        Numface = item.Numface,
                        Areatestada = item.Areatestada
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<AreaStruct> Lista_Area(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from a in db.Areas
                           join c in db.Categconstr on a.Catconstr equals c.Codcategconstr into ac from c in ac.DefaultIfEmpty()
                           join t in db.Tipoconstr on a.Tipoconstr equals t.Codtipoconstr into at from t in at.DefaultIfEmpty()
                           join u in db.Usoconstr on a.Usoconstr equals u.Codusoconstr into au from u in au.DefaultIfEmpty()
                           where a.Codreduzido == Codigo orderby a.Seqarea select new AreaStruct { Codigo=a.Codreduzido,Data_Aprovacao=a.Dataaprova,Area=(decimal)a.Areaconstr,Categoria_Codigo=a.Catconstr,
                           Tipo_Nome=t.Desctipoconstr ,Categoria_Nome=c.Desccategconstr,Data_Processo=a.Dataprocesso,Numero_Processo=a.Numprocesso,Pavimentos=a.Qtdepav,Seq=a.Seqarea,Tipo_Area=a.Tipoarea,Tipo_Codigo=a.Tipoconstr,
                           Uso_Codigo=a.Usoconstr,Uso_Nome=u.Descusoconstr}).ToList();
                List<AreaStruct> Lista = new List<AreaStruct>();
                foreach (var item in reg) {
                    AreaStruct Linha = new AreaStruct {
                        Codigo = item.Codigo,
                        Seq = item.Seq,
                        Area = item.Area,
                        Categoria_Codigo = item.Categoria_Codigo,
                        Categoria_Nome = item.Categoria_Nome,
                        Uso_Codigo = item.Uso_Codigo,
                        Uso_Nome = item.Uso_Nome,
                        Tipo_Codigo = item.Tipo_Codigo,
                        Tipo_Nome = item.Tipo_Nome,
                        Pavimentos = item.Pavimentos,
                        Numero_Processo = item.Numero_Processo,
                        Data_Processo = item.Data_Processo,
                        Data_Aprovacao = item.Data_Aprovacao,
                        Tipo_Area = item.Tipo_Area
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public ImovelStruct Inscricao_imovel(int Logradouro, short Numero) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from i in db.Cadimob
                           join f in db.Facequadra on new { p1 = i.Distrito, p2 = i.Setor, p3 = i.Quadra, p4 = i.Seq } equals new { p1 = f.Coddistrito, p2 = f.Codsetor, p3 = f.Codquadra, p4 = f.Codface } into fi from f in fi.DefaultIfEmpty()
                           join l in db.Logradouro on f.Codlogr equals l.Codlogradouro into lf from l in lf.DefaultIfEmpty()
                           where f.Codlogr == Logradouro && i.Li_num == Numero
                           select new ImovelStruct {Codigo=i.Codreduzido,
                               Distrito = i.Distrito, Setor = i.Setor, Quadra = i.Quadra, Lote = i.Lote, Seq = i.Seq, Unidade = i.Unidade, SubUnidade = i.Subunidade
                           }).FirstOrDefault();

                ImovelStruct row = new ImovelStruct();
                if (reg == null)
                    return row;
                row.Codigo = reg.Codigo;
                row.Distrito = reg.Distrito;
                row.Setor = reg.Setor;
                row.Quadra = reg.Quadra;
                row.Lote = reg.Lote;
                row.Seq = reg.Seq;
                row.Unidade = reg.Unidade;
                row.SubUnidade = reg.SubUnidade;

                return row;
            }
        }

        public List<int> Lista_Imovel_Ativo() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from e in db.Cadimob where e.Inativo ==false orderby e.Codreduzido select e.Codreduzido).ToList();
                return Sql;
            }
        }

        public List<Condominio> Lista_Condominio() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from e in db.Condominio where e.Cd_codigo > 0 orderby e.Cd_nomecond select e).ToList();
                return Sql;
            }
        }

        public CondominioStruct Dados_Condominio(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from m in db.Condominio
                           join b in db.Bairro on m.Cd_codbairro equals b.Codbairro into mb from b in mb.DefaultIfEmpty()
                           join c in db.Cidade on new { p1 = (short)m.Cd_codcidade, p2 = m.Cd_uf } equals new { p1 = c.Codcidade, p2 = c.Siglauf } into mc from c in mc.DefaultIfEmpty()
                           join f in db.Facequadra on new { p1 = m.Cd_distrito, p2 = m.Cd_setor, p3 = m.Cd_quadra, p4 = m.Cd_seq } equals new { p1 = f.Coddistrito, p2 = f.Codsetor, p3 = f.Codquadra, p4 = f.Codface } into mf from f in mf.DefaultIfEmpty()
                           join l in db.Logradouro on f.Codlogr equals l.Codlogradouro into lm from l in lm.DefaultIfEmpty()
                           join bf in db.Benfeitoria on m.Cd_codbenf equals bf.Codbenfeitoria into ib from bf in ib.DefaultIfEmpty()
                           join pd in db.Pedologia on m.Cd_codpedol equals pd.Codpedologia into ip from pd in ip.DefaultIfEmpty()
                           join tp in db.Topografia on m.Cd_codtopog equals tp.Codtopografia into it from tp in it.DefaultIfEmpty()
                           join st in db.Situacao on m.Cd_codsituacao equals st.Codsituacao into ist from st in ist.DefaultIfEmpty()
                           join cp in db.Categprop on m.Cd_codcategprop equals cp.Codcategprop into icp from cp in icp.DefaultIfEmpty()
                           join u in db.Usoterreno on m.Cd_codusoterreno equals u.Codusoterreno into iu from u in iu.DefaultIfEmpty()
                           where m.Cd_codigo == Codigo
                           select new CondominioStruct {
                               Codigo = m.Cd_codigo, Nome = m.Cd_nomecond, Codigo_Logradouro = f.Codlogr, Nome_Logradouro = l.Endereco, Numero = m.Cd_num, Cep = m.Cd_cep,
                               Complemento = m.Cd_compl, Codigo_Bairro = m.Cd_codbairro, Nome_Bairro = b.Descbairro, Area_Construida = m.Cd_areatotconstr, Area_Terreno = m.Cd_areaterreno,
                               Benfeitoria = m.Cd_codbenf, Categoria = m.Cd_codcategprop, Fracao_Ideal = m.Cd_fracao, Pedologia = m.Cd_codpedol, Lote_Original = m.Cd_lotes, Quadra_Original = m.Cd_quadras,
                               Situacao = m.Cd_codsituacao, Topografia = m.Cd_codtopog, Uso_terreno = m.Cd_codusoterreno, Codigo_Proprietario = m.Cd_prop, Qtde_Unidade = m.Cd_numunid, Distrito = m.Cd_distrito,
                               Setor = m.Cd_setor, Quadra = m.Cd_quadra, Lote = m.Cd_lote, Seq = m.Cd_seq, Benfeitoria_Nome = bf.Descbenfeitoria, Categoria_Nome = cp.Desccategprop, Pedologia_Nome = pd.Descpedologia,
                               Situacao_Nome = st.Descsituacao, Topografia_Nome = tp.Desctopografia, Uso_terreno_Nome = u.Descusoterreno
                           }).FirstOrDefault();

                CondominioStruct row = new CondominioStruct();
                if (reg == null)
                    return row;
                row.Codigo = reg.Codigo;
                row.Nome = reg.Nome;
                row.Codigo_Logradouro = reg.Codigo_Logradouro;
                row.Nome_Logradouro = reg.Nome_Logradouro;
                row.Numero = reg.Numero;
                row.Complemento = reg.Complemento;
                row.Codigo_Bairro = reg.Codigo_Bairro;
                row.Nome_Bairro = reg.Nome_Bairro;
                row.Distrito = reg.Distrito;
                row.Setor = reg.Setor;
                row.Quadra = reg.Quadra;
                row.Lote = reg.Lote;
                row.Seq = reg.Seq;
                row.Area_Construida = reg.Area_Construida;
                row.Area_Terreno = reg.Area_Terreno;
                row.Benfeitoria = reg.Benfeitoria;
                row.Benfeitoria_Nome = reg.Benfeitoria_Nome;
                row.Categoria = reg.Categoria;
                row.Categoria_Nome = reg.Categoria_Nome;
                row.Cep = reg.Cep;
                row.Codigo_Proprietario = reg.Codigo_Proprietario;
                row.Fracao_Ideal = reg.Fracao_Ideal;
                row.Lote_Original = reg.Lote_Original;
                row.Pedologia = reg.Pedologia;
                row.Pedologia_Nome = reg.Pedologia_Nome;
                row.Qtde_Unidade = reg.Qtde_Unidade;
                row.Quadra_Original = reg.Quadra_Original;
                row.Situacao = reg.Situacao;
                row.Situacao_Nome = reg.Situacao_Nome;
                row.Topografia = reg.Topografia;
                row.Topografia_Nome = reg.Topografia_Nome;
                row.Uso_terreno = reg.Uso_terreno;
                row.Uso_terreno_Nome = reg.Uso_terreno_Nome;

                if (reg.Codigo_Logradouro > 0) {
                    Endereco_Data Cep_Class = new Endereco_Data(_connection);
                    int nCep = Cep_Class.RetornaCep((int)reg.Codigo_Logradouro, (short)reg.Numero);
                    row.Cep = nCep == 0 ? "00000000" : nCep.ToString("0000");
                }

                return row;
            }
        }

        public List<AreaStruct> Lista_Area_Condominio(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from a in db.CondominioArea
                           join c in db.Categconstr on a.Catconstr equals c.Codcategconstr into ac from c in ac.DefaultIfEmpty()
                           join t in db.Tipoconstr on a.Tipoconstr equals t.Codtipoconstr into at from t in at.DefaultIfEmpty()
                           join u in db.Usoconstr on a.Usoconstr equals u.Codusoconstr into au from u in au.DefaultIfEmpty()
                           where a.Codcondominio == Codigo orderby a.Seqarea select new AreaStruct {
                               Codigo = a.Codcondominio, Data_Aprovacao = a.Dataaprova, Area = a.Areaconstr, Categoria_Codigo = a.Catconstr, Tipo_Nome = t.Desctipoconstr, Categoria_Nome = c.Desccategconstr,
                               Data_Processo = a.Dataprocesso, Numero_Processo = a.Numprocesso, Pavimentos = a.Qtdepav, Seq = a.Seqarea, Tipo_Area = a.Tipoarea, Tipo_Codigo = a.Tipoconstr,
                               Uso_Codigo = a.Usoconstr, Uso_Nome = u.Descusoconstr
                           }).ToList();
                List<AreaStruct> Lista = new List<AreaStruct>();
                foreach (var item in reg) {
                    AreaStruct Linha = new AreaStruct {
                        Codigo = item.Codigo,
                        Seq = item.Seq,
                        Area = item.Area,
                        Categoria_Codigo = item.Categoria_Codigo,
                        Categoria_Nome = item.Categoria_Nome,
                        Uso_Codigo = item.Uso_Codigo,
                        Uso_Nome = item.Uso_Nome,
                        Tipo_Codigo = item.Tipo_Codigo,
                        Tipo_Nome = item.Tipo_Nome,
                        Pavimentos = item.Pavimentos,
                        Numero_Processo = item.Numero_Processo,
                        Data_Processo = item.Data_Processo,
                        Data_Aprovacao = item.Data_Aprovacao,
                        Tipo_Area = item.Tipo_Area
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Testadacondominio> Lista_Testada_Condominio(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from t in db.Testadacondominio where t.Codcond == Codigo orderby t.Numface select t).ToList();
                List<Testadacondominio> Lista = new List<Testadacondominio>();
                foreach (var item in reg) {
                    Testadacondominio Linha = new Testadacondominio {
                        Codcond = item.Codcond,
                        Numface = item.Numface,
                        Areatestada = item.Areatestada
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Condominiounidade> Lista_Unidade_Condominio(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from t in db.CondominioUnidade where t.Cd_codigo == Codigo orderby new { t.Cd_unidade,t.Cd_subunidades } select t).ToList();
                List<Condominiounidade> Lista = new List<Condominiounidade>();
                foreach (var item in reg) {
                    Condominiounidade Linha = new Condominiounidade {
                        Cd_codigo = item.Cd_codigo,
                        Cd_unidade = item.Cd_unidade,
                        Cd_subunidades = item.Cd_subunidades
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<ImovelStruct> Lista_Imovel(ImovelStruct Reg,ImovelStruct OrderByField) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Cadimob
                           join f in db.Facequadra on new { p1 = c.Distrito, p2 = c.Setor, p3 = c.Quadra, p4 = c.Seq } equals new { p1 = f.Coddistrito, p2 = f.Codsetor, p3 = f.Codquadra, p4 = f.Codface } into fc from f in fc.DefaultIfEmpty()
                           join l in db.Logradouro on f.Codlogr equals l.Codlogradouro into fl from l in fl.DefaultIfEmpty()
                           join b in db.Bairro on new { p1 = c.Li_uf, p2 = (short)c.Li_codcidade, p3 = (short)c.Li_codbairro } equals new { p1 = b.Siglauf, p2 = b.Codcidade, p3 = b.Codbairro } into cb from b in cb.DefaultIfEmpty()
                           join o in db.Condominio on c.Codcondominio equals o.Cd_codigo into co from o in co.DefaultIfEmpty()
                           join p in db.Proprietario on c.Codreduzido equals p.Codreduzido into pc from p in pc.DefaultIfEmpty()
                           join i in db.Cidadao on p.Codcidadao equals i.Codcidadao into ip from i in ip.DefaultIfEmpty()
                           select new ImovelStruct {
                               Codigo = c.Codreduzido, Distrito = c.Distrito, Setor = c.Setor, Quadra = c.Quadra, Lote = c.Lote, Seq = c.Seq, Unidade = c.Unidade,
                               SubUnidade = c.Subunidade, Proprietario_Codigo = p.Codcidadao, Proprietario_Nome = i.Nomecidadao, Proprietario_Principal = p.Principal, CodigoLogradouro = f.Codlogr,
                               NomeLogradouro = l.Endereco, Numero = c.Li_num, CodigoCondominio = c.Codcondominio, NomeCondominio = o.Cd_nomecond,CodigoBairro=c.Li_codbairro,NomeBairro=b.Descbairro,
                               Complemento=c.Li_compl
                           });
                if (Reg.Codigo > 0)
                    Sql = Sql.Where(c => c.Codigo == Reg.Codigo);
                if (Reg.Proprietario_Codigo > 0)
                    Sql = Sql.Where(c => c.Proprietario_Codigo == Reg.Proprietario_Codigo);
                if (Convert.ToBoolean(Reg.Proprietario_Principal))
                    Sql = Sql.Where(c => c.Proprietario_Principal == Reg.Proprietario_Principal);
                if (Reg.Distrito > 0)
                    Sql = Sql.Where(c => c.Distrito == Reg.Distrito);
                if (Reg.Setor > 0)
                    Sql = Sql.Where(c => c.Setor == Reg.Setor);
                if (Reg.Quadra > 0)
                    Sql = Sql.Where(c => c.Quadra == Reg.Quadra);
                if (Reg.Lote > 0)
                    Sql = Sql.Where(c => c.Lote == Reg.Lote);
                if (Reg.CodigoCondominio > 0)
                    Sql = Sql.Where(c => c.CodigoCondominio == Reg.CodigoCondominio);
                if (Reg.CodigoLogradouro > 0)
                    Sql = Sql.Where(c => c.CodigoLogradouro == Reg.CodigoLogradouro);
                if (Reg.CodigoBairro > 0)
                    Sql = Sql.Where(c => c.CodigoBairro == Reg.CodigoBairro);
                if (Reg.Numero > 0)
                    Sql = Sql.Where(c => c.Numero == Reg.Numero);

                if (OrderByField.Codigo > 0)
                    Sql = Sql.OrderBy(c => c.Codigo);
                if (!string.IsNullOrWhiteSpace(OrderByField.Inscricao))
                    Sql = Sql.OrderBy(c => c.Inscricao);
                if (!string.IsNullOrWhiteSpace(OrderByField.Proprietario_Nome))
                    Sql = Sql.OrderBy(c => c.Proprietario_Nome);
                if (!string.IsNullOrWhiteSpace(OrderByField.NomeLogradouro))
                    Sql = Sql.OrderBy(c => c.NomeLogradouro);
                if (!string.IsNullOrWhiteSpace(OrderByField.NomeBairro))
                    Sql = Sql.OrderBy(c => c.NomeBairro);
                if (!string.IsNullOrWhiteSpace(OrderByField.NomeCondominio))
                    Sql = Sql.OrderBy(c => c.NomeCondominio);

                List<ImovelStruct> Lista = new List<ImovelStruct>();
                foreach (var item in Sql) {
                    ImovelStruct Linha = new ImovelStruct {
                        Codigo = item.Codigo,
                        Inscricao = item.Distrito.ToString() + "." + item.Setor.ToString("00") + "." + item.Quadra.ToString("0000") + "." + item.Lote.ToString("00000") + "." + item.Seq.ToString("00") + "." + item.Unidade.ToString("00") + "." + item.SubUnidade.ToString("000"),
                        Proprietario_Codigo =item.Proprietario_Codigo,Proprietario_Nome=item.Proprietario_Nome,CodigoLogradouro=item.CodigoLogradouro,NomeLogradouro=item.NomeLogradouro,Numero=item.Numero,NomeCondominio=item.NomeCondominio,
                        CodigoBairro=item.CodigoBairro ,NomeBairro=item.NomeBairro,CodigoCondominio=item.CodigoCondominio,Complemento=item.Complemento,Distrito=item.Distrito,Setor=item.Setor,Quadra=item.Quadra,Lote=item.Lote,Seq=item.Seq,
                        Unidade=item.Unidade,SubUnidade=item.SubUnidade
                    };
                    Lista.Add(Linha);
                }
                return Lista.ToList();
            }
        }

        public Laseriptu Dados_IPTU(int Codigo,int Ano) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from i in db.Laser_iptu where i.Ano == Ano && i.Codreduzido == Codigo select i).FirstOrDefault();
                return Sql;
            }
        }

        public List<Laseriptu> Dados_IPTU(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from i in db.Laser_iptu where i.Codreduzido == Codigo orderby i.Ano select i).ToList();
                return Sql;
            }
        }

        public bool Verifica_Imunidade(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Cadimob Sql = (from c in db.Cadimob where c.Codreduzido == Codigo select c).FirstOrDefault();
                if (Sql.Imune == null)
                    return false;
                else
                    return Convert.ToBoolean(Sql.Imune);
            }
        }

        public List<IsencaoStruct> Lista_Imovel_Isencao(int Codigo,int Ano=0) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Processo_Data processo_Class = new Processo_Data(_connection);
                
                var reg = (from t in db.Isencao where t.Codreduzido == Codigo orderby t.Anoisencao select t).ToList();
                if (Ano > 0)
                    reg = reg.Where(t => t.Anoisencao == Ano).ToList();
                List<IsencaoStruct> Lista = new List<IsencaoStruct>();
                foreach (var item in reg) {
                    IsencaoStruct Linha = new IsencaoStruct {
                        Codreduzido = item.Codreduzido,
                        Anoisencao = item.Anoisencao,
                        Anoproc = item.Anoproc,
                        Codisencao=item.Codisencao,
                        dataaltera=item.dataaltera,
                        dataprocesso= processo_Class.Dados_Processo((short)item.Anoproc,(int)item.Numproc).DataEntrada,
                        Filantropico=item.Filantropico,
                        Motivo=item.Motivo,
                        Numproc=item.Numproc,
                        Numprocesso=item.Numprocesso,
                        Percisencao=item.Percisencao,
                        Periodo=item.Periodo,
                        Userid=item.Userid
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public Exception Inativar_imovel(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Cadimob i= db.Cadimob.First(x => x.Codreduzido == Codigo);
                i.Inativo = true;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public List<HistoricoStruct> Lista_Historico(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from h in db.Historico
                           join u in db.Usuario on h.Userid equals u.Id into hu from u in hu.DefaultIfEmpty()
                           where h.Codreduzido == Codigo orderby h.Seq select new HistoricoStruct {
                               Codigo=Codigo,Data=h.Datahist2,Seq=h.Seq,Descricao=h.Deschist,Usuario_Codigo=(int)h.Userid,Usuario_Nome =u.Nomecompleto
                           }).ToList();
                List<HistoricoStruct> Lista = new List<HistoricoStruct>();
                foreach (var item in reg) {
                    Lista.Add(new HistoricoStruct {
                        Codigo = item.Codigo,
                        Seq = item.Seq,
                        Data = item.Data,
                        Descricao = item.Descricao,
                        Usuario_Codigo = item.Usuario_Codigo,
                        Usuario_Nome = item.Usuario_Nome
                    });
                }
                return Lista;
            }
        }

        public bool Existe_Face_Quadra(int Distrito,int Setor,int Quadra,int Face) {
            bool bRet = false;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var existingReg = db.Facequadra.Count(a => a.Coddistrito == Distrito && a.Codsetor==Setor && a.Codquadra==Quadra && a.Codface==Face);
                if (existingReg != 0) {
                    bRet = true;
                }
            }
            return bRet;
        }

        public int Retorna_Codigo_Disponivel() {
            int maxCod = 0;
            using (GTI_Context db = new GTI_Context(_connection)) {
                maxCod = (from c in db.Cadimob select c.Codreduzido).Max();
                maxCod = Convert.ToInt32(maxCod + 1);
            }
            return maxCod;
        }

        public int Retorna_Codigo_Condominio_Disponivel() {
            int maxCod = 0;
            using (GTI_Context db = new GTI_Context(_connection)) {
                maxCod = (from c in db.Condominio select c.Cd_codigo).Max();
                maxCod = Convert.ToInt32(maxCod + 1);
            }
            return maxCod;
        }

        public Exception Incluir_Imovel(Cadimob reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                object[] Parametros = new object[35];
                Parametros[0] = new SqlParameter { ParameterName = "@Cip", SqlDbType = SqlDbType.Bit, SqlValue = reg.Cip };
                Parametros[1] = new SqlParameter { ParameterName = "@Codcondominio", SqlDbType = SqlDbType.Int, SqlValue = reg.Codcondominio };
                Parametros[2] = new SqlParameter { ParameterName = "@Conjugado", SqlDbType = SqlDbType.Bit, SqlValue = reg.Conjugado };
                Parametros[3] = new SqlParameter { ParameterName = "@Datainclusao", SqlDbType = SqlDbType.SmallDateTime, SqlValue = reg.Datainclusao };
                Parametros[4] = new SqlParameter { ParameterName = "@Dc_qtdeedif", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Dc_qtdeedif };
                Parametros[5] = new SqlParameter { ParameterName = "@Distrito", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Distrito };
                Parametros[6] = new SqlParameter { ParameterName = "@Dt_areaterreno", SqlDbType = SqlDbType.Decimal, SqlValue = reg.Dt_areaterreno };
                Parametros[7] = new SqlParameter { ParameterName = "@Dt_codbenf", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Dt_codbenf };
                Parametros[8] = new SqlParameter { ParameterName = "@Dt_codcategprop", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Dt_codcategprop };
                Parametros[9] = new SqlParameter { ParameterName = "@Dt_codpedol", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Dt_codpedol };
                Parametros[10] = new SqlParameter { ParameterName = "@Dt_codsituacao", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Dt_codsituacao };
                Parametros[11] = new SqlParameter { ParameterName = "@Dt_codtopog", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Dt_codtopog };
                Parametros[12] = new SqlParameter { ParameterName = "@Dt_codusoterreno", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Dt_codusoterreno };
                Parametros[13] = new SqlParameter { ParameterName = "@Dt_fracaoIdeal",  SqlDbType = SqlDbType.Decimal, SqlValue = reg.Dt_fracaoideal };
                Parametros[14] = new SqlParameter { ParameterName = "@EE_tipoend", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Ee_tipoend };
                Parametros[15] = new SqlParameter { ParameterName = "@Imune", SqlDbType = SqlDbType.Bit, SqlValue = reg.Imune };
                Parametros[16] = new SqlParameter { ParameterName = "@Inativo", SqlDbType = SqlDbType.Bit, SqlValue = reg.Inativo };
                Parametros[17] = new SqlParameter { ParameterName = "@Li_cep", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Li_cep };
                Parametros[18] = new SqlParameter { ParameterName = "@Li_codbairro", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Li_codbairro };
                Parametros[19] = new SqlParameter { ParameterName = "@Li_codcidade", SqlDbType = SqlDbType.Int, SqlValue = reg.Li_codcidade };
                Parametros[20] = new SqlParameter { ParameterName = "@Li_compl", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Li_compl };
                Parametros[21] = new SqlParameter { ParameterName = "@Li_lotes", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Li_lotes };
                Parametros[22] = new SqlParameter { ParameterName = "@Li_num", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Li_num };
                Parametros[23] = new SqlParameter { ParameterName = "@Li_quadras", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Li_quadras };
                Parametros[24] = new SqlParameter { ParameterName = "@Li_uf", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Li_uf };
                Parametros[25] = new SqlParameter { ParameterName = "@Lote", SqlDbType = SqlDbType.Int, SqlValue = reg.Lote };
                Parametros[26] = new SqlParameter { ParameterName = "@Nummat", SqlDbType = SqlDbType.Int, SqlValue = reg.Nummat };
                Parametros[27] = new SqlParameter { ParameterName = "@Quadra", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Quadra };
                Parametros[28] = new SqlParameter { ParameterName = "@Resideimovel", SqlDbType = SqlDbType.Bit, SqlValue = reg.Resideimovel };
                Parametros[29] = new SqlParameter { ParameterName = "@Seq", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Seq };
                Parametros[30] = new SqlParameter { ParameterName = "@Setor", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Setor };
                Parametros[31] = new SqlParameter { ParameterName = "@Subunidade", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Subunidade };
                Parametros[32] = new SqlParameter { ParameterName = "@Tipomat", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Tipomat };
                Parametros[33] = new SqlParameter { ParameterName = "@Unidade", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Unidade };
                Parametros[34] = new SqlParameter { ParameterName = "@Codreduzido", SqlDbType = SqlDbType.Int, SqlValue = reg.Codreduzido };

                db.Database.ExecuteSqlCommand("INSERT INTO cadimob(dv,cip,codcondominio,conjugado,datainclusao,dc_qtdeedif,distrito,dt_areaterreno,dt_codbenf,dt_codcategprop,dt_codpedol," +
                    "dt_codsituacao,dt_codtopog,dt_codusoterreno,dt_fracaoideal,ee_tipoend,imune,inativo,li_cep,li_codbairro,li_codcidade,li_compl,li_lotes,li_num,li_quadras,li_uf," +
                    "lote,nummat,quadra,resideimovel,seq,setor,subunidade,tipomat,unidade,codreduzido) VALUES(0,@cip, @codcondominio, @conjugado, @datainclusao, @dc_qtdeedif, @distrito, @dt_areaterreno," +
                    "@dt_codbenf,@dt_codcategprop,@dt_codpedol,@dt_codsituacao,@dt_codtopog,@dt_codusoterreno,@dt_fracaoideal,@ee_tipoend,@imune,@inativo,@li_cep,@li_codbairro,@li_codcidade," +
                    "@li_compl,@li_lotes,@li_num,@li_quadras,@li_uf,@lote,@nummat,@quadra,@resideimovel,@seq,@setor,@subunidade,@tipomat,@unidade,@codreduzido)", Parametros);

                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Incluir_Condominio(Condominio reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                object[] Parametros = new object[26];
                Parametros[0] = new SqlParameter { ParameterName = "@cd_codigo", SqlDbType = SqlDbType.Int, SqlValue = reg.Cd_codigo };
                Parametros[1] = new SqlParameter { ParameterName = "@cd_nomecond", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Cd_nomecond };
                Parametros[2] = new SqlParameter { ParameterName = "@cd_distrito", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Cd_distrito };
                Parametros[3] = new SqlParameter { ParameterName = "@cd_setor", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Cd_setor };
                Parametros[4] = new SqlParameter { ParameterName = "@cd_quadra", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Cd_quadra };
                Parametros[5] = new SqlParameter { ParameterName = "@cd_lote", SqlDbType = SqlDbType.Int, SqlValue = reg.Cd_lote };
                Parametros[6] = new SqlParameter { ParameterName = "@cd_seq", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Cd_seq };
                Parametros[7] = new SqlParameter { ParameterName = "@cd_num", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Cd_num };
                Parametros[8] = new SqlParameter { ParameterName = "@cd_compl", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Cd_compl };
                Parametros[9] = new SqlParameter { ParameterName = "@cd_uf", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Cd_uf };
                Parametros[10] = new SqlParameter { ParameterName = "@cd_codcidade", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Cd_codcidade };
                Parametros[11] = new SqlParameter { ParameterName = "@cd_codbairro", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Cd_codbairro };
                Parametros[12] = new SqlParameter { ParameterName = "@cd_cep", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Cd_cep };
                Parametros[13] = new SqlParameter { ParameterName = "@cd_quadras", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Cd_quadras };
                Parametros[14] = new SqlParameter { ParameterName = "@cd_lotes", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Cd_lotes };
                Parametros[15] = new SqlParameter { ParameterName = "@cd_areaterreno", SqlDbType = SqlDbType.Decimal, SqlValue = reg.Cd_areaterreno };
                Parametros[16] = new SqlParameter { ParameterName = "@cd_codusoterreno", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Cd_codusoterreno };
                Parametros[17] = new SqlParameter { ParameterName = "@cd_codbenf", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Cd_codbenf };
                Parametros[18] = new SqlParameter { ParameterName = "@cd_codtopog", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Cd_codtopog };
                Parametros[19] = new SqlParameter { ParameterName = "@cd_codcategprop", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Cd_codcategprop };
                Parametros[20] = new SqlParameter { ParameterName = "@cd_codsituacao", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Cd_codsituacao };
                Parametros[21] = new SqlParameter { ParameterName = "@cd_codpedol", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Cd_codpedol };
                Parametros[22] = new SqlParameter { ParameterName = "@cd_areatotconstr", SqlDbType = SqlDbType.Decimal, SqlValue = reg.Cd_areatotconstr };
                Parametros[23] = new SqlParameter { ParameterName = "@cd_numunid", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Cd_numunid };
                Parametros[24] = new SqlParameter { ParameterName = "@cd_prop", SqlDbType = SqlDbType.Int, SqlValue = reg.Cd_prop };
                Parametros[25] = new SqlParameter { ParameterName = "@cd_fracao", SqlDbType = SqlDbType.Decimal, SqlValue = reg.Cd_fracao };

                db.Database.ExecuteSqlCommand("INSERT INTO condominio(cd_cogdigo,cd_nomecond,cd_distrito,cd_setor,cd_quadra,cd_lote,cd_seq,cd_num,cd_compl,cd_uf,cd_codcidade," +
                    "cd_codbairro,cd_cep,cd_quadras,cd_lotes,cd_areaterreno,cd_codusoterreno,cd_codbenf,cd_codtopog,cd_codcategprop,cd_codsituacao,cd_codpedol,cd_arratotconstr," +
                    "cd_numunid,cd_prop,cd_fracao) VALUES(@cd_codigo, @cd_nomecond, @cd_distrito, @cd_setor, @cd_quadra, @cd_lote, @cd_seq, @cd_num, @cd_compl,@cd_uf, @cd_codcidade, " +
                    "@cd_codbairro,@cd_cep,@cd_quadras,@cd_lotes,@cd_areaterreno,@cd_codusoterreno,@cd_codbenf,@cd_codtopog,@cd_codcategprop,@cd_codsituacao,@cd_codpedol,@cd_arratotconstr," +
                    "@cd_numunid,@cd_prop,@cd_fracao)", Parametros);

                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_Condominio(Condominio reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Condominio b = db.Condominio.First(i => i.Cd_codigo == reg.Cd_codigo);
                b.Cd_areaterreno = reg.Cd_areaterreno;
                b.Cd_areatotconstr = reg.Cd_areatotconstr;
                b.Cd_cep = reg.Cd_cep;
                b.Cd_codbairro = reg.Cd_codbairro;
                b.Cd_codbenf = reg.Cd_codbenf;
                b.Cd_codcategprop = reg.Cd_codcategprop;
                b.Cd_codcidade = reg.Cd_codcidade;
                b.Cd_codpedol = reg.Cd_codpedol;
                b.Cd_codsituacao = reg.Cd_codsituacao;
                b.Cd_codtopog = reg.Cd_codtopog;
                b.Cd_codusoterreno = reg.Cd_codusoterreno;
                b.Cd_compl = reg.Cd_compl;
                b.Cd_distrito = reg.Cd_distrito;
                b.Cd_fracao = reg.Cd_fracao;
                b.Cd_lote = reg.Cd_lote;
                b.Cd_lotes = reg.Cd_lotes;
                b.Cd_nomecond = reg.Cd_nomecond;
                b.Cd_num = reg.Cd_num;
                b.Cd_numunid = reg.Cd_numunid;
                b.Cd_prop = reg.Cd_prop;
                b.Cd_quadra = reg.Cd_quadra;
                b.Cd_quadras = reg.Cd_quadras;
                b.Cd_seq = reg.Cd_seq;
                b.Cd_setor = reg.Cd_setor;
                b.Cd_uf = reg.Cd_uf;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_Imovel(Cadimob reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Cadimob b = db.Cadimob.First(i => i.Codreduzido == reg.Codreduzido);
                b.Cip = reg.Cip;
                b.Codcondominio = reg.Codcondominio;
                b.Conjugado = reg.Conjugado;
                b.Dc_qtdeedif = reg.Dc_qtdeedif;
                b.Dt_areaterreno = reg.Dt_areaterreno;
                b.Dt_codbenf = reg.Dt_codbenf;
                b.Dt_codcategprop = reg.Dt_codcategprop;
                b.Dt_codpedol = reg.Dt_codpedol;
                b.Dt_codsituacao = reg.Dt_codsituacao;
                b.Dt_codtopog = reg.Dt_codtopog;
                b.Dt_codusoterreno = reg.Dt_codusoterreno;
                b.Dt_fracaoideal = reg.Dt_fracaoideal;
                b.Ee_tipoend = reg.Ee_tipoend;
                b.Imune = reg.Imune;
                b.Inativo = reg.Inativo;
                b.Li_cep = reg.Li_cep;
                b.Li_codbairro = reg.Li_codbairro;
                b.Li_codcidade = reg.Li_codcidade;
                b.Li_compl = reg.Li_compl;
                b.Li_lotes = reg.Li_lotes;
                b.Li_num = reg.Li_num;
                b.Li_quadras = reg.Li_quadras;
                b.Li_uf = reg.Li_uf;
                b.Nummat = reg.Nummat;
                b.Resideimovel = reg.Resideimovel;
                b.Tipomat = reg.Tipomat;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Incluir_Proprietario(List<Proprietario> Lista) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Database.ExecuteSqlCommand("DELETE FROM proprietario WHERE Codreduzido=@Codreduzido",
                        new SqlParameter("@Codreduzido", Lista[0].Codreduzido));
                } catch (Exception ex) {
                    return ex;
                }
                foreach (Proprietario item in Lista) {
                    Proprietario reg = new Proprietario {
                        Codcidadao = item.Codcidadao,
                        Codreduzido = item.Codreduzido,
                        Tipoprop = item.Tipoprop,
                        Principal=item.Principal
                    };
                    db.Proprietario.Add(reg);
                    try {
                        db.SaveChanges();
                    } catch (Exception ex) {
                        return ex;
                    }
                }
                return null;
            }
        }

        public Exception Incluir_Testada(List<Testada> testadas) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Database.ExecuteSqlCommand("DELETE FROM TESTADA WHERE Codreduzido=@Codreduzido",
                        new SqlParameter("@Codreduzido", testadas[0].Codreduzido));
                } catch (Exception ex) {
                    return ex;
                }
                foreach (Testada item in testadas) {
                    Testada reg = new Testada {
                        Codreduzido = item.Codreduzido,
                        Numface = item.Numface,
                        Areatestada = item.Areatestada
                    };
                    db.Testada.Add(reg);
                    try {
                        db.SaveChanges();
                    } catch (Exception ex) {
                        return ex;
                    }
                }
                return null;
            }
        }

        public Exception Incluir_Testada_Condominio(List<Testadacondominio> testadas) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Database.ExecuteSqlCommand("DELETE FROM TESTADACONDOMINIO WHERE CODCOND=@Codreduzido",
                        new SqlParameter("@Codreduzido", testadas[0].Codcond));
                } catch (Exception ex) {
                    return ex;
                }
                foreach (Testadacondominio item in testadas) {
                    Testadacondominio reg = new Testadacondominio {
                        Codcond = item.Codcond,
                        Numface = item.Numface,
                        Areatestada = item.Areatestada
                    };
                    db.Testadacondominio.Add(reg);
                    try {
                        db.SaveChanges();
                    } catch (Exception ex) {
                        return ex;
                    }
                }
                return null;
            }
        }

        public Exception Incluir_Historico(List<Historico> historicos) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Database.ExecuteSqlCommand("DELETE FROM HISTORICO WHERE Codreduzido=@Codreduzido",
                        new SqlParameter("@Codreduzido", historicos[0].Codreduzido));
                } catch (Exception ex) {
                    return ex;
                }
                foreach (Historico item in historicos) {
                    Historico reg = new Historico {
                        Codreduzido = item.Codreduzido,
                        Seq = item.Seq,
                        Datahist2 = item.Datahist2,
                        Deschist=item.Deschist,
                        Userid=item.Userid
                    };
                    db.Historico.Add(reg);
                    try {
                        db.SaveChanges();
                    } catch (Exception ex) {
                        return ex;
                    }
                }
                return null;
            }
        }

        public Exception Incluir_Area(List<Areas> areas) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Database.ExecuteSqlCommand("DELETE FROM AREAS WHERE Codreduzido=@Codreduzido",
                        new SqlParameter("@Codreduzido", areas[0].Codreduzido));
                } catch (Exception ex) {
                    return ex;
                }
                foreach (Areas item in areas) {
                    Areas reg = new Areas {
                        Codreduzido = item.Codreduzido,
                        Areaconstr = item.Areaconstr,
                        Catconstr = item.Catconstr,
                        Dataaprova = item.Dataaprova,
                        Numprocesso = item.Numprocesso,
                        Qtdepav=item.Qtdepav,
                        Seqarea=item.Seqarea,
                        Tipoarea=item.Tipoarea,
                        Tipoconstr=item.Tipoconstr,
                        Usoconstr=item.Usoconstr
                    };
                    db.Areas.Add(reg);
                    try {
                        db.SaveChanges();
                    } catch (Exception ex) {
                        return ex;
                    }
                }
                return null;
            }
        }

        public Exception Incluir_Area_Condominio(List<Condominioarea> areas) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Database.ExecuteSqlCommand("DELETE FROM Condominioarea WHERE Codcondominio=@Codreduzido",
                        new SqlParameter("@Codreduzido", areas[0].Codcondominio));
                } catch (Exception ex) {
                    return ex;
                }
                foreach (Condominioarea item in areas) {
                    Condominioarea reg = new Condominioarea {
                        Codcondominio = item.Codcondominio,
                        Areaconstr = item.Areaconstr,
                        Catconstr = item.Catconstr,
                        Dataaprova = item.Dataaprova,
                        Numprocesso = item.Numprocesso,
                        Qtdepav = item.Qtdepav,
                        Seqarea = item.Seqarea,
                        Tipoarea = item.Tipoarea,
                        Tipoconstr = item.Tipoconstr,
                        Usoconstr = item.Usoconstr
                    };
                    db.CondominioArea.Add(reg);
                    try {
                        db.SaveChanges();
                    } catch (Exception ex) {
                        return ex;
                    }
                }
                return null;
            }
        }

        public Exception Incluir_Unidade_Condominio(List<Condominiounidade> unidades) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Database.ExecuteSqlCommand("DELETE FROM Condominiounidade WHERE Cd_codigo=@Codreduzido",
                        new SqlParameter("@Codreduzido", unidades[0].Cd_codigo));
                } catch (Exception ex) {
                    return ex;
                }
                foreach (Condominiounidade item in unidades) {
                    Condominiounidade reg = new Condominiounidade {
                        Cd_codigo = item.Cd_codigo,
                        Cd_unidade = item.Cd_unidade,
                        Cd_subunidades = item.Cd_subunidades
                    };
                    db.CondominioUnidade.Add(reg);
                    try {
                        db.SaveChanges();
                    } catch (Exception ex) {
                        return ex;
                    }
                }
                return null;
            }
        }

        public List<int> Lista_Comunicado_Isencao() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                DateTime _data_alteracao = Convert.ToDateTime("21/10/2018");
                List<int>Codigos = (from t in db.Isencao where t.dataaltera > _data_alteracao orderby t.Codreduzido select t.Codreduzido).Distinct().ToList();
                return Codigos;
            }
        }

        public Exception Insert_Comunicado_Isencao(Comunicado_isencao Reg) {
            using (var db = new GTI_Context(_connection)) {
                object[] Parametros = new object[17];
                Parametros[0] = new SqlParameter { ParameterName = "@remessa", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Remessa };
                Parametros[1] = new SqlParameter { ParameterName = "@codigo", SqlDbType = SqlDbType.Int, SqlValue = Reg.Codigo };
                Parametros[2] = new SqlParameter { ParameterName = "@nome", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Nome };
                Parametros[3] = new SqlParameter { ParameterName = "@cpf_cnpj", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cpf_cnpj };
                Parametros[4] = new SqlParameter { ParameterName = "@endereco", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Endereco };
                Parametros[5] = new SqlParameter { ParameterName = "@bairro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Bairro };
                Parametros[6] = new SqlParameter { ParameterName = "@cidade", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cidade };
                Parametros[7] = new SqlParameter { ParameterName = "@cep", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cep };
                Parametros[8] = new SqlParameter { ParameterName = "@endereco_entrega", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Endereco_entrega };
                Parametros[9] = new SqlParameter { ParameterName = "@bairro_entrega", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Bairro_entrega };
                Parametros[10] = new SqlParameter { ParameterName = "@cidade_entrega", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cidade_entrega };
                Parametros[11] = new SqlParameter { ParameterName = "@cep_entrega", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cep_entrega };
                Parametros[12] = new SqlParameter { ParameterName = "@data_documento", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Data_documento };
                Parametros[13] = new SqlParameter { ParameterName = "@inscricao", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Inscricao };
                Parametros[14] = new SqlParameter { ParameterName = "@lote", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Lote };
                Parametros[15] = new SqlParameter { ParameterName = "@quadra", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Quadra };
                Parametros[16] = new SqlParameter { ParameterName = "@Cep_entrega_cod", SqlDbType = SqlDbType.Int, SqlValue = Reg.Cep_entrega_cod };

                db.Database.ExecuteSqlCommand("INSERT INTO comunicado_isencao(remessa,codigo,nome,cpf_cnpj,endereco,bairro,cidade,cep,endereco_entrega,bairro_entrega,cidade_entrega,cep_entrega," +
                    "data_documento,inscricao,lote,quadra,Cep_entrega_cod) VALUES(@remessa,@codigo,@nome,@cpf_cnpj,@endereco,@bairro,@cidade,@cep,@endereco_entrega,@bairro_entrega,@cidade_entrega," +
                    "@cep_entrega,@data_documento,@inscricao,@lote,@quadra,@Cep_entrega_cod)", Parametros);

                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public List<Foto_imovel> Lista_Foto_Imovel(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection))
            {
                return (from f in db.Foto_imovel where f.Codigo == Codigo select f).ToList();
            }
        }


    }//end class
}
