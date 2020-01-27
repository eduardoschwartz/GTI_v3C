using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTI_Dal.Classes {
    public class Endereco_Data {

        private string _connection;
        public Endereco_Data(string sConnection) {
            _connection = sConnection;
        }

        public bool Bairro_uso_cidadao(string id_UF, int id_cidade,int id_bairro) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var cntCod1 = (from c in db.Cidadao where c.Siglauf == id_UF && c.Codcidade == id_cidade && c.Codbairro == id_bairro select c.Codcidadao).Count();
                var cntCod2 = (from c in db.Cidadao where c.Siglauf == id_UF && c.Codcidade == id_cidade && c.Codbairro2 == id_bairro select c.Codcidadao).Count();
                return cntCod1 > 0||cntCod2>0 ? true : false;
            }
        }

        public bool Bairro_uso_empresa(string id_UF, int id_cidade, int id_bairro) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var cntCod1 = (from c in db.Mobiliario where c.Siglauf == id_UF && c.Codcidade == id_cidade && c.Codbairro == id_bairro select c.Codigomob).Count();
                return cntCod1 > 0  ? true : false;
            }
        }

        public bool Bairro_uso_processo(string id_UF, int id_cidade, int id_bairro) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var cntCod1 = (from c in db.Processocidadao where c.Siglauf == id_UF && c.Codcidade == id_cidade && c.Codbairro == id_bairro select c.Codcidadao).Count();
                return cntCod1 > 0 ? true : false;
            }
        }

        public bool Pais_uso_cidadao(int id_pais) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var cntCod1 = (from c in db.Cidadao where c.Codpais == id_pais  select c.Codcidadao).Count();
                var cntCod2 = (from c in db.Cidadao where c.Codpais2 == id_pais select c.Codcidadao).Count();
                return cntCod1 > 0 || cntCod2 > 0 ? true : false;
            }
        }
               
        public List<Bairro> Lista_Bairro(string UF, int cidade) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from b in db.Bairro where b.Siglauf == UF && b.Codcidade == cidade orderby b.Descbairro select b);
                return Sql.ToList();
            }
        }

        public Exception Incluir_bairro(Bairro reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var cntCod = (from c in db.Bairro where c.Siglauf == reg.Siglauf && c.Codcidade == reg.Codcidade select c.Codbairro).Count();
                int maxCod = 1;
                if (cntCod > 0)
                    maxCod = (from c in db.Bairro where c.Siglauf == reg.Siglauf && c.Codcidade == reg.Codcidade select c.Codbairro).Max() + 1;
                reg.Codbairro = Convert.ToInt16(maxCod);
                db.Bairro.Add(reg);
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_Bairro(Bairro reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                string sUF = reg.Siglauf;
                int nCodCidade = reg.Codcidade;
                int nCodBairro = reg.Codbairro;
                Bairro b = db.Bairro.First(i => i.Siglauf == sUF && i.Codcidade == nCodCidade && i.Codbairro == nCodBairro);
                b.Descbairro = reg.Descbairro;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Excluir_Bairro(Bairro reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                
                    string sUF = reg.Siglauf;
                    int nCodCidade = reg.Codcidade;
                    int nCodBairro = reg.Codbairro;
                    Bairro b = db.Bairro.First(i => i.Siglauf == sUF && i.Codcidade == nCodCidade && i.Codbairro == nCodBairro);
                try {
                    db.Bairro.Remove(b);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public List <Cidade> Lista_Cidade(string sUF) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Cidade select c);
                if (!string.IsNullOrEmpty(sUF))
                     Sql = Sql.Where(u => u.Siglauf == sUF).OrderBy(u=>u.Desccidade);

                return Sql.ToList();
            }
        }

        public List<Uf> Lista_UF() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Uf orderby c.Descuf select c);
                return Sql.ToList();
            }
        }

        public List<Pais> Lista_Pais() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Pais select c);
                return Sql.ToList();
            }
        }

        public string Retorna_Logradouro(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Logradouro where c.Codlogradouro == Codigo select c.Endereco).FirstOrDefault();
                return Sql;
            }
        }

        public string Retorna_Pais(int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                string Sql = (from c in db.Pais where c.Id_pais == Codigo select c.Nome_pais).FirstOrDefault();
                return Sql;
            }
        }

        public string Retorna_Cidade(string UF, int Codigo) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Cidade where c.Siglauf == UF && c.Codcidade==Codigo select c.Desccidade).FirstOrDefault();
                return Sql;
            }
        }

        public string Retorna_Bairro(string UF, int Cidade,int Bairro) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Bairro where c.Siglauf == UF && c.Codcidade == Cidade && c.Codbairro==Bairro select c.Descbairro).FirstOrDefault();
                return Sql;
            }
        }

        public Exception Incluir_Pais(Pais reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int cntCod = (from c in db.Pais select c).Count();
                int maxCod = 1;
                if(cntCod>0)
                    maxCod = (from c in db.Pais select c.Id_pais).Max()+1;
                reg.Id_pais = maxCod;
                db.Pais.Add(reg);
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_Pais(Pais reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int nCodPais = reg.Id_pais;
                Pais b = db.Pais.First(i => i.Id_pais == nCodPais);
                b.Nome_pais = reg.Nome_pais;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Excluir_Pais(Pais reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int nCodPais = reg.Id_pais;
                Pais b = db.Pais.First(i =>  i.Id_pais == nCodPais);
                try {
                    db.Pais.Remove(b);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }


        public List<Logradouro> Lista_Logradouro(String Filter = "") {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from l in db.Logradouro
                           select new { l.Codlogradouro, l.Endereco });
                if (!String.IsNullOrEmpty(Filter))
                    reg = reg.Where(u => u.Endereco.Contains(Filter)).OrderBy(u=>u.Endereco);

                List<Logradouro> Lista = new List<Logradouro>();
                foreach (var query in reg) {
                    Logradouro Linha = new Logradouro {
                        Codlogradouro = query.Codlogradouro,
                        Endereco = query.Endereco
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }
        
        public int RetornaCep(Int32 CodigoLogradouro, Int16 Numero) {
            int nCep = 0;
            int Num1, Num2;
            bool bPar, bImpar;

            if (Numero % 2 == 0) {
                bPar = true; bImpar = false;
            } else {
                bPar = false; bImpar = true;
            }

            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Cep where c.Codlogr == CodigoLogradouro select c).ToList();
                if (Sql.Count == 0)
                    nCep = 0;
                else if (Sql.Count == 1)
                    nCep = Sql[0].cep;
                else {
                    foreach (var item in Sql) {
                        Num1 = Convert.ToInt32(item.Valor1);
                        Num2 = Convert.ToInt32(item.Valor2);
                        if (Numero >= Num1 && Numero <= Num2) {
                            if ((bImpar && item.Impar ) || (bPar && item.Par )) {
                                nCep = item.cep;
                                break;
                            }
                        } else if (Numero >= Num1 && Num2 == 0) {
                            if ((bImpar && item.Impar) || (bPar && item.Par )) {
                                nCep = item.cep;
                                break;
                            }
                        }
                    }
                }
            }
            return nCep;
        }

    }
}
