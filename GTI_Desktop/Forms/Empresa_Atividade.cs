using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Empresa_Atividade : Form {
        string _connection = gtiCore.Connection_Name();
        public int ReturnValue { get; set; }
        public string ReturnAliquota { get; set; }
        int OriginValue = 0;
        bool bAddNew,_selecionarAliquota;
        ListViewColumnSorter lvwColumnSorter;

        public Empresa_Atividade(int Origin_Value, bool SelecionarAliquota) {
            InitializeComponent();
            OriginValue = Origin_Value;
            _selecionarAliquota = SelecionarAliquota;
            lvwColumnSorter = new ListViewColumnSorter();
            MainListView.ListViewItemSorter = lvwColumnSorter;
            tBar.Renderer = new MySR();
            Carrega_Lista();
            ControlBehaviour(true);
            bAddNew = false;
        }

        private void ControlBehaviour(bool bStart) {
            Color color_disable = !bStart ? Color.White : BackColor;
            AddButton.Enabled = bStart;
            EditButton.Enabled = bStart;
            DelButton.Enabled = bStart;
            SairButton.Enabled = bStart;
            GravarButton.Enabled = !bStart;
            CancelarButton.Enabled = !bStart;
            PrintButton.Enabled = bStart;
            SelecionarButton.Enabled = bStart;
            Codigo.ReadOnly = bStart;
            Codigo.BackColor = color_disable;
            Descricao.ReadOnly = bStart;
            Descricao.BackColor = color_disable;
            Aliquota1.ReadOnly = bStart;
            Aliquota1.BackColor = color_disable;
            Aliquota2.ReadOnly = bStart;
            Aliquota3.BackColor = color_disable;
            Aliquota3.ReadOnly = bStart;
            Aliquota3.BackColor = color_disable;
            MainListView.Enabled = bStart;
        }

        private void ClearReg() {
            Codigo.Text = "";
            Descricao.Text = "";
            Aliquota1.Text = "";
            Aliquota2.Text = "";
            Aliquota3.Text = "";
        }

        private void Aliquota1_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void Aliquota2_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void Aliquota3_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void Carrega_Lista() {
            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            List<Atividade> Lista = empresa_Class.Lista_Atividade();
            foreach (Atividade item in Lista) {
                ListViewItem lvItem = new ListViewItem(item.Codatividade.ToString("00000"));
                lvItem.SubItems.Add(item.Descatividade);
                lvItem.SubItems.Add(string.Format("{0:0.00}", item.Valoraliq1));
                lvItem.SubItems.Add(string.Format("{0:0.00}", item.Valoraliq2));
                lvItem.SubItems.Add(string.Format("{0:0.00}", item.Valoraliq3));
                MainListView.Items.Add(lvItem);
            }
            if(OriginValue==0)
                MainListView.Items[0].Selected = true;
            else {
                for (int i = 0; i < MainListView.Items.Count; i++) {
                    if (Convert.ToInt32(MainListView.Items[i].Text) == OriginValue) {
                        MainListView.Items[i].Selected = true;
                        MainListView_SelectedIndexChanged(null, null);
                        break;
                    }
                }
            }
        }

        private void MainListView_SelectedIndexChanged(object sender, EventArgs e) {
            if (MainListView.SelectedItems.Count > 0) {
                Codigo.Text = MainListView.SelectedItems[0].Text;
                Descricao.Text = MainListView.SelectedItems[0].SubItems[1].Text;
                Aliquota1.Text = MainListView.SelectedItems[0].SubItems[2].Text;
                Aliquota2.Text = MainListView.SelectedItems[0].SubItems[3].Text;
                Aliquota3.Text = MainListView.SelectedItems[0].SubItems[4].Text;
            }
        }

        private void ZoomButton_Click(object sender, EventArgs e) {
            bool bReadOnly = false;
            if (AddButton.Enabled) bReadOnly = true;
            ZoomBox f1 = new ZoomBox("Descrição da atividade", this, Descricao.Text, bReadOnly,300);
            f1.ShowDialog();
            Descricao.Text = f1.ReturnText;
        }

        private void SairButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void GravarButton_Click(object sender, EventArgs e) {
            decimal.TryParse(Aliquota1.Text, out decimal _aliq1);
            decimal.TryParse(Aliquota2.Text, out decimal _aliq2);
            decimal.TryParse(Aliquota3.Text, out decimal _aliq3);
            int.TryParse(Codigo.Text, out int _codigo);
            string _descricao = Descricao.Text.Trim();

            if (_codigo == 0)
                MessageBox.Show("Digite o código da atividade", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (Codigo.Text.Length < 5)
                    MessageBox.Show("Código deve ter 5 posições", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    if (_descricao == "")
                        MessageBox.Show("Digite a descrição da atividade", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        if ((decimal)0 == 0 && ((decimal)0 > 0 || _aliq3 > 0))
                            MessageBox.Show("Não é possível cadastar aliquotas 2 e 3 sem cadastrar a aliquota 1", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else {
                            if ((decimal)0 == 0 && _aliq3 > 0)
                                MessageBox.Show("Não é possível cadastar aliquota 3 sem cadastrar a aliquota 2", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else {
                                bool _find = false;
                                if (!bAddNew) goto Continue;
                                for (int i = 0; i < MainListView.Items.Count; i++) {
                                    if(Convert.ToInt32(MainListView.Items[i].Text) == _codigo) {
                                        _find = true;
                                        break;
                                    }
                                }
                                Continue:;
                                if (_find && bAddNew)
                                    MessageBox.Show("Código já cadatsrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else {
                                    Gravar_Atividade();
                                    ControlBehaviour(true);
                                    bAddNew = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e) {
            bAddNew = false;
            ControlBehaviour(true);
            MainListView.Focus();
            if (MainListView.SelectedItems.Count == 0) {
                MainListView.Items[0].Selected = true;
            }
            MainListView_SelectedIndexChanged(null, null);
        }

        private void AddButton_Click(object sender, EventArgs e) {
            bAddNew = true;
            ControlBehaviour(false);
            ClearReg();
            Codigo.ReadOnly = false;
            Codigo.BackColor = Color.White;
            Codigo.Focus();
        }

        private void EditButton_Click(object sender, EventArgs e) {
            if (MainListView.SelectedItems.Count == 0)
                MessageBox.Show("Selecione uma atividade para alterar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                bAddNew = false;
                ControlBehaviour(false);
                Codigo.ReadOnly = true;
                Codigo.BackColor = BackColor;
                Descricao.Focus();
            }
        }

        private void Codigo_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void Gravar_Atividade() {
            decimal.TryParse(Aliquota1.Text, out decimal _aliq1);
            decimal.TryParse(Aliquota2.Text, out decimal _aliq2);
            decimal.TryParse(Aliquota3.Text, out decimal _aliq3);
            int.TryParse(Codigo.Text, out int _codigo);
            string _descricao = Descricao.Text.Trim();

            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            Atividade reg = new Atividade {
                Codatividade = _codigo,
                Descatividade = _descricao,
                Valoraliq1 = _aliq1,
                Valoraliq2 = _aliq2,
                Valoraliq3 = _aliq3
            };
            Exception ex;
            if (bAddNew) {
                ex = tributario_Class.Insert_Atividade(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                } else {
                    ListViewItem lvItem = new ListViewItem(_codigo.ToString("00000"));
                    lvItem.SubItems.Add(_descricao);
                    lvItem.SubItems.Add(string.Format("{0:0.00}", _aliq3));
                    lvItem.SubItems.Add(string.Format("{0:0.00}", _aliq2));
                    lvItem.SubItems.Add(string.Format("{0:0.00}", _aliq3));
                    MainListView.Items.Add(lvItem);
                    ControlBehaviour(true);
                }
            } else {
                ex = tributario_Class.Alterar_Atividade(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                } else {
                    MainListView.Items[MainListView.SelectedIndices[0]].Text = _codigo.ToString("00000");
                    MainListView.Items[MainListView.SelectedIndices[0]].SubItems[1].Text = _descricao;
                    MainListView.Items[MainListView.SelectedIndices[0]].SubItems[2].Text = string.Format("{0:0.00}", _aliq1);
                    MainListView.Items[MainListView.SelectedIndices[0]].SubItems[3].Text = string.Format("{0:0.00}", _aliq2);
                    MainListView.Items[MainListView.SelectedIndices[0]].SubItems[4].Text = string.Format("{0:0.00}", _aliq3);

                    ControlBehaviour(true);
                }
            }
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

        private void PrintButton_Click(object sender, EventArgs e) {
            //TODO Imprimir atividades
        }

        private void DelButton_Click(object sender, EventArgs e) {
            int.TryParse(Codigo.Text, out int _codigo);

            if (_codigo == 0)
                MessageBox.Show("Selecione uma atividade.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (MessageBox.Show("Excluir este atividade?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    Empresa_bll empresa_Class = new Empresa_bll(_connection);
                    Exception ex = empresa_Class.Excluir_Atividade(_codigo);
                    if (ex != null) {
                        ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                        eBox.ShowDialog();
                    } else {
                        MainListView.Items.Remove(MainListView.SelectedItems[0]);
                        MainListView.Items[0].Selected = true;
                        MainListView_SelectedIndexChanged(null, null);
                        ClearReg();
                    }
                }
            }
        }

        private void SelecionarButton_Click(object sender, EventArgs e) {
            ListView.SelectedIndexCollection col = MainListView.SelectedIndices;
            if (col.Count > 0) {
                decimal.TryParse(Aliquota1.Text, out decimal _aliq1);
                decimal.TryParse(Aliquota2.Text, out decimal _aliq2);
                decimal.TryParse(Aliquota3.Text, out decimal _aliq3);

                DialogResult = DialogResult.OK;
                ReturnValue = Convert.ToInt32(MainListView.Items[col[0]].Text);

                if (_aliq2 > 0 && _selecionarAliquota ) {
                    MessageBoxManager.Yes = string.Format("{0:0.00}", _aliq1);
                    MessageBoxManager.No = string.Format("{0:0.00}", _aliq2);
                    MessageBoxManager.Cancel = string.Format("{0:0.00}", _aliq3);
                    MessageBoxManager.Register();
                    DialogResult a = MessageBox.Show("Selecione a aliquota.", "Atenção", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand);
                    if (a == DialogResult.Yes)
                        ReturnAliquota = Aliquota1.Text;
                    else {
                        if (a == DialogResult.No)
                            ReturnAliquota = Aliquota2.Text;
                        else
                            ReturnAliquota = Aliquota3.Text;
                    }
                    MessageBoxManager.Unregister();
                } else
                    ReturnAliquota = Aliquota1.Text;

                Close();
            } else {
                MessageBox.Show("Selecione uma Atividade.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
