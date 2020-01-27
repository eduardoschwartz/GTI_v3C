using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;

namespace GTI_Desktop.Forms {
    public partial class Login : Form {
        
        #region Shadow
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
    (
        int nLeftRect, // x-coordinate of upper-left corner
        int nTopRect, // y-coordinate of upper-left corner
        int nRightRect, // x-coordinate of lower-right corner
        int nBottomRect, // y-coordinate of lower-right corner
        int nWidthEllipse, // height of ellipse
        int nHeightEllipse // width of ellipse
     );

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams {
            get {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        private bool CheckAeroEnabled() {
            if (Environment.OSVersion.Version.Major >= 6) {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m) {
            switch (m.Msg) {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled) {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle,  2, ref v, 4);
                        MARGINS margins = new MARGINS() {
                            bottomHeight = 2,
                            leftWidth = 2,
                            rightWidth = 2,
                            topHeight = 2
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
                m.Result = (IntPtr)HTCAPTION;

        }

        #endregion
                
        public Int32 OriginSize;
        
        public Login() {
            m_aeroEnabled = false;
            this.Refresh();
            InitializeComponent();
            this.Size = new Size(this.Size.Width, 190);
            OriginSize = this.Size.Height;
            LoginToolStrip.Renderer = new MySR();
            txtServer.Text = GTI_Desktop.Properties.Settings.Default.ServerName;
            txtLogin.Text = gtiCore.Retorna_Last_User();
            txtPwd.Focus();
        }

        private void Login_Load(object sender, EventArgs e) {
            String Caminho = Application.StartupPath;
            txtLogin.Text = gtiCore.Retorna_Last_User(); 
        }

        
        private void Login_Activated(object sender, EventArgs e) {
            txtPwd.Focus();
        }
           

        private void BtGravar_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(txtPwd1.Text) || String.IsNullOrEmpty(txtPwd2.Text)) {
                MessageBox.Show("Digite a nova senha e confirme a senha.", "Erro de gravação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                if (string.Compare(txtPwd1.Text, txtPwd2.Text) != 0)
                    MessageBox.Show("Confirmação da senha diferente da senha digitada.", "Erro de gravação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    if (txtPwd1.Text.Length < 6)
                        MessageBox.Show("Senha deve ter no mínimo 6 caracteres.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else {
                        string _connection = gtiCore.Connection_Name();
                        Sistema_bll sistemaClass = new Sistema_bll(_connection);
                        string sPwd =  sistemaClass.Retorna_User_Password(txtLogin.Text);
                        if (!string.IsNullOrEmpty(sPwd) && gtiCore.Decrypt( sPwd) != txtPwd.Text) {
                            MessageBox.Show("Senha atual inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } else {
                            GTI_Models.Models.Usuario reg = new GTI_Models.Models.Usuario {
                                Nomelogin = txtLogin.Text.ToUpper(),
                                Senha2 = gtiCore.Encrypt( txtPwd1.Text)
                            };
                            Exception ex = sistemaClass.Alterar_Senha(reg);
                            if (ex != null) {
                                ErrorBox eBox = new ErrorBox("Atenção", "Erro ao gravar nova senha.", ex);
                                eBox.ShowDialog();
                            } else {
                                MessageBox.Show("Senha alterada.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtLogin.Enabled = true;
                                SenhaButton.Enabled = true;
                                LoginButton.Enabled = true;
                                SairButton.Enabled = true;
                                txtPwd.Text = txtPwd1.Text;
                                this.Size = new Size(this.Size.Width, OriginSize);
                            }
                        }
                    }
                }
            }
        }

        private void BtCancelar_Click(object sender, EventArgs e) {
            SenhaButton_Click(sender, e);
        }

        private void SenhaButton_Click(object sender, EventArgs e) {
            if (this.Size.Height < 300) {
                txtPwd1.Text = "";
                txtPwd2.Text = "";
                txtLogin.Enabled = false;
                SenhaButton.Enabled = false;
                LoginButton.Enabled = false;
                SairButton.Enabled = false;
                this.Size = new Size(this.Size.Width, 321);
            } else {
                txtLogin.Enabled = true;
                SenhaButton.Enabled = true;
                LoginButton.Enabled = true;
                SairButton.Enabled = true;
                this.Size = new Size(this.Size.Width, OriginSize);
            }

        }

        private void LoginButton_Click(object sender, EventArgs e) {
            if (txtLogin.Text.Equals(string.Empty)) {
                MessageBox.Show("Digite o nome de login.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPwd.Text.Equals(string.Empty)) {
                MessageBox.Show("Digite a senha.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            gtiCore.Ocupado(this);
            Properties.Settings.Default.ServerName = txtServer.Text;
            Properties.Settings.Default.Save();

            string _connection = gtiCore.Connection_Name();
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            try {
                string sUser = sistema_Class.Retorna_User_FullName( txtLogin.Text);
                gtiCore.Liberado(this);
                if (string.IsNullOrEmpty(sUser)) {
                    gtiCore.Liberado(this);
                    MessageBox.Show("Usuário não cadastrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string sPwd = sistema_Class.Retorna_User_Password(txtLogin.Text);
                if (string.IsNullOrEmpty(sPwd)) {
                    gtiCore.Liberado(this);
                    MessageBox.Show("Por favor cadastre uma senha!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SenhaButton_Click(null, null);
                    return;
                } else {
                    if (string.Compare(txtPwd.Text, gtiCore.Decrypt(sPwd)) != 0) {
                        gtiCore.Liberado(this);
                        MessageBox.Show("Senha inválida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            } catch (Exception ex) {
                gtiCore.Liberado(this);
                MessageBox.Show(ex.InnerException.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GTI_Desktop.Properties.Settings.Default.ServerName = txtServer.Text.ToUpper();
            GTI_Desktop.Properties.Settings.Default.LastUser = txtLogin.Text.ToUpper();
            GTI_Desktop.Properties.Settings.Default.UserId = sistema_Class.Retorna_User_LoginId(txtLogin.Text);
            GTI_Desktop.Properties.Settings.Default.Save();

            int nId = Properties.Settings.Default.UserId;
            usuarioStruct cUser = sistema_Class.Retorna_Usuario(nId);
            int? nSetor = cUser.Setor_atual;
            if (nSetor == null || nSetor == 0) {
                Usuario_Setor form = new Usuario_Setor();
                form.nId = nId;
                var result = form.ShowDialog(this);
                if (result != DialogResult.OK)
                    return;
            }
            gtiCore.UpdateUserBinary();
            //Update user Binary
            //string sTmp = sistema_Class.GetUserBinary(nId);
            //int nSize = sistema_Class.GetSizeofBinary();
            //GtiTypes.UserBinary = gtiCore.Decrypt(sTmp);
            //if (nSize > GtiTypes.UserBinary.Length) {
            //    int nDif = nSize - GtiTypes.UserBinary.Length;
            //    sTmp = new string('0', nDif);
            //    GtiTypes.UserBinary += sTmp;
            //}
       //     string h = GtiTypes.UserBinary;
            Close();
            Main f1 = (Main)Application.OpenForms["Main"];
            f1.UserToolStripStatus.Text = gtiCore.Retorna_Last_User();
            f1.LockForm(false);
            gtiCore.Liberado(this);
        }

        private void SairButton_Click(object sender, EventArgs e) {
            Main f1 = (Main)Application.OpenForms["Main"];
            FormClosingEventArgs e1 = new FormClosingEventArgs(CloseReason.MdiFormClosing, true);
            if (MessageBox.Show("Sair do sistema?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                f1.Main_FormClosing(null, e1);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch (keyData) {
                case Keys.Enter:
                    LoginButton_Click(null, null);
                    break;
                case Keys.Escape:
                    SairButton_Click(null, null);
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
