using GTI_Dal.Classes;
using GTI_Models;
using GTI_Models.Models;
using System;
using System.Collections.Generic;

namespace GTI_Bll.Classes {
    public class Tributario_bll {

        private static string _connection;

        public Tributario_bll(string sConnection) {
            _connection = sConnection;
        }

        ///<summary> Retorna o dígito verificador de um número de documento.
        ///</summary>
        public int DvDocumento(int Numero) {
            string sFromN = Numero.ToString("00000000");
            int nTotPosAtual = 0;

            nTotPosAtual = Convert.ToInt32(sFromN.Substring(0, 1)) * 7;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(1, 1)) * 3;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(2, 1)) * 9;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(3, 1)) * 7;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(4, 1)) * 3;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(5, 1)) * 9;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(6, 1)) * 7;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(7, 1)) * 3;

            string ret = nTotPosAtual.ToString();
            return Convert.ToInt32(ret.Substring(ret.Length - 1));

        }

        ///<summary> Retorna a lista dos lançamentos cadastrados.///</summary>
        public List<Lancamento> Lista_Lancamento() {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Lancamento();
        }

        ///<summary> Retorna a lista dos tributos cadastrados.
        ///</summary>
        public List<Tributo> Lista_Tributo(int Codigo=0) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Tributo(Codigo);
        }

        ///<summary> Retorna a lista dos tipos de livros cadastrados.
        ///</summary>
        public List<Tipolivro> Lista_Tipo_Livro() {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Tipo_Livro();
        }

        ///<summary> Incluir lancamento na tela de cadastro de lançamentos.
        ///</summary>
        public Exception Insert_Lancamento(Lancamento reg) {
            Exception AppEx ;
            if (String.IsNullOrWhiteSpace(reg.Descfull)) {
                AppEx = new Exception("Digite a descrição completa");
                return AppEx;
            }
            if (String.IsNullOrWhiteSpace(reg.Descreduz)) {
                AppEx = new Exception("Digite a descrição resumida");
                return AppEx;
            }
            if (reg.Tipolivro==null||reg.Tipolivro==0|| reg.Tipolivro==-1) {
                AppEx = new Exception("Selecione o tipo de livro.");
                return AppEx;
            }
            if (Existe_Lancamento(reg)) {
                AppEx = new Exception("Já existe um lançamento com esta descrição.");
                return AppEx;
            }

            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Lancamento(reg);
            return ex;
        }

        ///<summary> Incluir tributo na tela de cadastro de tributos.
        ///</summary>
        public Exception Insert_Tributo(Tributo reg) {
            Exception AppEx;
            if (String.IsNullOrWhiteSpace(reg.Desctributo)) {
                AppEx = new Exception("Digite a descrição completa");
                return AppEx;
            }
            if (String.IsNullOrWhiteSpace(reg.Abrevtributo)) {
                AppEx = new Exception("Digite a descrição resumida");
                return AppEx;
            }
            if (Existe_Tributo(reg)) {
                AppEx = new Exception("Já existe um tributo com esta descrição.");
                return AppEx;
            }

            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Tributo(reg);
            return ex;
        }

        ///<summary> Alterar lancamento na tela de cadastro de lançamentos.
        ///</summary>
        public Exception Alterar_Lancamento(Lancamento reg) {
            Exception AppEx;
            if (String.IsNullOrWhiteSpace(reg.Descfull)) {
                AppEx = new Exception("Digite a descrição completa");
                return AppEx;
            }
            if (String.IsNullOrWhiteSpace(reg.Descreduz)) {
                AppEx = new Exception("Digite a descrição resumida");
                return AppEx;
            }
            if (reg.Tipolivro == null || reg.Tipolivro == 0 || reg.Tipolivro == -1) {
                AppEx = new Exception("Selecione o tipo de livro.");
                return AppEx;
            }
            if (Existe_Lancamento(reg,false)) {
                AppEx = new Exception("Já existe um lançamento com esta descrição.");
                return AppEx;
            }

            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Alterar_Lancamento(reg);
            return ex;
        }

        ///<summary> Alterar tributo na tela de cadastro de tributos.
        ///</summary>
        public Exception Alterar_Tributo(Tributo reg) {
            Exception AppEx;
            if (String.IsNullOrWhiteSpace(reg.Desctributo)) {
                AppEx = new Exception("Digite a descrição completa");
                return AppEx;
            }
            if (String.IsNullOrWhiteSpace(reg.Desctributo)) {
                AppEx = new Exception("Digite a descrição resumida");
                return AppEx;
            }
            if (Existe_Tributo(reg, false)) {
                AppEx = new Exception("Já existe um tributo com esta descrição.");
                return AppEx;
            }

            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Alterar_Tributo(reg);
            return ex;
        }

        ///<summary> Verifica se já existe um lancamento com esta descrição
        ///</summary>
        public bool Existe_Lancamento(Lancamento reg, bool novo = true) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Existe_Lancamento(reg, novo);
        }

        ///<summary> Verifica se já existe um tributo com esta descrição
        ///</summary>
        public bool Existe_Tributo(Tributo reg, bool novo = true) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Existe_Tributo(reg, novo);
        }

        ///<summary> Excluir lancamento na tela de cadastro de lançamentos.
        ///</summary>
        public Exception Excluir_Lancamento(Lancamento reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = Lancamento_em_uso(reg.Codlancamento);
            if (ex == null)
                ex = obj.Excluir_Lancamento(reg);
            return ex;
        }

        ///<summary> Excluir tributo na tela de cadastro de tributos.
        ///</summary>
        public Exception Excluir_Tributo(Tributo reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = Tributo_em_uso(reg.Codtributo);
            if (ex == null)
                ex = obj.Excluir_Tributo(reg);
            return ex;
        }

        ///<summary> Verifica se o lançamento esta sendo utilizado no sistema.
        ///</summary>
        private Exception Lancamento_em_uso(int codigo_lancamento) {
            Exception AppEx = null;
            Tributario_Data obj = new Tributario_Data(_connection);
            bool bdebitoparcela = obj.Lancamento_uso_debito(codigo_lancamento);
            if (bdebitoparcela)
                AppEx = new Exception("Exclusão não permitida. Lançamento em uso - Débitos.");
            else {
                bool btributolançamento = obj.Lancamento_uso_tributo(codigo_lancamento);
                if (btributolançamento)
                    AppEx = new Exception("Exclusão não permitida. Lançamento com tributos cadastrados.");
            }
            return AppEx;
        }

        ///<summary> Verifica se o tributo esta sendo utilizado no sistema.
        ///</summary>
        private Exception Tributo_em_uso(int codigo_tributo) {
            Exception AppEx = null;
            Tributario_Data obj = new Tributario_Data(_connection);
            bool bdebitotributo = obj.Tributo_uso_debito(codigo_tributo);
            if (bdebitotributo)
                AppEx = new Exception("Exclusão não permitida. Tributo em uso - Débitos.");
            else {
                bool btributolançamento = obj.Tributo_uso_lancamento(codigo_tributo);
                if (btributolançamento)
                    AppEx = new Exception("Exclusão não permitida. Tributo em uso - Lançamentos.");
                else {
                    bool btributoaliquota = obj.Tributo_uso_aliquota(codigo_tributo);
                    if (btributoaliquota)
                        AppEx = new Exception("Exclusão não permitida. Tributo em uso - Aliquotas.");
                }
            }
            return AppEx;
        }

        ///<summary> Retorna todas as linhas da spExtratoNew
        ///</summary>
        public List<SpExtrato> Lista_Extrato_Tributo(int Codigo=3, short Ano1 = 1990, short Ano2 = 2050, short Lancamento1 = 1, short Lancamento2 = 99, short Sequencia1 = 0, short Sequencia2 = 9999,
            short Parcela1 = 0, short Parcela2 = 999, short Complemento1 = 0, short Complemento2 = 999, short Status1 = 0, short Status2 = 99, DateTime? Data_Atualizacao = null, string Usuario = "") {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Extrato_Tributo(Codigo,Ano1,Ano2,Lancamento1,Lancamento2,Sequencia1,Sequencia2,Parcela1,Parcela2,Complemento1,Complemento2,Status1,Status2,Data_Atualizacao,Usuario);
        }

        ///<summary> Retorna todas as linhas da spExtrato_carta
        ///</summary>
        public List<SpExtrato_carta> Lista_Extrato_Tributo_Carta(int Codigo = 3, short Ano1 = 1990, short Ano2 = 2050, short Lancamento1 = 1, short Lancamento2 = 99, short Sequencia1 = 0, short Sequencia2 = 9999,
            short Parcela1 = 0, short Parcela2 = 999, short Complemento1 = 0, short Complemento2 = 999, short Status1 = 0, short Status2 = 99, DateTime? Data_Atualizacao = null, string Usuario = "") {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Extrato_Tributo_Carta(Codigo, Ano1, Ano2, Lancamento1, Lancamento2, Sequencia1, Sequencia2, Parcela1, Parcela2, Complemento1, Complemento2, Status1, Status2, Data_Atualizacao, Usuario);
        }

        ///<summary> Agrupa as linhas da spExtratoNew por parcela
        ///</summary>
        public List<SpExtrato> Lista_Extrato_Parcela(List<SpExtrato> Lista_Debito) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Extrato_Parcela(Lista_Debito);
        }

        ///<summary> Agrupa as linhas da spExtrato_Carta por parcela
        ///</summary>
        public List<SpExtrato_carta> Lista_Extrato_Parcela_Carta(List<SpExtrato_carta> Lista_Debito) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Extrato_Parcela_Carta(Lista_Debito);
        }

        ///<summary> Retorna os tipos de status dos lançamentos
        ///</summary>
        public List<Situacaolancamento> Lista_Status() {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Status();
        }

        ///<summary> Retorna a taxa de expediente de um lançamento
        ///</summary>
        public double Retorna_Taxa_Expediente(int codigo, short ano, short lancamento, short sequencia, short parcela, short complemento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Taxa_Expediente( codigo,  ano,  lancamento, sequencia,  parcela, complemento);
        }

        ///<summary> Retorna a lista com todas as observações das parcelas de um código
        ///</summary>
        public List<ObsparcelaStruct> Lista_Observacao_Parcela(int codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Observacao_Parcela(codigo);
        }

        ///<summary> Incluir uma nova observação na parcela
        ///</summary>
        public Exception Insert_Observacao_Parcela(Obsparcela reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Observacao_Parcela(reg);
            return ex;
        }

        ///<summary> Alterar uma observação na parcela cadastrada
        ///</summary>
        public Exception Alterar_Observacao_Parcela(Obsparcela reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Alterar_Observacao_Parcela(reg);
            return ex;
        }

        ///<summary> Retorna a última sequência de uma observação de parcela
        ///</summary>
        public short Retorna_Ultima_Seq_Observacao_Parcela(int Codigo, int Ano, short Lanc, short Sequencia, short Parcela, short Complemento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Ultima_Seq_Observacao_Parcela(Codigo,Ano,Lanc,Sequencia,Parcela,Complemento);
        }

        ///<summary> Excluir uma observação de parcela
        ///</summary>
        public Exception Excluir_Observacao_Parcela(Obsparcela reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex  = obj.Excluir_Observacao_Parcela(reg);
            return ex;
        }

        ///<summary> Retorna a lista com todas as observações de um código
        ///</summary>
        public List<DebitoobservacaoStruct> Lista_Observacao_Codigo(int codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Observacao_Codigo(codigo);
        }

        ///<summary> Incluir uma nova observação no código
        ///</summary>
        public Exception Insert_Observacao_Codigo(Debitoobservacao reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Observacao_Codigo(reg);
            return ex;
        }

        ///<summary> Retorna a última sequência de uma observação de um contribuinte
        ///</summary>
        public short Retorna_Ultima_Seq_Observacao_Codigo(int Codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Ultima_Seq_Observacao_Codigo(Codigo);
        }

        ///<summary> Alterar uma observação de um código
        ///</summary>
        public Exception Alterar_Observacao_Codigo(Debitoobservacao reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Alterar_Observacao_Codigo(reg);
            return ex;
        }

        ///<summary> Excluir uma observação de um código
        ///</summary>
        public Exception Excluir_Observacao_Codigo(int Codigo, short Seq) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Excluir_Observacao_Codigo(Codigo,Seq);
            return ex;
        }

        ///<summary> Retorna a última sequência de uma observação de um contribuinte
        ///</summary>
        public short Retorna_Ultima_Seq_Honorario(int Codigo,int Ano) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Ultima_Seq_Honorario(Codigo,Ano);
        }

        public short Retorna_Ultima_Seq_AR(int Codigo, int Ano) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Ultima_Seq_AR(Codigo, Ano);
        }


        ///<summary> Retorna a lista de documentos de uma parcela
        ///</summary>
        public List<Numdocumento> Lista_Parcela_Documentos(Parceladocumento reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Parcela_Documentos(reg);
        }

        /// <summary>
        /// Lista tabela parceladocumento
        /// </summary>
        /// <param name="nNumdocumento"></param>
        /// <returns></returns>
        public List<DebitoStructure> Lista_Tabela_Parcela_Documento(int nNumdocumento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Tabela_Parcela_Documento(nNumdocumento);
        }

        /// <summary>
        /// Insere na tabela boletoguia
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Boleto_Guia(Boletoguia Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Boleto_Guia(Reg);
            return ex;
        }

        /// <summary>
        /// Insere na tabela segunda_via_web
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Numero_Segunda_Via(Segunda_via_web Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Numero_Segunda_Via(Reg);
            return ex;
        }

        /// <summary>
        /// Lista a tabela boletoguia
        /// </summary>
        /// <param name="nSid"></param>
        /// <returns></returns>
        public List<Boletoguia> Lista_Boleto_Guia(int nSid) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Boleto_Guia(nSid);
        }

        /// <summary>
        /// Parcelas da CIP para impressão na Web
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <param name="nAno"></param>
        /// <returns></returns>
        public List<DebitoStructure> Lista_Parcelas_CIP(int nCodigo, int nAno) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Parcelas_CIP(nCodigo,nAno);
        }

        /// <summary>
        /// Parcelas de IPTU para impressão na Web
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <param name="nAno"></param>
        /// <returns></returns>
        public List<DebitoStructure> Lista_Parcelas_IPTU(int nCodigo, int nAno) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Parcelas_IPTU(nCodigo, nAno);
        }

        /// <summary>
        /// Prepara os dados para imprimir o carnê na web
        /// </summary>
        /// <param name="Codigo"></param>
        /// <param name="Ano"></param>
        /// <returns></returns>
        public Exception Insert_Carne_Web(int Codigo, int Ano) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Carne_Web(Codigo, Ano);
            return ex;
        }

        /// <summary>
        /// Apaga os dados temporários do carnê na web
        /// </summary>
        /// <param name="nSid"></param>
        /// <returns></returns>
        public Exception Excluir_Carne(int nSid) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Excluir_Carne(nSid);
            return ex;
        }

        /// <summary>
        /// Carrega os dados de IPTU de um código no ano informado
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <param name="nAno"></param>
        /// <returns></returns>
        public Laseriptu Carrega_Dados_IPTU(int nCodigo, int nAno) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Carrega_Dados_IPTU(nCodigo, nAno);
        }

        /// <summary>
        /// Pesquisa o endereço de um terreno lançado na CIP 
        /// </summary>
        /// <param name="nNumDocumento"></param>
        /// <returns></returns>
        public bool Existe_Documento_CIP(int nNumDocumento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Existe_Documento_CIP(nNumDocumento);
        }

        /// <summary>
        /// Retorna o código reduzido associado a um documento
        /// </summary>
        /// <param name="nNumDocumento"></param>
        /// <returns></returns>
        public int Retorna_Codigo_por_Documento(int nNumDocumento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Codigo_por_Documento(nNumDocumento);
        }

        /// <summary>
        /// Retorna verdadeiro se o Refis esta ativo
        /// </summary>
        /// <returns></returns>
        public bool IsRefis() {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.IsRefis();
        }

        /// <summary>
        /// Retorna verdadeiro se o Refis do Distrito Industrial esta ativo
        /// </summary>
        /// <returns></returns>
        public bool IsRefisDI() {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.IsRefisDI();
        }

        /// <summary>
        /// Grava um novo documento
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public int Insert_Documento(Numdocumento Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Insert_Documento(Reg);
        }

        /// <summary>
        /// Grava na tabela parceladocumento
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Parcela_Documento(Parceladocumento Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Parcela_Documento(Reg);
            return ex;
        }

        /// <summary>
        /// Envia os débitos para serem impressos na DAM
        /// </summary>
        /// <param name="lstDebito"></param>
        /// <param name="nNumDoc"></param>
        /// <param name="DataBoleto"></param>
        /// <returns></returns>
        public Int32 Insert_Boleto_DAM(List<DebitoStructure> lstDebito, Int32 nNumDoc, DateTime DataBoleto) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Insert_Boleto_DAM(lstDebito,nNumDoc,DataBoleto);
        }

        /// <summary>
        /// Lista a tabela boleto
        /// </summary>
        /// <param name="nSid"></param>
        /// <returns></returns>
        public List<Boleto> Lista_Boleto_DAM(int nSid) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Boleto_DAM(nSid);
        }

        /// <summary>
        /// Verifica se o documento informado já foi gerado pelo comércio eletrônico
        /// </summary>
        /// <param name="nNumDocumento"></param>
        /// <returns></returns>
        public bool Existe_Comercio_Eletronico(int nNumDocumento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Existe_Comercio_Eletronico(nNumDocumento);
        }

        /// <summary>
        /// Grava na tabela comercio_eletronico
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Boleto_Comercio_Eletronico(comercio_eletronico Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Boleto_Comercio_Eletronico(Reg);
            return ex;
        }

        /// <summary>
        /// Verifica a existência de um número de documento
        /// </summary>
        /// <param name="nNumDocumento"></param>
        /// <returns></returns>
        public bool Existe_Documento(int nNumDocumento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Existe_Documento(nNumDocumento);
        }

        /// <summary>
        /// Retorna o cadastro de um documento
        /// </summary>
        /// <param name="nNumDocumento"></param>
        /// <returns></returns>
        public Numdocumento Retorna_Dados_Documento(int nNumDocumento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Dados_Documento(nNumDocumento);
        }

        /// <summary>
        /// Retorna o próximo código da certidão requerida e incrementa a sequência
        /// </summary>
        /// <param name="tipo_certidao"></param>
        /// <returns></returns>
        public int Retorna_Codigo_Certidao(modelCore.TipoCertidao tipo_certidao) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Codigo_Certidao(tipo_certidao);
        }

        /// <summary>
        /// Insere na tabela certidaoenderecoatualizado
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Certidao_Endereco(Certidao_endereco Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Certidao_Endereco(Reg);
            return ex;
        }

        /// <summary>
        /// Retorna os dados da certidão de endereço
        /// </summary>
        /// <param name="Ano"></param>
        /// <param name="Numero"></param>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public Certidao_endereco Retorna_Certidao_Endereco(int Ano, int Numero, int Codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Certidao_Endereco(Ano,Numero,Codigo);
        }

        /// <summary>
        /// Retorna os dados da certidão de valor venal
        /// </summary>
        /// <param name="Ano"></param>
        /// <param name="Numero"></param>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public Certidao_valor_venal Retorna_Certidao_ValorVenal(int Ano, int Numero, int Codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Certidao_ValorVenal(Ano, Numero, Codigo);
        }

        /// <summary>
        /// Retorna os dados da certdão de isenção
        /// </summary>
        /// <param name="Ano"></param>
        /// <param name="Numero"></param>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public Certidao_isencao Retorna_Certidao_Isencao(int Ano, int Numero, int Codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Certidao_Isencao(Ano, Numero, Codigo);
        }

        /// <summary>
        /// Retorna os dados da certidão de débitos
        /// </summary>
        /// <param name="Ano"></param>
        /// <param name="Numero"></param>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public Certidao_debito Retorna_Certidao_Debito(int Ano, int Numero, int Codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Certidao_Debito(Ano, Numero, Codigo);
        }

        /// <summary>
        /// Retorna os dados da certidão de débitos
        /// </summary>
        /// <param name="Validacao"></param>
        /// <returns></returns>
        public certidao_debito_doc Retorna_Certidao_Debito_Doc(string Validacao) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Certidao_Debito_Doc(Validacao);
        }

        /// <summary>
        /// Insere na tabela certidao_valor_venal
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Certidao_ValorVenal(Certidao_valor_venal Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Certidao_ValorVenal(Reg);
            return ex;
        }

        /// <summary>
        /// Insere na tabela certidao_isencao
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Certidao_Isencao(Certidao_isencao Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Certidao_Isencao(Reg);
            return ex;
        }

        /// <summary>
        /// Insere na tabela certidao_inscricao
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Certidao_Inscricao(Certidao_inscricao Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Certidao_Inscricao(Reg);
            return ex;
        }

        /// <summary>
        /// Insere na tabela certidao_debito
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Certidao_Debito(Certidao_debito Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Certidao_Debito(Reg);
            return ex;
        }

        /// <summary>
        /// Insere na tabela certidao_debito_doc
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Certidao_Debito_Doc(certidao_debito_doc Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Certidao_Debito_Doc(Reg);
            return ex;
        }

        /// <summary>
        /// Retorna as infomações para a certidão de débitos
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public Certidao_debito_detalhe Certidao_Debito(int Codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Certidao_Debito( Codigo);
        }

        /// <summary>
        /// Retorna o cálculo de IPTU do ano especificado
        /// </summary>
        /// <param name="Codigo"></param>
        /// <param name="Ano"></param>
        /// <returns></returns>
        public SpCalculo Calculo_IPTU(int Codigo, int Ano) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Calculo_IPTU(Codigo,Ano);
        }

      

        /// <summary>
        /// Retorna a qtde de meses nas quais a competência não foi encerrada
        /// </summary>
        /// <param name="Lista"></param>
        /// <returns></returns>
        public int Competencias_Nao_Encerradas(List<CompetenciaISS> Lista) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Competencias_Nao_Encerradas(Lista);
        }

        /// <summary>
        ///Retorna os dados da certidão de inscrição 
        /// </summary>
        /// <param name="Ano"></param>
        /// <param name="Numero"></param>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public Certidao_inscricao Retorna_Certidao_Inscricao(int Ano, int Numero, int Codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Certidao_Inscricao(Ano,Numero,Codigo);
        }

        /// <summary>
        /// Inserir registro na tabela relatorio_inscricao
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Certidao_Inscricao_Extrato(Certidao_inscricao_extrato Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Certidao_Inscricao_Extrato(Reg);
            return ex;
        }

        /// <summary>
        /// Retorna dados do pagamento através do nº do documento 
        /// </summary>
        /// <param name="nNumDocumento"></param>
        /// <returns></returns>
        public DebitoPagoStruct Retorna_DebitoPago_Documento(int nNumDocumento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_DebitoPago_Documento(nNumDocumento);
        }

        /// <summary>
        /// Insere dados do comprovante de pagamento
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Comprovante_Pagamento(Comprovante_pagamento Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Insert_Comprovante_Pagamento(Reg);
        }

        /// <summary>
        /// Insere dados na tabela carta_cobranca
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Carta_Cobranca(Carta_cobranca Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Carta_Cobranca(Reg);
            return ex;
        }

        /// <summary>
        /// Insere na tabela alvara_funcionamento
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Alvara_Funcionamento(Alvara_funcionamento Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Alvara_Funcionamento(Reg);
            return ex;
        }

        /// <summary>
        /// Exclui uma remessa de Cartas de cobrança
        /// </summary>
        /// <param name="Remessa"></param>
        /// <returns></returns>
        public Exception Excluir_Carta_Cobranca(int Remessa) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Excluir_Carta_Cobranca(Remessa);
            return ex;

        }

        /// <summary>
        /// Insere os códigos que não foram emitidos carta de cobrança por falta de cep ou cpf
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Carta_Cobranca_Exclusao(Carta_cobranca_exclusao Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Carta_Cobranca_Exclusao(Reg);
            return ex;
        }

        /// <summary>
        /// Insere os detalhes da carta de cobrança
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Carta_Cobranca_Detalhe(Carta_cobranca_detalhe Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Carta_Cobranca_Detalhe(Reg);
            return ex;
        }

        /// <summary>
        /// Insere na tabela numdocumento - utilizado quando o número do documento é pre definido pela rotina e não pelo sistema.
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Documento_Existente(Numdocumento Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Documento_Existente(Reg);
            return ex;
        }

        /// <summary>
        /// Retorna a lista dos códigos que possuem débito para carta de cobrança
        /// </summary>
        /// <param name="_codigo_inicial"></param>
        /// <param name="_codigo_final"></param>
        /// <param name="_data_vencimento"></param>
        /// <returns></returns>
        public List<int> Lista_Codigo_Carta(int _codigo_inicial, int _codigo_final, DateTime _data_vencimento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Codigo_Carta(_codigo_inicial,_codigo_final,_data_vencimento);
        }

        /// <summary>
        /// Retorna os registros da tabela carta_cobranca
        /// </summary>
        /// <param name="Remessa"></param>
        /// <returns></returns>
        public List<Carta_cobranca> Lista_Carta_Cobranca(int Remessa) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Carta_Cobranca(Remessa);
        }

        /// <summary>
        /// Inserir nova atividade
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Atividade(Atividade Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Atividade(Reg);
            return ex;
        }

        /// <summary>
        /// Alterar atividade
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Alterar_Atividade(Atividade Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Alterar_Atividade(Reg);
            return ex;
        }

        /// <summary>
        /// Retorna os vencimentos das parcelas
        /// </summary>
        /// <param name="_ano"></param>
        /// <param name="_tipo"></param>
        /// <returns></returns>
        public Paramparcela Retorna_Parametro_Parcela(int _ano, int _tipo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Parametro_Parcela(_ano,_tipo);
        }

        /// <summary>
        /// Grava registro na tabela calculo_iss_vs
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Calculo_Iss_VS(Calculo_resumo Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Calculo_Resumo(Reg);
            return ex;
        }

        /// <summary>
        /// retorna o valor do tributo selecionado
        /// </summary>
        /// <param name="Ano"></param>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public decimal Retorna_Valor_Tributo(int Ano, int Codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Valor_Tributo(Ano, Codigo);
        }

        /// <summary>
        /// Lista as parcelas de taxa de licença de uma empresa no ano selecionado
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <param name="nAno"></param>
        /// <returns></returns>
        public List<DebitoStructure> Lista_Parcelas_Taxa(int nCodigo, int nAno) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Parcelas_Taxa(nCodigo,nAno);
        }

        /// <summary>
        /// Lista as parcelas de Iss Fixo de uma empresa no ano selecionado
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <param name="nAno"></param>
        /// <returns></returns>
        public List<DebitoStructure> Lista_Parcelas_Iss_Fixo(int nCodigo, int nAno) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Parcelas_Iss_Fixo(nCodigo,nAno);
        }

        /// <summary>
        /// Lista as parcelas de vigilância sanitária de uma empresa no ano selecionado
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <param name="nAno"></param>
        /// <returns></returns>
        public List<DebitoStructure> Lista_Parcelas_Vigilancia(int nCodigo, int nAno) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Parcelas_Vigilancia(nCodigo, nAno);
        }

        /// <summary>
        /// Lista as parcelas e valor da parcela de um documento
        /// </summary>
        /// <param name="Numero"></param>
        /// <returns></returns>
        public List<Documento_parcela_valor> Lista_Detalhe_Documento(int Numero) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Detalhe_Documento(Numero);
        }

        /// <summary>
        /// Retorna true se o contribuinte estiver no Serasa
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public bool InSerasa(int Codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.InSerasa(Codigo);
        }

        /// <summary>
        /// Retorna os dados de pagamento de uma parcela
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public DebitoPagoStruct Retorna_DebitoPago_Parcela(Debitoparcela Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_DebitoPago_Parcela(Reg);
        }

        /// <summary>
        /// Retorna verdadeiro se existir parcela única não paga no exercício 
        /// </summary>
        /// <param name="Codigo"></param>
        /// <param name="Ano"></param>
        /// <returns></returns>
        public bool Parcela_Unica_IPTU_NaoPago(int Codigo, int Ano) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Parcela_Unica_IPTU_NaoPago(Codigo,Ano);
        }

        /// <summary>
        /// Inserir um documento para registro
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Ficha_Compensacao_Documento(Ficha_compensacao_documento Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Ficha_Compensacao_Documento(Reg);
            return ex;
        }

        /// <summary>
        /// Marcar o documento como registrado
        /// </summary>
        /// <param name="_documento"></param>
        /// <returns></returns>
        public Exception Marcar_Documento_Registrado(int _documento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Marcar_Documento_Registrado(_documento);
            return ex;
        }

        /// <summary>
        /// Lista os débitos de origem de um parcelamento
        /// </summary>
        /// <param name="_ano"></param>
        /// <param name="_numero"></param>
        /// <returns></returns>
        public List<OrigemReparcStruct> Lista_Origem_Parcelamento(int _ano, int _numero) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Origem_Parcelamento(_ano,_numero);
        }

        /// <summary>
        /// Lista os débitos de destino de um parcelamento
        /// </summary>
        /// <param name="_ano"></param>
        /// <param name="_numero"></param>
        /// <returns></returns>
        public List<DestinoreparcStruct> Lista_Destino_Parcelamento(int _ano, int _numero) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Destino_Parcelamento(_ano, _numero);
        }

        /// <summary>
        /// Retorna os dados de um parcelamento
        /// </summary>
        /// <param name="_ano"></param>
        /// <param name="_numero"></param>
        /// <returns></returns>
        public Processo_Parcelamento_Struct Retorna_Dados_Parcelamento(int _ano, int _numero) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Dados_Parcelamento(_ano, _numero);
        }

        /// <summary>
        /// Alterar o status de uma parcela
        /// </summary>
        /// <param name="_codigo"></param>
        /// <param name="_ano"></param>
        /// <param name="_lanc"></param>
        /// <param name="_seq"></param>
        /// <param name="_parc"></param>
        /// <param name="_compl"></param>
        /// <param name="_status"></param>
        /// <returns></returns>
        public Exception Alterar_Status_Lancamento(int _codigo, short _ano, short _lanc, short _seq, byte _parc, byte _compl, byte _status) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Alterar_Status_Lancamento(_codigo,_ano,_lanc,_seq,_parc,_compl,_status);
            return ex;
        }

        /// <summary>
        /// Alterar a data de vencimento de um lançamnto
        /// </summary>
        /// <param name="_codigo"></param>
        /// <param name="_ano"></param>
        /// <param name="_lanc"></param>
        /// <param name="_seq"></param>
        /// <param name="_parc"></param>
        /// <param name="_compl"></param>
        /// <param name="_vencto"></param>
        /// <returns></returns>
        public Exception Alterar_Data_Vencimento(int _codigo, short _ano, short _lanc, short _seq, byte _parc, byte _compl, DateTime _vencto) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Alterar_Data_Vencimento(_codigo, _ano, _lanc, _seq, _parc, _compl, _vencto);
            return ex;
        }

        /// <summary>
        /// Alterar a data base de um lançamento
        /// </summary>
        /// <param name="_codigo"></param>
        /// <param name="_ano"></param>
        /// <param name="_lanc"></param>
        /// <param name="_seq"></param>
        /// <param name="_parc"></param>
        /// <param name="_compl"></param>
        /// <param name="_data_base"></param>
        /// <returns></returns>
        public Exception Alterar_Data_Base(int _codigo, short _ano, short _lanc, short _seq, byte _parc, byte _compl, DateTime _data_base) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Alterar_Data_Base(_codigo, _ano, _lanc, _seq, _parc, _compl, _data_base);
            return ex;
        }

        /// <summary>
        /// Alterar o livro de um lançamento
        /// </summary>
        /// <param name="_codigo"></param>
        /// <param name="_ano"></param>
        /// <param name="_lanc"></param>
        /// <param name="_seq"></param>
        /// <param name="_parc"></param>
        /// <param name="_compl"></param>
        /// <param name="_livro"></param>
        /// <returns></returns>
        public Exception Alterar_Numero_Livro(int _codigo, short _ano, short _lanc, short _seq, byte _parc, byte _compl, int _livro) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Alterar_Numero_Livro(_codigo, _ano, _lanc, _seq, _parc, _compl, _livro);
            return ex;

        }

        /// <summary>
        /// Alterar a certidão de um livro
        /// </summary>
        /// <param name="_codigo"></param>
        /// <param name="_ano"></param>
        /// <param name="_lanc"></param>
        /// <param name="_seq"></param>
        /// <param name="_parc"></param>
        /// <param name="_compl"></param>
        /// <param name="_certidao"></param>
        /// <returns></returns>
        public Exception Alterar_Numero_Certidao(int _codigo, short _ano, short _lanc, short _seq, byte _parc, byte _compl, int _certidao) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Alterar_Numero_Certidao(_codigo, _ano, _lanc, _seq, _parc, _compl, _certidao);
            return ex;
        }

        /// <summary>
        /// Alterar a data de inscrição de um lançamento
        /// </summary>
        /// <param name="_codigo"></param>
        /// <param name="_ano"></param>
        /// <param name="_lanc"></param>
        /// <param name="_seq"></param>
        /// <param name="_parc"></param>
        /// <param name="_compl"></param>
        /// <param name="_data"></param>
        /// <returns></returns>
        public Exception Alterar_Data_Inscricao(int _codigo, short _ano, short _lanc, short _seq, byte _parc, byte _compl, DateTime _data) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Alterar_Data_Inscricao(_codigo, _ano, _lanc, _seq, _parc, _compl, _data);
            return ex;
        }

        /// <summary>
        /// Alterar a data de ajuizamento de um lançamento
        /// </summary>
        /// <param name="_codigo"></param>
        /// <param name="_ano"></param>
        /// <param name="_lanc"></param>
        /// <param name="_seq"></param>
        /// <param name="_parc"></param>
        /// <param name="_compl"></param>
        /// <param name="_data"></param>
        /// <returns></returns>
        public Exception Alterar_Data_Ajuizamento(int _codigo, short _ano, short _lanc, short _seq, byte _parc, byte _compl, DateTime _data) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Alterar_Data_Ajuizamento(_codigo, _ano, _lanc, _seq, _parc, _compl, _data);
            return ex;
        }

        /// <summary>
        /// Alterar a pagina do livro de um lançamento
        /// </summary>
        /// <param name="_codigo"></param>
        /// <param name="_ano"></param>
        /// <param name="_lanc"></param>
        /// <param name="_seq"></param>
        /// <param name="_parc"></param>
        /// <param name="_compl"></param>
        /// <param name="_pagina"></param>
        /// <returns></returns>
        public Exception Alterar_Pagina_Livro(int _codigo, short _ano, short _lanc, short _seq, byte _parc, byte _compl, int _pagina) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Alterar_Pagina_Livro(_codigo, _ano, _lanc, _seq, _parc, _compl, _pagina);
            return ex;
        }

        /// <summary>
        /// Excluir registro da tabela debitocancel
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Excluir_Debito_Cancel(Debitocancel reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Excluir_Debito_Cancel(reg);
            return ex;
        }

        /// <summary>
        /// Incluir um registro na tabela debitocancel
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Insert_Debito_Cancel(Debitocancel reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Debito_Cancel(reg);
            return ex;
        }

        /// <summary>
        /// Retorna o tipo de livro da divida ativa
        /// </summary>
        /// <param name="_lancamento"></param>
        /// <returns></returns>
        public Tipolivro Retorna_Tipo_Livro_Divida_Ativa(int _lancamento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Tipo_Livro_Divida_Ativa(_lancamento);
        }

        /// <summary>
        /// Retorna a próxima certidão disponível de divida ativa de um livro.
        /// </summary>
        /// <param name="_livro"></param>
        /// <returns></returns>
        public int Retorna_Ultima_Certidao_Livro(int _livro) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Ultima_Certidao_Livro(_livro);
        }

        /// <summary>
        /// Inscrever um débito em divida ativa
        /// </summary>
        /// <param name="_codigo"></param>
        /// <param name="_ano"></param>
        /// <param name="_lanc"></param>
        /// <param name="_seq"></param>
        /// <param name="_parc"></param>
        /// <param name="_compl"></param>
        /// <param name="_livro"></param>
        /// <param name="_pagina"></param>
        /// <param name="_certidao"></param>
        /// <param name="_data"></param>
        /// <returns></returns>
        public Exception Inscrever_Divida_Ativa(int _codigo, short _ano, short _lanc, short _seq, byte _parc, byte _compl, int _livro, int _pagina, int _certidao, DateTime _data) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Inscrever_Divida_Ativa(_codigo,_ano,_lanc,_seq,_parc,_compl,_livro,_pagina,_certidao,_data);
            return ex;
        }

        public Exception Insert_Debito_Parcela(Debitoparcela Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Debito_Parcela(Reg);
            return ex;
        }

        public Exception Insert_Debito_Tributo(Debitotributo Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Debito_Tributo(Reg);
            return ex;
        }


    }//end class
}



