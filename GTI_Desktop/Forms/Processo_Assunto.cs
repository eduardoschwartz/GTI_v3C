using System;
using System.Windows.Forms;
using GTI_Bll.Classes;
using GTI_Models.Models;
using GTI_Desktop.Classes;
using GTI_Desktop.Properties;
using System.Collections.Generic;
using System.Drawing;

namespace GTI_Desktop.Forms {
    public partial class Processo_Assunto : Form {
        bool bCheck, bSoAtivo, bSoNAtivo;
        int _oldIndex;
        int hoveredIndex = -1;
        string _connection = gtiCore.Connection_Name();

        public Processo_Assunto() {
            InitializeComponent();
            bCheck = false;
            bSoAtivo = false;
            bSoNAtivo = false;
            Carrega_Lista(bSoAtivo,bSoNAtivo);
            Carrega_Local();
            Carrega_Doc();
        }

        private void Carrega_Lista(bool Somente_Ativo,bool Somente_inativo) {
            lstMain.Items.Clear();
            gtiCore.Ocupado(this);
            Processo_bll processo_class = new Processo_bll(_connection);
            List<Assunto> lista = processo_class.Lista_Assunto(Somente_Ativo,Somente_inativo,txtFilter.Text);
            lstMain.Sorted = false;
            foreach (Assunto item in lista) {
                lstMain.Items.Add(new GtiTypes.CustomListBoxItem2(item.Nome.ToString(), item.Codigo,item.Ativo));
                lstMain.SetItemChecked(lstMain.Items.Count - 1, item.Ativo);
            }
            lstMain.Sorted = true;
            if (lstMain.Items.Count > 0) {
                lstMain.SelectedIndex = 0;
                LstMain_SelectedIndexChanged(null, null);
            } else {
                lstDoc2.Items.Clear();
                lstCC2.Items.Clear();
            }
                
            gtiCore.Liberado(this);
        }

        private void Carrega_Local() {
            lstCC1.Items.Clear();
            gtiCore.Ocupado(this);
            Processo_bll processo_class = new Processo_bll(_connection);
            List<Centrocusto> lista = processo_class.Lista_Local(true,false);
            foreach (Centrocusto item in lista) {
                lstCC1.Items.Add(new GtiTypes.CustomListBoxItem(item.Descricao.ToString(), item.Codigo));
            }
            gtiCore.Liberado(this);
        }

        private void Carrega_Doc() {
            lstDoc1.Items.Clear();
            gtiCore.Ocupado(this);
            Processo_bll processo_class = new Processo_bll(_connection);
            List<Documento> lista = processo_class.Lista_Documento();
            foreach (Documento item in lista) {
                lstDoc1.Items.Add(new GtiTypes.CustomListBoxItem(item.Nome.ToString(), item.Codigo));
            }
            gtiCore.Liberado(this);
        }

        private void Carrega_Assunto_Local(short Assunto) {
            lstCC2.Items.Clear();
            gtiCore.Ocupado(this);
            Processo_bll processo_class = new Processo_bll(_connection);
            List<AssuntoLocal> lista = processo_class.Lista_Assunto_Local(Assunto);
            lstCC2.Sorted = false;
            foreach (AssuntoLocal item in lista) {
                lstCC2.Items.Add(new GtiTypes.CustomListBoxItem(item.Nome.ToString(), item.Codigo));
            }
            gtiCore.Liberado(this);
        }

        private void Carrega_Assunto_Documento(short Assunto) {
            lstDoc2.Items.Clear();
            gtiCore.Ocupado(this);
            Processo_bll processo_class = new Processo_bll(_connection);
            List<AssuntoDocStruct> lista = processo_class.Lista_Assunto_Documento(Assunto);
            foreach (AssuntoDocStruct item in lista) {
                lstDoc2.Items.Add(new GtiTypes.CustomListBoxItem(item.Nome.ToString(), item.Codigo));
            }
            gtiCore.Liberado(this);
        }

        private void BtAdd_Click(object sender, EventArgs e) {
            inputBox iBox = new inputBox();
            String sCod = iBox.Show("", "Informação", "Digite o nome do assunto.", 40);
            if (!string.IsNullOrEmpty(sCod)) {
                Processo_bll processo_class = new Processo_bll(_connection);
                Assunto reg = new Assunto {
                    Ativo = true,
                    Nome = sCod.ToUpper()
                };
                Exception ex = processo_class.Incluir_Assunto(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", "Assunto já cadastrado.", ex);
                    eBox.ShowDialog();
                } else
                    Carrega_Lista(bSoAtivo,bSoNAtivo);
            }
        }

        private void BtEdit_Click(object sender, EventArgs e) {
            if (lstMain.SelectedItem == null) return;
            inputBox iBox = new inputBox();
            String sCod = iBox.Show(lstMain.Text, "Informação", "Digite o nome do assunto.", 40);
            if (!string.IsNullOrEmpty(sCod)) {
                Processo_bll processo_class = new Processo_bll(_connection);
                Assunto reg = new Assunto();
                GtiTypes.CustomListBoxItem2 selectedData = (GtiTypes.CustomListBoxItem2)lstMain.SelectedItem;
                reg.Codigo = Convert.ToInt16(selectedData._value);
                reg.Nome = sCod.ToUpper();
                reg.Ativo = Convert.ToBoolean(selectedData._ativo);
                Exception ex = processo_class.Alterar_Assunto(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", "Assunto já cadastrado.", ex);
                    eBox.ShowDialog();
                } else
                    Carrega_Lista(bSoAtivo,bSoNAtivo);
            }
        }

        private void BtDel_Click(object sender, EventArgs e) {
            if (lstMain.SelectedItem == null) return;
            if (MessageBox.Show("Excluir este assunto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Processo_bll processo_class = new Processo_bll(_connection);
                Assunto reg = new Assunto();
                GtiTypes.CustomListBoxItem2 selectedData = (GtiTypes.CustomListBoxItem2)lstMain.SelectedItem;
                reg.Codigo = Convert.ToInt16(selectedData._value);
                Exception ex = processo_class.Excluir_Assunto(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox( "Atenção", ex.Message, ex);
                    eBox.ShowDialog();
              } else
                    Carrega_Lista(bSoAtivo,bSoNAtivo);
            }
        }

        private void BtExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void LstMain_DoubleClick(object sender, EventArgs e) {
            if (lstMain.SelectedItem == null) return;
            btEdit.PerformClick();
        }

        private void BtAtivar_Click(object sender, EventArgs e) {
            if (lstMain.SelectedItem == null) return;
            bCheck = true;
            lstMain.SetItemChecked(lstMain.SelectedIndex, !lstMain.GetItemChecked(lstMain.SelectedIndex));

            Assunto reg = new Assunto();
            GtiTypes.CustomListBoxItem2 selectedData = (GtiTypes.CustomListBoxItem2)lstMain.SelectedItem;
            reg.Codigo = Convert.ToInt16(selectedData._value);
            reg.Nome = selectedData._name;
            reg.Ativo = selectedData._ativo;
            Processo_bll clsProcesso = new Processo_bll(_connection);
            Exception ex = clsProcesso.Alterar_Assunto(reg);
            if (ex != null) {
                ErrorBox eBox = new ErrorBox("Atenção", "Erro desconhecido.", ex);
                eBox.ShowDialog();

            }
        }

        private void LstMain_ItemCheck(object sender, ItemCheckEventArgs e) {
            if (bCheck) {
                bCheck = false;
                return;
            }
            if (lstMain.SelectedItem == null) return;
            e.NewValue = e.CurrentValue;
        }

        private void ExibirTodosOsAssuntosToolStripMenuItem_Click(object sender, EventArgs e) {
            bSoAtivo = false;bSoNAtivo = false;
            Carrega_Lista(bSoAtivo, bSoNAtivo);
        }

        private void SomenteOsAtivosToolStripMenuItem_Click(object sender, EventArgs e) {
            bSoAtivo = true; bSoNAtivo = false;
            Carrega_Lista(bSoAtivo, bSoNAtivo);
        }

        private void SomenteOsInativosToolStripMenuItem_Click(object sender, EventArgs e) {
            bSoAtivo = false; bSoNAtivo = true;
            Carrega_Lista(bSoAtivo, bSoNAtivo);
        }

        private void BtFilter_Click(object sender, EventArgs e) {
            Carrega_Lista(bSoAtivo, bSoNAtivo);
        }

        private void TxtFilter_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter)
                BtFilter_Click(null, null);
        }

        private void LstCC2_MouseDown(object sender, MouseEventArgs e) {
            if (lstCC2.SelectedItem == null) return;
            _oldIndex = lstCC2.SelectedIndex;
            lstCC2.DoDragDrop(lstCC2.SelectedItem, DragDropEffects.Move);
        }

        private void LstCC2_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        private void BtCC1_Click(object sender, EventArgs e) {
            if (lstMain.SelectedItem == null)
                MessageBox.Show("Selecione um assunto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                GtiTypes.CustomListBoxItem2 selectedData = (GtiTypes.CustomListBoxItem2)lstMain.SelectedItem;
                bool bAtivo = Convert.ToBoolean(selectedData._ativo);
                if (bAtivo) {
                    if (lstCC1.SelectedItem == null)
                        MessageBox.Show("Selecione o local que deseja incluir na tramitação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        GtiTypes.CustomListBoxItem selectedItem = (GtiTypes.CustomListBoxItem)lstCC1.SelectedItem;
                        lstCC2.Items.Add(new GtiTypes.CustomListBoxItem(selectedItem._name, selectedItem._value));
                        Atualizar_Local();
                    }
                } else
                    MessageBox.Show("Apenas assuntos ativos podem ser alterados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtCC2_Click(object sender, EventArgs e) {
            GtiTypes.CustomListBoxItem2 selectedData = (GtiTypes.CustomListBoxItem2)lstMain.SelectedItem;
            bool bAtivo = Convert.ToBoolean(selectedData._ativo);
            if (bAtivo) {
                if (lstCC2.SelectedItem == null)
                    MessageBox.Show("Selecione o local que deseja excluir da tramitação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    _oldIndex = lstCC2.SelectedIndex;
                    lstCC2.Items.RemoveAt(_oldIndex);
                    Atualizar_Local();
                }
            } else
                MessageBox.Show("Apenas assuntos ativos podem ser alterados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LstCC2_DragDrop(object sender, DragEventArgs e) {
            GtiTypes.CustomListBoxItem2 selectedData = (GtiTypes.CustomListBoxItem2)lstMain.SelectedItem;
            bool bAtivo = Convert.ToBoolean(selectedData._ativo);
            if (bAtivo) {                Point point = lstCC2.PointToClient(new Point(e.X, e.Y));
                int index = lstCC2.IndexFromPoint(point);
                if (index < 0) index = lstCC2.Items.Count - 1;
                object data = e.Data.GetData(typeof(GtiTypes.CustomListBoxItem));
                lstCC2.Items.RemoveAt(_oldIndex);
                lstCC2.Items.Insert(index, data);
                Atualizar_Local();
            } else
                MessageBox.Show("Apenas assuntos ativos podem ser alterados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtDoc1_Click(object sender, EventArgs e) {
            if (lstMain.SelectedItem == null)
                MessageBox.Show("Selecione um assunto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                GtiTypes.CustomListBoxItem2 selectedData = (GtiTypes.CustomListBoxItem2)lstMain.SelectedItem;
                bool bAtivo = Convert.ToBoolean(selectedData._ativo);
                if (bAtivo) {
                    if (lstDoc1.SelectedItem == null)
                        MessageBox.Show("Selecione o documento que deseja incluir na tramitação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        bool bFind = false;
                        GtiTypes.CustomListBoxItem selectedItem = (GtiTypes.CustomListBoxItem)lstDoc1.SelectedItem;
                        foreach (GtiTypes.CustomListBoxItem item in lstDoc2.Items) {
                            if (item._value == selectedItem._value) {
                                bFind = true;
                                break;
                            }
                        }
                        if (bFind)
                            MessageBox.Show("Documento já incluso no assunto.","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        else {
                            lstDoc2.Items.Add(new GtiTypes.CustomListBoxItem(selectedItem._name, selectedItem._value));
                            Atualizar_Documento();
                        }
                    }
                } else
                    MessageBox.Show("Apenas assuntos ativos podem ser alterados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtDoc2_Click(object sender, EventArgs e) {
            GtiTypes.CustomListBoxItem2 selectedData = (GtiTypes.CustomListBoxItem2)lstMain.SelectedItem;
            bool bAtivo = Convert.ToBoolean(selectedData._ativo);
            if (bAtivo) {
                if (lstDoc2.SelectedItem == null)
                    MessageBox.Show("Selecione o documento que deseja excluir da tramitação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    _oldIndex = lstDoc2.SelectedIndex;
                    lstDoc2.Items.RemoveAt(_oldIndex);
                    Atualizar_Documento();
                }
            } else
                MessageBox.Show("Apenas assuntos ativos podem ser alterados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LstMain_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstMain.SelectedItems.Count > 0) {
                GtiTypes.CustomListBoxItem2 selectedData = (GtiTypes.CustomListBoxItem2)lstMain.SelectedItem;
                Carrega_Assunto_Local(Convert.ToInt16( selectedData._value));
                Carrega_Assunto_Documento(Convert.ToInt16(selectedData._value));
            }
        }

        private void LstDoc2_MouseMove(object sender, MouseEventArgs e) {
            int newHoveredIndex = lstDoc2.IndexFromPoint(e.Location);
            if (hoveredIndex != newHoveredIndex) {
                hoveredIndex = newHoveredIndex;
                if (hoveredIndex > -1) {
                    tTp.Active = false;
                    tTp.SetToolTip(lstDoc2, ((GtiTypes.CustomListBoxItem)lstDoc2.Items[hoveredIndex])._name);
                    tTp.Active = true;
                }
            }
        }

        private void LstCC2_MouseMove(object sender, MouseEventArgs e) {
            int newHoveredIndex = lstCC2.IndexFromPoint(e.Location);
            if (hoveredIndex != newHoveredIndex) {
                hoveredIndex = newHoveredIndex;
                if (hoveredIndex > -1) {
                    tTp.Active = false;
                    tTp.SetToolTip(lstCC2, ((GtiTypes.CustomListBoxItem)lstCC2.Items[hoveredIndex])._name);
                    tTp.Active = true;
                }
            }
        }

        private void LstMain_MouseMove(object sender, MouseEventArgs e) {
            int newHoveredIndex = lstMain.IndexFromPoint(e.Location);
            if (hoveredIndex != newHoveredIndex) {
                hoveredIndex = newHoveredIndex;
                if (hoveredIndex > -1) {
                    tTp.Active = false;
                    tTp.SetToolTip(lstMain, ((GtiTypes.CustomListBoxItem2)lstMain.Items[hoveredIndex])._name);
                    tTp.Active = true;
                }
            }
        }

        private void Atualizar_Local() {
            GtiTypes.CustomListBoxItem2 selectedData = (GtiTypes.CustomListBoxItem2)lstMain.SelectedItem;
            int CodAssunto = Convert.ToInt16(selectedData._value);

            List<Assuntocc> Lista = new List<Assuntocc>();
            int x = 1;
            foreach (GtiTypes.CustomListBoxItem item in lstCC2.Items) {
                Assuntocc reg = new Assuntocc {
                    Codassunto = Convert.ToInt16(CodAssunto),
                    Codcc = Convert.ToInt16(item._value),
                    Seq = Convert.ToInt16(x)
                };
                Lista.Add(reg);
                x++;
            }
            Processo_bll clsProcesso = new Processo_bll(_connection);
            Exception ex = clsProcesso.Incluir_Assunto_Local(Lista);
        }

        private void Atualizar_Documento() {
            GtiTypes.CustomListBoxItem2 selectedData = (GtiTypes.CustomListBoxItem2)lstMain.SelectedItem;
            short CodAssunto = Convert.ToInt16(selectedData._value);

            List<Assuntodoc> Lista = new List<Assuntodoc>();
            foreach (GtiTypes.CustomListBoxItem item in lstDoc2.Items) {
                Assuntodoc reg = new Assuntodoc {
                    Codassunto = CodAssunto,
                    Coddoc = Convert.ToInt16(item._value)
                };
                Lista.Add(reg);
            }
            Processo_bll clsProcesso = new Processo_bll(_connection);
            Exception ex = clsProcesso.Incluir_Assunto_Documento(Lista);
        }

    }
}
