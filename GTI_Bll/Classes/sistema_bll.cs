using GTI_Dal.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using static GTI_Models.modelCore;

namespace GTI_Bll.Classes {
    public class Sistema_bll {

        private string _connection;
        public Sistema_bll(string sConnection) {
            _connection = sConnection;
        }

        /// <summary>Retorna o nome completo do usuário pelo login.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public string Retorna_User_FullName(string loginName) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Retorna_User_FullName(loginName);
        }

        public string Retorna_User_FullName(int idUser) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Retorna_User_FullName(idUser);
        }


        /// <summary>Retorna o login do usuário pelo nome completo.
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public string Retorna_User_LoginName(string fullName) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Retorna_User_LoginName(fullName);
        }

        /// <summary>Retorna o Id do usuário pelo login.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public int Retorna_User_LoginId(string loginName) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Retorna_User_LoginId(loginName);
        }

        /// <summary>Retorna o login do usuário pelo Id.
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public string Retorna_User_LoginName(int idUser) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Retorna_User_LoginName(idUser);
        }

        /// <summary>Retorna a senha do usuário.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public string Retorna_User_Password(string login) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Retorna_User_Password(login);
        }

        /// <summary>Retorna os dados principais do contribuinte.
        /// </summary>
        public Contribuinte_Header_Struct Contribuinte_Header(int Codigo) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Contribuinte_Header(Codigo);
        }

        /// <summary>Verifica se o código fornacido esta cadastrado no sistema
        /// </summary>
        public bool Existe_Cadastro(int Codigo) {
            bool bRet = false;
            if (Codigo < 100000) {
                Imovel_bll clsImovel = new Imovel_bll(_connection);
                if (clsImovel.Existe_Imovel(Codigo))
                   bRet = true;
            } else if(Codigo>=100000 && Codigo<300000) {
                Empresa_bll clsEmpresa = new Empresa_bll(_connection);
                if (clsEmpresa.Existe_Empresa(Codigo))
                    bRet = true;
            } else {
                Cidadao_bll clsCidadao = new Cidadao_bll(_connection);
                if (clsCidadao.ExisteCidadao(Codigo))
                    bRet = true;
            }
            return bRet;
        }

        /// <summary>Alterar a senha de um usuário
        /// </summary>
        public Exception Alterar_Senha(Usuario reg) {
            Sistema_Data obj = new Sistema_Data(_connection);
            Exception ex = obj.Alterar_Senha(reg);
            return ex;
        }

        /// <summary>Alterar o acesso binário de um usuário
        /// </summary>
        public Exception SaveUserBinary(Usuario reg) {
            Sistema_Data obj = new Sistema_Data(_connection);
            Exception ex = obj.SaveUserBinary(reg);
            return ex;
        }

        /// <summary>Retorna a lista dos eventos de segurança do sistema
        /// </summary>
        public List<security_event> Lista_Sec_Eventos() {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Lista_Sec_Eventos();
        }

        /// <summary>Retorna o último código cadastrado da tabela usuário
        /// </summary>
        public int? Retorna_Ultimo_Codigo_Usuario() {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Retorna_Ultimo_Codigo_Usuario();
        }

        /// <summary>Incluir novo usuário
        /// </summary>
        public Exception Incluir_Usuario(Usuario reg) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Incluir_Usuario(reg);
        }

        /// <summary>Alterar o usuário selecionado
        /// </summary>
        public Exception Alterar_Usuario(Usuario reg) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Alterar_Usuario(reg);
        }

        /// <summary>Retorna os dados do usuário selecionado
        /// </summary>
        public usuarioStruct Retorna_Usuario(int Id) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Retorna_Usuario(Id);
        }


        /// <summary>Retorna a lista de todos os usuários cadastrados
        /// </summary>
        public List<usuarioStruct> Lista_Usuarios() {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Lista_Usuarios();
        }

        /// <summary>Retorna a lista dos centro de custos de um usuário
        /// </summary>
        public List<Usuariocc> Lista_Usuario_Local(int Id) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Lista_Usuario_Local(Id);
        }

        /// <summary>Grava o acesso aos centros de custo de um usuário
        /// </summary>
        public Exception Alterar_Usuario_Local(List<Usuariocc> reg) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Alterar_Usuario_Local(reg);
        }

        /// <summary>return the size of the binary string access
        /// </summary>
        public int GetSizeofBinary() {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.GetSizeofBinary();
        }

        /// <summary>Retorna a binary string do usuário.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetUserBinary(int id) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.GetUserBinary(id);
        }

        /// <summary>
        /// Retorna o tipo de cadastro baseado no código
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public TipoCadastro Tipo_Cadastro(int Codigo) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Tipo_Cadastro(Codigo);
        }

        /// <summary>
        /// Retorna o último número de remessa para o arquivo de registro bancário
        /// </summary>
        /// <returns></returns>
        public int Retorna_Ultima_Remessa_Cobranca() {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Retorna_Ultima_Remessa_Cobranca();
        }

        /// <summary>
        /// Incrementa o campo COBRANCA na tabela parametros
        /// </summary>
        /// <returns></returns>
        public Exception Atualiza_Codigo_Remessa_Cobranca() {
            Sistema_Data obj = new Sistema_Data(_connection);
            Exception ex = obj.Atualiza_Codigo_Remessa_Cobranca();
            return ex;
        }

        /// <summary>
        /// Retorna os códigos imobiliários, mobiliários e de cidadão de um Cpf/Cnpj
        /// </summary>
        /// <param name="Documento"></param>
        /// <param name="_tipo"></param>
        /// <returns></returns>
        public List<int> Lista_Codigos_Documento(string Documento, TipoDocumento _tipo) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Lista_Codigos_Documento(Documento,_tipo);
        }

        /// <summary>
        /// Incluir um evento na tabela de logevento
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Incluir_LogEvento(Logevento reg) {
            Sistema_Data obj = new Sistema_Data(_connection);
            Exception ex = obj.Incluir_LogEvento(reg);
            return ex;
        }

        public string Retorna_Valor_Parametro(string ParameterName) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Retorna_Valor_Parametro(ParameterName);
        }

        public string Nome_por_Cpf(string cpf) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Nome_por_Cpf(cpf);
        }

        public string Nome_por_Cnpj(string cnpj) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Nome_por_Cnpj(cnpj);
        }

    }
}
