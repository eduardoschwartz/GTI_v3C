using GTI_Dal.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;

namespace GTI_Bll.Classes {
    public class Empresa_bll {
        private string _connection;
        public Empresa_bll(string sConnection) {
            _connection = sConnection;
        }

        /// <summary>
        /// Verifica se a empresa esta cadastrada
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <returns></returns>
        public bool Existe_Empresa(int nCodigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Existe_Empresa(nCodigo);
        }

        /// <summary>
        /// Retorna a qtde de parcelas de Taxa de licença não pagas no ano.
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public int Qtde_Parcelas_TLL_Vencidas(int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Qtde_Parcelas_TLL_Vencidas(Codigo);
        }

        /// <summary>
        /// Retorna o cadastro da empresa
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public EmpresaStruct Retorna_Empresa(int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Retorna_Empresa(Codigo);
        }

        /// <summary>
        /// Verifica se a empresa esta suspensa
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <returns></returns>
        public bool EmpresaSuspensa(int nCodigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Empresa_Suspensa(nCodigo);
        }

        /// <summary>
        /// Verifica se tem alguma empresa com o CNPJ informado
        /// </summary>
        /// <param name="sCNPJ"></param>
        /// <returns></returns>
        public int ExisteEmpresaCnpj(string sCNPJ) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Existe_EmpresaCnpj(sCNPJ);
        }

        /// <summary>
        /// Verifica se tem alguma empresa com o CPF informado
        /// </summary>
        /// <param name="sCPF"></param>
        /// <returns></returns>
        public int ExisteEmpresaCpf(string sCPF) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Existe_EmpresaCpf(sCPF);
        }

        /// <summary>
        /// Verifica se a empresa possui vigilância sanitária
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <returns></returns>
        public bool Empresa_tem_VS(int nCodigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Empresa_tem_VS(nCodigo);
        }

        /// <summary>
        /// Verifica se a empresa trem taxa de licença
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <returns></returns>
        public bool Empresa_tem_TL(int nCodigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Empresa_tem_TL(nCodigo);
        }

        /// <summary>
        /// Verifica se a empresa pode tirar alvará na Internet
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <returns></returns>
        public bool Empresa_tem_Alvara(int nCodigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Empresa_tem_Alvara(nCodigo);

        }

        /// <summary>
        /// Retorna o regime da empresa
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <returns></returns>
        public string RegimeEmpresa(int nCodigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Regime_Empresa(nCodigo);
        }

        /// <summary>
        /// Verifica se a empresa esta no Mei
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <returns></returns>
        public bool Empresa_Mei(int nCodigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Empresa_Mei(nCodigo);
        }

        /// <summary>
        /// Lista dos sócios de uma empresa
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <returns></returns>
        public List<CidadaoStruct> ListaSocio(int nCodigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Socio(nCodigo);
        }

        /// <summary>
        /// Lista dos horários de funcionamento
        /// </summary>
        /// <returns></returns>
        public List<Horariofunc> Lista_Horario() {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Horario();
        }

        /// <summary>
        /// Lista as placas dos veículos de uma empresa
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<string> Lista_Placas(int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Placas(Codigo);
        }

        /// <summary>
        /// Retorna a lista de protocolos do VRE
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<sil> Lista_Sil(int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Sil(Codigo);
        }

        /// <summary>
        /// Retorna True se a empresa for do simpels e false se nãop for.
        /// </summary>
        /// <param name="Codigo"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public bool Empresa_Simples(int Codigo, DateTime Data) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Empresa_Simples(Codigo,Data);
        }

        /// <summary>
        /// Retorna o endereço de entrega da empresa
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public mobiliarioendentrega Empresa_Endereco_entrega(int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Empresa_Endereco_entrega(Codigo);
        }

        /// <summary>
        /// Lista dos proprietários da empresa
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<MobiliarioproprietarioStruct> Lista_Empresa_Proprietario(int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Empresa_Proprietario(Codigo);
        }

        /// <summary>
        /// Lista dos escritórios de contabilidade
        /// </summary>
        /// <returns></returns>
        public List<Escritoriocontabil> Lista_Escritorio_Contabil() {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Escritorio_Contabil();
        }

        /// <summary>
        /// Retorna os dados do escritório contabil
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public EscritoriocontabilStruct Dados_Escritorio_Contabil(int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Dados_Escritorio_Contabil(Codigo);
        }

        /// <summary>
        /// Validação para gravação do escritório de contabilidade
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Valida_Escritorio_Contabil(Escritoriocontabil reg) {
            Exception AppEx;
            if (String.IsNullOrWhiteSpace(reg.Nomeesc)) {
                AppEx = new Exception("Digite o nome do escritório");
                return AppEx;
            }

            if (String.IsNullOrWhiteSpace(reg.Cpf) && String.IsNullOrEmpty(reg.Cnpj)) {
                AppEx = new Exception("Digite o CPF ou CNPJ.");
                return AppEx;
            }

            if (!string.IsNullOrWhiteSpace(reg.Cpf) && !bllCore.ValidaCpf(reg.Cpf)) {
                AppEx = new Exception("CPF inválido.");
                return AppEx;
            }

            if (!string.IsNullOrWhiteSpace(reg.Cnpj) && !bllCore.ValidaCNPJ(reg.Cnpj)) {
                AppEx = new Exception("CNPJ inválido.");
                return AppEx;
            }

            if (String.IsNullOrWhiteSpace(reg.Nomelogradouro) && reg.Codlogradouro==0) {
                AppEx = new Exception("Digite o endereço do escritório.");
                return AppEx;
            }

            if (reg.Codcidade==0) {
                AppEx = new Exception("Selecione a cidade.");
                return AppEx;
            }

            if (String.IsNullOrWhiteSpace( reg.UF) ) {
                AppEx = new Exception("Selecione a UF.");
                return AppEx;
            }

            return null;
        }

        /// <summary>
        /// Incluir um novo escritório contábil
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Incluir_escritorio(Escritoriocontabil reg) {
            Exception AppEx = Valida_Escritorio_Contabil(reg);
            if (AppEx != null) return AppEx;
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = obj.Incluir_escritorio(reg);
            return ex;
        }

        /// <summary>
        /// Alterar o cadastro de um escritório contábil
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Alterar_escritorio(Escritoriocontabil reg) {
            Exception AppEx = Valida_Escritorio_Contabil(reg);
            if (AppEx != null) return AppEx;
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = obj.Alterar_escritorio(reg);
            return ex;
        }

        /// <summary>
        /// Último código de escritório cadastrado
        /// </summary>
        /// <returns></returns>
        public int Retorna_Ultimo_Codigo_Escritorio() {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Retorna_Ultimo_Codigo_Escritorio();
        }

        /// <summary>
        /// Verifica se alguma empresa esta usando o código de escritório
        /// </summary>
        /// <param name="id_cidadao"></param>
        /// <returns></returns>
        private Exception Escritorio_em_uso(int id_escritorio) {
            Exception AppEx = null;
            Empresa_Data obj = new Empresa_Data(_connection);
            bool bUso = obj.Empresa_Escritorio(id_escritorio);
            if (bUso)
                AppEx = new Exception("Exclusão não permitida. Escritório em uso nas empresas.");
            return AppEx;
        }

        /// <summary>
        /// Verifica se o escritório esta sendo utilizado em alguma empresa
        /// </summary>
        /// <param name="id_escritorio"></param>
        /// <returns></returns>
        public bool Empresa_Escritorio(int id_escritorio) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Empresa_Escritorio(id_escritorio);
        }

        /// <summary>
        /// Excluir um escritório cadastrado
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public Exception Excluir_Escritorio(int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = Escritorio_em_uso(Codigo);
            if (ex == null)
                ex = obj.Excluir_Escritorio(Codigo);
            return ex;

        }

        /// <summary>
        /// Incluir os dados da empresa utilizados na impressão dos detalhes da empresa na Web
        /// </summary>
        /// <param name="Lista"></param>
        /// <returns></returns>
        public Exception Incluir_DEmp(List<DEmpresa> Lista) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = obj.Incluir_DEmp(Lista);
            return ex;
        }

        /// <summary>
        /// Lista os dados de uma empresa na web
        /// </summary>
        /// <param name="nSid"></param>
        /// <returns></returns>
        public List<DEmpresa> ListaDEmpresa(int nSid) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.ListaDEmpresa(nSid);
        }

        /// <summary>
        /// Excluir os dados da tabela DEmpresa utilizada na consulta web de empresas
        /// </summary>
        /// <param name="nSid"></param>
        /// <returns></returns>
        public Exception Delete_DEmpresa(int nSid) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = obj.Delete_DEmpresa(nSid);
            return ex;
        }

        /// <summary>
        /// Retorna a Lista de Cnaes de uma empresa
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <returns></returns>
        public List<CnaeStruct> ListaCnae() {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Cnae();
        }

        //public List<CnaeStruct> Lista_Cnae_Empresa(int nCodigo) {
        //    Empresa_Data obj = new Empresa_Data(_connection);
        //    return obj.Lista_Cnae_Empresa(nCodigo);
        //}

        /// <summary>
        /// Retorna o número Sil de uma empresa
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public SilStructure CarregaSil(int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.CarregaSil(Codigo);
        }

        /// <summary>
        /// Verifica se a empresa já existe na tabela vre_empresa
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <returns></returns>
        public bool Existe_Empresa_Vre(int nCodigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Existe_Empresa_Vre(nCodigo);
        }

        public bool Existe_redeSim_Viabilidade(string Protocolo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Existe_redeSim_Viabilidade(Protocolo);
        }


        /// <summary>
        /// Insere na tabela vre_empresa
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Insert_Empresa_Vre(Vre_empresa reg) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = obj.Incluir_Empresa_Vre(reg);
            return ex;
        }

        public Exception Incluir_redeSim_Viabilidade(Redesim_viabilidade reg) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = obj.Incluir_redeSim_Viabilidade(reg);
            return ex;
        }

        /// <summary>
        /// Insere na tabela vre_atividade
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Insert_Atividade_Vre(Vre_atividade reg) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = obj.Incluir_Atividade_Vre(reg);
            return ex;
        }

        /// <summary>
        /// Insere na tabela vre_socio
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Insert_Socio_Vre(Vre_socio reg) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = obj.Incluir_Socio_Vre(reg);
            return ex;
        }

        /// <summary>
        /// Insere na tabela vre_licenciamento
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Insert_Licenciamento_Vre(Vre_licenciamento reg) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = obj.Incluir_Licenciamento_Vre(reg);
            return ex;
        }

        /// <summary>
        /// Retorna as inscrições cadastrais da empresa através do nº de CPF
        /// </summary>
        /// <param name="CPF"></param>
        /// <returns></returns>
        public List<int> Retorna_Codigo_por_CPF(string CPF) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Retorna_Codigo_por_CPF(CPF);
        }
        
        /// <summary>
        /// Retrorna os dados do alvara gravado para validação
        /// </summary>
        /// <param name="Controle"></param>
        /// <returns></returns>
        public Alvara_funcionamento Alvara_Funcionamento_gravado(string Controle) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Alvara_Funcionamento_gravado(Controle);
        }

        public Exception Incluir_Empresa_Historico(List<MobiliarioHistoricoStruct> historicos) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = obj.Incluir_Empresa_Historico(historicos);
            return ex;
        }
        
        /// <summary>
        /// Retorna as inscrições cadastrais da empresa através do nº de CNPJ
        /// </summary>
        /// <param name="CNPJ"></param>
        /// <returns></returns>
        public List<int> Retorna_Codigo_por_CNPJ(string CNPJ) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Retorna_Codigo_por_CNPJ(CNPJ);
        }

        /// <summary>
        /// Retorna lista de atividades das empresas
        /// </summary>
        /// <returns></returns>
        public List<Atividade> Lista_Atividade() {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Atividade();
        }

        /// <summary>
        /// Verifica se a atividade pode ser excluida ou se esta sendo utilizada por alguma empresa
        /// </summary>
        /// <param name="id_atividade"></param>
        /// <returns></returns>
        private Exception Atividade_em_uso(int id_atividade) {
            Exception AppEx = null;
            Empresa_Data obj = new Empresa_Data(_connection);
            bool bAtividade = obj.Existe_Atividade_Empresa(id_atividade);
            if (bAtividade)
                AppEx = new Exception("Exclusão não permitida. Atividade em uso.");
            return AppEx;
        }

        /// <summary>
        /// Excluir atividade
        /// </summary>
        /// <param name="id_atividade"></param>
        /// <returns></returns>
        public Exception Excluir_Atividade(int id_atividade) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = Atividade_em_uso(id_atividade);
            if (ex == null)
                ex = obj.Excluir_Atividade(id_atividade);
            return ex;
        }

        /// <summary>
        /// retorna a descrição da atividade principal
        /// </summary>
        /// <param name="id_atividade"></param>
        /// <returns></returns>
        public string Retorna_Nome_Atividade(int id_atividade) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Retorna_Nome_Atividade(id_atividade);
        }
        
        /// <summary>
        /// Separa o Cnae em suas partes
        /// </summary>
        /// <param name="_cnae"></param>
        /// <returns></returns>
        public CnaeStruct Separa_Cnae(string _cnae) {
            CnaeStruct _reg = new CnaeStruct();
            _reg.CNAE = _cnae;
            _reg.Divisao = Convert.ToInt32(_cnae.Substring(0,2));
            _reg.Grupo = Convert.ToInt32(_cnae.Substring(2, 1));
            _reg.Classe = Convert.ToInt32(bllCore.ExtractNumber( _cnae.Substring(3, 3)));
            _reg.Subclasse = Convert.ToInt32(_cnae.Substring(7, 2));
            return _reg;
        }

        /// <summary>
        /// Lista todos os Cnaes cadastrados
        /// </summary>
        /// <returns></returns>
        public List<CnaeStruct> Lista_Cnae() {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Cnae();
        }

        /// <summary>
        /// Retorna os Cnaes de uma empresa
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<CnaeStruct> Lista_Cnae_Empresa(int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Cnae_Empresa(Codigo);
        }

        /// <summary>
        /// retorna os Cnaes de VS de uma empresa
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<CnaeStruct> Lista_Cnae_Empresa_VS(int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Cnae_Empresa_VS(Codigo);
        }

        /// <summary>
        /// Dados da certidão de inscrição
        /// </summary>
        /// <param name="Ano"></param>
        /// <param name="Numero"></param>
        /// <returns></returns>
        public Certidao_inscricao Certidao_inscricao_gravada(int Ano, int Numero) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Certidao_inscricao_gravada(Ano,Numero);
        }

        /// <summary>
        /// Lista das empresas que não estão encerradas e nem suspensas
        /// </summary>
        /// <returns></returns>
        public List<int> Lista_Empresas_Ativas() {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Empresas_Ativas();
        }

        /// <summary>
        /// Lista das empresas que possuem vigilancia sanitaria
        /// </summary>
        /// <returns></returns>
        public List<MobiliariovsStruct> Lista_Empresas_Vigilancia_Sanitaria() {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Empresas_Vigilancia_Sanitaria();
        }

        /// <summary>
        /// Lista das empresas que possuem Taxa de Licença
        /// </summary>
        /// <returns></returns>
        public List<EmpresaStruct> Lista_Empresas_Taxa_Licenca() {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Empresas_Taxa_Licenca();
        }

        /// <summary>
        /// Lista das empresas que possuem ISS Fixo
        /// </summary>
        /// <returns></returns>
        public List<Mobiliarioatividadeiss> Lista_Empresas_ISS_Fixo() {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Empresas_ISS_Fixo();
        }

        /// <summary>
        /// Lista dos critérios de um CNAE
        /// </summary>
        /// <returns></returns>
        public List<CnaecriterioStruct> Lista_Cnae_Criterio(string Cnae) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Cnae_Criterio(Cnae);
        }

        /// <summary>
        /// Retorna o valor da aliquota de taxa de licença de uma empresa
        /// </summary>
        /// <param name="_codigo"></param>
        /// <returns></returns>
        public decimal Aliquota_Taxa_Licenca(int _codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Aliquota_Taxa_Licenca(_codigo);
        }

        /// <summary>
        /// Lista atividade de ISS de uma empresa
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <returns></returns>
        public List<MobiliarioAtividadeISSStruct> Lista_AtividadeISS_Empresa(int nCodigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_AtividadeISS_Empresa(nCodigo);
        }

        /// <summary>
        /// Lista do histórico da empresa
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<MobiliarioHistoricoStruct> Lista_Empresa_Historico(int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Empresa_Historico(Codigo);
        }

        /// <summary>
        /// Retorna true se a atividade da empresa permite alvará automático ou false ne não permitir.
        /// </summary>
        /// <param name="Codigo_Atividade"></param>
        /// <returns></returns>
        public bool Empresa_Alvara_Automatico(int Codigo_Atividade) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Empresa_Alvara_Automatico(Codigo_Atividade);
        }

        /// <summary>
        /// Incluir uma nova empresa
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Incluir_Empresa(Mobiliario reg) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = obj.Incluir_Empresa(reg);
            return ex;
        }

        /// <summary>
        /// Retorna o próximo código disponível
        /// </summary>
        /// <returns></returns>
        public int Retorna_Codigo_Disponivel() {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Retorna_Codigo_Disponivel();
        }

        /// <summary>
        /// Gravar a lista de placas de uma empresa
        /// </summary>
        /// <param name="Lista"></param>
        /// <returns></returns>
        public Exception Incluir_Empresa_Placa(List<mobiliarioplaca> Lista,int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = obj.Incluir_Empresa_Placa(Lista,Codigo);
            return ex;
        }

        /// <summary>
        /// Gravar a lista de proprietários de uma empresa
        /// </summary>
        /// <param name="Lista"></param>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public Exception Incluir_Empresa_Proprietario(List<Mobiliarioproprietario> Lista, int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = obj.Incluir_Empresa_Proprietario(Lista, Codigo);
            return ex;
        }

        /// <summary>
        /// Gravar a lista de atividades de ISS de uma empresa
        /// </summary>
        /// <param name="Lista"></param>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public Exception Incluir_Empresa_AtividadeISS(List<Mobiliarioatividadeiss> Lista, int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = obj.Incluir_Empresa_AtividadeISS(Lista, Codigo);
            return ex;
        }

        /// <summary>
        /// Gravar a lista de atividades VS de uma empresa
        /// </summary>
        /// <param name="Lista"></param>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public Exception Incluir_Empresa_AtividadeVS(List<Mobiliariovs> Lista, int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = obj.Incluir_Empresa_AtividadeVS(Lista, Codigo);
            return ex;
        }

        /// <summary>
        /// Lista das atividades de ISS cadastradas
        /// </summary>
        /// <returns></returns>
        public List<AtividadeIssStruct> Lista_AtividadeISS() {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_AtividadeISS();
        }

        /// <summary>
        /// Alterar os dados de uma empresa
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Alterar_Empresa(Mobiliario reg) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = obj.Alterar_Empresa(reg);
            return ex;
        }

        /// <summary>
        /// Incluir os Cnaes de uma empresa
        /// </summary>
        /// <param name="Lista"></param>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public Exception Incluir_Empresa_CNAE(List<CnaeStruct> Lista, int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = obj.Incluir_Empresa_CNAE(Lista,Codigo);
            return ex;
        }

        /// <summary>
        /// Busca o próximo nº de alvara de funcionamento
        /// </summary>
        /// <param name="Ano"></param>
        /// <returns></returns>
        public int Retorna_Alvara_Disponivel(int Ano) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Retorna_Alvara_Disponivel(Ano);
        }

        /// <summary>
        /// Verifica se a atividade permite alvará automático
        /// </summary>
        /// <param name="Codigo_Atividade"></param>
        /// <returns></returns>
        public bool Atividade_tem_Alvara(int Codigo_Atividade) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Atividade_tem_Alvara(Codigo_Atividade);
        }

        /// <summary>
        /// Retorna o horário de funcionamento de uma atividade
        /// </summary>
        /// <param name="Codigo_Atividade"></param>
        /// <returns></returns>
        public Horario_funcionamento Retorna_Horario_Funcionamento(int Codigo_Atividade) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Retorna_Horario_Funcionamento(Codigo_Atividade);
        }

        /// <summary>
        /// Retorna a lista filtrada de empresas.
        /// </summary>
        /// <param name="Filter"></param>
        /// <returns></returns>
        public List<EmpresaStruct> Lista_Empresa(EmpresaStruct Filter) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Empresa(Filter);
        }

        /// <summary>
        /// Retorna sim se a empresa possuir lançamento de taxa de licença no ano especificado.
        /// </summary>
        /// <param name="Codigo"></param>
        /// <param name="Ano"></param>
        /// <returns></returns>
        public bool Existe_Debito_TaxaLicenca(int Codigo, int Ano) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Existe_Debito_TaxaLicenca(Codigo,Ano);
        }

        /// <summary>
        /// Lista tabela CNAE criterio descricao
        /// </summary>
        /// <returns></returns>
        public List<Cnaecriteriodesc> Lista_Cnae_Criterio() {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Cnae_Criterio();
        }

        /// <summary>
        /// Incluir um critério de um Cnae
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Incluir_Cnae_Criterio(Cnae_criterio reg) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = obj.Incluir_Cnae_Criterio(reg);
            return ex;
        }

        /// <summary>
        /// Remove um critério de um Cnae
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public Exception Excluir_Cnae_Criterio(string _cnae, int _criterio) {
            Empresa_Data obj = new Empresa_Data(_connection);
            Exception ex = Cnae_criterio_em_uso(_cnae,_criterio);
            if (ex == null)
                ex = obj.Excluir_Cnae_Criterio(_cnae, _criterio);
            return ex;
        }

        /// <summary>
        /// Verifica se o critério de um Cnae esta sendo utilizado por alguma empresa
        /// </summary>
        /// <param name="_cnae"></param>
        /// <param name="_criterio"></param>
        /// <returns></returns>
        public bool Existe_Cnae_Criterio_Empresa(string _cnae, int _criterio) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Existe_Cnae_Criterio_Empresa(_cnae,_criterio);
        }

        /// <summary>
        /// Verifica se o critério Cnae pode ser excluido ou se esta sendo utilizado por alguma empresa
        /// </summary>
        /// <param name="_cnae"></param>
        /// <param name="_criterio"></param>
        /// <returns></returns>
        private Exception Cnae_criterio_em_uso(string _cnae, int _criterio) {
            Exception AppEx = null;
            Empresa_Data obj = new Empresa_Data(_connection);

            bool bCriterio = obj.Existe_Cnae_Criterio_Empresa(_cnae,_criterio);
            if (bCriterio  )
                AppEx = new Exception("Exclusão não permitida. Critério em uso.");
            return AppEx;
        }
    }
}

