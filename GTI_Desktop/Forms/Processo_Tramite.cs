using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Desktop.Properties;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Processo_Tramite : Form {

        List<GtiTypes.CustomListBoxItem> lstButtonState;
        public int Ano_Processo { get; set; }
        public int Num_Processo { get; set; }
        private bool bFechado;
        private string _connection = gtiCore.Connection_Name();

        public Processo_Tramite(int AnoProcesso, int NumProcesso) {
            InitializeComponent();
            this.Size = new System.Drawing.Size(Properties.Settings.Default.Form_Processo_Tramite_width, Properties.Settings.Default.Form_Processo_Tramite_height);

            tBar.Renderer = new MySR();
            Ano_Processo = AnoProcesso;
            Num_Processo = NumProcesso;
            lstButtonState = new List<GtiTypes.CustomListBoxItem>();
            Processo_bll clsProcesso = new Processo_bll(_connection);
            ProcessoStruct Reg = clsProcesso.Dados_Processo(Ano_Processo, Num_Processo);
            List<Despacho> lstDespacho = clsProcesso.Lista_Despacho();
            List<Despacho> lstDespacho2 = clsProcesso.Lista_Despacho();
            cmbDespacho.DataSource = lstDespacho;
            cmbDespacho.DisplayMember = "descricao";
            cmbDespacho.ValueMember = "codigo";
            cmbDespacho2.DataSource = lstDespacho2;
            cmbDespacho2.DisplayMember = "descricao";
            cmbDespacho2.ValueMember = "codigo";

            Centrocusto tblCCusto = new Centrocusto();
            List<Centrocusto> lstCCusto = clsProcesso.Lista_Local(true,false);
            cmbCCusto.DataSource = lstCCusto;
            cmbCCusto.DisplayMember = "descricao";
            cmbCCusto.ValueMember = "codigo";

            lblNumProc.Text = NumProcesso.ToString() + "-" + Reg.Dv.ToString() + "/" + AnoProcesso.ToString();
            lblComplemento.Text = Reg.Assunto;
            lblComplemento.Tag = Reg.CodigoAssunto.ToString();
            lblRequerente.Text = Reg.NomeCidadao;
            Forms.Processo f3 = (Forms.Processo)Application.OpenForms["Processo"];
            lblSit.Text = f3.SituacaoLabel.Text;
            bFechado = lblSit.Text == "NORMAL" ? false : true;
            CarregaTramite();
        }

        private void CarregaTramite() {
            lvMain.Items.Clear();
            gtiCore.Ocupado(this);
            Processo_bll clsProcesso = new Processo_bll(_connection);
            List<TramiteStruct> Lista = clsProcesso.DadosTramite((short)Ano_Processo, Num_Processo, Convert.ToInt32(lblComplemento.Tag.ToString()));

            int nPos = 0;
            foreach (TramiteStruct Reg in Lista) {
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add(Reg.Seq.ToString("00"));
                lvi.SubItems.Add(Reg.CentroCustoCodigo.ToString());
                lvi.SubItems.Add(Reg.CentroCustoNome??"");
                lvi.SubItems.Add(Reg.DataEntrada??"");
                lvi.SubItems.Add(Reg.HoraEntrada??"");
                lvi.SubItems.Add(Reg.Usuario1??"");
                lvi.SubItems.Add(Reg.DespachoNome??"");
                lvi.SubItems.Add("0");
                lvi.SubItems.Add(Reg.DataEnvio??"");
                lvi.SubItems.Add(Reg.Usuario2??"");
                lvi.SubItems.Add(Reg.Obs??"");
                lvi.Tag = Reg.Obs??"";
                if (!string.IsNullOrEmpty(Reg.Obs)) lvi.ImageIndex = 0;
                lvMain.Items.Add(lvi);
                nPos++;
            }
            CalculoDias();
            gtiCore.Liberado(this);
        }

        private void LockForm(bool bLock) {
            tBar.Enabled = bLock;
            btAddLocal.Enabled = bLock;
            btRemoveLocal.Enabled = bLock;
            btUp.Enabled = bLock;
            btDown.Enabled = bLock;
            btEmprestimo.Enabled = bLock;
            btAlterar.Enabled = bLock;
            btObs.Enabled = bLock;
            btReceber.Enabled = bLock;
            btEnviar.Enabled = bLock;
        }

        private void GetButtonState() {
            lstButtonState.Clear();
            lstButtonState.Add(new GtiTypes.CustomListBoxItem("btAddLocal", btAddLocal.Enabled ? 1 : 0));
            lstButtonState.Add(new GtiTypes.CustomListBoxItem("btRemoveLocal", btRemoveLocal.Enabled ? 1 : 0));
            lstButtonState.Add(new GtiTypes.CustomListBoxItem("btUp", btUp.Enabled ? 1 : 0));
            lstButtonState.Add(new GtiTypes.CustomListBoxItem("btDown", btDown.Enabled ? 1 : 0));
            lstButtonState.Add(new GtiTypes.CustomListBoxItem("btEmprestimo", btEmprestimo.Enabled ? 1 : 0));
            lstButtonState.Add(new GtiTypes.CustomListBoxItem("btAlterar", btAlterar.Enabled ? 1 : 0));
            lstButtonState.Add(new GtiTypes.CustomListBoxItem("btObs", btObs.Enabled ? 1 : 0));
            lstButtonState.Add(new GtiTypes.CustomListBoxItem("btReceber", btReceber.Enabled ? 1 : 0));
            lstButtonState.Add(new GtiTypes.CustomListBoxItem("btEnviar", btEnviar.Enabled ? 1 : 0));
        }

        private void SetButtonState() {
            if (lstButtonState.Count == 0) return;
            GtiTypes.CustomListBoxItem r = lstButtonState.Find(item => item._name == "btAddLocal");
            btAddLocal.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btRemoveLocal");
            btRemoveLocal.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btUp");
            btUp.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btDown");
            btDown.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btEmprestimo");
            btEmprestimo.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btAlterar");
            btAlterar.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btObs");
            btObs.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btReceber");
            btReceber.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btEnviar");
            btEnviar.Enabled = Convert.ToBoolean(r._value);
        }

        private void ReorderList() {
            int nPos = 1;
            foreach (ListViewItem lvItem in lvMain.Items) {
                lvItem.SubItems[1].Text = nPos.ToString("00");
                nPos++;
            }
        }

        private void BtUp_Click(object sender, EventArgs e) {
            if (lvMain.SelectedItems[0].Index == 0)
                MessageBox.Show("Não é possível mover para cima o 1º local.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (String.IsNullOrEmpty(lvMain.SelectedItems[0].SubItems[4].Text)) {
                    if (String.IsNullOrEmpty(lvMain.Items[lvMain.SelectedItems[0].Index - 1].SubItems[4].Text)) {

                        ListViewItem lvOld = lvMain.SelectedItems[0];
                        int nInd = lvMain.SelectedItems[0].Index;
                        lvMain.Items.Remove(lvMain.SelectedItems[0]);
                        lvMain.Items.Insert(nInd - 1, lvOld);
                        lvMain.Items[nInd - 1].SubItems[1].Text = (nInd).ToString();
                        lvMain.Items[nInd].SubItems[1].Text = (nInd + 1).ToString();
                    } else
                        MessageBox.Show("Não é possível mover este local porque já houve recebimento de processo no local acima.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                    MessageBox.Show("Não é possível mover este local porque já houve recebimento de processo no mesmo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtDown_Click(object sender, EventArgs e) {
            Processo clsProc = new Processo();
            if (lvMain.SelectedItems[0].Index == lvMain.Items.Count - 1)
                MessageBox.Show("Não é possível mover para baixo o último local.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (String.IsNullOrEmpty(lvMain.SelectedItems[0].SubItems[4].Text)) {
                    if (String.IsNullOrEmpty(lvMain.Items[lvMain.SelectedItems[0].Index + 1].SubItems[4].Text)) {
                        ListViewItem lvOld = lvMain.SelectedItems[0];
                        int nInd = lvMain.SelectedItems[0].Index;
                        lvMain.Items.Remove(lvMain.SelectedItems[0]);
                        lvMain.Items.Insert(nInd + 1, lvOld);
                        lvMain.Items[nInd + 1].SubItems[1].Text = (nInd + 2).ToString();
                        lvMain.Items[nInd].SubItems[1].Text = (nInd + 1).ToString();
                    } else
                        MessageBox.Show("Não é possível mover este local porque já houve recebimento de processo no local abaixo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                    MessageBox.Show("Não é possível mover este local porque já houve recebimento de processo no mesmo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Processo_Tramite_FormClosing(object sender, FormClosingEventArgs e) {
            gtiCore.Ocupado(this);
            List<TramiteStruct> Lista = new List<TramiteStruct>();
            foreach (ListViewItem lvItem in lvMain.Items) {
                TramiteStruct Reg = new TramiteStruct {
                    Ano = Ano_Processo,
                    Numero = Num_Processo,
                    Seq = Convert.ToInt32(lvItem.SubItems[1].Text),
                    CentroCustoCodigo = Convert.ToInt16(lvItem.SubItems[2].Text)
                };
                Lista.Add(Reg);
            }
            Processo_bll clsProc = new Processo_bll(_connection);
            clsProc.Incluir_MovimentoCC((short)Ano_Processo, Num_Processo, Lista);
            gtiCore.Liberado(this);
            Properties.Settings.Default.Form_Processo_Tramite_width = Size.Width;
            Properties.Settings.Default.Form_Processo_Tramite_height = Size.Height;
            Properties.Settings.Default.Save();

        }

        private void BtAddLocal_Click(object sender, EventArgs e) {
            if (lvMain.SelectedItems.Count == 0) {
                MessageBox.Show("Selecione a posição na lista que deseja inserir.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (bFechado) {
                MessageBox.Show("O processo não está aberto.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else {
                if (lvMain.Items.Count == 1)
                    goto Adicionar;

                if (lvMain.Items.Count - 1 == lvMain.SelectedItems[0].Index)
                    goto Adicionar;

                if (String.IsNullOrEmpty(lvMain.Items[lvMain.SelectedItems[0].Index + 1].SubItems[4].Text))
                    goto Adicionar;
            }

            MessageBox.Show("Não é possível inserir neste local porque já houve recebimento de processo no local abaixo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;

Adicionar:;
            GetButtonState();
            LockForm(false);
            lvMain.Enabled = false;
            pnlLocal.Visible = true;
            pnlLocal.BringToFront();
        }

        private void BtRemoveLocal_Click(object sender, EventArgs e) {
            if (lvMain.SelectedItems.Count == 0) {
                MessageBox.Show("Selecione a posição na lista que deseja remover.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (bFechado)
                MessageBox.Show("O processo não está aberto.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {

                int nIndex;
                nIndex = lvMain.SelectedItems[0].Index;

                if (String.IsNullOrEmpty(lvMain.Items[nIndex].SubItems[4].Text)) {
                    lvMain.Items.RemoveAt(lvMain.SelectedItems[0].Index);
                    ReorderList();
                } else
                    MessageBox.Show("Não é possível remover este local porque já houve recebimento neste local.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtCancelLocal_Click(object sender, EventArgs e) {
            LockForm(true);
            SetButtonState();
            pnlLocal.Hide();
            lvMain.Enabled = true;
        }

        private void BtOkLocal_Click(object sender, EventArgs e) {
            ListViewItem lvItem = new ListViewItem();
            lvItem.SubItems.Add("00");
            lvItem.SubItems.Add(cmbCCusto.SelectedValue.ToString());
            lvItem.SubItems.Add(cmbCCusto.Text);
            lvItem.SubItems.Add("");
            lvItem.SubItems.Add("");
            lvItem.SubItems.Add("");
            lvItem.SubItems.Add("");
            lvItem.SubItems.Add("");
            lvItem.SubItems.Add("");
            lvItem.SubItems.Add("");
            lvItem.SubItems.Add("");
            if (lvMain.Items.Count == 1 || lvMain.Items.Count - 1 == lvMain.SelectedItems[0].Index)
                lvMain.Items.Add(lvItem);
            else
                lvMain.Items.Insert(lvMain.SelectedItems[0].Index + 1, lvItem);
            ReorderList();
            LockForm(true);
            SetButtonState();
            pnlLocal.Hide();
            lvMain.Enabled = true;
        }

        private void BtSair_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void CalculoDias() {
            TimeSpan t;
            double NumDias = 0;
            DateTime Data1;
            DateTime Data2;

            foreach (ListViewItem lvItem in lvMain.Items) {
                if (lvItem.Index == 0) {//Se for a primeira linha
                    if (lvItem.SubItems[4].Text != "") {//Se tiver Data de Entrada 
                        if (lvItem.SubItems[9].Text != "") {//Se tiver data de envio
                            Data1 = DateTime.Parse(lvItem.SubItems[4].Text);
                            Data2 = DateTime.Parse(lvItem.SubItems[9].Text);
                            t = (Data2 - Data1);
                            NumDias = t.TotalDays;
                        } else {//Não tem data de envio
                            Data1 = DateTime.Parse(lvItem.SubItems[4].Text);
                            Data2 = DateTime.Now;
                            t = (Data2 - Data1);
                            NumDias = t.TotalDays;
                        }
                    } else {//Não tem data de entrada
                        NumDias = 0;
                    }
                } else {//Se não for a primeira linha
                        //Data de Entrada será a data de envio da linha anterior 
                    if (lvMain.Items[lvItem.Index - 1].SubItems[9].Text != "") {
                        if (lvItem.SubItems[9].Text != "") {//Se tiver data de envio
                            Data1 = DateTime.Parse(lvMain.Items[lvItem.Index - 1].SubItems[9].Text);
                            Data2 = DateTime.Parse(lvItem.SubItems[9].Text);
                            t = (Data2 - Data1);
                            NumDias = t.TotalDays;
                        } else {//Não tem data de envio
                            Data1 = DateTime.Parse(lvMain.Items[lvItem.Index - 1].SubItems[9].Text);
                            Data2 = DateTime.Now;
                            t = (Data2 - Data1);
                            NumDias = t.TotalDays;
                        }
                    } else {//Não tem data de entrada
                        NumDias = 0;
                    }
                }
                if (lvItem.Index == lvMain.Items.Count - 1 && lblSit.Text == "ARQUIVADO")
                    lvMain.Items[lvItem.Index].SubItems[8].Text = "0";
                else
                    lvMain.Items[lvItem.Index].SubItems[8].Text = (Math.Round(NumDias)).ToString();

                if (lvItem.SubItems[4].Text == "")
                    lvMain.Items[lvItem.Index].SubItems[8].Text = "";
            }
        }

        private void LvMain_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvMain.Items.Count > 0 && lvMain.SelectedItems.Count > 0)
                txtObs.Text = lvMain.SelectedItems[0].SubItems[11].Text.ToString();
        }

        private void BtObs_Click(object sender, EventArgs e) {
            if (lvMain.Items.Count == 0 || lvMain.SelectedItems.Count == 0) return;

            if (String.IsNullOrEmpty(lvMain.SelectedItems[0].SubItems[2].Text)) {
                MessageBox.Show("Local ainda não tramitado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool bReadOnly = true;
            int CodCC = Convert.ToInt16(lvMain.SelectedItems[0].SubItems[2].Text);
            Processo_bll processo_Class = new Processo_bll(_connection);
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            List<UsuariocentroCusto> Lista = processo_Class.ListaCentrocustoUsuario(sistema_Class.Retorna_User_LoginId(  gtiCore.Retorna_Last_User()));
            foreach (UsuariocentroCusto item in Lista) {
                if (item.Codigo == CodCC) {
                    bReadOnly = false;
                    break;
                }
            }

            ZoomBox f1 = new ZoomBox("Observação do trâmite", this, txtObs.Text, bReadOnly);
            f1.ShowDialog();
            txtObs.Text = f1.ReturnText;

            if (!bReadOnly) {
                lvMain.SelectedItems[0].SubItems[11].Text = f1.ReturnText;
                int Ano = processo_Class.ExtractAnoProcesso(lblNumProc.Text);
                int Numero = processo_Class.ExtractNumeroProcessoNoDV(lblNumProc.Text);
                int Seq = Convert.ToInt16(lvMain.SelectedItems[0].SubItems[1].Text);
                Exception ex = processo_Class.Alterar_Observacao_Tramite(Ano, Numero, Seq, txtObs.Text);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Erro!", ex.Message, ex);
                    eBox.ShowDialog();
                }
            }
        }

        private void BtAlterar_Click(object sender, EventArgs e) {
            if (lvMain.SelectedItems.Count == 0) {
                MessageBox.Show("Selecione o trâmite que deseja alterar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (bFechado) {
                MessageBox.Show("O processo não está aberto.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else {
                bool bFind = false;
                int CodCC = Convert.ToInt16(lvMain.SelectedItems[0].SubItems[2].Text);
                Processo_bll processo_Class = new Processo_bll(_connection);
                Sistema_bll sistema_Class = new Sistema_bll(_connection);
                List<UsuariocentroCusto> Lista = processo_Class.ListaCentrocustoUsuario(sistema_Class.Retorna_User_LoginId(gtiCore.Retorna_Last_User()));
                foreach (UsuariocentroCusto item in Lista) {
                    if (item.Codigo == CodCC) {
                        bFind = true;
                        break;
                    }
                }

                if (!bFind) {
                    MessageBox.Show("Você não pode alterar o despacho deste local.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (String.IsNullOrEmpty(lvMain.SelectedItems[0].SubItems[7].Text)) {
                    MessageBox.Show("Este trâmite não possui despacho.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (lvMain.Items.Count == 1)
                    goto Alterar;

                if (lvMain.Items.Count - 1 == lvMain.SelectedItems[0].Index)
                    goto Alterar;

                if (String.IsNullOrEmpty(lvMain.Items[lvMain.SelectedItems[0].Index + 1].SubItems[4].Text))
                    goto Alterar;
            }

            MessageBox.Show("Não é possível alterar o despacho porque já houve recebimento de processo no local abaixo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
Alterar:;
            GetButtonState();
            LockForm(false);
            lvMain.Enabled = false;
            pnlDespacho.Visible = true;
            pnlDespacho.BringToFront();
            String sDespacho = lvMain.SelectedItems[0].SubItems[7].Text;
            cmbDespacho.Text = sDespacho;
        }

        private void BtCancelDespacho_Click(object sender, EventArgs e) {
            LockForm(true);
            SetButtonState();
            pnlDespacho.Hide();
            lvMain.Enabled = true;
        }

        private void BtOKDespacho_Click(object sender, EventArgs e) {
            String sDespacho = lvMain.SelectedItems[0].SubItems[7].Text;
            if (sDespacho != cmbDespacho.Text) {
                if (MessageBox.Show("Alterar o despacho?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    Processo_bll clsProcesso = new Processo_bll(_connection);
                    int Ano = clsProcesso.ExtractAnoProcesso(lblNumProc.Text);
                    int Numero = clsProcesso.ExtractNumeroProcessoNoDV(lblNumProc.Text);
                    int Seq = Convert.ToInt16(lvMain.SelectedItems[0].SubItems[1].Text);
                    clsProcesso.Alterar_Despacho(Ano, Numero, Seq, Convert.ToInt16(cmbDespacho.SelectedValue));
                    lvMain.SelectedItems[0].SubItems[7].Text = cmbDespacho.Text;
                    LockForm(true);
                    SetButtonState();
                    pnlDespacho.Hide();
                    lvMain.Enabled = true;
                }
            }
        }

        private void BtReceber_Click(object sender, EventArgs e) {
            if (lvMain.SelectedItems.Count == 0) {
                MessageBox.Show("Selecione o trâmite que deseja receber.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Sistema_bll Sistema_Class = new Sistema_bll(_connection);
            int nUserId = Sistema_Class.Retorna_User_LoginId(Properties.Settings.Default.LastUser);

            if (bFechado) {
                MessageBox.Show("O processo não está aberto.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else {
                bool bFind = false;
                int CodCC = Convert.ToInt16(lvMain.SelectedItems[0].SubItems[2].Text);
                Processo_bll processo_Class = new Processo_bll(_connection);
                List<UsuariocentroCusto> Lista = processo_Class.ListaCentrocustoUsuario(Sistema_Class.Retorna_User_LoginId( gtiCore.Retorna_Last_User()));
                foreach (UsuariocentroCusto item in Lista) {
                    if (item.Codigo == CodCC) {
                        bFind = true;
                        break;
                    }
                }

                if (!bFind && nUserId != 433) {
                    MessageBox.Show("Você não pode trâmitar deste local.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!String.IsNullOrWhiteSpace(lvMain.SelectedItems[0].SubItems[4].Text)) {
                    MessageBox.Show("Já houve recebimento neste local.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (lvMain.Items.Count == 1)
                    goto Receber;

                if (lvMain.Items.Count - 1 == lvMain.SelectedItems[0].Index)
                    goto Receber;

            }

            if (lvMain.SelectedItems[0].Index>0 &&  String.IsNullOrEmpty(lvMain.Items[lvMain.SelectedItems[0].Index - 1].SubItems[9].Text)) {
                MessageBox.Show("O local anterior ainda não foi tramitado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

Receber:;

            GetButtonState();
            LockForm(false);
            lvMain.Enabled = false;
            pnlEnvRec.Visible = true;
            pnlEnvRec.BringToFront();
            lblEnvRec.Text = "Recebimento de Processo";
            toolTip1.SetToolTip(btOKEnvRec, "Receber processo");
            cmbDespacho2.SelectedIndex = -1;

            lblLocal.Text = lvMain.SelectedItems[0].SubItems[3].Text;
            lblData.Text = gtiCore.Retorna_Data_Base_Sistema().ToString("dd/MM/yyyy");
            lblHora.Text = DateTime.Now.ToString("HH:mm");
            String sFuncionario = lvMain.SelectedItems[0].SubItems[6].Text;

            cmbFuncionario.Items.Clear();
            String sNomeCompleto;
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            if (lvMain.SelectedItems[0].SubItems[6].Text != "")
                sNomeCompleto = lvMain.SelectedItems[0].SubItems[6].Text;
            else
                sNomeCompleto = sistema_Class.Retorna_User_FullName(gtiCore.Retorna_Last_User());
            cmbFuncionario.Items.Add(new GtiTypes.CustomListBoxItem(sNomeCompleto, 999));
            Processo_bll clsProc = new Processo_bll(_connection);
            List<UsuarioFuncStruct> ListaFunc = clsProc.ListaFuncionario(nUserId);
            foreach (UsuarioFuncStruct item in ListaFunc) {
                cmbFuncionario.Items.Add(new GtiTypes.CustomListBoxItem(item.NomeCompleto, item.FuncLogin));
            }
            cmbFuncionario.Text = sNomeCompleto;
        }

        private void BtCancelEnvRec_Click(object sender, EventArgs e) {
            LockForm(true);
            SetButtonState();
            pnlEnvRec.Hide();
            lvMain.Enabled = true;
        }

        private void BtOKEnvRec_Click(object sender, EventArgs e) {
            Exception ex = null;
            bool bReceber = lblEnvRec.Text == "Recebimento de Processo" ? true : false;
            Processo_bll clsProcesso = new Processo_bll(_connection);
            int Ano = clsProcesso.ExtractAnoProcesso(lblNumProc.Text);
            int Numero = clsProcesso.ExtractNumeroProcessoNoDV(lblNumProc.Text);
            int Seq = Convert.ToInt16(lvMain.SelectedItems[0].SubItems[1].Text);
            short CCusto = Convert.ToInt16(lvMain.SelectedItems[0].SubItems[2].Text);
            DateTime Data = Convert.ToDateTime(lblData.Text);
            DateTime Hora = Convert.ToDateTime(lblHora.Text);
            DateTime DataHora = new DateTime(Data.Year, Data.Month, Data.Day, Hora.Hour, Hora.Second, Hora.Second);
            short? CodDespacho = cmbDespacho2.SelectedIndex == -1 ? Convert.ToInt16(0) : Convert.ToInt16(cmbDespacho2.SelectedValue);
            Sistema_bll Sistema_Class = new Sistema_bll(_connection);

            Tramitacao reg = new Tramitacao {
                Ano = Convert.ToInt16(Ano),
                Numero = Numero,
                Seq = Convert.ToByte(Seq),
                Ccusto = CCusto,
                Datahora = DataHora,
                Despacho = CodDespacho == 0 ? null : CodDespacho
            };

            if (bReceber) {
                if (cmbFuncionario.SelectedIndex == -1) {
                    MessageBox.Show("Selecione um funcionário", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } else {
                    GtiTypes.CustomListBoxItem selectedItem = (GtiTypes.CustomListBoxItem)cmbFuncionario.SelectedItem;
                    reg.Userid = selectedItem._value;
                    if (reg.Userid < 999) 
                        reg.Userid = Sistema_Class.Retorna_User_LoginId("F" + Convert.ToInt32( reg.Userid).ToString("000"));
                    else
                        reg.Userid= Sistema_Class.Retorna_User_LoginId(gtiCore.Retorna_Last_User());

                    ex = clsProcesso.Excluir_Tramite(Ano, Numero, Seq);
                    if (ex != null) {
                        ErrorBox eBox = new ErrorBox("Erro!", ex.Message, ex);
                        eBox.ShowDialog();
                    }
                    ex = clsProcesso.Incluir_Tramite(reg);
                    if (ex != null) {
                        ErrorBox eBox = new ErrorBox("Erro!", ex.Message, ex);
                        eBox.ShowDialog();
                    }
                }
            } else {
                if (CodDespacho==0) {
                    MessageBox.Show("Selecione um despacho para o trâmite.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                reg.Dataenvio = DataHora;
                GtiTypes.CustomListBoxItem selectedItem = (GtiTypes.CustomListBoxItem)cmbFuncionario.SelectedItem;
                reg.Userid2 = selectedItem._value;

                if (reg.Userid2 < 999)
                    reg.Userid2 = Sistema_Class.Retorna_User_LoginId("F" + Convert.ToInt32(reg.Userid2).ToString("000"));
                else
                    reg.Userid2 = Sistema_Class.Retorna_User_LoginId(gtiCore.Retorna_Last_User());

                ex = clsProcesso.Alterar_Tramite(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Erro!", ex.Message, ex);
                    eBox.ShowDialog();
                }
            }

            CarregaTramite();
            LockForm(true);
            SetButtonState();
            pnlEnvRec.Hide();
            lvMain.Enabled = true;
        }

        private void BtEnviar_Click(object sender, EventArgs e) {
            
            
            if (lvMain.SelectedItems.Count == 0) {
                MessageBox.Show("Selecione o trâmite que deseja enviar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (bFechado) {
                MessageBox.Show("O processo não está aberto.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else {
                bool bFind = false;
                int CodCC = Convert.ToInt16(lvMain.SelectedItems[0].SubItems[2].Text);
                Processo_bll processo_Class = new Processo_bll(_connection);
                Sistema_bll Sistema_Class = new Sistema_bll(_connection);
                int nUserId = Sistema_Class.Retorna_User_LoginId( Properties.Settings.Default.LastUser);
                List<UsuariocentroCusto> Lista = processo_Class.ListaCentrocustoUsuario( Sistema_Class.Retorna_User_LoginId( gtiCore.Retorna_Last_User()));
                foreach (UsuariocentroCusto item in Lista) {
                    if (item.Codigo == CodCC) {
                        bFind = true;
                        break;
                    }
                }

                if (!bFind && nUserId!=433) {
                    MessageBox.Show("Você não pode trâmitar deste local.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (String.IsNullOrEmpty(lvMain.SelectedItems[0].SubItems[4].Text)) {
                    MessageBox.Show("Ainda não houve recebimento deste local.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (lvMain.Items.Count == 1)
                    goto Enviar;

                if (lvMain.Items.Count - 1 == lvMain.SelectedItems[0].Index)
                    goto Enviar;

                if (lvMain.SelectedItems[0].Index > 0 && String.IsNullOrEmpty(lvMain.Items[lvMain.SelectedItems[0].Index - 1].SubItems[9].Text)) {
                    MessageBox.Show("O local anterior ainda não foi tramitado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

Enviar:;

            GetButtonState();
            LockForm(false);
            lvMain.Enabled = false;
            pnlEnvRec.Visible = true;
            pnlEnvRec.BringToFront();
            lblEnvRec.Text = "Envio de Processo";
            if (lvMain.SelectedItems[0].SubItems[7].Text != "")
                cmbDespacho2.Text = lvMain.SelectedItems[0].SubItems[7].Text;
            else
                cmbDespacho2.SelectedIndex = -1;

            toolTip1.SetToolTip(btOKEnvRec, "Enviar processo");
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            lblLocal.Text = lvMain.SelectedItems[0].SubItems[3].Text;
            lblData.Text = gtiCore.Retorna_Data_Base_Sistema().ToString("dd/MM/yyyy");
            lblHora.Text = DateTime.Now.ToString("HH:mm");
            String sFuncionario = lvMain.SelectedItems[0].SubItems[6].Text;

            cmbFuncionario.Items.Clear();
            String sNomeCompleto;
            if (lvMain.SelectedItems[0].SubItems[6].Text != "")
                sNomeCompleto = lvMain.SelectedItems[0].SubItems[6].Text;
            else
                sNomeCompleto = sistema_Class.Retorna_User_FullName(gtiCore.Retorna_Last_User());
            cmbFuncionario.Items.Add(new GtiTypes.CustomListBoxItem(sNomeCompleto, 999));
            Processo_bll clsProc = new Processo_bll(_connection);
            List<UsuarioFuncStruct> ListaFunc = clsProc.ListaFuncionario(sistema_Class.Retorna_User_LoginId(gtiCore.Retorna_Last_User()));
            foreach (UsuarioFuncStruct item in ListaFunc) {
                cmbFuncionario.Items.Add(new GtiTypes.CustomListBoxItem(item.NomeCompleto, item.FuncLogin));
            }
            cmbFuncionario.Text = sNomeCompleto;
        }

        private void BtEmprestimo_Click(object sender, EventArgs e) {
            //TODO: Empréstimos de processo
        }
    }//end class
}
