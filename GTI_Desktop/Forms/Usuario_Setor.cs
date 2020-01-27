using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Usuario_Setor : Form {
        string _connection = gtiCore.Connection_Name();
        public int nId { get; set; }
        public Usuario_Setor() {
            InitializeComponent();
            Processo_bll processo_Class = new Processo_bll(_connection);
            SetorComboBox.DataSource = processo_Class.Lista_Local(true, true);
            SetorComboBox.DisplayMember = "Descricao";
            SetorComboBox.ValueMember = "Codigo";
        }

        private void GravarButton_Click(object sender, EventArgs e) {
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            usuarioStruct cUser = sistema_Class.Retorna_Usuario(nId);
            GTI_Models.Models.Usuario reg = new GTI_Models.Models.Usuario();
            reg.Id = cUser.Id;
            reg.Nomecompleto = cUser.Nome_completo;
            reg.Nomelogin = cUser.Nome_login;
            reg.Ativo = cUser.Ativo;
            reg.Setor_atual = Convert.ToInt32( SetorComboBox.SelectedValue);
            Exception ex = sistema_Class.Alterar_Usuario(reg);
            if (ex == null) {
                DialogResult = DialogResult.OK;
            } else {
                DialogResult = DialogResult.Cancel;
                ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                eBox.ShowDialog();
            }
            Close();
        }

        private void CancelarButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

      
    }
}
