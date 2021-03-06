﻿using System;
using GTI_Desktop.Classes;
using System.Windows.Forms;
using System.Configuration;

namespace GTI_Desktop.Forms {
    public partial class Config : Form {
        public Config() {
            InitializeComponent();
        }

        private void FillGrid() {
            gtiConfig Pms = new gtiConfig {
                PathApp = AppDomain.CurrentDomain.BaseDirectory,
                DataBaseReal = gtiCore.BaseDados,
                DataBaseTeste = gtiCore.BaseDadosTeste
            };
            Pms.PathReport = gtiCore.Path_Report;
            Pms.PathAnexo = gtiCore.Path_Anexo;
            Pms.ServerName = gtiCore.ServerName;
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
                        gtiCore.ServerName = e.ChangedItem.Value.ToString();

                        Main f1 = (Main)Application.OpenForms["Main"];
                        f1.ServidorToolStripStatus.Text = e.ChangedItem.Value.ToString();
                        break;
                    default:
                        break;
                }

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["server"].Value = e.ChangedItem.Value.ToString();
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                FillGrid();
            }
        }
    }
}
