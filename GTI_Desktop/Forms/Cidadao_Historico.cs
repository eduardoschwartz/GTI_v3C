using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Cidadao_Historico : Form {
        string _connection = gtiCore.Connection_Name();
        string _tipo = "";
        int _codigo;
        bool bDirty ,bExec;

        public Cidadao_Historico(int Codigo,string Tipo) {
            InitializeComponent();
            _tipo = Tipo;
            _codigo = Codigo;
            GravarButton.Enabled = false;
            if (_tipo == "H")
                Text = "Histórico do contribuinte";
            else {
                Text = "Observação do contribuinte";
                HistoricoText.ReadOnly = false;
            }
            bDirty = false;
            Carrega_Lista();
        }

        private void MainListView_SelectedIndexChanged(object sender, EventArgs e) {
            if (MainListView.Items.Count > 0 && MainListView.SelectedItems.Count > 0)
                HistoricoText.Text = MainListView.SelectedItems[0].SubItems[2].Text.ToString();
        }

        private void Carrega_Lista() {
            MainListView.Items.Clear();
            Cidadao_bll cidadao_Class = new Cidadao_bll(_connection);
            bDirty = false;
            bExec = false;
            if (_tipo == "H") {
                List<Historico_CidadaoStruct> Lista = cidadao_Class.Lista_Historico(_codigo);
                foreach (Historico_CidadaoStruct item in Lista) {
                    ListViewItem lvItem = new ListViewItem(Convert.ToDateTime(item.Data).ToString("dd/MM/yyyy"));
                    lvItem.SubItems.Add(item.Nome_Usuario);
                    lvItem.SubItems.Add(item.Obs);
                    MainListView.Items.Add(lvItem);
                }
            } else {
                List<Observacao_CidadaoStruct> Lista = cidadao_Class.Lista_Observacao(_codigo);
                foreach (Observacao_CidadaoStruct item in Lista) {
                    ListViewItem lvItem = new ListViewItem(Convert.ToDateTime(item.Data_Hora).ToString("dd/MM/yyyy hh:mm"));
                    lvItem.SubItems.Add(item.Nome_Usuario);
                    lvItem.SubItems.Add(item.Obs);
                    MainListView.Items.Add(lvItem);
                }
            }
            bExec = true;
            if (MainListView.Items.Count > 0)
                MainListView.Items[0].Selected = true;

        }

        private void GravarButton_Click(object sender, EventArgs e) {
            if (bDirty) {
                bDirty = false;

                Sistema_bll sistema_Class = new Sistema_bll(_connection);
                obscidadao reg = new obscidadao();
                reg.Codigo = _codigo;
                reg.Userid = sistema_Class.Retorna_User_LoginId(Properties.Settings.Default.LastUser);
                reg.timestamp = DateTime.Now;
                reg.Obs = HistoricoText.Text;

                Cidadao_bll cidadao_Class = new Cidadao_bll(_connection);
                Exception ex = cidadao_Class.Incluir_observacao_cidadao(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                } else
                    Carrega_Lista();
            }
        }

        private void HistoricoText_KeyPress(object sender, KeyPressEventArgs e) {
            bDirty = true;
        }

        private void HistoricoText_TextChanged(object sender, EventArgs e) {
            if (_tipo == "O" && bExec && bDirty)
                GravarButton.Enabled = true;
        }

    }
}
