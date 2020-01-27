using GTI_WebCore.Models;
using GTI_WebCore.Interfaces;
using System;
using System.Linq;

namespace GTI_WebCore.Repository {
    public class EnderecoRepository:IEnderecoRepository {

        private readonly AppDbContext context;
        public EnderecoRepository(AppDbContext context) {
            this.context = context;
        }

        public AppDbContext Context { get; }
        
        public int RetornaCep(int CodigoLogradouro, short Numero) {
            int nCep = 0;
            int Num1, Num2;
            bool bPar, bImpar;

            if (Numero % 2 == 0) {
                bPar = true; bImpar = false;
            } else {
                bPar = false; bImpar = true;
            }

            var Sql = (from c in context.Cep where c.Codlogr == CodigoLogradouro select c).ToList();
            if (Sql.Count == 0)
                nCep = 0;
            else if (Sql.Count == 1)
                nCep = Sql[0].cep;
            else {
                foreach (var item in Sql) {
                    Num1 = Convert.ToInt32(item.Valor1);
                    Num2 = Convert.ToInt32(item.Valor2);
                    if (Numero >= Num1 && Numero <= Num2) {
                        if ((bImpar && item.Impar) || (bPar && item.Par)) {
                            nCep = item.cep;
                            break;
                        }
                    } else if (Numero >= Num1 && Num2 == 0) {
                        if ((bImpar && item.Impar) || (bPar && item.Par)) {
                            nCep = item.cep;
                            break;
                        }
                    }
                }
            }
            return nCep;
        }
    }
}
