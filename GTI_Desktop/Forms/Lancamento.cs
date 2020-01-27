using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Desktop.Properties;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static GTI_Desktop.Classes.GtiTypes;

namespace GTI_Desktop.Forms {
    public partial class Lancamento : Form {
        string _connection = gtiCore.Connection_Name();
        List<GTI_Models.Models.Lancamento> Lista = new List<GTI_Models.Models.Lancamento>();
        bool bAddNew;

        private  struct StrLancamento {
            public int _codigo;
            public string _nome;

            private StrLancamento(int Codigo, string Nome) {
                _codigo = Codigo;
                _nome = Nome;
            }
        }

        public Lancamento() {
            InitializeComponent();
            bAddNew = false;
            ControlBehaviour(true);
            Carrega_Lista();
        }

        private void Carrega_Lista() {
            Tributario_bll clsTributario = new Tributario_bll(_connection);
            Lista = clsTributario.Lista_Lancamento();
            cmbLivro.DataSource = clsTributario.Lista_Tipo_Livro();
            cmbLivro.DisplayMember = "desctipo";
            cmbLivro.ValueMember = "codtipo";

            List<StrLancamento> Lista2 = new List<StrLancamento>();
            foreach (var item in Lista) {
                StrLancamento reg = new StrLancamento {
                    _codigo = item.Codlancamento,
                    _nome = item.Descfull
                };
                Lista2.Add(reg);
            }

            List<CustomListBoxItem> myItems = new List<CustomListBoxItem>();
            foreach (StrLancamento item in Lista2) {
                myItems.Add(new CustomListBoxItem(item._nome, item._codigo));
            }
            lstMain.DataSource = myItems;
            lstMain.DisplayMember = "_name";
            lstMain.ValueMember = "_value";

        }


        private void LstMain_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstMain.SelectedItems.Count > 0)
                LoadReg();
        }

        private void LoadReg() {
            CustomListBoxItem Itens = (CustomListBoxItem)lstMain.SelectedItem;
            int nCodigo = Itens._value;
            txtCompleto.Text = lstMain.Text;
            foreach (GTI_Models.Models.Lancamento item in Lista) {
                if (item.Codlancamento == nCodigo) {
                    txtResumido.Text = item.Descreduz;
                    cmbLivro.SelectedValue =item.Tipolivro==null||item.Tipolivro==0?-1: item.Tipolivro;
                    break;
                }
            }
        }

        private void ControlBehaviour(bool bStart) {
            btAdd.Enabled = bStart;
            btEdit.Enabled = bStart;
            btDel.Enabled = bStart;
            btExit.Enabled = bStart;
            btGravar.Enabled = !bStart;
            btCancelar.Enabled = !bStart;
            lstMain.Enabled = bStart;
            txtCompleto.ReadOnly = bStart;
            txtResumido.ReadOnly = bStart;
            cmbLivro.Enabled = !bStart;
        }

        private void Clear_Reg() {
            txtCompleto.Text = "";
            txtResumido.Text = "";
            cmbLivro.SelectedIndex = -1;
        }

        private void BtAdd_Click(object sender, EventArgs e) {
            bAddNew = true;
            Clear_Reg();
            ControlBehaviour(false);
            txtCompleto.Focus();
        }

        private void BtEdit_Click(object sender, EventArgs e) {
            if (lstMain.SelectedItems.Count==0)
                MessageBox.Show("Selecione um lançamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                bAddNew = false;
                ControlBehaviour(false);
            }
        }

        private void SaveReg() {
            GTI_Models.Models.Lancamento reg = new GTI_Models.Models.Lancamento {
                Descfull = txtCompleto.Text,
                Descreduz = txtResumido.Text,
                Tipolivro = Convert.ToInt16(cmbLivro.SelectedValue)
            };
            Tributario_bll clsTributario = new Tributario_bll(_connection);
            Exception ex;
            if (bAddNew) {
                ex = clsTributario.Insert_Lancamento(reg);
            } else {
                reg.Codlancamento = Convert.ToInt16(lstMain.SelectedValue);
                ex = clsTributario.Alterar_Lancamento(reg);
            }
            if (ex != null) {
                ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                eBox.ShowDialog();
            } else {
                Carrega_Lista();
                ControlBehaviour(true);
            }
        }

        private void BtGravar_Click(object sender, EventArgs e) {
            SaveReg();
        }

        private void BtCancelar_Click(object sender, EventArgs e) {
            ControlBehaviour(true);
            if (lstMain.SelectedItems.Count > 0)
                lstMain.SetSelected(lstMain.SelectedIndex, true);
            else
                lstMain.SetSelected(0, true);
        }

        private void BtExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BtDel_Click(object sender, EventArgs e) {
            if (lstMain.SelectedItem == null) return;
            if (MessageBox.Show("Excluir este lançamento?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Tributario_bll clsTributario = new Tributario_bll(_connection);
                GTI_Models.Models.Lancamento reg = new GTI_Models.Models.Lancamento {
                    Codlancamento = Convert.ToInt16(lstMain.SelectedValue.ToString())
                };
                Exception ex = clsTributario.Excluir_Lancamento(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                } else
                    Carrega_Lista();
            }
        }
    }
}
