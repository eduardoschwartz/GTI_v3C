using System;
using System.Windows.Forms;
using GTI_Bll.Classes;
using GTI_Models.Models;
using GTI_Desktop.Classes;
using System.Collections.Generic;
using GTI_Desktop.Properties;
using GTI_Models;

namespace GTI_Desktop.Forms {
    public partial class Profissao : Form {

        string _connection = gtiCore.Connection_Name();

        public Profissao() {
            InitializeComponent();
        }

        private void BtExit_Click(object sender, EventArgs e) {
            this.Close();
        }
        
        private void Carrega_Lista() {
            lstMain.DataSource = null;
            gtiCore.Ocupado(this);
            Cidadao_bll profissao_class = new Cidadao_bll(_connection);
            List<GTI_Models.Models.Profissao> lista = profissao_class.Lista_Profissao();
            lstMain.DataSource = lista;
            lstMain.DisplayMember = "Nome";
            lstMain.ValueMember = "Codigo";
            gtiCore.Liberado(this);
        }

        private void BtAdd_Click(object sender, EventArgs e) {
            inputBox iBox = new inputBox();
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroProfissao_Alterar);
            if (!bAllow) {
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String sCod = iBox.Show("", "Informação", "Digite o nome da profissão.", 100);
            if (!string.IsNullOrEmpty(sCod)) {
                Cidadao_bll profissao_class = new Cidadao_bll(_connection);
                GTI_Models.Models.Profissao reg = new GTI_Models.Models.Profissao {
                    Nome = sCod.ToUpper()
                };
                Exception ex = profissao_class.Incluir_Profissao(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", "Profissão já cadastrada.", ex);
                    eBox.ShowDialog();
                } else
                    Carrega_Lista();
            }
        }

        private void BtEdit_Click(object sender, EventArgs e) {
            if (lstMain.SelectedItem == null) return;
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroProfissao_Alterar);
            if (!bAllow) {
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            inputBox iBox = new inputBox();
            String sCod = iBox.Show(lstMain.Text, "Informação", "Digite o nome da profissão.", 100);
            if (!string.IsNullOrEmpty(sCod)) {
                Cidadao_bll profissao_class = new Cidadao_bll(_connection);
                GTI_Models.Models.Profissao reg = new GTI_Models.Models.Profissao {
                    Codigo = Convert.ToInt16(lstMain.SelectedValue.ToString()),
                    Nome = sCod.ToUpper()
                };
                Exception ex = profissao_class.Alterar_Profissao(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", "Profissão já cadastrada.", ex);
                    eBox.ShowDialog();
                } else
                    Carrega_Lista();
            }
        }

        private void BtDel_Click(object sender, EventArgs e) {
            if (lstMain.SelectedItem == null) return;
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroProfissao_Alterar);
            if (!bAllow) {
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Excluir esta profissão?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Cidadao_bll profissao_class = new Cidadao_bll(_connection);
                GTI_Models.Models.Profissao reg = new GTI_Models.Models.Profissao {
                    Codigo = Convert.ToInt16(lstMain.SelectedValue.ToString())
                };
                Exception ex = profissao_class.Excluir_Profissao(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                } else
                    Carrega_Lista();
            }
        }

        private void LstMain_DoubleClick(object sender, EventArgs e) {
            if (lstMain.SelectedItem == null) return;
            btEdit.PerformClick();
        }

        private void Profissao_Load(object sender, EventArgs e) {
            Carrega_Lista();
        }
    }
}
