using System;
using System.Windows.Forms;
using GTI_Bll.Classes;
using GTI_Models.Models;
using GTI_Desktop.Classes;
using GTI_Desktop.Properties;
using System.Collections.Generic;
using GTI_Models;

namespace GTI_Desktop.Forms {
    public partial class Pais : Form {

          string _connection = gtiCore.Connection_Name();

        public Pais() {
            InitializeComponent();
            Carrega_Lista();
        }

        private void BtExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Carrega_Lista() {
            gtiCore.Ocupado(this);
            Endereco_bll endereco_class = new Endereco_bll(_connection);
            List<GTI_Models.Models.Pais> lista = endereco_class.Lista_Pais();
            lstMain.DataSource = lista;
            lstMain.DisplayMember = "Nome_pais";
            lstMain.ValueMember = "Id_pais";
            gtiCore.Liberado(this);
        }

        private void BtAdd_Click(object sender, EventArgs e) {
            inputBox iBox = new inputBox();

            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroPais_Alterar);
            if (!bAllow) {
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String sCod = iBox.Show("", "Informação", "Digite o nome do país.", 40);
            if (!string.IsNullOrEmpty(sCod)) {
                Endereco_bll endereco_class = new Endereco_bll(_connection);
                GTI_Models.Models.Pais reg = new GTI_Models.Models.Pais {
                    Nome_pais = sCod.ToUpper()
                };
                Exception ex = endereco_class.Incluir_Pais(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", "País já cadastrado.", ex);
                    eBox.ShowDialog();
                } else
                    Carrega_Lista();
            }
        }

        private void BtEdit_Click(object sender, EventArgs e) {
            if (lstMain.SelectedItem == null) return;
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroPais_Alterar);
            if (!bAllow) {
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            inputBox iBox = new inputBox();
            String sCod = iBox.Show(lstMain.Text, "Informação", "Digite o nome do país.", 50);
            if (!string.IsNullOrEmpty(sCod)) {
                Endereco_bll endereco_class = new Endereco_bll(_connection);
                GTI_Models.Models.Pais reg = new GTI_Models.Models.Pais {
                    Id_pais = Convert.ToInt16(lstMain.SelectedValue.ToString()),
                    Nome_pais = sCod.ToUpper()
                };
                Exception ex = endereco_class.Alterar_Pais(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", "País já cadastrado.", ex);
                    eBox.ShowDialog();
                } else
                    Carrega_Lista();
            }

        }

        private void BtDel_Click(object sender, EventArgs e) {
            if (lstMain.SelectedItem == null) return;
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroPais_Alterar);
            if (!bAllow) {
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Excluir este país?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Endereco_bll endereco_class = new Endereco_bll(_connection);
                GTI_Models.Models.Pais reg = new GTI_Models.Models.Pais {
                    Id_pais = Convert.ToInt16(lstMain.SelectedValue.ToString())
                };
                Exception ex = endereco_class.Excluir_Pais(reg);
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

    }
}
