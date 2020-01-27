using System;
using System.Collections.Generic;
using GTI_Models.Models;
using GTI_Dal.Classes;
using GTI_Bll.Classes;
using static GTI_Models.modelCore;

namespace GTI_Bll.Classes {
    public class Imovel_bll {
        private string _connection;

        public Imovel_bll(string sConnection) {
            _connection = sConnection;
        }

        /// <summary>
        /// Retorna os dados de um imóvel
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <returns></returns>
        public ImovelStruct Dados_Imovel(int nCodigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Dados_Imovel(nCodigo);
        }

        public List<ProprietarioStruct> Lista_Proprietario(int CodigoImovel, bool Principal = false) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Proprietario(CodigoImovel, Principal);
        }

        public List<LogradouroStruct> Lista_Logradouro(String Filter = "") {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Logradouro(Filter);
        }

        /// <summary>
        /// Verifica se existe o imóvel informado
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <returns></returns>
        public bool Existe_Imovel(int nCodigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Existe_Imovel(nCodigo);
        }

        /// <summary>
        /// Verifica e o imóvelk existe
        /// </summary>
        /// <param name="distrito"></param>
        /// <param name="setor"></param>
        /// <param name="quadra"></param>
        /// <param name="lote"></param>
        /// <param name="unidade"></param>
        /// <param name="subunidade"></param>
        /// <returns></returns>
        public int Existe_Imovel(int distrito, int setor, int quadra, int lote, int unidade, int subunidade) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Existe_Imovel(distrito,setor,quadra,lote,unidade,subunidade);
        }
        
        /// <summary>
        /// Verifica se existe a Face informada
        /// </summary>
        /// <param name="Distrito"></param>
        /// <param name="Setor"></param>
        /// <param name="Quadra"></param>
        /// <param name="Face"></param>
        /// <returns></returns>
        public bool Existe_Face_Quadra(int Distrito, int Setor, int Quadra, int Face) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Existe_Face_Quadra(Distrito,Setor,Quadra,Face);
        }

        public EnderecoStruct Dados_Endereco(int Codigo, TipoEndereco Tipo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Dados_Endereco(Codigo,Tipo);
        }

        public List<Categprop> Lista_Categoria_Propriedade() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Categoria_Propriedade();
        }

        public List<Topografia> Lista_Topografia() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Topografia();
        }

        public List<Situacao> Lista_Situacao() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Situacao();
        }

        public List<Benfeitoria> Lista_Benfeitoria() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Benfeitoria();
        }

        public List<Pedologia> Lista_Pedologia() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Pedologia();
        }

        public List<Usoterreno> Lista_uso_terreno() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Uso_Terreno();
        }

        public List<Testada> Lista_Testada(int Codigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Testada(Codigo);
        }

        public List<AreaStruct> Lista_Area(int Codigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Area(Codigo);
        }

        /// <summary>
        /// Lista do histórico do imóvel
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<HistoricoStruct> Lista_Historico(int Codigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Historico(Codigo);
        }
        
        public List<Usoconstr> Lista_Uso_Construcao() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Uso_Construcao();
        }

        public List<Categconstr> Lista_Categoria_Construcao() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Categoria_Construcao();
        }

        public List<Tipoconstr> Lista_Tipo_Construcao() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Tipo_Construcao();
        }

        ///<summary> Retorna os dados de um condomínio
        ///</summary>
        public CondominioStruct Dados_Condominio(int nCodigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Dados_Condominio(nCodigo);
        }

        ///<summary> Retorna a lista das áreas de um condomínio
        ///</summary>
        public List<AreaStruct> Lista_Area_Condominio(int Codigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Area_Condominio(Codigo);
        }

        /// <summary>
        /// Retorna a inscrição cadastral completa do imóvel
        /// </summary>
        /// <param name="Logradouro"></param>
        /// <param name="Numero"></param>
        /// <returns></returns>
        public ImovelStruct Inscricao_imovel(int Logradouro, short Numero) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Inscricao_imovel(Logradouro,Numero);
        }

        /// <summary>
        /// Lista dos condomínios cadastrados
        /// </summary>
        /// <returns></returns>
        public List<Condominio> Lista_Condominio() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Condominio();
        }

        /// <summary>
        /// Lista das testadas do condomínio
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<Testadacondominio> Lista_Testada_Condominio(int Codigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Testada_Condominio(Codigo);
        }
        
        /// <summary>
        /// Lista das unidades do condomínio
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<Condominiounidade> Lista_Unidade_Condominio(int Codigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Unidade_Condominio(Codigo);
        }

        /// <summary>
        /// Retorna a Lista dos imóveis filtrados
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public List<ImovelStruct> Lista_Imovel(ImovelStruct Reg, ImovelStruct OrderByField) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Imovel(Reg,OrderByField);
        }

        /// <summary>
        /// Retorna os dados de IPTU de um imóvel em um ano
        /// </summary>
        /// <param name="Codigo"></param>
        /// <param name="Ano"></param>
        /// <returns></returns>
        public Laseriptu Dados_IPTU(int Codigo, int Ano) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Dados_IPTU(Codigo, Ano);
        }

        /// <summary>
        /// Retorna os dados IPTU de um imóvel em todos os anos
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<Laseriptu> Dados_IPTU(int Codigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Dados_IPTU(Codigo);
        }

        /// <summary>
        /// Soma das áreas construidas do imóvel
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public decimal Soma_Area(int Codigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Soma_Area(Codigo);
        }

        /// <summary>
        /// Retorna a quantidade de imóveis que um contribuinte possui como proprietário
        /// </summary>
        /// <param name="CodigoImovel"></param>
        /// <returns></returns>
        public int Qtde_Imovel_Cidadao(int CodigoImovel) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Qtde_Imovel_Cidadao(CodigoImovel);
        }

        /// <summary>
        /// Retorna verdadeiro se o imóvel for imune e falso se não for
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public bool Verifica_Imunidade(int Codigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Verifica_Imunidade(Codigo);
        }

        /// <summary>
        /// Retorna a lista de isenções de um imóvel, caso o ano for especificado retorna apenas a isenção do ano.
        /// </summary>
        /// <param name="Codigo"></param>
        /// <param name="Ano"></param>
        /// <returns></returns>
        public List<IsencaoStruct> Lista_Imovel_Isencao(int Codigo, int Ano = 0) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Imovel_Isencao(Codigo,Ano);
        }

        /// <summary>
        /// Inativar o imóvel especificado
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public Exception Inativar_imovel(int Codigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            Exception ex = obj.Inativar_imovel(Codigo);
            return ex;
        }

        /// <summary>
        /// Retorna o código reduzido através da inscrição cadastral ou zero se não existir
        /// </summary>
        /// <param name="distrito"></param>
        /// <param name="setor"></param>
        /// <param name="quadra"></param>
        /// <param name="lote"></param>
        /// <param name="face"></param>
        /// <param name="unidade"></param>
        /// <param name="subunidade"></param>
        /// <returns></returns>
        public int Retorna_Imovel_Inscricao(int distrito, int setor, int quadra, int lote, int face, int unidade, int subunidade) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Retorna_Imovel_Inscricao(distrito,setor,quadra,lote,face,unidade,subunidade);
        }

        /// <summary>
        /// Retorna a lista de faces de quadra
        /// </summary>
        /// <param name="distrito"></param>
        /// <param name="setor"></param>
        /// <param name="quadra"></param>
        /// <param name="face"></param>
        /// <returns></returns>
        public List<FacequadraStruct> Lista_FaceQuadra(int distrito, int setor, int quadra, int face) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_FaceQuadra(distrito, setor, quadra, face);
        }

        /// <summary>
        /// Retorna o próximo código disponivel de imóvel
        /// </summary>
        /// <returns></returns>
        public int Retorna_Codigo_Disponivel() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Retorna_Codigo_Disponivel();
        }

        /// <summary>
        /// Retorna o próximo código disponível de condomínio
        /// </summary>
        /// <returns></returns>
        public int Retorna_Codigo_Condominio_Disponivel() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Retorna_Codigo_Disponivel();
        }

        /// <summary>
        /// Incluir um novo imóvel
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Incluir_Imovel(Cadimob reg) {
            Imovel_Data obj = new Imovel_Data(_connection);
            Exception ex = obj.Incluir_Imovel(reg);
            return ex;
        }

        /// <summary>
        /// Incluir um novo condomínio
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Incluir_Condominio(Condominio reg) {
            Imovel_Data obj = new Imovel_Data(_connection);
            Exception ex = obj.Incluir_Condominio(reg);
            return ex;
        }
        
        /// <summary>
        /// Alterar o imóvel selecionado
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Alterar_Imovel(Cadimob reg) {
            Imovel_Data obj = new Imovel_Data(_connection);
            Exception ex = obj.Alterar_Imovel(reg);
            return ex;
        }

        /// <summary>
        /// Alterar o condomínio selecionado
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Alterar_Condominio(Condominio reg) {
            Imovel_Data obj = new Imovel_Data(_connection);
            Exception ex = obj.Alterar_Condominio(reg);
            return ex;
        }

        /// <summary>
        /// Grava os proprietários do imóvel
        /// </summary>
        /// <param name="Lista"></param>
        /// <returns></returns>
        public Exception Incluir_Proprietario(List<Proprietario> Lista) {
            Imovel_Data obj = new Imovel_Data(_connection);
            Exception ex = obj.Incluir_Proprietario(Lista);
            return ex;
        }

        /// <summary>
        /// Grava as testadas do imóvel
        /// </summary>
        /// <param name="testadas"></param>
        /// <returns></returns>
        public Exception Incluir_Testada(List<Testada> testadas) {
            Imovel_Data obj = new Imovel_Data(_connection);
            Exception ex = obj.Incluir_Testada(testadas);
            return ex;
        }

        /// <summary>
        /// Grava as testadas do condomínio
        /// </summary>
        /// <param name="testadas"></param>
        /// <returns></returns>
        public Exception Incluir_Testada_Condominio(List<Testadacondominio> testadas) {
            Imovel_Data obj = new Imovel_Data(_connection);
            Exception ex = obj.Incluir_Testada_Condominio(testadas);
            return ex;
        }

        /// <summary>
        /// Grava os históricos do imóvel
        /// </summary>
        /// <param name="historicos"></param>
        /// <returns></returns>
        public Exception Incluir_Historico(List<Historico> historicos) {
            Imovel_Data obj = new Imovel_Data(_connection);
            Exception ex = obj.Incluir_Historico(historicos);
            return ex;
        }

        /// <summary>
        /// Grava as áreas do imóvel
        /// </summary>
        /// <param name="areas"></param>
        /// <returns></returns>
        public Exception Incluir_Area(List<Areas> areas) {
            Imovel_Data obj = new Imovel_Data(_connection);
            Exception ex = obj.Incluir_Area(areas);
            return ex;
        }

        /// <summary>
        /// Grava as áreas do condomínio
        /// </summary>
        /// <param name="areas"></param>
        /// <returns></returns>
        public Exception Incluir_Area_Condominio(List<Condominioarea> areas) {
            Imovel_Data obj = new Imovel_Data(_connection);
            Exception ex = obj.Incluir_Area_Condominio(areas);
            return ex;
        }

        /// <summary>
        /// Grava as unidades do condomínio
        /// </summary>
        /// <param name="unidades"></param>
        /// <returns></returns>
        public Exception Incluir_Unidade_Condominio(List<Condominiounidade> unidades) {
            Imovel_Data obj = new Imovel_Data(_connection);
            Exception ex = obj.Incluir_Unidade_Condominio(unidades);
            return ex;
        }

        /// <summary>
        /// Lista os códigos dos imóveis ativos
        /// </summary>
        /// <returns></returns>
        public List<int> Lista_Imovel_Ativo() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Imovel_Ativo();
        }

        /// <summary>
        /// Retorna os códigos dos imóveis que receberam o comunicado de isenção
        /// </summary>
        /// <returns></returns>
        public List<int> Lista_Comunicado_Isencao() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Comunicado_Isencao();
        }

        /// <summary>
        /// Grava na tabela Comunicado_Isencao
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Comunicado_Isencao(Comunicado_isencao Reg) {
            Imovel_Data obj = new Imovel_Data(_connection);
            Exception ex = obj.Insert_Comunicado_Isencao(Reg);
            return ex;
        }

        /// <summary>
        /// Retorna a lista das fotos de um imóvel
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<Foto_imovel> Lista_Foto_Imovel(int Codigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Foto_Imovel(Codigo);
        }

    }//end class
}
