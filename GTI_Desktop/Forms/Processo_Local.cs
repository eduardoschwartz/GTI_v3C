using System;
using System.Windows.Forms;
using GTI_Bll.Classes;
using GTI_Models.Models;
using GTI_Desktop.Properties;
using System.Collections.Generic;
using System.Linq;
using GTI_Desktop.Classes;
using System.Net;
using System.IO;
using System.Text;

namespace GTI_Desktop.Forms {
    public partial class Processo_Local : Form {
        List<Centrocusto> Lista;
        bool bAddNew;
        string _connection = gtiCore.Connection_Name();

        public Processo_Local() {
            InitializeComponent();
            ControlBehaviour(true);
            Processo_bll clsProcesso = new Processo_bll(_connection);
            Lista = clsProcesso.Lista_Local(false,false);
            TreeNode root = null;
            var departments = Lista;
            PopulateTree(ref root, departments);
            tvMain.Nodes.Add(root);
            tvMain.ExpandAll();
            tvMain.Nodes[0].EnsureVisible();
        }

        public void PopulateTree(ref TreeNode root, List<Centrocusto> departments) {
            if (root == null) {
                root = new TreeNode {
                    Text = "LOCAIS DE TRAMITAÇÃO",
                    ForeColor = System.Drawing.Color.Red,
                    Tag = null
                };
                var details = departments.Where(t => t.Vinculo == 0);
                foreach (var detail in details) {
                    var child = new TreeNode() {
                        Text = detail.Descricao.ToUpper(),
                        Tag = detail.Codigo,
                    };
                    child.ForeColor = System.Drawing.Color.Blue;
                    PopulateTree(ref child, departments);
                    root.Nodes.Add(child);
                }
            } else {
                var id = (short)root.Tag;
                var details = departments.Where(t => t.Vinculo == id);
                foreach (var detail in details) {
                    var child = new TreeNode() {
                        Text = detail.Descricao.ToUpper(),
                        Tag = detail.Codigo,
                    };
                    PopulateTree(ref child, departments);
                    root.Nodes.Add(child);
                }
            }
        }

        private void TvMain_AfterSelect(object sender, TreeViewEventArgs e) {
            Clear_Reg();
            if(tvMain.Nodes[0].IsSelected) {
                btEdit.Enabled = false;
                btDel.Enabled = false;
            }else {
                btEdit.Enabled = true;
                btDel.Enabled = true;
            }
            TreeNode tParent = e.Node.Parent;
            txtVinculo.Tag = tParent==null|| tParent.Tag == null ? "-1" : tParent.Tag.ToString();
            txtVinculo.Text = tParent==null?"LOCAIS DE TRAMITAÇÃO":  tParent.Text;
            txtDescricao.Text = tvMain.SelectedNode.Text;
            txtDescricao.Tag = tvMain.SelectedNode.Tag==null?"0": tvMain.SelectedNode.Tag.ToString();
            
            for (int i = 0; i < Lista.Count; i++) {
                if (Lista[i].Codigo == Convert.ToInt16(txtDescricao.Tag.ToString())) {
                    txtFone.Text = Lista[i].Telefone;
                    chkAtivo.Checked = Lista[i].Ativo;
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
            txtVinculo.ReadOnly = true;
            txtFone.ReadOnly = bStart;
            txtDescricao.ReadOnly = bStart;
            chkAtivo.Enabled = !bStart;
            tvMain.Enabled = bStart;
        }

        private void BtAdd_Click(object sender, EventArgs e) {
            bAddNew = true;
            Clear_Reg();
            ControlBehaviour(false);
            txtDescricao.Focus();
        }

        private void BtEdit_Click(object sender, EventArgs e) {
            bAddNew = false;
            ControlBehaviour(false);
            txtDescricao.Focus();
        }

        private void BtGravar_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Gravar os dados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Centrocusto reg = new Centrocusto {
                    Vinculo = Convert.ToInt16(txtVinculo.Tag),
                    Codigo = Convert.ToInt16(txtDescricao.Tag),
                    Descricao = txtDescricao.Text,
                    Telefone = txtFone.Text,
                    Ativo = chkAtivo.Checked
                };

                Processo_bll clsProcesso = new Processo_bll(_connection);
                Exception ex;

                if (bAddNew) {
                    short nLastCod = clsProcesso.Retorna_Ultimo_Codigo_Local();
                    reg.Vinculo = Convert.ToInt16(txtDescricao.Tag);
                    reg.Codigo =Convert.ToInt16( nLastCod + 1);
                    ex = clsProcesso.Incluir_Local(reg);
                    if (ex != null) {
                        ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                        eBox.ShowDialog();
                    } else {
                        var child = new TreeNode() {
                            Text = txtDescricao.Text.ToUpper(),
                            Tag = (nLastCod + 1).ToString(),
                        };
                        tvMain.SelectedNode.Nodes.Add(child);
                        Lista.Add(reg);
                        ControlBehaviour(true);
                    }
                } else {
                    ex = clsProcesso.Alterar_Local(reg);
                    if (ex != null) {
                        ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                        eBox.ShowDialog();
                    } else {
                        tvMain.SelectedNode.Text = txtDescricao.Text.ToUpper();
                        for (int i = 0; i < Lista.Count; i++) {
                            if (Lista[i].Codigo == Convert.ToInt32(txtDescricao.Tag.ToString())) {
                                Lista[i].Telefone=txtFone.Text;
                                Lista[i].Ativo = chkAtivo.Checked;
                                break;
                            }
                        }
                        ControlBehaviour(true);
                    }
                }
            }
        }

        private void BtCancelar_Click(object sender, EventArgs e) {
            ControlBehaviour(true);
        }

        private void BtExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Clear_Reg() {
            txtDescricao.Text = "";
            txtFone.Text = "";
            chkAtivo.Checked = false;
        }

        private void BtDel_Click(object sender, EventArgs e) {
            int nCodigo = Convert.ToInt32(txtDescricao.Tag);
            if (nCodigo == 0)
                MessageBox.Show("Selecione um local.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (MessageBox.Show("Excluir este registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    Processo_bll clsProcesso = new Processo_bll(_connection);
                    clsProcesso.Excluir_Local(nCodigo);
                    tvMain.SelectedNode.Remove();
                    tvMain.Nodes[0].EnsureVisible();
                    Clear_Reg();
                }
            }
        }
    }
}
