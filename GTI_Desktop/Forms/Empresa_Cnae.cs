using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Empresa_Cnae : Form {
        string _connection = gtiCore.Connection_Name();
        public List<CnaeStruct> Lista_Cnae { get; set; }

        public Empresa_Cnae(List<CnaeStruct>Lista_Cnae_Old, List<CnaeStruct> Lista_Cnae_VS,bool Read_Only) {
            InitializeComponent();
            AddButton.Enabled = !Read_Only;
            DelButton.Enabled = !Read_Only;
            CnaeToolStrip.Renderer = new MySR();
            MainListView.Items.Clear();

            //Remove Cnae Duplicado
Inicio:;
            foreach (CnaeStruct itemCnaeVS in Lista_Cnae_VS) {
                foreach (CnaeStruct itemCnae in Lista_Cnae_Old) {
                    if (itemCnaeVS.CNAE == itemCnae.CNAE) {
                        Lista_Cnae_VS.Remove(itemCnaeVS);
                        goto Inicio;
                    }
                }
            }


            foreach (CnaeStruct item in Lista_Cnae_Old) {
                ListViewItem lvItem = new ListViewItem(item.CNAE);
                lvItem.SubItems.Add(item.Descricao);
                lvItem.Checked = item.Principal;
                MainListView.Items.Add(lvItem);
            }
            foreach (CnaeStruct item in Lista_Cnae_VS) {
                ListViewItem lvItem = new ListViewItem(item.CNAE);
                lvItem.SubItems.Add(item.Descricao);
                lvItem.Checked = item.Principal;
                MainListView.Items.Add(lvItem);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            int _count = 0;
            Lista_Cnae = new List<CnaeStruct>();
            if (MainListView.Items.Count > 0) {
                foreach (ListViewItem item in MainListView.Items) {
                    if (item.Checked)
                        _count++;
                }
                if (_count == 0)
                    MessageBox.Show("Selecione um Cnae como principal.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    if (_count > 1)
                        MessageBox.Show("Selecione apenas um Cnae como principal.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        //retorna a lista de Cnaes
                        Empresa_bll empresa_Class = new Empresa_bll(_connection);
                        foreach (ListViewItem item in MainListView.Items) {
                            CnaeStruct reg = empresa_Class.Separa_Cnae(item.Text);
                            reg.Descricao = item.SubItems[1].Text;
                            reg.Principal = item.Checked;
                            Lista_Cnae.Add(reg);
                        }
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            } else {
                Lista_Cnae.Clear() ;
                Close();
            }
        }

        private void AddButton_Click(object sender, EventArgs e) {
            Cnae frm = new Cnae();
            frm.Tag = Name;
            frm.ShowDialog(this);
            if (frm.Return_Cnae != null) {
                bool _find = false;
                for (int i = 0; i < MainListView.Items.Count; i++) {
                    if (MainListView.Items[i].Text == frm.Return_Cnae.CNAE) {
                        _find = true;
                        break;
                    }
                }
                if (_find)
                    MessageBox.Show("Cnae já inserido na lista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    ListViewItem lvItem = new ListViewItem(frm.Return_Cnae.CNAE);
                    lvItem.SubItems.Add(frm.Return_Cnae.Descricao);
                    MainListView.Items.Add(lvItem);
                }
            }
        }

        private void DelButton_Click(object sender, EventArgs e) {
            if(MainListView.SelectedItems.Count==0)
                MessageBox.Show("Selecione um Cnae.","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else {
                MainListView.Items.Remove(MainListView.SelectedItems[0]);
            }
        }
    }
}
