using GTI_Desktop.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace GTI_Desktop.Forms {

    public partial class SelectForm : Form {

        public List<GtiTypes.CustomListBoxItem2> Lista_Retorno { get; set; }

        public SelectForm(List<GtiTypes.CustomListBoxItem2> Lista) {
            InitializeComponent();
            FillList(Lista);
        }

        private void FillList(List<GtiTypes.CustomListBoxItem2> Lista) {
            LstMain.DisplayMember = "_name";
            LstMain.ValueMember = "_value";
            LstMain.DataSource = Lista;
            for (int i = 0; i < LstMain.Items.Count; i++) {
                GtiTypes.CustomListBoxItem2 item = (GtiTypes.CustomListBoxItem2)LstMain.Items[i];
                LstMain.SetItemChecked(i, item._ativo);
            }
        }

        private void BtSair_Click(object sender, EventArgs e) {
            Lista_Retorno = new List<GtiTypes.CustomListBoxItem2>();
            for (int i = 0; i < LstMain.Items.Count; i++) {
                GtiTypes.CustomListBoxItem2 item = (GtiTypes.CustomListBoxItem2)LstMain.Items[i];
                GtiTypes.CustomListBoxItem2 item2 = new GtiTypes.CustomListBoxItem2(item._name, item._value, LstMain.GetItemChecked(i));
                Lista_Retorno.Add(item2);
            }

            Close();
        }

        private void BtAll_Click(object sender, EventArgs e) {
            for (int i = 0; i < LstMain.Items.Count; i++) {
                LstMain.SetItemChecked(i, true);
            }
        }

        private void BtNone_Click(object sender, EventArgs e) {
            for (int i = 0; i < LstMain.Items.Count; i++) {
                LstMain.SetItemChecked(i, false);
            }
        }

    }

}
