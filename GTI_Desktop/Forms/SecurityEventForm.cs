using System;
using System.Windows.Forms;
using GTI_Bll.Classes;
using GTI_Models.Models;
using GTI_Desktop.Classes;
using GTI_Desktop.Properties;
using System.Collections.Generic;

namespace GTI_Desktop.Forms {
    public partial class SecurityEventForm : Form {
        string _connection = gtiCore.Connection_Name();

        public SecurityEventForm() {
            InitializeComponent();
            CarregaLista();
        }

        private void CarregaLista() {
            MainListView.Items.Clear();
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            List<security_event> Lista = sistema_Class.Lista_Sec_Eventos();
            foreach (security_event item in Lista) {
                ListViewItem lvItem = new ListViewItem(item.Id.ToString("0000"));
                lvItem.SubItems.Add(item.IdMaster.ToString("0000"));
                lvItem.SubItems.Add(item.Descricao);
                MainListView.Items.Add(lvItem);
            }
        }



    }
}
