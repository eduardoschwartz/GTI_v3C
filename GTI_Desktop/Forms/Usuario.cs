using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static GTI_Desktop.Classes.GtiTypes;

namespace GTI_Desktop.Forms {
    public partial class Usuario : Form {
        string _connection = gtiCore.Connection_Name();
        bool bAddNew;
        bool bExec;

        public Usuario() {
            InitializeComponent();
            bExec = true;
            ControlBehaviour(true);
            Carrega_Lista();
            tBar.Focus();
        }

        private void ControlBehaviour(bool bStart) {
            AddButton.Enabled = bStart;
            EditButton.Enabled = bStart;
            ExitButton.Enabled = bStart;
            SaveButton.Enabled = !bStart;
            CancelarButton.Enabled = !bStart;
            FindButton.Enabled = bStart;
            NomeCompletoTextBox.ReadOnly = bStart;
            NomeLoginTextBox.ReadOnly = bStart;
            LocalComboBox.Visible = !bStart;
            LocalTextBox.Visible = bStart;
            AtivoCheckbox.Enabled = !bStart;
            if (!bAddNew) {
                NomeCompletoTextBox.ReadOnly = true;
                NomeLoginTextBox.ReadOnly = true;
            }
        }

        private void Clear_Reg() {
            IdLabel.Text = "0";
            NomeCompletoTextBox.Text = "";
            NomeLoginTextBox.Text = "";
            LocalComboBox.SelectedIndex = -1;
            AtivoCheckbox.Checked = false;
            bExec = false;
            for (int i = 0; i < LocalComboBox.Items.Count; i++) {
                LocalListBox.SetItemChecked(i, false);
            }
            bExec = true;
        }

        private void Carrega_Lista() {
            Processo_bll clsProcesso = new Processo_bll(_connection);
            List<Centrocusto> Lista = clsProcesso.Lista_Local(true,true);

            List<CustomListBoxItem> myItems = new List<CustomListBoxItem>();
            List<CustomListBoxItem> myItems2 = new List<CustomListBoxItem>();
            foreach (Centrocusto item in Lista) {
                myItems.Add(new CustomListBoxItem(item.Descricao, item.Codigo));
                myItems2.Add(new CustomListBoxItem(item.Descricao, item.Codigo));
            }
            LocalComboBox.DataSource = myItems;
            LocalComboBox.DisplayMember = "_name";
            LocalComboBox.ValueMember = "_value";
            LocalListBox.DataSource = myItems2;
            LocalListBox.DisplayMember = "_name";
            LocalListBox.ValueMember = "_value";
        }

        private void AddButton_Click(object sender, EventArgs e) {
            bAddNew = true;
            Clear_Reg();
            ControlBehaviour(false);
            AtivoCheckbox.Checked = true;
            NomeCompletoTextBox.Focus();
        }

        private void EditButton_Click(object sender, EventArgs e) {
            if (Convert.ToInt32(IdLabel.Text) == 0)
                MessageBox.Show("Selecione um usuário para alterar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                bAddNew = false;
                ControlBehaviour(false);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            if (NomeCompletoTextBox.Text == "") {
                MessageBox.Show("Digite o nome completo do usuário.","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (NomeLoginTextBox.Text == "") {
                MessageBox.Show("Digite o nome de login do usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (LocalComboBox.SelectedIndex==-1) {
                MessageBox.Show("Selecione o local atual de trabalho.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            string sFullName = sistema_Class.Retorna_User_FullName( NomeLoginTextBox.Text);
            if (!string.IsNullOrWhiteSpace(sFullName) && bAddNew ) {
                if (sFullName != NomeCompletoTextBox.Text) {
                    MessageBox.Show("O login digitado já esta sendo utilizado pelo usuário " + sFullName + ".", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } else {
                    MessageBox.Show("Usuário já cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            } 
            SaveReg();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            ControlBehaviour(true);
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void SaveReg() {
            int? nLastCod;
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            CustomListBoxItem cBoxItem = (CustomListBoxItem)LocalComboBox.SelectedItem;

            if (bAddNew) {
                nLastCod = sistema_Class.Retorna_Ultimo_Codigo_Usuario();
                if (nLastCod == 0) 
                    nLastCod = 1;
                else
                    nLastCod++;
            } else
                nLastCod = Convert.ToInt32(IdLabel.Text);
            GTI_Models.Models.Usuario reg = new GTI_Models.Models.Usuario {
                Nomecompleto = NomeCompletoTextBox.Text,
                Nomelogin = NomeLoginTextBox.Text,
                Ativo = AtivoCheckbox.Checked?(byte)1:(byte)0,
                Id = (int)nLastCod,
                Setor_atual=cBoxItem._value
            };

            Exception ex;
            if (bAddNew) {
                ex = sistema_Class.Incluir_Usuario(reg);
                IdLabel.Text = Convert.ToInt32(nLastCod).ToString("0000");
            } else {
                ex = null;
                ex = sistema_Class.Alterar_Usuario(reg);
            }
            if (ex != null) {
                ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                eBox.ShowDialog();
            } else {

                List<Usuariocc> Lista = new List<Usuariocc>();
                for (int i = 0; i < LocalListBox.Items.Count; i++) {
                    if (LocalListBox.GetItemCheckState(i) == CheckState.Checked) {
                        Usuariocc item = new Usuariocc();
                        CustomListBoxItem selectedItem = (CustomListBoxItem)LocalListBox.Items[i];
                        item.Userid = Convert.ToInt32(IdLabel.Text);
                        item.Codigocc = Convert.ToInt16(selectedItem._value);
                        Lista.Add(item);
                    }
                }
                ex = null;
                ex = sistema_Class.Alterar_Usuario_Local(Lista);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                } else {

                    LocalTextBox.Text = LocalComboBox.Text;
                    ControlBehaviour(true);
                }
            }
        }

        private void LoadReg(int nId) {
            Clear_Reg();
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            usuarioStruct reg = sistema_Class.Retorna_Usuario(nId);
            IdLabel.Text = Convert.ToInt32(reg.Id).ToString("0000");
            NomeCompletoTextBox.Text = reg.Nome_completo;
            NomeLoginTextBox.Text = reg.Nome_login;
            LocalComboBox.SelectedValue = reg.Setor_atual == null ? -1 : reg.Setor_atual;
            LocalTextBox.Text = reg.Nome_setor;
            AtivoCheckbox.Checked = reg.Ativo==1?true:false;

            bExec = false;
            List<Usuariocc> ListaCC = sistema_Class.Lista_Usuario_Local(nId);
            foreach (Usuariocc item in ListaCC) {
                for (int i = 0; i < LocalListBox.Items.Count; i++) {
                    CustomListBoxItem linha = (CustomListBoxItem)LocalListBox.Items[i];
                    int nCodCC = linha._value;
                    if (nCodCC == item.Codigocc)
                        LocalListBox.SetItemChecked(i, true);
                }
            }
            bExec = true;
        }

        private void FindButton_Click(object sender, EventArgs e) {
            using (var form = new Usuario_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    int val = form.ReturnValue;     
                    IdLabel.Text = val.ToString("0000");
                    LoadReg(val);
                }
            }
        }

        private void NomeLoginTextBox_Enter(object sender, EventArgs e) {
            if(SaveButton.Enabled && NomeCompletoTextBox.Text!="" && NomeLoginTextBox.Text == "") {
                string fullName = NomeCompletoTextBox.Text;
                string[] names = fullName.Split(' ');
                string name = names.First();
                string lasName = names.Last();
                NomeLoginTextBox.Text = name + "." + lasName;
            }
        }

        private void LocalListBox_ItemCheck(object sender, ItemCheckEventArgs e) {
            if (!bExec) return;
            if (AddButton.Enabled) {
                e.NewValue = e.CurrentValue;
            }
        }
    }
}
