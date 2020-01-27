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
    public partial class SecurityUserForm : Form {
        string _connection = gtiCore.Connection_Name();
        string sUserBinary = "";

        List<security_event> ListaEventos;

        public SecurityUserForm() {
            InitializeComponent();
            List<CustomListBoxItem> comboList = new List<CustomListBoxItem>();
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            List<usuarioStruct> Lista = sistema_Class.Lista_Usuarios();
            foreach (usuarioStruct item in Lista) {
                comboList.Add(new CustomListBoxItem(item.Nome_completo, (int)item.Id));
            }

            UsuarioComboBox.DataSource = comboList;
            UsuarioComboBox.DisplayMember = "_name";
            UsuarioComboBox.ValueMember = "_value";
            
            MainTreeView.Nodes.Clear();

            UsuarioComboBox_SelectedIndexChanged(null, null);
        }

        private void UsuarioComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (UsuarioComboBox.SelectedItem != null) {
                Sistema_bll sistema_Class = new Sistema_bll(_connection);
                CustomListBoxItem item = (CustomListBoxItem)UsuarioComboBox.SelectedItem;
                LoginLabel.Text = sistema_Class.Retorna_User_LoginName(item._value);
                string sTmp = sistema_Class.GetUserBinary(item._value);

                //Verifica a qtde de eventos cadastrados
                int nSize = sistema_Class.GetSizeofBinary();
                sUserBinary = gtiCore.Decrypt(sTmp);
                
                //**Caso o binário do usuário for menor que a qtde de eventos, acrescenta zeros no final.
                if (nSize > sUserBinary.Length) {
                    int nDif = nSize - sUserBinary.Length;
                    sTmp = new string('0', nDif);
                    sUserBinary += sTmp;
                }
                //***********************************************

                MainTreeView.Nodes.Clear();
                ListaEventos = sistema_Class.Lista_Sec_Eventos();
                TreeNode root = null;
                var departments = ListaEventos;
                PopulateTree(ref root, departments);
                MainTreeView.Nodes.Add(root);
                MainTreeView.ExpandAll();
                MainTreeView.Nodes[0].EnsureVisible();

            }
        }

        private void GravarButton_Click(object sender, EventArgs e) {
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            int nSize = sistema_Class.GetSizeofBinary();
            string sZero = new string('0', nSize);

            var aString = sZero.ToCharArray();

            List<TreeNode> checked_nodes = CheckedNodes(MainTreeView);

            foreach (TreeNode itemTv in checked_nodes) {
                aString[Convert.ToInt32(itemTv.Tag) - 1] = '1';
            }
            string sNewBinary = new string(aString);
            GtiTypes.UserBinary = sNewBinary;
            CustomListBoxItem UsuarioId = (CustomListBoxItem)UsuarioComboBox.SelectedItem;
            GTI_Models.Models.Usuario reg = new GTI_Models.Models.Usuario();
            reg.Id = UsuarioId._value;
            reg.Userbinary = gtiCore.Encrypt(sNewBinary);
            Exception ex = sistema_Class.SaveUserBinary(reg);
            if (ex != null) {
                ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                eBox.ShowDialog();
            }else
                MessageBox.Show("Alterações gravadas com sucesso.","Informação",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        public void PopulateTree(ref TreeNode root, List<security_event> departments) {
            if (root == null) {
                root = new TreeNode {
                    Text = "Eventos de Segurança",
                    ForeColor = System.Drawing.Color.Yellow,
                    BackColor=Color.Red,
                    Tag = null
                };
                var details = departments.Where(t => t.IdMaster == 0);
                foreach (var detail in details) {
                    var child = new TreeNode() {
                        Text = detail.Descricao.ToUpper(),
                        Tag = detail.Id,
                    };
                    if (sUserBinary.Substring(detail.Id-1, 1) == "1")
                        child.Checked = true;
                    child.ForeColor = System.Drawing.Color.Blue;
                    PopulateTree(ref child, departments);
                    root.Nodes.Add(child);
                }
            } else {
                var id = (int)root.Tag;
                var details = departments.Where(t => t.IdMaster == id);
                foreach (var detail in details) {
                    var child = new TreeNode() {
                        Text = detail.Descricao.ToUpper(),
                        Tag = detail.Id,
                    };
                    if (sUserBinary.Substring(detail.Id-1, 1) == "1")
                        child.Checked = true;
                    PopulateTree(ref child, departments);
                    root.Nodes.Add(child);
                }
            }
        }

        // Return a list of the TreeNodes that are checked.
        private void FindCheckedNodes(List<TreeNode> checked_nodes, TreeNodeCollection nodes) {
            foreach (TreeNode node in nodes) {
                // Add this node.
                if (node.Checked) checked_nodes.Add(node);
                // Check the node's descendants.
                FindCheckedNodes(checked_nodes, node.Nodes);
            }
        }

        // Return a list of the checked TreeView nodes.
        private List<TreeNode> CheckedNodes(TreeView trv) {
            List<TreeNode> checked_nodes = new List<TreeNode>();
            FindCheckedNodes(checked_nodes, MainTreeView.Nodes);
            return checked_nodes;
        }

        private void MainTreeView_BeforeCheck(object sender, TreeViewCancelEventArgs e) {
            if (e.Node.Level == 0) {
                e.Cancel = true;
            }
        }

      
    }
}
