using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static GTI_Desktop.Classes.GtiTypes;

namespace GTI_Desktop.Forms {
    public partial class Cnae : Form {
        string _connection = gtiCore.Connection_Name();
        public List<CnaeStruct> Lista_Cnae{ get; set; }
        public CnaeStruct Return_Cnae { get; set; }

        public Cnae() {
            InitializeComponent();
        }

        private void Cnae_Load(object sender, EventArgs e) {
            if (Tag.ToString() == "Empresa_Cnae") {
                var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Empresa_Cnae);
                Location = new Point(frm.Location.X + 50, frm.Location.Y + 50);
            }
            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            Lista_Cnae = empresa_Class.Lista_Cnae();
            Carrega_Lista();
        }

        private void Carrega_Lista() {
            MainListView.Items.Clear();

            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            List<Cnaecriteriodesc> Lista_Cnae_Criterio = empresa_Class.Lista_Cnae_Criterio();
            List<CustomListBoxItem4> myItems = new List<CustomListBoxItem4>();
            foreach (Cnaecriteriodesc item in Lista_Cnae_Criterio) {
                myItems.Add(new CustomListBoxItem4(item.Descricao, item.Criterio,(decimal)item.Valor));
            }
            CriterioList.DisplayMember = "_name";
            CriterioList.ValueMember = "_value";
            CriterioList.DataSource = myItems;

            if (Busca.Text != "") {
                if (gtiCore.IsNumeric(Busca.Text.Substring(0, 1))) {
                    var Lista_Filter_Cnae = Lista_Cnae.Where(c => c.CNAE.Contains(Busca.Text));
                    foreach (CnaeStruct item in Lista_Filter_Cnae) {
                        ListViewItem lvItem = new ListViewItem(item.CNAE);
                        lvItem.SubItems.Add(item.Descricao);
                        MainListView.Items.Add(lvItem);
                    }
                } else {
                    var Lista_Filter_Nome = Lista_Cnae.Where(c => c.Descricao.Contains(Busca.Text));
                    foreach (CnaeStruct item in Lista_Filter_Nome) {
                        ListViewItem lvItem = new ListViewItem(item.CNAE);
                        lvItem.SubItems.Add(item.Descricao);
                        MainListView.Items.Add(lvItem);
                    }
                }
            } else {
                foreach (CnaeStruct item in Lista_Cnae) {
                    ListViewItem lvItem = new ListViewItem(item.CNAE);
                    lvItem.SubItems.Add(item.Descricao);
                    MainListView.Items.Add(lvItem);
                }
            }
        }

        private void SelectButton_Click(object sender, EventArgs e) {
            if(MainListView.SelectedItems.Count==0)
                MessageBox.Show("Selecione ao menos 1 Cnae.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                ListViewItem item = MainListView.SelectedItems[0];
                Return_Cnae = new CnaeStruct {
                    CNAE = item.Text,
                    Descricao = item.SubItems[1].Text
                };
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Busca_TextChanged(object sender, EventArgs e) {
            Carrega_Lista();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            Return_Cnae = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CriterioList_SelectedIndexChanged(object sender, EventArgs e) {
            if (CriterioList.SelectedIndex == -1) return;
            CustomListBoxItem4 item = (CustomListBoxItem4)CriterioList.SelectedItem;
            ValorText.Text = item._value2.ToString("#0.00");
        }

        private void btCC1_Click(object sender, EventArgs e) {
            if (CriterioList.SelectedIndex == -1) return;
            if (MainListView.SelectedItems.Count == 0) return;
            CustomListBoxItem4 item = (CustomListBoxItem4)CriterioList.SelectedItem;
            bool _find = false;
            foreach (ListViewItem lv in CriterioListView.Items) {
                if(Convert.ToInt32(lv.Text) == item._value) {
                    _find = true;
                    break;
                }
            }
            if (!_find) {
                string _cnae =gtiCore.RetornaNumero( MainListView.SelectedItems[0].Text);

                Empresa_bll empresa_Class = new Empresa_bll(_connection);
                Cnae_criterio reg = new Cnae_criterio {
                    Cnae =_cnae,
                    Criterio=item._value
                };
                Exception ex = empresa_Class.Incluir_Cnae_Criterio(reg);
                if (ex == null) {
                    ListViewItem lv = new ListViewItem(item._value.ToString());
                    lv.SubItems.Add(item._name);
                    lv.SubItems.Add(item._value2.ToString("#0.00"));
                    CriterioListView.Items.Add(lv);
                } else {
                    ErrorBox eBox = new ErrorBox("Atenção", "Erro de inclusão.", ex);
                    eBox.ShowDialog();
                }
            } else
                MessageBox.Show("Critério já incluso na lista.", "Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void btCC2_Click(object sender, EventArgs e) {
            if (CriterioListView.Items.Count == 0) return;
            if (CriterioListView.SelectedItems.Count > 0) {
                ListViewItem item = MainListView.SelectedItems[0];
                string _cnae = item.Text;
                int _criterio = Convert.ToInt32(CriterioListView.SelectedItems[0].Text);
                Empresa_bll empresa_Class = new Empresa_bll(_connection);
                Exception ex = empresa_Class.Excluir_Cnae_Criterio(_cnae, _criterio);
                if (ex == null) 
                    CriterioListView.SelectedItems[0].Remove();
                else {
                    ErrorBox eBox = new ErrorBox("Não é possível excluir", "Atividade em uso.", ex);
                    eBox.ShowDialog();
                }
            }
        }

        private void Carregar_Criterio_Cnae(string _cnae) {
            CriterioListView.Items.Clear();
            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            List<CnaecriterioStruct> Lista = empresa_Class.Lista_Cnae_Criterio(_cnae);
            foreach (CnaecriterioStruct item in Lista) {
                ListViewItem lv = new ListViewItem(item.Criterio.ToString());
                lv.SubItems.Add(item.Descricao);
                lv.SubItems.Add(item.Valor.ToString("#0.00"));
                CriterioListView.Items.Add(lv);
            }
        }

        private void MainListView_SelectedIndexChanged(object sender, EventArgs e) {
            if (MainListView.SelectedItems.Count > 0) {
                string _cnae = gtiCore.RetornaNumero( MainListView.SelectedItems[0].Text);
                Carregar_Criterio_Cnae(_cnae);
            }
        }
    }

}
