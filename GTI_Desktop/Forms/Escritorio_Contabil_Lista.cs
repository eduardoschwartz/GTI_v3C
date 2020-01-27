using GTI_Desktop.Classes;
using GTI_Bll.Classes;
using System.Windows.Forms;
using System;

namespace GTI_Desktop.Forms {
    public partial class Escritorio_Contabil_Lista : Form {
        string _connection = gtiCore.Connection_Name();
        public short ReturnValue { get; set; }

        public Escritorio_Contabil_Lista() {
            InitializeComponent();
            tBar.Renderer = new MySR();
            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            MainList.DataSource = empresa_Class.Lista_Escritorio_Contabil();
            MainList.DisplayMember = "nomeesc";
            MainList.ValueMember = "codigoesc";
        }

        private void OKbutton_Click(object sender, System.EventArgs e) {
            if (MainList.SelectedItem!=null) {
                DialogResult = DialogResult.OK;
                ReturnValue = Convert.ToInt16(MainList.SelectedValue);
            } else {
                DialogResult = DialogResult.Cancel;
            }
            Close();
        }
    }
}
