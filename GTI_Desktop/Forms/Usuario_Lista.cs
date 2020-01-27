using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Usuario_Lista : Form {
        string _connection = gtiCore.Connection_Name();
        private ListViewColumnSorter lvwColumnSorter;
        List<usuarioStruct> Lista;
        public int ReturnValue { get; set; }

        public Usuario_Lista() {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            MainListView.ListViewItemSorter = lvwColumnSorter;
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            Lista = sistema_Class.Lista_Usuarios();
            CarregaLista();
        }

        private void CarregaLista() {
            MainListView.Items.Clear();
            foreach (usuarioStruct item in Lista) {
                if (BuscaTextBox.Text != "") {
                    string sText = BuscaTextBox.Text;
                    string sSetor = item.Nome_setor ?? "";
                    if (!item.Nome_completo.Contains(sText) && !item.Nome_login.Contains(sText) && !sSetor.Contains(sText))
                        goto Proximo;
                }
                if (AtivoCheckBox.Checked && item.Ativo == 0)
                    goto Proximo;
                ListViewItem lvItem = new ListViewItem(Convert.ToInt32(item.Id).ToString("0000"));
                lvItem.SubItems.Add(item.Nome_completo);
                lvItem.SubItems.Add(item.Nome_login);
                lvItem.SubItems.Add(item.Nome_setor);
                MainListView.Items.Add(lvItem);
Proximo:;
            }
        }

        private void ReturnButton_Click(object sender, System.EventArgs e) {
            int nRet = 0;
            if (MainListView.Items.Count > 0) {
                if (MainListView.SelectedItems.Count > 0) {
                    nRet = Convert.ToInt32(MainListView.SelectedItems[0].Text);
                } else {
                    MessageBox.Show("Selecione um item.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            } else {
                MessageBox.Show("Selecione um item.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReturnValue = nRet;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BuscaTextBox_TextChanged(object sender, EventArgs e) {
            CarregaLista();
        }

        private void MainListView_ColumnClick(object sender, ColumnClickEventArgs e) {
            if (e.Column == lvwColumnSorter.SortColumn) {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                    lvwColumnSorter.Order = SortOrder.Descending;
                else
                    lvwColumnSorter.Order = SortOrder.Ascending;
            } else {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            MainListView.Sort();
        }

        private void AtivoCheckBox_CheckedChanged(object sender, EventArgs e) {
            CarregaLista();
        }

        private void MainListView_DoubleClick(object sender, EventArgs e) {
            ReturnButton_Click(null, null);
        }

        private void MainListView_KeyPress(object sender, KeyPressEventArgs e) {
            if(e.KeyChar==(char)Keys.Enter)
                ReturnButton_Click(null, null);
        }
    }
}
