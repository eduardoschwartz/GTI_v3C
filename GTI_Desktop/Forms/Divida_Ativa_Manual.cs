using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Divida_Ativa_Manual : Form {
        public int ReturnValue { get; set; }
        int _codigo, _UserId,_numero_livro=0;
        string _connection = gtiCore.Connection_Name();
        string _connection_integrativa = gtiCore.Connection_Name("GTI_Integrativa");
        List<SpExtrato> _listaTributo=new List<SpExtrato>();

        public Divida_Ativa_Manual(List<SpExtrato> Lista,List<SpExtrato>Lista_Tributo) {
            InitializeComponent();
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            _listaTributo = Lista_Tributo;
            _UserId = sistema_Class.Retorna_User_LoginId(gtiCore.Retorna_Last_User());

            _codigo = Lista[0].Codreduzido;
            int _lanc = Convert.ToInt32(Lista[0].Desclancamento.Substring(0, 2));
            Tipolivro _tipo_livro = tributario_Class.Retorna_Tipo_Livro_Divida_Ativa(_lanc);
            if (_tipo_livro == null)
                LivroText.Text = "0 - LIVRO NÃO CADASTRADO";
            else
                LivroText.Text = _tipo_livro.Codtipo.ToString() + " - " + _tipo_livro.Desctipo;

            foreach (SpExtrato item in Lista) {
                _lanc = Convert.ToInt32(item.Desclancamento.Substring(0, 2));
                _tipo_livro = tributario_Class.Retorna_Tipo_Livro_Divida_Ativa(_lanc);
                _numero_livro = _tipo_livro.Codtipo;

                ListViewItem lv = new ListViewItem(item.Anoexercicio.ToString());
                lv.SubItems.Add(item.Desclancamento);
                lv.SubItems.Add(item.Seqlancamento.ToString());
                lv.SubItems.Add(item.Numparcela.ToString());
                lv.SubItems.Add(item.Codcomplemento.ToString());
                lv.SubItems.Add(item.Datavencimento.ToString("dd/MM/yyyy"));
                lv.SubItems.Add(item.Valortributo.ToString("#0.00"));
                lv.SubItems.Add(item.Datainscricao==null?"N":"S");
                lv.SubItems.Add(_tipo_livro==null?"0":_tipo_livro.Codtipo.ToString());
                MainListView.Items.Add(lv);

                DataInscricaoText.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void SairButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e) {
            foreach (ListViewItem linha in MainListView.Items) {
                if (linha.SubItems[7].Text == "S") {
                    MessageBox.Show("Apenas lançamentos não inscritos em divida ativa podem ser inscritos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            List<int> _lista = new List<int>();
            foreach (ListViewItem linha in MainListView.Items) {
                int _tipo = Convert.ToInt32(linha.SubItems[8].Text);
                if (_lista.Count == 0)
                    _lista.Add(_tipo);
                else {
                    foreach (int item in _lista) {
                        if (item != _tipo) {
                            _lista.Add(item);
                            break;
                        }
                    }
                }
            }

            if (_lista.Count > 1)
                MessageBox.Show("Não é possível escrever em dívida ativa lançamentos que pertencem a livros diferentes.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (Convert.ToInt32(LivroText.Text.Substring(0, 1)) == 0)
                    MessageBox.Show("Nenhum livro selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {

                    if (!DateTime.TryParseExact(DataInscricaoText.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime _data)) {
                        MessageBox.Show("Data de Inscrição inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else {
                        Grava_Dados();
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
        }

        private void Grava_Dados() {
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            GTI_Models.modelCore.TipoCadastro _tipo_cadastro = sistema_Class.Tipo_Cadastro(_codigo);

            Contribuinte_Header_Struct _header = sistema_Class.Contribuinte_Header(_codigo);

            string _tipo_divida = _tipo_cadastro == GTI_Models.modelCore.TipoCadastro.Imovel ? "Imobiliário" :
                                  _tipo_cadastro == GTI_Models.modelCore.TipoCadastro.Cidadao ? "Taxas Diversas" : "Mobiliário";
            int _certidao = tributario_Class.Retorna_Ultima_Certidao_Livro(_numero_livro);
            int _pagina = _certidao;

            Cdas regCda = new Cdas() {
                Iddevedor = _codigo.ToString(),
                Setordevedor = _tipo_divida,
                Dtinscricao = Convert.ToDateTime(DataInscricaoText.Text),
                Nrocertidao = _certidao,
                Nrolivro = _numero_livro,
                Nrofolha = _pagina,
                Dtgeracao = DateTime.Now
            };
            Integrativa_bll integrativa_Class = new Integrativa_bll(_connection_integrativa);
            int _idCda = integrativa_Class.Insert_Integrativa_Cda(regCda);

            if(_tipo_cadastro != GTI_Models.modelCore.TipoCadastro.Cidadao) {
                Cadastro regCadastro = new Cadastro() {
                    Idcda=_idCda,
                    Setordevedor=_tipo_divida,
                    Crc=_codigo,
                    Nome=_header.Nome,
                    Inscricao=_header.Inscricao,
                    Cpfcnpj=_header.Cpf_cnpj,
                    Rginscrestadual=_header.Rg,
                    Localcep=_header.Cep,
                    Localendereco=_header.Endereco,
                    Localnumero=_header.Numero,
                    Localcomplemento=_header.Complemento,
                    Localbairro=_header.Nome_bairro,
                    Localcidade=_header.Nome_cidade,
                    LocalEstado=_header.Nome_uf,
                    Quadra=_header.Quadra_original,
                    Lote=_header.Lote_original,
                    Entregacep=_header.Cep_entrega,
                    Entregaendereco=_header.Endereco_entrega,
                    Entreganumero=_header.Numero_entrega,
                    Entregabairro=_header.Nome_bairro_entrega,
                    Entregacomplemento=_header.Complemento_entrega,
                    Entregacidade=_header.Nome_cidade_entrega,
                    Entregaestado=_header.Nome_uf_entrega,
                    Dtgeracao=DateTime.Now
                };
                integrativa_Class = new Integrativa_bll(_connection_integrativa);
                int _idCadastro = integrativa_Class.Insert_Integrativa_Cadastro(regCadastro);

            } else {
                Partes regPartes = new Partes() {
                    Idcda = _idCda,
                    Tipo = "Principal",
                    Crc = _codigo,
                    Nome = _header.Nome,
                    Cpfcnpj = _header.Cpf_cnpj,
                    Rginscrestadual = _header.Rg,
                    Cep = _header.Cep,
                    Endereco = _header.Endereco,
                    Numero = _header.Numero,
                    Complemento = _header.Complemento,
                    Bairro = _header.Nome_bairro,
                    Cidade = _header.Nome_cidade,
                    Estado = _header.Nome_uf,
                    Dtgeracao = DateTime.Now
                };
                integrativa_Class = new Integrativa_bll(_connection_integrativa);
                int _idPartes = integrativa_Class.Insert_Integrativa_Partes(regPartes);
            }
            Imovel_bll imovel_Class = new Imovel_bll(_connection);
            Cidadao_bll cidadao_Class = new Cidadao_bll(_connection);
            Empresa_bll empresa_class = new Empresa_bll(_connection);
            if (_tipo_cadastro == GTI_Models.modelCore.TipoCadastro.Imovel) {
                List<ProprietarioStruct> ListaPropImovel = imovel_Class.Lista_Proprietario(_codigo);
                foreach (ProprietarioStruct item in ListaPropImovel) {
                    CidadaoStruct _cidadao = cidadao_Class.Dados_Cidadao(item.Codigo);
                    Partes regPartes = new Partes() {
                        Idcda = _idCda,
                        Tipo = item.Principal ? "Principal" : "Compromissário",
                        Crc = _codigo,
                        Nome = _cidadao.Nome,
                        Cpfcnpj = string.IsNullOrWhiteSpace(_cidadao.Cnpj) ? _cidadao.Cpf : _cidadao.Cnpj,
                        Rginscrestadual = _cidadao.Rg,
                        Dtgeracao = DateTime.Now
                    };
                    if (_cidadao.EtiquetaR == "C") {
                        regPartes.Cep = _cidadao.CepC.ToString();
                        regPartes.Endereco = _cidadao.EnderecoC;
                        regPartes.Numero = _cidadao.NumeroC;
                        regPartes.Complemento = _cidadao.ComplementoC;
                        regPartes.Bairro = _cidadao.NomeBairroC;
                        regPartes.Cidade = _cidadao.NomeCidadeC;
                        regPartes.Estado = _cidadao.UfC;
                    } else {
                        regPartes.Cep = _cidadao.CepR.ToString();
                        regPartes.Endereco = _cidadao.EnderecoR;
                        regPartes.Numero = _cidadao.NumeroR;
                        regPartes.Complemento = _cidadao.ComplementoR;
                        regPartes.Bairro = _cidadao.NomeBairroR;
                        regPartes.Cidade = _cidadao.NomeCidadeR;
                        regPartes.Estado = _cidadao.UfR;
                    }
                    integrativa_Class = new Integrativa_bll(_connection_integrativa);
                    int _idPartes = integrativa_Class.Insert_Integrativa_Partes(regPartes);
                }
            } else {
                if (_tipo_cadastro == GTI_Models.modelCore.TipoCadastro.Empresa) {
                    List<CidadaoStruct> ListaSocio = empresa_class.ListaSocio(_codigo);
                    foreach (CidadaoStruct item in ListaSocio) {
                        CidadaoStruct _cidadao = cidadao_Class.Dados_Cidadao(item.Codigo);
                        Partes regPartes = new Partes() {
                            Idcda = _idCda,
                            Tipo = "Sócio",
                            Crc = _codigo,
                            Nome = _cidadao.Nome,
                            Cpfcnpj = string.IsNullOrWhiteSpace(_cidadao.Cnpj) ? _cidadao.Cpf : _cidadao.Cnpj,
                            Rginscrestadual = _cidadao.Rg,
                            Dtgeracao = DateTime.Now
                        };
                        if (_cidadao.EtiquetaR == "C") {
                            regPartes.Cep = _cidadao.CepC.ToString();
                            regPartes.Endereco = _cidadao.EnderecoC;
                            regPartes.Numero = _cidadao.NumeroC;
                            regPartes.Complemento = _cidadao.ComplementoC;
                            regPartes.Bairro = _cidadao.NomeBairroC;
                            regPartes.Cidade = _cidadao.NomeCidadeC;
                            regPartes.Estado = _cidadao.UfC;
                        } else {
                            regPartes.Cep = _cidadao.CepR.ToString();
                            regPartes.Endereco = _cidadao.EnderecoR;
                            regPartes.Numero = _cidadao.NumeroR;
                            regPartes.Complemento = _cidadao.ComplementoR;
                            regPartes.Bairro = _cidadao.NomeBairroR;
                            regPartes.Cidade = _cidadao.NomeCidadeR;
                            regPartes.Estado = _cidadao.UfR;
                        }
                        integrativa_Class = new Integrativa_bll(_connection_integrativa);
                        int _idPartes = integrativa_Class.Insert_Integrativa_Partes(regPartes);
                    }
                }
            }

            foreach (ListViewItem linha in MainListView.Items) {
                short _ano = Convert.ToInt16(linha.Text);
                short _lanc = Convert.ToInt16(linha.SubItems[1].Text.Substring(0,2));
                short _seq = Convert.ToInt16(linha.SubItems[2].Text);
                byte _parc = Convert.ToByte(linha.SubItems[3].Text);
                byte _compl = Convert.ToByte(linha.SubItems[4].Text);

                Exception ex = tributario_Class.Inscrever_Divida_Ativa(_codigo, _ano, _lanc, _seq, _parc, _compl, _numero_livro, _pagina, _certidao, Convert.ToDateTime(DataInscricaoText.Text));

                foreach (SpExtrato item in _listaTributo) {
                    if(item.Anoexercicio==_ano && item.Codlancamento==_lanc && item.Seqlancamento==_seq && item.Numparcela==_parc && item.Codcomplemento == _compl) {
                        Cdadebitos regCdaDebito = new Cdadebitos() {
                            Idcda = _idCda,
                            Codtributo=item.Codtributo,
                            Tributo=item.Abrevtributo,
                            Exercicio=_ano,
                            Lancamento=_lanc,
                            Seq=_seq,
                            Nroparcela=_parc,
                            Complparcela=_compl,
                            Dtvencimento=item.Datavencimento,
                            Vlroriginal=item.Valortributo,
                            Vlrmultas=item.Valormulta,
                            Vlrjuros=item.Valorjuros,
                            Vlrcorrecao=item.Valorcorrecao,
                            Dtgeracao=DateTime.Now
                        };
                        int _IdCdaDebito = integrativa_Class.Insert_Integrativa_CdaDebito(regCdaDebito);
                    }
                }
            }

        }

    }
}
