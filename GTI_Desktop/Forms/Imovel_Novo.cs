using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static GTI_Desktop.Classes.GtiTypes;

namespace GTI_Desktop.Forms {
    public partial class Imovel_Novo : Form {

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
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
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

        public string ReturnInscricao { get; set; }
        public string ReturnCondominio { get; set; }
        public int ReturnCondominioCodigo { get; set; }
        string _connection = gtiCore.Connection_Name();
        List<Condominiounidade> Condominios = new List<Condominiounidade>();
        List<GTI_Models.Models.Condominio> lista_condominios = new List<GTI_Models.Models.Condominio>();

        public Imovel_Novo() {
            m_aeroEnabled = false;
            this.Refresh();
            InitializeComponent();
            tBar.Renderer = new MySR();
            Imovel_bll imovel_Class = new Imovel_bll(_connection);
            lista_condominios = imovel_Class.Lista_Condominio();
            TipoList.Items.Add(new CustomListBoxItem("(Imóvel normal)", 0));
            List<CustomListBoxItem> myItems = new List<CustomListBoxItem>();
            foreach (GTI_Models.Models.Condominio item in lista_condominios) {
                TipoList.Items.Add(new CustomListBoxItem(item.Cd_nomecond, item.Cd_codigo));
            }
            TipoList.SelectedIndex = 0;
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e) {
            int distrito = 0, setor = 0, quadra = 0, lote = 0, face = 0, unidade = 0, subunidade = 0;
            string s = Inscricao.Text;
            try {
                distrito = Int32.Parse(s.Substring(0, 1));
            } catch {
                MessageBox.Show("Distrito inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try {
                setor = Int32.Parse(s.Substring(2, 2));
            } catch {
                MessageBox.Show("Setor inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try {
                quadra = Int32.Parse(s.Substring(5, 4));
            } catch {
                MessageBox.Show("Quadra inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try {
                lote = Int32.Parse(s.Substring(10, 5));
            } catch {
                MessageBox.Show("Lote inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try {
                face = Int32.Parse(s.Substring(16, 2));
            } catch {
                MessageBox.Show("Face inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try {
                unidade = Int32.Parse(s.Substring(19, 2));
            } catch {
                MessageBox.Show("Unidade inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try {
                subunidade = Int32.Parse(s.Substring(22, 3));
            } catch {
                MessageBox.Show("SubUnidade inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lote > 10000) {
                MessageBox.Show("Nº de lote inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TipoList.SelectedIndex==0 && (unidade>0 || subunidade > 0)) {
                MessageBox.Show("Imóvel normal não pode ter número de unidade ou subunidade", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Imovel_bll imovel_Class = new Imovel_bll(_connection);
            int nCodigo = imovel_Class.Existe_Imovel(distrito, setor, quadra, lote, unidade, subunidade);
            if (nCodigo>0) {
                MessageBox.Show("Já existe um imóvel com esta inscrição cadastral (" + nCodigo.ToString("000000") + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
               bool ExisteFace = imovel_Class.Existe_Face_Quadra(distrito, setor, quadra, face);
                if (!ExisteFace) {
                    MessageBox.Show("Face de quadra não cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    CustomListBoxItem _condominio = (CustomListBoxItem)TipoList.SelectedItem;
                    DialogResult = DialogResult.OK;
                    ReturnInscricao = Inscricao.Text;
                    if (TipoList.SelectedIndex == 0) {
                        ReturnCondominio = "[NÃO CADASTRADO]";
                        ReturnCondominioCodigo = 0;
                    } else {
                        ReturnCondominio = _condominio._name;
                        ReturnCondominioCodigo = _condominio._value;
                    }

                    Close();
                }
            }
        }

        private void TipoList_SelectedIndexChanged(object sender, EventArgs e) {
            UnidadeList.Items.Clear();
            SubUnidadeList.Items.Clear();
            if (TipoList.SelectedItem != null) {
                if (TipoList.SelectedIndex > 0) {
                    UnidadeList.Enabled = true;
                    SubUnidadeList.Enabled = true;
                    Inscricao.ReadOnly = true;
                    CustomListBoxItem item = (CustomListBoxItem)TipoList.SelectedItem;
                    Imovel_bll imovel_Class = new Imovel_bll(_connection);
                    Condominios = imovel_Class.Lista_Unidade_Condominio(item._value);
                    foreach (Condominiounidade Unidade in Condominios) {
                        UnidadeList.Items.Add(Unidade.Cd_unidade.ToString("00"));
                    }
                    if (UnidadeList.Items.Count > 0)
                        UnidadeList.SelectedIndex = 0;
                } else{
                    UnidadeList.Enabled = false;
                    SubUnidadeList.Enabled = false;
                    Inscricao.ReadOnly = false;
                    Inscricao.Text = "";
                    Inscricao.Focus();
                }
            }
        }

        private void UnidadeList_SelectedIndexChanged(object sender, EventArgs e) {
            for (int i = 0; i < Condominios.Count; i++) {
                if(Convert.ToInt32( Condominios[i].Cd_unidade)==Convert.ToInt32(UnidadeList.Text)) {
                    int nQtdeSub = Condominios[i].Cd_subunidades;
                    for (int q = 0; q < nQtdeSub; q++) {
                        SubUnidadeList.Items.Add((q + 1).ToString("000"));
                    }
                    if (SubUnidadeList.Items.Count > 0)
                        SubUnidadeList.SelectedIndex = 0;
                    Carrega_Inscricao();
                    break;
                }
            }
        }

        private void Carrega_Inscricao() {
            CustomListBoxItem item = (CustomListBoxItem)TipoList.SelectedItem;
            Imovel_bll imovel_Class = new Imovel_bll(_connection);
            for (int i = 0; i < lista_condominios.Count; i++) {
                if (lista_condominios[i].Cd_codigo == item._value) {
                    StringBuilder sInscricao = new StringBuilder();
                    sInscricao.Append(lista_condominios[i].Cd_distrito.ToString() + ".");
                    sInscricao.Append(lista_condominios[i].Cd_setor.ToString("00") + ".");
                    sInscricao.Append(lista_condominios[i].Cd_quadra.ToString("0000") + ".");
                    sInscricao.Append(lista_condominios[i].Cd_lote.ToString("00000") + ".");
                    sInscricao.Append(lista_condominios[i].Cd_seq.ToString("00") + ".");
                    sInscricao.Append(UnidadeList.Text + ".");
                    sInscricao.Append(SubUnidadeList.Text);
                    Inscricao.Text = sInscricao.ToString();
                    break;
                }
            }
        }

        private void SubUnidadeList_SelectedIndexChanged(object sender, EventArgs e) {
            Carrega_Inscricao();
        }



    }
}
