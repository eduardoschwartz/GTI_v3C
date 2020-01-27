using System;
using System.Collections.Generic;
using GTI_Models.Models;
using GTI_Dal.Classes;

namespace GTI_Bll.Classes {
    public class Processo_bll {

        private string _connection;
        Exception AppEx = null;

        public Processo_bll(string sConnection) {
            _connection = sConnection;
        }

        public List<Documento> Lista_Documento() {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.Lista_Documento();
        }

        public Exception Incluir_Documento(Documento reg) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Incluir_Documento(reg);
            return ex;
        }

        public Exception Alterar_Documento(Documento reg) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Alterar_Documento(reg);
            return ex;
        }

        public Exception Alterar_Observacao_Tramite(int Ano, int Numero, int Seq, string Observacao) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Alterar_Observacao_Tramite(Ano, Numero, Seq, Observacao);
            return ex;
        }

        public Exception Alterar_Despacho(int Ano, int Numero, int Seq, short CodigoDespacho) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Alterar_Despacho(Ano, Numero, Seq, CodigoDespacho);
            return ex;
        }

        public Exception Excluir_Documento(Documento reg) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Excluir_Documento(reg);
            return ex;
        }

        public string Retorna_Documento(int Codigo) {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.Retorna_Documento(Codigo);
        }

        public List<Despacho> Lista_Despacho() {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.Lista_Despacho();
        }

        public Exception Incluir_Despacho(Despacho reg) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Incluir_Despacho(reg);
            return ex;
        }

        public Exception Alterar_Despacho(Despacho reg) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Alterar_Despacho(reg);
            return ex;
        }

        public Exception Excluir_Despacho(Despacho reg) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Excluir_Despacho(reg);
            return ex;
        }

        public string Retorna_Despacho(int Codigo) {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.Retorna_Despacho(Codigo);
        }

        public Exception Incluir_Assunto_Local(List<Assuntocc> Lista) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Incluir_Assunto_Local(Lista);
            return ex;
        }

        public Exception Incluir_Assunto_Documento(List<Assuntodoc> Lista) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Incluir_Assunto_Documento(Lista);
            return ex;
        }

        public List<Assunto> Lista_Assunto(bool Somente_Ativo, bool Somente_Inativo, string Filter = "") {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.Lista_Assunto(Somente_Ativo, Somente_Inativo, Filter);
        }

        public List<AssuntoLocal> Lista_Assunto_Local(short Assunto) {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.Lista_Assunto_Local(Assunto);
        }

        public List<AssuntoDocStruct> Lista_Assunto_Documento(short Assunto) {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.Lista_Assunto_Documento(Assunto);
        }

        public Exception Incluir_Assunto(Assunto reg) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Incluir_Assunto(reg);
            return ex;
        }

        public Exception Alterar_Assunto(Assunto reg) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Alterar_Assunto(reg);
            return ex;
        }

        public Exception Excluir_Assunto(Assunto reg) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = Assunto_uso_processo(reg.Codigo);
            if (ex == null)
                ex = obj.Excluir_Assunto(reg);
            return ex;
        }

        public string Retorna_Assunto(int Codigo) {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.Retorna_Assunto(Codigo);
        }

        public List<Centrocusto> Lista_Local(bool Somente_Ativo,bool Local) {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.Lista_Local(Somente_Ativo,Local);
        }

        public Exception Incluir_Local(Centrocusto reg) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Incluir_Local(reg);
            return ex;
        }

        public Exception Alterar_Local(Centrocusto reg) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Alterar_Local(reg);
            return ex;
        }

        public Exception Excluir_Local(int Codigo) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Excluir_Local(Codigo);
            return ex;
        }

        public short Retorna_Ultimo_Codigo_Local() {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.Retorna_Ultimo_Codigo_Local();
        }

        ///<summary> Verifica se o número fornecido é de um processo válido.
        ///</summary>
        public Exception ValidaProcesso(string sInput) {
            Exception AppEx;
            string sNumero = sInput.Trim();
            int Numero = 0;
            int Ano = 0;
            int Dv = 0;
            string sDv = "";
            string sNumTmp = "";
            string AnoTmp = "";
            if (sNumero.Length < 7) {
                AppEx = new Exception("Número de processo inválido!");
                return AppEx;
            } else {
                AnoTmp = (sNumero.Substring(sNumero.Length - 4));
                if (!bllCore.IsNumeric(AnoTmp)) {
                    AppEx = new Exception("Número de processo inválido!");
                    return AppEx;
                } else {
                    Ano = Convert.ToInt32(AnoTmp);
                    if (Ano < 1900 || Ano > DateTime.Now.Year + 1) {
                        AppEx = new Exception("Número de processo inválido!");
                        return AppEx;
                    } else {
                        if (sNumero.Contains("-") && sNumero.Contains("/")) {
                            if (sNumero.IndexOf("-") > sNumero.IndexOf("/")) {
                                AppEx = new Exception("Número de processo inválido!");
                                return AppEx;
                            } else {
                                if (sNumero.IndexOf("/") - sNumero.IndexOf("-") > 2) {
                                    AppEx = new Exception("Número de processo inválido!");
                                    return AppEx;
                                }
                            }
                        }
                        if (sNumero.Contains("-")) {
                            sDv = sNumero.Substring(sNumero.IndexOf("-") + 1, 1);
                            sNumTmp = sNumero.Substring(0, sNumero.IndexOf("-"));
                        } else {
                            sDv = sNumero.Substring(sNumero.IndexOf("/") - 1, 1);
                            sNumTmp = sNumero.Substring(0, sNumero.IndexOf("/") - 1);
                        }
                        Numero = Convert.ToInt32(sNumTmp);
                        if (!bllCore.IsNumeric(sDv)) {
                            AppEx = new Exception("Número de processo inválido!");
                            return AppEx;
                        } else {
                            Dv = Convert.ToInt32(sDv);
                            if (Dv != DvProcesso(Numero)) {
                                AppEx = new Exception("Número de processo inválido!");
                                return AppEx;
                            } else
                                if (!Existe_Processo(Ano, Numero)) {
                                AppEx = new Exception("Processo não cadastrado!");
                                return AppEx;
                            }
                        }
                    }
                }
            }

            return null;
        }

        ///<summary> Retorna o dígito verificador de um número de processo.
        ///O dígito verificador é o mesmo para todos os números iguais, independente do ano do processo.
        ///</summary>
        public int DvProcesso(int Numero) {
            int soma = 0, index = 0, Mult = 6;
            string sNumProc = Numero.ToString().PadLeft(5, '0');
            while (index < 5) {
                int nChar = Convert.ToInt32(sNumProc.Substring(index, 1));
                soma += (Mult * nChar);
                Mult--;
                index++;
            }

            int DigAux = soma % 11;
            int Digito = 11 - DigAux;
            if (Digito == 10)
                Digito = 0;
            if (Digito == 11)
                Digito = 1;

            return Digito;
        }

        ///<summary> Verifica se um processo esta cadastrado.
        ///</summary>
        public bool Existe_Processo(int Ano, int Numero) {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.Existe_Processo(Ano, Numero);
        }

        ///<summary> Retorna o número do processo sem o dígito verificador.
        ///</summary>
        public int ExtractNumeroProcessoNoDV(string NumProc) {
            if (String.IsNullOrWhiteSpace(NumProc))
                return 0;
            else {
                if (NumProc.Contains("-"))
                    return Convert.ToInt32(NumProc.Substring(0, NumProc.IndexOf("-")));
                else
                    return Convert.ToInt32(NumProc.Substring(0, NumProc.IndexOf("/") - 1));
            }
        }

        /// <summary>
        /// Insere o digito verificador nos números de processo que foam gravados sem.
        /// </summary>
        /// <param name="Numero_Processo_sem_DV"></param>
        /// <returns></returns>
        public string Retorna_Processo_com_DV(string Numero_Processo_sem_DV) {
            string sAno;
            int nNumero, nDv;
            sAno = bllCore.StringRight(Numero_Processo_sem_DV, 4);
            nNumero = ExtractNumeroProcessoNoDV(Numero_Processo_sem_DV);
            nDv = DvProcesso(nNumero);
            return nNumero.ToString() + "-" + nDv.ToString() + "/" + sAno;
        }

        ///<summary> Extrai o ano do processo de um número de processo.
        ///</summary>
        public short ExtractAnoProcesso(string NumProc) {
            return Convert.ToInt16(bllCore.StringRight(NumProc, 4));
        }

        ///<summary> Retorna todos os dados de um proceso.
        ///</summary>
        public ProcessoStruct Dados_Processo(int nAno, int nNumero) {
            Processo_Data obj = new Processo_Data(_connection);
            ProcessoStruct reg = obj.Dados_Processo(nAno, nNumero);
            return reg;
        }

        public Exception Cancelar_Processo(int Ano, int Numero, string Observacao) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Cancelar_Processo(Ano, Numero, Observacao);
            return ex;
        }

        public Exception Reativar_Processo(int Ano, int Numero, string Observacao) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Reativar_Processo(Ano, Numero, Observacao);
            return ex;
        }

        public Exception Suspender_Processo(int Ano, int Numero, string Observacao) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Suspender_Processo(Ano, Numero, Observacao);
            return ex;
        }

        public Exception Arquivar_Processo(int Ano, int Numero, string Observacao) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Arquivar_Processo(Ano, Numero, Observacao);
            return ex;
        }

        public Exception Incluir_Historico_Processo(short Ano, int Numero, string Historico, string Usuario) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Incluir_Historico_Processo(Ano, Numero, Historico, Usuario);
            return ex;
        }

        ///<summary> Retorna os dados do cidadão original que requereu o processo.
        ///</summary>
        public ProcessoCidadaoStruct Processo_cidadao_old(short ano_Processo, int num_Processo) {
            Processo_Data obj = new Processo_Data(_connection);
            ProcessoCidadaoStruct reg = obj.Processo_cidadao_old(ano_Processo, num_Processo);
            return reg;
        }

        public Exception Excluir_Anexo(Anexo reg, string usuario) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Excluir_Anexo(reg, usuario);
            return ex;
        }

        public Exception Incluir_Anexo(Anexo reg, string usuario) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Incluir_Anexo(reg, usuario);
            return ex;
        }

        ///<summary>Verifica se o assunto enviado esta sendo utilizado em algum processo para evitar exclusão do mesmo.
        ///</summary>
        public Exception Assunto_uso_processo(short Codigo_Assunto) {
            Processo_Data obj = new Processo_Data(_connection);
            bool bAssunto = obj.Assunto_uso_processo(Codigo_Assunto);
            if (bAssunto)
                AppEx = new Exception("Exclusão não permitida. Assunto em uso.");
            return AppEx;
        }

        ///<summary> Após carregado o trâmite padrão para o assunto selecionado, 
        ///então todo o trâmite, independente se foi alterado pelo usuário ou não,
        ///passa a ser carregado nas próximas vezes a partir da tabela movimentocc e não mais da tabela assuntocc.
        ///</summary>
        public Exception Incluir_MovimentoCC(short Ano, int Numero, List<TramiteStruct> Lista) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Incluir_MovimentoCC(Ano, Numero, Lista);
            return ex;
        }

        ///<summary>Retorna a lista contendo os trâmites do processo.
        ///</summary>
        public List<TramiteStruct> DadosTramite(short Ano, int Numero, int CodAssunto) {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.DadosTramite(Ano, Numero, CodAssunto);
        }

        ///<summary>Retorna a lista dos centros de custo que o usuário tem permissão de tramitar
        ///</summary>
        public List<UsuariocentroCusto> ListaCentrocustoUsuario(int idLogin) {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.ListaCentrocustoUsuario(idLogin);
        }

        ///<summary>Retorna a lista dos usuários de fora que são tramitados pelo setor de protocolo
        ///</summary>
        public List<UsuarioFuncStruct> ListaFuncionario(int LoginId) {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.ListaFuncionario(LoginId);
        }

        public Exception Excluir_Tramite(int Ano, int Numero, int Seq) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Excluir_Tramite(Ano, Numero, Seq);
            return ex;
        }

        public Exception Incluir_Tramite(Tramitacao Reg) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Incluir_Tramite(Reg);
            return ex;
        }

        public Exception Alterar_Tramite(Tramitacao Reg) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Alterar_Tramite(Reg);
            return ex;
        }

        ///<summary>Verifica se o cidadão esta em algum processo para evitar que ele seja excluido
        ///</summary>
        public bool Cidadao_Processo(int id_cidadao) {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.Cidadao_Processo(id_cidadao);
        }
        
        /// <summary>
        /// Retorna a lista filtrada dos processos cadastrados.
        /// </summary>
        /// <param name="Filter"></param>
        /// <returns></returns>
        public List<ProcessoStruct> Lista_Processos(ProcessoFilter Filter) {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.Lista_Processos(Filter);
        }

        /// <summary>
        /// Retorna a data de abertura do processo.
        /// </summary>
        /// <param name="Ano"></param>
        /// <param name="Numero"></param>
        /// <returns></returns>
        public DateTime? Data_Processo(int Ano, int Numero) {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.Data_Processo(Ano,Numero);
        }

        /// <summary>
        /// Incluir um novo processo
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Incluir_Processo(Processogti reg) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Incluir_Processo(reg);
            return ex;
        }

        /// <summary>
        /// Retorna o próximo número de processo
        /// </summary>
        /// <param name="Ano"></param>
        /// <returns></returns>
        public int Retorna_Numero_Disponivel(int Ano) {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.Retorna_Numero_Disponivel(Ano);
        }

        /// <summary>
        /// Incluir os endereços de um processo
        /// </summary>
        /// <param name="Lista"></param>
        /// <returns></returns>
        public Exception Incluir_Processo_Endereco(List<Processoend> Lista,int Ano,int Numero) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Incluir_Processo_Endereco(Lista,Ano,Numero);
            return ex;
        }

        /// <summary>
        /// Incluir os documentos de um processo
        /// </summary>
        /// <param name="Lista"></param>
        /// <param name="Ano"></param>
        /// <param name="Numero"></param>
        /// <returns></returns>
        public Exception Incluir_Processo_Documento(List<Processodoc> Lista, int Ano, int Numero) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Incluir_Processo_Documento(Lista, Ano, Numero);
            return ex;
        }

        /// <summary>
        /// Alterar os dados de um processo.
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Alterar_Processo(Processogti reg) {
            Processo_Data obj = new Processo_Data(_connection);
            Exception ex = obj.Alterar_Processo(reg);
            return ex;
        }

        /// <summary>
        /// Retorna os números de processo de parcelamento de uma inscrição
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<Processo_Numero> Lista_Processo_Parcelamento_Header(int Codigo) {
            Processo_Data obj = new Processo_Data(_connection);
            return obj.Lista_Processo_Parcelamento_Header(Codigo);
        }


    }
}
