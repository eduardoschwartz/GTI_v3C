using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Desktop.Forms;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using static GTI_Desktop.Classes.GtiTypes;

namespace GTI_Desktop.User_Controls {
    public partial class ctlTributoEditor : UserControl {
        private IWindowsFormsEditorService _editorService = null;
        string _connection = gtiCore.Connection_Name();

        public ctlTributoEditor(IWindowsFormsEditorService editorService) {
            InitializeComponent();
            _editorService = editorService;
            ControlBehaviour(true);
            Tributario_bll clsTributario = new Tributario_bll(_connection);
            List<GTI_Models.Models.Tributo> Lista = clsTributario.Lista_Tributo();

            List<CustomListBoxItem3> myItems = new List<CustomListBoxItem3>();
            foreach (GTI_Models.Models.Tributo item in Lista) {
                myItems.Add(new CustomListBoxItem3(item.Desctributo, item.Codtributo,item.Abrevtributo));
            }

            cmbTributo.DataSource = myItems;
            cmbTributo.DisplayMember = "_name";
            cmbTributo.ValueMember = "_value";

            foreach(SpExtrato reg in Parcela_Edit._lista_tributo) {
                ListViewItem item = new ListViewItem(reg.Codtributo.ToString("00"));
                item.SubItems.Add(reg.Abrevtributo);
                item.SubItems.Add(reg.Valortributo.ToString("#0.00"));
                lvTrib.Items.Add(item);
            }
            if (lvTrib.Items.Count > 0)
                lvTrib.Items[0].Selected = true;
        }

        private void btSair_Click(object sender, EventArgs e) {
            _editorService.CloseDropDown();
        }

        private void ControlBehaviour(bool bStart) {
            btAdd.Enabled = bStart;
            btEdit.Enabled = bStart;
            btDel.Enabled = bStart;
            btExit.Enabled = bStart;
            btGravar.Enabled = !bStart;
            btCancelar.Enabled = !bStart;
            txtValor.ReadOnly = bStart;
            cmbTributo.Enabled = false;
        }

        private void btAdd_Click(object sender, EventArgs e) {
            ControlBehaviour(false);
            cmbTributo.Enabled = true;
        }

        private void btEdit_Click(object sender, EventArgs e) {
            //TODO: Falta rotina de alteração dos tributos
            ControlBehaviour(false);
        }

        private void btGravar_Click(object sender, EventArgs e) {
            //TODO: Falta rotina de gravação de novos tributos
            ControlBehaviour(true);

        }

        private void btCancelar_Click(object sender, EventArgs e) {
            ControlBehaviour(true);
        }

        private void lvTrib_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvTrib.SelectedItems.Count > 0) {
                cmbTributo.SelectedValue = Convert.ToInt32(lvTrib.SelectedItems[0].Text);
                txtValor.Text = lvTrib.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void btDel_Click(object sender, EventArgs e) {
            //TODO: Falta rotina de exclusão dos tributos
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }
    }
}
