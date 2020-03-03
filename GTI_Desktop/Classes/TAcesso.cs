using System;
using System.Text;

namespace GTI_Desktop.Classes {

    public class TAcessoFunction {
        private  double[] cle = new double[17];
        private  double[] x1a0 = new double[9];
        private  double inter, res, ax, bx, cx, dx, si, tmpx;
        private  double x1a2;
        private  int i128 = 0;


        public  string DecryptGTI(string value) {
            string sData = "", champl = gtiCore.Up;
            int si = 0, i = 0, lchampl = gtiCore.Up.Length, d = 0, c = 0, fois = 0, e = 0;
            byte[] asciiBytes;

            for (fois = 0; fois < cle.Length; fois++) {
                cle[fois] = 0;
            }
            for (fois = 0; fois < x1a0.Length; fois++) {
                x1a0[fois] = 0;
            }
            inter = 0; res = 0; ax = 0; bx = 0; cx = 0; dx = 0; si = 0; tmpx = 0; x1a2 = 0;

            try {

                for (fois = 0; fois < lchampl; fois++) {
                    asciiBytes = Encoding.ASCII.GetBytes(champl.Substring(fois, 1));
                    cle[fois] = asciiBytes[0];
                }

                champl = value;
                lchampl = champl.Length;

                for (fois = 0; fois < lchampl; fois++) {
                    asciiBytes = Encoding.ASCII.GetBytes(champl.Substring(fois, 1));
                    d = asciiBytes[0];
                    if (d - 97 >= 0) {
                        d = d - 97;
                        if (d >= 0 && d <= 15)
                            d *= 16;
                    }

                    if (fois != gtiCore.Up.Length)
                        fois++;
                    asciiBytes = Encoding.ASCII.GetBytes(champl.Substring(fois, 1));
                    e = asciiBytes[0];
                    if (e - 97 >= 0) {
                        e -= 97;
                        if (e >= 0 && e <= 15)
                            c = d + e;
                    }
                    Assemble128();
                    double cfc = (((inter / 256) * 256) - (inter % 256)) / 256;
                    double cfd = (int)inter % 256;

                    double t = (int)cfc ^ (int)cfd;
                    c = c ^ (int)t;

                    for (int compte = 0; compte <= 16; compte++) {
                        cle[compte] = (int)cle[compte] ^ c;
                    }
                    sData += Convert.ToChar(c);
                }

            } catch (Exception ex) {
                throw ex;
            }

            return sData;
        }

        private  void Assemble128() {
            try {

                x1a0[0] = ((cle[0] * 256) + cle[1]) % 65536;
                Code128();
                inter = res;

                x1a0[1] = (int)x1a0[0] ^ (((int)cle[2] * 256) + (int)cle[3]);
                Code128();
                inter = (int)inter ^ (int)res;

                x1a0[2] = (int)x1a0[1] ^ (((int)cle[4] * 256) + (int)cle[5]);
                Code128();
                inter = (int)inter ^ (int)res;

                x1a0[3] = (int)x1a0[2] ^ (((int)cle[6] * 256) + (int)cle[7]);
                Code128();
                inter = (int)inter ^ (int)res;

                x1a0[4] = (int)x1a0[3] ^ (((int)cle[8] * 256) + (int)cle[9]);
                Code128();
                inter = (int)inter ^ (int)res;

                x1a0[5] = (int)x1a0[4] ^ (((int)cle[10] * 256) + (int)cle[11]);
                Code128();
                inter = (int)inter ^ (int)res;

                x1a0[6] = (int)x1a0[5] ^ (((int)cle[12] * 256) + (int)cle[13]);
                Code128();
                inter = (int)inter ^ (int)res;

                x1a0[7] = (int)x1a0[6] ^ (((int)cle[14] * 256) + (int)cle[15]);
                Code128();
                inter = (int)inter ^ (int)res;

                i128 = 0;

            } catch (Exception ex) {
                throw ex;
            }

        }

        private  void Code128() {
            i128 = 0;
            try {
                dx = (x1a2 + i128) % 65536;
                ax = x1a0[i128];
                cx = 346; //&H15A
                bx = 20021; //&H4E35

                tmpx = ax;
                ax = si;
                si = tmpx;

                tmpx = ax;
                ax = dx;
                dx = tmpx;

                if (ax != 0)
                    ax = (ax * bx) % 65536;

                tmpx = ax;
                ax = cx;
                cx = tmpx;

                if (ax != 0) {
                    ax = (ax * si) % 65536;
                    cx = (ax + cx) % 65536;
                }

                tmpx = ax;
                ax = si;
                si = tmpx;
                ax = (ax * bx) % 65536;
                dx = (cx + dx) % 65536;

                ax += 1;
                x1a2 = dx;
                x1a0[i128] = ax;
                res = (int)ax ^ (int)dx;
                i128++;

            } catch (Exception ex) {
                throw ex;
            }
        }


    }


    public enum TAcesso {
        CadastroPais = 1,
        CadastroPais_Alterar = 2,
        CadastroBairro = 3,
        CadastroBairro_Alterar_Fora = 4,
        CadastroBairro_Alterar_Local = 5,
        CadastroProfissao = 6,
        CadastroProfissao_Alterar = 7,
        CadastroImovel = 8,
        CadastroImovel_Alterar_Total = 9,
        CadastroImovel_Alterar_Historico = 10,
        CadastroImovel_Inativar = 11,
        CadastroFaceQuadra = 12,
        CadastroFaceQuadra_Alterar = 13,
        CadastroCidadao = 14,
        CadastroCidadao_Alterar_Total = 15,
        ExtratoContribuinte = 16,
        CadastroProcesso = 17,
        CadastroProcesso_Alterar_Basico = 18,
        CadastroProcesso_Alterar_Avancado = 19,
        CadastroProcesso_Tramitar = 20,
        CadastroProcesso_Novo = 21,
        CadastroImovel_Novo = 22,
        CadastroCondominio = 23,
        CadastroCondominio_Alterar = 24,
        CadastroImovel_IPTU=25,
        Carta_Cobranca=26,
        Registro_Bancario=27,
        Atividade_Empresa=28,
        Calculo_Imposto=29,
        Comunicado_Isencao=30,
        CadastroEmpresa=31,
        CadastroEmpresa_Alterar_Total=32,
        CadastroEmpresa_Alterar_Historico=33,
        CadastroEmpresa_Exclusao=34,
        Consulta_documento=35,
        DAM_Desativar_Refis = 36,
        DAM_Imprimir=37,
        Editar_Parcela=38,
        Editar_Parcela_Lancamentos=39,
        Editar_Parcela_Divida_Ativa=40,
        DAM_Honorario=41,
        DAM_Desconto=42,
        Cancelamento_debito=43

    }
}
