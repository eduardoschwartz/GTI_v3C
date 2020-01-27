using GTI_Dal;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using static GTI_Models.modelCore;

namespace GTI_Dal.Classes {
    public class Sistema_Data {

        private static string _connection;
        public Sistema_Data(string sConnection) {
            _connection = sConnection;
        }

        public List<int> Lista_Codigos_Documento(string Documento,TipoDocumento _tipo) {
            List<int> _lista = new List<int>();
            using (GTI_Context db = new GTI_Context(_connection)) {
                string _doc = dalCore.RetornaNumero(Documento);

                List<int> _codigos;
                //procura imóvel
                if (_tipo == TipoDocumento.Cpf) {
                    //_codigos = (from i in db.Cadimob join p in db.Proprietario on i.Codreduzido equals p.Codreduzido join c in db.Cidadao on p.Codcidadao equals c.Codcidadao
                    //           where p.Tipoprop == "P" && p.Principal == true && c.Cpf.Contains(_doc) select i.Codreduzido).ToList();
                    _codigos = (from i in db.Cadimob join p in db.Proprietario on i.Codreduzido equals p.Codreduzido join c in db.Cidadao on p.Codcidadao equals c.Codcidadao
                                where  c.Cpf.Contains(_doc) select i.Codreduzido).ToList();
                } else {
                    //_codigos = (from i in db.Cadimob join p in db.Proprietario on i.Codreduzido equals p.Codreduzido join c in db.Cidadao on p.Codcidadao equals c.Codcidadao
                    //           where p.Tipoprop == "P" && p.Principal == true && c.Cnpj.Contains(_doc) select i.Codreduzido).ToList();
                    _codigos = (from i in db.Cadimob join p in db.Proprietario on i.Codreduzido equals p.Codreduzido join c in db.Cidadao on p.Codcidadao equals c.Codcidadao
                                where  c.Cnpj.Contains(_doc) select i.Codreduzido).ToList();
                }
                foreach (int item in _codigos) {
                    _lista.Add(item);
                }

                _codigos.Clear();
                //procura empresa
                if (_tipo == TipoDocumento.Cpf) {
                    _codigos = (from m in db.Mobiliario where m.Cpf.Contains(_doc) select m.Codigomob).ToList();
                } else {
                    _codigos = (from m in db.Mobiliario where m.Cnpj.Contains(_doc) select m.Codigomob).ToList();
                }
                foreach (int item in _codigos) {
                    _lista.Add(item);
                }

                _codigos.Clear();
                //procura cidadão
                if (_tipo == TipoDocumento.Cpf) {
                    _codigos = (from c in db.Cidadao where  c.Codcidadao>=500000 && c.Codcidadao<700000 &&  c.Cpf.Contains(_doc) select c.Codcidadao).ToList();
                } else {
                    _codigos = (from c in db.Cidadao where c.Codcidadao >= 500000 && c.Codcidadao < 700000 && c.Cnpj.Contains(_doc) select c.Codcidadao).ToList();
                }
                foreach (int item in _codigos) {
                    _lista.Add(item);
                }

            }

            return _lista;
        }


        public string Nome_por_Cpf(string cpf) {
            string _nome = "";

            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Cidadao where c.Cpf == cpf select c.Nomecidadao).FirstOrDefault();
                if (Sql != null) {
                    _nome = Sql.ToString();
                } else {
                    var Sql2 = (from m in db.Mobiliario where m.Cpf == cpf select m.Razaosocial).FirstOrDefault();
                    if (Sql2 != null)
                        _nome = Sql2.ToString();
                }
            }
            return _nome;
        }

        public string Nome_por_Cnpj(string cnpj) {
            string _nome = "";

            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Cidadao where c.Cnpj == cnpj select c.Nomecidadao).FirstOrDefault();
                if (Sql != null) {
                    _nome = Sql.ToString();
                } else {
                    var Sql2 = (from m in db.Mobiliario where m.Cnpj == cnpj select m.Razaosocial).FirstOrDefault();
                    if (Sql2 != null)
                        _nome = Sql2.ToString();
                }
            }
            return _nome;
        }

        public Contribuinte_Header_Struct Contribuinte_Header(int _codigo,bool _principal = false) {
            string _nome = "", _inscricao = "", _endereco = "", _complemento = "", _bairro = "", _cidade = "", _uf = "", _cep = "", _quadra = "", _lote = "";
            string _endereco_entrega = "", _complemento_entrega = "", _bairro_entrega = "", _cidade_entrega = "", _uf_entrega = "", _cep_entrega = "";
            string _cpf_cnpj = "",_atividade="",_rg="",_endereco_abreviado="",_endereco_entrega_abreviado="";
            int _numero = 0, _numero_entrega = 0;
            GTI_Models.modelCore.TipoEndereco _tipo_end = GTI_Models.modelCore.TipoEndereco.Local;
            bool _ativo = false;
            TipoCadastro _tipo_cadastro;
            _tipo_cadastro = _codigo < 100000 ? TipoCadastro.Imovel : (_codigo >= 100000 && _codigo < 500000) ? TipoCadastro.Empresa : TipoCadastro.Cidadao;

            if (_tipo_cadastro == TipoCadastro.Imovel) {
                Imovel_Data imovel_Class = new Imovel_Data(_connection);
                ImovelStruct _imovel = imovel_Class.Dados_Imovel(_codigo);
                List<ProprietarioStruct> _proprietario = imovel_Class.Lista_Proprietario(_codigo, _principal);
                _nome = _proprietario[0].Nome;
                _cpf_cnpj = _proprietario[0].CPF;
                _rg = _proprietario[0].RG;
                _inscricao = _imovel.Inscricao;
                _endereco = _imovel.NomeLogradouro;
                _endereco_abreviado = _imovel.NomeLogradouroAbreviado;
                _numero = (int)_imovel.Numero;
                _complemento = _imovel.Complemento;
                _bairro = _imovel.NomeBairro;
                _cidade = "JABOTICABAL";
                _uf = "SP";
                _ativo = (bool)_imovel.Inativo ? false : true;
                _lote = _imovel.LoteOriginal;
                _quadra = _imovel.QuadraOriginal;
                Endereco_Data endereco_Class = new Endereco_Data(_connection);
                _cep = endereco_Class.RetornaCep((int)_imovel.CodigoLogradouro,(short) _imovel.Numero).ToString();
                //Carrega Endereço de Entrega do imóvel
                _tipo_end = _imovel.EE_TipoEndereco == 0 ? GTI_Models.modelCore.TipoEndereco.Local : _imovel.EE_TipoEndereco == 1 ? GTI_Models.modelCore.TipoEndereco.Proprietario : GTI_Models.modelCore.TipoEndereco.Entrega;
                EnderecoStruct regEntrega = imovel_Class.Dados_Endereco(_codigo, _tipo_end);
                if (regEntrega != null) {
                    _endereco_entrega = regEntrega.Endereco??"";
                    _endereco_entrega_abreviado = regEntrega.Endereco_Abreviado??"";
                    _numero_entrega = (int)regEntrega.Numero;
                    _complemento_entrega = regEntrega.Complemento??"";
                    _uf_entrega = regEntrega.UF.ToString();
                    _cidade_entrega = regEntrega.NomeCidade.ToString();
                    _bairro_entrega = regEntrega.NomeBairro??"";
                    _cep_entrega = regEntrega.Cep == null ? "00000-000" : Convert.ToInt32(regEntrega.Cep.ToString()).ToString("00000-000");
                }
            } else {
                if (_tipo_cadastro == TipoCadastro.Empresa) {
                    Empresa_Data empresa_Class = new Empresa_Data(_connection);
                    EmpresaStruct _empresa = empresa_Class.Retorna_Empresa(_codigo);
                    _nome = _empresa.Razao_social;
                    _inscricao = _codigo.ToString();
                    _rg = string.IsNullOrWhiteSpace( _empresa.Inscricao_estadual)?_empresa.Rg:_empresa.Inscricao_estadual;
                    _cpf_cnpj = _empresa.Cpf_cnpj;
                    _endereco = _empresa.Endereco_nome;
                    _endereco_abreviado = _empresa.Endereco_nome_abreviado;
                    _numero = _empresa.Numero==null?0:(int)_empresa.Numero;
                    _complemento = _empresa.Complemento;
                    _bairro = _empresa.Bairro_nome;
                    _cidade = _empresa.Cidade_nome;
                    _uf = _empresa.UF;
                    _cep = _empresa.Cep;
                    _ativo = _empresa.Data_Encerramento == null ? true : false;
                    _atividade = _empresa.Atividade_extenso;

                    //Carrega Endereço de Entrega da Empresa
                    mobiliarioendentrega regEntrega = empresa_Class.Empresa_Endereco_entrega(_codigo);
                    if (regEntrega.Nomelogradouro == null) {
                        _endereco_entrega = _endereco;
                        _numero_entrega = _numero;
                        _complemento_entrega = _complemento;
                        _uf_entrega = _uf;
                        _cidade_entrega = _cidade;
                        _bairro_entrega = _bairro;
                        _cep_entrega = _cep;
                    } else {
                        _endereco_entrega = regEntrega.Nomelogradouro ?? "";
                        _numero_entrega = (int)regEntrega.Numimovel;
                        _complemento_entrega = regEntrega.Complemento ?? "";
                        _uf_entrega = regEntrega.Uf ?? "";
                        _cidade_entrega = regEntrega.Desccidade;
                        _bairro_entrega = regEntrega.Descbairro;
                        _cep_entrega = regEntrega.Cep == null ? "00000-000" : Convert.ToInt32(dalCore.RetornaNumero(regEntrega.Cep).ToString()).ToString("00000-000");
                    }
                } else {
                    Cidadao_Data cidadao_Class = new Cidadao_Data(_connection);
                    CidadaoStruct _cidadao = cidadao_Class.Dados_Cidadao(_codigo);
                    _nome = _cidadao.Nome;
                    _inscricao = _codigo.ToString();
                    _cpf_cnpj = _cidadao.Cpf;
                    _rg = _cidadao.Rg;
                    _ativo = true;
                    if (_cidadao.EtiquetaC == "S") {
                        if (_cidadao.CodigoCidadeC == 413) {
                            _endereco = _cidadao.EnderecoC.ToString();
                            Endereco_Data endereco_Class = new Endereco_Data(_connection);
                            if (_cidadao.NumeroC == null || _cidadao.NumeroC == 0 || _cidadao.CodigoLogradouroC == null || _cidadao.CodigoLogradouroC == 0)
                                _cep = "14870000";
                            else
                                _cep = endereco_Class.RetornaCep((int)_cidadao.CodigoLogradouroC, Convert.ToInt16(_cidadao.NumeroC)).ToString("00000000");
                        } else {
                            _endereco = _cidadao.CodigoCidadeC.ToString();
                            _cep = _cidadao.CepC.ToString();
                        }
                        _numero = (int)_cidadao.NumeroC;
                        _complemento = _cidadao.ComplementoC;
                        _bairro = _cidadao.NomeBairroC;
                        _cidade = _cidadao.NomeCidadeC;
                        _uf = _cidadao.UfC;
                    } else {
                        if (_cidadao.CodigoCidadeR == 413) {
                            _endereco = _cidadao.EnderecoR??""                            ;
                            Endereco_Data endereco_Class = new Endereco_Data(_connection);
                            if (_cidadao.NumeroR == null || _cidadao.NumeroR == 0 || _cidadao.CodigoLogradouroR == null || _cidadao.CodigoLogradouroR == 0)
                                _cep = "14870000";
                            else
                                _cep = endereco_Class.RetornaCep((int)_cidadao.CodigoLogradouroR, Convert.ToInt16(_cidadao.NumeroR)).ToString("00000000");
                        } else {
                            _endereco = _cidadao.CodigoCidadeR.ToString();
                            _cep = _cidadao.CepR.ToString();
                        }
                        _numero =  _cidadao.NumeroR==null?0: (int)_cidadao.NumeroR;
                        _complemento = _cidadao.ComplementoR;
                        _bairro = _cidadao.NomeBairroR;
                        _cidade = _cidadao.NomeCidadeR;
                        _uf = _cidadao.UfR;
                    }
                    _endereco_abreviado = _endereco;
                    _endereco_entrega = _endereco;
                    _numero_entrega = _numero;
                    _complemento_entrega = _complemento;
                    _uf_entrega = _uf;
                    _cidade_entrega = _cidade;
                    _bairro_entrega = _bairro;
                    _cep_entrega = _cep;
                }
            }

            Contribuinte_Header_Struct reg = new Contribuinte_Header_Struct {
                Codigo = _codigo,
                Tipo = _tipo_cadastro,
                TipoEndereco=_tipo_end,
                Nome=_nome,
                Inscricao=_inscricao,
                Inscricao_Estadual=_inscricao,
                Cpf_cnpj=_cpf_cnpj,
                Endereco=_endereco,
                Endereco_abreviado=_endereco_abreviado,
                Endereco_entrega=_endereco_entrega,
                Endereco_entrega_abreviado=_endereco_entrega_abreviado,
                Numero=(short)_numero,
                Numero_entrega=(short)_numero_entrega,
                Complemento=_complemento,
                Complemento_entrega=_complemento_entrega,
                Nome_bairro=_bairro,
                Nome_bairro_entrega=_bairro_entrega,
                Nome_cidade=_cidade,
                Nome_cidade_entrega=_cidade_entrega,
                Nome_uf=_uf,
                Nome_uf_entrega=_uf_entrega,
                Cep=_cep,
                Cep_entrega=_cep_entrega,
                Ativo=_ativo,
                Lote_original=_lote,
                Quadra_original=_quadra,
                Atividade=_atividade
            };

            return reg;
        }

        public TipoCadastro Tipo_Cadastro(int Codigo) {
            TipoCadastro _tipo_cadastro;
            if (Codigo < 100000)
                _tipo_cadastro = TipoCadastro.Imovel;
            else {
                if (Codigo >= 100000 && Codigo < 500000)
                    _tipo_cadastro = TipoCadastro.Empresa;
                else
                    _tipo_cadastro = TipoCadastro.Cidadao;
            }
            return _tipo_cadastro;
        }

        public int Retorna_Ultima_Remessa_Cobranca() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Parametros where c.Nomeparam=="COBRANCA" select c.Valparam).FirstOrDefault();
                return Convert.ToInt32(Sql);
            }
        }

        public Exception Atualiza_Codigo_Remessa_Cobranca( ) {
            Parametros p = null;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var _sql = (from c in db.Parametros where c.Nomeparam == "COBRANCA" select c.Valparam).FirstOrDefault();
                int _valor = Convert.ToInt32(_sql) + 1;

                p = db.Parametros.First(i => i.Nomeparam == "COBRANCA");
                p.Valparam = _valor.ToString();
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        #region Security

        public Exception Alterar_Senha(Usuario reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                string sLogin = reg.Nomelogin;
                Usuario b = db.Usuario.First(i => i.Nomelogin == sLogin);
                b.Senha2 = reg.Senha2;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public int? Retorna_Ultimo_Codigo_Usuario() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Usuario orderby c.Id descending select c.Id).FirstOrDefault();
                return Sql;
            }
        }

        public string Retorna_User_FullName(string loginName) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                string Sql = (from u in db.Usuario where u.Nomelogin == loginName select u.Nomecompleto).FirstOrDefault();
                return Sql;
            }
        }

        public string Retorna_User_FullName(int idUser) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                string Sql = (from u in db.Usuario where u.Id == idUser select u.Nomecompleto).FirstOrDefault();
                return Sql;
            }
        }

        public string Retorna_User_LoginName(string fullName) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                string Sql = (from u in db.Usuario where u.Nomecompleto == fullName select u.Nomelogin).FirstOrDefault();
                return Sql;
            }
        }

        public string Retorna_User_LoginName(int idUser) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                string Sql = (from u in db.Usuario where u.Id == idUser select u.Nomelogin).FirstOrDefault();
                return Sql;
            }
        }

        public int Retorna_User_LoginId(string loginName) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int Sql = (from u in db.Usuario where u.Nomelogin == loginName select (int)u.Id).FirstOrDefault();
                return Sql;
            }
        }

        public string Retorna_User_Password(string login) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                string Sql = (from u in db.Usuario where u.Nomelogin == login select u.Senha2).FirstOrDefault();
                return Sql;
            }
        }

        public List<security_event> Lista_Sec_Eventos() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from t in db.Security_event orderby t.Id select t).ToList();
                List<security_event> Lista = new List<security_event>();
                foreach (var item in reg) {
                    security_event Linha = new security_event { Id = item.Id, IdMaster = item.IdMaster, Descricao = item.Descricao };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public int GetSizeofBinary (){
            using (GTI_Context db = new GTI_Context(_connection)) {
                int nSize = (from t in db.Security_event orderby t.Id descending select t.Id).FirstOrDefault();
                return nSize;
            }
        }

        public string GetUserBinary(int id) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                string Sql = (from u in db.Usuario where u.Id == id select u.Userbinary).FirstOrDefault();
                if (Sql == null) {
                    Sql = "0";
                    int nSize = GetSizeofBinary();
                    int nDif = nSize - Sql.Length;
                    string sZero = new string('0', nDif);
                    Sql += sZero;
                    return dalCore.Encrypt(Sql);
                }
                    return Sql;
            }
        }

        public List<usuarioStruct> Lista_Usuarios() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from t in db.Usuario
                           join cc in db.Centrocusto on t.Setor_atual equals cc.Codigo into tcc from cc in tcc.DefaultIfEmpty()
                           where t.Ativo == 1
                           orderby t.Nomecompleto select new { t.Nomelogin, t.Nomecompleto, t.Ativo, t.Id, t.Senha, t.Setor_atual, cc.Descricao }).ToList();
                List<usuarioStruct> Lista = new List<usuarioStruct>();
                foreach (var item in reg) {
                    usuarioStruct Linha = new usuarioStruct {
                        Nome_login = item.Nomelogin,
                        Nome_completo = item.Nomecompleto,
                        Ativo = item.Ativo,
                        Id=item.Id,
                        Senha=item.Senha,
                        Setor_atual=item.Setor_atual,
                        Nome_setor=item.Descricao
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public Exception Incluir_Usuario(Usuario reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    List<SqlParameter> parameters = new List<SqlParameter> {
                        new SqlParameter("@id", reg.Id),
                        new SqlParameter("@nomelogin", reg.Nomelogin),
                        new SqlParameter("@nomecompleto", reg.Nomecompleto),
                        new SqlParameter("@setor_atual", reg.Setor_atual)
                    };

                    db.Database.ExecuteSqlCommand("INSERT INTO usuario2(id,nomelogin,nomecompleto,ativo,setor_atual)" +
                                                  " VALUES(@id,@nomelogin,@nomecompleto,@ativo,@setor_atual)",parameters.ToArray());
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            } 
        }

        public Exception Alterar_Usuario(Usuario reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Usuario b = db.Usuario.First(i => i.Id == reg.Id);
                b.Nomecompleto = reg.Nomecompleto;
                b.Nomelogin = reg.Nomelogin;
                b.Setor_atual = reg.Setor_atual;
                b.Ativo = reg.Ativo;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_Usuario_Local(List<Usuariocc> reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                db.Database.ExecuteSqlCommand("DELETE FROM usuariocc WHERE userid=@id" ,new SqlParameter("@id", reg[0].Userid));

                List<SqlParameter> parameters = new List<SqlParameter>();
                foreach (Usuariocc item in reg) {
                    try {
                        parameters.Add(new SqlParameter("@Userid", item.Userid));
                        parameters.Add(new SqlParameter("@Codigocc", item.Codigocc));

                        db.Database.ExecuteSqlCommand("INSERT INTO usuariocc(userid,codigocc) VALUES(@Userid,@Codigocc)", parameters.ToArray());
                        parameters.Clear();
                    } catch (Exception ex) {
                        return ex;
                    }
                }
                return null;
            }
        }

        public usuarioStruct Retorna_Usuario(int Id) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from t in db.Usuario
                           join cc in db.Centrocusto on t.Setor_atual equals cc.Codigo into tcc from cc in tcc.DefaultIfEmpty()
                           where t.Id==Id
                           orderby t.Nomelogin select new usuarioStruct {Nome_login= t.Nomelogin,  Nome_completo=t.Nomecompleto,Ativo= t.Ativo,
                               Id=  t.Id, Senha= t.Senha,Senha2= t.Senha2, Setor_atual= t.Setor_atual, Nome_setor= cc.Descricao }).FirstOrDefault();
                usuarioStruct Sql = new usuarioStruct {
                    Id = reg.Id,
                    Nome_completo = reg.Nome_completo,
                    Nome_login = reg.Nome_login,
                    Senha = reg.Senha,
                    Senha2=reg.Senha2,
                    Setor_atual = reg.Setor_atual,
                    Nome_setor = reg.Nome_setor,
                    Ativo = reg.Ativo
                };
                return Sql;
            }
        }

        public List<Usuariocc> Lista_Usuario_Local(int Id) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from cc in db.Usuariocc where cc.Userid == Id orderby cc.Codigocc select cc).ToList();
                return reg;
            }
        }

        public Exception SaveUserBinary(Usuario reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int nId = (int)reg.Id;
                Usuario b = db.Usuario.First(i => i.Id == nId);
                b.Userbinary = reg.Userbinary;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }
        #endregion

        public Exception Incluir_LogEvento(Logevento reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int nMax = (from c in db.Logevento select c.Seq).Max();
                nMax += 1;

                try {
                    List<SqlParameter> parameters = new List<SqlParameter> {
                        new SqlParameter("@seq", nMax),
                        new SqlParameter("@datahoraevento", reg.Datahoraevento),
                        new SqlParameter("@computador", reg.Computador),
                        new SqlParameter("@form", reg.Form),
                        new SqlParameter("@evento", reg.Evento),
                        new SqlParameter("@secevento", reg.Secevento),
                        new SqlParameter("@logevento", reg.LogEvento),
                        new SqlParameter("@userid", reg.Userid)
                    };

                    db.Database.ExecuteSqlCommand("INSERT INTO logevento(seq,datahoraevento,computador,form,evento,secevento,logevento,userid)" +
                                                  " VALUES(@seq,@datahoraevento,@computador,@form,@evento,@secevento,@logevento,@userid)", parameters.ToArray());
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public string Retorna_Valor_Parametro(string ParameterName) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                string Sql = (from p in db.Parametros where p.Nomeparam == ParameterName select p.Valparam).FirstOrDefault();
                return Sql;
            }
        }

    }
}
