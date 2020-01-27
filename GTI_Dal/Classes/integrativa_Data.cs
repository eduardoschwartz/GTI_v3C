using GTI_Models.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace GTI_Dal.Classes {
    public class Integrativa_Data {
        private static string _connection;

        public Integrativa_Data(string sConnection) {
            _connection = sConnection;
        }

        public int Insert_Integrativa_Cda(Cdas Reg) {
            int _id = 0;
            using (Integrativa_Context db = new Integrativa_Context(_connection)) {
                try {
                    db.Cdas.Add(Reg);
                    db.SaveChanges();
                    _id = Reg.Idcda;
                } catch  {

                }
                return _id;
            }
        }

        public int Insert_Integrativa_CdaDebito(Cdadebitos Reg) {
            int _id = 0;
            using (Integrativa_Context db = new Integrativa_Context(_connection)) {
                object[] Parametros = new object[14];
                Parametros[0] = new SqlParameter { ParameterName = "@idcda", SqlDbType = SqlDbType.Int, SqlValue = Reg.Idcda };
                Parametros[1] = new SqlParameter { ParameterName = "@codtributo", SqlDbType = SqlDbType.Int, SqlValue = Reg.Codtributo };
                Parametros[2] = new SqlParameter { ParameterName = "@tributo", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Tributo };
                Parametros[3] = new SqlParameter { ParameterName = "@exercicio", SqlDbType = SqlDbType.Int, SqlValue = Reg.Exercicio };
                Parametros[4] = new SqlParameter { ParameterName = "@lancamento", SqlDbType = SqlDbType.Int, SqlValue = Reg.Lancamento };
                Parametros[5] = new SqlParameter { ParameterName = "@seq", SqlDbType = SqlDbType.Int, SqlValue = Reg.Seq };
                Parametros[6] = new SqlParameter { ParameterName = "@nroparcela", SqlDbType = SqlDbType.Int, SqlValue = Reg.Nroparcela };
                Parametros[7] = new SqlParameter { ParameterName = "@complparcela", SqlDbType = SqlDbType.Int, SqlValue = Reg.Complparcela };
                Parametros[8] = new SqlParameter { ParameterName = "@dtvencimento", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Dtvencimento };
                Parametros[9] = new SqlParameter { ParameterName = "@vlroriginal", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Vlroriginal };
                Parametros[10] = new SqlParameter { ParameterName = "@vlrmultas", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Vlrmultas };
                Parametros[11] = new SqlParameter { ParameterName = "@vlrjuros", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Vlrjuros };
                Parametros[12] = new SqlParameter { ParameterName = "@vlrcorrecao", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Vlrcorrecao };
                Parametros[13] = new SqlParameter { ParameterName = "@dtgeracao", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Dtgeracao };

                try {
                    db.Database.ExecuteSqlCommand("INSERT INTO cdadebitos(idcda,codtributo,tributo,exercicio,lancamento,seq,nroparcela,complparcela,dtvencimento," +
                        "vlroriginal,vlrmultas,vlrjuros,vlrcorrecao,dtgeracao) VALUES(@idcda,@codtributo,@tributo,@exercicio,@lancamento,@seq,@nroparcela," +
                        "@complparcela,@dtvencimento,@vlroriginal,@vlrmultas,@vlrjuros,@vlrcorrecao,@dtgeracao)", Parametros);
                    _id = Reg.Idcdadebitos;
                } catch  {

                }
                return _id;
            }
        }

        public Exception Insert_Integrativa_Cancelamento(Cancelamentos Reg) {
            using (Integrativa_Context db = new Integrativa_Context(_connection)) {
                try {
                    db.Cancelamentos.Add(Reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Integrativa_Cadastro_Old(Cadastro Reg) {
            using (Integrativa_Context db = new Integrativa_Context(_connection)) {
                object[] Parametros = new object[26];
                Parametros[0] = new SqlParameter { ParameterName = "@idcadastro", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Idcadastro };
                Parametros[1] = new SqlParameter { ParameterName = "@idcda", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Idcda };
                Parametros[2] = new SqlParameter { ParameterName = "@setordevedor", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Setordevedor };
                Parametros[3] = new SqlParameter { ParameterName = "@crc", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Crc };
                Parametros[4] = new SqlParameter { ParameterName = "@nome", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Nome };
                Parametros[5] = new SqlParameter { ParameterName = "@inscricao", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Inscricao };
                Parametros[6] = new SqlParameter { ParameterName = "@cpfcnpj", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cpfcnpj };
                Parametros[7] = new SqlParameter { ParameterName = "@rginscrestadual", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Rginscrestadual };
                Parametros[8] = new SqlParameter { ParameterName = "@localcep", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Localcep };
                Parametros[9] = new SqlParameter { ParameterName = "@localendereco", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Localendereco };
                Parametros[10] = new SqlParameter { ParameterName = "@localnumero", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Localnumero };
                Parametros[11] = new SqlParameter { ParameterName = "@localcomplemento", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Localcomplemento };
                Parametros[12] = new SqlParameter { ParameterName = "@localbairro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Localbairro };
                Parametros[13] = new SqlParameter { ParameterName = "@localcidade", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Localcidade };
                Parametros[14] = new SqlParameter { ParameterName = "@localestado", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.LocalEstado };
                Parametros[15] = new SqlParameter { ParameterName = "@quadra", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Quadra };
                Parametros[16] = new SqlParameter { ParameterName = "@lote", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Lote };
                Parametros[17] = new SqlParameter { ParameterName = "@entregacep", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Entregacep };
                Parametros[18] = new SqlParameter { ParameterName = "@entregaendereco", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Entregaendereco };
                Parametros[19] = new SqlParameter { ParameterName = "@entreganumero", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Entreganumero };
                Parametros[20] = new SqlParameter { ParameterName = "@entregacomplemento", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Entregacomplemento };
                Parametros[21] = new SqlParameter { ParameterName = "@entregabairro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Entregabairro };
                Parametros[22] = new SqlParameter { ParameterName = "@entregacidade", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Entregacidade };
                Parametros[23] = new SqlParameter { ParameterName = "@entregaestado", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Entregaestado };
                Parametros[24] = new SqlParameter { ParameterName = "@dtgeracao", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Dtgeracao };
                Parametros[25] = new SqlParameter { ParameterName = "@dtleitura", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Dtleitura };

                db.Database.ExecuteSqlCommand("INSERT INTO cadastro(idcadastro,idcda,setordevedor,crc,nome,inscricao,cpfcnpj,rginscrestadual,localcep,localendereco," +
                    "localnumero,localcomplemento,localbairro,localcidade,localestado,quadra,lote,entregacep,entregaendereco,entreganumero,entregacomplemento," +
                    "entregabairro,entregacidade,entregaestado,dtgeracao,dtleitura) VALUES(@idcadastro,@idcda,@setordevedor,@crc,@nome,@inscricao,@cpfcnpj," +
                    "@rginscrestadual,@localcep,@localendereco,@localnumero,@localcomplemento,@localbairro,@localcidade,@localestado,@quadra,@lote,@entregacep," +
                    "@entregaendereco,@entreganumero,@entregacomplemento,@entregabairro,@entregacidade,@entregaestado,@dtgeracao,@dtleitura)", Parametros);
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public int Insert_Integrativa_Cadastro(Cadastro Reg) {
            int _id = 0;
            using (Integrativa_Context db = new Integrativa_Context(_connection)) {
                try {
                    db.Cadastro.Add(Reg);
                    db.SaveChanges();
                    _id = Reg.Idcadastro;
                } catch {

                }
                return _id;
            }
        }

        public int Insert_Integrativa_Partes(Partes Reg) {
            int _id = 0;
            using (Integrativa_Context db = new Integrativa_Context(_connection)) {
                try {
                    db.Partes.Add(Reg);
                    db.SaveChanges();
                    _id = Reg.Idparte;
                } catch {

                }
                return _id;
            }
        }

    }
}
