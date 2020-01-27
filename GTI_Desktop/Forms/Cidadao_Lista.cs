using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Cidadao_Lista : Form {
        string _connection = gtiCore.Connection_Name();
        public int ReturnValue { get; set; }
        List<ArrayList> aDatResult;
        int _File_Version = Properties.Settings.Default.gti_002_version;

        public Cidadao_Lista() {
            InitializeComponent();
            ReadDatFile();
        }

        private void UncheckOtherToolStripMenuItems(ToolStripMenuItem selectedMenuItem) {
            selectedMenuItem.Checked = true;

            foreach (var ltoolStripMenuItem in (from object
                                                item in selectedMenuItem.Owner.Items
                                                let ltoolStripMenuItem = item as ToolStripMenuItem
                                                where ltoolStripMenuItem != null
                                                where !item.Equals(selectedMenuItem)
                                                select ltoolStripMenuItem))
                (ltoolStripMenuItem).Checked = false;

            TitleMenu.Text = "Critério: (" + selectedMenuItem.Text + ")";
            TitleMenu.Tag = selectedMenuItem.Text;
        }

        private void MnuNome_Click(object sender, EventArgs e) {
            UncheckOtherToolStripMenuItems((ToolStripMenuItem)sender);
        }

        private void MnuCodigo_Click(object sender, EventArgs e) {
            UncheckOtherToolStripMenuItems((ToolStripMenuItem)sender);
        }

        private void MnuCPF_Click(object sender, EventArgs e) {
            UncheckOtherToolStripMenuItems((ToolStripMenuItem)sender);
        }

        private void MnuCNPJ_Click(object sender, EventArgs e) {
            UncheckOtherToolStripMenuItems((ToolStripMenuItem)sender);
        }

        private void BtFind_Click(object sender, EventArgs e) {
            MainListView.Items.Clear();
            if (BuscaText.Text.Length < 3)
                MessageBox.Show("Digite ao menos 3 caractéres.", "Informação inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Fill_List();
        }

        private void Cidadao_Lista_Activated(object sender, EventArgs e) {
            if (TitleMenu.Text.Equals(""))
                UncheckOtherToolStripMenuItems(NomeMenu);
        }

        private void Fill_List() {
            gtiCore.Ocupado(this);
            string _valor = BuscaText.Text;
            Cidadao_bll clsCidadao = new Cidadao_bll(_connection);
            List<GTI_Models.Models.Cidadao> Lista = new List<GTI_Models.Models.Cidadao>();
            if (TitleMenu.Tag.ToString() == "Nome")
                Lista = clsCidadao.Lista_Cidadao(_valor, "", "");
            else {
                if (TitleMenu.Tag.ToString() == "CPF")
                    Lista = clsCidadao.Lista_Cidadao("", _valor, "");
                else
                    Lista = clsCidadao.Lista_Cidadao("", "", _valor);
            }

            int _total = Lista.Count;
            if (aDatResult == null) aDatResult = new List<ArrayList>();
            aDatResult.Clear();
            foreach (var item in Lista) {
                ArrayList itemlv = new ArrayList();
                itemlv.Add(item.Codcidadao.ToString("000000"));
                itemlv.Add(item.Nomecidadao);
                if (!String.IsNullOrEmpty(item.Cpf) && gtiCore.IsNumeric(item.Cpf))
                    itemlv.Add(String.Format(@"{0:000\.000\.000\-00}", Convert.ToDecimal(Regex.Match(item.Cpf, @"\d+").Value)));
                else
                    itemlv.Add("");
                if (!String.IsNullOrEmpty(item.Cnpj))
                    itemlv.Add(String.Format(@"{0:00\.000\.000\/0000\-00}", Convert.ToDecimal(Regex.Match(item.Cnpj, @"\d+").Value)));
                else
                    itemlv.Add("");
                aDatResult.Add(itemlv);
            }
            MainListView.BeginUpdate();
            MainListView.VirtualListSize = aDatResult.Count;
            MainListView.EndUpdate();

            TotalCidadao.Text = _total.ToString();
            gtiCore.Liberado(this);
            if (MainListView.Items.Count == 0)
                MessageBox.Show("Nenhum contribuinte coincide com os critérios especificados", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void TxtBusca_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Return) {
                e.Handled = true;
                BtFind_Click(sender, e);
            }
        }

        private void BtReturn_Click(object sender, EventArgs e) {
            ListView.SelectedIndexCollection col = MainListView.SelectedIndices;
            if (col.Count > 0) {
                DialogResult = DialogResult.OK;
                ReturnValue = Convert.ToInt32(MainListView.Items[col[0]].Text);
                SaveDatFile();
                Close();
            } else {
                MessageBox.Show("Selecione um Cidadão.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lvMain_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
            var acc = aDatResult[e.ItemIndex];
            e.Item = new ListViewItem(
                new string[]
                { acc[0].ToString(), acc[1].ToString(), acc[2].ToString() ,acc[3].ToString()}) {
                Tag = acc,
                BackColor = e.ItemIndex % 2 == 0 ? Color.Beige : Color.White
            };
        }

        private void SaveDatFile() {
            List<string> aLista = new List<string>();
            string[] aReg = new string[8];
            string[] aTmp = new string[1];
            aLista.Add(gtiCore.ConvertDatReg("ZZ", _File_Version.ToString().Split())); //Versão do arquivo
            aLista.Add(gtiCore.ConvertDatReg("DS", new[] { BuscaText.Text }));

            for (int i = 0; i < MainListView.VirtualListSize; i++) {
                aReg[0] = MainListView.Items[i].Text;
                aReg[1] = MainListView.Items[i].SubItems[1].Text;
                aReg[2] = MainListView.Items[i].SubItems[2].Text == "" ? " " : MainListView.Items[i].SubItems[2].Text;
                aReg[3] = MainListView.Items[i].SubItems[3].Text == "" ? " " : MainListView.Items[i].SubItems[3].Text;
                aLista.Add(gtiCore.ConvertDatReg("CD", aReg));
            }

            string sDir = AppDomain.CurrentDomain.BaseDirectory;
            gtiCore.CreateDatFile(sDir + "\\gti002.dat", aLista);
        }

        private void ReadDatFile() {
            string sDir = AppDomain.CurrentDomain.BaseDirectory;
            string sFileName = "\\gti002.dat";
            //se o arquivo não existir, então não tem o que ler.
            if (!File.Exists(sDir + sFileName)) return;
            //se o arquivo for de outro dia, então não ler.
            if (File.GetLastWriteTime(sDir + sFileName).ToString("MM/dd/yyyy") != DateTime.Now.ToString("MM/dd/yyyy")) return;
            //lê o q arquivo
            try {
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "ZZ");
                if (Convert.ToInt32(aDatResult[0][0].ToString()) != _File_Version) {
                    return;
                }

                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "DS");
                if (aDatResult[0].Count > 0)
                    BuscaText.Text = aDatResult[0][0].ToString();

                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "CD",false);
                MainListView.VirtualListSize = aDatResult.Count;
            } catch  {
            }
        }


    }
}
