using System;
using System.Collections.Generic;
using GTI_Models.Models;
using GTI_Dal.Classes;

namespace GTI_Bll.Classes {
    public class Endereco_bll {

        private string _connection;
        public Endereco_bll(string sConnection) {
            _connection = sConnection;
        }

        public List<Cidade> Lista_Cidade(string UF) {
            Endereco_Data obj = new Endereco_Data(_connection);
            return obj.Lista_Cidade(UF);
        }

        public List<Uf> Lista_UF() {
            Endereco_Data obj = new Endereco_Data(_connection);
            return obj.Lista_UF();
        }

        public List<Logradouro> Lista_Logradouro(String Filter = "") {
            Endereco_Data obj = new Endereco_Data(_connection);
            return obj.Lista_Logradouro(Filter);
        }

        public List<Bairro> Lista_Bairro(string UF, int cidade) {
            Endereco_Data obj = new Endereco_Data(_connection);
            return obj.Lista_Bairro(UF, cidade);
        }

        public Exception Incluir_bairro(Bairro reg) {
            Endereco_Data obj = new Endereco_Data(_connection);
            Exception ex = obj.Incluir_bairro(reg);
            return ex;
        }

        public Exception Alterar_Bairro(Bairro reg) {
            Endereco_Data obj = new Endereco_Data(_connection);
            Exception ex= obj.Alterar_Bairro(reg);
            return ex;
        }

        public Exception Excluir_Bairro(Bairro reg) {
            Endereco_Data obj = new Endereco_Data(_connection);
            Exception ex = Bairro_em_uso(reg.Siglauf, reg.Codcidade,reg.Codbairro);
            if (ex == null) 
                ex =obj.Excluir_Bairro(reg);
            return ex;
        }

        private Exception Bairro_em_uso(string id_UF, int id_cidade,int id_bairro) {
            Exception AppEx=null;
            Endereco_Data obj = new Endereco_Data(_connection);
            bool bcidadao = obj.Bairro_uso_cidadao(id_UF, id_cidade, id_bairro);
            if(bcidadao)
                AppEx = new Exception("Exclusão não permitida. Bairro em uso - cadastro cidadão.");
            else {
                bool bempresa = obj.Bairro_uso_empresa(id_UF, id_cidade, id_bairro);
                if (bempresa)
                    AppEx = new Exception("Exclusão não permitida. Bairro em uso - cadastro mobiliário.");
                else {
                    bool bprocesso = obj.Bairro_uso_processo(id_UF, id_cidade, id_bairro);
                    if (bempresa)
                        AppEx = new Exception("Exclusão não permitida. Bairro em uso - processo.");
                }
            }
            return AppEx;
        }

        public List<Pais> Lista_Pais() {
            Endereco_Data obj = new Endereco_Data(_connection);
            return obj.Lista_Pais();
        }

        public Exception Incluir_Pais(Pais reg) {
            Endereco_Data obj = new Endereco_Data(_connection);
            Exception ex = obj.Incluir_Pais(reg);
            return ex;
        }

        public Exception Alterar_Pais(Pais reg) {
            Endereco_Data obj = new Endereco_Data(_connection);
            Exception ex = obj.Alterar_Pais(reg);
            return ex;
        }

        public Exception Excluir_Pais(Pais reg) {
            Endereco_Data obj = new Endereco_Data(_connection);
            Exception ex = Pais_em_uso(reg.Id_pais);
            if(ex==null)
                ex = obj.Excluir_Pais(reg);
            return ex;
        }

        private Exception Pais_em_uso(int id_pais) {
            Exception AppEx = null;
            Endereco_Data obj = new Endereco_Data(_connection);
            bool bcidadao = obj.Pais_uso_cidadao(id_pais);
            if (bcidadao)
                AppEx = new Exception("Exclusão não permitida. País em uso - cadastro cidadão.");
            return AppEx;
        }

        public string Retorna_Pais(int Codigo) {
            Endereco_Data obj = new Endereco_Data(_connection);
            return obj.Retorna_Pais(Codigo);
        }

        public string Retorna_Logradouro(int Codigo) {
            Endereco_Data obj = new Endereco_Data(_connection);
            return obj.Retorna_Logradouro(Codigo);
        }

        public string Retorna_Cidade(string UF, int Codigo) {
            Endereco_Data obj = new Endereco_Data(_connection);
            return obj.Retorna_Cidade(UF,Codigo);
        }

        public string Retorna_Bairro(string UF, int Cidade, int Bairro) {
            Endereco_Data obj = new Endereco_Data(_connection);
            return obj.Retorna_Bairro(UF, Cidade,Bairro);
        }

        //private Exception Validated(endereco reg) {
        //    Exception AppEx;
        //    if (reg.id_pais==0) {
        //        AppEx = new Exception("Informe o país.");
        //        return AppEx;
        //    }
        //    if (String.IsNullOrEmpty(reg.sigla_uf)) {
        //        AppEx = new Exception("Informe o Estado.");
        //        return AppEx;
        //    }
        //    if (reg.id_cidade == 0) {
        //        AppEx = new Exception("Informe a cidade.");
        //        return AppEx;
        //    }
        //    if (reg.id_bairro == 0) {
        //        AppEx = new Exception("Informe o bairro.");
        //        return AppEx;
        //    }
        //    if (reg.sigla_uf=="SP" && reg.id_cidade==413 && reg.logradouro_codigo==0) {
        //        AppEx = new Exception("Informe o logradouro de Jaboticabal.");
        //        return AppEx;
        //    }
        //    if ((reg.sigla_uf != "SP" || reg.id_cidade != 413) && string.IsNullOrEmpty( reg.logradouro_fora)) {
        //        AppEx = new Exception("Informe o logradouro.");
        //        return AppEx;
        //    }
            
        //    return null;
        //}

        public int RetornaCep(Int32 CodigoLogradouro, Int16 Numero) {
            Endereco_Data obj = new Endereco_Data(_connection);
            return obj.RetornaCep(CodigoLogradouro, Numero);
        }


    }
}

