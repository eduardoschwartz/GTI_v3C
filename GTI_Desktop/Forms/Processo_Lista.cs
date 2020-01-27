using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static GTI_Desktop.Classes.GtiTypes;

namespace GTI_Desktop.Forms {
    public partial class Processo_Lista : Form
    {
        string _connection = gtiCore.Connection_Name();
        public ProcessoNumero ReturnValue { get; set; } = new ProcessoNumero();
        List<ArrayList> aDatResult;
        int _File_Version = Properties.Settings.Default.gti_003_version;

        public Processo_Lista()
        {
            InitializeComponent();
            tBar.Renderer = new MySR();
            ProprietarioToolStrip.Renderer = new MySR();
            this.Size = new System.Drawing.Size(Properties.Settings.Default.Form_Processo_Lista_width, Properties.Settings.Default.Form_Processo_Lista_height);
            InternoList.SelectedIndex = 0;
            FisicoList.SelectedIndex = 0;
            Carrega_Lista();
            ReadDatFile();
        }

        private void Carrega_Lista() {
            Processo_bll processo_Class = new Processo_bll(_connection);
            List<CustomListBoxItem> myItems = new List<CustomListBoxItem> {
                new CustomListBoxItem("(Não selecionado)", 0)
            };
            List<GTI_Models.Models.Assunto> lista = processo_Class.Lista_Assunto(true, false);
            foreach (GTI_Models.Models.Assunto item in lista) {
                myItems.Add(new CustomListBoxItem(item.Nome , item.Codigo));
            }
            AssuntoList.DisplayMember = "_name";
            AssuntoList.ValueMember = "_value";
            AssuntoList.DataSource = myItems;
            AssuntoList.SelectedIndex = 0;

            myItems = new List<CustomListBoxItem> {
                new CustomListBoxItem("(Não selecionado)", 0)
            };
            List<GTI_Models.Models.Centrocusto> listaCC = processo_Class.Lista_Local(true, false);
            foreach (GTI_Models.Models.Centrocusto item in listaCC) {
                myItems.Add(new CustomListBoxItem(item.Descricao, item.Codigo));
            }
            SetorList.DisplayMember = "_name";
            SetorList.ValueMember = "_value";
            SetorList.DataSource = myItems;
            SetorList.SelectedIndex = 0;

        }

        private void ReadDatFile() {
            string sDir = AppDomain.CurrentDomain.BaseDirectory;
            string sFileName = "\\gti003.dat";
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

                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "NP");
                if (aDatResult[0].Count > 0)
                    NumeroProcesso.Text = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "AI");
                if (aDatResult[0].Count > 0)
                    AnoInicial.Text = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "AF");
                if (aDatResult[0].Count > 0)
                    AnoFinal.Text = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "DE");
                if (aDatResult[0].Count > 0)
                    DataEntrada.Text = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "RQ");
                if (aDatResult[0].Count > 0)
                    Requerente.Text = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "FI");
                if (aDatResult[0].Count > 0)
                    FisicoList.SelectedIndex = Convert.ToInt32(aDatResult[0][0].ToString());
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "IN");
                if (aDatResult[0].Count > 0)
                    InternoList.SelectedIndex = Convert.ToInt32(aDatResult[0][0].ToString());
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "CC");
                if (aDatResult[0].Count > 0)
                    SetorList.SelectedIndex = Convert.ToInt32(aDatResult[0][0].ToString());
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "AS");
                if (aDatResult[0].Count > 0)
                    AssuntoList.SelectedIndex = Convert.ToInt32(aDatResult[0][0].ToString());
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "CP");
                if (aDatResult[0].Count > 0)
                    Complemento.Text = aDatResult[0][0].ToString();


                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "PC", false);
                MainListView.VirtualListSize = aDatResult.Count;
            } catch {
            }
        }

        private void SaveDatFile() {
            List<string> aLista = new List<string>();
            string[] aReg = new string[12];
            string[] aTmp = new string[1];

            aLista.Add(gtiCore.ConvertDatReg("ZZ", _File_Version.ToString().Split())); //Versão do arquivo
            aLista.Add(gtiCore.ConvertDatReg("NP", new[] { NumeroProcesso.Text }));
            aLista.Add(gtiCore.ConvertDatReg("AI", new[] { AnoInicial.Text }));
            aLista.Add(gtiCore.ConvertDatReg("AF", new[] { AnoFinal.Text }));
            aLista.Add(gtiCore.ConvertDatReg("DE", new[] { DataEntrada.Text }));
            aLista.Add(gtiCore.ConvertDatReg("RQ", new[] { Requerente.Text }));
            aLista.Add(gtiCore.ConvertDatReg("FI", new[] { FisicoList.SelectedIndex.ToString() }));
            aLista.Add(gtiCore.ConvertDatReg("IN", new[] { InternoList.SelectedIndex.ToString() }));
            aLista.Add(gtiCore.ConvertDatReg("CC", new[] { SetorList.SelectedIndex.ToString() }));
            aLista.Add(gtiCore.ConvertDatReg("AS", new[] { AssuntoList.SelectedIndex.ToString() }));
            aLista.Add(gtiCore.ConvertDatReg("CP", new[] { Complemento.Text }));


            for (int i = 0; i < MainListView.VirtualListSize; i++) {
                aReg[0] = MainListView.Items[i].Text;
                aReg[1] = MainListView.Items[i].SubItems[1].Text;
                aReg[2] = MainListView.Items[i].SubItems[2].Text;
                aReg[3] = MainListView.Items[i].SubItems[3].Text == "" ? " " : MainListView.Items[i].SubItems[3].Text;
                aReg[4] = MainListView.Items[i].SubItems[4].Text == "" ? " " : MainListView.Items[i].SubItems[4].Text;
                aReg[5] = MainListView.Items[i].SubItems[5].Text == "" ? " " : MainListView.Items[i].SubItems[5].Text;
                aReg[6] = MainListView.Items[i].SubItems[6].Text == "" ? " " : MainListView.Items[i].SubItems[6].Text;
                aReg[7] = MainListView.Items[i].SubItems[7].Text == "" ? " " : MainListView.Items[i].SubItems[7].Text;
                aReg[8] = MainListView.Items[i].SubItems[8].Text == "" ? " " : MainListView.Items[i].SubItems[8].Text;
                aReg[9] = MainListView.Items[i].SubItems[9].Text == "" ? " " : MainListView.Items[i].SubItems[9].Text;
                aReg[10] = MainListView.Items[i].SubItems[10].Text == "" ? " " : MainListView.Items[i].SubItems[10].Text;
                aLista.Add(gtiCore.ConvertDatReg("PC", aReg));
            }

            string sDir = AppDomain.CurrentDomain.BaseDirectory;
            gtiCore.CreateDatFile(sDir + "\\gti003.dat", aLista);
        }

        private void SelectButton_Click(object sender, System.EventArgs e) {
            ListView.SelectedIndexCollection col = MainListView.SelectedIndices;
            if (col.Count > 0) {
                DialogResult = DialogResult.OK;
                ReturnValue.Ano = Convert.ToInt32(MainListView.Items[col[0]].Text);
                ReturnValue.Numero = Convert.ToInt32(MainListView.Items[col[0]].SubItems[1].Text.Substring(0,5));
                Close();
            } else {
                MessageBox.Show("Selecione um processo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AnoInicial_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void AnoFinal_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void Fill_List() {
            gtiCore.Ocupado(this);

            //***Construção do filtro ****
            Processo_bll processo_Class = new Processo_bll(_connection);
            ProcessoFilter Reg = new ProcessoFilter();
            if (!string.IsNullOrEmpty(NumeroProcesso.Text)) {
                Reg.Ano = processo_Class.ExtractAnoProcesso(NumeroProcesso.Text);
                Reg.Numero = processo_Class.ExtractNumeroProcessoNoDV(NumeroProcesso.Text);
                Reg.SNumProcesso = NumeroProcesso.Text;
            } else {
                Reg.Ano = 0;
                Reg.Numero = 0;
                Reg.SNumProcesso = "";
            }
            Reg.AnoIni = AnoInicial.Text.Trim() == "" ? 0 : Convert.ToInt32(AnoInicial.Text);
            Reg.AnoFim = AnoFinal.Text.Trim() == "" ? 0 : Convert.ToInt32(AnoFinal.Text);
            if (gtiCore.IsDate(DataEntrada.Text))
                Reg.DataEntrada = Convert.ToDateTime(DataEntrada.Text);
            Reg.Requerente = Requerente.Text.Trim() == "" ? 0 : Convert.ToInt32(Requerente.Text);
            if (FisicoList.SelectedIndex > 0)
                Reg.Fisico = FisicoList.SelectedIndex == 1 ? true : false;
            if (InternoList.SelectedIndex > 0)
                Reg.Interno = InternoList.SelectedIndex == 1 ? true : false;

            CustomListBoxItem selectedItem = (CustomListBoxItem)SetorList.SelectedItem;
            Reg.Setor = SetorList.SelectedIndex == 0 ? 0 : selectedItem._value;
            selectedItem = (CustomListBoxItem)AssuntoList.SelectedItem;
            Reg.AssuntoCodigo = AssuntoList.SelectedIndex == 0 ? 0 : selectedItem._value;
            Reg.Complemento = Complemento.Text.Trim();
            if (Reg.Setor > 0) Reg.Interno = true;

            //********************************

            List<ProcessoStruct> Lista = processo_Class.Lista_Processos(Reg);
            List<ProcessoNumero> aCount = new List<ProcessoNumero>(); //usado na totalização dos processos
            
            int _total = 0;
            if (aDatResult == null) aDatResult = new List<ArrayList>();
            aDatResult.Clear();
            foreach (var item in Lista) {

                //Array para totalizar os processos distintos, desta forma processos com mais de um endereço serão contados apenas 1 vez.
                bool bFind = false;
                for (int i = 0; i < aCount.Count; i++) {
                    if (aCount[i].Ano==item.Ano && aCount[i].Numero == item.Numero) {
                        bFind = true;
                        break;
                    }
                }
                if (!bFind) {
                    aCount.Add(new ProcessoNumero { Ano = item.Ano, Numero = item.Numero });
                    _total++;
                }

                string _nome = item.Interno ? item.CentroCustoNome : item.NomeCidadao;
                //******************************************

                ArrayList itemlv = new ArrayList {
                    item.Ano.ToString(),
                    item.Numero.ToString("00000") + "-" + processo_Class.DvProcesso(item.Numero),
                    _nome ?? "",
                    item.Assunto ?? "",
                    Convert.ToDateTime(item.DataEntrada).ToString("dd/MM/yyyy")
                };
                if (item.DataCancelado != null)
                    itemlv.Add(Convert.ToDateTime(item.DataCancelado).ToString("dd/MM/yyyy"));
                else
                    itemlv.Add("");
                if (item.DataArquivado != null)
                    itemlv.Add(Convert.ToDateTime(item.DataArquivado).ToString("dd/MM/yyyy"));
                else
                    itemlv.Add("");
                if (item.DataReativacao != null)
                    itemlv.Add(Convert.ToDateTime(item.DataReativacao).ToString("dd/MM/yyyy"));
                else
                    itemlv.Add("");
                if (item.Interno )
                    itemlv.Add("S");
                else
                    itemlv.Add("N");
                if (item.Fisico)
                    itemlv.Add("S");
                else
                    itemlv.Add("N");
                string sEndereco = item.LogradouroNome ?? "";
                string sNumero = item.LogradouroNumero ?? "";
                if (sEndereco != "")
                    itemlv.Add(sEndereco + ", " + sNumero ?? "");
                else
                    itemlv.Add("");

                aDatResult.Add(itemlv);
            }
            MainListView.BeginUpdate();
            MainListView.VirtualListSize = aDatResult.Count;
            MainListView.EndUpdate();

            Total.Text = _total.ToString();
            gtiCore.Liberado(this);
            if (MainListView.Items.Count == 0)
                MessageBox.Show("Nenhum contribuinte coincide com os critérios especificados", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void MainListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
            var acc = aDatResult[e.ItemIndex];
            e.Item = new ListViewItem(
                new string[]
                { acc[0].ToString(), acc[1].ToString(), acc[2].ToString() ,acc[3].ToString(),acc[4].ToString(),acc[5].ToString(),acc[6].ToString(),acc[7].ToString(),
                    acc[8].ToString(),acc[9].ToString(),acc[10].ToString()}) {
                Tag = acc,
                BackColor = e.ItemIndex % 2 == 0 ? Color.Beige : Color.White
            };
        }

        private void FindButton_Click(object sender, EventArgs e) {
            MainListView.Items.Clear();
            if (ValidaProcesso())
                if (NumeroProcesso.Text == "" && AnoInicial.Text == "" && AnoFinal.Text == "" && gtiCore.IsEmptyDate(DataEntrada.Text) && 
                    Requerente.Text == "" && SetorList.SelectedIndex == 0 && AssuntoList.SelectedIndex==0  && Complemento.Text=="")
                    MessageBox.Show("Nenhum filtro selecionado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Fill_List();
            else
                MessageBox.Show("Nenhum processo coincide com o filtro selecionado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NumeroProcesso_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != (char)Keys.Return && e.KeyChar != (char)Keys.Tab) {
                const char Delete = (char)8;
                const char Minus = (char)45;
                const char Barra = (char)47;
                if (e.KeyChar == Minus && NumeroProcesso.Text.Contains("-"))
                    e.Handled = true;
                else {
                    if (e.KeyChar == Barra && NumeroProcesso.Text.Contains("/"))
                        e.Handled = true;
                    else
                        e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete && e.KeyChar != Barra && e.KeyChar != Minus;
                }
            }
        }

        private bool ValidaProcesso() {
            bool bRet = true;
            if (!String.IsNullOrEmpty(NumeroProcesso.Text)) {
                Processo_bll clsProcesso = new Processo_bll(_connection);
                Exception ex = clsProcesso.ValidaProcesso(NumeroProcesso.Text);
                if (ex != null) 
                    bRet = false;
            } 
            return bRet;
        }
      
        private void Requerente_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void ExcelButton_Click(object sender, EventArgs e) {
            using (SaveFileDialog sfd = new SaveFileDialog() {
                Filter = "Excel |* .xlsx",
                InitialDirectory = @"c:\dados\xlsx",
                FileName = "Consulta_Processos.xlsx",
                ValidateNames = true
            }) {
                if (sfd.ShowDialog() == DialogResult.OK) {
                    gtiCore.Ocupado(this);
                    string file = sfd.FileName;

                    ExcelPackage package = new ExcelPackage();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Lista");
                    worksheet.Cells[1, 1].Value = "Ano";
                    worksheet.Cells[1, 2].Value = "Número";
                    worksheet.Cells[1, 3].Value = "Requerente";
                    worksheet.Cells[1, 4].Value = "Assunto";
                    worksheet.Cells[1, 5].Value = "Dt.Entrada";
                    worksheet.Cells[1, 6].Value = "Dt.Cancel";
                    worksheet.Cells[1, 7].Value = "Dt.Arquiva";
                    worksheet.Cells[1, 8].Value = "Dt.Reativa";
                    worksheet.Cells[1, 9].Value = "Físico";
                    worksheet.Cells[1, 10].Value = "Interno";
                    worksheet.Cells[1, 11].Value = "Endereço";

                    int r = 2;
                    for (int i = 0; i < MainListView.VirtualListSize; i++) {
                        worksheet.Cells[i + r, 1].Value = MainListView.Items[i].Text;
                        worksheet.Cells[i + r, 2].Value = MainListView.Items[i].SubItems[1].Text;
                        worksheet.Cells[i + r, 3].Value = MainListView.Items[i].SubItems[2].Text;
                        worksheet.Cells[i + r, 4].Value = MainListView.Items[i].SubItems[3].Text;
                        worksheet.Cells[i + r, 5].Value = MainListView.Items[i].SubItems[4].Text;
                        worksheet.Cells[i + r, 6].Value = MainListView.Items[i].SubItems[5].Text;
                        worksheet.Cells[i + r, 7].Value = MainListView.Items[i].SubItems[6].Text;
                        worksheet.Cells[i + r, 8].Value = MainListView.Items[i].SubItems[7].Text;
                        worksheet.Cells[i + r, 9].Value = MainListView.Items[i].SubItems[8].Text;
                        worksheet.Cells[i + r, 10].Value = MainListView.Items[i].SubItems[9].Text;
                        worksheet.Cells[i + r, 11].Value = MainListView.Items[i].SubItems[10].Text;
                    }

                    worksheet.Cells.AutoFitColumns(0);  //Autofit columns for all cells
                    var xlFile = gtiCore.GetFileInfo(sfd.FileName);
                    package.SaveAs(xlFile);

                    gtiCore.Liberado(this);
                    MessageBox.Show("Seus dados foram exportados para o Excel com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e) {
            NumeroProcesso.Text = "";
            AnoInicial.Text = "";
            AnoFinal.Text = "";
            DataEntrada.Text = "";
            Requerente.Text = "";
            FisicoList.SelectedIndex = 0;
            InternoList.SelectedIndex = 0;
            SetorList.SelectedIndex = 0;
            AssuntoList.SelectedIndex = 0;
            Complemento.Text = "";
            MainListView.VirtualListSize=0;
            MainListView.Invalidate();
        }

        private void Processo_Lista_FormClosing(object sender, FormClosingEventArgs e) {
            SaveDatFile();
            Properties.Settings.Default.Form_Processo_Lista_width = this.Size.Width;
            Properties.Settings.Default.Form_Processo_Lista_height = this.Size.Height;
            Properties.Settings.Default.Save();
        }
    }
}
