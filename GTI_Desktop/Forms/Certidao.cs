using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static GTI_Models.modelCore;

namespace GTI_Desktop.Forms {
    public partial class Certidao : Form {
        private string _connection = gtiCore.Connection_Name();
        private string sNao = "", sTipoCertidao = "", sTributo = "", sAtividade = "", sSufixo = "", sCPF = "", sCNPJ = "";
        private short nRet = 0;

        TipoCertidao _tipo_certidao;
        TipoCadastro _tipo_cadastro;
        DateTime? _data_processo;


        public Certidao() {
            InitializeComponent();
            TBar.Renderer = new MySR();
            TipoList.SelectedIndex = 0;
        }

        private void ClearFields() {
            Nome.Text = "";
            Endereco.Text = "";
            Bairro.Text = "";
            Cidade.Text = "";
            Cep.Text = "";
            Quadra.Text = "";
            Lote.Text = "";
            Atividade.Text = "";
            Inscricao.Text = "";
            Doc.Text = "";
        }
        
        private void Dados_Impressao(int Codigo) {
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            Contribuinte_Header_Struct header = sistema_Class.Contribuinte_Header(Codigo);
            if (header == null)
                MessageBox.Show("Código não cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                Nome.Text = header.Nome;
                Endereco.Text = header.Endereco + ", " + header.Numero.ToString();
                Bairro.Text = header.Nome_bairro;
                Cidade.Text = header.Nome_cidade + "/" + header.Nome_uf;
                Cep.Text = header.Cep;
                Inscricao.Text = header.Inscricao;
                if (header.Cpf_cnpj != "") {
                    if (gtiCore.ExtractNumber( header.Cpf_cnpj).Length == 11)
                        Doc.Text = Convert.ToInt64(gtiCore.ExtractNumber(header.Cpf_cnpj)).ToString(@"000\.000\.000\-00");
                    else
                        Doc.Text = Convert.ToInt64(gtiCore.ExtractNumber(header.Cpf_cnpj)).ToString(@"00\.000\.000\/0000\-00");
                }
                Quadra.Text = header.Quadra_original;
                Lote.Text = header.Lote_original;
                if (Codigo >= 100000 && Codigo < 500000) {
                    Empresa_bll empresa_Class = new Empresa_bll(_connection);
                    EmpresaStruct dados = empresa_Class.Retorna_Empresa(Codigo);
                    Atividade.Text = dados.Atividade_extenso;
                }
            }
        }

        private void Codigo_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void Processo_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != (char)Keys.Return && e.KeyChar != (char)Keys.Tab) {
                const char Delete = (char)8;
                const char Minus = (char)45;
                const char Barra = (char)47;
                if (e.KeyChar == Minus && Processo.Text.Contains("-"))
                    e.Handled = true;
                else {
                    if (e.KeyChar == Barra && Processo.Text.Contains("/"))
                        e.Handled = true;
                    else
                        e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete && e.KeyChar != Barra && e.KeyChar != Minus;
                }
            }
        }

        private void TipoList_SelectedIndexChanged(object sender, EventArgs e) {
            ClearFields();
        }

        private void Codigo_TextChanged(object sender, EventArgs e) {
            if (Codigo.Text != "")
                ClearFields();
        }

        private void Processo_TextChanged(object sender, EventArgs e) {
            if (Processo.Text != "")
                ClearFields();
        }

        private void Tipo_Certidao(int Indice,int codigo) {
            if (Indice == 0)
                _tipo_certidao = TipoCertidao.Debito;
            else {
                if (Indice == 1)
                    _tipo_certidao = TipoCertidao.Endereco;
                else {
                    if (Indice == 2)
                        _tipo_certidao = TipoCertidao.Isencao;
                    else
                        _tipo_certidao = TipoCertidao.ValorVenal;
                }
            }

            return;
        }

        private void VerificarButton_Click(object sender, EventArgs e) {
            int _codigo;
            Processo_bll processo_Class = new Processo_bll(_connection);
            Sistema_bll sistema_Class = new Sistema_bll(_connection);

            ClearFields();
            if (Codigo.Text.Trim() == "")
                MessageBox.Show("Código não informado.","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else {
                if (Processo.Text.Trim() == "")
                    MessageBox.Show("Processo não informado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    Exception ex = processo_Class.ValidaProcesso(Processo.Text);
                    if(ex!=null)
                        MessageBox.Show("Processo não cadastrado ou inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        _codigo = Convert.ToInt32(Codigo.Text);
                        _tipo_cadastro = sistema_Class.Tipo_Cadastro(_codigo);
                        int _ano = processo_Class.ExtractAnoProcesso(Processo.Text);
                        int _numero = processo_Class.ExtractNumeroProcessoNoDV(Processo.Text);
                        _data_processo = processo_Class.Data_Processo(_ano, _numero);

                        Tipo_Certidao(TipoList.SelectedIndex,_codigo);
                        if((_tipo_certidao==TipoCertidao.Endereco||_tipo_certidao==TipoCertidao.Isencao||_tipo_certidao==TipoCertidao.ValorVenal) && _tipo_cadastro!=TipoCadastro.Imovel) 
                            MessageBox.Show("Este tipo de certidão só pode ser emitida para imóveis.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else {
                            if(_tipo_certidao==TipoCertidao.Debito && _tipo_cadastro==TipoCadastro.Cidadao)
                                MessageBox.Show("Este tipo de certidão não pode ser emitida para cidadão.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else {

                                gtiCore.Ocupado(this);
                                Dados_Impressao(_codigo);
                                gtiCore.Liberado(this);
                            }
                        }
                    }
                }
            }
        }

        private void ImprimirButton_Click(object sender, EventArgs e) {
            if (Nome.Text == "") {
                MessageBox.Show("Carregue os dados de um contribuinte para poder imprimir a certidão.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            int _userId = Properties.Settings.Default.UserId;
            int _ano_certidao = DateTime.Now.Year, _numero_certidao = 0, _codigo = Convert.ToInt32(Codigo.Text), _ano_isencao = DateTime.Now.Year;
            decimal _percisencao = 0, SomaArea = 0;
            DateTime? _data_processo_isencao = null;
            Report_Data _dados = null;
            string _nomeReport = "", _controle = "", _numero_processo = "";

            if (_tipo_certidao == TipoCertidao.Endereco) {
                _nomeReport = "CertidaoEndereco";
                _numero_certidao = tributario_Class.Retorna_Codigo_Certidao(modelCore.TipoCertidao.Endereco);
                _controle = _numero_certidao.ToString("00000") + _ano_certidao.ToString("0000") + "/" + _codigo.ToString() + "-EA";
                Certidao_endereco cert = new Certidao_endereco();
                cert.Codigo = Convert.ToInt32(_codigo);
                cert.Ano = _ano_certidao;
                cert.Numero = _numero_certidao;
                cert.Data = DateTime.Now;
                cert.Inscricao = Inscricao.Text;
                cert.Nomecidadao = Nome.Text;
                cert.Logradouro = Endereco.Text;
                cert.descbairro = Bairro.Text;
                cert.Li_quadras = Quadra.Text;
                cert.Li_lotes = Lote.Text;
                Exception ex = tributario_Class.Insert_Certidao_Endereco(cert);
                if (ex != null) {
                    throw ex;
                }
            } else {
                if (_tipo_certidao == TipoCertidao.Isencao) {
                    Imovel_bll imovel_Class = new Imovel_bll(_connection);
                    bool bImune = imovel_Class.Verifica_Imunidade(_codigo);
                    _numero_certidao = tributario_Class.Retorna_Codigo_Certidao(modelCore.TipoCertidao.Isencao);
                    _controle = _numero_certidao.ToString("00000") + _ano_certidao.ToString("0000") + "/" + _codigo.ToString() + "-CI";

                    if (bImune) {
                        _percisencao = 100;
                        _nomeReport = "CertidaoImunidade";
                    } else {
                        bool bIsentoProcesso = false;
                        List<IsencaoStruct> ListaIsencao = null;
                        ListaIsencao = imovel_Class.Lista_Imovel_Isencao(_codigo, DateTime.Now.Year);
                        if (ListaIsencao.Count > 0)
                            bIsentoProcesso = true;
                        if (bIsentoProcesso) {
                            _nomeReport = "CertidaoIsencaoProcesso";
                            _percisencao = (decimal)ListaIsencao[0].Percisencao;
                            _numero_processo = ListaIsencao[0].Numprocesso;
                            _data_processo_isencao = Convert.ToDateTime(ListaIsencao[0].dataprocesso);
                        } else {
                            SomaArea = imovel_Class.Soma_Area(_codigo);
                            if (SomaArea < 65) {
                                //Se tiver área < 65m² mas tiver mais de 1 imóvel, perde a isenção.
                                int nQtdeImovel = imovel_Class.Qtde_Imovel_Cidadao(_codigo);
                                if (nQtdeImovel > 1) {
                                    MessageBox.Show("Este imóvel não esta isento da cobrança de IPTU no ano atual.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                _nomeReport = "CertidaoIsencao65";
                            }
                        }
                    }

                    Certidao_isencao cert = new Certidao_isencao();
                    cert.Codigo = _codigo;
                    cert.Ano = _ano_certidao;
                    cert.Numero = _numero_certidao;
                    cert.Data = DateTime.Now;
                    cert.Inscricao = Inscricao.Text;
                    cert.Nomecidadao = Nome.Text;
                    cert.Logradouro = Endereco.Text;
                    cert.Descbairro = Bairro.Text;
                    cert.Li_quadras = Quadra.Text;
                    cert.Li_lotes = Lote.Text;
                    cert.Area = SomaArea;
                    cert.Percisencao = _percisencao;
                    cert.Numprocesso = _numero_processo;
                    cert.Dataprocesso = _data_processo_isencao;
                    Exception ex = tributario_Class.Insert_Certidao_Isencao(cert);
                    if (ex != null) {
                        throw ex;
                    }

                } else {
                    if (_tipo_certidao == TipoCertidao.ValorVenal) {
                        _nomeReport = "CertidaoValorVenal";
                        _numero_certidao = tributario_Class.Retorna_Codigo_Certidao(modelCore.TipoCertidao.ValorVenal);
                        _controle = _numero_certidao.ToString("00000") + _ano_certidao.ToString("0000") + "/" + _codigo.ToString() + "-VV";
                        Certidao_valor_venal cert = new Certidao_valor_venal();
                        cert.Codigo = Convert.ToInt32(_codigo);
                        cert.Ano = _ano_certidao;
                        cert.Numero = _numero_certidao;
                        cert.Data = DateTime.Now;
                        cert.Inscricao = Inscricao.Text;
                        cert.Nomecidadao = Nome.Text;
                        cert.Logradouro = Endereco.Text;
                        cert.Descbairro = Bairro.Text;
                        cert.Li_quadras = Quadra.Text;
                        cert.Li_lotes = Lote.Text;
                        Exception ex = tributario_Class.Insert_Certidao_ValorVenal(cert);
                        if (ex != null) {
                            throw ex;
                        }
                    } else {
                        if (_tipo_certidao == TipoCertidao.Debito) {

                            //***Verifica débito
                            Certidao_debito_detalhe dadosCertidao = tributario_Class.Certidao_Debito(_codigo);
                            if (dadosCertidao.Tipo_Retorno == RetornoCertidaoDebito.Negativa) {
                                sTipoCertidao = "NEGATIVA";
                                sNao = "não ";
                                nRet = 3;
                                sSufixo = "CN";
                                if (_tipo_cadastro == TipoCadastro.Imovel)
                                    _nomeReport = "CertidaoDebitoImovel";
                                else {
                                    if (_tipo_cadastro == TipoCadastro.Empresa)
                                        _nomeReport = "CertidaoDebitoEmpresa";
                                }
                            } else {
                                if (dadosCertidao.Tipo_Retorno == RetornoCertidaoDebito.Positiva) {
                                    sTipoCertidao = "POSITIVA";
                                    nRet = 4;
                                    sSufixo = "CP";
                                    if (_tipo_cadastro == TipoCadastro.Imovel)
                                        _nomeReport = "CertidaoDebitoImovel";
                                    else {
                                        if (_tipo_cadastro == TipoCadastro.Empresa)
                                            _nomeReport = "CertidaoDebitoEmpresa";
                                    }
                                } else {
                                    if (dadosCertidao.Tipo_Retorno == RetornoCertidaoDebito.NegativaPositiva) {
                                        sTipoCertidao = "POSITIVA COM EFEITO NEGATIVA";
                                        nRet = 5;
                                        sSufixo = "PN";
                                        if (_tipo_cadastro == TipoCadastro.Imovel)
                                            _nomeReport = "CertidaoDebitoImovelPN";
                                        else {
                                            if (_tipo_cadastro == TipoCadastro.Empresa)
                                                _nomeReport = "CertidaoDebitoEmpresaPN";
                                        }
                                    }
                                }
                            }
                            sTributo = dadosCertidao.Descricao_Lancamentos;

                            _numero_certidao = tributario_Class.Retorna_Codigo_Certidao(modelCore.TipoCertidao.Debito);
                            _controle = _numero_certidao.ToString("00000") + _ano_certidao.ToString("0000") + "/" + _codigo.ToString() + "-" + sSufixo;
                            Certidao_debito cert = new Certidao_debito();
                            cert.Codigo = Convert.ToInt32(_codigo);
                            cert.Ano = (short)_ano_certidao;
                            cert.Ret = nRet;
                            cert.Numero = _numero_certidao;
                            cert.Datagravada = DateTime.Now;
                            cert.Inscricao =Inscricao.Text;
                            cert.Nome = Nome.Text;
                            cert.Logradouro = Endereco.Text;
                            cert.Bairro = Bairro.Text;
                            cert.Cidade = Cidade.Text;
                            cert.Processo = Processo.Text;
                            cert.Dataprocesso = _data_processo;
                            cert.Atendente = gtiCore.Retorna_Last_User();
                            cert.Cpf = sCPF;
                            cert.Cnpj = sCNPJ;
                            cert.Atividade = Atividade.Text;
                            cert.Lancamento = dadosCertidao.Descricao_Lancamentos;
                            Exception ex = tributario_Class.Insert_Certidao_Debito(cert);
                            if (ex != null) {
                                throw ex;
                            }
                        }
                    }
                }

                if (_numero_certidao > 0) {
                    _dados = new Report_Data() {
                        Codigo = Convert.ToInt32(Codigo.Text),
                        Inscricao = Inscricao.Text,
                        Nome = Nome.Text,
                        Cpf_cnpj = Doc.Text,
                        Endereco = Endereco.Text,
                        Nome_bairro = Bairro.Text,
                        Quadra_original = Quadra.Text,
                        Lote_original = Lote.Text,
                        Nome_cidade = Cidade.Text,
                        Cep = Cep.Text,
                        Numero_Certidao = _numero_certidao.ToString("000000") + "/" + _ano_certidao.ToString(),
                        Controle = _controle,
                        Assinatura_Hide = Assinatura.Checked,
                        Processo = Processo.Text,
                        Data_Processo = _data_processo,
                        UserId = _userId,
                        Perc_Isencao = _percisencao,
                        Data_Processo_Isencao = _data_processo_isencao,
                        Processo_Isencao = _numero_processo,
                        AnoIsencao = _ano_isencao,
                        Area = SomaArea,
                        Nao=sNao,
                        TipoCertidao=sTipoCertidao,
                        Tributos=sTributo,
                        Atividade=sAtividade
                        
                    };
                    ReportCR fRpt = new ReportCR(_nomeReport, _dados,null);
                    fRpt.ShowDialog();
                    ClearFields();
                }
            }
        }


    }
}
