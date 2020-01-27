using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace GTI_Desktop.Forms {
    public partial class Atividade_ISS : Form {
        string _connection = gtiCore.Connection_Name();
        public AtividadeIssStruct ReturnValue { get; set; }

        public Atividade_ISS() {
            InitializeComponent();
            TipoList.SelectedIndex = 0;
            CarregaLista();
        }

        private void CarregaLista() {
            MainListView.Items.Clear();
            int _tipo = TipoList.SelectedIndex == 0 ? 11 : TipoList.SelectedIndex == 1 ? 12 : 13;
            Empresa_bll empresa_class = new Empresa_bll(_connection);
            List<AtividadeIssStruct> Lista = empresa_class.Lista_AtividadeISS();
            foreach (AtividadeIssStruct item in Lista.Where(c=>c.Tipo==_tipo)) {
                ListViewItem lvItem = new ListViewItem(item.Codigo_atividade.ToString("000"));
                lvItem.SubItems.Add ( item.Tipo == 11 ? "F" : item.Tipo == 12 ? "E" : "V");
                lvItem.SubItems.Add( item.Descricao);
                lvItem.SubItems.Add( item.Aliquota.ToString("#0.000"));
                MainListView.Items.Add(lvItem);
            }

        }

        private void SelecionarButton_Click(object sender, System.EventArgs e) {
            ListView.SelectedIndexCollection col = MainListView.SelectedIndices;
            if (col.Count > 0) {

                inputBox z = new inputBox();
                String sQtde = z.Show("", "Informação", "Digite a quantidade.",  3, gtiCore.eTweakMode.IntegerPositive);
                if (!string.IsNullOrEmpty(sQtde) || Convert.ToInt32(sQtde)==0) {

                    DialogResult = DialogResult.OK;
                    ReturnValue = new AtividadeIssStruct();
                    ReturnValue.Codigo_atividade = Convert.ToInt32(MainListView.Items[col[0]].Text);
                    ReturnValue.Tipo_str = MainListView.Items[col[0]].SubItems[1].Text;
                    ReturnValue.Descricao = MainListView.Items[col[0]].SubItems[2].Text;
                    ReturnValue.Aliquota = Convert.ToSingle(MainListView.Items[col[0]].SubItems[3].Text);
                    ReturnValue.Quantidade = Convert.ToInt32(sQtde);
                }else
                    MessageBox.Show("Digite a quantidade.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else {
                MessageBox.Show("Selecione uma Atividade.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void TipoList_SelectedIndexChanged(object sender, EventArgs e) {
            CarregaLista();
        }
    }
}























