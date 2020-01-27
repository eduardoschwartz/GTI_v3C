using GTI_Models;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace GTI_Dal.Classes {
    public class Eicon_Data {
        private static string _connection;

        public Eicon_Data(string sConnection) {
            _connection = sConnection;
        }

        public List<CompetenciaISS> Resumo_CompetenciaISS(int Codigo) {
            List<CompetenciaISS> TabelaMes = new List<CompetenciaISS>();
            using (Eicon_Context db = new Eicon_Context(_connection)) {
                decimal _mes_inicial = db.Tb_inter_encerramento_giss.OrderBy(c => c.Ano_competencia).ThenBy(c => c.Mes_competencia).Where(c => c.Num_cadastro == Codigo).Select(c => c.Mes_competencia).FirstOrDefault();
                decimal _ano_inicial = db.Tb_inter_encerramento_giss.OrderBy(c => c.Ano_competencia).ThenBy(c => c.Mes_competencia).Where(c => c.Num_cadastro == Codigo).Select(c => c.Ano_competencia).FirstOrDefault();
                if (_ano_inicial == 0)
                    return null;
                int _mes_anterior = 0, _ano_anterior = 0;

                if (DateTime.Now.Month == 1) {
                    _mes_anterior = 12;
                    _ano_anterior = DateTime.Now.Year - 1;
                } else {
                    _mes_anterior = DateTime.Now.Month - 1;
                    _ano_anterior = DateTime.Now.Year;
                }

                //DateTime _data_30dias = DateTime.Now.AddDays(-31);
                DateTime _data_30dias = DateTime.Now.AddDays(-40);

                int _mes_final = _data_30dias.Month;
                int _ano_final = _data_30dias.Year;

                decimal _mes_atual = _mes_inicial, _ano_atual = _ano_inicial;

                while (true) {
                    if (_ano_atual < 2017) //apenas para competencias acima de abril de 2015(Inicio da Giss)
                                           //    if (_ano_atual < 2015) //apenas para competencias acima de abril de 2015(Inicio da Giss)
                        goto Continue;
                    //                  else {
                    //if(_ano_atual==2015 && _mes_atual<5)
                    //                                goto Continue;
                    //                }

                    CompetenciaISS reg = new CompetenciaISS {
                        Codigo = Codigo,
                        Ano_Competencia = Convert.ToInt32(_ano_atual),
                        Mes_Competencia = Convert.ToInt32(_mes_atual),
                        Encerrada = false,
                        Sem_Movimento = false,
                        Valor = 0
                    };
                    TabelaMes.Add(reg);

                Continue:;

                    if (_mes_atual == 12) {
                        _mes_atual = 1;
                        _ano_atual++;
                    } else
                        _mes_atual++;

                    if (_ano_atual == _ano_final && _mes_atual > _mes_final)
                        break;

                    if (_ano_atual > _ano_final)
                        break;

                }

                var Sql = db.Tb_inter_encerramento_giss.Where(c => c.Num_cadastro == Codigo).OrderBy(c => c.Ano_competencia).ThenBy(c => c.Mes_competencia).Select(x => new { x.Ano_competencia, x.Mes_competencia, x.Sem_movimento }).ToList();
                foreach (var item in Sql) {
                    for (int i = 0; i < TabelaMes.Count; i++) {
                        if (TabelaMes[i].Ano_Competencia == item.Ano_competencia && TabelaMes[i].Mes_Competencia == item.Mes_competencia) {
                            TabelaMes[i].Encerrada = true;
                            TabelaMes[i].Sem_Movimento = item.Sem_movimento == "S" ? true : false;
                            break;
                        }
                    }
                }
            }

            return TabelaMes;
        }



    }
}
