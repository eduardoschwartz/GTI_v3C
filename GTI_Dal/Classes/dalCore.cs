using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GTI_Dal.Classes {
    public class dalCore {

        public enum LocalEndereco { Imovel, Empresa, Cidadao }
        public enum TipoContribuinte {Imovel, Empresa, Cidadao }
        

        private static byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private static byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };


        public static bool IsDate(Object date) {
            try {
                DateTime dt = DateTime.Parse(date.ToString());
                return true;
            } catch {
                return false;
            }
        }
        
        public static string Encrypt(string clearText) {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(clearText);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);
        }

        public static string Decrypt(string cipherText) {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
            byte[] inputbuffer = Convert.FromBase64String(cipherText);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Encoding.Unicode.GetString(outputBuffer);
        }

        //Function to get random number
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber() {
            lock (syncLock) { // synchronize
                return getrandom.Next(1, 2000000);
            }
        }

        public static Int32 RetornaDVDocumento(Int32 nNumDoc) {
            String sFromN = "";
            Int32 nDV = 0;
            Int32 nTotPosAtual = 0;

            sFromN = nNumDoc.ToString("00000000");
            nTotPosAtual = Convert.ToInt32(sFromN.Substring(0, 1)) * 7;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(1, 1)) * 3;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(2, 1)) * 9;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(3, 1)) * 7;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(4, 1)) * 3;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(5, 1)) * 9;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(6, 1)) * 7;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(7, 1)) * 3;

            nDV = Convert.ToInt32(nTotPosAtual.ToString().Substring(nTotPosAtual.ToString().Length - 1));
            return nDV;
        }

        public static Int32 Modulo11(String sValue) {
            Int32 nDV = 0;
            Int32 nTotPosAtual = 0;

            nTotPosAtual = Convert.ToInt32(sValue.Substring(0, 1)) * 6;
            nTotPosAtual += Convert.ToInt32(sValue.Substring(1, 1)) * 5;
            nTotPosAtual += Convert.ToInt32(sValue.Substring(2, 1)) * 4;
            nTotPosAtual += Convert.ToInt32(sValue.Substring(3, 1)) * 3;
            nTotPosAtual += Convert.ToInt32(sValue.Substring(4, 1)) * 2;
            nTotPosAtual += Convert.ToInt32(sValue.Substring(5, 1)) * 9;
            nTotPosAtual += Convert.ToInt32(sValue.Substring(6, 1)) * 8;
            nTotPosAtual += Convert.ToInt32(sValue.Substring(7, 1)) * 7;
            nTotPosAtual += Convert.ToInt32(sValue.Substring(8, 1)) * 6;
            nTotPosAtual += Convert.ToInt32(sValue.Substring(9, 1)) * 5;
            nTotPosAtual += Convert.ToInt32(sValue.Substring(10, 1)) * 4;
            nTotPosAtual += Convert.ToInt32(sValue.Substring(11, 1)) * 3;
            nTotPosAtual += Convert.ToInt32(sValue.Substring(12, 1)) * 2;

            nDV = 11 - (nTotPosAtual % 11);

            if (nDV == 1)
                nDV = 0;
            else
                if (nDV == 10)
                nDV = 1;
            else
                    if (nDV == 1 | nDV == 11)
                nDV = 0;

            return nDV;
        }

        public static int RetornaDV2of5(string sBloco) {
            int nRet = 0; int d = 0; int nSoma = 0; int nResto = 0;
            string e = "";

            for (int c = sBloco.Length - 1; c >= 0; c--) {
                if (c % 2 == 0)
                    d = Convert.ToInt16(sBloco.Substring(c, 1)) * 2;
                else {
                    d = Convert.ToInt16(sBloco.Substring(c, 1));
                }
                if (d > 0) {
                    if (d > 9) {
                        e = d.ToString();
                        d = Convert.ToInt32(e.Substring(0, 1)) + Convert.ToInt32(e.Substring(1, 1));
                    }
                    nSoma += d;
                }
            }
            nResto = nSoma % 10;
            if (nResto == 0)
                nRet = 0;
            else
                nRet = 10 - nResto;

            return nRet;
        }

        public static String RetornaNumero(String Numero) {
            if (String.IsNullOrEmpty(Numero))
                return "0";
            else
                return Regex.Replace(Numero, @"[^\d]", "");
        }

        public static string Gera2of5Cod(string Valor, DateTime Vencimento, int Numero_Documento, int Codigo_Reduzido) {
            string sValor_Parcela = Convert.ToInt32(RetornaNumero(Valor)).ToString("00000000000");
            string sDia = Vencimento.Day.ToString("00");
            string sMes = Vencimento.Month.ToString("00");
            string sAno = Vencimento.Year.ToString();
            string sNumero_Documento = Numero_Documento.ToString("000000000");
            string sCodigo_Reduzido = Codigo_Reduzido.ToString("00000000");

            string sBloco1 = "816" + sValor_Parcela.Substring(0, 7);
            string sBloco2 = sValor_Parcela.Substring(7, 4) + "2177" + sAno.Substring(0, 3);
            string sBloco3 = sAno.Substring(3, 1) + sMes + sDia + sNumero_Documento.Substring(0, 6);
            string sBloco4 = sNumero_Documento.Substring(6, 3) + sCodigo_Reduzido;

            string sDv0 = RetornaDV2of5(sBloco1 + sBloco2 + sBloco3 + sBloco4).ToString();
            sBloco1 = sBloco1.Substring(0, 3) + sDv0 + sBloco1.Substring(3, 7);
            sBloco1 += "-" + RetornaDV2of5(sBloco1);
            sBloco2 += "-" + RetornaDV2of5(sBloco2);
            sBloco3 += "-" + RetornaDV2of5(sBloco3);
            sBloco4 += "-" + RetornaDV2of5(sBloco4);

            return sBloco1 + sBloco2 + sBloco3 + sBloco4;
        }

        public static string Gera2of5Str(string sCodigo_Barra) {
            string DataToEncode = ""; string DataToPrint = ""; char StartCode = (char)203; char StopCode = (char)204; int CurrentChar = 0;
            DataToEncode = sCodigo_Barra;
            if (DataToEncode.Length % 2 == 1)
                DataToEncode = "0" + DataToEncode;
            for (int i = 0; i < DataToEncode.Length; i += 2) {
                CurrentChar = Convert.ToInt32(DataToEncode.Substring(i, 2));
                if (CurrentChar < 94)
                    DataToPrint += Convert.ToChar(CurrentChar + 33);
                else if (CurrentChar > 93)
                    DataToPrint += Convert.ToChar(CurrentChar + 103);
            }

            return StartCode + DataToPrint + StopCode;
        }

        public static Int32 Calculo_DV10(String sValue) {
            Int32 nDV = 0;
            Int32 intNumero = 0;
            Int32 intTotalNumero = 0;
            Int32 intMultiplicador = 2;

            for (Int32 intContador = sValue.Length; intContador > 0; intContador--) {
                intNumero = Convert.ToInt32(sValue.Substring(intContador - 1, 1)) * intMultiplicador;
                if (intNumero > 9)
                    intNumero = Convert.ToInt32(intNumero.ToString().Substring(0, 1)) + Convert.ToInt32(intNumero.ToString().Substring(1, 1));

                intTotalNumero += intNumero;
                intMultiplicador = intMultiplicador == 2 ? 1 : 2;
            }

            Int32 DezenaSuperior = intTotalNumero < 10 ? 10 : (10 * (Convert.ToInt32(intTotalNumero.ToString().Substring(0, 1)) + 1));

            Int32 intResto = DezenaSuperior - intTotalNumero;

            if (intResto == 0 || intResto == 10)
                nDV = 0;
            else
                nDV = intResto;

            return nDV;
        }

        public static string Mask(string sSqlField) {
            return sSqlField.Replace("'", "''");
        }

        public static String Truncate(string str, int maxLength, string suffix) {
            if (str.Length > maxLength) {
                str = str.Substring(0, maxLength + 1);
                str = str.Substring(0, Math.Min(str.Length, str.LastIndexOf(" ") == -1 ? 0 : str.LastIndexOf(" ")));
                str = str + suffix;
            }
            return str.Trim();
        }

        public static string Unifica_Cnae(int _divisao,int _grupo,int _classe,int _subclasse) {
            return _divisao.ToString("00") + _grupo.ToString("0") + _classe.ToString("00").Substring(0, 1) + "-" + _classe.ToString("00").Substring(1, 1) + "/" + _subclasse.ToString("00");
        }



    }
}
