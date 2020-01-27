using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Desktop.Properties;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static GTI_Desktop.Classes.GtiTypes;
using static GTI_Models.modelCore;

namespace GTI_Desktop.Forms {
    public partial class Extrato : Form {

        string _connection = gtiCore.Connection_Name();
        List<SpExtrato> Lista_Extrato_Tributo;
        List<SpExtrato> Lista_Extrato_Parcela;
        List<ObsparcelaStruct> Lista_Observacao;
        List<CustomListBoxItem2> Lista_Lancamento = new List<CustomListBoxItem2>();
        List<CustomListBoxItem2> Lista_Status = new List<CustomListBoxItem2>();
        int _filtro_exercicio_inicio, _filtro_exercicio_fim;
        bool bAddNew, bObsGeral,bFiltroAtivo;

        public Extrato() {
            InitializeComponent();
            this.Size = new System.Drawing.Size(Properties.Settings.Default.Form_Extrato_width, Properties.Settings.Default.Form_Extrato_height);
            Grid_Format();
            ClearAll(true);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (ExtratoDataGrid.Rows.Count == 0) return false;
            if (ObservacaoPanel.Visible) return false;
            if (keyData == Keys.Enter) {
                if (ExtratoDataGrid.SelectedRows.Count > 0) {
                    int RowIndex = ExtratoDataGrid.SelectedRows[0].Index;
                    DataGridViewRow linha = ExtratoDataGrid.Rows[RowIndex];
                    int nStatus = Convert.ToInt32(linha.Cells["status"].Value.ToString().Substring(0, 2));
                    if (nStatus == 3 | nStatus == 42 | nStatus == 43) {
                        if (ExtratoDataGrid.Rows[RowIndex].Tag.ToString() == "1") {
                            ExtratoDataGrid.Rows[RowIndex].Tag = "";
                            for (int i = 0; i < ExtratoDataGrid.ColumnCount; i++) {
                                ExtratoDataGrid.Rows[RowIndex].DefaultCellStyle.BackColor = Color.White;
                                ExtratoDataGrid.Rows[RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                                ExtratoDataGrid.Rows[RowIndex].DefaultCellStyle.SelectionBackColor = Color.DarkRed;
                                ExtratoDataGrid.Rows[RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
                                ExtratoDataGrid.Rows[RowIndex].Cells["status"].Style.BackColor = Color.White;
                            }
                        } else {
                            ExtratoDataGrid.Rows[RowIndex].Tag = "1";
                            for (int i = 0; i < ExtratoDataGrid.ColumnCount; i++) {
                                ExtratoDataGrid.Rows[RowIndex].DefaultCellStyle.BackColor = Color.Aquamarine;
                                ExtratoDataGrid.Rows[RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                                ExtratoDataGrid.Rows[RowIndex].DefaultCellStyle.SelectionBackColor = Color.DarkRed;
                                ExtratoDataGrid.Rows[RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
                                ExtratoDataGrid.Rows[RowIndex].Cells["status"].Style.BackColor = Color.Aquamarine;
                            }
                        }
                    }
                }
                Atualiza_Total();
                return true;
            } else if (keyData == Keys.F8) {
                for (int i = 0; i < ExtratoDataGrid.Rows.Count; i++) {
                    DataGridViewRow linha = ExtratoDataGrid.Rows[i];
                    int nStatus = Convert.ToInt32(linha.Cells["status"].Value.ToString().Substring(0, 2));
                    if ( nStatus==3 | nStatus ==42 | nStatus == 43) {
                        if (linha.Tag.ToString() == "1") {
                            linha.Tag = "";
                            for (int j = 0; j < ExtratoDataGrid.ColumnCount; j++) {
                                linha.DefaultCellStyle.BackColor = Color.White;
                                linha.DefaultCellStyle.ForeColor = Color.Black;
                                linha.DefaultCellStyle.SelectionBackColor = Color.DarkRed;
                                linha.DefaultCellStyle.SelectionForeColor = Color.White;
                                ExtratoDataGrid.Rows[i].Cells["status"].Style.BackColor = Color.White;
                            }
                        } else {
                            linha.Tag = "1";
                            for (int j = 0; j < ExtratoDataGrid.ColumnCount; j++) {
                                linha.DefaultCellStyle.BackColor = Color.Aquamarine;
                                linha.DefaultCellStyle.ForeColor = Color.Black;
                                linha.DefaultCellStyle.SelectionBackColor = Color.DarkRed;
                                linha.DefaultCellStyle.SelectionForeColor = Color.White;
                                ExtratoDataGrid.Rows[i].Cells["status"].Style.BackColor = Color.Aquamarine;
                            }
                        }
                    }
                }
                Atualiza_Total();
                return true;
            } else if (keyData == Keys.F9) {
                Detalhe_Parcela();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Detalhe_Parcela() {
            if (ExtratoDataGrid.SelectedRows.Count > 0) {
                FiltroPanel.Visible = false;
                DataGridViewRow linha = ExtratoDataGrid.SelectedRows[0];
                List<SpExtrato> Lista = new List<SpExtrato>();
                foreach (SpExtrato reg in Lista_Extrato_Tributo) {
                    if (reg.Anoexercicio == Convert.ToInt16(linha.Cells["ano"].Value) &&
                        reg.Codlancamento == Convert.ToInt16(linha.Cells["lancamento"].Value.ToString().Substring(0, 2)) &&
                        reg.Seqlancamento == Convert.ToInt16(linha.Cells["sequencia"].Value) &&
                        reg.Numparcela == Convert.ToInt16(linha.Cells["parcela"].Value) &&
                        reg.Codcomplemento == Convert.ToByte(linha.Cells["complemento"].Value)) {
                        Lista.Add(reg);
                    }
                }
                Parcela_Detalhe frm = new Parcela_Detalhe(Convert.ToInt32(CodigoText.Text), NomeText.Text, Lista);
                frm.ShowDialog(this);
            } else
                MessageBox.Show("Selecione uma parcela.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void TxtCodigo_TextChanged(object sender, EventArgs e) {
            ClearAll(true);
        }

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void TxtCodigo_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                GeraExtrato();
            }
        }

        private void BtRefresh_Click(object sender, EventArgs e) {
            ExtratoDataGrid.Rows.Clear();
            bFiltroAtivo = false;
            GeraExtrato();
        }

        private void GeraExtrato() {
            if (CodigoText.Text.Trim() == "") return;
            int Codigo = Convert.ToInt32(CodigoText.Text);
            gtiCore.Ocupado(this);
            FiltroPanel.Visible = false;
            Sistema_bll clsSistema = new Sistema_bll(_connection);
            if (!clsSistema.Existe_Cadastro(Codigo)) {
                MessageBox.Show("Cadastro não localizado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NomeText.Text = "";
                gtiCore.Liberado(this);
            } else {
                Contribuinte_Header_Struct reg = clsSistema.Contribuinte_Header(Codigo);
                this.Refresh();
                if (string.IsNullOrWhiteSpace(reg.Nome)) {
                    MessageBox.Show("Cadastro não localizado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NomeText.Text = "";
                    gtiCore.Liberado(this);
                } else {
                    NomeText.Text = reg.Nome;
                    if (reg.Tipo == TipoCadastro.Imovel) {
                        TipoCadastroLabel.Text = "Imóvel";
                    } else {
                        if (reg.Tipo == TipoCadastro.Empresa) {
                            TipoCadastroLabel.Text = "Empresa";
                        } else {
                            TipoCadastroLabel.Text = "Cidadão";
                        }
                    }
                    if (reg.Ativo) {
                        if (reg.Tipo == TipoCadastro.Empresa)
                            SituacaoCadastroLabel.Text = "Ativa";
                        else
                            SituacaoCadastroLabel.Text = "Ativo";
                        SituacaoCadastroLabel.ForeColor = Color.Green;
                    } else {
                        if (reg.Tipo == TipoCadastro.Empresa) 
                            SituacaoCadastroLabel.Text = "Inativa";
                        else
                            SituacaoCadastroLabel.Text = "Inativo";
                        SituacaoCadastroLabel.ForeColor = Color.Red;
                    }

                    Tributario_bll tributario_Class = new Tributario_bll(_connection);
                    if (tributario_Class.InSerasa(Codigo))
                        SerasaLabel.Visible = true;

                    Carrega_Extrato(Convert.ToInt32(CodigoText.Text));
                    Exibe_Extrato();
                    gtiCore.Liberado(this);
                }
            }
        }

        private void ClearAll(bool ClearName) {
            if (ClearName)
                NomeText.Text = "";
            FiltroPanel.Visible = false;
            ExtratoDataGrid.Rows.Clear();
            ChkAllExercicio.Checked = false;
            ChkParcelaOculta.Checked = false;
            CmbDivAtiva.SelectedIndex = 0;
            CmbAjuizado.SelectedIndex = 0;
            ObservacaoPanel.Visible = false;
            ObservacaoText.Text = "";
            DocumentoPanel.Visible = false;
            DocumentoListView.Items.Clear();
            TipoCadastroLabel.Text = "Tipo de";
            SituacaoCadastroLabel.Text = "Cadastro";
            SituacaoCadastroLabel.ForeColor = Color.Black;
            SerasaLabel.Visible = false;
        }

        private void Grid_Format() {
            ExtratoDataGrid.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ExtratoDataGrid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ExtratoDataGrid.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ExtratoDataGrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ExtratoDataGrid.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ExtratoDataGrid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ExtratoDataGrid.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ExtratoDataGrid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ExtratoDataGrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ExtratoDataGrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ExtratoDataGrid.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ExtratoDataGrid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ExtratoDataGrid.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ExtratoDataGrid.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ExtratoDataGrid.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ExtratoDataGrid.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ExtratoDataGrid.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ExtratoDataGrid.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ExtratoDataGrid.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ExtratoDataGrid.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn column in ExtratoDataGrid.Columns) {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            };
        }

        private void Carrega_Extrato(int Codigo) {
            Tributario_bll clsTributario = new Tributario_bll(_connection);
            Lista_Extrato_Tributo = clsTributario.Lista_Extrato_Tributo(Codigo);
            Lista_Extrato_Parcela = clsTributario.Lista_Extrato_Parcela(Lista_Extrato_Tributo);

            if (Lista_Extrato_Parcela.Count == 0) {
                MessageBox.Show("Não existem débitos com estes parâmentros.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Lista_Observacao = clsTributario.Lista_Observacao_Parcela(Codigo);
            //carrega o filtro
            bFiltroAtivo = false;

            //Exercício
            CmbAnoInicial.Items.Clear();
            CmbAnoFinal.Items.Clear();

            short nAnoInicio = Lista_Extrato_Parcela[0].Anoexercicio;
            short nAnoFim = Lista_Extrato_Parcela[Lista_Extrato_Parcela.Count - 1].Anoexercicio;
            for (int i = nAnoInicio; i <= nAnoFim; i++) {
                CmbAnoInicial.Items.Add(i);
                CmbAnoFinal.Items.Add(i);
            }

            CmbAnoInicial.Text = (DateTime.Now.Year - 5).ToString();
            CmbAnoFinal.Text = nAnoFim.ToString();

            _filtro_exercicio_inicio = DateTime.Now.Year - 5;
            _filtro_exercicio_fim = nAnoFim;

            //Lançamento
            Lista_Lancamento.Clear();
            foreach (SpExtrato item in Lista_Extrato_Parcela) {
                bool bFind = false;
                for (int i = 0; i < Lista_Lancamento.Count; i++) {
                    if (item.Codlancamento == Lista_Lancamento[i]._value) {
                        bFind = true;
                        break;
                    }
                }
                if (!bFind) {
                    CustomListBoxItem2 reg = new CustomListBoxItem2(item.Desclancamento, item.Codlancamento, true);
                    Lista_Lancamento.Add(reg);
                }
            }

            //Status Lançamento
            Lista_Status.Clear();
            foreach (SpExtrato item in Lista_Extrato_Parcela) {
                bool bFind = false;
                for (int i = 0; i < Lista_Status.Count; i++) {
                    if (item.Statuslanc == Lista_Status[i]._value) {
                        bFind = true;
                        break;
                    }
                }
                if (!bFind) {
                    CustomListBoxItem2 reg = new CustomListBoxItem2(item.Situacao, item.Statuslanc, true);
                    Lista_Status.Add(reg);
                }
            }

        }

        private void Exibe_Extrato() {

            if (string.IsNullOrWhiteSpace(CodigoText.Text)) return;
            gtiCore.Ocupado(this);
            ExtratoDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            if (ExtratoDataGrid.Rows.Count > 0) {
                foreach (DataGridViewRow Linha in ExtratoDataGrid.Rows) {
                    Linha.Visible = Line_isVisible(Linha.Index);
                }
            } else {
                if (Lista_Extrato_Parcela == null)
                    GeraExtrato();
                foreach (SpExtrato item in Lista_Extrato_Parcela) {
                    string sLancamento = item.Codlancamento.ToString("00") + "-" + item.Desclancamento;
                    string sSeqLancamento = item.Seqlancamento.ToString();
                    string sNumParcela = item.Numparcela.ToString("00");
                    string sComplemento = item.Codcomplemento.ToString("00");
                    string sStatus = item.Statuslanc.ToString("00");
                    string sSituacao = item.Situacao;
                    string sDA = item.Datainscricao == null ? "N" : "S";
                    string sAJ = item.Dataajuiza == null ? "N" : "S";
                    string sExercicio = item.Anoexercicio.ToString();
                    string sDataVencto = item.Datavencimento.ToString("dd/MM/yyyy");
                    string sValorLanc = item.Valortributo.ToString("#0.00");
                    string sValorAtual = item.Valortotal.ToString("#0.00");
                    string sNotificado = item.Notificado == null ? "N" : item.Notificado == true ? "S" : "N";
                    string sCertidao = item.Prot_certidao == null ? "" : item.Prot_certidao.ToString();
                    string sDataRemessa = item.Prot_dtremessa == null ? "" : Convert.ToDateTime(item.Prot_dtremessa).ToString("dd/MM/yyyy");

                    string sExecFiscal = "";
                    if (item.Processocnj != null)
                        sExecFiscal = item.Processocnj;
                    else {
                        if (item.Anoexecfiscal != null)
                            sExecFiscal = Convert.ToInt32(item.Numexecfiscal).ToString("00000") + "/" + item.Anoexecfiscal.ToString();
                    }

                    bool bHasObs = Parcela_Tem_Observacao(item.Anoexercicio, item.Codlancamento, item.Seqlancamento, item.Numparcela, item.Codcomplemento);

                    ExtratoDataGrid.Rows.Add(bHasObs ? Resources.write : new Bitmap(1, 1), sExercicio, sLancamento, sSeqLancamento, sNumParcela, sComplemento, sStatus + "-" + sSituacao, sDataVencto, sDA, sAJ, sValorLanc,
                                             sValorAtual,sNotificado,sExecFiscal,sCertidao,sDataRemessa);
                    int nIndex = ExtratoDataGrid.Rows.Count - 1;
                    ExtratoDataGrid.Rows[nIndex].Tag = "";
                    ExtratoDataGrid.Rows[nIndex].Visible = Line_isVisible(nIndex);

                    Ajustar_Cores(nIndex);

                }

            }
            if (ExtratoDataGrid.DisplayedRowCount(true) == 0) {
                MessageBox.Show("Não existem registros a serem exibidos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gtiCore.Liberado(this);
            } else {
                int FirstLine = GetFirstVisibleRow();
                if (ExtratoDataGrid.Rows.Count > 0 && FirstLine > -1) ExtratoDataGrid.FirstDisplayedScrollingRowIndex = FirstLine;
                Atualiza_Total();
                ExtratoDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                gtiCore.Liberado(this);
            }
        }

        private void Ajustar_Cores(int Index) {
            if (Index >= Lista_Extrato_Parcela.Count) return;
            Color _cor_status_fonte = Color.Black;
            Color _cor_status_fundo = Color.White;
            SpExtrato item = Lista_Extrato_Parcela[Index];
            switch (item.Statuslanc) {
                case 1:
                    _cor_status_fonte = Color.MediumBlue;
                    break;
                case 2:
                    _cor_status_fonte = Color.Green;
                    break;
                case 3:
                case 42:
                case 43:
                    _cor_status_fonte = Color.Red;
                    break;
                case 4:
                    _cor_status_fonte = Color.DarkOrchid;
                    break;
                case 5:
                case 13:
                    _cor_status_fonte = Color.Blue;
                    break;
                case 6:
                    _cor_status_fonte = Color.IndianRed;
                    break;
                case 7:
                    _cor_status_fonte = Color.DarkGreen;
                    break;
                case 8:
                    _cor_status_fonte = Color.Blue;
                    break;
                case 38:
                    _cor_status_fonte = Color.Yellow;
                    _cor_status_fundo = Color.Red;
                    break;
                default:
                    _cor_status_fonte = Color.Black;
                    _cor_status_fundo = Color.White;
                    break;
            }
            ExtratoDataGrid.Rows[Index].Cells["status"].Style.ForeColor = _cor_status_fonte;
            ExtratoDataGrid.Rows[Index].Cells["status"].Style.BackColor = _cor_status_fundo;
        }

        private bool Line_isVisible(int Index) {
            bool bRet = true;
            DataGridViewRow Linha = ExtratoDataGrid.Rows[Index];
            int nAno = Convert.ToInt32(Linha.Cells["Ano"].Value);
            int nLanc = Convert.ToInt32(Linha.Cells["lancamento"].Value.ToString().Substring(0, 2));
            int nParc = Convert.ToInt32(Linha.Cells["parcela"].Value.ToString().Substring(0, 2));
            int nStatus = Convert.ToInt32(Linha.Cells["status"].Value.ToString().Substring(0, 2));
            DateTime Vencimento = Convert.ToDateTime(Linha.Cells["data_vencimento"].Value.ToString());
            string sDA = Linha.Cells["DA"].Value.ToString();
            string sAJ = Linha.Cells["AJ"].Value.ToString();

            if (!bFiltroAtivo) {
                if (nStatus == 3 || nStatus == 42 || nStatus == 43 || nStatus == 19 || nStatus == 20 || nStatus == 25)
                    return true;
            }

            if (!ChkAllExercicio.Checked) {
                if (nAno > _filtro_exercicio_fim) {
                    return false;
                }
                if (nAno < _filtro_exercicio_inicio) {

                    return false;
                }
            }

            if (!ChkParcelaOculta.Checked) {
                if (nStatus == 5 || (nStatus == 1 && nParc > 0))
                    return false;
            }

            foreach (GtiTypes.CustomListBoxItem2 item in Lista_Lancamento) {
                if (nLanc == item._value) {
                    if (item._ativo == false)
                        return false;
                }
            }

            foreach (GtiTypes.CustomListBoxItem2 item in Lista_Status) {
                if (nStatus == item._value) {
                    if (item._ativo == false)
                        return false;
                }
            }


            if (CmbDivAtiva.SelectedIndex == 1) {
                if (sDA == "N")
                    return false;
            } else if (CmbDivAtiva.SelectedIndex == 2) {
                if (sDA == "S")
                    return false;
            }

            if (CmbAjuizado.SelectedIndex == 1) {
                if (sAJ == "N")
                    return false;
            } else if (CmbAjuizado.SelectedIndex == 2) {
                if (sAJ == "S")
                    return false;
            }

            return bRet;
        }

        private int GetFirstVisibleRow() {
            int index = -1;
            foreach (DataGridViewRow Linha in ExtratoDataGrid.Rows) {
                if (Linha.Visible) {
                    index = Linha.Index;
                    break;
                }
            }
            return index;
        }

        private void Atualiza_Total() {
            decimal _valorNaoPagoTotal = 0, _valorNaoPagoVencido = 0, _valorSelecionado = 0;
            foreach (DataGridViewRow linha in ExtratoDataGrid.Rows) {
                if (linha.Visible) {
                    int _status = Convert.ToInt32(linha.Cells["status"].Value.ToString().Substring(0, 2));
                    DateTime _data_vencto = Convert.ToDateTime(linha.Cells["data_vencimento"].Value);
                    decimal _valor_atual = Convert.ToDecimal(linha.Cells["valor_atual"].Value);

                    if (_status == 3|_status==42|_status==43) {
                        _valorNaoPagoTotal += _valor_atual;
                        if (_data_vencto < DateTime.Now) {
                            _valorNaoPagoVencido += _valor_atual;
                        }
                    }
                    if (linha.Tag.ToString() == "1")
                        _valorSelecionado += _valor_atual;
                }
            }
            lblTotalNPago.Text = _valorNaoPagoTotal.ToString("#0.00");
            lblTotalVenc.Text = _valorNaoPagoVencido.ToString("#0.00");
            lblTotalSel.Text = _valorSelecionado.ToString("#0.00");
        }

        private void LockScreen(bool bLock) {
            MainMenu.Enabled = !bLock; ;
            FiltroPanel.Visible = false;
            CodigoText.ReadOnly = bLock;
            ExtratoDataGrid.Enabled = !bLock;
            ConsultarCodigoButton.Enabled = !bLock;
            RefreshButton.Enabled = !bLock;
        }

        private void ExtratoDataGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            //Skip the Column and Row headers
            if (e.ColumnIndex < 0 || e.RowIndex < 0) {
                return;
            }
            var dataGridView = (sender as DataGridView);
            //Check the condition as per the requirement casting the cell value to the appropriate type
            if (e.ColumnIndex == 0)
                dataGridView.Cursor = Cursors.Hand;
            else
                dataGridView.Cursor = Cursors.Default;
        }

        private void ExtratoDataGrid_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 0 && e.RowIndex > 0) {
                DataGridViewRow linha = ExtratoDataGrid.SelectedRows[0];
                short Ano = Convert.ToInt16(linha.Cells["ano"].Value);
                short Lanc = Convert.ToInt16(linha.Cells["lancamento"].Value.ToString().Substring(0, 2));
                short Seq = Convert.ToInt16(linha.Cells["sequencia"].Value);
                short Parc = Convert.ToInt16(linha.Cells["parcela"].Value);
                byte Compl = Convert.ToByte(linha.Cells["complemento"].Value);

                ExibeObservacao(false, Ano, Lanc, Seq, Parc, Compl);
            }
        }

        private void ExtratoDataGrid_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                mnuMain.Show(ExtratoDataGrid, ExtratoDataGrid.PointToClient(Cursor.Position));
            }
        }

        private void Extrato_FormClosing(object sender, FormClosingEventArgs e) {
            Properties.Settings.Default.Form_Extrato_width = this.Size.Width;
            Properties.Settings.Default.Form_Extrato_height = this.Size.Height;
            Properties.Settings.Default.Save();
        }

        private void BtDetalhe_Click(object sender, EventArgs e) {
            Detalhe_Parcela();
        }

        private void BtSelectLancamento_Click(object sender, EventArgs e) {
            Forms.SelectForm f1 = new Forms.SelectForm(Lista_Lancamento);
            f1.ShowDialog();
            Lista_Lancamento = f1.Lista_Retorno;
        }

        private void BtSelectStatus_Click(object sender, EventArgs e) {
            Forms.SelectForm f1 = new Forms.SelectForm(Lista_Status);
            f1.ShowDialog();
            Lista_Status = f1.Lista_Retorno;
        }

        private void BTOcultar_Click(object sender, EventArgs e) {
            FiltroPanel.Visible = false;
        }

        private void MnuEditaDebito_Click(object sender, EventArgs e) {
            if (ExtratoDataGrid.SelectedRows.Count > 0) {
                DataGridViewRow linha = ExtratoDataGrid.SelectedRows[0];
                List<SpExtrato> Lista = new List<SpExtrato>();
                foreach (SpExtrato reg in Lista_Extrato_Tributo) {
                    if (reg.Anoexercicio == Convert.ToInt16(linha.Cells["ano"].Value) &&
                        reg.Codlancamento == Convert.ToInt16(linha.Cells["lancamento"].Value.ToString().Substring(0, 2)) &&
                        reg.Seqlancamento == Convert.ToInt16(linha.Cells["sequencia"].Value) &&
                        reg.Numparcela == Convert.ToInt16(linha.Cells["parcela"].Value) &&
                        reg.Codcomplemento == Convert.ToByte(linha.Cells["complemento"].Value)) {
                        Lista.Add(reg);
                    }
                }
                Parcela_Edit frm = new Parcela_Edit(Lista);
                frm.ShowDialog(this);
            } else
                MessageBox.Show("Selecione uma parcela.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void DetalheLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Detalhe_Parcela();
        }

        private void BtFiltro_Click(object sender, EventArgs e) {
            if (CmbAnoInicial.Items.Count == 0)
                return;
            _filtro_exercicio_inicio = Convert.ToInt16(CmbAnoInicial.Text);
            _filtro_exercicio_fim = Convert.ToInt16(CmbAnoFinal.Text);

            if (_filtro_exercicio_inicio > _filtro_exercicio_fim)
                MessageBox.Show("Ano inicial não pode ser maior que o ano final.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                bFiltroAtivo = true;
                Exibe_Extrato();
            }
        }

        private void ChkAllExercicio_CheckedChanged(object sender, EventArgs e) {
            if (ChkAllExercicio.Checked) {
                CmbAnoInicial.SelectedIndex = 0;
                CmbAnoFinal.SelectedIndex = CmbAnoFinal.Items.Count - 1;
                CmbAnoInicial.Enabled = false;
                CmbAnoFinal.Enabled = false;
            } else {
                CmbAnoInicial.Enabled = true;
                CmbAnoFinal.Enabled = true;
            }
        }

        private bool Parcela_Tem_Observacao(short Ano, short Lancamento, short Sequencia, short Parcela, byte Complemento) {
            bool bRet = false;
            foreach (ObsparcelaStruct item in Lista_Observacao) {
                if (item.Anoexercicio == Ano && item.Codlancamento == Lancamento && item.Seqlancamento == Sequencia && item.Numparcela == Parcela && item.Codcomplemento == Complemento) {
                    bRet = true;
                    break;
                }
            }
            return bRet;
        }

        private void ExibeObservacao(bool Geral, int Ano = 0, short Lancamento = 0, short Sequencia = 0, short Parcela = 0, byte Complemento = 0) {
            ObservacaoText.Text = "";
            ObservacaoListView.Items.Clear();
            LockScreen(true);
            int nCodigo = Convert.ToInt32(CodigoText.Text);
            if (Geral) {
                bObsGeral = true;
                TituloObsLabel.Text = "Observação Geral";
                Tributario_bll clsTributario = new Tributario_bll(_connection);
                List<GTI_Models.Models.DebitoobservacaoStruct> Lista = clsTributario.Lista_Observacao_Codigo(nCodigo);
                foreach (DebitoobservacaoStruct item in Lista) {
                    ListViewItem lvItem = new ListViewItem(item.Seq.ToString("000"));
                    lvItem.SubItems.Add(Convert.ToDateTime(item.Dataobs).ToString("dd/MM/yyyy"));
                    lvItem.SubItems.Add(item.NomeLogin);
                    lvItem.SubItems.Add(item.Obs);
                    ObservacaoListView.Items.Add(lvItem);
                }
            } else {
                bObsGeral = false;
                TituloObsLabel.Text = "Observação da Parcela Ano: " + Ano.ToString() + "  Lc: " + Lancamento.ToString() + "  Sq: " + Sequencia.ToString() + "  Pc: " + Parcela.ToString() + "  Cp:" + Complemento.ToString();
                foreach (ObsparcelaStruct item in Lista_Observacao) {
                    if (item.Anoexercicio == Ano && item.Codlancamento == Lancamento && item.Seqlancamento == Sequencia && item.Numparcela == Parcela && item.Codcomplemento == Complemento) {
                        ListViewItem lvItem = new ListViewItem(item.Seq.ToString("000"));
                        lvItem.SubItems.Add(Convert.ToDateTime(item.Data).ToString("dd/MM/yyyy"));
                        lvItem.SubItems.Add(item.NomeLogin);
                        lvItem.SubItems.Add(item.Obs);
                        ObservacaoListView.Items.Add(lvItem);
                    }
                }
            }
            if (ObservacaoListView.Items.Count > 0)
                ObservacaoListView.Items[0].Selected = true;
            ObservacaoPanel.Visible = true;
            ObservacaoPanel.BringToFront();
            ObservacaoControlBehaviour(true);
        }

        private void SairObsButton_Click(object sender, EventArgs e) {
            AtualizaObservacao();
        }

        private void ObservacaoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (ExtratoDataGrid.SelectedRows.Count > 0) {
                ExibeObservacao(true);
            } else
                MessageBox.Show("Selecione um contribuinte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void ObservacaoListView_SelectedIndexChanged(object sender, EventArgs e) {
            ObservacaoText.Text = "";
            if (ObservacaoListView.SelectedItems.Count > 0) {
                ObservacaoText.Text = ObservacaoListView.SelectedItems[0].SubItems[3].Text;
            }
        }

        private void AtualizaObservacao() {
            ObservacaoPanel.Visible = false;
            LockScreen(false);
        }

        private void NovaObsButton_Click(object sender, EventArgs e) {
            bAddNew = true;
            ObservacaoText.Text = "";
            ObservacaoControlBehaviour(false);
        }

        private void AlterarObsButton_Click(object sender, EventArgs e) {
            if (ObservacaoListView.SelectedItems.Count == 0) {
                MessageBox.Show("Selecione a observação que deseja alterar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                string sUser = ObservacaoListView.SelectedItems[0].SubItems[2].Text;
                if (sUser != Properties.Settings.Default.LastUser)
                    MessageBox.Show("Você só pode alterar as observações criadas por você.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    bAddNew = false;
                    ObservacaoControlBehaviour(false);
                }
            }
        }

        private void CancelarObsButton_Click(object sender, EventArgs e) {
            ObservacaoControlBehaviour(true);
        }

        private void GravarObsButton_Click(object sender, EventArgs e) {
            if (ObservacaoText.Text.Trim() == "")
                MessageBox.Show("Digite uma observação!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                Tributario_bll clsTributario = new Tributario_bll(_connection);
                Exception ex;
                int nCodigo = Convert.ToInt32(CodigoText.Text);
                //Observação Geral
                if (bObsGeral) {
                    Debitoobservacao reg = new Debitoobservacao {
                        Codreduzido = nCodigo
                    };
                    reg.Obs = ObservacaoText.Text.Trim();
                    reg.Dataobs = DateTime.Now;
                    Sistema_bll sistema_Class = new Sistema_bll(_connection);
                    reg.Userid = sistema_Class.Retorna_User_LoginId( Properties.Settings.Default.LastUser);
                    //Nova Observação Geral
                    if (bAddNew) {
                        ex = clsTributario.Insert_Observacao_Codigo(reg);
                        if (ex != null) {
                            ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                            eBox.ShowDialog();
                        } else {
                            short nSeq = clsTributario.Retorna_Ultima_Seq_Observacao_Codigo(reg.Codreduzido);
                            ListViewItem lvItem = new ListViewItem(nSeq.ToString("000"));
                            lvItem.SubItems.Add(DateTime.Now.ToString("dd/MM/yyyy"));
                            lvItem.SubItems.Add(Properties.Settings.Default.LastUser);
                            lvItem.SubItems.Add(ObservacaoText.Text);
                            ObservacaoListView.Items.Add(lvItem);
                            ObservacaoControlBehaviour(true);
                            if (ObservacaoListView.SelectedItems.Count > 0) {
                                ObservacaoListView.SelectedItems[0].Focused = false;
                                ObservacaoListView.SelectedItems[0].Selected = false;
                            }
                            ObservacaoListView.Items[ObservacaoListView.Items.Count - 1].Selected = true;
                            ObservacaoListView.Select();
                        }
                    } else {
                        //Alterar Observação Geral
                        reg.Seq = Convert.ToInt16(ObservacaoListView.SelectedItems[0].Text);
                        ex = clsTributario.Alterar_Observacao_Codigo(reg);
                        if (ex != null) {
                            ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                            eBox.ShowDialog();
                        } else {
                            //atualiza ListView
                            ObservacaoListView.SelectedItems[0].SubItems[1].Text = DateTime.Now.ToString("dd/MM/yyyy");
                            ObservacaoListView.SelectedItems[0].SubItems[2].Text = Properties.Settings.Default.LastUser;
                            ObservacaoListView.SelectedItems[0].SubItems[3].Text = ObservacaoText.Text.Trim();
                            ObservacaoControlBehaviour(true);
                        }
                    }
                } else {
                    //Obsevação da parcela
                    Obsparcela reg = new Obsparcela {
                        Codreduzido = nCodigo
                    };
                    DataGridViewRow linha = ExtratoDataGrid.SelectedRows[0];
                    reg.Anoexercicio = Convert.ToInt16(linha.Cells["ano"].Value);
                    reg.Codlancamento = Convert.ToInt16(linha.Cells["lancamento"].Value.ToString().Substring(0, 2));
                    reg.Seqlancamento = Convert.ToInt16(linha.Cells["sequencia"].Value);
                    reg.Numparcela = Convert.ToByte(linha.Cells["parcela"].Value);
                    reg.Codcomplemento = Convert.ToByte(linha.Cells["complemento"].Value);
                    reg.Obs = ObservacaoText.Text.Trim();
                    reg.Data = DateTime.Now;
                    Sistema_bll sistema_Class = new Sistema_bll(_connection);
                    reg.Userid = sistema_Class.Retorna_User_LoginId( Properties.Settings.Default.LastUser);
                    //Nova observação da parcela
                    if (bAddNew) {
                        ex = clsTributario.Insert_Observacao_Parcela(reg);
                        if (ex != null) {
                            ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                            eBox.ShowDialog();
                        } else {
                            short nSeq = clsTributario.Retorna_Ultima_Seq_Observacao_Parcela(reg.Codreduzido, reg.Anoexercicio, reg.Codlancamento, reg.Seqlancamento, reg.Numparcela, reg.Codcomplemento);
                            ListViewItem lvItem = new ListViewItem(nSeq.ToString("000"));
                            lvItem.SubItems.Add(DateTime.Now.ToString("dd/MM/yyyy"));
                            lvItem.SubItems.Add(Properties.Settings.Default.LastUser);
                            lvItem.SubItems.Add(ObservacaoText.Text);
                            ObservacaoListView.Items.Add(lvItem);
                            ObservacaoControlBehaviour(true);
                            if (ObservacaoListView.SelectedItems.Count > 0) {
                                ObservacaoListView.SelectedItems[0].Focused = false;
                                ObservacaoListView.SelectedItems[0].Selected = false;
                            }
                            ObservacaoListView.Items[ObservacaoListView.Items.Count - 1].Selected = true;
                            ObservacaoListView.Select();
                            //atualiza lista de observação
                            ObsparcelaStruct itemObs = new ObsparcelaStruct {
                                Codreduzido = reg.Codreduzido,
                                Anoexercicio = reg.Anoexercicio,
                                Codlancamento = reg.Codlancamento,
                                Seqlancamento = reg.Seqlancamento,
                                Numparcela = reg.Numparcela,
                                Codcomplemento = reg.Codcomplemento,
                                Seq = nSeq,
                                Data = reg.Data,
                                Userid = reg.Userid,
                                Obs = reg.Obs
                            };
                            Lista_Observacao.Add(itemObs);
                            //atualiza icone no datagridview
                            ExtratoDataGrid.SelectedRows[0].Cells[0].Value = Properties.Resources.write;
                        }
                    } else {
                        //Alterar observação da parcela
                        reg.Seq = Convert.ToInt16(ObservacaoListView.SelectedItems[0].Text);
                        ex = clsTributario.Alterar_Observacao_Parcela(reg);
                        if (ex != null) {
                            ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                            eBox.ShowDialog();
                        } else {
                            ObservacaoControlBehaviour(true);
                            //atualiza ListView
                            ObservacaoListView.SelectedItems[0].SubItems[1].Text = DateTime.Now.ToString("dd/MM/yyyy");
                            ObservacaoListView.SelectedItems[0].SubItems[2].Text = Properties.Settings.Default.LastUser;
                            ObservacaoListView.SelectedItems[0].SubItems[3].Text = ObservacaoText.Text.Trim();
                            //atualiza lista de observação
                            for (int i = 0; i < Lista_Observacao.Count; i++) {
                                if (Lista_Observacao[i].Anoexercicio == reg.Anoexercicio && Lista_Observacao[i].Codlancamento == reg.Codlancamento && Lista_Observacao[i].Seqlancamento == reg.Seqlancamento &&
                                    Lista_Observacao[i].Numparcela == reg.Numparcela && Lista_Observacao[i].Codcomplemento == reg.Codcomplemento && Lista_Observacao[i].Seq == reg.Seq) {
                                    Lista_Observacao[i].Data = reg.Data;
                                    Lista_Observacao[i].Obs = reg.Obs;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ZoomButton_Click(object sender, EventArgs e) {
            ZoomBox f1 = new ZoomBox(this.Text, this, ObservacaoText.Text, !GravarObsButton.Enabled);
            f1.ShowDialog();
            ObservacaoText.Text = f1.ReturnText;
        }

        private void ExcluirObsButton_Click(object sender, EventArgs e) {
            if (ObservacaoListView.SelectedItems.Count == 0) {
                MessageBox.Show("Selecione a observação que deseja excluir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                if (MessageBox.Show("Excluir esta observação?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    string sUser = ObservacaoListView.SelectedItems[0].SubItems[2].Text;
                    if (sUser != Properties.Settings.Default.LastUser)
                        MessageBox.Show("Você só pode excluir as observações criadas por você.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        Tributario_bll clsTributario = new Tributario_bll(_connection);
                        int nCodigo = Convert.ToInt32(CodigoText.Text);
                        short nSeq = Convert.ToInt16(ObservacaoListView.SelectedItems[0].Text);
                        if (bObsGeral) {
                            Exception ex = clsTributario.Excluir_Observacao_Codigo(nCodigo, nSeq);
                            if (ex == null) {
                                ObservacaoListView.SelectedItems[0].Remove();
                                if (ObservacaoListView.SelectedItems.Count > 0) {
                                    ObservacaoListView.SelectedItems[0].Focused = false;
                                    ObservacaoListView.SelectedItems[0].Selected = false;
                                    ObservacaoListView.Items[0].Selected = true;
                                    ObservacaoListView.Select();
                                }
                            } else {
                                ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                                eBox.ShowDialog();
                            }
                        } else {
                            DataGridViewRow linha = ExtratoDataGrid.SelectedRows[0];
                            Obsparcela itemObs = new Obsparcela {
                                Codreduzido = nCodigo,
                                Anoexercicio = Convert.ToInt16(linha.Cells["ano"].Value),
                                Codlancamento = Convert.ToInt16(linha.Cells["lancamento"].Value.ToString().Substring(0, 2)),
                                Seqlancamento = Convert.ToInt16(linha.Cells["sequencia"].Value),
                                Numparcela = Convert.ToByte(linha.Cells["parcela"].Value),
                                Codcomplemento = Convert.ToByte(linha.Cells["complemento"].Value),
                                Seq = nSeq
                            };
                            Exception ex = clsTributario.Excluir_Observacao_Parcela(itemObs);
                            if (ex == null) {
                                ObservacaoListView.SelectedItems[0].Remove();
                                if (ObservacaoListView.SelectedItems.Count > 0) {
                                    ObservacaoListView.SelectedItems[0].Focused = false;
                                    ObservacaoListView.SelectedItems[0].Selected = false;
                                    ObservacaoListView.Items[0].Selected = true;
                                    ObservacaoListView.Select();
                                }
//atualiza lista de observação
InicioObs:
                                for (int i = 0; i < Lista_Observacao.Count; i++) {
                                    if (Lista_Observacao[i].Anoexercicio == itemObs.Anoexercicio && Lista_Observacao[i].Codlancamento == itemObs.Codlancamento && Lista_Observacao[i].Seqlancamento == itemObs.Seqlancamento &&
                                        Lista_Observacao[i].Numparcela == itemObs.Numparcela && Lista_Observacao[i].Codcomplemento == itemObs.Codcomplemento && Lista_Observacao[i].Seq == itemObs.Seq) {
                                        Lista_Observacao.RemoveAt(i);
                                        goto InicioObs;
                                    }
                                }
                            } else {
                                ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                                eBox.ShowDialog();
                            }
                            if (ObservacaoListView.Items.Count == 0) {
                                //atualiza icone no datagridview
                                ExtratoDataGrid.SelectedRows[0].Cells[0].Value = new Bitmap(1, 1);
                            }
                        }
                    }
                }
            }
        }

        private void ObservacaoControlBehaviour(bool bStart) {
            Color color_enable = Color.White, color_disable = this.BackColor;
            AlterarObsButton.Enabled = bStart;
            NovaObsButton.Enabled = bStart;
            ExcluirObsButton.Enabled = bStart;
            SairObsButton.Enabled = bStart;
            GravarObsButton.Enabled = !bStart;
            CancelarObsButton.Enabled = !bStart;
            ObservacaoListView.Enabled = bStart;
            ObservacaoText.ReadOnly = bStart;
        }

        private void DocumentoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (ExtratoDataGrid.SelectedRows.Count > 0) {
                Tributario_bll TributarioClass = new Tributario_bll(_connection);
                DocumentoListView.Items.Clear();
                Parceladocumento reg = new Parceladocumento();
                DataGridViewRow linha = ExtratoDataGrid.SelectedRows[0];
                reg.Codreduzido = Convert.ToInt32(CodigoText.Text);
                reg.Anoexercicio = Convert.ToInt16(linha.Cells["ano"].Value);
                reg.Codlancamento = Convert.ToInt16(linha.Cells["lancamento"].Value.ToString().Substring(0, 2));
                reg.Seqlancamento = Convert.ToInt16(linha.Cells["sequencia"].Value);
                reg.Numparcela = Convert.ToByte(linha.Cells["parcela"].Value);
                reg.Codcomplemento = Convert.ToByte(linha.Cells["complemento"].Value);
                List<Numdocumento> Lista = TributarioClass.Lista_Parcela_Documentos(reg);
                foreach (Numdocumento item in Lista) {
                    ListViewItem lvItem = new ListViewItem(item.numdocumento.ToString("00000000"));
                    lvItem.SubItems.Add(Convert.ToDateTime(item.Datadocumento).ToString("dd/MM/yyyy"));
                    lvItem.SubItems.Add(Convert.ToDecimal(item.Valorguia).ToString("#0.00"));
                    DocumentoListView.Items.Add(lvItem);
                }

                LockScreen(true);
                DocumentoPanel.Visible = true;
                DocumentoPanel.BringToFront();
            } else
                MessageBox.Show("Selecione uma parcela.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FiltroMenu_Click(object sender, EventArgs e) {
            //if (ExtratoDataGrid.Rows.Count == 0)
            //    MessageBox.Show("Filtro indisponível!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //else {
                if (FiltroPanel.Visible)
                    FiltroPanel.Visible = false;
                else {
                    FiltroPanel.Visible = true;
                    FiltroPanel.BringToFront();
                }
           // }
        }

        private void Detalhemenu_Click(object sender, EventArgs e) {
            Detalhe_Parcela();
        }

        private void ExtratoMenu_Click(object sender, EventArgs e) {

        }

        private void DocumentoMenu_Click(object sender, EventArgs e) {
            if (ExtratoDataGrid.SelectedRows.Count > 0) {
                Tributario_bll TributarioClass = new Tributario_bll(_connection);
                DocumentoListView.Items.Clear();
                Parceladocumento reg = new Parceladocumento();
                DataGridViewRow linha = ExtratoDataGrid.SelectedRows[0];
                reg.Codreduzido = Convert.ToInt32(CodigoText.Text);
                reg.Anoexercicio = Convert.ToInt16(linha.Cells["ano"].Value);
                reg.Codlancamento = Convert.ToInt16(linha.Cells["lancamento"].Value.ToString().Substring(0, 2));
                reg.Seqlancamento = Convert.ToInt16(linha.Cells["sequencia"].Value);
                reg.Numparcela = Convert.ToByte(linha.Cells["parcela"].Value);
                reg.Codcomplemento = Convert.ToByte(linha.Cells["complemento"].Value);
                List<Numdocumento> Lista = TributarioClass.Lista_Parcela_Documentos(reg);
                foreach (Numdocumento item in Lista) {
                    ListViewItem lvItem = new ListViewItem(item.numdocumento.ToString("00000000"));
                    lvItem.SubItems.Add(Convert.ToDateTime(item.Datadocumento).ToString("dd/MM/yyyy"));
                    lvItem.SubItems.Add(Convert.ToDecimal(item.Valorguia).ToString("#0.00"));
                    DocumentoListView.Items.Add(lvItem);
                }

                LockScreen(true);
                DocumentoPanel.Visible = true;
                DocumentoPanel.BringToFront();
            } else
                MessageBox.Show("Selecione uma parcela.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ParcelamentoMenu_Click(object sender, EventArgs e) {
            if (ExtratoDataGrid.SelectedRows.Count > 0) {
                Processo_bll processo_Class = new Processo_bll(_connection);
                List<Processo_Numero> Lista = processo_Class.Lista_Processo_Parcelamento_Header(Convert.ToInt32(CodigoText.Text));
                if (Lista.Count > 0) {
                    int _pos = 0;
                    foreach (Processo_Numero item in Lista) {
                        if (item.Numero == null) {//processos antigos que não separavam o numero do ano, teremos que separar manualmente.
                            Lista[_pos].Numero = processo_Class.ExtractNumeroProcessoNoDV(item.Numero_processo);
                            Lista[_pos].Ano = processo_Class.ExtractAnoProcesso(item.Numero_processo);
                        }
                        int _numero = Convert.ToInt32(Lista[_pos].Numero);
                        Lista[_pos].Numero_processo = _numero.ToString("00000") + "-" + processo_Class.DvProcesso(_numero) + "/" + Lista[_pos].Ano.ToString();
                        _pos++;
                    }
                    Parcelamento_Lista f1 = new Parcelamento_Lista(Lista);
                    f1.ShowDialog();
                }else
                    MessageBox.Show("Esta inscrição não possui parcelamentos cadastrados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else
                MessageBox.Show("Selecione um contribuinte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void ObservacaoGeralMenu_Click(object sender, EventArgs e) {
            if (ExtratoDataGrid.SelectedRows.Count > 0) {
                ExibeObservacao(true);
            } else
                MessageBox.Show("Selecione um contribuinte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void ConsultarCodigoButton_Click(object sender, EventArgs e) {
            HeaderMenu.Show(ConsultarCodigoButton,  new System.Drawing.Point(0, 20));
        }

        private void OutrosMenu_Click(object sender, EventArgs e) {

        }

        private void ImovelMenuItem_Click(object sender, EventArgs e) {
            using (var form = new Imovel_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    int val = form.ReturnValue;
                    CodigoText.Text = val.ToString();
                    ClearAll(true);
                    GeraExtrato();
                    Exibe_Extrato();
                }
            }
        }

        private void EmpresaMenuItem_Click(object sender, EventArgs e) {
            using (var form = new Empresa_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    int val = form.ReturnValue;
                    CodigoText.Text = val.ToString();
                    ClearAll(true);
                    GeraExtrato();
                }
            }
        }

        private void CidadaoMenuItem_Click(object sender, EventArgs e) {
            using (var form = new Cidadao_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    int val = form.ReturnValue;
                    CodigoText.Text = val.ToString();
                    ClearAll(true);
                    GeraExtrato();
                }
            }
        }

        private void ExecFiscalMenu_Click(object sender, EventArgs e) {
            //TODO Rotina de Execução Fiscal
        }

        private void ObservacaoParcelaMenu_Click(object sender, EventArgs e) {
            if (ExtratoDataGrid.SelectedRows.Count > 0) {
                DataGridViewRow linha = ExtratoDataGrid.SelectedRows[0];
                int _ano = Convert.ToInt16(linha.Cells["ano"].Value);
                short _lancamento= Convert.ToInt16(linha.Cells["lancamento"].Value.ToString().Substring(0, 2));
                short _seq = Convert.ToInt16(linha.Cells["sequencia"].Value);
                short _parcela = Convert.ToInt16(linha.Cells["parcela"].Value);
                byte _complemento = Convert.ToByte(linha.Cells["complemento"].Value);
                ExibeObservacao(false,_ano,_lancamento,_seq,_parcela,_complemento);
            } else
                MessageBox.Show("Selecione uma parcela.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void DividaAtivaToolStripMenuItem_Click(object sender, EventArgs e) {
            bool _find = false;
            foreach (DataGridViewRow item in ExtratoDataGrid.Rows) {
                if (item.Tag.ToString() == "1") {
                    _find = true;
                    break;
                }
            }
            if (!_find)
                MessageBox.Show("Nenhum débito selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                List<SpExtrato> Lista = new List<SpExtrato>();

                foreach (DataGridViewRow item in ExtratoDataGrid.Rows) {
                    short _ano = Convert.ToInt16(item.Cells["Ano"].Value);
                    short _lanc = Convert.ToInt16(item.Cells["lancamento"].Value.ToString().Substring(0, 2));
                    short _seq = Convert.ToInt16(item.Cells["sequencia"].Value);
                    short _parc = Convert.ToInt16(item.Cells["parcela"].Value);
                    byte _compl = Convert.ToByte(item.Cells["complemento"].Value);

                    if (item.Tag.ToString() == "1") {
                        SpExtrato reg = new SpExtrato {
                            Codreduzido = Convert.ToInt32(CodigoText.Text),
                            Anoexercicio = _ano,
                            Desclancamento = item.Cells["lancamento"].Value.ToString(),
                            Seqlancamento = _seq,
                            Numparcela = _parc,
                            Codcomplemento = _compl,
                            Datavencimento = Convert.ToDateTime(item.Cells["data_vencimento"].Value),
                            Valortributo = Convert.ToDecimal(item.Cells["valor_lancado"].Value),
                            
                        };
                        if (item.Cells["DA"].Value.ToString() == "S")
                            reg.Datainscricao = DateTime.Now;
                        Lista.Add(reg);
                    }
                }
                string _codigo = CodigoText.Text;
                using (var form = new Divida_Ativa_Manual(Lista,Lista_Extrato_Tributo)) {
                    var result = form.ShowDialog(this);
                    if (result == DialogResult.OK) {
                        int val = form.ReturnValue;
                        CodigoText.Text = _codigo;
                        ClearAll(false);
                        GeraExtrato();
                    }
                }
            }

        }

        private void DamMenu_Click(object sender, EventArgs e) {
            bool _find = false;
            foreach (DataGridViewRow item in ExtratoDataGrid.Rows) {
                if (item.Tag.ToString() == "1") {
                    _find = true;
                    break;
                }
            }
            if (!_find)
                MessageBox.Show("Nenhum débito selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.DAM_Imprimir);
                if (bAllow) {
                    List<SpExtrato> Lista = new List<SpExtrato>();

                    foreach (DataGridViewRow item in ExtratoDataGrid.Rows) {
                        short _ano = Convert.ToInt16(item.Cells["Ano"].Value);
                        short _lanc = Convert.ToInt16(item.Cells["lancamento"].Value.ToString().Substring(0, 2));
                        short _seq = Convert.ToInt16(item.Cells["sequencia"].Value);
                        short _parc = Convert.ToInt16(item.Cells["parcela"].Value);
                        byte _compl = Convert.ToByte(item.Cells["complemento"].Value);

                        if (item.Tag.ToString() == "1") {
                            SpExtrato reg = new SpExtrato {
                                Codreduzido = Convert.ToInt32(CodigoText.Text),
                                Anoexercicio = _ano,
                                Codlancamento = _lanc,
                                Seqlancamento = _seq,
                                Numparcela = _parc,
                                Codcomplemento = _compl
                            };
                            Lista.Add(reg);
                        }
                    }
                    Dam frm = new Dam(Lista, Lista_Extrato_Tributo);
                    frm.ShowDialog();
                } else
                    MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PesquisarDocumentoButton_Click(object sender, EventArgs e) {
            if (DocumentoListView.SelectedItems.Count > 0) {
                int nNumDoc = Convert.ToInt32(DocumentoListView.SelectedItems[0].Text);
                Documento_Detalhe frmDetalhe = new Documento_Detalhe(nNumDoc);
                frmDetalhe.ShowDialog();
            } else
                MessageBox.Show("Selecione um documento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SairDocumentoButton_Click(object sender, EventArgs e) {
            DocumentoPanel.Visible = false;
            LockScreen(false);
        }

        private void CancelamentoDebitoMenu_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.Cancelamento_debito);
            if (!bAllow) {
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool _find = false;
            foreach (DataGridViewRow item in ExtratoDataGrid.Rows) {
                if (item.Tag.ToString() == "1") {
                    _find = true;
                    break;
                }
            }
            if (!_find)
                MessageBox.Show("Nenhum débito selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                List<SpExtrato> Lista = new List<SpExtrato>();

                foreach (DataGridViewRow item in ExtratoDataGrid.Rows) {
                    short _ano = Convert.ToInt16(item.Cells["Ano"].Value);
                    short _lanc = Convert.ToInt16(item.Cells["lancamento"].Value.ToString().Substring(0, 2));
                    short _seq = Convert.ToInt16(item.Cells["sequencia"].Value);
                    short _parc = Convert.ToInt16(item.Cells["parcela"].Value);
                    byte _compl = Convert.ToByte(item.Cells["complemento"].Value);

                    if (item.Tag.ToString() == "1") {
                        SpExtrato reg = new SpExtrato {
                            Codreduzido=Convert.ToInt32(CodigoText.Text),
                            Anoexercicio = _ano,
                            Desclancamento = item.Cells["lancamento"].Value.ToString(),
                            Seqlancamento = _seq,
                            Numparcela = _parc,
                            Codcomplemento = _compl,
                            Datavencimento = Convert.ToDateTime(item.Cells["data_vencimento"].Value),
                            Valortributo = Convert.ToDecimal(item.Cells["valor_lancado"].Value)
                        };
                        decimal _valor_juros = 0, _valor_multa = 0,_valor_correcao=0;
                        decimal _valor_total = Convert.ToDecimal(item.Cells["valor_lancado"].Value);
                        int _livro = 0, _pagina = 0;

                        foreach (SpExtrato spitem in Lista_Extrato_Tributo) {
                            if(spitem.Anoexercicio==_ano && spitem.Codlancamento==_lanc && spitem.Seqlancamento==_seq && spitem.Numparcela==_parc && spitem.Codcomplemento == _compl) {
                                _valor_juros += spitem.Valorjuros;
                                _valor_multa += spitem.Valormulta;
                                _valor_correcao += spitem.Valorcorrecao;
                                _livro = spitem.Numlivro==null?0:(int)spitem.Numlivro;
                                _pagina = spitem.Pagina==null?0:(int)spitem.Pagina;
                            }
                        }
                        _valor_total += _valor_juros + _valor_multa+_valor_correcao;
                        reg.Valorjuros = _valor_juros;
                        reg.Valormulta = _valor_multa;
                        reg.Valorcorrecao = _valor_correcao;
                        reg.Valortotal = _valor_total;
                        reg.Numlivro = _livro;
                        reg.Pagina = _pagina;
                        Lista.Add(reg);
                    }
                }
                string _codigo = CodigoText.Text;
                using (var form = new Extrato_Debito_Cancelar(Lista)) {
                    var result = form.ShowDialog(this);
                    if (result == DialogResult.OK) {
                        int val = form.ReturnValue;
                        CodigoText.Text = _codigo;
                        ClearAll(false);
                        GeraExtrato();
                    }
                }
            }
        }
    }//end class
}
