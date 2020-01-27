using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Desktop.Datasets;
using GTI_Desktop.Properties;
using GTI_Models;
using GTI_Models.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static GTI_Desktop.Classes.GtiTypes;

namespace GTI_Desktop.Forms {
    public partial class Processo : Form {

        #region Variables
        bool bExec;
        bool bAssunto;
        bool bAddNew;
        string EmptyDateText = "  /  /    ";
        List<CustomListBoxItem> lstButtonState;
        string _connection = gtiCore.Connection_Name();

        public int _numero_processo { get; set; }
        public short _ano_processo { get; set; }
        public string ObsArquiva { get; set; }
        public string ObsCancela { get; set; }
        public string ObsReativa { get; set; }
        public string ObsSuspende { get; set; }

        //State Control
        public bool _addEnderecoButton { get; set; }
        public bool _delEnderecoButton { get; set; }
        public bool _tbar { get; set; }
        public bool _zoombutton { get; set; }
        public bool _cidadaoeditbutton { get; set; }
        public bool _cidadaooldbutton { get; set; }
        public bool _guiabutton { get; set; }
        public bool _documentoeditbutton { get; set; }
        public bool _arquivalabel { get; set; }
        public bool _cancelalabel { get; set; }
        public bool _reativalabel { get; set; }
        public bool _suspensaolabel { get; set; }
        public bool _anexolabel { get; set; }
        public bool _numproc { get; set; }

        #endregion

        public Processo()
        {
            gtiCore.Ocupado(this);
            InitializeComponent();
            OrigemCombo.Items.Add(new CustomListBoxItem("CENTRO DE CUSTOS", 1));
            OrigemCombo.Items.Add(new CustomListBoxItem("SISTEMA PRÁTICO", 2));
            lstButtonState = new List<CustomListBoxItem>();
            DocPanel.Hide();

            bAssunto = false;

            List<CustomListBoxItem2> myItems = new List<CustomListBoxItem2>();
            Processo_bll clsProcesso = new Processo_bll(_connection);
            List<GTI_Models.Models.Assunto> lista = clsProcesso.Lista_Assunto(true, false);
            foreach (GTI_Models.Models.Assunto item in lista) {
                myItems.Add(new CustomListBoxItem2(item.Nome, item.Codigo, item.Ativo));
            }
            AssuntoCombo.DisplayMember = "_name";
            AssuntoCombo.ValueMember = "_value";
            AssuntoCombo.DataSource = myItems;

            bAssunto = true;

            List<GTI_Models.Models.Centrocusto> listalocal = clsProcesso.Lista_Local(true,false);
            CCustoCombo.DataSource = listalocal;
            CCustoCombo.DisplayMember = "Descricao";
            CCustoCombo.ValueMember = "Codigo";

            ClearFields();
            bExec = true;
            ControlBehaviour(true);
            bExec = false;
            gtiCore.Liberado(this);
        }

        #region Form Routines

        private void GetButtonState()
        {
            lstButtonState.Clear();
            lstButtonState.Add(new CustomListBoxItem("btAdd", AddButton.Enabled ? 1 : 0));
            lstButtonState.Add(new CustomListBoxItem("btEdit", EditButton.Enabled ? 1 : 0));
            lstButtonState.Add(new CustomListBoxItem("btDel", DelButton.Enabled ? 1 : 0));
            lstButtonState.Add(new CustomListBoxItem("btGravar", GravarButton.Enabled ? 1 : 0));
            lstButtonState.Add(new CustomListBoxItem("btCancelar", CancelarButton.Enabled ? 1 : 0));
            lstButtonState.Add(new CustomListBoxItem("btZoom", ZoomButton.Enabled ? 1 : 0));
            lstButtonState.Add(new CustomListBoxItem("btAddEndereco", AddEnderecoButton.Enabled ? 1 : 0));
            lstButtonState.Add(new CustomListBoxItem("btDelEndereco", DelEnderecoButton.Enabled ? 1 : 0));
            lstButtonState.Add(new CustomListBoxItem("btFind", FindButton.Enabled ? 1 : 0));
            lstButtonState.Add(new CustomListBoxItem("btDocumentoEdit", DocumentoEditButton.Enabled ? 1 : 0));
            lstButtonState.Add(new CustomListBoxItem("btCidadaoEdit", CidadaoEditButton.Enabled ? 1 : 0));
            lstButtonState.Add(new CustomListBoxItem("btCidadaoOld", CidadaoOldButton.Enabled ? 1 : 0));
            lstButtonState.Add(new CustomListBoxItem("btGuia", GuiaButton.Enabled ? 1 : 0));
            lstButtonState.Add(new CustomListBoxItem("btOpcao", OpcaoButton.Enabled ? 1 : 0));
            lstButtonState.Add(new CustomListBoxItem("btSair", SairButton.Enabled ? 1 : 0));
            lstButtonState.Add(new CustomListBoxItem("btTramitar", TramitarButton.Enabled ? 1 : 0));
            lstButtonState.Add(new CustomListBoxItem("btPrint", PrintButton.Enabled ? 1 : 0));
            lstButtonState.Add(new CustomListBoxItem("btPrintDoc", PrintDocButton.Enabled ? 1 : 0));
        }

        private void SetButtonState()
        {
            if (lstButtonState.Count == 0) return;
            CustomListBoxItem r = lstButtonState.Find(item => item._name == "btAdd");
            AddButton.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btEdit");
            EditButton.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btDel");
            DelButton.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btGravar");
            GravarButton.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btCancelar");
            CancelarButton.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btZoom");
            ZoomButton.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btAddEndereco");
            AddEnderecoButton.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btDelEndereco");
            DelEnderecoButton.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btFind");
            FindButton.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btDocumentoEdit");
            DocumentoEditButton.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btFind");
            FindButton.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btCidadaoEdit");
            CidadaoEditButton.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btCidadaoOld");
            CidadaoOldButton.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btGuia");
            GuiaButton.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btOpcao");
            OpcaoButton.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btSair");
            SairButton.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btTramitar");
            TramitarButton.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btPrint");
            PrintButton.Enabled = Convert.ToBoolean(r._value);
            r = lstButtonState.Find(item => item._name == "btPrintDoc");
            PrintDocButton.Enabled = Convert.ToBoolean(r._value);
        }

        private void ControlBehaviour(bool bStart)
        {
            AnexoLabel.Enabled = bStart;
            ArquivaLabel.Enabled = bStart;
            CancelaLabel.Enabled = bStart;
            EntradaLabel.Enabled = bStart;
            ReativaLabel.Enabled = bStart;
            SuspensaoLabel.Enabled = bStart;
            AddButton.Enabled = bStart;
            EditButton.Enabled = bStart;
            DelButton.Enabled = bStart;
            SairButton.Enabled = bStart;
            PrintButton.Enabled = bStart;
            FindButton.Enabled = bStart;
            GravarButton.Enabled = !bStart;
            CancelarButton.Enabled = !bStart;
            OpcaoButton.Enabled = bStart;
            TramitarButton.Enabled = bStart;
           
            ComplementoText.ReadOnly = bStart;

            if (!bAddNew) {
                if (!gtiCore.IsEmptyDate(ArquivaLabel.Text) || !gtiCore.IsEmptyDate(CancelaLabel.Text) || !gtiCore.IsEmptyDate(SuspensaoLabel.Text))
                   bStart = true;

                bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroProcesso_Alterar_Avancado);
                if (bAllow) {
                    Fisicocheckbox.Enabled = !bStart;
                    Internocheckbox.Enabled = !bStart;
                    ComOption.Enabled = !bStart;
                    ResOption.Enabled = !bStart;
                    ObsText.ReadOnly = bStart;
                    CidadaoEditButton.Enabled = !bStart;
                    DelEnderecoButton.Enabled = !bStart;
                    AddEnderecoButton.Enabled = !bStart;
                    AssuntoText.Visible = bStart;
                    AssuntoText.ReadOnly = true;
                    AssuntoCombo.Visible = !bStart;
                    InscricaoText.ReadOnly = bStart;
                    OrigemText.Visible = bStart;
                    OrigemText.ReadOnly = true;
                    OrigemCombo.Visible = !bStart;
                    ObsText.ReadOnly = bStart;
                    NumProcText.ReadOnly = !bStart;
                    CCustoText.Visible = bStart;
                    CCustoText.ReadOnly = true;
                    CCustoCombo.Visible = !bStart;
                    DocListView.Enabled = !bStart;
                } else {
                    bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroProcesso_Alterar_Basico);
                    if (bAllow) {
                        ObsText.ReadOnly = bStart;
                        InscricaoText.ReadOnly = bStart;
                    }
                }
            } else {
                Fisicocheckbox.Enabled = !bStart;
                Internocheckbox.Enabled = !bStart;
                ComOption.Enabled = !bStart;
                ResOption.Enabled = !bStart;
                ObsText.ReadOnly = bStart;
                CidadaoEditButton.Enabled = !bStart;
                DelEnderecoButton.Enabled = !bStart;
                AddEnderecoButton.Enabled = !bStart;
                AssuntoText.Visible = bStart;
                AssuntoText.ReadOnly = true;
                AssuntoCombo.Visible = !bStart;
                InscricaoText.ReadOnly = bStart;
                OrigemText.Visible = bStart;
                OrigemText.ReadOnly = true;
                OrigemCombo.Visible = !bStart;
                ObsText.ReadOnly = bStart;
                NumProcText.ReadOnly = !bStart;
                CCustoText.Visible = bStart;
                CCustoText.ReadOnly = true;
                CCustoCombo.Visible = !bStart;
                DocListView.Enabled = !bStart;
            }
        }

        private void ClearFields()
        {
            AtendenteLabel.Text = "";
            HoraLabel.Text = "00:00";
            AssuntoText.Text = "";
            Fisicocheckbox.Checked = true;
            Internocheckbox.Checked = false;
            AssuntoCombo.SelectedIndex = -1;
            OrigemCombo.SelectedIndex = 1;
            ComplementoText.Text = "";
            InscricaoText.Text = "";
            EntradaLabel.Text = DateTime.Parse(DateTime.Now.ToString()).ToString("dd/MM/yyyy");
            ReativaLabel.Text = EmptyDateText;
            SuspensaoLabel.Text = EmptyDateText;
            ArquivaLabel.Text = EmptyDateText;
            CancelaLabel.Text = EmptyDateText;
            AnexoLabel.Text = "";
            AnexoLogListView.Items.Clear();
            ObsText.Text = "";
            CodCidadaoLabel.Text = "000000";
            NomeCidadaoLabel.Text = "";
            CCustoCombo.SelectedIndex = -1;
            EnderecoListView.Items.Clear();
            DocListView.Items.Clear();
            SituacaoLabel.Text = "NORMAL";
            NomeLabel.Text = "";
            DocLabel.Text = "";
            EndLabel.Text = "";
            ComplLabel.Text = "";
            BairroLabel.Text = "";
            CidadeLabel.Text = "";
            RGLabel.Text = "";
            DocEntregueLabel.Text = "0";
            DocPendenteLabel.Text = "0";
        }

        private void UnlockForm() {
            AddEnderecoButton.Enabled = _addEnderecoButton;
            DelEnderecoButton.Enabled = _delEnderecoButton;
            tBar.Enabled = _tbar;
            ZoomButton.Enabled = _zoombutton;
            CidadaoEditButton.Enabled = _cidadaoeditbutton;
            CidadaoOldButton.Enabled = _cidadaooldbutton;
            GuiaButton.Enabled = _guiabutton;
            DocumentoEditButton.Enabled = _documentoeditbutton;
            ArquivaLabel.Enabled = _arquivalabel;
            CancelaLabel.Enabled = _cancelalabel;
            ReativaLabel.Enabled = _reativalabel;
            SuspensaoLabel.Enabled = _suspensaolabel;
            AnexoLabel.Enabled = _anexolabel;
            NumProcText.ReadOnly = _numproc;
        }

        private void LockForm() {
            _addEnderecoButton = AddEnderecoButton.Enabled;
            _delEnderecoButton = DelEnderecoButton.Enabled;
            _tbar = tBar.Enabled;
            _zoombutton = ZoomButton.Enabled;
            _cidadaoeditbutton = CidadaoEditButton.Enabled;
            _cidadaooldbutton = CidadaoOldButton.Enabled;
            _guiabutton = GuiaButton.Enabled;
            _documentoeditbutton = DocumentoEditButton.Enabled;
            _arquivalabel = ArquivaLabel.Enabled;
            _cancelalabel = CancelaLabel.Enabled;
            _reativalabel = ReativaLabel.Enabled;
            _suspensaolabel = SuspensaoLabel.Enabled;
            _anexolabel = AnexoLabel.Enabled;
            _numproc = NumProcText.ReadOnly;

            AddEnderecoButton.Enabled = false;
            DelEnderecoButton.Enabled = false;
            tBar.Enabled = false;
            ZoomButton.Enabled = false;
            CidadaoEditButton.Enabled = false;
            CidadaoOldButton.Enabled = false;
            GuiaButton.Enabled = false;
            DocumentoEditButton.Enabled = false;
            ArquivaLabel.Enabled = false;
            CancelaLabel.Enabled = false;
            ReativaLabel.Enabled = false;
            SuspensaoLabel.Enabled = false;
            AnexoLabel.Enabled = false;
            NumProcText.ReadOnly = false;

            Doc1Check.Checked = true;
            Doc2Check.Checked = false;
            Doc3Check.Checked = false;
            Doc4Check.Checked = false;
            Doc5Check.Checked = false;
            Doc1Check.Focus();
        }

        #endregion

        #region Control Events

        private void BtAdd_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroProcesso_Novo);
            if (bAllow) {
                _ano_processo = 0;
                _numero_processo = 0;
                bAddNew = true;
                ClearFields();
                AtendenteLabel.Text = gtiCore.Retorna_Last_User();
                Sistema_bll sistema_Class = new Sistema_bll(_connection);
                AtendenteLabel.Tag = sistema_Class.Retorna_User_LoginId(AtendenteLabel.Text);
                NumProcText.Text = "";
                ControlBehaviour(false);
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtEdit_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroProcesso_Alterar_Avancado);
            bool bAllow2 = gtiCore.GetBinaryAccess((int)TAcesso.CadastroProcesso_Alterar_Basico);
            if (bAllow || bAllow2) {
                bAddNew = false;
                if (String.IsNullOrEmpty(AssuntoText.Text))
                    MessageBox.Show("Nenhum processo carregado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    ControlBehaviour(false);
                    ObsText.Focus();
                }
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtGravar_Click(object sender, EventArgs e) {
            if (ValidateReg()) {
                Exception ex = Grava_Processo();
                if (ex == null) {
                    ex = Grava_Endereco();
                    if (ex == null) {
                        ex = Grava_Documento();
                        CarregaProcesso();
                        ControlBehaviour(true);
                    }
                }
            }
        }

        private void BtTramitar_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroProcesso_Tramitar);
            if (bAllow) {
                if (String.IsNullOrEmpty(AssuntoText.Text)) {
                    MessageBox.Show("Nenhum processo carregado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Processo_Tramite);
                if (formToShow != null)
                    formToShow.Show();

                Processo_bll clsProcesso = new Processo_bll(_connection);
                short nAnoProc = clsProcesso.ExtractAnoProcesso(NumProcText.Text);
                int nNumeroProc = clsProcesso.ExtractNumeroProcessoNoDV(NumProcText.Text);
                Forms.Processo_Tramite f1 = new Processo_Tramite(nAnoProc, nNumeroProc) {
                    Tag = this.Name
                };
                f1.ShowDialog();
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtFind_Click(object sender, EventArgs e)
        {
            using (var form = new Processo_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    ProcessoNumero val = form.ReturnValue;
                    Processo_bll clsProcesso = new Processo_bll(_connection);
                    NumProcText.Text = val.Numero + "-" + clsProcesso.DvProcesso(val.Numero) + "/" + val.Ano;
                    LoadReg();
                }
            }
        }

        private void ChkInterno_CheckStateChanged(object sender, EventArgs e)
        {
            if (Internocheckbox.Checked) {
                OrigemCombo.SelectedIndex = 0;

            } else {
                OrigemCombo.SelectedIndex = 1;
            }
        }

        private void BtAnexoSair_Click(object sender, EventArgs e)
        {
            UnlockForm();
            AnexoPanel.Visible = false;
        }

        private void LblAnexo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (String.IsNullOrEmpty(AssuntoText.Text)) {
                MessageBox.Show("Nenhum processo carregado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GetButtonState();
            LockForm();
            AnexoPanel.Show();
            AnexoPanel.BringToFront();
        }

        private void BtAnexoNovo_Click(object sender, EventArgs e)
        {
            inputBox iBox = new inputBox();
            String sData = iBox.Show("", "Informe  o Processo", "Digite o Nº do Processo à ser anexado.", 12);
            if (!string.IsNullOrEmpty(sData)) {
                Processo_bll clsProcesso = new Processo_bll(_connection);
                Exception ex = clsProcesso.ValidaProcesso(sData);
                if (ex == null) {
                    if (MessageBox.Show("Deseja anexar o processo: " + sData + "?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        int nAnoAnexo = clsProcesso.ExtractAnoProcesso(sData);
                        int nNumeroAnexo = clsProcesso.ExtractNumeroProcessoNoDV(sData);
                        ProcessoStruct reg = clsProcesso.Dados_Processo(nAnoAnexo, nNumeroAnexo);
                        string sNumProcesso = reg.SNumero;
                        foreach (ListViewItem item in MainListView.Items) {
                            if (item.Text == sNumProcesso) {
                                MessageBox.Show("Este processo já foi anexado ao processo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }

                        ListViewItem lvi = new ListViewItem(sNumProcesso);
                        lvi.SubItems.Add(reg.NomeCidadao);
                        lvi.SubItems.Add(reg.Complemento);
                        MainListView.Items.Add(lvi);

                        short nAnoProc = clsProcesso.ExtractAnoProcesso(NumProcText.Text);
                        int nNumeroProc = clsProcesso.ExtractNumeroProcessoNoDV(NumProcText.Text);

                        GTI_Models.Models.Anexo reg_anexo = new GTI_Models.Models.Anexo {
                            Ano = nAnoProc,
                            Numero = nNumeroProc,
                            Anoanexo = (short)nAnoAnexo,
                            Numeroanexo = nNumeroAnexo
                        };
                        ex = clsProcesso.Incluir_Anexo(reg_anexo, gtiCore.Retorna_Last_User());
                        AnexoLabel.Text = MainListView.Items.Count.ToString() + " anexo(s)";

                        ProcessoStruct Proc = clsProcesso.Dados_Processo(nAnoProc, nNumeroProc);
                        Sistema_bll sistema_Class = new Sistema_bll(_connection);
                        ListViewItem lvlog = new ListViewItem(DateTime.Now.ToString("dd/MM/yyyy"));
                        lvlog.SubItems.Add(sNumProcesso);
                        lvlog.SubItems.Add("Anexado");
                        lvlog.SubItems.Add(sistema_Class.Retorna_User_FullName(gtiCore.Retorna_Last_User()));
                        AnexoLogListView.Items.Add(lvlog);

                        if (ex != null) {
                            ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                            eBox.ShowDialog();
                        }
                    } else {
                        ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                        eBox.ShowDialog();
                    }
                } else
                    MessageBox.Show("Digite um processo cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtAnexoDel_Click(object sender, EventArgs e)
        {
            if (MainListView.SelectedItems.Count == 0)
                MessageBox.Show("Selecione o anexo a ser removido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (MessageBox.Show("Remover o anoexo " + MainListView.SelectedItems[0].Text, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    Processo_bll clsProcesso = new Processo_bll(_connection);
                    string sNumProcesso = MainListView.SelectedItems[0].Text;
                    short nAno = clsProcesso.ExtractAnoProcesso(sNumProcesso);
                    int nNumero = clsProcesso.ExtractNumeroProcessoNoDV(sNumProcesso);
                    GTI_Models.Models.Anexo reganexo = new GTI_Models.Models.Anexo {
                        Ano = clsProcesso.ExtractAnoProcesso(NumProcText.Text),
                        Numero = clsProcesso.ExtractNumeroProcessoNoDV(NumProcText.Text),
                        Anoanexo = nAno,
                        Numeroanexo = nNumero
                    };

                    Exception ex = clsProcesso.Excluir_Anexo(reganexo, gtiCore.Retorna_Last_User());
                    if (ex != null) {
                        ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                        eBox.ShowDialog();
                    } else {
                        MainListView.Items.RemoveAt(MainListView.SelectedItems[0].Index);
                        AnexoLabel.Text = MainListView.Items.Count.ToString() + " anexo(s)";
                        ProcessoStruct Proc = clsProcesso.Dados_Processo(nAno, nNumero);

                        Sistema_bll sistema_Class = new Sistema_bll(_connection);
                        ListViewItem lvlog = new ListViewItem(DateTime.Now.ToString("dd/MM/yyyy"));
                        lvlog.SubItems.Add(sNumProcesso);
                        lvlog.SubItems.Add("Removido");
                        lvlog.SubItems.Add(sistema_Class.Retorna_User_FullName(gtiCore.Retorna_Last_User()));
                        AnexoLogListView.Items.Add(lvlog);
                    }
                }
            }
        }

        private void BtCancelar_Click(object sender, EventArgs e)
        {
            ClearFields();
            ControlBehaviour(true);
        }

        private void BtCidadaoOld_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NumProcText.Text)) {

                Processo_bll clsProcesso = new Processo_bll(_connection);
                ProcessoCidadaoStruct row = clsProcesso.Processo_cidadao_old(clsProcesso.ExtractAnoProcesso(NumProcText.Text), clsProcesso.ExtractNumeroProcessoNoDV(NumProcText.Text));
                if (row == null) {
                    MessageBox.Show("Cidadão original não gravado para este processo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                NomeLabel.Text = row.Codigo.ToString("000000") + " - " + row.Nome;
                EndLabel.Text = row.Logradouro_Nome + ", " + row.Numero.ToString();
                ComplLabel.Text = row.Complemento;
                BairroLabel.Text = row.Bairro_Nome;
                DocLabel.Text = row.Documento;
                RGLabel.Text = row.RG + " " + row.Orgao;
                CidadeLabel.Text = row.Cidade_Nome + "/" + row.UF;
                GetButtonState();
                LockForm();
                CidadaoPanel.Show();
                CidadaoPanel.BringToFront();
                GravarButton.Enabled = false;
                CancelarButton.Enabled = false;
            } else
                MessageBox.Show("Selecione um processo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtCancelCidadao_Click(object sender, EventArgs e)
        {
            UnlockForm();
            SetButtonState();
            CidadaoPanel.Hide();
        }

        private void CancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(AssuntoText.Text)) {
                MessageBox.Show("Nenhum processo carregado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!gtiCore.IsEmptyDate(CancelaLabel.Text))
                MessageBox.Show("Processo já cancelado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (!gtiCore.IsEmptyDate(ArquivaLabel.Text))
                    MessageBox.Show("Não é possível cancelar, processo arquivado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    if (MessageBox.Show("Cancelar este processo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        ZoomBox f1 = new ZoomBox("Motivo do cancelamento do processo", this, "", false);
                        f1.ShowDialog();
                        ObsCancela = f1.ReturnText;

                        if (String.IsNullOrEmpty(ObsCancela))
                            MessageBox.Show("Digite o motivo do cancelamento!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else {
                            CancelaLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
                            ReativaLabel.Text = EmptyDateText;
                            SuspensaoLabel.Text = EmptyDateText;
                            ArquivaLabel.Text = EmptyDateText;
                            Processo_bll clsProcesso = new Processo_bll(_connection);
                            short Ano_Processo = clsProcesso.ExtractAnoProcesso(NumProcText.Text);
                            int Num_Processo = clsProcesso.ExtractNumeroProcessoNoDV(NumProcText.Text);
                            string sHist = "Cancelamento do processo --> " + ObsCancela;
                            clsProcesso.Incluir_Historico_Processo(Ano_Processo, Num_Processo, sHist, gtiCore.Retorna_Last_User());
                            clsProcesso.Cancelar_Processo(Ano_Processo, Num_Processo, ObsCancela);
                            SituacaoLabel.Text = "CANCELADO";
                        }
                    }
                }
            }
        }

        private void ReativarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(AssuntoText.Text)) {
                MessageBox.Show("Nenhum processo carregado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!gtiCore.IsEmptyDate(CancelaLabel.Text) && !gtiCore.IsEmptyDate(ArquivaLabel.Text) && !gtiCore.IsEmptyDate(SuspensaoLabel.Text))
                MessageBox.Show("Processo encontra-se ativo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (!gtiCore.IsEmptyDate(CancelaLabel.Text))
                    MessageBox.Show("Não é possível reativar, processo cancelado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    if (MessageBox.Show("Reativar este processo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        ZoomBox f1 = new ZoomBox("Motivo da reativação do processo", this, "", false);
                        f1.ShowDialog();
                        ObsReativa = f1.ReturnText;
                        if (String.IsNullOrEmpty(ObsReativa))
                            MessageBox.Show("Digite o motivo da reativação!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else {
                            ReativaLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
                            SuspensaoLabel.Text = EmptyDateText;
                            ArquivaLabel.Text = EmptyDateText;
                            CancelaLabel.Text = EmptyDateText;
                            Processo_bll clsProcesso = new Processo_bll(_connection);
                            short Ano_Processo = clsProcesso.ExtractAnoProcesso(NumProcText.Text);
                            int Num_Processo = clsProcesso.ExtractNumeroProcessoNoDV(NumProcText.Text);
                            string sHist = "Reativação do processo --> " + ObsReativa;
                            clsProcesso.Incluir_Historico_Processo(Ano_Processo, Num_Processo, sHist, gtiCore.Retorna_Last_User());
                            clsProcesso.Reativar_Processo(Ano_Processo, Num_Processo, ObsReativa);
                            SituacaoLabel.Text = "NORMAL";
                        }
                    }
                }
            }
        }

        private void SuspenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(AssuntoText.Text)) {
                MessageBox.Show("Nenhum processo carregado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!gtiCore.IsEmptyDate(SuspensaoLabel.Text))
                MessageBox.Show("Processo já suspenso!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (!gtiCore.IsEmptyDate(ArquivaLabel.Text))
                    MessageBox.Show("Processo arquivado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    if (!gtiCore.IsEmptyDate(CancelaLabel.Text))
                        MessageBox.Show("Processo cancelado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        if (MessageBox.Show("Suspender este processo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                            ZoomBox f1 = new ZoomBox("Motivo da suspensão do processo", this, "", false);
                            f1.ShowDialog();
                            ObsSuspende = f1.ReturnText;

                            if (String.IsNullOrEmpty(ObsSuspende))
                                MessageBox.Show("Digite o motivo da suspensão!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else {
                                SuspensaoLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
                                ReativaLabel.Text = EmptyDateText;
                                ArquivaLabel.Text = EmptyDateText;
                                CancelaLabel.Text = EmptyDateText;
                                Processo_bll clsProcesso = new Processo_bll(_connection);
                                short Ano_Processo = clsProcesso.ExtractAnoProcesso(NumProcText.Text);
                                int Num_Processo = clsProcesso.ExtractNumeroProcessoNoDV(NumProcText.Text);
                                string sHist = "Suspenção do processo --> " + ObsSuspende;
                                clsProcesso.Incluir_Historico_Processo(Ano_Processo, Num_Processo, sHist, gtiCore.Retorna_Last_User());
                                clsProcesso.Suspender_Processo(Ano_Processo, Num_Processo, ObsReativa);
                                SituacaoLabel.Text = "SUSPENSO";
                            }
                        }
                    }
                }
            }
        }

        private void ArquivarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(AssuntoText.Text)) {
                MessageBox.Show("Nenhum processo carregado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!gtiCore.IsEmptyDate(ArquivaLabel.Text))
                MessageBox.Show("Processo já arquivado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (!gtiCore.IsEmptyDate(CancelaLabel.Text))
                    MessageBox.Show("Não é possível arquivar, processo cancelado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    if (!VerificaTramite())
                        MessageBox.Show("Não é possível arquivar, trâmite não concluido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        ZoomBox f1 = new ZoomBox("Motivo do arquivamento do processo", this, "", false);
                        f1.ShowDialog();
                        ObsArquiva = f1.ReturnText;
                        ArquivaLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        if (String.IsNullOrEmpty(ObsArquiva))
                            MessageBox.Show("Digite o motivo do arquivamento!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else {
                            SuspensaoLabel.Text = EmptyDateText;
                            ReativaLabel.Text = EmptyDateText;
                            ArquivaLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
                            CancelaLabel.Text = EmptyDateText;
                            Processo_bll clsProcesso = new Processo_bll(_connection);
                            short Ano_Processo = clsProcesso.ExtractAnoProcesso(NumProcText.Text);
                            int Num_Processo = clsProcesso.ExtractNumeroProcessoNoDV(NumProcText.Text);
                            string sHist = "Arquivação do processo --> " + ObsArquiva;
                            clsProcesso.Incluir_Historico_Processo(Ano_Processo, Num_Processo, sHist, gtiCore.Retorna_Last_User());
                            clsProcesso.Arquivar_Processo(Ano_Processo, Num_Processo, ObsArquiva);
                            SituacaoLabel.Text = "ARQUIVADO";
                        }
                    }
                }
            }
        }

        private void BtZoom_Click(object sender, EventArgs e)
        {
            bool bReadOnly = false;
            if (AddButton.Enabled) bReadOnly = true;
            ZoomBox f1 = new ZoomBox("Observação do processo", this, ObsText.Text, bReadOnly,5000);
            f1.ShowDialog();
            ObsText.Text = f1.ReturnText;
        }

        private void BtSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtPrint_Click(object sender, EventArgs e)
        {
            if (AssuntoCombo.SelectedIndex > -1) {
                LockForm();
                PrintPanel.Visible = true;
                PrintPanel.BringToFront();
                DocumentoEditButton.Enabled = false;
            }
        }

        private void TxtInscricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void TxtNumProc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Return && e.KeyChar != (char)Keys.Tab) {
                const char Delete = (char)8;
                const char Minus = (char)45;
                const char Barra = (char)47;
                if (e.KeyChar == Minus && NumProcText.Text.Contains("-"))
                    e.Handled = true;
                else {
                    if (e.KeyChar == Barra && NumProcText.Text.Contains("/"))
                        e.Handled = true;
                    else
                        e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete && e.KeyChar != Barra && e.KeyChar != Minus;
                }
            }
        }

        private void TxtNumProc_TextChanged(object sender, EventArgs e)
        {
            if(bExec)
                ClearFields();
        }

        private void CmbAssunto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bAssunto) return;

            CustomListBoxItem2 item = (CustomListBoxItem2)AssuntoCombo.SelectedItem;
//            if (item != null)
//                InscricaoText.Text = item._ativo.ToString();
            DocListView.Items.Clear();
            if (AssuntoCombo.SelectedIndex == -1) {
                AssuntoText.Text = "";
                AssuntoText.Tag = "";
            } else {
                AssuntoText.Text = AssuntoCombo.Text;
                AssuntoText.Tag = item._value.ToString();
                ComplementoText.Text = AssuntoCombo.Text;
            }
        }

        private void CmbCCusto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CCustoCombo.SelectedIndex == -1)
                CCustoText.Text = "";
            else
                CCustoText.Text = CCustoCombo.Text;
        }

        private void CmbOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OrigemCombo.SelectedIndex == 0) {
                RequerentePanel.Visible = false;
                pnlCCusto.Visible = true;
            } else {
                RequerentePanel.Visible = true;
                pnlCCusto.Visible = false;
            }
            OrigemText.Text = OrigemCombo.Text;
        }

        private void LblSuspensao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!gtiCore.IsEmptyDate(SuspensaoLabel.Text)) {
                bool bReadOnly = true;
                ZoomBox f1 = new ZoomBox("Observação da suspenção do processo", this, ObsSuspende, bReadOnly);
                f1.ShowDialog();
                ObsSuspende = f1.ReturnText;
            }
        }

        private void LblArquiva_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!gtiCore.IsEmptyDate(ArquivaLabel.Text)) {
                bool bReadOnly = true;
                ZoomBox f1 = new ZoomBox("Observação do arquivamento do processo", this, ObsArquiva, bReadOnly);
                f1.ShowDialog();
                ObsArquiva = f1.ReturnText;
            }
        }

        private void LblReativa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!gtiCore.IsEmptyDate(ReativaLabel.Text)) {
                bool bReadOnly = true;
                ZoomBox f1 = new ZoomBox("Observação da reativação do processo", this, ObsReativa, bReadOnly);
                f1.ShowDialog();
                ObsReativa = f1.ReturnText;
            }
        }

        private void LblCancela_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!gtiCore.IsEmptyDate(CancelaLabel.Text)) {
                bool bReadOnly = true;
                ZoomBox f1 = new ZoomBox("Observação do cancelamento do processo", this, ObsCancela, bReadOnly);
                f1.ShowDialog();
                ObsCancela = f1.ReturnText;
            }
        }

        private void BtCidadaoEdit_Click(object sender, EventArgs e){
            inputBox z = new inputBox();
            String sCod = z.Show("", "Adicionar o requerente do processo.", "Digite o código do cidadão.", 6, gtiCore.eTweakMode.IntegerPositive);
            if (!string.IsNullOrEmpty(sCod)) {
                int nCod = Convert.ToInt32(sCod);
                if (nCod < 500000 || nCod > 700000)
                    MessageBox.Show("Código de cidadão inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    Cidadao_bll cidadao_Class = new Cidadao_bll(_connection);
                    if (!cidadao_Class.ExisteCidadao(nCod))
                        MessageBox.Show("Código não cadastrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        CidadaoStruct reg = cidadao_Class.LoadReg(nCod);
                        CodCidadaoLabel.Text = reg.Codigo.ToString("000000");
                        NomeCidadaoLabel.Text = reg.Nome;
                    }
                }
            }
        }

        #endregion

        #region Functions

        private void LoadReg()
        {
            gtiCore.Ocupado(this);
            Processo_bll clsProcesso = new Processo_bll(_connection);
            _numero_processo = clsProcesso.ExtractNumeroProcessoNoDV(NumProcText.Text);
            _ano_processo = clsProcesso.ExtractAnoProcesso(NumProcText.Text);
            ProcessoStruct Reg = clsProcesso.Dados_Processo(_ano_processo,_numero_processo);
            AssuntoCombo.SelectedValue = Convert.ToInt32(Reg.CodigoAssunto);
            AssuntoText.Text = AssuntoCombo.Text;
            ComplementoText.Text = Reg.Complemento;
            AtendenteLabel.Text = Reg.AtendenteNome;
            AtendenteLabel.Tag = Reg.AtendenteId.ToString();
            ObsText.Text = Reg.Observacao;
            HoraLabel.Text = Reg.Hora;
            InscricaoText.Text = Reg.Inscricao.ToString();
            EntradaLabel.Text = Reg.DataEntrada == null ? EmptyDateText : DateTime.Parse(Reg.DataEntrada.ToString()).ToString("dd/MM/yyyy");
            ArquivaLabel.Text = Reg.DataArquivado == null ? EmptyDateText : DateTime.Parse(Reg.DataArquivado.ToString()).ToString("dd/MM/yyyy");
            ReativaLabel.Text = Reg.DataReativacao == null ? EmptyDateText : DateTime.Parse(Reg.DataReativacao.ToString()).ToString("dd/MM/yyyy");
            SuspensaoLabel.Text = Reg.DataSuspensao == null ? EmptyDateText : DateTime.Parse(Reg.DataSuspensao.ToString()).ToString("dd/MM/yyyy");
            CancelaLabel.Text = Reg.DataCancelado == null ? EmptyDateText : DateTime.Parse(Reg.DataCancelado.ToString()).ToString("dd/MM/yyyy");

            if (Reg.DataCancelado != null)
                SituacaoLabel.Text = "CANCELADO";
            else {
                if (Reg.DataArquivado != null)
                    SituacaoLabel.Text = "ARQUIVADO";
                else {
                    if (Reg.DataSuspensao != null)
                        SituacaoLabel.Text = "SUSPENSO";
                    else
                        SituacaoLabel.Text = "NORMAL";
                }
            }

            AnexoLabel.Text = Reg.Anexo;
            Internocheckbox.Checked = Reg.Interno;
            Fisicocheckbox.Checked = Reg.Fisico;

            for (int r = 0; r < OrigemCombo.Items.Count; r++) {
                CustomListBoxItem selectedData = (CustomListBoxItem)OrigemCombo.Items[r];
                if (Reg.Origem == selectedData._value) {
                    OrigemCombo.SelectedIndex = r;
                    OrigemText.Text = OrigemCombo.Text;
                    break;
                }
            }

            CCustoCombo.SelectedValue = Convert.ToInt16(Reg.CentroCusto);
            CCustoText.Text = CCustoCombo.Text;
            CodCidadaoLabel.Text = Reg.CodigoCidadao.ToString();
            NomeCidadaoLabel.Text = Reg.NomeCidadao;

            if (Reg.CentroCusto > 0) {
                pnlCCusto.Visible = true;
                RequerentePanel.Visible = false;
            } else {
                pnlCCusto.Visible = false;
                RequerentePanel.Visible = true;
            }

            EnderecoListView.Items.Clear();
            foreach (var item in Reg.ListaProcessoEndereco) {
                ListViewItem lvi = new ListViewItem(item.NomeLogradouro);
                lvi.SubItems.Add(item.CodigoLogradouro.ToString());
                lvi.SubItems.Add(item.Numero);
                EnderecoListView.Items.Add(lvi);
            }

            MainListView.Items.Clear();
            foreach (var item in Reg.ListaAnexo) {
                String sNumProc = item.NumeroAnexo.ToString() + "-" + clsProcesso.DvProcesso(item.NumeroAnexo).ToString() + "/" + item.AnoAnexo.ToString();
                ListViewItem lvi = new ListViewItem(sNumProc);
                lvi.SubItems.Add(item.Requerente);
                lvi.SubItems.Add(item.Complemento);
                MainListView.Items.Add(lvi);
            }

            foreach (var item in Reg.ListaAnexoLog) {
                String sNumProc = item.Numero_anexo.ToString() + "-" + clsProcesso.DvProcesso(item.Numero_anexo).ToString() + "/" + item.Ano_anexo.ToString();
                ListViewItem lvi = new ListViewItem(item.Data.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(sNumProc);
                lvi.SubItems.Add(item.Ocorrencia);
                lvi.SubItems.Add(item.UserName);
                AnexoLogListView.Items.Add(lvi);
            }

            ObsArquiva = Reg.ObsArquiva;
            //pnlDoc.Show();
            DocListView.Items.Clear();
            if (Reg.ListaProcessoDoc.Count == 0) {
                //se não houver documentos gravados no processo carrega lista padrão de documentos do assunto selecionado.
                Processo_bll processo_Class = new Processo_bll(_connection);
                List<AssuntoDocStruct> ListaDoc = new List<AssuntoDocStruct>();
                ListaDoc = processo_Class.Lista_Assunto_Documento((short)Reg.CodigoAssunto);
                foreach (AssuntoDocStruct item in ListaDoc) {
                    ProcessoDocStruct reg = new ProcessoDocStruct {
                        CodigoDocumento = item.Codigo,
                        NomeDocumento = item.Nome
                    };
                    Reg.ListaProcessoDoc.Add(reg);
                }
            }


            foreach (var item in Reg.ListaProcessoDoc) {
                ListViewItem lvi = new ListViewItem(item.NomeDocumento);
                lvi.SubItems.Add(item.CodigoDocumento.ToString());
                if (item.DataEntrega == null) {
                    lvi.SubItems.Add("");
                } else {
                    lvi.Checked = true;
                    lvi.SubItems.Add(DateTime.Parse(item.DataEntrega.ToString()).ToString("dd/MM/yyyy"));
                }
                DocListView.Items.Add(lvi);
            }
            gtiCore.Liberado(this);
            DocPanel.Hide();
            UpdateDocNumber();

        }

        private void TxtNumProc_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
                CarregaProcesso();
        }

        private void CarregaProcesso()
        {
            if (!String.IsNullOrEmpty(NumProcText.Text)) {
                Processo_bll clsProcesso = new Processo_bll(_connection);
                Exception ex = clsProcesso.ValidaProcesso(NumProcText.Text);
                if (ex == null) {
                    bExec = false;
                    LoadReg();
                    bExec = true;
                    tBar.Focus();
                } else {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                }
            } else
                MessageBox.Show("Digite um processo cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool VerificaTramite()
        {
            //TODO: Verificar Tramite
            return true;
        }

        private void UpdateDocNumber()
        {
            int DocEntregue = 0;
            int DocPendente = 0;
            foreach (ListViewItem lvItem in DocListView.Items) {
                if (lvItem.Checked)
                    DocEntregue++;
                else
                    DocPendente++;
            }
            DocEntregueLabel.Text = DocEntregue.ToString();
            DocPendenteLabel.Text = DocPendente.ToString();
        }

        private bool ValidateReg() {
            if (AssuntoCombo.SelectedIndex == -1) {
                MessageBox.Show("Selecione o assunto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(ComplementoText.Text.Trim())) {
                MessageBox.Show("Digite o complemento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (OrigemCombo.SelectedIndex == 0 && CCustoCombo.SelectedIndex == -1) {
                MessageBox.Show("Selecione o Centro de Custos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (OrigemCombo.SelectedIndex == 1 && NomeCidadaoLabel.Text == "") {
                MessageBox.Show("Selecione o requerente do processo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(InscricaoText.Text.Trim()))
                InscricaoText.Text = "0";

            return true;
        }

        private Exception Grava_Processo() {
            Processogti Reg = new Processogti {
                Numero = _numero_processo,
                Ano = _ano_processo,
                Complemento = ComplementoText.Text.Trim(),
                Observacao = ObsText.Text.Trim(),
                Insc = Convert.ToInt32(InscricaoText.Text),
                Dataentrada = Convert.ToDateTime(EntradaLabel.Text),
                Hora = HoraLabel.Text
            };
            if (gtiCore.IsEmptyDate(SuspensaoLabel.Text))
                Reg.Datasuspenso = null;
            else
                Reg.Datasuspenso = Convert.ToDateTime(SuspensaoLabel.Text);
            if (gtiCore.IsEmptyDate(ReativaLabel.Text))
                Reg.Datareativa = null;
            else
                Reg.Datareativa = Convert.ToDateTime(ReativaLabel.Text);
            if (gtiCore.IsEmptyDate(ArquivaLabel.Text))
                Reg.Dataarquiva = null;
            else
                Reg.Dataarquiva = Convert.ToDateTime(ArquivaLabel.Text);
            if (gtiCore.IsEmptyDate(CancelaLabel.Text))
                Reg.Datacancel = null;
            else
                Reg.Datacancel = Convert.ToDateTime(CancelaLabel.Text);
            Reg.Interno = Internocheckbox.Checked ? true : false;
            Reg.Fisico = Fisicocheckbox.Checked ? true : false;
            Reg.Codassunto = Convert.ToInt16(AssuntoText.Tag.ToString());
            Reg.Userid = Convert.ToInt32( AtendenteLabel.Tag.ToString());
            CustomListBoxItem selectedData = (CustomListBoxItem)OrigemCombo.SelectedItem;
            Reg.Origem = Convert.ToInt16(selectedData._value);
            if (OrigemCombo.SelectedIndex == 0) {
                Reg.Centrocusto = Convert.ToInt32(CCustoCombo.SelectedValue);
                Reg.Codcidadao = 0;
            } else {
                Reg.Centrocusto = 0;
                Reg.Codcidadao = Convert.ToInt32(CodCidadaoLabel.Text);
            }

            Exception ex;
            Processo_bll processo_Class = new Processo_bll(_connection);
            if (bAddNew) {
                Reg.Hora = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00");
                Reg.Ano = (short)DateTime.Now.Year;
                Reg.Numero = processo_Class.Retorna_Numero_Disponivel(DateTime.Now.Year);
                _ano_processo = Reg.Ano;
                _numero_processo = Reg.Numero;
                ex = processo_Class.Incluir_Processo(Reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                    return ex;
                } else {
                    bExec = false;
                    NumProcText.Text = $"{ _numero_processo}-{processo_Class.DvProcesso(_numero_processo)}/{_ano_processo}";
                    bExec = true;
                }
                Reg.Tipoend = ComOption.Checked ? "C" : "R";
            } else {
                ex = processo_Class.Alterar_Processo(Reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                } else {
                    ControlBehaviour(true);
                }
            }
            return null;
        }

        private Exception Grava_Endereco() {
            List<Processoend> ListaEndereco = new List<Processoend>();
            foreach (ListViewItem item in EnderecoListView.Items) {
                Processoend regEnd = new Processoend {
                    Ano=_ano_processo,
                    Numprocesso=_numero_processo,
                    Codlogr = Convert.ToInt16(item.SubItems[1].Text),
                    Numero = item.SubItems[2].Text
                };
                ListaEndereco.Add(regEnd);
            }

            Processo_bll processo_Class = new Processo_bll(_connection);
            Exception ex = processo_Class.Incluir_Processo_Endereco(ListaEndereco,_ano_processo,_numero_processo);
            if (ex != null) {
                ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                eBox.ShowDialog();
            }
            return ex;
        }

        private Exception Grava_Documento() {
            List<Processodoc> ListaDoc = new List<Processodoc>();
            foreach (ListViewItem item in DocListView.Items) {
                Processodoc reg = new Processodoc {
                    Ano = _ano_processo,
                    Numero = _numero_processo,
                    Coddoc = Convert.ToInt16(item.SubItems[1].Text)
                };
                if (!string.IsNullOrWhiteSpace(item.SubItems[2].Text))
                    reg.Data = Convert.ToDateTime(item.SubItems[2].Text);
                
                ListaDoc.Add(reg);
            }

            Processo_bll processo_Class = new Processo_bll(_connection);
            Exception ex = processo_Class.Incluir_Processo_Documento(ListaDoc, _ano_processo, _numero_processo);
            if (ex != null) {
                ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                eBox.ShowDialog();
            }
            return ex;
        }

        #endregion

        #region Print Routines

        private void BtPrintDoc_Click(object sender, EventArgs e)
        {
            if (Doc1Check.Checked)
                PrintProcessoRequerente();
            if (Doc2Check.Checked)
                PrintRequerimento(true);
            if (Doc3Check.Checked)
                PrintComunicadoDoc();
            if (Doc4Check.Checked)
                PrintComprovanteDoc();
            if (Doc5Check.Checked)
                PrintRequerimento(false);
        }

        private void PrintProcessoRequerente()
        {
            gtiCore.Ocupado(this);
            String sReportName = "ProcessoRequerente";
            dsProcessoRequerente Ds = new dsProcessoRequerente();
            DataTable dTable = new dsProcessoRequerente.dtProcessoRequerenteDataTable();
            DataRow dRow = dTable.NewRow();

            Processo_bll clsProcesso = new Processo_bll(_connection);
            short Ano_Processo = clsProcesso.ExtractAnoProcesso(NumProcText.Text);
            int Num_Processo = clsProcesso.ExtractNumeroProcessoNoDV(NumProcText.Text);

            ProcessoStruct Reg = clsProcesso.Dados_Processo(Ano_Processo, Num_Processo);
            dRow["AnoProcesso"] = Ano_Processo;
            dRow["NumProcesso"] = Num_Processo;
            dRow["Seq"] = 1;
            dRow["NumeroProcesso"] = string.Format("{0}-{1}/{2}", Num_Processo, clsProcesso.DvProcesso(Num_Processo), Ano_Processo);
            dRow["Assunto"] = Reg.Assunto;
            dRow["DataEntrada"] = DateTime.Parse(Reg.DataEntrada.ToString()).ToString("dd/MM/yyyy");

            Cidadao_bll clsCidadao = new Cidadao_bll(_connection);
            CidadaoStruct Reg2 = clsCidadao.LoadReg((int)Reg.CodigoCidadao);

            dRow["Requerente"] = Reg2.Nome;
            if (!string.IsNullOrEmpty(Reg2.Cnpj))
                dRow["Documento"] = Convert.ToUInt64(Reg2.Cnpj).ToString(@"00\.000\.000\/0000\-00");
            else {
                if (!string.IsNullOrEmpty(Reg2.Cpf))
                    dRow["Documento"] = Convert.ToUInt64(Reg2.Cpf).ToString(@"000\.000\.000\-00");
                else
                    dRow["Documento"] = Reg2.Rg;
            }
            if (ResOption.Checked) {
                dRow["Endereco"] = Reg2.EnderecoR + " " + Reg2.NumeroR;
                dRow["Bairro"] = Reg2.NomeBairroR;
                dRow["Cidade"] = Reg2.NomeCidadeR;
                dRow["UF"] = Reg2.UfR;
            } else {
                dRow["Endereco"] = Reg2.EnderecoC + " " + Reg2.NumeroC;
                dRow["Bairro"] = Reg2.NomeBairroC;
                dRow["Cidade"] = Reg2.NomeCidadeC;
                dRow["UF"] = Reg2.UfC;
            }
            dTable.Rows.Add(dRow);
            Ds.Tables.Add();

            gtiCore.Liberado(this);
            Report f1 = new Forms.Report(sReportName, Ds, 1, true, null) {
                Tag = this.Name
            };
            f1.ShowDialog();

        }

        private void PrintRequerimento(bool bAbertura)
        {
            gtiCore.Ocupado(this);
            string sReportName;
            if (bAbertura)
                sReportName = "RequerimentoAbertura";
            else
                sReportName = "RequerimentoCancelamento";
            dsProcessoRequerente Ds = new dsProcessoRequerente();
            DataTable dTable = new dsProcessoRequerente.dtProcessoRequerenteDataTable();

            Processo_bll clsProcesso = new Processo_bll(_connection);
            short Ano_Processo = clsProcesso.ExtractAnoProcesso(NumProcText.Text);
            int Num_Processo = clsProcesso.ExtractNumeroProcessoNoDV(NumProcText.Text);
            ProcessoStruct Reg = clsProcesso.Dados_Processo(Ano_Processo, Num_Processo);
            int nSeq = 1;
            if (Reg.ListaProcessoEndereco.Count == 0) {
                ProcessoEndStruct RegTmp = new ProcessoEndStruct {
                    NomeLogradouro = ""
                };
                Reg.ListaProcessoEndereco.Add(RegTmp);
            }
            foreach (var item in Reg.ListaProcessoEndereco) {
                DataRow dRow = dTable.NewRow();
                if (!string.IsNullOrEmpty(item.NomeLogradouro))
                    dRow["EnderecoOcorrencia"] = nSeq.ToString() + ") " + item.NomeLogradouro + " " + item.Numero;
                dRow["AnoProcesso"] = Ano_Processo;
                dRow["NumProcesso"] = Num_Processo;
                dRow["Seq"] = nSeq;
                dRow["NumeroProcesso"] = string.Format("{0}-{1}/{2}", Num_Processo, clsProcesso.DvProcesso(Num_Processo), Ano_Processo);
                dRow["Assunto"] = Reg.Complemento;

                Cidadao_bll clsCidadao = new Cidadao_bll(_connection);
                CidadaoStruct Reg2 = clsCidadao.LoadReg((int)Reg.CodigoCidadao);
                dRow["Requerente"] = Reg2.Nome;
                if (!string.IsNullOrEmpty(Reg2.Cnpj))
                    dRow["Documento"] = Convert.ToUInt64(Reg2.Cnpj).ToString(@"00\.000\.000\/0000\-00");
                else {
                    if (!string.IsNullOrEmpty(Reg2.Cpf))
                        dRow["Documento"] = Convert.ToUInt64(Reg2.Cpf).ToString(@"000\.000\.000\-00");
                    else
                        dRow["Documento"] = Reg2.Rg;
                }
                if (ResOption.Checked) {
                    dRow["Endereco"] = Reg2.EnderecoR + " " + Reg2.NumeroR;
                    dRow["Bairro"] = Reg2.NomeBairroR;
                    dRow["Cidade"] = Reg2.NomeCidadeR;
                    dRow["UF"] = Reg2.UfR;
                } else {
                    dRow["Endereco"] = Reg2.EnderecoC + " " + Reg2.NumeroC;
                    dRow["Bairro"] = Reg2.NomeBairroC;
                    dRow["Cidade"] = Reg2.NomeCidadeC;
                    dRow["UF"] = Reg2.UfC;
                }
                dRow["RG"] = Reg2.Rg + " " + Reg2.Orgao;
                dRow["INSCRICAO"] = Reg.Inscricao;
                dRow["OBSERVACAO"] = Reg.Observacao;

                dTable.Rows.Add(dRow);
                nSeq++;
            }

            Ds.Tables.Add(dTable);
            gtiCore.Liberado(this);
            Report f1 = new Report(sReportName, Ds, 1, true, null) {
                Tag = this.Name
            };
            f1.ShowDialog();

        }

        private void PrintComunicadoDoc()
        {
            gtiCore.Ocupado(this);
            String sNumProc, sNome, sAssunto, sDoc, sData;
            String sReportName = "ComunicadoDoc";
            dsProcessoDoc Ds = new dsProcessoDoc();
            DataTable dTable = new dsProcessoDoc.dtProcessoDocDataTable();

            Processo_bll clsProcesso = new Processo_bll(_connection);
            short Ano_Processo = clsProcesso.ExtractAnoProcesso(NumProcText.Text);
            int Num_Processo = clsProcesso.ExtractNumeroProcessoNoDV(NumProcText.Text);
            ProcessoStruct Reg = clsProcesso.Dados_Processo(Ano_Processo, Num_Processo);

            Cidadao_bll clsCidadao = new Cidadao_bll(_connection);
            CidadaoStruct Reg2 = clsCidadao.LoadReg((int)Reg.CodigoCidadao);

            if (!string.IsNullOrEmpty(Reg2.Cnpj))
                sDoc = Convert.ToUInt64(Reg2.Cnpj).ToString(@"00\.000\.000\/0000\-00");
            else {
                if (!string.IsNullOrEmpty(Reg2.Cpf))
                    sDoc = Convert.ToUInt64(Reg2.Cpf).ToString(@"000\.000\.000\-00");
                else
                    sDoc = Reg2.Rg;
            }
            sNumProc = string.Format("{0}-{1}/{2}", Num_Processo, clsProcesso.DvProcesso(Num_Processo), Ano_Processo);
            sNome = Reg.NomeCidadao;
            sAssunto = Reg.Complemento;
            sData = DateTime.Parse(Reg.DataEntrada.ToString()).ToString("dd/MM/yyyy");
            foreach (var Item in Reg.ListaProcessoDoc) {
                if (Item.DataEntrega == null) {
                    DataRow dRow = dTable.NewRow();
                    dRow["Codigo"] = Item.CodigoDocumento;
                    dRow["Nome"] = Item.NomeDocumento;
                    dTable.Rows.Add(dRow);
                }
            }
            Ds.Tables.Add(dTable);
            ReportParameter p1 = new ReportParameter("prmProcesso", sNumProc);
            ReportParameter p2 = new ReportParameter("prmNome", sNome);
            ReportParameter p3 = new ReportParameter("prmAssunto", sAssunto);
            ReportParameter p4 = new ReportParameter("prmDataEntrada", sData);
            ReportParameter p5 = new ReportParameter("prmDoc", sDoc);
            gtiCore.Liberado(this);
            Report f1 = new Report(sReportName, Ds, 1, true, new ReportParameter[] { p1, p2, p3, p4, p5 }) {
                Tag = this.Name
            };
            f1.ShowDialog();

        }

        private void PrintComprovanteDoc()
        {
            gtiCore.Ocupado(this);
            String sReportName = "ComprovanteDoc";
            dsProcessoDoc Ds = new dsProcessoDoc();
            DataTable dTable = new dsProcessoDoc.dtProcessoDocDataTable();
            String sNumProc, sNome, sAssunto, sDoc, sData;

            Processo_bll clsProcesso = new Processo_bll(_connection);
            short Ano_Processo = clsProcesso.ExtractAnoProcesso(NumProcText.Text);
            int Num_Processo = clsProcesso.ExtractNumeroProcessoNoDV(NumProcText.Text);
            ProcessoStruct Reg = clsProcesso.Dados_Processo(Ano_Processo, Num_Processo);

            Cidadao_bll clsCidadao = new Cidadao_bll(_connection);
            CidadaoStruct Reg2 = clsCidadao.LoadReg((int)Reg.CodigoCidadao);

            if (!string.IsNullOrEmpty(Reg2.Cnpj))
                sDoc = Convert.ToUInt64(Reg2.Cnpj).ToString(@"00\.000\.000\/0000\-00");
            else {
                if (!string.IsNullOrEmpty(Reg2.Cpf))
                    sDoc = Convert.ToUInt64(Reg2.Cpf).ToString(@"000\.000\.000\-00");
                else
                    sDoc = Reg2.Rg;
            }
            sNumProc = string.Format("{0}-{1}/{2}", Num_Processo, clsProcesso.DvProcesso(Num_Processo), Ano_Processo);
            sNome = Reg.NomeCidadao;
            sAssunto = Reg.Complemento;
            sData = DateTime.Parse(Reg.DataEntrada.ToString()).ToString("dd/MM/yyyy");
            foreach (var Item in Reg.ListaProcessoDoc) {
                if (Item.DataEntrega != null) {
                    DataRow dRow = dTable.NewRow();
                    dRow["Codigo"] = Item.CodigoDocumento;
                    dRow["Nome"] = Item.NomeDocumento;
                    dRow["DataEntrega"] = DateTime.Parse(Item.DataEntrega.ToString()).ToString("dd/MM/yyyy");
                    dTable.Rows.Add(dRow);
                }
            }

            Ds.Tables.Add(dTable);
            ReportParameter p1 = new ReportParameter("prmProcesso", sNumProc);
            ReportParameter p2 = new ReportParameter("prmNome", sNome);
            ReportParameter p3 = new ReportParameter("prmAssunto", sAssunto);
            ReportParameter p4 = new ReportParameter("prmDataEntrada", sData);
            ReportParameter p5 = new ReportParameter("prmDoc", sDoc);
            gtiCore.Liberado(this);
            Forms.Report f1 = new Report(sReportName, Ds, 1, true, new ReportParameter[] { p1, p2, p3, p4, p5 }) {
                Tag = this.Name
            };
            f1.ShowDialog();

        }

        #endregion

        #region Endereco

        private void BtAddEndereco_Click(object sender, EventArgs e)     {
            GTI_Models.Models.Endereco reg = new GTI_Models.Models.Endereco {
                Id_pais = 1,
                Sigla_uf = "SP",
                Id_cidade = 413
            };
            Forms.Endereco f1 = new Forms.Endereco(reg, true, false, true, false);
            f1.ShowDialog();

            if (!String.IsNullOrEmpty(f1.EndRetorno.Nome_logradouro.Trim())) {
                bool bFind = false;
                foreach (ListViewItem item in EnderecoListView.Items) {
                    if (item.SubItems[1].Text == f1.EndRetorno.Id_logradouro.ToString() && item.SubItems[2].Text == f1.EndRetorno.Numero_imovel.ToString()) {
                        bFind = true;
                        break;
                    }
                }
                if (bFind)
                    MessageBox.Show("Endereço já incluso na lista.", "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    ListViewItem lvi = new ListViewItem(f1.EndRetorno.Nome_logradouro);
                    lvi.SubItems.Add(f1.EndRetorno.Id_logradouro.ToString());
                    lvi.SubItems.Add(f1.EndRetorno.Numero_imovel.ToString());
                    EnderecoListView.Items.Add(lvi);
                    int s = EnderecoListView.Items.Count;
                }
            }
        }

        private void BtDelEndereco_Click(object sender, EventArgs e)
        {
            if (EnderecoListView.SelectedItems.Count == 0)
                MessageBox.Show("Selecione um endereço", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                int nIndex = EnderecoListView.SelectedItems[0].Index;
                EnderecoListView.Items.RemoveAt(nIndex);
            }
        }

        #endregion

        #region Documento

        private void BtDocumentoEdit_Click(object sender, EventArgs e)
        {
            if (bAddNew) {
                
                if (AssuntoCombo.SelectedIndex==-1)
                    MessageBox.Show("Selecione o assunto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    if (DocListView.Items.Count > 0) goto Jump;
                    List<ProcessoDocStruct> ListaProcessoDoc = new List<ProcessoDocStruct>();
                    Processo_bll processo_Class = new Processo_bll(_connection);
                    List<AssuntoDocStruct> ListaDoc = new List<AssuntoDocStruct>();
                    
                    ListaDoc = processo_Class.Lista_Assunto_Documento(Convert.ToInt16( AssuntoCombo.SelectedValue));
                    foreach (AssuntoDocStruct item in ListaDoc) {
                        ProcessoDocStruct reg = new ProcessoDocStruct {
                            CodigoDocumento = item.Codigo,
                            NomeDocumento = item.Nome
                        };
                        ListaProcessoDoc.Add(reg);
                    }

                    foreach (var item in ListaProcessoDoc) {
                        ListViewItem lvi = new ListViewItem(item.NomeDocumento);
                        lvi.SubItems.Add(item.CodigoDocumento.ToString());
                        lvi.SubItems.Add("");
                        DocListView.Items.Add(lvi);
                    }
Jump:;
                    bExec = false;
                    GetButtonState();
                    LockForm();
                    DocPanel.Show();
                    DocPanel.BringToFront();
                    GravarButton.Enabled = false;
                    CancelarButton.Enabled = false;
                    bExec = true;
                }
            } else {
                bExec = false;
                GetButtonState();
                LockForm();
                DocPanel.Show();
                DocPanel.BringToFront();
                GravarButton.Enabled = false;
                CancelarButton.Enabled = false;
                bExec = true;
            }
            UpdateDocNumber();
        }

        private void BtCancelDoc_Click(object sender, EventArgs e)
        {
            UnlockForm();
            PrintPanel.Visible = false;
            DocumentoEditButton.Enabled = true;
        }

        private void BtCancelPnlDoc_Click(object sender, EventArgs e)
        {
            UnlockForm();
            SetButtonState();
            UpdateDocNumber();
            DocPanel.Hide();
        }

        private void LvDoc_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!bExec) return;
            if (e.NewValue == CheckState.Checked) {
                inputBox iBox = new inputBox();
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                string title = textInfo.ToTitleCase(DocListView.Items[e.Index].Text.ToLower()); //War And Peace
                String sData = iBox.Show(DateTime.Now.ToString("dd/MM/yyyy"), title, "Digite a data de entrada do documento", 10);
                if (string.IsNullOrEmpty(sData))
                    e.NewValue = CheckState.Unchecked;
                else {
                    if (DateTime.TryParse(sData, out DateTime result)) {
                        if (result.Year < 1920 || result.Year > DateTime.Now.Year) {
                            MessageBox.Show("Data inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.NewValue = CheckState.Unchecked;
                        } else
                            DocListView.Items[e.Index].SubItems[2].Text = result.ToString("dd/MM/yyyy");
                    } else {
                        MessageBox.Show("Data inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.NewValue = CheckState.Unchecked;
                    }
                }
            } else
                DocListView.Items[e.Index].SubItems[2].Text = "";
        }

        #endregion

        private void GuiaButton_Click(object sender, EventArgs e) {

        }
    }

}
