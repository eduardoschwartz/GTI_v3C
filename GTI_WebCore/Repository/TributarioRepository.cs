using GTI_WebCore.Interfaces;
using GTI_WebCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GTI_WebCore.Repository {
    public class TributarioRepository : ITributarioRepository {
        private readonly AppDbContext context;

        public TributarioRepository(AppDbContext context) {
            this.context = context;
        }

        public int Retorna_Codigo_Certidao(Functions.TipoCertidao tipo_certidao) {
            int nRet = 0;
                var Sql = (from p in context.Parametros select p);
                if (tipo_certidao == Functions.TipoCertidao.Endereco)
                    Sql = Sql.Where(c => c.Nomeparam == "CETEND");
                else {
                    if (tipo_certidao == Functions.TipoCertidao.ValorVenal)
                        Sql = Sql.Where(c => c.Nomeparam == "CETVVN");
                    else {
                        if (tipo_certidao == Functions.TipoCertidao.Isencao)
                            Sql = Sql.Where(c => c.Nomeparam == "CETISE");
                        else {
                            if (tipo_certidao == Functions.TipoCertidao.Debito)
                                Sql = Sql.Where(c => c.Nomeparam == "CDB");
                            else {
                                if (tipo_certidao == Functions.TipoCertidao.Comprovante_Pagamento)
                                    Sql = Sql.Where(c => c.Nomeparam == "CPAGTO");
                                else {
                                    if (tipo_certidao == Functions.TipoCertidao.Alvara)
                                        Sql = Sql.Where(c => c.Nomeparam == "ALVARA");
                                    else {
                                        if (tipo_certidao == Functions.TipoCertidao.Debito_Doc)
                                            Sql = Sql.Where(c => c.Nomeparam == "CDB_DOC");
                                    }
                                }
                            }
                        }
                    }
                }
                try {
                    foreach (Parametros item in Sql) {
                        nRet = Convert.ToInt32(item.Valparam) + 1;
                        break;
                    }
                } catch (Exception ex2) {

                    throw ex2;
                }
            Exception ex = Atualiza_Codigo_Certidao(tipo_certidao, nRet);
            if (ex == null)
                return nRet;
            else
                return 0;
        }

        public Exception Atualiza_Codigo_Certidao(Functions.TipoCertidao tipo_certidao, int Valor) {
            Parametros p = null;
                if (tipo_certidao == Functions.TipoCertidao.Endereco)
                    p = context.Parametros.First(i => i.Nomeparam == "CETEND");
                else {
                    if (tipo_certidao == Functions.TipoCertidao.ValorVenal)
                        p = context.Parametros.First(i => i.Nomeparam == "CETVVN");
                    else {
                        if (tipo_certidao == Functions.TipoCertidao.Isencao)
                            p = context.Parametros.First(i => i.Nomeparam == "CETISE");
                        else {
                            if (tipo_certidao == Functions.TipoCertidao.Debito)
                                p = context.Parametros.First(i => i.Nomeparam == "CDB");
                            else {
                                if (tipo_certidao == Functions.TipoCertidao.Comprovante_Pagamento)
                                    p = context.Parametros.First(i => i.Nomeparam == "CPAGTO");
                                else {
                                    if (tipo_certidao == Functions.TipoCertidao.Alvara)
                                        p = context.Parametros.First(i => i.Nomeparam == "ALVARA");
                                    else {
                                        if (tipo_certidao == Functions.TipoCertidao.Debito_Doc)
                                            p = context.Parametros.First(i => i.Nomeparam == "CDB_DOC");
                                    }
                                }
                            }
                        }
                    }
                }
                p.Valparam = Valor.ToString();
                try {
                    context.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
        }

        public chaveStruct Valida_Certidao(string Chave) {
            bool _valido = false;
            if (Chave.Trim().Length < 8)
                goto fim;
            else {
                int nPos = Chave.IndexOf("-");
                if (nPos < 6)
                    goto fim;
                else {
                    int nPos2 = Chave.IndexOf("/");
                    if (nPos2 < 5 || nPos - nPos2 < 2)
                        goto fim;
                    else {
                        int nCodigo = Convert.ToInt32(Chave.Substring(nPos2 + 1, nPos - nPos2 - 1));
                        int nAno = Convert.ToInt32(Chave.Substring(nPos2 - 4, 4));
                        int nNumero = Convert.ToInt32(Chave.Substring(0, 5));
                        if (nAno < 2010 || nAno > DateTime.Now.Year + 1)
                            goto fim;
                        else {
                            string sTipo = Chave.Substring(Chave.Length - 2, 2);
                            if (sTipo == "EA") {
                                Certidao_endereco dados = Retorna_Certidao_Endereco(nAno, nNumero, nCodigo);
                                if (dados != null) {
                                    chaveStruct reg = new chaveStruct {
                                        Codigo = nCodigo,
                                        Ano = nAno,
                                        Numero = nNumero,
                                        Tipo = sTipo,
                                        Valido = true
                                    };
                                    return reg;
                                } else
                                    goto fim;
                            } else if (sTipo == "VV") {
                                Certidao_valor_venal dados = Retorna_Certidao_Valor_Venal(nAno, nNumero, nCodigo);
                                if (dados != null) {
                                    chaveStruct reg = new chaveStruct {
                                        Codigo = nCodigo,
                                        Ano = nAno,
                                        Numero = nNumero,
                                        Tipo = sTipo,
                                        Valido = true
                                    };
                                    return reg;
                                } else
                                    goto fim;
                            } else if (sTipo == "CI") {
                                Certidao_isencao dados = Retorna_Certidao_Isencao(nAno, nNumero, nCodigo);
                                if (dados != null) {
                                    chaveStruct reg = new chaveStruct {
                                        Codigo = nCodigo,
                                        Ano = nAno,
                                        Numero = nNumero,
                                        Tipo = sTipo,
                                        Valido = true
                                    };
                                    return reg;
                                }
                            } else if (sTipo == "IE" || sTipo == "XE" || sTipo == "XA") {
                                Certidao_Inscricao dados = Retorna_Certidao_Inscricao(nAno, nNumero);
                                if (dados != null) {
                                    chaveStruct reg = new chaveStruct {
                                        Codigo = nCodigo,
                                        Ano = nAno,
                                        Numero = nNumero,
                                        Tipo = sTipo,
                                        Valido = true
                                    };
                                    return reg;
                                } else
                                    goto fim;
                            }
                        }
                    }
                }
            }
        fim:;
            chaveStruct _reg = new chaveStruct {
                Valido = _valido
            };
            return _reg;
        }

        public Exception Insert_Certidao_Endereco(Certidao_endereco Reg) {

            object[] Parametros = new object[12];
            Parametros[0] = new SqlParameter { ParameterName = "@numero", SqlDbType = SqlDbType.Int, SqlValue = Reg.Numero };
            Parametros[1] = new SqlParameter { ParameterName = "@ano", SqlDbType = SqlDbType.Int, SqlValue = Reg.Ano };
            Parametros[2] = new SqlParameter { ParameterName = "@data", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Data };
            Parametros[3] = new SqlParameter { ParameterName = "@codigo", SqlDbType = SqlDbType.Int, SqlValue = Reg.Codigo };
            Parametros[4] = new SqlParameter { ParameterName = "@nomecidadao", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Nomecidadao };
            Parametros[5] = new SqlParameter { ParameterName = "@inscricao", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Inscricao };
            Parametros[6] = new SqlParameter { ParameterName = "@logradouro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Logradouro };
            Parametros[7] = new SqlParameter { ParameterName = "@li_num", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Li_num };
            Parametros[8] = new SqlParameter { ParameterName = "@li_compl", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Li_compl };
            Parametros[9] = new SqlParameter { ParameterName = "@li_quadras", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Li_quadras };
            Parametros[10] = new SqlParameter { ParameterName = "@li_lotes", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Li_lotes };
            Parametros[11] = new SqlParameter { ParameterName = "@descbairro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.descbairro };

            context.Database.ExecuteSqlCommand("INSERT INTO certidao_endereco(numero,ano,data,codigo,nomecidadao,inscricao,logradouro,li_num,li_compl,li_quadras,li_lotes,descbairro)" +
                " VALUES(@numero,@ano,@data,@codigo,@nomecidadao,@inscricao,@logradouro,@li_num,@li_compl,@li_quadras,@li_lotes,@descbairro)", Parametros);

            try {
                context.SaveChanges();
            } catch (Exception ex) {
                return ex;
            }
            return null;
        }

        public Exception Insert_Certidao_Valor_Venal(Certidao_valor_venal Reg) {

            object[] Parametros = new object[16];
            Parametros[0] = new SqlParameter { ParameterName = "@numero", SqlDbType = SqlDbType.Int, SqlValue = Reg.Numero };
            Parametros[1] = new SqlParameter { ParameterName = "@ano", SqlDbType = SqlDbType.Int, SqlValue = Reg.Ano };
            Parametros[2] = new SqlParameter { ParameterName = "@data", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Data };
            Parametros[3] = new SqlParameter { ParameterName = "@codigo", SqlDbType = SqlDbType.Int, SqlValue = Reg.Codigo };
            Parametros[4] = new SqlParameter { ParameterName = "@nomecidadao", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Nomecidadao };
            Parametros[5] = new SqlParameter { ParameterName = "@inscricao", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Inscricao };
            Parametros[6] = new SqlParameter { ParameterName = "@logradouro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Logradouro };
            Parametros[7] = new SqlParameter { ParameterName = "@li_num", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Li_num };
            Parametros[8] = new SqlParameter { ParameterName = "@li_compl", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Li_compl };
            Parametros[9] = new SqlParameter { ParameterName = "@li_quadras", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Li_quadras };
            Parametros[10] = new SqlParameter { ParameterName = "@li_lotes", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Li_lotes };
            Parametros[11] = new SqlParameter { ParameterName = "@descbairro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Descbairro };
            Parametros[12] = new SqlParameter { ParameterName = "@areaterreno", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Areaterreno };
            Parametros[13] = new SqlParameter { ParameterName = "@vvt", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Vvt };
            Parametros[14] = new SqlParameter { ParameterName = "@vvp", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Vvp };
            Parametros[15] = new SqlParameter { ParameterName = "@vvi", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Vvi };

            context.Database.ExecuteSqlCommand("INSERT INTO certidao_valor_venal(numero,ano,data,codigo,nomecidadao,inscricao,logradouro,li_num,li_compl,li_quadras,li_lotes," +
                "descbairro,areaterreno,vvt,vvp,vvi) VALUES(@numero,@ano,@data,@codigo,@nomecidadao,@inscricao,@logradouro,@li_num,@li_compl,@li_quadras,@li_lotes," +
                "@descbairro,@areaterreno,@vvt,@vvp,@vvi)", Parametros);

            try {
                context.SaveChanges();
            } catch (Exception ex) {
                return ex;
            }
            return null;
        }

        public Exception Insert_Certidao_Isencao(Certidao_isencao Reg) {
            object[] Parametros = new object[16];
            Parametros[0] = new SqlParameter { ParameterName = "@numero", SqlDbType = SqlDbType.Int, SqlValue = Reg.Numero };
            Parametros[1] = new SqlParameter { ParameterName = "@ano", SqlDbType = SqlDbType.Int, SqlValue = Reg.Ano };
            Parametros[2] = new SqlParameter { ParameterName = "@data", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Data };
            Parametros[3] = new SqlParameter { ParameterName = "@codigo", SqlDbType = SqlDbType.Int, SqlValue = Reg.Codigo };
            Parametros[4] = new SqlParameter { ParameterName = "@nomecidadao", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Nomecidadao };
            Parametros[5] = new SqlParameter { ParameterName = "@inscricao", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Inscricao };
            Parametros[6] = new SqlParameter { ParameterName = "@logradouro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Logradouro };
            Parametros[7] = new SqlParameter { ParameterName = "@li_num", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Li_num };
            Parametros[8] = new SqlParameter { ParameterName = "@li_compl", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Li_compl };
            Parametros[9] = new SqlParameter { ParameterName = "@li_quadras", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Li_quadras };
            Parametros[10] = new SqlParameter { ParameterName = "@li_lotes", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Li_lotes };
            Parametros[11] = new SqlParameter { ParameterName = "@descbairro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Descbairro };
            Parametros[12] = new SqlParameter { ParameterName = "@percisencao", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Percisencao };
            Parametros[13] = new SqlParameter { ParameterName = "@Area", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Area };
            Parametros[14] = new SqlParameter { ParameterName = "@numprocesso", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Numprocesso };
            Parametros[15] = new SqlParameter { ParameterName = "@dataprocesso", SqlDbType = SqlDbType.SmallDateTime,IsNullable=true,  SqlValue = DBNull.Value };

            context.Database.ExecuteSqlCommand("INSERT INTO certidao_isencao(numero,ano,data,codigo,nomecidadao,inscricao,logradouro,li_num,li_compl,li_quadras,li_lotes," +
                "descbairro,percisencao,area,numprocesso,dataprocesso) VALUES(@numero,@ano,@data,@codigo,@nomecidadao,@inscricao,@logradouro,@li_num,@li_compl,@li_quadras,@li_lotes," +
                "@descbairro,@percisencao,@area,@numprocesso,@dataprocesso)", Parametros);

            try {
                context.SaveChanges();
            } catch (Exception ex) {
                return ex;
            }
            return null;
        }

        public Exception Insert_Certidao_Inscricao_Extrato(Certidao_Inscricao_Extrato Reg) {
            object[] Parametros = new object[13];
            Parametros[0] = new SqlParameter { ParameterName = "@id", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Id };
            Parametros[1] = new SqlParameter { ParameterName = "@numero_certidao", SqlDbType = SqlDbType.Int, SqlValue = Reg.Numero_certidao };
            Parametros[2] = new SqlParameter { ParameterName = "@ano_certidao", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Ano_certidao };
            Parametros[3] = new SqlParameter { ParameterName = "@codigo", SqlDbType = SqlDbType.Int, SqlValue = Reg.Codigo };
            Parametros[4] = new SqlParameter { ParameterName = "@ano", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Ano };
            Parametros[5] = new SqlParameter { ParameterName = "@lancamento_codigo", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Lancamento_Codigo };
            Parametros[6] = new SqlParameter { ParameterName = "@sequencia", SqlDbType = SqlDbType.TinyInt, SqlValue = Reg.Sequencia };
            Parametros[7] = new SqlParameter { ParameterName = "@parcela", SqlDbType = SqlDbType.TinyInt, SqlValue = Reg.Parcela };
            Parametros[8] = new SqlParameter { ParameterName = "@complemento", SqlDbType = SqlDbType.TinyInt, SqlValue = Reg.Complemento };
            Parametros[9] = new SqlParameter { ParameterName = "@lancamento_descricao", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Lancamento_Descricao };
            Parametros[10] = new SqlParameter { ParameterName = "@data_vencimento", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Data_Vencimento };
            Parametros[11] = new SqlParameter { ParameterName = "@data_pagamento", SqlDbType = SqlDbType.SmallDateTime, IsNullable = true, SqlValue = DBNull.Value };
            Parametros[12] = new SqlParameter { ParameterName = "@valor_pago", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Valor_Pago };

            context.Database.ExecuteSqlCommand("INSERT INTO certidao_inscricao_extrato(id,numero_certidao,ano_certidao,codigo,ano,lancamento_codigo,sequencia,parcela,complemento,lancamento_descricao," +
                "data_vencimento,data_pagamento,valor_pago) VALUES(@id,@numero_certidao,@ano_certidao,@codigo,@ano,@lancamento_codigo,@sequencia,@parcela,@complemento,@lancamento_descricao," +
                "@data_vencimento,@data_pagamento,@valor_pago)", Parametros);

            try {
                context.SaveChanges();
            } catch (Exception ex) {
                return ex;
            }
            return null;
        }

        public Exception Insert_Certidao_Inscricao(Certidao_Inscricao Reg) {
            object[] Parametros = new object[27];
            Parametros[0] = new SqlParameter { ParameterName = "@numero", SqlDbType = SqlDbType.Int, SqlValue = Reg.Numero };
            Parametros[1] = new SqlParameter { ParameterName = "@ano", SqlDbType = SqlDbType.Int, SqlValue = Reg.Ano };
            Parametros[2] = new SqlParameter { ParameterName = "@data_emissao", SqlDbType = SqlDbType.SmallDateTime ,SqlValue=Reg.Data_emissao};
            Parametros[3] = new SqlParameter { ParameterName = "@endereco", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Endereco };
            Parametros[4] = new SqlParameter { ParameterName = "@bairro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Bairro };
            Parametros[5] = new SqlParameter { ParameterName = "@cadastro", SqlDbType = SqlDbType.Int, SqlValue = Reg.Cadastro };
            Parametros[6] = new SqlParameter { ParameterName = "@nome", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Nome };
            Parametros[7] = new SqlParameter { ParameterName = "@rg", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Rg };
            Parametros[8] = new SqlParameter { ParameterName = "@documento", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Documento };
            Parametros[9] = new SqlParameter { ParameterName = "@cidade", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cidade };
            Parametros[10] = new SqlParameter { ParameterName = "@atividade", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Atividade };
            Parametros[11] = new SqlParameter { ParameterName = "@data_abertura", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Data_abertura };
            Parametros[12] = new SqlParameter { ParameterName = "@processo_abertura", SqlDbType = SqlDbType.VarChar,  SqlValue = Reg.Processo_abertura };
            Parametros[13] = new SqlParameter { ParameterName = "@data_encerramento", SqlDbType = SqlDbType.SmallDateTime,  IsNullable = true, SqlValue =Reg.Data_encerramento};
            Parametros[14] = new SqlParameter { ParameterName = "@processo_encerramento", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Processo_encerramento };
            Parametros[15] = new SqlParameter { ParameterName = "@inscricao_estadual", SqlDbType = SqlDbType.VarChar,  SqlValue = Reg.Inscricao_estadual };
            Parametros[16] = new SqlParameter { ParameterName = "@nome_fantasia", SqlDbType = SqlDbType.VarChar,  SqlValue = Reg.Nome_fantasia };
            Parametros[17] = new SqlParameter { ParameterName = "@atividade_secundaria", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Atividade_secundaria };
            Parametros[18] = new SqlParameter { ParameterName = "@complemento", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Complemento };
            Parametros[19] = new SqlParameter { ParameterName = "@cep", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cep };
            Parametros[20] = new SqlParameter { ParameterName = "@situacao", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Situacao };
            Parametros[21] = new SqlParameter { ParameterName = "@telefone", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Telefone };
            Parametros[22] = new SqlParameter { ParameterName = "@email", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Email };
            Parametros[23] = new SqlParameter { ParameterName = "@taxa_licenca", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Taxa_licenca };
            Parametros[24] = new SqlParameter { ParameterName = "@vigilancia_sanitaria", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Vigilancia_sanitaria };
            Parametros[25] = new SqlParameter { ParameterName = "@mei", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Mei };
            Parametros[26] = new SqlParameter { ParameterName = "@area", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Area };

            context.Database.ExecuteSqlCommand("INSERT INTO certidao_inscricao(numero,ano,data_emissao,endereco,bairro,cadastro,nome,rg,documento,cidade,atividade,data_abertura," +
                "processo_abertura,data_encerramento,processo_encerramento,inscricao_estadual,nome_fantasia,atividade_secundaria,complemento,cep,situacao,telefone,email,taxa_licenca," +
                "vigilancia_sanitaria,mei,area) VALUES(@numero,@ano,@data_emissao,@endereco,@bairro,@cadastro,@nome,@rg,@documento,@cidade,@atividade,@data_abertura," +
                "@processo_abertura,@data_encerramento,@processo_encerramento,@inscricao_estadual,@nome_fantasia,@atividade_secundaria,@complemento,@cep,@situacao,@telefone,@email," +
                "@taxa_licenca,@vigilancia_sanitaria,@mei,@area)", Parametros);

            try {
                context.SaveChanges();
            } catch (Exception ex) {
                return ex;
            }
            return null;
        }

        public Exception Insert_Certidao_Debito(Certidao_debito Reg) {
            object[] Parametros = new object[20];
            Parametros[0] = new SqlParameter { ParameterName = "@numero", SqlDbType = SqlDbType.Int, SqlValue = Reg.Numero };
            Parametros[1] = new SqlParameter { ParameterName = "@ano", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Ano };
            Parametros[2] = new SqlParameter { ParameterName = "@ret", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Ret };
            Parametros[3] = new SqlParameter { ParameterName = "@lancamento", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Lancamento };
            Parametros[4] = new SqlParameter { ParameterName = "@suspenso", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Suspenso };
            Parametros[5] = new SqlParameter { ParameterName = "@codigo", SqlDbType = SqlDbType.Int, SqlValue = Reg.Codigo };
            Parametros[6] = new SqlParameter { ParameterName = "@processo", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Processo };
            Parametros[7] = new SqlParameter { ParameterName = "@dataprocesso", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Dataprocesso };
            Parametros[8] = new SqlParameter { ParameterName = "@nome", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Nome };
            Parametros[9] = new SqlParameter { ParameterName = "@logradouro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Logradouro };
            Parametros[10] = new SqlParameter { ParameterName = "@numimovel", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Numimovel };
            Parametros[11] = new SqlParameter { ParameterName = "@cpf", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cpf };
            Parametros[12] = new SqlParameter { ParameterName = "@cnpj", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cnpj };
            Parametros[13] = new SqlParameter { ParameterName = "@bairro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Bairro };
            Parametros[14] = new SqlParameter { ParameterName = "@cidade", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cidade };
            Parametros[15] = new SqlParameter { ParameterName = "@uf", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.UF };
            Parametros[16] = new SqlParameter { ParameterName = "@atendente", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Atendente };
            Parametros[17] = new SqlParameter { ParameterName = "@inscricao", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Inscricao };
            Parametros[18] = new SqlParameter { ParameterName = "@atividade", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Atividade };
            Parametros[19] = new SqlParameter { ParameterName = "@datagravada", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Datagravada };

            context.Database.ExecuteSqlCommand("INSERT INTO certidao_debito(numero,ano,ret,lancamento,suspenso,codigo,processo,dataprocesso,nome,logradouro,numimovel,cpf,cnpj,bairro,cidade,uf,atendente,inscricao,atividade,datagravada)" +
                " VALUES(@numero,@ano,@ret,@lancamento,@suspenso,@codigo,@processo,@dataprocesso,@nome,@logradouro,@numimovel,@cpf,@cnpj,@bairro,@cidade,@uf,@atendente,@inscricao,@atividade,@datagravada)", Parametros);

            try {
                context.SaveChanges();
            } catch (Exception ex) {
                return ex;
            }
            return null;
        }

        public Exception Insert_Certidao_Debito_Doc(Certidao_debito_doc Reg) {
                try {
                    context.Certidao_Debito_Doc.Add(Reg);
                    context.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
        }

        public Certidao_valor_venal Retorna_Certidao_Valor_Venal(int Ano, int Numero, int Codigo) {
            var Sql = (from p in context.Certidao_Valor_Venal where p.Ano == Ano && p.Numero == Numero && p.Codigo == Codigo select p).FirstOrDefault();
            return Sql;
        }

        public Certidao_isencao Retorna_Certidao_Isencao(int Ano, int Numero, int Codigo) {
                var Sql = (from p in context.Certidao_Isencao where p.Ano == Ano && p.Numero == Numero && p.Codigo == Codigo select p).FirstOrDefault();
                return Sql;
        }

        public Certidao_endereco Retorna_Certidao_Endereco(int Ano, int Numero, int Codigo) {
            var Sql = (from p in context.Certidao_Endereco where p.Ano == Ano && p.Numero == Numero && p.Codigo == Codigo select p).FirstOrDefault();
            return Sql;
        }

        public Certidao_Inscricao Retorna_Certidao_Inscricao(int Ano, int Numero) {
            var Sql = (from c in context.Certidao_Inscricao where c.Ano == Ano && c.Numero == Numero select c).FirstOrDefault();
            return Sql;
        }

        public List<SpExtrato> Lista_Extrato_Tributo(int Codigo, short Ano1 = 1990, short Ano2 = 2050, short Lancamento1 = 1, short Lancamento2 = 99, short Sequencia1 = 0, short Sequencia2 = 9999,
    short Parcela1 = 0, short Parcela2 = 999, short Complemento1 = 0, short Complemento2 = 999, short Status1 = 0, short Status2 = 99, DateTime? Data_Atualizacao = null, string Usuario = "") {
                context.Database.SetCommandTimeout(180);
                var prmCod1 = new SqlParameter { ParameterName = "@CodReduz1", SqlDbType = SqlDbType.Int, SqlValue = Codigo };
                var prmCod2 = new SqlParameter { ParameterName = "@CodReduz2", SqlDbType = SqlDbType.Int, SqlValue = Codigo };
                var prmAno1 = new SqlParameter { ParameterName = "@AnoExercicio1", SqlDbType = SqlDbType.SmallInt, SqlValue = Ano1 };
                var prmAno2 = new SqlParameter { ParameterName = "@AnoExercicio2", SqlDbType = SqlDbType.SmallInt, SqlValue = Ano2 };
                var prmLanc1 = new SqlParameter { ParameterName = "@CodLancamento1", SqlDbType = SqlDbType.SmallInt, SqlValue = Lancamento1 };
                var prmLanc2 = new SqlParameter { ParameterName = "@CodLancamento2", SqlDbType = SqlDbType.SmallInt, SqlValue = Lancamento2 };
                var prmSeq1 = new SqlParameter { ParameterName = "@SeqLancamento1", SqlDbType = SqlDbType.SmallInt, SqlValue = Sequencia1 };
                var prmSeq2 = new SqlParameter { ParameterName = "@SeqLancamento2", SqlDbType = SqlDbType.SmallInt, SqlValue = Sequencia2 };
                var prmPc1 = new SqlParameter { ParameterName = "@NumParcela1", SqlDbType = SqlDbType.SmallInt, SqlValue = Parcela1 };
                var prmPc2 = new SqlParameter { ParameterName = "@NumParcela2", SqlDbType = SqlDbType.SmallInt, SqlValue = Parcela2 };
                var prmCp1 = new SqlParameter { ParameterName = "@CodComplemento1", SqlDbType = SqlDbType.SmallInt, SqlValue = Complemento1 };
                var prmCp2 = new SqlParameter { ParameterName = "@CodComplemento2", SqlDbType = SqlDbType.SmallInt, SqlValue = Complemento2 };
                var prmSta1 = new SqlParameter { ParameterName = "@Status1", SqlDbType = SqlDbType.SmallInt, SqlValue = Status1 };
                var prmSta2 = new SqlParameter { ParameterName = "@Status2", SqlDbType = SqlDbType.SmallInt, SqlValue = Status2 };
                var prmDtA = new SqlParameter { ParameterName = "@DataNow", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Data_Atualizacao == null ? DateTime.Now : Data_Atualizacao };
                var prmUser = new SqlParameter { ParameterName = "@Usuario", SqlDbType = SqlDbType.VarChar, SqlValue = Usuario };

                var result = context.SpExtrato.FromSql("EXEC spEXTRATONEW @CodReduz1, @CodReduz2, @AnoExercicio1 ,@AnoExercicio2 ,@CodLancamento1 ,@CodLancamento2, @SeqLancamento1 ,@SeqLancamento2, @NumParcela1, @NumParcela2, @CodComplemento1, @CodComplemento2, @Status1, @Status2, @DataNow, @Usuario ",
                    prmCod1, prmCod2, prmAno1, prmAno2, prmLanc1, prmLanc2, prmSeq1, prmSeq2, prmPc1, prmPc2, prmCp1, prmCp2, prmSta1, prmSta2, prmDtA, prmUser).ToList();

                List<SpExtrato> ListaDebito = new List<SpExtrato>();
                foreach (SpExtrato item in result) {
                    SpExtrato reg = new SpExtrato {
                        Anoexercicio = item.Anoexercicio,
                        Codlancamento = item.Codlancamento,
                        Desclancamento = item.Desclancamento,
                        Seqlancamento = item.Seqlancamento,
                        Numparcela = item.Numparcela,
                        Codcomplemento = item.Codcomplemento,
                        Datavencimento = item.Datavencimento,
                        Datadebase = item.Datadebase,
                        Datapagamento = item.Datapagamento,
                        Codreduzido = item.Codreduzido,
                        Statuslanc = item.Statuslanc,
                        Situacao = item.Situacao,
                        Datainscricao = item.Datainscricao,
                        Certidao = item.Certidao,
                        Numlivro = item.Numlivro,
                        Pagina = item.Pagina,
                        Numdocumento = item.Numdocumento,
                        Dataajuiza = item.Dataajuiza,
                        Valortributo = item.Valortributo,
                        Valormulta = item.Valormulta,
                        Valorjuros = item.Valorjuros,
                        Valorcorrecao = item.Valorcorrecao,
                        Valortotal = item.Valortotal,
                        Valorpago = item.Valorpago,
                        Valorpagoreal = item.Valorpagoreal,
                        Abrevtributo = item.Abrevtributo,
                        Codtributo = item.Codtributo,
                        UserId = item.UserId
                    };
                    reg.Valortributo = item.Valortributo;
                    reg.Anoexecfiscal = item.Anoexecfiscal;
                    reg.Numexecfiscal = item.Numexecfiscal;
                    reg.Processocnj = item.Processocnj;
                    reg.Prot_certidao = item.Prot_certidao;
                    reg.Prot_dtremessa = item.Prot_dtremessa;
                    ListaDebito.Add(reg);
                }
                return ListaDebito;

        }

        public List<SpExtrato> Lista_Extrato_Parcela(List<SpExtrato> Lista_Tributo) {
            List<SpExtrato> ListaDebito = new List<SpExtrato>();

            foreach (SpExtrato item in Lista_Tributo) {
                bool bFind = false;
                int x;
                for (x = 0; x < ListaDebito.Count; x++) {
                    SpExtrato itemArray = ListaDebito[x];
                    if (item.Anoexercicio == itemArray.Anoexercicio && item.Codlancamento == itemArray.Codlancamento && item.Seqlancamento == itemArray.Seqlancamento &&
                        item.Numparcela == itemArray.Numparcela && item.Codcomplemento == itemArray.Codcomplemento) {
                        bFind = true;
                        break;
                    }
                }
                if (!bFind) {
                    SpExtrato reg = new SpExtrato {
                        Anoexercicio = item.Anoexercicio,
                        Codlancamento = item.Codlancamento,
                        Desclancamento = item.Desclancamento,
                        Seqlancamento = item.Seqlancamento,
                        Numparcela = item.Numparcela,
                        Codcomplemento = item.Codcomplemento,
                        Datadebase = item.Datadebase,
                        Datavencimento = item.Datavencimento,
                        Statuslanc = item.Statuslanc,
                        Situacao = item.Situacao,
                        Datapagamento = item.Datapagamento,
                        Codreduzido = item.Codreduzido,
                        Datainscricao = item.Datainscricao,
                        Certidao = item.Certidao,
                        Numlivro = item.Numlivro,
                        Pagina = item.Pagina,
                        Dataajuiza = item.Dataajuiza,
                        Valortributo = item.Valortributo,
                        Valormulta = item.Valormulta,
                        Valorjuros = item.Valorjuros,
                        Valorcorrecao = item.Valorcorrecao,
                        Valortotal = item.Valortotal,
                        Numdocumento = item.Numdocumento,
                        Anoexecfiscal = item.Anoexecfiscal,
                        Numexecfiscal = item.Numexecfiscal,
                        Processocnj = item.Processocnj,
                        Prot_certidao = item.Prot_certidao,
                        Prot_dtremessa = item.Prot_dtremessa,
                        UserId = item.UserId
                    };
                    reg.Valorpago = item.Valorpago == null ? 0 : item.Valorpago;
                    reg.Valorpagoreal = item.Valorpagoreal == null ? 0 : item.Valorpagoreal;
                    ListaDebito.Add(reg);
                } else {
                    ListaDebito[x].Valortributo += item.Valortributo;
                    ListaDebito[x].Valormulta += item.Valormulta;
                    ListaDebito[x].Valorjuros += item.Valorjuros;
                    ListaDebito[x].Valorcorrecao += item.Valorcorrecao;
                    ListaDebito[x].Valortotal += item.Valortotal;
                }
            }

            return ListaDebito;

        }

        public Certidao_debito_detalhe Certidao_Debito(int Codigo) {
            Functions.TipoCadastro _tipo_Cadastro = Codigo < 100000 ? Functions.TipoCadastro.Imovel : Codigo >= 500000 ? Functions.TipoCadastro.Cidadao : Functions.TipoCadastro.Empresa;
            Certidao_debito_detalhe Certidao = new Certidao_debito_detalhe();
            List<SpExtrato> ListaTributo = Lista_Extrato_Tributo(Codigo, 1980, 2050, 0, 99, 0, 99, 0, 999, 0, 99, 0, 99, DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", null), "Web");

            ArrayList alArrayNaoPagoVencido = new ArrayList();
            ArrayList alArrayParceladoAVencer = new ArrayList();
            ArrayList alArraySuspenso = new ArrayList();
            ArrayList alArrayResult = new ArrayList();

            string _descricao_lancamento = "";
            string sDescTmp = "";

            if (ListaTributo.Count > 0) {
                bool bNaoPagoVencido = false;
                bool bParceladoAVencer = false;
                bool bSuspenso = false;

                foreach (var item in ListaTributo) {
                    bool bFind = false;
                    sDescTmp = item.Abrevtributo;
                    if (item.Codlancamento == 29)
                        sDescTmp = "IPTU";

                    //Verifica o status
                    //*** não pagos
                    TimeSpan difference = DateTime.Now - item.Datavencimento;
                    var days = difference.TotalDays;
                    if ((item.Statuslanc == 3 | item.Statuslanc == 18 | item.Statuslanc == 42 | item.Statuslanc == 43 | item.Statuslanc == 38 | item.Statuslanc == 39) && days > 1) {
                        bNaoPagoVencido = true;
                        for (int i = 0; i < alArrayNaoPagoVencido.Count; i++) {
                            if (item.Codtributo == 26 || item.Codtributo == 90 || item.Codtributo == 112 || item.Codtributo == 113 || item.Codtributo == 585 || item.Codtributo == 587 || item.Codtributo == 24 || item.Codtributo == 28) {
                                bFind = true;
                                break;
                            }
                            if (alArrayNaoPagoVencido[i].ToString() == sDescTmp) {
                                bFind = true;
                                break;
                            }
                        }
                        if (!bFind)
                            alArrayNaoPagoVencido.Add(sDescTmp);

                    }

                    //*** suspensos ou em julgamento
                    if ((item.Statuslanc == 18 | item.Statuslanc == 19 | item.Statuslanc == 20) && item.Datavencimento < DateTime.Now) {
                        bSuspenso = true;
                        if (item.Codtributo == 26 || item.Codtributo == 90 || item.Codtributo == 112 || item.Codtributo == 113 || item.Codtributo == 585 || item.Codtributo == 587 || item.Codtributo == 24 || item.Codtributo == 28) {
                            bFind = true;
                            break;
                        }
                        for (int i = 0; i < alArraySuspenso.Count; i++) {
                            if (alArraySuspenso[i].ToString() == sDescTmp) {
                                bFind = true;
                                break;
                            }
                        }
                        if (!bFind)
                            alArraySuspenso.Add(sDescTmp);
                    }

                    //*** parcelados
                    if (item.Codlancamento == 20 && (item.Statuslanc == 3 || item.Statuslanc == 18 || item.Statuslanc == 42 || item.Statuslanc == 43) && item.Datavencimento >= DateTime.Now) {
                        bParceladoAVencer = true;
                        for (int i = 0; i < alArrayParceladoAVencer.Count; i++) {
                            if (item.Codtributo == 26 || item.Codtributo == 90 || item.Codtributo == 112 || item.Codtributo == 113 || item.Codtributo == 585 || item.Codtributo == 587 || item.Codtributo == 24 || item.Codtributo == 28) {
                                bFind = true;
                                break;
                            }
                            if (alArrayParceladoAVencer[i].ToString() == sDescTmp) {
                                bFind = true;
                                break;
                            }
                        }
                        if (!bFind)
                            alArrayParceladoAVencer.Add(sDescTmp);
                    }
                }

                if (bNaoPagoVencido) {
                    alArrayResult = alArrayNaoPagoVencido;
                } else {
                    if (bSuspenso) {
                        alArrayResult = alArraySuspenso;
                    } else {
                        if (bParceladoAVencer) {
                            alArrayResult = alArrayParceladoAVencer;
                        }
                    }
                }

                for (int i = 0; i < alArrayResult.Count; i++) {
                    _descricao_lancamento += alArrayResult[i].ToString() + ", ";
                }

                if (_descricao_lancamento != "")
                    _descricao_lancamento = _descricao_lancamento.Substring(0, _descricao_lancamento.Length - 2);
                else {
                    if (_tipo_Cadastro == Functions.TipoCadastro.Imovel) {
                        _descricao_lancamento = "Débitos Imobiliários";
                    } else {
                        if (_tipo_Cadastro == Functions.TipoCadastro.Empresa) {
                            _descricao_lancamento = "Débitos Mobiliários";
                        } else {
                            _descricao_lancamento = "Débitos do Contribuinte";
                        }
                    }
                }

                if (bNaoPagoVencido)
                    Certidao.Tipo_Retorno = Functions.RetornoCertidaoDebito.Positiva;
                else {
                    //Verifica se tem débito suspenso/julgamento
                    if (bSuspenso)
                        Certidao.Tipo_Retorno = Functions.RetornoCertidaoDebito.NegativaPositiva;
                    else {
                        //Verifica se tem parcelamento
                        if (bParceladoAVencer)
                            Certidao.Tipo_Retorno = Functions.RetornoCertidaoDebito.NegativaPositiva;
                        else
                            Certidao.Tipo_Retorno = Functions.RetornoCertidaoDebito.Negativa;
                    }
                }
            } else {
                //Código sem lançamentos, emite negativa
                Certidao.Descricao_Lancamentos = "";
                Certidao.Tipo_Retorno = Functions.RetornoCertidaoDebito.Negativa;
            }

            Certidao.Descricao_Lancamentos = _descricao_lancamento;
            return Certidao;
        }


    }
}
