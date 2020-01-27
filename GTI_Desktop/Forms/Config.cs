using System;
using GTI_Desktop.Classes;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Config : Form {
        public Config() {
            InitializeComponent();
        }

        private void FillGrid() {
            gtiConfig Pms = new gtiConfig {
                PathApp = AppDomain.CurrentDomain.BaseDirectory,
                DataBaseReal = Properties.Settings.Default.DataBaseReal,
                DataBaseTeste = Properties.Settings.Default.DataBaseTeste
            };
            Pms.PathReport = Pms.PathApp + "\\report";
            Pms.PathAnexo = Properties.Settings.Default.Path_Anexo_Local;
            Pms.ServerName = Properties.Settings.Default.ServerName;
            Pms.ComputerName = Environment.MachineName;
            Pms.UserName = gtiCore.Retorna_Last_User();
            pGrid.SelectedObject = Pms;
        }

        private void Config_Load(object sender, EventArgs e) {
            FillGrid();
        }

        private void PGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
            if (e.OldValue != e.ChangedItem.Value) {
                switch (e.ChangedItem.Label) {
                    case "Servidor de Dados":
                        Properties.Settings.Default.ServerName = e.ChangedItem.Value.ToString();

                        Main f1 = (Main)Application.OpenForms["Main"];
                        f1.ServidorToolStripStatus.Text = e.ChangedItem.Value.ToString();
                        break;
                    default:
                        break;
                }
                Properties.Settings.Default.Save();
                FillGrid();
            }
        }
    }
}
