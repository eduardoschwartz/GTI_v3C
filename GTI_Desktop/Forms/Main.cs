using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace GTI_Desktop.Forms
{
    public partial class Main : Form
    {
        string _connection = gtiCore.Connection_Name();
        private const int CP_NOCLOSE_BUTTON = 0x200;

        protected override CreateParams CreateParams {
            get {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public Main()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            DateTimePicker t = new DateTimePicker
            {
                AutoSize = false,
                Width = 100,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Name = "sbDataBase",
            };
            TopBarToolStrip.Renderer = new MySR();
            t.CloseUp += new System.EventHandler(SbDataBase_CloseUp);

            BarStatus.Items.Insert(17, new ToolStripControlHost(t));
            MaquinaToolStripStatus.Text = Environment.MachineName;
            DataBaseToolStripStatus.Text = Properties.Settings.Default.DataBaseReal;

        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.Refresh();

            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            FillBackgroundImage(false);

            ServidorToolStripStatus.Text = Properties.Settings.Default.ServerName;

            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            VersaoToolStripStatus.Text = $"{version.Major}"+"."+ $"{version.Minor}" +"."+ $"{version.Build}";
            this.Text += VersaoToolStripStatus.Text;

            LockForm(true);
            Forms.Login login = new Forms.Login();
            login.ShowDialog();
        }

        private void CorFundo()
        {
            MdiClient ctlMDI;

            foreach (Control ctl in this.Controls)
            {
                try
                {
                    ctlMDI = (MdiClient)ctl;
                    ctlMDI.BackColor = this.BackColor;
                    //ctlMDI.BackgroundImage = Properties.Resources.GTI_logo;

                }
                catch
                {
                }
            }
        }

        private void SbDataBase_CloseUp(object sender, EventArgs e)
        {
            MessageBox.Show(ReturnDataBaseValue().ToString());
        }

        public DateTime ReturnDataBaseValue()
        {
            DateTime dValue = DateTime.Today;

            DateTimePicker dbox;
            foreach (Control c in BarStatus.Controls)
            {
                if (c is DateTimePicker)
                {
                    dbox = c as DateTimePicker;
                    dValue = dbox.Value.Date;
                }
            }
            return dValue;
        }

        public void LockForm(bool bLocked)
        {
            foreach (ToolStripItem ts in TopBarToolStrip.Items)
            {
                ts.Enabled = !bLocked;
            }

            List<ToolStripMenuItem> mItems = gtiCore.GetItems(this.MenuBarStrip);
            foreach (var item in mItems)
            {
                item.Enabled = !bLocked;
            }
            Dv1Option.Enabled = !bLocked;
            Dv2Option.Enabled = !bLocked;
            DVText.ReadOnly = bLocked;
            DVLabel.Enabled = !bLocked;
            lblDV2.Enabled = !bLocked;
            DV3label.Enabled = !bLocked;
        }

        public void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void BtSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja fechar todas as janelas e retornar a tela de login?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form[] charr = this.MdiChildren;
                foreach (Form chform in charr)
                {
                    chform.Close();
                }
                LockForm(true);
                Forms.Login login = new Forms.Login();
                login.ShowDialog();
            }
        }

        private void MnuConfig_Click(object sender, EventArgs e)
        {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Config);
            if (formToShow != null)
            {
                formToShow.Show();
            }
            else
            {
                Forms.Config f1 = new Forms.Config
                {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
                f1.BringToFront();
            }
        }

        private void BtConfig_Click(object sender, EventArgs e)
        {
            MnuConfig_Click(sender, e);
        }

        private void BaseRealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] charr = this.MdiChildren;
            foreach (Form chform in charr)
                chform.Close();

            FillBackgroundImage(false);
            DataBaseToolStripStatus.Text = Properties.Settings.Default.DataBaseReal;
            gtiCore.UpdateUserBinary();
            this.Refresh();
        }

        private void BaseDeTestesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] charr = this.MdiChildren;
            foreach (Form chform in charr)
                chform.Close();

            FillBackgroundImage(true);
            DataBaseToolStripStatus.Text = Properties.Settings.Default.DataBaseTeste;
            gtiCore.UpdateUserBinary();
            this.Refresh();
        }

        private void FillBackgroundImage(bool bTeste)
        {
            Bitmap img = bTeste ? Properties.Resources.rosa : Properties.Resources.bege;
            Color cor = bTeste ? Color.FromArgb(250, 218, 226) : Color.OldLace;
            this.BackgroundImage = img;
            BarStatus.BackgroundImage = img;
            LedGreen.BackgroundImage = img;
            LedRed.BackgroundImage = img;
            VersaotoolStripStatusLabel.BackgroundImage = img;
            VersaoToolStripStatus.BackgroundImage = img;
            UsuariotoolStripStatusLabel.BackgroundImage = img;
            UserToolStripStatus.BackgroundImage = img;
            ServidorToolStripStatus.BackgroundImage = img;
            ServidortoolStripStatusLabel.BackgroundImage = img;
            DataBaseToolStripStatus.BackgroundImage = img;
            DataBasetoolStripStatusLabel.BackgroundImage = img;
            MaquinaToolStripStatus.BackgroundImage = img;
            MaquinatoolStripStatusLabel.BackgroundImage = img;
            NomeBaseDadostoolStripStatusLabel.BackgroundImage = img;
            Div1.BackColor = cor;
            Div2.BackColor = cor;
            Div3.BackColor = cor;
            Div4.BackColor = cor;
            Div5.BackColor = cor;
            MenuBarStrip.BackColor = cor;
            TopBarToolStrip.BackColor = cor;
            PanelDV.BackColor = cor;
            PanelDV.GradientEndColor = cor;
        }

        private void BtCidadao_Click(object sender, EventArgs e)
        {
            MnuCidadao_Click(sender, e);
        }

        private void MnuCidadao_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroCidadao);
            if (bAllow)
            {
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Cidadao);
                if (formToShow != null)
                {
                    formToShow.Show();
                }
                else
                {
                    Cidadao f1 = new Cidadao
                    {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
            }
            else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DocumentaçãoParaProcessosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Processo_Documento);
            if (formToShow != null)
            {
                formToShow.Show();
            }
            else
            {
                Processo_Documento f1 = new Processo_Documento
                {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
            }
        }

        private void DespachosDosTrâmitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Processo_Despacho);
            if (formToShow != null)
            {
                formToShow.Show();
            }
            else
            {
                Processo_Despacho f1 = new Processo_Despacho
                {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
            }
        }

        private void AssuntosDoProcessoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Processo_Assunto);
            if (formToShow != null)
            {
                formToShow.Show();
            }
            else
            {
                Processo_Assunto f1 = new Processo_Assunto
                {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
            }
        }

        private void LocalDeTramitaçãoDeProcessosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Processo_Local);
            if (formToShow != null)
            {
                formToShow.Show();
            }
            else
            {
                Processo_Local f1 = new Processo_Local
                {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
            }
        }

        private void MinimizarTodasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] charr = this.MdiChildren;
            foreach (Form chform in charr)
                chform.WindowState = FormWindowState.Minimized;
        }

        private void RestaurarTodasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] charr = this.MdiChildren;
            foreach (Form chform in charr)
                chform.WindowState = FormWindowState.Normal;
        }

        private void FecharTodasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] charr = this.MdiChildren;
            foreach (Form chform in charr)
                chform.Close();
        }

        private void EmCascataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void LadoALadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void ControleDeProcessosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BtProtocolo_Click(object sender, EventArgs e)
        {
            MnuControleProcesso_Click(sender, e);
        }

        private void MnuControleProcesso_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroProcesso);
            if (bAllow)
            {

                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Processo);
                if (formToShow != null)
                {
                    formToShow.Show();
                }
                else
                {
                    Processo f1 = new Processo
                    {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
            }
            else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MnuCadImob_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroImovel);
            if (bAllow)
            {
                gtiCore.Ocupado(this);
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Imovel);
                if (formToShow != null)
                {
                    formToShow.Show();
                }
                else
                {
                    Imovel f1 = new Imovel
                    {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
                gtiCore.Liberado(this);
            }
            else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtImobiliario_Click(object sender, EventArgs e)
        {
            MnuCadImob_Click(null, null);
        }

        private void TxtDV_TextChanged(object sender, EventArgs e)
        {
            if (DVText.Text == "")
                DVLabel.Text = "X";
            else
                DVLabel.Text = RetornaDV().ToString();
        }

        private void TxtDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private short RetornaDV()
        {
            short ret = 0;
            if (DVText.Text == "") DVText.Text = "0";
            int Numero = Convert.ToInt32(DVText.Text);
            if (Dv1Option.Checked)
            {
                Processo_bll clsProcesso = new Processo_bll(_connection);
                ret = Convert.ToInt16(clsProcesso.DvProcesso(Numero));
            }
            else
            {
                Tributario_bll clsTributario = new Tributario_bll(_connection);
                ret = Convert.ToInt16(clsTributario.DvDocumento(Numero));
            }

            return ret;
        }

        private void OptDv1_CheckedChanged(object sender, EventArgs e)
        {
            DVLabel.Text = RetornaDV().ToString();
            DVText.Focus();
        }

        private void OptDv2_CheckedChanged(object sender, EventArgs e)
        {
            DVLabel.Text = RetornaDV().ToString();
            DVText.Focus();
        }

        private void TxtDV_Enter(object sender, EventArgs e)
        {
            DVText.SelectionStart = 0;
            DVText.SelectionLength = DVText.Text.Length;
        }

        private void MnuCadastroLancamento_Click(object sender, EventArgs e)
        {
            gtiCore.Ocupado(this);
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Lancamento);
            if (formToShow != null)
            {
                formToShow.Show();
            }
            else
            {
                Lancamento f1 = new Lancamento
                {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
            }
            gtiCore.Liberado(this);
        }

        private void MnuTributos_Click(object sender, EventArgs e)
        {
            gtiCore.Ocupado(this);
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Tributo);
            if (formToShow != null)
            {
                formToShow.Show();
            }
            else
            {
                Tributo f1 = new Tributo
                {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
            }
            gtiCore.Liberado(this);
        }

        private void MnuExtrato_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.ExtratoContribuinte);
            if (bAllow)
            {
                gtiCore.Ocupado(this);
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Extrato);
                if (formToShow != null)
                {
                    formToShow.Show();
                }
                else
                {
                    Extrato f1 = new Extrato
                    {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
                gtiCore.Liberado(this);
            }
            else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtExtrato_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.ExtratoContribuinte);
            if (bAllow) 
                MnuExtrato_Click(null, null);
             else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MnuEmpresa_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroEmpresa);
            if (bAllow)
            {
                gtiCore.Ocupado(this);
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Empresa);
                if (formToShow != null)
                {
                    formToShow.Show();
                }
                else
                {
                    Empresa f1 = new Empresa
                    {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
                gtiCore.Liberado(this);
            }
            else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtMobiliario_Click(object sender, EventArgs e)
        {
            MnuEmpresa_Click(null, null);
        }

        private void CadastroEventoMenu_Click(object sender, EventArgs e)
        {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.SecurityEventForm);
            if (formToShow != null)
            {
                formToShow.Show();
            }
            else
            {
                Forms.SecurityEventForm f1 = new Forms.SecurityEventForm
                {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
                f1.BringToFront();
            }
        }

        private void AtribuicaoAcessoMenu_Click(object sender, EventArgs e)
        {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.SecurityUserForm);
            if (formToShow != null)
            {
                formToShow.Show();
            }
            else
            {
                Forms.SecurityUserForm f1 = new Forms.SecurityUserForm
                {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
                f1.BringToFront();
            }
        }

        private void CadastroUsuario_Click(object sender, EventArgs e)
        {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Usuario);
            if (formToShow != null)
            {
                formToShow.Show();
            }
            else
            {
                Forms.Usuario f1 = new Forms.Usuario
                {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
                f1.BringToFront();
            }
        }

        private void CadastroUsuarioMenu_Click(object sender, EventArgs e)
        {
            CadastroUsuario_Click(null, null);
        }

        private void EventosDoSistemaMenu_Click(object sender, EventArgs e)
        {
            CadastroEventoMenu_Click(null, null);
        }

        private void AtribuicaoDeAcessoMenu_Click(object sender, EventArgs e)
        {
            AtribuicaoAcessoMenu_Click(null, null);
        }

        private void EscritorioContabilMenu_Click(object sender, EventArgs e)
        {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Escritorio_Contabil);
            if (formToShow != null)
            {
                formToShow.Show();
            }
            else
            {
                Forms.Escritorio_Contabil f1 = new Forms.Escritorio_Contabil
                {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
                f1.BringToFront();
            }
        }

        private void CadastroCondominioMenu_Click(object sender, EventArgs e)
        {

            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroCondominio);
            if (bAllow)
            {
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Condominio);
                if (formToShow != null)
                {
                    formToShow.Show();
                }
                else
                {
                    Forms.Condominio f1 = new Forms.Condominio
                    {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                    f1.BringToFront();
                }
            }
            else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CertidaoButton_Click(object sender, EventArgs e)
        {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Certidao);
            if (formToShow != null)
            {
                formToShow.Show();
            }
            else
            {
                Certidao f1 = new Certidao
                {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
                f1.BringToFront();
            }
        }

        private void CadastroBairroMenu_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroBairro);
            if (bAllow)
            {
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Bairro);
                if (formToShow != null)
                {
                    formToShow.Show();
                }
                else
                {
                    Forms.Bairro f1 = new Forms.Bairro
                    {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
            }
            else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CadastroPaisMenu_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroPais);
            if (bAllow)
            {
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Pais);
                if (formToShow != null)
                {
                    formToShow.Show();
                }
                else
                {
                    Pais f1 = new Pais
                    {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
            }
            else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CadastroProfissaoMenu_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroProfissao);
            if (bAllow)
            {
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Profissao);
                if (formToShow != null)
                {
                    formToShow.Show();
                }
                else
                {
                    Profissao f1 = new Profissao
                    {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
            }
            else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CartaCobrancaMenu_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.Carta_Cobranca);
            if (bAllow)
            {
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Carta_Cobranca);
                if (formToShow != null)
                {
                    formToShow.Show();
                }
                else
                {
                    Carta_Cobranca f1 = new Carta_Cobranca
                    {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
            }
            else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RegistroBancarioMenu_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.Registro_Bancario);
            if (bAllow)
            {
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Registro_Bancario);
                if (formToShow != null)
                {
                    formToShow.Show();
                }
                else
                {
                    Registro_Bancario f1 = new Registro_Bancario
                    {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
            }
            else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ProcessoAtrasoMenu_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.Registro_Bancario);
            if (bAllow)
            {
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Processo_Atraso);
                if (formToShow != null)
                {
                    formToShow.Show();
                }
                else
                {
                    Processo_Atraso f1 = new Processo_Atraso
                    {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
            }
            else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AtividadeEmpresaMenu_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.Atividade_Empresa);
            if (bAllow)
            {
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Empresa_Atividade);
                if (formToShow != null)
                {
                    formToShow.Show();
                }
                else
                {
                    Empresa_Atividade f1 = new Empresa_Atividade(0,false)
                    {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
            }
            else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CalculoImpostoMenu_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.Calculo_Imposto);
            if (bAllow)
            {
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Calculo_Imposto);
                if (formToShow != null)
                {
                    formToShow.Show();
                }
                else
                {
                    Calculo_Imposto f1 = new Calculo_Imposto()
                    {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
            }
            else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ComunicadoIsencaoMenu_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.Comunicado_Isencao);
            if (bAllow)
            {
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Comunicado_Isencao);
                if (formToShow != null)
                {
                    formToShow.Show();
                }
                else
                {
                    Comunicado_Isencao f1 = new Comunicado_Isencao()
                    {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
            }
            else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ConsultaDocButton_Click(object sender, EventArgs e)
        {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.Consulta_documento);
            if (bAllow)
            {
                Documento_Detalhe f1 = new Documento_Detalhe();
                f1.ShowDialog();
            }
            else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TabelaCnaeMenu_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.Atividade_Empresa);
            if (bAllow) {
                Cnae f1 = new Cnae() {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EmissaoGuiaButton_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.ExtratoContribuinte);
            if (bAllow)
                EmissaoGuiaMenu_Click(null, null);
            else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EmissaoGuiaMenu_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.ExtratoContribuinte);
            if (bAllow) {
                gtiCore.Ocupado(this);
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Emissao_Guia);
                if (formToShow != null) {
                    formToShow.Show();
                } else {
                    Emissao_Guia f1 = new Emissao_Guia {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
                gtiCore.Liberado(this);
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }//end class
}
