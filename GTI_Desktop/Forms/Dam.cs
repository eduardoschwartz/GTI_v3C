using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Dam : Form {
        string _connection = gtiCore.Connection_Name();
        List<SpExtrato> _lista_selecionados = new List<SpExtrato>();
        List<SpExtrato> _extrato = new List<SpExtrato>();
        Color _backColor = Color.White, _foreColor = Color.Brown;
        Font _font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
        DateTime _data_refis_inicio,_data_refis_final,_data_refisdi_inicio,_data_refisdi_final;
        bool _refis_ativo = false, _refisdi_ativo = false;
        int _plano = 0;

        public Dam(List<SpExtrato>_ListaSelecionados,List<SpExtrato>_ListaTributos) {
            InitializeComponent();
            tBar.Renderer = new MySR();
            _lista_selecionados = _ListaSelecionados;
            _extrato = _ListaTributos;
            DataVencimentoText.Text = DateTime.Now.ToString("dd/MM/yyyy");
            HonoraioCheckBox.Enabled = gtiCore.GetBinaryAccess((int)TAcesso.DAM_Honorario);
            DesativarRefisCheckBox.Enabled = gtiCore.GetBinaryAccess((int)TAcesso.DAM_Desativar_Refis);
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.DAM_Desconto);
            if (!bAllow){
                MultaUpDown.Enabled = false;
                CorrecaoUpDown.Enabled = false;
                JurosUpDown.Enabled = false;
                MultaRefreshButton.Enabled = false;
                JurosRefreshButton.Enabled = false;
                CorrecaoRefreshButton.Enabled = false;
                MultaUpDown.BackColor = BackColor;
                JurosUpDown.BackColor = BackColor;
                CorrecaoUpDown.BackColor = BackColor;
            }
            Header();
            Carrega_Lista();
            MainListView.Items[0].Selected = true;
            MainListView.Focus ();
        }

        private void MultaRefreshButton_Click(object sender, EventArgs e) {
            Carrega_Lista();
        }

        private void JurosRefreshButton_Click(object sender, EventArgs e) {
            Carrega_Lista();
        }

        private void CorrecaoRefreshButton_Click(object sender, EventArgs e) {
            Carrega_Lista();
        }

        private void DataVenctoDateTimePicker_ValueChanged(object sender, EventArgs e) {
            MainListView.Items.Clear();
            Atualiza_Lista_Debitos();
        }

        private void DataVencimentoRefreshButton_Click(object sender, EventArgs e) {
            if (gtiCore.IsDate(DataVencimentoText.Text)) {
                Atualiza_Lista_Debitos();
                Carrega_Lista();
            } else {
                MessageBox.Show("Data de vencimento inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculoDataRefreshData_Click(object sender, EventArgs e) {
            Atualiza_Lista_Debitos();
            Carrega_Lista();
        }

        private void Carrega_Lista() {
            //TODO Honorários
            //TODO Refis

            gtiCore.Ocupado(this);
            MainListView.Items.Clear();
            List<SpExtrato> _listaTmp = new List<SpExtrato>();
            decimal _perc_multa = MultaUpDown.Value;
            decimal _perc_juros = JurosUpDown.Value;
            decimal _perc_correcao = CorrecaoUpDown.Value;

            foreach (SpExtrato itemSelected in _lista_selecionados) {
                foreach (SpExtrato itemTributo in _extrato) {
                    if (itemSelected.Anoexercicio == itemTributo.Anoexercicio && itemSelected.Codlancamento == itemTributo.Codlancamento && itemSelected.Seqlancamento == itemTributo.Seqlancamento &&
                        itemSelected.Numparcela == itemTributo.Numparcela && itemSelected.Codcomplemento == itemTributo.Codcomplemento) {

                        int _pos = 0;
                        bool _find = false;
                        decimal _valor_multa = _perc_multa > 0 ? itemTributo.Valormulta - (itemTributo.Valormulta * _perc_multa / 100) : itemTributo.Valormulta;
                        decimal _valor_juros = _perc_juros > 0 ? itemTributo.Valorjuros - (itemTributo.Valorjuros * _perc_juros / 100) : itemTributo.Valorjuros;
                        decimal _valor_correcao = _perc_correcao > 0 ? itemTributo.Valorcorrecao - (itemTributo.Valorcorrecao * _perc_correcao / 100) : itemTributo.Valorcorrecao;
                        foreach (SpExtrato itemTmp in _listaTmp) {
                            if (itemSelected.Anoexercicio == itemTmp.Anoexercicio && itemSelected.Codlancamento == itemTmp.Codlancamento && itemSelected.Seqlancamento == itemTmp.Seqlancamento &&
                                itemSelected.Numparcela == itemTmp.Numparcela && itemSelected.Codcomplemento == itemTmp.Codcomplemento) {
                                _find = true;
                                break;
                            }
                            _pos++;
                        }

                        if (!_find) {
                            SpExtrato _reg = new SpExtrato() {
                                Anoexercicio = itemTributo.Anoexercicio,
                                Codlancamento = itemTributo.Codlancamento,
                                Seqlancamento = itemTributo.Seqlancamento,
                                Numparcela = itemTributo.Numparcela,
                                Codcomplemento = itemTributo.Codcomplemento,
                                Datavencimento = itemTributo.Datavencimento,
                                Valortributo = itemTributo.Valortributo,
                                Valormulta = _valor_multa,
                                Valorjuros = _valor_juros,
                                Valorcorrecao = _valor_correcao,
                                Valortotal = itemTributo.Valortributo + _valor_multa + _valor_juros + _valor_correcao
                            };
                            _listaTmp.Add(_reg);
                        } else {
                            _listaTmp[_pos].Valortributo += itemTributo.Valortributo;
                            _listaTmp[_pos].Valormulta += _valor_multa;
                            _listaTmp[_pos].Valorjuros += _valor_juros;
                            _listaTmp[_pos].Valorcorrecao += _valor_correcao;
                            _listaTmp[_pos].Valortotal += itemTributo.Valortributo + _valor_multa + _valor_juros + _valor_correcao;
                        }
                    }
                }
            }

            decimal _principal = 0,_multa=0,_juros=0,_correcao=0,_total=0;
            ListViewItem lvItem;
            foreach (SpExtrato item in _listaTmp) {
                lvItem = new ListViewItem(item.Anoexercicio.ToString());
                lvItem.SubItems.Add(item.Codlancamento.ToString("00"));
                lvItem.SubItems.Add(item.Seqlancamento.ToString("000"));
                lvItem.SubItems.Add(item.Numparcela.ToString("000"));
                lvItem.SubItems.Add(item.Codcomplemento.ToString());
                lvItem.SubItems.Add(item.Datavencimento.ToString("dd/MM/yyyy"));
                lvItem.SubItems.Add(item.Valortributo.ToString("#0.00"));
                lvItem.SubItems.Add(item.Valormulta.ToString("#0.00"));
                lvItem.SubItems.Add(item.Valorjuros.ToString("#0.00"));
                lvItem.SubItems.Add(item.Valorcorrecao.ToString("#0.00"));
                lvItem.SubItems.Add(item.Valortotal.ToString("#0.00"));
                MainListView.Items.Add(lvItem);
                _principal += Math.Round(item.Valortributo, 2);
                _multa += Math.Round(item.Valormulta, 2,MidpointRounding.AwayFromZero);
                _juros += Math.Round(item.Valorjuros, 2, MidpointRounding.AwayFromZero);
                _correcao += Math.Round(item.Valorcorrecao, 2, MidpointRounding.AwayFromZero);
                _total += Math.Round(item.Valortotal, 2, MidpointRounding.AwayFromZero);
            }
            lvItem = new ListViewItem {
                Text = "",
                ForeColor = Color.Brown,
                UseItemStyleForSubItems = false
            };
            lvItem.SubItems.Add("");
            lvItem.SubItems.Add("");
            lvItem.SubItems.Add("");
            lvItem.SubItems.Add("");
            lvItem.SubItems.Add("Total==>", _foreColor, _backColor, _font);
            lvItem.SubItems.Add(_principal.ToString("#0.00"), _foreColor, _backColor, _font);
            lvItem.SubItems.Add(_multa.ToString("#0.00"), _foreColor, _backColor, _font);
            lvItem.SubItems.Add(_juros.ToString("#0.00"), _foreColor, _backColor, _font);
            lvItem.SubItems.Add(_correcao.ToString("#0.00"), _foreColor, _backColor, _font);
            lvItem.SubItems.Add(_total.ToString("#0.00"), _foreColor, _backColor, _font);
            MainListView.Items.Add(lvItem);
            gtiCore.Liberado(this);
        }

        private void Atualiza_Lista_Debitos() {
            gtiCore.Ocupado(this);
            Tributario_bll clsTributario = new Tributario_bll(_connection);
            DateTime _data_Atualiza;
            if (gtiCore.IsDate(DataCalculoText.Text))
                _data_Atualiza = Convert.ToDateTime(DataCalculoText.Text);
            else {
                if(gtiCore.IsDate(DataVencimentoText.Text))
                    _data_Atualiza = Convert.ToDateTime(DataVencimentoText.Text);
                else {
                    MessageBox.Show("Data de vencimento inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DataVencimentoText.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    _data_Atualiza = DateTime.Now;
                }
            }
            _extrato = clsTributario.Lista_Extrato_Tributo(Codigo: _lista_selecionados[0].Codreduzido,Data_Atualizacao:_data_Atualiza);
            gtiCore.Liberado(this);
        }

        private void OKButton_Click(object sender, EventArgs e) {
            if (CPFText.Text == "") 
                MessageBox.Show("CPF/CNPJ obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                Emite_Boleto();
            }
        }

        private void SairButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void Header() {
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            Contribuinte_Header_Struct _dados = sistema_Class.Contribuinte_Header(_lista_selecionados[0].Codreduzido);
            NomeText.Text = _dados.Nome;
            CPFText.Text = _dados.Cpf_cnpj;
            EnderecoText.Text = _dados.Endereco_abreviado + ", " + _dados.Numero.ToString() + " " + _dados.Complemento + " " + _dados.Nome_bairro;
            CidadeText.Text = _dados.Nome_cidade;
            UFText.Text = _dados.Nome_uf;
            CepText.Text = _dados.Cep;

            _data_refis_inicio = Convert.ToDateTime(sistema_Class.Retorna_Valor_Parametro("REFIS_INICIO"));
            _data_refis_final = Convert.ToDateTime(sistema_Class.Retorna_Valor_Parametro("REFIS_FIM"));
            _data_refisdi_inicio = Convert.ToDateTime(sistema_Class.Retorna_Valor_Parametro("REFISDI_INICIO"));
            _data_refisdi_final = Convert.ToDateTime(sistema_Class.Retorna_Valor_Parametro("REFISI_FIM"));

            DateTime _data_now = DateTime.Now;
            if (_data_now >= _data_refis_inicio && _data_now <= _data_refis_final)
                _refis_ativo = true;

            if (_data_now >= _data_refisdi_inicio && _data_now <= _data_refisdi_final)
                _refisdi_ativo = true;


        }

        private void Emite_Boleto() {
            int nSid = gtiCore.GetRandomNumber();
            int _numero_documento = 0;
            string _valor_guia = MainListView.Items[MainListView.Items.Count - 1].SubItems[10].Text;
            string _nome = NomeText.Text;
            string _endereco = EnderecoText.Text.Length > 60 ? EnderecoText.Text.Substring(0, 60) : EnderecoText.Text;
            string _dataVencto = DataVencimentoText.Text;
            string _nosso_numero = "287353200" + _numero_documento.ToString("00000000");
            string _cidade = CidadeText.Text.Length > 18 ? CidadeText.Text.Substring(0, 18) : CidadeText.Text;
            string _uf = UFText.Text;
            string _cep = gtiCore.RetornaNumero(CepText.Text);
            string _user = "GTI-Dam";
            if (_cep.Trim() == "" || _cep.Trim() == "-")
                _cep = "14870000";
            string _cpfcnpj = gtiCore.RetornaNumero( CPFText.Text);
            string _tipo_doc = _cpfcnpj.Length == 1 ? "1" : "2";
            string _path = "http://sistemas.jaboticabal.sp.gov.br/gti/Pages/boletoBB.aspx?f1=" + _nome + "&f2=" + _endereco +
                "&f3=" + _dataVencto + "&f4=" + _cpfcnpj + "&f5=" + _nosso_numero + "&f6=" + _valor_guia + "&f7=" + _cidade + 
                "&f8=" + _uf + "&f9=" + _cep + "&f10=" + _user;

            WebBrowserForm frm = new WebBrowserForm(_path);
            frm.ShowDialog();

            
        }

    }
}
