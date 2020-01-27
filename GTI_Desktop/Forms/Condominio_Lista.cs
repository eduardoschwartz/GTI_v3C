using GTI_Desktop.Classes;
using GTI_Bll.Classes;
using System.Windows.Forms;
using System;

namespace GTI_Desktop.Forms {
    public partial class Condominio_Lista : Form {
        string _connection = gtiCore.Connection_Name();
        public short ReturnValue { get; set; }

        public Condominio_Lista() {
            InitializeComponent();
            tBar.Renderer = new MySR();
            Imovel_bll empresa_Class = new Imovel_bll(_connection);
            MainList.DataSource = empresa_Class.Lista_Condominio();
            MainList.DisplayMember = "cd_nomecond";
            MainList.ValueMember = "cd_codigo";
        }

        private void OKbutton_Click(object sender, EventArgs e) {
            if (MainList.SelectedItem != null) {
                DialogResult = DialogResult.OK;
                ReturnValue = Convert.ToInt16(MainList.SelectedValue);
            } else {
                DialogResult = DialogResult.Cancel;
            }
            Close();
        }
    }
}
