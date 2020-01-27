using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static GTI_Desktop.Classes.GtiTypes;

namespace GTI_Desktop.Forms {
    public partial class Tributo : Form {

        string _connection = gtiCore.Connection_Name();
        List<GTI_Models.Models.Tributo> Lista = new List<GTI_Models.Models.Tributo>();
        bool bAddNew;

        private struct StrTributo {
            public int _codigo;
            public string _nome;

            private StrTributo(int Codigo, string Nome) {
                _codigo = Codigo;
                _nome = Nome;
            }
        }

        public Tributo() {
            InitializeComponent();
            bAddNew = false;
            ControlBehaviour(true);
            Carrega_Lista();
        }

        private void Carrega_Lista() {
            Tributario_bll clsTributario = new Tributario_bll(_connection);
            Lista = clsTributario.Lista_Tributo();
            List<GTI_Models.Models.Tributo> ListaFilter = Lista.Where(c => c.Desctributo.Contains(txtFilter.Text)).ToList();

            List<StrTributo> Lista2 = new List<StrTributo>();
            foreach (var item in ListaFilter) {
                StrTributo reg = new StrTributo {
                    _codigo = item.Codtributo,
                    _nome = item.Desctributo
                };
                Lista2.Add(reg);
            }

            List<CustomListBoxItem> myItems = new List<CustomListBoxItem>();
            foreach (StrTributo item in Lista2) {
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
            foreach (GTI_Models.Models.Tributo item in Lista) {
                if (item.Codtributo == nCodigo) {
                    txtResumido.Text = item.Abrevtributo;
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
        }

        private void Clear_Reg() {
            txtCompleto.Text = "";
            txtResumido.Text = "";
        }

        private void BtAdd_Click(object sender, EventArgs e) {
            bAddNew = true;
            Clear_Reg();
            ControlBehaviour(false);
            txtCompleto.Focus();
        }

        private void BtEdit_Click(object sender, EventArgs e) {
            if (lstMain.SelectedItems.Count == 0)
                MessageBox.Show("Selecione um lançamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                bAddNew = false;
                ControlBehaviour(false);
            }
        }

        private void SaveReg() {
            GTI_Models.Models.Tributo reg = new GTI_Models.Models.Tributo {
                Desctributo = txtCompleto.Text,
                Abrevtributo = txtResumido.Text,
                Da = true
            };
            Tributario_bll clsTributario = new Tributario_bll(_connection);
            Exception ex;
            if (bAddNew) {
                ex = clsTributario.Insert_Tributo(reg);
            } else {
                reg.Codtributo = Convert.ToInt16(lstMain.SelectedValue);
                ex = clsTributario.Alterar_Tributo(reg);
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
            if (MessageBox.Show("Excluir este tributo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Tributario_bll clsTributario = new Tributario_bll(_connection);
                GTI_Models.Models.Tributo reg = new GTI_Models.Models.Tributo {
                    Codtributo = Convert.ToInt16(lstMain.SelectedValue.ToString())
                };
                Exception ex = clsTributario.Excluir_Tributo(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                } else
                    Carrega_Lista();
            }
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e) {
            Carrega_Lista();
        }

    }//end class
}
