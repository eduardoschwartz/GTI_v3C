using System;
using System.Windows.Forms;
using GTI_Bll.Classes;
using GTI_Models.Models;
using GTI_Desktop.Classes;
using GTI_Desktop.Properties;
using System.Collections.Generic;

namespace GTI_Desktop.Forms {
    public partial class Processo_Documento : Form {

        string _connection = gtiCore.Connection_Name();

        public Processo_Documento() {
            InitializeComponent();
            Carrega_Lista();
        }

        private void BtExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Carrega_Lista() {
            gtiCore.Ocupado(this);
            Processo_bll processo_class = new Processo_bll(_connection);
            List<Documento> lista = processo_class.Lista_Documento();
            lstMain.DataSource = lista;
            lstMain.DisplayMember = "nome";
            lstMain.ValueMember = "codigo";
            gtiCore.Liberado(this);
        }

        private void BtAdd_Click(object sender, EventArgs e) {
            inputBox iBox = new inputBox();
            String sCod = iBox.Show("", "Informação", "Digite o nome do Documento.", 40);
            if (!string.IsNullOrEmpty(sCod)) {
                Processo_bll processo_class = new Processo_bll(_connection);
                Documento reg = new Documento {
                    Nome = sCod.ToUpper()
                };
                Exception ex = processo_class.Incluir_Documento(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", "Documento já cadastrado.", ex);
                    eBox.ShowDialog();
                } else
                    Carrega_Lista();
            }
        }

        private void BtEdit_Click(object sender, EventArgs e) {
            if (lstMain.SelectedItem == null) return;
            inputBox iBox = new inputBox();
            String sCod = iBox.Show(lstMain.Text, "Informação", "Digite o nome do Documento.", 50);
            if (!string.IsNullOrEmpty(sCod)) {
                Processo_bll processo_class = new Processo_bll(_connection);
                Documento reg = new Documento();
                Documento dRow = (Documento)lstMain.SelectedItem;
                reg.Codigo = dRow.Codigo;
                reg.Nome = sCod.ToUpper();
                Exception ex = processo_class.Alterar_Documento(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", "Documento já cadastrado.", ex);
                    eBox.ShowDialog();
                } else
                    Carrega_Lista();
            }
        }

        private void BtDel_Click(object sender, EventArgs e) {
            if (lstMain.SelectedItem == null) return;
            if (MessageBox.Show("Excluir este Documento?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Processo_bll processo_class = new Processo_bll(_connection);
                Documento reg = new Documento();
                Documento dRow = (Documento)lstMain.SelectedItem;
                reg.Codigo = dRow.Codigo;
                Exception ex = processo_class.Excluir_Documento(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", "Não foi possível excluir este Documento, consulte o detalhe para mais informações.", ex);
                    eBox.ShowDialog();
                } else
                    Carrega_Lista();
            }
        }

        private void LstMain_DoubleClick(object sender, EventArgs e) {
            if(lstMain.SelectedItem == null) return;
                btEdit.PerformClick();
        }
    }
}
