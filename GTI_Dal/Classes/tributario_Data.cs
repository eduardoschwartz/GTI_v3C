using GTI_Models.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using static GTI_Models.modelCore;
using GTI_Models;

namespace GTI_Dal.Classes {
    public class Tributario_Data {
        public static int Plano = 0;

        private static string _connection;

        public Tributario_Data(string sConnection) {
            _connection = sConnection;
        }
        
        public List<Lancamento> Lista_Lancamento() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = from l in db.Lancamento orderby l.Descfull select l;
                return Sql.ToList();
            }
        }

        public List<Situacaolancamento> Lista_Status() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = from s in db.Situacaolancamento orderby s.Descsituacao select s;
                return Sql.ToList();
            }
        }

        public List<Tributo> Lista_Tributo(int Codigo=0) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                List<Tributo> Sql = (from l in db.Tributo orderby l.Desctributo select l).ToList();
                if (Codigo > 0)
                    Sql=Sql.Where(c => c.Codtributo == Codigo).ToList();
                return Sql;
            }
        }

        public List<Tipolivro> Lista_Tipo_Livro() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = from t in db.Tipolivro orderby t.Desctipo select t;
                return Sql.ToList();
            }
        }

        public Paramparcela Retorna_Parametro_Parcela(int _ano,int _tipo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = from p in db.Paramparcela where p.Ano==_ano && p.Codtipo==_tipo select p;
                return Sql.FirstOrDefault();
            }
        }

        public Exception Insert_Lancamento(Lancamento reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int cntCod = (from c in db.Lancamento select c).Count();
                int maxCod = 1;
                if (cntCod > 0)
                    maxCod = (from c in db.Lancamento select c.Codlancamento).Max() + 1;

                try {
                    db.Database.ExecuteSqlCommand("INSERT INTO lancamento(codlancamento,descfull,descreduz,tipolivro) VALUES(@codlancamento,@descfull,@descreduz,@tipolivro)",
                        new SqlParameter("@codlancamento", Convert.ToInt16(maxCod)),
                        new SqlParameter("@descfull", reg.Descfull),
                        new SqlParameter("@descreduz", reg.Descreduz),
                        new SqlParameter("@tipolivro", reg.Tipolivro));
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Tributo(Tributo reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int cntCod = (from c in db.Tributo select c).Count();
                int maxCod = 1;
                if (cntCod > 0)
                    maxCod = (from c in db.Tributo select c.Codtributo).Max() + 1;

                reg.Codtributo = Convert.ToInt16(maxCod);
//                db.Tributo.Add(reg);
                try {
                    db.Database.ExecuteSqlCommand("INSERT INTO tributo(codtributo,desctributo,abrevtributo,da) VALUES(@codtributo,@desctributo,@abrevtributo,@da)",
                        new SqlParameter("@codtributo", Convert.ToInt16(maxCod)),
                        new SqlParameter("@desctributo", reg.Desctributo),
                        new SqlParameter("@abrevtributo", reg.Abrevtributo),
                        new SqlParameter("@da", reg.Da));
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_Lancamento(Lancamento reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int nCodLanc = reg.Codlancamento;
                Lancamento b = db.Lancamento.First(i => i.Codlancamento == nCodLanc);
                b.Descfull = reg.Descfull;
                b.Descreduz = reg.Descreduz;
                b.Tipolivro = reg.Tipolivro;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_Tributo(Tributo reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int nCodTrib = reg.Codtributo;
                Tributo b = db.Tributo.First(i => i.Codtributo == nCodTrib);
                b.Desctributo = reg.Desctributo;
                b.Abrevtributo = reg.Abrevtributo;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public bool Existe_Lancamento(Lancamento reg,bool novo=true) {
            bool bValido = false;
            using (GTI_Context db = new GTI_Context(_connection)) {
                if (novo) {
                    var existingReg = db.Lancamento.Count(a => a.Descfull == reg.Descfull);
                    if (existingReg > 0)
                        bValido = true;
                } else {
                    var existingReg = db.Lancamento.Count(a => a.Descfull == reg.Descfull && a.Codlancamento!=reg.Codlancamento);
                    if (existingReg > 0)
                        bValido = true;
                }
            }
            return bValido;
        }

        public bool Existe_Tributo(Tributo reg, bool novo = true) {
            bool bValido = false;
            using (GTI_Context db = new GTI_Context(_connection)) {
                if (novo) {
                    var existingReg = db.Tributo.Count(a => a.Desctributo == reg.Desctributo);
                    if (existingReg > 0)
                        bValido = true;
                } else {
                    var existingReg = db.Tributo.Count(a => a.Desctributo == reg.Desctributo && a.Codtributo != reg.Codtributo);
                    if (existingReg > 0)
                        bValido = true;
                }
            }
            return bValido;
        }

        public List<int> Lista_Codigo_Carta(int _codigo_inicial, int _codigo_final, DateTime _data_vencimento) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                db.Database.CommandTimeout = 3 * 60;
                List<int> Lista =  (from d in db.Debitoparcela where d.Codreduzido >= _codigo_inicial && d.Codreduzido <= _codigo_final && d.Datavencimento <= _data_vencimento && 
                                    (d.Statuslanc == 3 || d.Statuslanc==42 || d.Statuslanc==43  || d.Statuslanc == 38 || d.Statuslanc == 39) && d.Codlancamento!=20 orderby d.Codreduzido select d.Codreduzido  ).Distinct().ToList();
                return Lista;
            }
        }

        public Exception Excluir_Lancamento(Lancamento reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int nCodLanc = reg.Codlancamento;
                Lancamento b = db.Lancamento.First(i => i.Codlancamento == nCodLanc);
                try {
                    db.Lancamento.Remove(b);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Excluir_Tributo(Tributo reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int nCodTrib = reg.Codtributo;
                Tributo b = db.Tributo.First(i => i.Codtributo == nCodTrib);
                try {
                    db.Tributo.Remove(b);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public bool Lancamento_uso_debito(int codigo_lancamento) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Debitoparcela reg = (from c in db.Debitoparcela where c.Codlancamento==codigo_lancamento select c).FirstOrDefault();
                return reg!=null;
            }
        }

        public bool Lancamento_uso_tributo(int codigo_lancamento) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Tributolancamento reg = (from c in db.Tributolancamento where c.Codlancamento == codigo_lancamento select c).FirstOrDefault();
                return reg != null;
            }
        }

        public bool Tributo_uso_debito(int codigo_tributo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Debitoparcela reg = (from c in db.Debitoparcela where c.Codlancamento == codigo_tributo select c).FirstOrDefault();
                return reg != null;
            }
        }

        public bool Tributo_uso_lancamento(int codigo_tributo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Tributolancamento reg = (from c in db.Tributolancamento  where c.Codtributo == codigo_tributo select c).FirstOrDefault();
                return reg != null;
            }
        }

        public bool Tributo_uso_aliquota(int codigo_tributo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Tributoaliquota reg = (from c in db.Tributoaliquota where c.Codtributo == codigo_tributo select c).FirstOrDefault();
                return reg != null;
            }
        }

        public List<SpExtrato> Lista_Extrato_Tributo(int Codigo, short Ano1 = 1990, short Ano2 = 2050, short Lancamento1 = 1, short Lancamento2 = 99, short Sequencia1 = 0, short Sequencia2 = 9999,
            short Parcela1 = 0, short Parcela2 = 999, short Complemento1 = 0, short Complemento2 = 999, short Status1 = 0, short Status2 = 99, DateTime? Data_Atualizacao = null, string Usuario = "") {
            using (GTI_Context db = new GTI_Context(_connection)) {
                db.Database.CommandTimeout = 180; 
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

                var result = db.SpExtrato.SqlQuery("EXEC spEXTRATONEW @CodReduz1, @CodReduz2, @AnoExercicio1 ,@AnoExercicio2 ,@CodLancamento1 ,@CodLancamento2, @SeqLancamento1 ,@SeqLancamento2, @NumParcela1, @NumParcela2, @CodComplemento1, @CodComplemento2, @Status1, @Status2, @DataNow, @Usuario ",
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
                        Datapagamento=item.Datapagamento,
                        Codreduzido=item.Codreduzido,
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
                        UserId=item.UserId
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

        }

        public List<SpExtrato_carta> Lista_Extrato_Tributo_Carta(int Codigo, short Ano1 = 1990, short Ano2 = 2050, short Lancamento1 = 1, short Lancamento2 = 99, short Sequencia1 = 0, short Sequencia2 = 9999,
                                                                 short Parcela1 = 0, short Parcela2 = 999, short Complemento1 = 0, short Complemento2 = 999, short Status1 = 0, short Status2 = 99, DateTime? Data_Atualizacao = null, string Usuario = "") {
            using (GTI_Context db = new GTI_Context(_connection)) {
                db.Database.CommandTimeout = 180;
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

                var result = db.SpExtrato_carta.SqlQuery("EXEC spEXTRATO_CARTA @CodReduz1, @CodReduz2, @AnoExercicio1 ,@AnoExercicio2 ,@CodLancamento1 ,@CodLancamento2, @SeqLancamento1 ,@SeqLancamento2, @NumParcela1, @NumParcela2, @CodComplemento1, @CodComplemento2, @Status1, @Status2, @DataNow, @Usuario ",
                    prmCod1, prmCod2, prmAno1, prmAno2, prmLanc1, prmLanc2, prmSeq1, prmSeq2, prmPc1, prmPc2, prmCp1, prmCp2, prmSta1, prmSta2, prmDtA, prmUser).ToList();

                List<SpExtrato_carta> ListaDebito = new List<SpExtrato_carta>();
                foreach (SpExtrato_carta item in result) {
                    SpExtrato_carta reg = new SpExtrato_carta {
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
                        Datapagamento=item.Datapagamento,
                        Codreduzido=item.Codreduzido,
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
                        Numdocumento=item.Numdocumento,
                        Anoexecfiscal = item.Anoexecfiscal,
                        Numexecfiscal = item.Numexecfiscal,
                        Processocnj = item.Processocnj,
                        Prot_certidao = item.Prot_certidao,
                        Prot_dtremessa = item.Prot_dtremessa,
                        UserId=item.UserId
                    };
                    reg.Valorpago = item.Valorpago==null?0:item.Valorpago;
                    reg.Valorpagoreal = item.Valorpagoreal==null?0:item.Valorpagoreal;
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

        public List<SpExtrato_carta> Lista_Extrato_Parcela_Carta(List<SpExtrato_carta> Lista_Tributo) {
            List<SpExtrato_carta> ListaDebito = new List<SpExtrato_carta>();

            foreach (SpExtrato_carta item in Lista_Tributo) {
                bool bFind = false;
                int x;
                for (x = 0; x < ListaDebito.Count; x++) {
                    SpExtrato_carta itemArray = ListaDebito[x];
                    if (item.Anoexercicio == itemArray.Anoexercicio && item.Codlancamento == itemArray.Codlancamento && item.Seqlancamento == itemArray.Seqlancamento &&
                        item.Numparcela == itemArray.Numparcela && item.Codcomplemento == itemArray.Codcomplemento) {
                        bFind = true;
                        break;
                    }
                }
                if (!bFind) {
                    SpExtrato_carta reg = new SpExtrato_carta {
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
                        Prot_dtremessa = item.Prot_dtremessa
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

        public double Retorna_Taxa_Expediente(int codigo,short ano,short lancamento,short sequencia,short parcela,short complemento) {
            double nTaxa=0;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from d in db.Debitotributo where d.Codreduzido == codigo && d.Anoexercicio==ano && d.Codlancamento==lancamento && d.Seqlancamento==sequencia &&
                           d.Numparcela==parcela && d.Codcomplemento==complemento && d.Codtributo==3  select d.Valortributo).FirstOrDefault();
                if (reg == null)
                    nTaxa = 0;
                else
                    nTaxa = Convert.ToDouble(reg);
            }
            return nTaxa;
        }

        public List<ObsparcelaStruct> Lista_Observacao_Parcela(int codigo) {
                using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = from d in db.Obsparcela
                          join u in db.Usuario on d.Userid equals u.Id into du from u in du.DefaultIfEmpty()
                          where d.Codreduzido == codigo
                          orderby d.Codreduzido,d.Anoexercicio,d.Codlancamento,d.Seqlancamento,d.Numparcela,d.Codcomplemento,d.Data
                          select new ObsparcelaStruct {Codreduzido= d.Codreduzido,Anoexercicio=d.Anoexercicio,Codcomplemento=d.Codcomplemento,Codlancamento=d.Codlancamento,
                          Data=d.Data,NomeCompleto=u.Nomecompleto,NomeLogin=u.Nomelogin,Numparcela=d.Numparcela,Obs=d.Obs,Seq=d.Seq,Seqlancamento=d.Seqlancamento,Userid=d.Userid};
                return reg.ToList();
            }
        }

        public Exception Insert_Observacao_Parcela(Obsparcela reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int maxSeq = Retorna_Ultima_Seq_Observacao_Parcela(reg.Codreduzido,reg.Anoexercicio,reg.Codlancamento,reg.Seqlancamento,reg.Numparcela,reg.Codcomplemento);

                try {
                    db.Database.ExecuteSqlCommand("INSERT INTO obsparcela(codreduzido,anoexercicio,codlancamento,seqlancamento,numparcela,codcomplemento,seq,obs,userid,data) " +
                        "VALUES(@codreduzido, @anoexercicio, @codlancamento, @seqlancamento, @numparcela, @codcomplemento, @seq, @obs, @userid, @data  )",
                        new SqlParameter("@codreduzido", reg.Codreduzido),
                        new SqlParameter("@anoexercicio", reg.Anoexercicio),
                        new SqlParameter("@codlancamento", reg.Codlancamento),
                        new SqlParameter("@seqlancamento", reg.Seqlancamento),
                        new SqlParameter("@numparcela", reg.Numparcela),
                        new SqlParameter("@codcomplemento", reg.Codcomplemento),
                        new SqlParameter("@seq", maxSeq+1),
                        new SqlParameter("@obs", reg.Obs),
                        new SqlParameter("@userid", reg.Userid),
                        new SqlParameter("@data", reg.Data));
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_Observacao_Parcela(Obsparcela reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Obsparcela b = db.Obsparcela.First(i => i.Codreduzido == reg.Codreduzido && i.Anoexercicio==reg.Anoexercicio && i.Codlancamento==reg.Codlancamento &&
                i.Seqlancamento==reg.Seqlancamento && i.Numparcela==reg.Numparcela && i.Codcomplemento==reg.Codcomplemento && i.Seq==reg.Seq);
                b.Data = reg.Data;
                b.Obs = reg.Obs;
                b.Userid = reg.Userid;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public short Retorna_Ultima_Seq_Observacao_Parcela(int Codigo,int Ano,short Lanc, short Sequencia,short Parcela,short Complemento) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var cntCod = (from c in db.Obsparcela
                              where c.Codreduzido == Codigo && c.Anoexercicio == Ano && c.Codlancamento == Lanc && c.Seqlancamento == Sequencia && c.Numparcela == Parcela && c.Codcomplemento == Complemento
                              orderby c.Seq descending
                              select c.Seq).FirstOrDefault();
                return Convert.ToInt16(cntCod);
            }
        }

        public Exception Excluir_Observacao_Parcela(Obsparcela reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Obsparcela b = db.Obsparcela.First(i => i.Codreduzido == reg.Codreduzido && i.Anoexercicio == reg.Anoexercicio && i.Codlancamento == reg.Codlancamento && i.Seqlancamento == reg.Seqlancamento && i.Numparcela == reg.Numparcela && i.Codcomplemento == reg.Codcomplemento && i.Seq == reg.Seq);
                try {
                    db.Obsparcela.Remove(b);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public List<DebitoobservacaoStruct> Lista_Observacao_Codigo(int codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = from d in db.Debitoobservacao
                          join u in db.Usuario on d.Userid equals u.Id into du from u in du.DefaultIfEmpty()
                          where d.Codreduzido == codigo
                          orderby  d.Dataobs select new DebitoobservacaoStruct {Codreduzido=  d.Codreduzido,Dataobs= d.Dataobs,
                              Obs=d.Obs,Seq=d.Seq,Userid=d.Userid,NomeLogin=u.Nomelogin,NomeCompleto=u.Nomecompleto };
                return reg.ToList();
            }
        }

        public Exception Insert_Observacao_Codigo(Debitoobservacao reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int maxSeq = Retorna_Ultima_Seq_Observacao_Codigo(reg.Codreduzido);

                try {
                    db.Database.ExecuteSqlCommand("INSERT INTO debitoobservacao(codreduzido,seq,userid,dataobs,obs) " +
                        "VALUES(@codreduzido, @seq, @userid, @dataobs, @obs)",
                        new SqlParameter("@codreduzido", reg.Codreduzido),
                        new SqlParameter("@seq", maxSeq + 1),
                        new SqlParameter("@userid", reg.Userid),
                        new SqlParameter("@dataobs", reg.Dataobs),
                        new SqlParameter("@obs", reg.Obs));
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public short Retorna_Ultima_Seq_Observacao_Codigo(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var cntCod = (from c in db.Debitoobservacao where c.Codreduzido == Codigo orderby c.Seq descending select c.Seq).FirstOrDefault();
                return Convert.ToInt16(cntCod);
            }
        }

        public short Retorna_Ultima_Seq_Honorario(int Codigo,int Ano) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var cntCod = (from c in db.Debitoparcela where c.Codreduzido == Codigo && c.Anoexercicio==Ano && c.Codlancamento==41 orderby c.Seqlancamento descending  select c.Seqlancamento).FirstOrDefault();
                return Convert.ToInt16(cntCod);
            }
        }

        public short Retorna_Ultima_Seq_AR(int Codigo, int Ano) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var cntCod = (from c in db.Parceladocumento where c.Codreduzido == Codigo && c.Anoexercicio == Ano && c.Codlancamento == 78 orderby c.Seqlancamento descending select c.Seqlancamento).FirstOrDefault();
                return Convert.ToInt16(cntCod);
            }
        }




        public Exception Alterar_Observacao_Codigo(Debitoobservacao reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Debitoobservacao b = db.Debitoobservacao.First(i => i.Codreduzido == reg.Codreduzido && i.Seq==reg.Seq);
                b.Dataobs = reg.Dataobs;
                b.Obs = reg.Obs;
                b.Userid = reg.Userid;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Excluir_Observacao_Codigo(int Codigo,short Seq) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Debitoobservacao b = db.Debitoobservacao.First(i => i.Codreduzido == Codigo &&  i.Seq == Seq);
                try {
                    db.Debitoobservacao.Remove(b);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public List<Numdocumento> Lista_Parcela_Documentos(Parceladocumento reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from d in db.Numdocumento
                           join p in db.Parceladocumento on d.numdocumento equals p.Numdocumento into dp1 from p in dp1.DefaultIfEmpty()
                           where p.Codreduzido==reg.Codreduzido && p.Anoexercicio==reg.Anoexercicio && p.Codlancamento==reg.Codlancamento && 
                           p.Seqlancamento==reg.Seqlancamento && p.Numparcela==reg.Numparcela && p.Codcomplemento==reg.Codcomplemento
                           orderby d.numdocumento
                           select new { d.numdocumento, d.Datadocumento, d.Valorguia }).ToList();
                List<Numdocumento> Lista = new List<Numdocumento>();
                foreach (var item in Sql) {
                    Numdocumento Linha = new Numdocumento {
                        numdocumento = item.numdocumento,
                        Datadocumento = item.Datadocumento,
                        Valorguia = item.Valorguia
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<DebitoStructure> Lista_Tabela_Parcela_Documento(int nNumdocumento) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                    var reg = (from p in db.Parceladocumento where p.Numdocumento == nNumdocumento
                               select new { p.Codreduzido, p.Anoexercicio, p.Codlancamento, p.Seqlancamento, p.Numparcela, p.Codcomplemento });
                    List<DebitoStructure> Lista = new List<DebitoStructure>();
                    foreach (var query in reg) {
                    DebitoStructure Linha = new DebitoStructure {
                        Codigo_Reduzido = query.Codreduzido,
                        Ano_Exercicio = query.Anoexercicio,
                        Codigo_Lancamento = query.Codlancamento,
                        Sequencia_Lancamento = query.Seqlancamento,
                        Numero_Parcela = query.Numparcela,
                        Complemento = query.Codcomplemento
                    };
                    Lista.Add(Linha);
                    }
                    return Lista;
                }
            }

        //public List<ParceladocumentoStruct> Lista_Lancamento_Documentos(Parceladocumento reg) {
        //    using (GTI_Context db = new GTI_Context(_connection)) {
        //        var Sql = (from d in db.Numdocumento
        //                   join p in db.Parceladocumento on d.numdocumento equals p.Numdocumento into dp1 from p in dp1.DefaultIfEmpty()
        //                   where p.Codreduzido == reg.Codreduzido && p.Anoexercicio == reg.Anoexercicio && p.Codlancamento == reg.Codlancamento &&
        //                   p.Seqlancamento == reg.Seqlancamento && p.Numparcela == reg.Numparcela && p.Codcomplemento == reg.Codcomplemento
        //                   orderby d.numdocumento
        //                   select new ParceladocumentoStruct{Documento= d.numdocumento, d.Datadocumento, d.Valorguia }).ToList();
        //        List<Numdocumento> Lista = new List<Numdocumento>();
        //        foreach (var item in Sql) {
        //            Numdocumento Linha = new Numdocumento();
        //            Linha.numdocumento = item.numdocumento;
        //            Linha.Datadocumento = item.Datadocumento;
        //            Linha.Valorguia = item.Valorguia;
        //            Lista.Add(Linha);
        //        }
        //        return Lista;
        //    }
        //}

        public Exception Insert_Boleto_Guia(Boletoguia Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Boletoguia.Add(Reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Numero_Segunda_Via(Segunda_via_web Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Segunda_via_web.Add(Reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Atividade(Atividade Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Database.ExecuteSqlCommand("INSERT INTO atividade(codatividade,descatividade,valoraliq1,valoraliq2,valoraliq3) " +
                        "VALUES(@codatividade, @descatividade, @valoraliq1, @valoraliq2, @valoraliq3)",
                        new SqlParameter("@codatividade", Reg.Codatividade),
                        new SqlParameter("@descatividade", Reg.Descatividade),
                        new SqlParameter("@valoraliq1", Reg.Valoraliq1),
                        new SqlParameter("@valoraliq2", Reg.Valoraliq2),
                        new SqlParameter("@valoraliq3", Reg.Valoraliq3));
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_Atividade(Atividade reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Atividade b = db.Atividade.First(i => i.Codatividade == reg.Codatividade);
                b.Descatividade = reg.Descatividade;
                b.Valoraliq1 = reg.Valoraliq1;
                b.Valoraliq2 = reg.Valoraliq2;
                b.Valoraliq3 = reg.Valoraliq3;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public List<Boletoguia> Lista_Boleto_Guia(int nSid) {
            List<Boletoguia> reg;
            using (GTI_Context db = new GTI_Context(_connection)) {
                reg = (from b in db.Boletoguia where b.Sid == nSid select b).ToList();
                return reg;
            }
        }

        public List<Boleto> Lista_Boleto_DAM(int nSid) {
            List<Boleto> reg;
            using (GTI_Context db = new GTI_Context(_connection)) {
                reg = (from b in db.Boleto where b.Sid == nSid select b).ToList();
                return reg;
            }
        }

        public List<DebitoStructure> Lista_Parcelas_CIP(int nCodigo, int nAno) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from dp in db.Debitoparcela
                           join dt in db.Debitotributo on new { p1 = dp.Codreduzido, p2 = dp.Anoexercicio, p3 = dp.Codlancamento, p4 = dp.Seqlancamento, p5 = dp.Numparcela, p6 = dp.Codcomplemento }
                                                   equals new { p1 = dt.Codreduzido, p2 = dt.Anoexercicio, p3 = dt.Codlancamento, p4 = dt.Seqlancamento, p5 = dt.Numparcela, p6 = dt.Codcomplemento } into dpdt from dt in dpdt.DefaultIfEmpty()
                           join pd in db.Parceladocumento on new { p1 = dp.Codreduzido, p2 = dp.Anoexercicio, p3 = dp.Codlancamento, p4 = dp.Seqlancamento, p5 = dp.Numparcela, p6 = dp.Codcomplemento }
                                                      equals new { p1 = pd.Codreduzido, p2 = pd.Anoexercicio, p3 = pd.Codlancamento, p4 = pd.Seqlancamento, p5 = pd.Numparcela, p6 = pd.Codcomplemento } into dppd from pd in dppd.DefaultIfEmpty()
                           where dp.Codreduzido == nCodigo && dp.Anoexercicio == nAno && dp.Codlancamento == 79 && dp.Seqlancamento == 0 && dp.Statuslanc == 3 && dp.Datavencimento>=DateTime.Now
                           orderby new { dp.Numparcela, dp.Codcomplemento }
                           select new { dp.Codreduzido, dp.Anoexercicio, dp.Codlancamento, dp.Seqlancamento, dp.Numparcela, dp.Codcomplemento, dp.Datavencimento, dt.Valortributo, pd.Numdocumento });

                List<DebitoStructure> Lista = new List<DebitoStructure>();
                foreach (var query in reg) {
                    foreach (DebitoStructure item in Lista) {
                        if (item.Numero_Parcela == query.Numparcela && item.Complemento == query.Codcomplemento)
                            goto Proximo;
                    }
                    DebitoStructure Linha = new DebitoStructure {
                        Codigo_Reduzido = query.Codreduzido,
                        Ano_Exercicio = query.Anoexercicio,
                        Codigo_Lancamento = query.Codlancamento,
                        Sequencia_Lancamento = query.Seqlancamento,
                        Numero_Parcela = query.Numparcela,
                        Complemento = query.Codcomplemento,
                        Soma_Principal = Convert.ToDecimal(query.Valortributo),
                        Data_Vencimento = query.Datavencimento,
                        Numero_Documento = query.Numdocumento
                    };
                    Lista.Add(Linha);
                    Proximo:;
                }
                return Lista;
            }
        }

        public List<DebitoStructure> Lista_Parcelas_IPTU(int nCodigo, int nAno) {
            DateTime dDataNow = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from dp in db.Debitoparcela
                           join dt in db.Debitotributo on new { p1 = dp.Codreduzido, p2 = dp.Anoexercicio, p3 = dp.Codlancamento, p4 = dp.Seqlancamento, p5 = dp.Numparcela, p6 = dp.Codcomplemento }
                                                   equals new { p1 = dt.Codreduzido, p2 = dt.Anoexercicio, p3 = dt.Codlancamento, p4 = dt.Seqlancamento, p5 = dt.Numparcela, p6 = dt.Codcomplemento } into dpdt from dt in dpdt.DefaultIfEmpty()
                           join pd in db.Parceladocumento on new { p1 = dp.Codreduzido, p2 = dp.Anoexercicio, p3 = dp.Codlancamento, p4 = dp.Seqlancamento, p5 = dp.Numparcela, p6 = dp.Codcomplemento }
                                                      equals new { p1 = pd.Codreduzido, p2 = pd.Anoexercicio, p3 = pd.Codlancamento, p4 = pd.Seqlancamento, p5 = pd.Numparcela, p6 = pd.Codcomplemento } into dppd from pd in dppd.DefaultIfEmpty()
                           join nd in db.Numdocumento on pd.Numdocumento equals nd.numdocumento 
                           where dp.Codreduzido == nCodigo && dp.Anoexercicio == nAno && dp.Codlancamento == 1 && dp.Seqlancamento == 0   && nd.Registrado==true 
                           orderby new { dp.Numparcela, dp.Codcomplemento }
                           select new { dp.Codreduzido, dp.Anoexercicio, dp.Codlancamento, dp.Seqlancamento, dp.Numparcela, dp.Codcomplemento, dp.Datavencimento, dt.Valortributo, pd.Numdocumento,nd.Datadocumento });

                List<DebitoStructure> Lista = new List<DebitoStructure>();
                foreach (var query in reg) {
                    foreach (DebitoStructure item in Lista) {
                        if (item.Numero_Parcela == query.Numparcela && item.Complemento == query.Codcomplemento)
                            goto Proximo;
                    }
                    DebitoStructure Linha = new DebitoStructure {
                        Codigo_Reduzido = query.Codreduzido,
                        Ano_Exercicio = query.Anoexercicio,
                        Codigo_Lancamento = query.Codlancamento,
                        Sequencia_Lancamento = query.Seqlancamento,
                        Numero_Parcela = query.Numparcela,
                        Complemento = query.Codcomplemento,
                        Soma_Principal = Convert.ToDecimal(query.Valortributo),
                        Data_Vencimento = query.Datavencimento,
                        Numero_Documento = query.Numdocumento,
                        Data_Base = Convert.ToDateTime(query.Datadocumento)
                    };
                    Lista.Add(Linha);
                    Proximo:;
                }
                return Lista;
            }
        }

        public Exception Insert_Carne_Web(int Codigo, int Ano) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    Laseriptu b = db.Laser_iptu.First(i => i.Codreduzido == Codigo && i.Ano == Ano);
                    b.Carne_web = 1;
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Excluir_Carne(int nSid) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Boletoguia.RemoveRange(db.Boletoguia.Where(i => i.Sid == nSid));
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Laseriptu Carrega_Dados_IPTU(int nCodigo, int nAno) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Laseriptu reg = (from l in db.Laser_iptu where l.Ano == nAno && l.Codreduzido == nCodigo select l).FirstOrDefault();
                return reg;
            }
        }

        public bool Existe_Documento_CIP(int nNumDocumento) {
            bool bRet = false;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var existingReg = db.Parceladocumento.Where(a => a.Codlancamento == 79).Count(a => a.Numdocumento == nNumDocumento);
                if (existingReg != 0) {
                    bRet = true;
                }
            }
            return bRet;
        }

        public bool Existe_Documento(int nNumDocumento) {
            bool bRet = false;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var existingReg = db.Numdocumento.Where(a => a.numdocumento > 1).Count(a => a.numdocumento == nNumDocumento);
                if (existingReg != 0) {
                    bRet = true;
                }
            }
            return bRet;
        }

        public int Retorna_Codigo_por_Documento(int nNumDocumento) {
            int Sql = 0;
            using (GTI_Context db = new GTI_Context(_connection)) {
                Sql = (from b in db.Parceladocumento where  b.Numdocumento == nNumDocumento select b.Codreduzido).FirstOrDefault();
            }
            return Sql;
        }

        public bool IsRefis() {
            return false;
        }

        public bool IsRefisDI() {
            return false;
        }

        public int Insert_Documento(Numdocumento Reg) {
            Int32 maxCod = 0;
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    maxCod = db.Numdocumento.Max(u => u.numdocumento);
                    maxCod++;
                    db.Database.ExecuteSqlCommand("INSERT INTO numdocumento(numdocumento,datadocumento,valorguia,emissor,registrado,percisencao) VALUES(@numdocumento,@datadocumento,@valorguia,@emissor,@registrado,@percisencao)",
                        new SqlParameter("@numdocumento", maxCod),
                        new SqlParameter("@datadocumento", Reg.Datadocumento),
                        new SqlParameter("@valorguia", Reg.Valorguia),
                        new SqlParameter("@emissor", Reg.Emissor),
                        new SqlParameter("@registrado", Reg.Registrado),
                        new SqlParameter("@percisencao", Reg.Percisencao));
                } catch (Exception ex) {
                    throw (ex.InnerException);
                }
                return maxCod;

            }
        }

        public Exception Insert_Documento_Existente(Numdocumento Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Database.ExecuteSqlCommand("INSERT INTO numdocumento(numdocumento,datadocumento,valorguia,emissor,registrado,percisencao) VALUES(@numdocumento,@datadocumento,@valorguia,@emissor,@registrado,@percisencao)",
                        new SqlParameter("@numdocumento", Reg.numdocumento),
                        new SqlParameter("@datadocumento", Reg.Datadocumento),
                        new SqlParameter("@valorguia", Reg.Valorguia),
                        new SqlParameter("@emissor", Reg.Emissor),
                        new SqlParameter("@registrado", Reg.Registrado),
                        new SqlParameter("@percisencao", Reg.Percisencao));
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Parcela_Documento(Parceladocumento Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Parceladocumento.Add(Reg);
                    db.SaveChanges();
                    
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Int32 Insert_Boleto_DAM(List<DebitoStructure> lstDebito, Int32 nNumDoc, DateTime DataBoleto) {
            int nSid = dalCore.GetRandomNumber(), nCodigo = lstDebito[0].Codigo_Reduzido, nNumero = 0, Pos = 0;
            string sInscricao = "", sNome = "", sQuadra = "", sLote = "", sCPF = "", sEndereco = "", sComplemento = "", sBairro = "", sCidade = "", sUF = "";
            decimal SomaPrincipal = 0, SomaTotal = 0;

            string sNumDoc = nNumDoc.ToString() + "-" + dalCore.RetornaDVDocumento(nNumDoc).ToString();
            string sNumDoc2 = nNumDoc.ToString() + dalCore.RetornaDVDocumento(nNumDoc).ToString();
            string sNumDoc3 = nNumDoc.ToString() + dalCore.Modulo11(nNumDoc.ToString("0000000000000")).ToString();

//            dalCore.TipoContribuinte tpContribuinte = nCodigo < 100000 ?
//                dalCore.TipoContribuinte.Imovel : nCodigo >= 100000 && nCodigo < 400000 ? dalCore.TipoContribuinte.Empresa : dalCore.TipoContribuinte.Cidadao;
            TipoCadastro Local = nCodigo < 100000 ? TipoCadastro.Imovel : nCodigo >= 100000 && nCodigo < 400000 ? TipoCadastro.Empresa : TipoCadastro.Cidadao;


            Sistema_Data sistema_Class = new Sistema_Data("GTIconnection");
            Contribuinte_Header_Struct regDados = sistema_Class.Contribuinte_Header(nCodigo,true);
            sNome = regDados.Nome;
            sCPF = regDados.Cpf_cnpj;
            sInscricao = regDados.Inscricao;
            sQuadra = "";
            sLote = "";
            sEndereco = regDados.Endereco ?? "";
            nNumero = regDados.Numero;
            sComplemento = regDados.Complemento ?? "";
            sBairro = regDados.Nome_bairro ?? "";
            sCidade = regDados.Nome_cidade ?? "";
            sUF = regDados.Nome_uf;

            DeleteSid(nSid);

            foreach (DebitoStructure reg in lstDebito) {
                SomaPrincipal += Convert.ToDecimal(reg.Soma_Principal);
                SomaTotal += Convert.ToDecimal(reg.Soma_Total);
            }

            StringBuilder sFullLanc = new StringBuilder();

            foreach (DebitoStructure Lanc in lstDebito) {
                if (sFullLanc.ToString().IndexOf(Lanc.Descricao_Lancamento) == -1) {
                    String DescLanc = Lanc.Descricao_Lancamento;
                    sFullLanc.Append(DescLanc + "/");
                }
            }
            sFullLanc.Remove(sFullLanc.Length - 1, 1);

            decimal nValorguia = Math.Truncate(Convert.ToDecimal(SomaTotal * 100));
            string NumBarra = dalCore.Gera2of5Cod((nValorguia).ToString(), Convert.ToDateTime(DataBoleto), Convert.ToInt32(nNumDoc), Convert.ToInt32(nCodigo));
            string numbarra2a = NumBarra.Substring(0, 13);
            string numbarra2b = NumBarra.Substring(13, 13);
            string numbarra2c = NumBarra.Substring(26, 13);
            string numbarra2d = NumBarra.Substring(39, 13);
            string strBarra = dalCore.Gera2of5Str(numbarra2a.Substring(0, 11) + numbarra2b.Substring(0, 11) + numbarra2c.Substring(0, 11) + numbarra2d.Substring(0, 11));
            string sBarra = dalCore.Mask(strBarra);
            
            foreach (DebitoStructure reg in lstDebito) {
                try {
                    Boleto regBoleto = new Boleto {
                        Usuario = "GTI.Web.Dam",
                        Computer = "Internet",
                        Sid = nSid,
                        Seq = Convert.ToInt16(Pos),
                        Inscricao = sInscricao,
                        Codreduzido = reg.Codigo_Reduzido.ToString(),
                        Nome = dalCore.Truncate(sNome.Trim(), 37, "..."),
                        Cpf = sCPF,
                        Endereco = dalCore.Truncate(sEndereco, 37, "..."),
                        Numimovel = Convert.ToInt16(nNumero),
                        Complemento = dalCore.Truncate(sComplemento, 27, "..."),
                        Bairro = dalCore.Truncate(sBairro, 27, "..."),
                        Cidade = sCidade,
                        Uf = sUF,
                        Quadra = dalCore.Truncate(sQuadra, 15, ""),
                        Lote = dalCore.Truncate(sLote, 10, ""),
                        Fulllanc = dalCore.Truncate(sFullLanc.ToString(), 1997, "..."),
                        Fulltrib = dalCore.Truncate(reg.Descricao_Tributo.Trim(), 1997, "..."),
                        Numdoc = sNumDoc,
                        Datadam = Convert.ToDateTime(DataBoleto),
                        Nomefunc = "GTI.Web",
                        Anoexercicio = reg.Ano_Exercicio,
                        Codlancamento = Convert.ToInt16(reg.Codigo_Lancamento),
                        Seqlancamento = Convert.ToInt16(reg.Sequencia_Lancamento),
                        Numparcela = Convert.ToInt16(reg.Numero_Parcela),
                        Codcomplemento = Convert.ToInt16(reg.Complemento),
                        Datavencto = Convert.ToDateTime(reg.Data_Vencimento),
                        Aj = reg.Data_Ajuizamento == null || reg.Data_Ajuizamento == DateTime.MinValue ? "N" : "S",
                        Da = reg.Ano_Exercicio == DateTime.Now.Year ? "N" : "S",
                        Principal = Convert.ToDecimal(reg.Soma_Principal),
                        Juros = Convert.ToDecimal(reg.Soma_Juros),
                        Multa = Convert.ToDecimal(reg.Soma_Multa),
                        Correcao = Convert.ToDecimal(reg.Soma_Correcao),
                        Total = Convert.ToDecimal(reg.Soma_Total),
                        Numdoc2 = sNumDoc2,
                        Digitavel = "",
                        Codbarra = sBarra,
                        Valordam = SomaTotal,
                        Valorprincdam = SomaPrincipal,
                        Numbarra2a = numbarra2a,
                        Numbarra2b = numbarra2b,
                        Numbarra2c = numbarra2c,
                        Numbarra2d = numbarra2d
                    };
                    GravaDam(regBoleto);
                    Pos++;
                } catch (SqlException ex) {
                    throw new Exception(ex.Message);
                } catch (Exception ex) {
                    throw new Exception(ex.Message);
                }
            }
            return nSid;
        }

        public void DeleteSid(int nSid) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Boletoguia.RemoveRange(db.Boletoguia.Where(i => i.Sid == nSid));
                    db.SaveChanges();
                    db.Boleto.RemoveRange(db.Boleto.Where(i => i.Sid == nSid));
                    db.SaveChanges();
                } catch (Exception ex) {
                    throw (ex.InnerException);
                }
            }
        }

        public void GravaDam(Boleto Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Boleto.Add(Reg);
                    db.SaveChanges();
                    return;
                } catch (Exception ex) {
                    throw (ex.InnerException);
                }
            }
        }

        public bool Existe_Comercio_Eletronico(int nNumDocumento) {
            bool bRet = false;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var existingReg = db.Comercio_eletronico.Where(a => a.Numdoc > 1).Count(a => a.Numdoc == nNumDocumento);
                if (existingReg != 0) {
                    bRet = true;
                }
            }
            return bRet;
        }

        public Exception Insert_Boleto_Comercio_Eletronico(comercio_eletronico Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Comercio_eletronico.Add(Reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Numdocumento Retorna_Dados_Documento(int nNumDocumento) {
            Numdocumento reg;
            using (GTI_Context db = new GTI_Context(_connection)) {
                reg = (from m in db.Numdocumento where m.numdocumento == nNumDocumento select m).FirstOrDefault();
            }
            return reg;
        }

        public int Retorna_Codigo_Certidao(TipoCertidao tipo_certidao) {
            int nRet = 0;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from p in db.Parametros select p);
                if (tipo_certidao == TipoCertidao.Endereco)
                    Sql = Sql.Where(c => c.Nomeparam == "CETEND");
                else {
                    if (tipo_certidao == TipoCertidao.ValorVenal)
                        Sql = Sql.Where(c => c.Nomeparam == "CETVVN");
                    else {
                        if (tipo_certidao == TipoCertidao.Isencao)
                            Sql = Sql.Where(c => c.Nomeparam == "CETISE");
                        else {
                            if (tipo_certidao == TipoCertidao.Debito)
                                Sql = Sql.Where(c => c.Nomeparam == "CDB");
                            else {
                                if (tipo_certidao == TipoCertidao.Comprovante_Pagamento)
                                    Sql = Sql.Where(c => c.Nomeparam == "CPAGTO");
                                else {
                                    if (tipo_certidao == TipoCertidao.Alvara)
                                        Sql = Sql.Where(c => c.Nomeparam == "ALVARA");
                                    else {
                                        if (tipo_certidao == TipoCertidao.Debito_Doc)
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
            }
            Exception ex = Atualiza_Codigo_Certidao(tipo_certidao, nRet);
            if (ex == null)
                return nRet;
            else
                return 0;
        }

        private Exception Atualiza_Codigo_Certidao(TipoCertidao tipo_certidao,int Valor) {
            Parametros p=null;
            using (GTI_Context db = new GTI_Context(_connection)) {
                if(tipo_certidao==TipoCertidao.Endereco)
                    p = db.Parametros.First(i => i.Nomeparam == "CETEND");
                else {
                    if (tipo_certidao == TipoCertidao.ValorVenal)
                        p = db.Parametros.First(i => i.Nomeparam == "CETVVN");
                    else {
                        if (tipo_certidao == TipoCertidao.Isencao)
                            p = db.Parametros.First(i => i.Nomeparam == "CETISE");
                        else {
                            if (tipo_certidao == TipoCertidao.Debito)
                                p = db.Parametros.First(i => i.Nomeparam == "CDB");
                            else {
                                if (tipo_certidao == TipoCertidao.Comprovante_Pagamento)
                                    p = db.Parametros.First(i => i.Nomeparam == "CPAGTO");
                                else {
                                    if (tipo_certidao == TipoCertidao.Alvara)
                                        p = db.Parametros.First(i => i.Nomeparam == "ALVARA");
                                    else {
                                        if (tipo_certidao == TipoCertidao.Debito_Doc)
                                            p = db.Parametros.First(i => i.Nomeparam == "CDB_DOC");
                                    }
                                }
                            }
                        }
                    }
                }
                p.Valparam = Valor.ToString();
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Comprovante_Pagamento(Comprovante_pagamento Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                object[] Parametros = new object[10];
                Parametros[0] = new SqlParameter { ParameterName = "@Ano", SqlDbType = SqlDbType.Int, SqlValue = Reg.Ano };
                Parametros[1] = new SqlParameter { ParameterName = "@Numero", SqlDbType = SqlDbType.Int, SqlValue = Reg.Numero };
                Parametros[2] = new SqlParameter { ParameterName = "@Controle", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Controle };
                Parametros[3] = new SqlParameter { ParameterName = "@Data_emissao", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Data_emissao };
                Parametros[4] = new SqlParameter { ParameterName = "@Banco", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Numero };
                Parametros[5] = new SqlParameter { ParameterName = "@Nome", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Nome };
                Parametros[6] = new SqlParameter { ParameterName = "@Data_pagamento", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Data_pagamento };
                Parametros[7] = new SqlParameter { ParameterName = "@Valor", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Valor };
                Parametros[8] = new SqlParameter { ParameterName = "@Documento", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Documento };
                Parametros[9] = new SqlParameter { ParameterName = "@Cpfcnpj", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cpfcnpj };

                db.Database.ExecuteSqlCommand("INSERT INTO comprovante_pagamento(ano,numero,controle,data_emissao,banco,nome,data_pagamento,valor,documento,cpfcnpj) VALUES(@ano,@numero," +
                                              "@controle,@data_emissao,@banco,@nome,@data_pagamento,@valor,@documento,@cpfcnpj)", Parametros);

                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Certidao_Endereco(Certidao_endereco Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Certidao_endereco.Add(Reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Certidao_ValorVenal(Certidao_valor_venal Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Certidao_valor_venal.Add(Reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Certidao_Isencao(Certidao_isencao Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Certidao_isencao.Add(Reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Alvara_Funcionamento(Alvara_funcionamento Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                object[] Parametros = new object[12];
                Parametros[0] = new SqlParameter { ParameterName = "@Ano", SqlDbType = SqlDbType.Int, SqlValue = Reg.Ano };
                Parametros[1] = new SqlParameter { ParameterName = "@Numero", SqlDbType = SqlDbType.Int, SqlValue = Reg.Numero };
                Parametros[2] = new SqlParameter { ParameterName = "@Controle", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Controle };
                Parametros[3] = new SqlParameter { ParameterName = "@Codigo", SqlDbType = SqlDbType.Int, SqlValue = Reg.Codigo };
                Parametros[4] = new SqlParameter { ParameterName = "@Razao_Social", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Razao_social };
                Parametros[5] = new SqlParameter { ParameterName = "@Documento", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Documento };
                Parametros[6] = new SqlParameter { ParameterName = "@Endereco", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Endereco };
                Parametros[7] = new SqlParameter { ParameterName = "@Bairro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Bairro };
                Parametros[8] = new SqlParameter { ParameterName = "@Atividade", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Atividade };
                Parametros[9] = new SqlParameter { ParameterName = "@Horario", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Horario };
                Parametros[10] = new SqlParameter { ParameterName = "@Validade", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Validade };
                Parametros[11] = new SqlParameter { ParameterName = "@Data_gravada", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Data_Gravada };
                db.Database.ExecuteSqlCommand("INSERT INTO Alvara_Funcionamento(ano,numero,controle,codigo,razao_social,documento,endereco,bairro,atividade,horario,validade,data_gravada) VALUES(@ano,@numero," +
                                              "@controle,@codigo,@razao_social,@documento,@endereco,@bairro,@atividade,@horario,@validade,@data_gravada)", Parametros);
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Certidao_endereco Retorna_Certidao_Endereco(int Ano,int Numero,int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from p in db.Certidao_endereco where p.Ano == Ano && p.Numero == Numero && p.Codigo == Codigo select p).FirstOrDefault();
                return Sql;
            }
        }

        public Certidao_valor_venal Retorna_Certidao_ValorVenal(int Ano, int Numero, int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from p in db.Certidao_valor_venal where p.Ano == Ano && p.Numero == Numero && p.Codigo == Codigo select p).FirstOrDefault();
                return Sql;
            }
        }

        public Certidao_isencao Retorna_Certidao_Isencao(int Ano, int Numero, int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from p in db.Certidao_isencao where p.Ano == Ano && p.Numero == Numero && p.Codigo == Codigo select p).FirstOrDefault();
                return Sql;
            }
        }

        public Exception Insert_Certidao_Debito(Certidao_debito Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Certidao_debito.Add(Reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Certidao_Debito_Doc(certidao_debito_doc Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Certidao_debito_doc.Add(Reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Certidao_Inscricao(Certidao_inscricao Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Certidao_inscricao.Add(Reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Certidao_debito Retorna_Certidao_Debito(int Ano, int Numero, int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from p in db.Certidao_debito where p.Ano == Ano && p.Numero == Numero && p.Codigo == Codigo select p).FirstOrDefault();
                return Sql;
            }
        }

        public certidao_debito_doc Retorna_Certidao_Debito_Doc(string Validacao) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from p in db.Certidao_debito_doc where p.Validacao == Validacao select p).FirstOrDefault();
                return Sql;
            }
        }

        public Certidao_inscricao Retorna_Certidao_Inscricao(int Ano, int Numero, int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from p in db.Certidao_inscricao where p.Ano == Ano && p.Numero == Numero && p.Cadastro == Codigo select p).FirstOrDefault();
                return Sql;
            }
        }

        public Certidao_debito_detalhe Certidao_Debito(int Codigo) {
            TipoCadastro _tipo_Cadastro = Codigo < 100000 ? TipoCadastro.Imovel : Codigo >= 500000 ? TipoCadastro.Cidadao : TipoCadastro.Empresa;
            Certidao_debito_detalhe Certidao = new Certidao_debito_detalhe();
            List<SpExtrato> ListaTributo = Lista_Extrato_Tributo(Codigo, 1980, 2050, 0, 99, 0, 99, 0, 999, 0, 99, 0, 99, DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", null), "Web");
       
            ArrayList alArrayNaoPagoVencido = new ArrayList();
            ArrayList alArrayParceladoAVencer = new ArrayList();
            ArrayList alArraySuspenso = new ArrayList();
            ArrayList alArrayResult = new ArrayList();

            string _descricao_lancamento = "";
            string sDescTmp="";

            if (ListaTributo.Count > 0) {
                bool bNaoPagoVencido = false;
                bool bParceladoAVencer = false;
                bool bSuspenso = false;

                foreach (var item in ListaTributo) { 
                    bool bFind = false;
                    sDescTmp = item.Abrevtributo;
                    if (item.Codlancamento==29)
                        sDescTmp = "IPTU";

                    //Verifica o status
                    //*** não pagos
                    TimeSpan difference =DateTime.Now- item.Datavencimento ;
                    var days = difference.TotalDays;
                    if ((item.Statuslanc == 3 | item.Statuslanc== 18 | item.Statuslanc == 42 | item.Statuslanc == 43 | item.Statuslanc == 38 | item.Statuslanc == 39) && days>1) {
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
                            if(item.Codtributo==26 || item.Codtributo==90 || item.Codtributo==112 || item.Codtributo==113||item.Codtributo==585 || item.Codtributo == 587 || item.Codtributo==24 ||item.Codtributo==28 ) {
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
                    if (_tipo_Cadastro == TipoCadastro.Imovel) {
                        _descricao_lancamento = "Débitos Imobiliários";
                    } else {
                        if (_tipo_Cadastro == TipoCadastro.Empresa) {
                            _descricao_lancamento = "Débitos Mobiliários";
                        } else {
                            _descricao_lancamento = "Débitos do Contribuinte";
                        }
                    }
                }

                if (bNaoPagoVencido)
                    Certidao.Tipo_Retorno = RetornoCertidaoDebito.Positiva;
                else {
                    //Verifica se tem débito suspenso/julgamento
                    if (bSuspenso)
                        Certidao.Tipo_Retorno = RetornoCertidaoDebito.NegativaPositiva;
                    else {
                        //Verifica se tem parcelamento
                        if(bParceladoAVencer)
                            Certidao.Tipo_Retorno = RetornoCertidaoDebito.NegativaPositiva;
                        else
                            Certidao.Tipo_Retorno = RetornoCertidaoDebito.Negativa;
                    }
                }
            } else {
                //Código sem lançamentos, emite negativa
                Certidao.Descricao_Lancamentos = "";
                Certidao.Tipo_Retorno = RetornoCertidaoDebito.Negativa;
            }

            Certidao.Descricao_Lancamentos = _descricao_lancamento;
            return Certidao;
        }

        public SpCalculo Calculo_IPTU(int Codigo, int Ano) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var prmCodigo = new SqlParameter { ParameterName = "@Codigo", SqlDbType = SqlDbType.Int, SqlValue = Codigo };
                var prmAno = new SqlParameter { ParameterName = "@Ano", SqlDbType = SqlDbType.Int, SqlValue = Ano };
                SpCalculo result = db.SpCalculo.SqlQuery("EXEC spCalculo @Codigo, @Ano ", prmCodigo, prmAno).FirstOrDefault();
                return result;
            }
        }

        public int Competencias_Nao_Encerradas(List<CompetenciaISS>Lista) {
            int nCount = 0, nFill = 0;
            if (Lista == null)
                return 0;
            for (int i = 0; i < Lista.Count; i++) {
                if (Lista[i].Encerrada == false)
                    if (Lista[i].Mes_Competencia == DateTime.Now.Month - 1 && DateTime.Now.Day < 16)
                        nFill++; //just BS
                    else
                        nCount++;
            }
            return nCount;
        }

        public Exception Insert_Certidao_Inscricao_Extrato(Certidao_inscricao_extrato Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Certidao_inscricao_extrato.Add(Reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public DebitoPagoStruct Retorna_DebitoPago_Documento(int nNumDocumento) {
            DebitoPagoStruct ret = null;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from m in db.Debitopago
                           join b in db.Banco on m.Codbanco equals b.Codbanco into bm from b in bm.DefaultIfEmpty()
                           where m.Numdocumento == nNumDocumento select new DebitoPagoStruct { Ano = m.Anoexercicio,Banco_Codigo=m.Codbanco,Banco_Nome=b.Nomebanco,
                           Codigo=m.Codreduzido,Codigo_Agencia=m.Codagencia,Complemento=m.Codcomplemento,Data_Pagamento=m.Datapagamento,Data_Recebimento=m.Datarecebimento,
                           Lancamento=m.Codlancamento,Parcela=m.Numparcela,Restituido=m.Restituido,Sequencia=m.Seqlancamento,Sequencia_Pagamento=m.Seqpag,Valor_Pago=m.Valorpago,Valor_Pago_Real=m.Valorpagoreal});

                foreach (DebitoPagoStruct item in reg) {
                    ret = new DebitoPagoStruct {
                        Codigo = item.Codigo,
                        Ano = item.Ano,
                        Banco_Codigo = item.Banco_Codigo,
                        Banco_Nome = item.Banco_Nome,
                        Codigo_Agencia = item.Codigo_Agencia,
                        Complemento = item.Complemento,
                        Data_Pagamento = item.Data_Pagamento,
                        Data_Recebimento = item.Data_Recebimento,
                        Lancamento = item.Lancamento,
                        Numero_Documento = item.Numero_Documento,
                        Parcela = item.Parcela,
                        Restituido = item.Restituido,
                        Sequencia = item.Sequencia,
                        Sequencia_Pagamento = item.Sequencia_Pagamento,
                        Valor_Pago = item.Valor_Pago,
                        Valor_Pago_Real = item.Valor_Pago_Real
                    };
                }           

                return ret;
            }
        }

        public Exception Insert_Carta_Cobranca(Carta_cobranca Reg) {
            using(var db=new GTI_Context(_connection)) {
                object[] Parametros = new object[28];
                Parametros[0] = new SqlParameter { ParameterName = "@remessa", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Remessa };
                Parametros[1] = new SqlParameter { ParameterName = "@codigo", SqlDbType = SqlDbType.Int, SqlValue = Reg.Codigo };
                Parametros[2] = new SqlParameter { ParameterName = "@parcela", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Parcela };
                Parametros[3] = new SqlParameter { ParameterName = "@total_parcela", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Total_Parcela };
                Parametros[4] = new SqlParameter { ParameterName = "@parcela_label", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Parcela_Label };
                Parametros[5] = new SqlParameter { ParameterName = "@nome", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Nome };
                Parametros[6] = new SqlParameter { ParameterName = "@cpf_cnpj", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cpf_cnpj };
                Parametros[7] = new SqlParameter { ParameterName = "@endereco", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Endereco };
                Parametros[8] = new SqlParameter { ParameterName = "@bairro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Bairro };
                Parametros[9] = new SqlParameter { ParameterName = "@cidade", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cidade };
                Parametros[10] = new SqlParameter { ParameterName = "@cep", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cep };
                Parametros[11] = new SqlParameter { ParameterName = "@endereco_entrega", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Endereco_Entrega };
                Parametros[12] = new SqlParameter { ParameterName = "@bairro_entrega", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Bairro_Entrega };
                Parametros[13] = new SqlParameter { ParameterName = "@cidade_entrega", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cidade_Entrega };
                Parametros[14] = new SqlParameter { ParameterName = "@cep_entrega", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cep_Entrega };
                Parametros[15] = new SqlParameter { ParameterName = "@data_vencimento", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Data_Vencimento };
                Parametros[16] = new SqlParameter { ParameterName = "@data_documento", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Data_Documento };
                Parametros[17] = new SqlParameter { ParameterName = "@inscricao", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Inscricao };
                Parametros[18] = new SqlParameter { ParameterName = "@lote", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Lote };
                Parametros[19] = new SqlParameter { ParameterName = "@quadra", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Quadra };
                Parametros[20] = new SqlParameter { ParameterName = "@atividade", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Atividade };
                Parametros[21] = new SqlParameter { ParameterName = "@numero_documento", SqlDbType = SqlDbType.Int, SqlValue = Reg.Numero_Documento };
                Parametros[22] = new SqlParameter { ParameterName = "@nosso_numero", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Nosso_Numero };
                Parametros[23] = new SqlParameter { ParameterName = "@valor_boleto", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Valor_Boleto };
                Parametros[24] = new SqlParameter { ParameterName = "@digitavel", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Digitavel };
                Parametros[25] = new SqlParameter { ParameterName = "@codbarra", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Codbarra };
                Parametros[26] = new SqlParameter { ParameterName = "@Cep_entrega_cod", SqlDbType = SqlDbType.Int, SqlValue = Reg.Cep_entrega_cod };
                Parametros[27] = new SqlParameter { ParameterName = "@Lancamento", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Lancamento };

                db.Database.ExecuteSqlCommand("INSERT INTO carta_cobranca(remessa,codigo,parcela,total_parcela,parcela_label,nome,cpf_cnpj,endereco,bairro,cidade,cep,endereco_entrega,bairro_entrega,cidade_entrega,cep_entrega,data_vencimento," +
                    "data_documento,inscricao,lote,quadra,atividade,numero_documento,nosso_numero,valor_boleto,digitavel,codbarra,Cep_entrega_cod,Lancamento) VALUES(@remessa,@codigo,@parcela,@total_parcela,@parcela_label,@nome,@cpf_cnpj,@endereco,@bairro," +
                    "@cidade,@cep,@endereco_entrega,@bairro_entrega,@cidade_entrega,@cep_entrega,@data_vencimento,@data_documento,@inscricao,@lote,@quadra,@atividade,@numero_documento,@nosso_numero,@valor_boleto,@digitavel,@codbarra,@Cep_entrega_cod,@Lancamento)", Parametros);

                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Carta_Cobranca_Exclusao(Carta_cobranca_exclusao Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                object[] Parametros = new object[2];
                Parametros[0] = new SqlParameter { ParameterName = "@remessa", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Remessa };
                Parametros[1] = new SqlParameter { ParameterName = "@codigo", SqlDbType = SqlDbType.Int, SqlValue = Reg.Codigo };
                db.Database.ExecuteSqlCommand("INSERT INTO carta_cobranca_exclusao(remessa,codigo) VALUES(@remessa,@codigo)", Parametros);

                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Excluir_Carta_Cobranca(int Remessa) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Carta_cobranca_exclusao.RemoveRange(db.Carta_cobranca_exclusao.Where(i => i.Remessa == Remessa));
                    db.SaveChanges();
                    db.Carta_cobranca_detalhe.RemoveRange(db.Carta_cobranca_detalhe.Where(i => i.Remessa == Remessa));
                    db.SaveChanges();
                    db.Carta_cobranca.RemoveRange(db.Carta_cobranca.Where(i => i.Remessa == Remessa));
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Carta_Cobranca_Detalhe(Carta_cobranca_detalhe Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                object[] Parametros = new object[10];
                Parametros[0] = new SqlParameter { ParameterName = "@remessa", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Remessa };
                Parametros[1] = new SqlParameter { ParameterName = "@codigo", SqlDbType = SqlDbType.Int, SqlValue = Reg.Codigo };
                Parametros[2] = new SqlParameter { ParameterName = "@parcela", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Parcela };
                Parametros[3] = new SqlParameter { ParameterName = "@ano", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Ano };
                Parametros[4] = new SqlParameter { ParameterName = "@principal", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Principal };
                Parametros[5] = new SqlParameter { ParameterName = "@juros", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Juros };
                Parametros[6] = new SqlParameter { ParameterName = "@multa", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Multa };
                Parametros[7] = new SqlParameter { ParameterName = "@correcao", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Correcao };
                Parametros[8] = new SqlParameter { ParameterName = "@total", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Total };
                Parametros[9] = new SqlParameter { ParameterName = "@ordem", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Ordem };

                db.Database.ExecuteSqlCommand("INSERT INTO carta_cobranca_detalhe(remessa,codigo,parcela,ano,principal,juros,multa,correcao,total,ordem) " +
                    "VALUES(@remessa,@codigo,@parcela,@ano,@principal,@juros,@multa,@correcao,@total,@ordem)", Parametros);

                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public List<Carta_cobranca> Lista_Carta_Cobranca(int s) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from t in db.Carta_cobranca  orderby t.Numero_Documento select new { t.Bairro, t.Cep,t.Cidade,t.Codigo,t.Cpf_cnpj,t.Data_Documento,
                    t.Data_Vencimento,t.Endereco,t.Nome,t.Nosso_Numero,t.Numero_Documento,t.Valor_Boleto }).ToList();
                List<Carta_cobranca> Lista = new List<Carta_cobranca>();
                foreach (var item in reg) {
                    Carta_cobranca Linha = new Carta_cobranca {
                        Bairro=item.Bairro,
                        Cep=item.Cep,
                        Cidade=item.Cidade,
                        Codigo = item.Codigo,
                        Cpf_cnpj=item.Cpf_cnpj,
                        Data_Documento=item.Data_Documento,
                        Data_Vencimento=item.Data_Vencimento,
                        Endereco=item.Endereco,
                        Nome=item.Nome,
                        Nosso_Numero=item.Nosso_Numero,
                        Numero_Documento=item.Numero_Documento,
                        Valor_Boleto = item.Valor_Boleto
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public Exception Insert_Calculo_Resumo(Calculo_resumo Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                object[] Parametros = new object[15];
                Parametros[0] = new SqlParameter { ParameterName = "@ano", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Ano };
                Parametros[1] = new SqlParameter { ParameterName = "@codigo", SqlDbType = SqlDbType.Int, SqlValue = Reg.Codigo };
                Parametros[2] = new SqlParameter { ParameterName = "@lancamento", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Lancamento };
                Parametros[3] = new SqlParameter { ParameterName = "@qtde_parcela", SqlDbType = SqlDbType.TinyInt, SqlValue = Reg.Qtde_parcela };
                Parametros[4] = new SqlParameter { ParameterName = "@valor0", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Valor0 };
                Parametros[5] = new SqlParameter { ParameterName = "@valor1", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Valor1 };
                Parametros[6] = new SqlParameter { ParameterName = "@documento0", SqlDbType = SqlDbType.Int, SqlValue = Reg.Documento0 };
                Parametros[7] = new SqlParameter { ParameterName = "@documento1", SqlDbType = SqlDbType.Int, SqlValue = Reg.Documento1 };
                Parametros[8] = new SqlParameter { ParameterName = "@vencimento1", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Vencimento1 };
                Parametros[9] = new SqlParameter { ParameterName = "@documento2", SqlDbType = SqlDbType.Int, SqlValue = Reg.Documento2 };
                Parametros[10] = new SqlParameter { ParameterName = "@vencimento2", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Vencimento2 };
                Parametros[11] = new SqlParameter { ParameterName = "@documento3", SqlDbType = SqlDbType.Int, SqlValue = (object)Reg.Documento3??DBNull.Value};
                Parametros[12] = new SqlParameter { ParameterName = "@vencimento3", SqlDbType = SqlDbType.SmallDateTime, SqlValue = (object)Reg.Vencimento3 ?? DBNull.Value };
                Parametros[13] = new SqlParameter { ParameterName = "@documento4", SqlDbType = SqlDbType.Int, SqlValue = (object)Reg.Documento4 ?? DBNull.Value };
                Parametros[14] = new SqlParameter { ParameterName = "@vencimento4", SqlDbType = SqlDbType.SmallDateTime, SqlValue = (object)Reg.Vencimento4 ?? DBNull.Value };

                db.Database.ExecuteSqlCommand("INSERT INTO calculo_resumo(ano,codigo,lancamento,qtde_parcela,valor0,valor1,documento0,documento1," +
                    "vencimento1,documento2,vencimento2,documento3,vencimento3,documento4,vencimento4) " +
                    "VALUES(@ano,@codigo,@lancamento,@qtde_parcela,@valor0,@valor1,@documento0,@documento1,@vencimento1,@documento2," +
                    "@vencimento2,@documento3,@vencimento3,@documento4,@vencimento4)", Parametros);

                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public decimal Retorna_Valor_Tributo(int Ano,int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                decimal Sql = (from t in db.Tributoaliquota where t.Ano==Ano && t.Codtributo==Codigo select t.Valoraliq).FirstOrDefault();
                return Sql;
            }
        }

        public List<DebitoStructure> Lista_Parcelas_Taxa(int nCodigo, int nAno) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                DateTime dDataBase = Convert.ToDateTime("01/01/2020");
                //Retornar a lista das parcelas registradas
                var reg = (from dp in db.Debitoparcela
                           join dt in db.Debitotributo on new { p1 = dp.Codreduzido, p2 = dp.Anoexercicio, p3 = dp.Codlancamento, p4 = dp.Seqlancamento, p5 = dp.Numparcela, p6 = dp.Codcomplemento }
                                                   equals new { p1 = dt.Codreduzido, p2 = dt.Anoexercicio, p3 = dt.Codlancamento, p4 = dt.Seqlancamento, p5 = dt.Numparcela, p6 = dt.Codcomplemento } into dpdt from dt in dpdt.DefaultIfEmpty()
                           join pd in db.Parceladocumento on new { p1 = dp.Codreduzido, p2 = dp.Anoexercicio, p3 = dp.Codlancamento, p4 = dp.Seqlancamento, p5 = dp.Numparcela, p6 = dp.Codcomplemento }
                                                      equals new { p1 = pd.Codreduzido, p2 = pd.Anoexercicio, p3 = pd.Codlancamento, p4 = pd.Seqlancamento, p5 = pd.Numparcela, p6 = pd.Codcomplemento } into dppd from pd in dppd.DefaultIfEmpty()
                           join nd in db.Numdocumento on pd.Numdocumento equals nd.numdocumento
                           where dp.Codreduzido == nCodigo && dp.Anoexercicio == nAno && dp.Codlancamento == 6  && (dp.Statuslanc == 3 || dp.Statuslanc == 18) && dp.Datavencimento >= DateTime.Now && dp.Datadebase==dDataBase
                           orderby new { dp.Numparcela, dp.Codcomplemento }
                           select new { dp.Codreduzido, dp.Anoexercicio, dp.Codlancamento, dp.Seqlancamento, dp.Numparcela, dp.Codcomplemento, dp.Datavencimento, dt.Valortributo, pd.Numdocumento, nd.Datadocumento });

                List<DebitoStructure> Lista = new List<DebitoStructure>();
                foreach (var query in reg) {
                    foreach (DebitoStructure item in Lista) {
                        if (item.Numero_Parcela == query.Numparcela && item.Complemento == query.Codcomplemento)
                            goto Proximo;
                    }
                    DebitoStructure Linha = new DebitoStructure {
                        Codigo_Reduzido = query.Codreduzido,
                        Ano_Exercicio = query.Anoexercicio,
                        Codigo_Lancamento = query.Codlancamento,
                        Sequencia_Lancamento = query.Seqlancamento,
                        Numero_Parcela = query.Numparcela,
                        Complemento = query.Codcomplemento,
                        Soma_Principal = Convert.ToDecimal(query.Valortributo),
                        Data_Vencimento = query.Datavencimento,
                        Numero_Documento = query.Numdocumento,
                        Data_Base = Convert.ToDateTime(query.Datadocumento)
                    };
                    Lista.Add(Linha);
Proximo:;
                }

                return Lista;
            }
        }

        public List<DebitoStructure> Lista_Parcelas_Iss_Fixo(int nCodigo, int nAno) {
            DateTime dDataBase = Convert.ToDateTime("01/01/2020");
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from dp in db.Debitoparcela
                           join dt in db.Debitotributo on new { p1 = dp.Codreduzido, p2 = dp.Anoexercicio, p3 = dp.Codlancamento, p4 = dp.Seqlancamento, p5 = dp.Numparcela, p6 = dp.Codcomplemento }
                                                   equals new { p1 = dt.Codreduzido, p2 = dt.Anoexercicio, p3 = dt.Codlancamento, p4 = dt.Seqlancamento, p5 = dt.Numparcela, p6 = dt.Codcomplemento } into dpdt from dt in dpdt.DefaultIfEmpty()
                           join pd in db.Parceladocumento on new { p1 = dp.Codreduzido, p2 = dp.Anoexercicio, p3 = dp.Codlancamento, p4 = dp.Seqlancamento, p5 = dp.Numparcela, p6 = dp.Codcomplemento }
                                                      equals new { p1 = pd.Codreduzido, p2 = pd.Anoexercicio, p3 = pd.Codlancamento, p4 = pd.Seqlancamento, p5 = pd.Numparcela, p6 = pd.Codcomplemento } into dppd from pd in dppd.DefaultIfEmpty()
                           join nd in db.Numdocumento on pd.Numdocumento equals nd.numdocumento
                           where dp.Codreduzido == nCodigo && dp.Anoexercicio == nAno && dp.Codlancamento == 14 &&  (dp.Statuslanc == 3 || dp.Statuslanc == 18) && dp.Datavencimento >= DateTime.Now && dp.Datadebase == dDataBase
                           orderby new { dp.Numparcela, dp.Codcomplemento }
                           select new { dp.Codreduzido, dp.Anoexercicio, dp.Codlancamento, dp.Seqlancamento, dp.Numparcela, dp.Codcomplemento, dp.Datavencimento, dt.Valortributo, pd.Numdocumento, nd.Datadocumento,nd.Registrado });

                List<DebitoStructure> Lista = new List<DebitoStructure>();
                foreach (var query in reg) {
                    foreach (DebitoStructure item in Lista) {
                        if (item.Numero_Parcela == query.Numparcela && item.Complemento == query.Codcomplemento)
                            goto Proximo;
                    }
                    DebitoStructure Linha = new DebitoStructure {
                        Codigo_Reduzido = query.Codreduzido,
                        Ano_Exercicio = query.Anoexercicio,
                        Codigo_Lancamento = query.Codlancamento,
                        Sequencia_Lancamento = query.Seqlancamento,
                        Numero_Parcela = query.Numparcela,
                        Complemento = query.Codcomplemento,
                        Soma_Principal = Convert.ToDecimal(query.Valortributo),
                        Data_Vencimento = query.Datavencimento,
                        Numero_Documento = query.Numdocumento,
                        Data_Base = Convert.ToDateTime(query.Datadocumento),
                        Registrado = query.Registrado
                    };
                    Lista.Add(Linha);

Proximo:;
                }
                return Lista;
            }
        }

        public Exception Marcar_Documento_Registrado(int _documento) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Numdocumento d = db.Numdocumento.First(i => i.numdocumento == _documento);
                d.Registrado = true;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Ficha_Compensacao_Documento(Ficha_compensacao_documento Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Database.ExecuteSqlCommand("INSERT INTO ficha_compensacao_documento(numero_documento,data_vencimento,valor_documento,nome,cpf,endereco,bairro,cep,cidade,uf) " +
                        "VALUES(@numero_documento, @data_vencimento,@valor_documento,@nome,@cpf,@endereco,@bairro,@cep,@cidade,@uf)",
                        new SqlParameter("@numero_documento", Reg.Numero_documento),
                        new SqlParameter("@data_vencimento", Reg.Data_vencimento),
                        new SqlParameter("@valor_documento", Reg.Valor_documento),
                        new SqlParameter("@nome", Reg.Nome),
                        new SqlParameter("@cpf", Reg.Cpf),
                        new SqlParameter("@endereco", Reg.Endereco),
                        new SqlParameter("@bairro", Reg.Bairro),
                        new SqlParameter("@cep", Reg.Cep),
                        new SqlParameter("@cidade", Reg.Cidade),
                        new SqlParameter("@uf", Reg.Uf));
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public List<DebitoStructure> Lista_Parcelas_Vigilancia(int nCodigo, int nAno) {
            DateTime dDataBase = Convert.ToDateTime("01/01/2020");
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from dp in db.Debitoparcela
                           join dt in db.Debitotributo on new { p1 = dp.Codreduzido, p2 = dp.Anoexercicio, p3 = dp.Codlancamento, p4 = dp.Seqlancamento, p5 = dp.Numparcela, p6 = dp.Codcomplemento }
                                                   equals new { p1 = dt.Codreduzido, p2 = dt.Anoexercicio, p3 = dt.Codlancamento, p4 = dt.Seqlancamento, p5 = dt.Numparcela, p6 = dt.Codcomplemento } into dpdt from dt in dpdt.DefaultIfEmpty()
                           join pd in db.Parceladocumento on new { p1 = dp.Codreduzido, p2 = dp.Anoexercicio, p3 = dp.Codlancamento, p4 = dp.Seqlancamento, p5 = dp.Numparcela, p6 = dp.Codcomplemento }
                                                      equals new { p1 = pd.Codreduzido, p2 = pd.Anoexercicio, p3 = pd.Codlancamento, p4 = pd.Seqlancamento, p5 = pd.Numparcela, p6 = pd.Codcomplemento } into dppd from pd in dppd.DefaultIfEmpty()
                           join nd in db.Numdocumento on pd.Numdocumento equals nd.numdocumento
                           where dp.Codreduzido == nCodigo && dp.Anoexercicio == nAno && dp.Codlancamento == 13 && dp.Seqlancamento == 0 && (dp.Statuslanc == 3 || dp.Statuslanc == 18) && dp.Datadebase == dDataBase && dp.Datavencimento >= DateTime.Now
                           orderby new { dp.Numparcela, dp.Codcomplemento }
                           select new { dp.Codreduzido, dp.Anoexercicio, dp.Codlancamento, dp.Seqlancamento, dp.Numparcela, dp.Codcomplemento, dp.Datavencimento, dt.Valortributo, pd.Numdocumento, nd.Datadocumento });

                List<DebitoStructure> Lista = new List<DebitoStructure>();
                foreach (var query in reg) {
                    foreach (DebitoStructure item in Lista) {
                        if (item.Numero_Parcela == query.Numparcela && item.Complemento == query.Codcomplemento)
                            goto Proximo;
                    }
                    DebitoStructure Linha = new DebitoStructure {
                        Codigo_Reduzido = query.Codreduzido,
                        Ano_Exercicio = query.Anoexercicio,
                        Codigo_Lancamento = query.Codlancamento,
                        Sequencia_Lancamento = query.Seqlancamento,
                        Numero_Parcela = query.Numparcela,
                        Complemento = query.Codcomplemento,
                        Soma_Principal = Convert.ToDecimal(query.Valortributo),
                        Data_Vencimento = query.Datavencimento,
                        Numero_Documento = query.Numdocumento,
                        Data_Base = Convert.ToDateTime(query.Datadocumento)
                    };
                    Lista.Add(Linha);
Proximo:;
                }
                return Lista;
            }
        }

        public List<Documento_parcela_valor> Lista_Detalhe_Documento(int Numero) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var sql = from p in db.Parceladocumento join d in db.Debitoparcela on new { p1 = p.Codreduzido, p2 = p.Anoexercicio, p3 = p.Codlancamento, p4 = p.Seqlancamento, p5 = p.Numparcela, p6 = p.Codcomplemento }
                          equals new { p1 = d.Codreduzido, p2 = d.Anoexercicio, p3 = d.Codlancamento, p4 = d.Seqlancamento, p5 = d.Numparcela, p6 = d.Codcomplemento } into dp from d in dp
                          join t in db.Debitotributo on new { p1 = d.Codreduzido, p2 = d.Anoexercicio, p3 = d.Codlancamento, p4 = d.Seqlancamento, p5 = d.Numparcela, p6 = d.Codcomplemento }
                          equals new { p1 = t.Codreduzido, p2 = t.Anoexercicio, p3 = t.Codlancamento, p4 = t.Seqlancamento, p5 = t.Numparcela, p6 = t.Codcomplemento } into pt from t in pt
                          join l in db.Lancamento on d.Codlancamento equals l.Codlancamento into pl from l in pl
                          where p.Numdocumento == Numero
                          orderby d.Codreduzido, d.Anoexercicio, d.Codlancamento, d.Seqlancamento, d.Numparcela, d.Codcomplemento select new Documento_parcela_valor {Codigo=d.Codreduzido,Ano=d.Anoexercicio,
                          Lancamento_codigo =d.Codlancamento,Sequencia=d.Seqlancamento,Parcela=d.Numparcela,Complemento=(byte)d.Codlancamento,Valor_parcela=(decimal)t.Valortributo,Data_vencimento=d.Datavencimento,Lancamento_nome=l.Descreduz };

                List<Documento_parcela_valor> Lista = new List<Documento_parcela_valor>();
                int _pos = -1;
                foreach (var reg in sql) {
                    bool _find = false;
                    foreach (Documento_parcela_valor item in Lista) {
                        if(item.Codigo==reg.Codigo && item.Ano==reg.Ano && item.Lancamento_codigo==reg.Lancamento_codigo && item.Sequencia==reg.Sequencia && item.Parcela==reg.Parcela && item.Complemento == reg.Complemento) {
                            _find = true;
                            break;
                        }
                    }
                    if (!_find) {
                        Lista.Add(reg);
                        _pos++;
                    } else
                        Lista[_pos].Valor_parcela += reg.Valor_parcela;
                    
                }
                return Lista;
            }
        }

        public bool InSerasa(int Codigo) {
            bool bRet = false;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var existingReg = db.Serasa.Count(a => a.Codigo == Codigo && a.Dtsaida==null);
                if (existingReg != 0) {
                    bRet = true;
                }
            }
            return bRet;
        }

        public DebitoPagoStruct Retorna_DebitoPago_Parcela(Debitoparcela Reg) {
            
            using (GTI_Context db = new GTI_Context(_connection)) {
                DebitoPagoStruct ret = new DebitoPagoStruct();
                var item = (from m in db.Debitopago
                           join b in db.Banco on m.Codbanco equals b.Codbanco into bm from b in bm.DefaultIfEmpty()
                           where m.Codreduzido==Reg.Codreduzido && m.Anoexercicio==Reg.Anoexercicio && m.Codlancamento==Reg.Codlancamento && m.Seqlancamento==Reg.Seqlancamento && m.Numparcela==Reg.Numparcela && m.Codcomplemento==Reg.Codcomplemento && m.Restituido == null
                           orderby m.Seqpag
                           select new DebitoPagoStruct {
                               Ano = m.Anoexercicio, Banco_Codigo = m.Codbanco, Banco_Nome = b.Nomebanco,
                               Codigo = m.Codreduzido, Codigo_Agencia = m.Codagencia, Complemento = m.Codcomplemento, Data_Pagamento = m.Datapagamento, Data_Recebimento = m.Datarecebimento,
                               Lancamento = m.Codlancamento, Parcela = m.Numparcela, Restituido = m.Restituido, Sequencia = m.Seqlancamento, Sequencia_Pagamento = m.Seqpag, Valor_Pago = m.Valorpago,
                               Valor_Pago_Real = m.Valorpagoreal, Data_Pagamento_Calc = m.Datapagamentocalc, Numero_Documento = m.Numdocumento,Valor_Tarifa=m.Valortarifa,Valor_Dif=m.Valordif
                           }).FirstOrDefault();
                if (item == null)
                    ret= null;
                else {
                    ret = new DebitoPagoStruct {
                        Codigo = item.Codigo,
                        Ano = item.Ano,
                        Banco_Codigo = item.Banco_Codigo,
                        Banco_Nome = item.Banco_Nome,
                        Codigo_Agencia = item.Codigo_Agencia,
                        Complemento = item.Complemento,
                        Data_Pagamento = item.Data_Pagamento,
                        Data_Recebimento = item.Data_Recebimento,
                        Lancamento = item.Lancamento,
                        Numero_Documento = item.Numero_Documento,
                        Parcela = item.Parcela,
                        Restituido = item.Restituido,
                        Sequencia = item.Sequencia,
                        Sequencia_Pagamento = item.Sequencia_Pagamento,
                        Valor_Pago = item.Valor_Pago,
                        Valor_Pago_Real = item.Valor_Pago_Real,
                        Valor_Tarifa = item.Valor_Tarifa,
                        Valor_Dif = item.Valor_Dif,
                        Data_Pagamento_Calc = item.Data_Pagamento_Calc
                    };
                }
                return ret;
            }
        }

        public bool Parcela_Unica_IPTU_NaoPago(int Codigo, int Ano) {
            bool bRet = false;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var existingReg = db.Debitoparcela.Count(a => a.Codreduzido == Codigo && a.Anoexercicio == Ano && a.Codlancamento==1 && a.Numparcela==0 && a.Statuslanc==3);
                if (existingReg != 0) {
                    bRet = true;
                    existingReg = db.Debitoparcela.Count(a => a.Codreduzido == Codigo && a.Anoexercicio < DateTime.Now.Year  && (a.Statuslanc == 3 | a.Statuslanc == 42 | a.Statuslanc == 43));
                    if (existingReg != 0) {
                        bRet = false;
                    }
                }

            }
            return bRet;
        }

        public List<OrigemReparcStruct> Lista_Origem_Parcelamento(int _ano,int _numero) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                List<OrigemReparcStruct> Lista = (from o in db.Origemreparc join l in db.Lancamento on o.Codlancamento equals l.Codlancamento
                           where o.Anoproc == _ano && o.Numproc == _numero orderby o.Anoexercicio, o.Codlancamento, o.Numsequencia, o.Numparcela,o.Codcomplemento
                           select new OrigemReparcStruct {Numero_Processo_Unificado=o.Numprocesso,Ano_Processo=o.Anoproc,Numero_Processo=o.Numproc,
                           Codigo=o.Codreduzido,Exercicio=o.Anoexercicio,Lancamento_Codigo=o.Codlancamento,Lancamento_Descricao=l.Descreduz,
                           Sequencia=o.Numsequencia,Parcela=o.Numparcela,Complemento=o.Codcomplemento}).ToList();

                return Lista;
            }
        }

        public List<DestinoreparcStruct> Lista_Destino_Parcelamento(int _ano, int _numero) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                List<DestinoreparcStruct> Lista = (from o in db.Destinoreparc
                                                   join d in db.Debitoparcela on new {p1 = o.Codreduzido,p2=o.Anoexercicio,p3=o.Codlancamento,p4= (short)o.Numsequencia, p5 = o.Numparcela,p6=o.Codcomplemento}
                                                   equals new { p1=d.Codreduzido,p2=d.Anoexercicio,p3=d.Codlancamento,p4=d.Seqlancamento,p5=d.Numparcela,p6=d.Codcomplemento}
                                                   join s in db.Situacaolancamento on d.Statuslanc equals s.Codsituacao
                                                  where o.Anoproc == _ano && o.Numproc == _numero orderby o.Anoexercicio, o.Codlancamento, o.Numsequencia, o.Numparcela, o.Codcomplemento
                                                  select new DestinoreparcStruct {
                                                      Numero_Processo_Unificado = o.Numprocesso, Ano_Processo = o.Anoproc, Numero_Processo = o.Numproc, Codigo = o.Codreduzido, Exercicio = o.Anoexercicio, Lancamento_Codigo = o.Codlancamento, 
                                                      Sequencia = o.Numsequencia, Parcela = o.Numparcela, Complemento = o.Codcomplemento,Data_Vencimento=d.Datavencimento,Situacao_Lancamento_Codigo=d.Statuslanc,Situacao_Lancamento_Descricao=s.Descsituacao
                                                  }).ToList();

                return Lista;
            }
        }

        public Processo_Parcelamento_Struct Retorna_Dados_Parcelamento(int _ano, int _numero) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Processo_Parcelamento_Struct Reg = (from p in db.Processoreparc
                            join u in db.Usuario on p.Userid equals u.Id into pu from u in pu.DefaultIfEmpty()
                            where p.Anoproc == _ano && p.Numproc == _numero 
                            select new Processo_Parcelamento_Struct {Numero_Processo_Unificado = p.Numprocesso, Ano_Processo = p.Anoproc, Numero_Processo = p.Numproc,
                            Codigo_Reduzido = p.Codigoresp,Calcula_Correcao=p.Calculacorrecao,Calcula_Juros=p.Calculajuros,Calcula_Multa=p.Calculamulta,Cancelado=p.Cancelado,
                            Data_Cancelado=p.Datacancel,Data_Exportacao=p.Data_exportacao,Data_Parcelamento=p.Datareparc,Data_Processo=p.Dataprocesso,Funcionario=p.Funcionario,
                            Funcionario_Cancelado=p.Funcionariocancel,Honorario=p.Honorario,Novo=p.Novo,Numero_Protocolo=p.Numprotocolo,Penhora=p.Penhora,Percentual_Entrada=p.Percentrada,
                            Plano=p.Plano,Qtde_Parcela=p.Qtdeparcela,Userid=p.Userid,Valor_Entrada=p.Valorentrada,Usuario_Nome=u.Nomecompleto}).FirstOrDefault();
                return Reg;
            }
        }

        public Exception Alterar_Status_Lancamento(int _codigo,short _ano,short _lanc,short _seq, byte _parc, byte _compl,byte _status) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Debitoparcela d = db.Debitoparcela.First(i => i.Codreduzido == _codigo && i.Anoexercicio==_ano && i.Codlancamento==_lanc && i.Seqlancamento==_seq && i.Numparcela==_parc && i.Codcomplemento==_compl);
                d.Statuslanc = _status;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_Data_Vencimento(int _codigo, short _ano, short _lanc, short _seq, byte _parc, byte _compl, DateTime _vencto) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Debitoparcela d = db.Debitoparcela.First(i => i.Codreduzido == _codigo && i.Anoexercicio == _ano && i.Codlancamento == _lanc && i.Seqlancamento == _seq && i.Numparcela == _parc && i.Codcomplemento == _compl);
                d.Datavencimento = _vencto;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_Data_Base(int _codigo, short _ano, short _lanc, short _seq, byte _parc, byte _compl, DateTime _data_base) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Debitoparcela d = db.Debitoparcela.First(i => i.Codreduzido == _codigo && i.Anoexercicio == _ano && i.Codlancamento == _lanc && i.Seqlancamento == _seq && i.Numparcela == _parc && i.Codcomplemento == _compl);
                d.Datadebase = _data_base;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_Data_Inscricao(int _codigo, short _ano, short _lanc, short _seq, byte _parc, byte _compl, DateTime _data) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Debitoparcela d = db.Debitoparcela.First(i => i.Codreduzido == _codigo && i.Anoexercicio == _ano && i.Codlancamento == _lanc && i.Seqlancamento == _seq && i.Numparcela == _parc && i.Codcomplemento == _compl);
                d.Datainscricao = _data;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_Data_Ajuizamento(int _codigo, short _ano, short _lanc, short _seq, byte _parc, byte _compl, DateTime _data) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Debitoparcela d = db.Debitoparcela.First(i => i.Codreduzido == _codigo && i.Anoexercicio == _ano && i.Codlancamento == _lanc && i.Seqlancamento == _seq && i.Numparcela == _parc && i.Codcomplemento == _compl);
                d.Dataajuiza = _data;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_Numero_Livro(int _codigo, short _ano, short _lanc, short _seq, byte _parc, byte _compl, int _livro) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Debitoparcela d = db.Debitoparcela.First(i => i.Codreduzido == _codigo && i.Anoexercicio == _ano && i.Codlancamento == _lanc && i.Seqlancamento == _seq && i.Numparcela == _parc && i.Codcomplemento == _compl);
                d.Numerolivro = _livro;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_Numero_Certidao(int _codigo, short _ano, short _lanc, short _seq, byte _parc, byte _compl, int _certidao) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Debitoparcela d = db.Debitoparcela.First(i => i.Codreduzido == _codigo && i.Anoexercicio == _ano && i.Codlancamento == _lanc && i.Seqlancamento == _seq && i.Numparcela == _parc && i.Codcomplemento == _compl);
                d.Numcertidao = _certidao;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_Pagina_Livro(int _codigo, short _ano, short _lanc, short _seq, byte _parc, byte _compl, int _pagina) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Debitoparcela d = db.Debitoparcela.First(i => i.Codreduzido == _codigo && i.Anoexercicio == _ano && i.Codlancamento == _lanc && i.Seqlancamento == _seq && i.Numparcela == _parc && i.Codcomplemento == _compl);
                d.Paginalivro = _pagina;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Excluir_Debito_Cancel(Debitocancel reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int _codigo = reg.Codreduzido;
                short _ano = reg.Anoexercicio;
                short _lanc = reg.Codlancamento;
                short _seq = reg.Seqlancamento;
                byte _parc = reg.Numparcela;
                byte _compl = reg.Codcomplemento;

                try {
                    Debitocancel b = db.Debitocancel.First(i => i.Codreduzido == _codigo && i.Anoexercicio == _ano && i.Codlancamento == _lanc && i.Seqlancamento == _seq && i.Numparcela == _parc && i.Codcomplemento == _compl);
                    try {
                        db.Debitocancel.Remove(b);
                        db.SaveChanges();
                    } catch (Exception ex) {
                        return ex;
                    }
                } catch {

                }
                return null;
            }
        }

        public Exception Insert_Debito_Cancel(Debitocancel reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    db.Database.ExecuteSqlCommand("INSERT INTO debitocancel(numprocesso,codreduzido,anoexercicio,codlancamento,seqlancamento,numparcela,codcomplemento,datacancel,motivo,userid) " +
                        "VALUES(@numprocesso,@codreduzido,@anoexercicio,@codlancamento,@seqlancamento,@numparcela,@codcomplemento,@datacancel,@motivo,@userid)",
                        new SqlParameter("@numprocesso", reg.Numprocesso),
                        new SqlParameter("@codreduzido", reg.Codreduzido),
                        new SqlParameter("@anoexercicio", reg.Anoexercicio),
                        new SqlParameter("@codlancamento", reg.Codlancamento),
                        new SqlParameter("@seqlancamento", reg.Seqlancamento),
                        new SqlParameter("@numparcela", reg.Numparcela),
                        new SqlParameter("@codcomplemento", reg.Codcomplemento),
                        new SqlParameter("@datacancel", reg.Datacancel),
                        new SqlParameter("@motivo", reg.Motivo),
                        new SqlParameter("@userid", reg.Userid));
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Tipolivro Retorna_Tipo_Livro_Divida_Ativa(int _lancamento) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Tipolivro Sql = (from l in db.Lancamento
                           join t in db.Tipolivro on l.Tipolivro equals t.Codtipo into lt from t in lt.DefaultIfEmpty()
                           where l.Codlancamento==_lancamento
                           select t).FirstOrDefault();
                return Sql;
            }
        }

        public int Retorna_Ultima_Certidao_Livro(int _livro) {
            int maxCod = 0;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from p in db.Debitoparcela where p.Numerolivro == _livro select p.Numcertidao).Max();
                maxCod = Convert.ToInt32(Sql) + 1;
            }
            return maxCod;
        }

        public Exception Inscrever_Divida_Ativa(int _codigo, short _ano, short _lanc, short _seq, byte _parc, byte _compl, int _livro, int _pagina,int _certidao,DateTime _data) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Debitoparcela d = db.Debitoparcela.First(i => i.Codreduzido == _codigo && i.Anoexercicio == _ano && i.Codlancamento == _lanc && i.Seqlancamento == _seq && i.Numparcela == _parc && i.Codcomplemento == _compl);
                d.Numerolivro = _livro;
                d.Paginalivro = _pagina;
                d.Numcertidao = _certidao;
                d.Datainscricao = _data;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Debito_Parcela(Debitoparcela Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                object[] Parametros = new object[10];
                Parametros[0] = new SqlParameter { ParameterName = "@codreduzido", SqlDbType = SqlDbType.Int, SqlValue = Reg.Codreduzido };
                Parametros[1] = new SqlParameter { ParameterName = "@anoexercicio", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Anoexercicio };
                Parametros[2] = new SqlParameter { ParameterName = "@codlancamento", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Codlancamento };
                Parametros[3] = new SqlParameter { ParameterName = "@seqlancamento", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Seqlancamento };
                Parametros[4] = new SqlParameter { ParameterName = "@numparcela", SqlDbType = SqlDbType.TinyInt, SqlValue = Reg.Numparcela };
                Parametros[5] = new SqlParameter { ParameterName = "@codcomplemento", SqlDbType = SqlDbType.TinyInt, SqlValue = Reg.Codcomplemento };
                Parametros[6] = new SqlParameter { ParameterName = "@statuslanc", SqlDbType = SqlDbType.TinyInt, SqlValue = Reg.Statuslanc };
                Parametros[7] = new SqlParameter { ParameterName = "@datavencimento", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Datavencimento };
                Parametros[8] = new SqlParameter { ParameterName = "@datadebase", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Datavencimento };
                Parametros[9] = new SqlParameter { ParameterName = "@userid", SqlDbType = SqlDbType.Int, SqlValue = Reg.Userid };

                db.Database.ExecuteSqlCommand("INSERT INTO debitoparcela(codreduzido,anoexercicio,codlancamento,seqlancamento,numparcela,codcomplemento,statuslanc,datavencimento,datadebase,userid) " +
                    "VALUES(@codreduzido,@anoexercicio,@codlancamento,@seqlancamento,@numparcela,@codcomplemento,@statuslanc,@datavencimento,@datadebase,@userid)", Parametros);

                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Debito_Tributo(Debitotributo Reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                object[] Parametros = new object[8];
                Parametros[0] = new SqlParameter { ParameterName = "@codreduzido", SqlDbType = SqlDbType.Int, SqlValue = Reg.Codreduzido };
                Parametros[1] = new SqlParameter { ParameterName = "@anoexercicio", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Anoexercicio };
                Parametros[2] = new SqlParameter { ParameterName = "@codlancamento", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Codlancamento };
                Parametros[3] = new SqlParameter { ParameterName = "@seqlancamento", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Seqlancamento };
                Parametros[4] = new SqlParameter { ParameterName = "@numparcela", SqlDbType = SqlDbType.TinyInt, SqlValue = Reg.Numparcela };
                Parametros[5] = new SqlParameter { ParameterName = "@codcomplemento", SqlDbType = SqlDbType.TinyInt, SqlValue = Reg.Codcomplemento };
                Parametros[6] = new SqlParameter { ParameterName = "@Codtributo", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Codtributo };
                Parametros[7] = new SqlParameter { ParameterName = "@Valortributo", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Valortributo };

                db.Database.ExecuteSqlCommand("INSERT INTO debitotributo(codreduzido,anoexercicio,codlancamento,seqlancamento,numparcela,codcomplemento,Codtributo,Valortributo) " +
                    "VALUES(@codreduzido,@anoexercicio,@codlancamento,@seqlancamento,@numparcela,@codcomplemento,@Codtributo,@Valortributo)", Parametros);

                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }



    }//end class
}
