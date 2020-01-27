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

namespace GTI_Desktop.Forms {
    public partial class Imovel_Lista : Form {
        string _connection = gtiCore.Connection_Name();
        public int ReturnValue { get; set; }
        List<ArrayList> aDatResult;
        int _File_Version = Properties.Settings.Default.gti_001_version;

        public Imovel_Lista() {
            InitializeComponent();
            tBar.Renderer = new MySR();
            EnderecoToolStrip.Renderer = new MySR();
            ProprietarioToolStrip.Renderer = new MySR();
            CondominioToolStrip.Renderer = new MySR();
            ReadDatFile();
            string[] _ordem = new string[] { "Código", "Inscrição", "Proprietário", "Endereco", "Bairro", "Condomínio" };
            OrdemList.Items.AddRange(_ordem);
            OrdemList.SelectedIndex = 0;

        }

        private void SelectButton_Click(object sender, EventArgs e) {
            ListView.SelectedIndexCollection col = MainListView.SelectedIndices;
            if (col.Count > 0) {
                DialogResult = DialogResult.OK;
                ReturnValue = Convert.ToInt32(MainListView.Items[col[0]].Text);
                SaveDatFile();
                Close();
            } else {
                MessageBox.Show("Selecione um imóvel.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void SaveDatFile() {
            List<string> aLista = new List<string>();
            string[] aReg = new string[8];
            string[] aTmp = new string[1];

            aLista.Add(gtiCore.ConvertDatReg("ZZ", _File_Version.ToString().Split())); //Versão do arquivo
            aLista.Add(gtiCore.ConvertDatReg("CD", Codigo.Text.Split()));
            aLista.Add(gtiCore.ConvertDatReg("PR", PrincipalCheckBox.Checked.ToString().Split()));
            aTmp[0] = Inscricao.Text;
            aLista.Add(gtiCore.ConvertDatReg("IC", aTmp));
            if (Proprietario.Tag == null || Proprietario.Tag.ToString() == "") Proprietario.Tag = "0";
            aTmp[0] = Proprietario.Text;
            aLista.Add(gtiCore.ConvertDatReg("PP", aTmp));
            aLista.Add(gtiCore.ConvertDatReg("Pt", Proprietario.Tag.ToString().Split()));
            if (Logradouro.Tag == null || Logradouro.Tag.ToString() == "") Logradouro.Tag = "0";
            aTmp[0] = Logradouro.Text;
            aLista.Add(gtiCore.ConvertDatReg("LG", aTmp));
            aLista.Add(gtiCore.ConvertDatReg("Lt", Logradouro.Tag.ToString().Split()));
            aLista.Add(gtiCore.ConvertDatReg("NM", Numero.Text.Split()));
            if (Bairro.Tag == null || Bairro.Tag.ToString() == "") Bairro.Tag = "0";
            aTmp[0] = Bairro.Text;
            aLista.Add(gtiCore.ConvertDatReg("BR", aTmp));
            aLista.Add(gtiCore.ConvertDatReg("Bt", Bairro.Tag.ToString().Split()));
            if (Condominio.Tag == null || Condominio.Tag.ToString() == "") Condominio.Tag = "0";
            aTmp[0] = Condominio.Text;
            aLista.Add(gtiCore.ConvertDatReg("CN", aTmp));
            aLista.Add(gtiCore.ConvertDatReg("Ct", Condominio.Tag.ToString().Split()));

            for (int i = 0; i < MainListView.VirtualListSize; i++) {
                aReg[0] = MainListView.Items[i].Text;
                aReg[1] = MainListView.Items[i].SubItems[1].Text;
                aReg[2] = MainListView.Items[i].SubItems[2].Text;
                aReg[3] = MainListView.Items[i].SubItems[3].Text == "" ? " " : MainListView.Items[i].SubItems[3].Text;
                aReg[4] = MainListView.Items[i].SubItems[4].Text == "" ? " " : MainListView.Items[i].SubItems[4].Text;
                aReg[5] = MainListView.Items[i].SubItems[5].Text == "" ? " " : MainListView.Items[i].SubItems[5].Text;
                aReg[6] = MainListView.Items[i].SubItems[6].Text == "" ? " " : MainListView.Items[i].SubItems[6].Text;
                aReg[7] = MainListView.Items[i].SubItems[7].Text == "" ? " " : MainListView.Items[i].SubItems[7].Text;
                aLista.Add(gtiCore.ConvertDatReg("IM", aReg));
            }

            string sDir = AppDomain.CurrentDomain.BaseDirectory;
            gtiCore.CreateDatFile(sDir + "\\gti001.dat", aLista);
        }

        private void ReadDatFile() {
            string sDir = AppDomain.CurrentDomain.BaseDirectory;
            string sFileName = "\\gti001.dat";
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

                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "CD");
                if (aDatResult[0].Count > 0)
                    Codigo.Text = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "PR");
                if (aDatResult[0].Count > 0)
                    PrincipalCheckBox.Checked = Convert.ToBoolean(aDatResult[0][0]);
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "IC");
                if (aDatResult[0].Count > 0)
                    Inscricao.Text = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "PP");
                if (aDatResult[0].Count > 0)
                    Proprietario.Text = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "Pt");
                if (aDatResult[0].Count > 0)
                    Proprietario.Tag = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "LG");
                if (aDatResult[0].Count > 0)
                    Logradouro.Text = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "Lt");
                if (aDatResult[0].Count > 0)
                    Logradouro.Tag = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "NM");
                if (aDatResult[0].Count > 0)
                    Numero.Text = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "BR");
                if (aDatResult[0].Count > 0)
                    Bairro.Text = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "Bt");
                if (aDatResult[0].Count > 0)
                    Bairro.Tag = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "CN");
                if (aDatResult[0].Count > 0)
                    Condominio.Text = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "Ct");
                if (aDatResult[0].Count > 0)
                    Condominio.Tag = aDatResult[0][0].ToString();

                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "IM", false);
                MainListView.VirtualListSize = aDatResult.Count;
            } catch {
            }

        }

        private void ProprietarioButton_Click(object sender, EventArgs e) {
            using (var form = new Cidadao_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    int val = form.ReturnValue;
                    Sistema_bll sistema_Class = new Sistema_bll(_connection);
                    Contribuinte_Header_Struct reg = sistema_Class.Contribuinte_Header(val);
                    Proprietario.Text = reg.Nome;
                    Proprietario.Tag = val.ToString();
                }
            }
        }

        private void CallPB(System.Windows.Forms.ToolStripProgressBar pBar, int nPos, int nTot) {
            pBar.Value = nPos * 100 / nTot;
        }

        private void FindButton_Click(object sender, EventArgs e) {

            MainListView.BeginUpdate();
            MainListView.VirtualListSize = 0;
            MainListView.EndUpdate();

            gtiCore.Ocupado(this);
            Imovel_bll imovel_Class = new Imovel_bll(_connection);

            ImovelStruct Reg = new ImovelStruct {
                Codigo = string.IsNullOrEmpty(Codigo.Text) ? 0 : Convert.ToInt32(Codigo.Text),
                Proprietario_Principal = PrincipalCheckBox.Checked
            };
            if (Proprietario.Tag == null || Proprietario.Tag.ToString() == "") Proprietario.Tag = "0";
            Reg.Proprietario_Codigo = Convert.ToInt32(Proprietario.Tag.ToString());
            Reg.Distrito = Inscricao.Text.Substring(0, 1).Trim() == "" ? (short)0 : Convert.ToInt16(Inscricao.Text.Substring(0, 1).Trim());
            Reg.Setor = Inscricao.Text.Substring(2, 2).Trim() == "" ? (short)0 : Convert.ToInt16(Inscricao.Text.Substring(2, 2).Trim());
            Reg.Quadra = Inscricao.Text.Substring(5, 4).Trim() == "" ? (short)0 : Convert.ToInt16(Inscricao.Text.Substring(5, 4).Trim());
            Reg.Lote = Inscricao.Text.Substring(10, 5).Trim() == "" ? 0 : Convert.ToInt32(Inscricao.Text.Substring(10, 5).Trim());
            Condominio.Tag = Condominio.Tag ?? "";
            Reg.CodigoCondominio = string.IsNullOrWhiteSpace(Condominio.Tag.ToString()) ? 0 : Convert.ToInt32(Condominio.Tag.ToString());
            Logradouro.Tag = Logradouro.Tag ?? "";
            Reg.CodigoLogradouro = string.IsNullOrWhiteSpace(Logradouro.Tag.ToString()) ? 0 : Convert.ToInt32(Logradouro.Tag.ToString());
            Bairro.Tag = Bairro.Tag ?? "";
            Reg.CodigoBairro = string.IsNullOrWhiteSpace(Bairro.Tag.ToString()) ? (short)0 : Convert.ToInt16(Bairro.Tag.ToString());
            Reg.Numero = Numero.Text.Trim() == "" ? (short)0 : Convert.ToInt16(Numero.Text);

            if (Reg.Codigo == 0 && Reg.Proprietario_Codigo == 0 && Reg.Distrito == 0 && Reg.Setor == 0 & Reg.Quadra == 0 & Reg.Lote == 0 && Reg.CodigoCondominio == 0 &&
                Reg.CodigoLogradouro == 0 && Reg.Numero == 0 && Reg.CodigoBairro == 0) {
                gtiCore.Liberado(this);
//                MessageBox.Show("Selecione ao menos um critério para filtrar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MainListView.ListViewItemSorter = null;
            ImovelStruct _orderby = new ImovelStruct();
            if (OrdemList.SelectedIndex == 0)
                _orderby.Codigo = 1;
            else if (OrdemList.SelectedIndex == 1)
                _orderby.Inscricao = "X";
            else if (OrdemList.SelectedIndex == 2)
                _orderby.Proprietario_Nome = "X";
            else if (OrdemList.SelectedIndex == 3)
                _orderby.NomeLogradouro = "X";
            else if (OrdemList.SelectedIndex == 4)
                _orderby.NomeBairro = "X";
            else if (OrdemList.SelectedIndex == 5)
                _orderby.NomeCondominio = "X";
            List<ImovelStruct> Lista = imovel_Class.Lista_Imovel(Reg, _orderby);

            int _pos = 0, _total = Lista.Count;
            if (aDatResult == null) aDatResult = new List<ArrayList>();
            aDatResult.Clear();
            foreach (var item in Lista) {
                ArrayList itemlv = new ArrayList(8) {
                    item.Codigo.ToString("000000"),
                    item.Inscricao.ToString(),
                    item.Proprietario_Nome.ToString(),
                    item.NomeLogradouro.ToString(),
                    item.Numero.ToString(),
                    item.Complemento == null ? "" : item.Complemento.ToString(),
                    item.NomeBairro.ToString(),
                    item.CodigoCondominio == 999 ? "" : item.NomeCondominio.ToString()
                };
                aDatResult.Add(itemlv);
                _pos++;
            }
            MainListView.BeginUpdate();
            MainListView.VirtualListSize = aDatResult.Count;
            MainListView.EndUpdate();

            TotalImovel.Text = _total.ToString();
            gtiCore.Liberado(this);
            if (MainListView.Items.Count == 0)
                MessageBox.Show("Nenhum imóvel coincide com os critérios especificados", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void CondominioButton_Click(object sender, EventArgs e) {
            using (var form = new Condominio_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    short val = form.ReturnValue;
                    Imovel_bll imovel_Class = new Imovel_bll(_connection);
                    Condominio.Text = imovel_Class.Dados_Condominio(val).Nome;
                    Condominio.Tag = val.ToString();
                }
            }
        }

        private void ProprietarioDelButton_Click(object sender, EventArgs e) {
            Proprietario.Text = "";
            Proprietario.Tag = "";
        }

        private void CondominioDelButton_Click(object sender, EventArgs e) {
            Condominio.Text = "";
            Condominio.Tag = "";
        }

        private void EnderecoAddButton_Click(object sender, EventArgs e) {
            GTI_Models.Models.Endereco reg = new GTI_Models.Models.Endereco {
                Id_pais = 1,
                Sigla_uf = "SP",
                Id_cidade = 413,
            };
            if (Bairro.Tag == null) Bairro.Tag = "0";
            reg.Id_bairro = string.IsNullOrWhiteSpace(Bairro.Tag.ToString()) ? 0 : Convert.ToInt32(Bairro.Tag.ToString());
            if (Logradouro.Tag == null) Logradouro.Tag = "0";
            if (string.IsNullOrWhiteSpace(Logradouro.Tag.ToString()))
                Logradouro.Tag = "0";
            reg.Id_logradouro = string.IsNullOrWhiteSpace(Logradouro.Text) ? 0 : Convert.ToInt32(Logradouro.Tag.ToString());
            reg.Nome_logradouro = Logradouro.Text;
            reg.Numero_imovel = Numero.Text == "" ? 0 : Convert.ToInt32(Numero.Text);
            reg.Complemento = "";
            reg.Email = "";

            Forms.Endereco f1 = new Forms.Endereco(reg, true, true, false, true);
            f1.ShowDialog();
            if (!f1.EndRetorno.Cancelar) {
                Bairro.Text = f1.EndRetorno.Nome_bairro;
                Bairro.Tag = f1.EndRetorno.Id_bairro.ToString();
                Logradouro.Text = f1.EndRetorno.Nome_logradouro;
                Logradouro.Tag = f1.EndRetorno.Id_logradouro.ToString();
                Numero.Text = f1.EndRetorno.Numero_imovel.ToString();
            }
        }

        private void EnderecoDelButton_Click(object sender, EventArgs e) {
            Logradouro.Text = "";
            Logradouro.Tag = "";
            Numero.Text = "";
            Bairro.Text = "";
            Bairro.Tag = "";
        }

        private void ExcelButton_Click(object sender, EventArgs e) {
            if (MainListView.Items.Count == 0) return;
            using (SaveFileDialog sfd = new SaveFileDialog() {
                Filter = "Excel |* .xlsx",
                InitialDirectory = @"c:\dados\xlsx",
                FileName = "Consulta_Imovel.xlsx",
                ValidateNames = true
            }) {
                if (sfd.ShowDialog() == DialogResult.OK) {
                    gtiCore.Ocupado(this);
                    string file = sfd.FileName;

                    ExcelPackage package = new ExcelPackage();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Lista");
                    worksheet.Cells[1, 1].Value = "Código";
                    worksheet.Cells[1, 2].Value = "Inscrição";
                    worksheet.Cells[1, 3].Value = "Proprietário";
                    worksheet.Cells[1, 4].Value = "Endereço";
                    worksheet.Cells[1, 5].Value = "Nº";
                    worksheet.Cells[1, 6].Value = "Compl.";
                    worksheet.Cells[1, 7].Value = "Bairro";
                    worksheet.Cells[1, 8].Value = "Condomínio";

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
                    }

                    worksheet.Cells.AutoFitColumns(0);  //Autofit columns for all cells
                    var xlFile = gtiCore.GetFileInfo(sfd.FileName);
                    package.SaveAs(xlFile);

                    gtiCore.Liberado(this);
                    MessageBox.Show("Seus dados foram exportados para o Excel com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void MainListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
            var acc = aDatResult[e.ItemIndex];
            e.Item = new ListViewItem(
                new string[]
                { acc[0].ToString(), acc[1].ToString(), acc[2].ToString() ,acc[3].ToString(),acc[4].ToString(),acc[5].ToString(),acc[6].ToString(),acc[7].ToString()}) {
                Tag = acc,
                BackColor = e.ItemIndex % 2 == 0 ? Color.Beige : Color.White
            };
        }

        private void Codigo_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return)
                FindButton_Click(sender, e);
        }

        private void OrdemList_SelectedIndexChanged(object sender, EventArgs e) {
            FindButton_Click(sender, e);
        }

        private void ClearButton_Click(object sender, EventArgs e) {
            Codigo.Text = "";
            PrincipalCheckBox.Checked = false;
            Inscricao.Text = "";
            Proprietario.Text = "";
            Proprietario.Tag = "";
            Logradouro.Text = "";
            Numero.Text = "";
            Bairro.Text = "";
            Bairro.Tag = "";
            Condominio.Text = "";
            Condominio.Tag = "";
            MainListView.BeginUpdate();
            MainListView.VirtualListSize = 0;
            MainListView.EndUpdate();
            TotalImovel.Text = "0";
            SaveDatFile();
        }
    }
}
