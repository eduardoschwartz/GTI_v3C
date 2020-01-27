using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static GTI_Desktop.Classes.GtiTypes;

namespace GTI_Desktop.Forms {
    public partial class Empresa_VS : Form {
        private string _connection = gtiCore.Connection_Name();
        public CnaeStruct Item_VS { get; set; }

        public Empresa_VS(List<CnaeStruct> Lista_Cnae, List<CnaeStruct> Lista_Cnae_VS,bool Read_only) {
            InitializeComponent();
            OkButton.Enabled = !Read_only;

            if (Lista_Cnae == null)
                Lista_Cnae = new List<CnaeStruct>();
            CnaeList.Items.Clear();
            foreach (CnaeStruct item in Lista_Cnae_VS) {
                string reg = item.CNAE + "-" + item.Descricao;
                CnaeList.Items.Add(reg);
            }

            foreach (CnaeStruct item in Lista_Cnae) {
                bool _find = false;
                foreach (CnaeStruct itemvs in Lista_Cnae_VS) {
                    if (itemvs.CNAE == item.CNAE) {
                        _find = true;
                        break;
                    }
                }
                if (!_find) {
                    string reg = item.CNAE + "-" + item.Descricao;
                    CnaeList.Items.Add(reg);
                }
            }
            AdjustWidthComboBox_DropDown(CnaeList, null);
            if (CnaeList.Items.Count > 0) CnaeList.SelectedIndex = 0;
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            Item_VS = null;
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e) {
            if (Qtde.Text == "") Qtde.Text = "0";
            if (CriterioList.Items.Count == 0)
                MessageBox.Show("Selecione um Cnae.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                decimal _valor = Convert.ToDecimal(Valor.Text);
                if (_valor == 0)
                    MessageBox.Show("Selecione um CNAE com valor cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    int _qtde = Convert.ToInt32(Qtde.Text);
                    if (_qtde == 0)
                        MessageBox.Show("Digite a Quantidade.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        CustomListBoxItem4 item = (CustomListBoxItem4)CriterioList.SelectedItem;
                        Item_VS = new CnaeStruct {
                            CNAE = CnaeList.Text.Substring(0, 9),
                            Descricao = CnaeList.Text.Substring(10, CnaeList.Text.Length - 10),
                            Criterio = item._value,
                            Qtde = _qtde,
                            Valor = _valor
                        };
                        Close();
                    }
                }
            }
        }

        private void CnaeList_SelectedIndexChanged(object sender, EventArgs e) {
            if (CnaeList.SelectedIndex > -1) {
                Empresa_bll empresa_Class = new Empresa_bll(_connection);
                string _cnae =  gtiCore.ExtractNumber(CnaeList.Text.Substring(0,9));
                List<CnaecriterioStruct>  ListaCriterio = empresa_Class.Lista_Cnae_Criterio(_cnae);
                List<CustomListBoxItem4> myItems = new List<CustomListBoxItem4>();
                foreach (var item in ListaCriterio) {
                    myItems.Add(new CustomListBoxItem4(item.Descricao, item.Criterio, item.Valor));
                }
                CriterioList.DataSource = myItems;
                CriterioList.DisplayMember = "_name";
                CriterioList.ValueMember = "_value";
                Valor.Text = "0,00";
                if (CriterioList.Items.Count > 0) {
                    CriterioList.SelectedIndex = 0;
                    CriterioList_SelectedIndexChanged(null, null);
                }
            }
        }

        private void AdjustWidthComboBox_DropDown(object sender, System.EventArgs e) {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (string s in ((ComboBox)sender).Items) {
                newWidth = (int)g.MeasureString(s, font).Width
                    + vertScrollBarWidth;
                if (width < newWidth) {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width;
        }

        private void CriterioList_SelectedIndexChanged(object sender, EventArgs e) {
            Valor.Text = "0,00";
            if (CriterioList.SelectedIndex > -1) {
                CustomListBoxItem4 item = (CustomListBoxItem4)CriterioList.SelectedItem;
                Valor.Text = item._value2.ToString("#0.00");
            }
        }

        private void Qtde_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }
    }
}
