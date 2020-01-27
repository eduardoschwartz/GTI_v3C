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
    public partial class Empresa_Lista : Form {
        string _connection = gtiCore.Connection_Name();
        public int ReturnValue { get; set; }
        List<ArrayList> aDatResult;
        bool _bExec=false;
        int _File_Version = Properties.Settings.Default.gti_004_version;

        public Empresa_Lista() {
            InitializeComponent();
            _bExec = false;
            tBar.Renderer = new MySR();
            EnderecoToolStrip.Renderer = new MySR();
            ProprietarioToolStrip.Renderer = new MySR();
            AtividadeToolStrip.Renderer = new MySR();
            ReadDatFile();
            string[] _ordem = new string[] { "Código", "Inscrição", "Razão Social", "Atividade", "Endereco", "Bairro" };
            OrdemList.Items.AddRange(_ordem);
            OrdemList.SelectedIndex = 0;
            _bExec = true;
//            gtiCore.Liberado(this);
        }

        private void FindButton_Click(object sender, EventArgs e) {
            if (!_bExec) return;
            MainListView.BeginUpdate();
            MainListView.VirtualListSize = 0;
            MainListView.EndUpdate();

            gtiCore.Ocupado(this);
            Empresa_bll empresa_Class = new Empresa_bll(_connection);

            EmpresaStruct Reg = new EmpresaStruct {
                Codigo = string.IsNullOrEmpty(Codigo.Text) ? 0 : Convert.ToInt32(Codigo.Text),
            };

            Reg.Razao_social = RazaoSocialText.Text.Trim();
            LogradouroText.Tag = LogradouroText.Tag ?? "";
            AtividadeText.Tag = AtividadeText.Tag ?? "";
            Reg.Atividade_codigo = string.IsNullOrWhiteSpace(AtividadeText.Tag.ToString()) ? 0 : Convert.ToInt32(AtividadeText.Tag.ToString());
            Reg.Endereco_codigo = string.IsNullOrWhiteSpace(LogradouroText.Tag.ToString()) ? 0 : Convert.ToInt32(LogradouroText.Tag.ToString());
            BairroText.Tag = BairroText.Tag ?? "";
            Reg.Bairro_codigo = string.IsNullOrWhiteSpace(BairroText.Tag.ToString()) ? (short)0 : Convert.ToInt16(BairroText.Tag.ToString());
            Reg.Numero = NumeroText.Text.Trim() == "" ? (short)0 : Convert.ToInt16(NumeroText.Text);
            if (CNPJOption.Checked) {
                Reg.Juridica = true;
                Reg.Cnpj = CNPJText.Text;
                Reg.Cpf_cnpj = CNPJText.Text;
            } else {
                Reg.Juridica = false;
                Reg.Cnpj = CPFText.Text;
                Reg.Cpf_cnpj = CPFText.Text;
            }

            int _pos = 0, _total = 0;
            if (Reg.Codigo==0 && Reg.Razao_social=="" && Reg.Atividade_codigo==0 && Reg.Endereco_codigo==0 && Reg.Bairro_codigo==0) 
                MessageBox.Show("Selecione ao menos um critério.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else{
                List<EmpresaStruct> Lista = empresa_Class.Lista_Empresa(Reg);
                _total = Lista.Count;
                if (aDatResult == null) aDatResult = new List<ArrayList>();
                aDatResult.Clear();
                foreach (var item in Lista) {
                    ArrayList itemlv = new ArrayList(10) {
                    item.Codigo.ToString("000000"),
                    item.Cpf_cnpj??"",
                    item.Razao_social,
                    item.Socios.Count==0?"":item.Socios[0].Nome,
                    item.Atividade_nome??"",
                    item.Atividade_codigo==null?"0":item.Atividade_codigo.ToString(),
                    item.Endereco_nome??"",
                    item.Numero==null?"0":item.Numero.ToString(),
                    item.Complemento??"",
                    item.Bairro_nome??""
                };
                    aDatResult.Add(itemlv);
                    _pos++;
                }
                MainListView.BeginUpdate();
                MainListView.VirtualListSize = aDatResult.Count;
                MainListView.EndUpdate();
            }
            TotalEmpresa.Text = _total.ToString();

            gtiCore.Liberado(this);

        }

        private void SelectButton_Click(object sender, EventArgs e) {
            ListView.SelectedIndexCollection col = MainListView.SelectedIndices;
            if (col.Count > 0) {
                DialogResult = DialogResult.OK;
                ReturnValue = Convert.ToInt32(MainListView.Items[col[0]].Text);
                SaveDatFile();
                Close();
            } else {
                MessageBox.Show("Selecione uma empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void SaveDatFile() {
            List<string> aLista = new List<string>();
            string[] aReg = new string[10];
            string[] aTmp = new string[1];
            aLista.Add(gtiCore.ConvertDatReg("ZZ", _File_Version.ToString().Split())); //Versão do arquivo
            aLista.Add(gtiCore.ConvertDatReg("CD", Codigo.Text.Split()));
            aTmp[0] = RazaoSocialText.Text;
            aLista.Add(gtiCore.ConvertDatReg("RS", aTmp));
            if (ProprietarioText.Tag == null || ProprietarioText.Tag.ToString() == "") ProprietarioText.Tag = "0";
            aTmp[0] = ProprietarioText.Text;
            aLista.Add(gtiCore.ConvertDatReg("PN", aTmp));
            aLista.Add(gtiCore.ConvertDatReg("PC", ProprietarioText.Tag.ToString().Split()));
            if (AtividadeText.Tag == null || AtividadeText.Tag.ToString() == "") AtividadeText.Tag = "0";
            aTmp[0] = AtividadeText.Text;
            aLista.Add(gtiCore.ConvertDatReg("AN", aTmp));
            aLista.Add(gtiCore.ConvertDatReg("AC", AtividadeText.Tag.ToString().Split()));
            if (LogradouroText.Tag == null || LogradouroText.Tag.ToString() == "") LogradouroText.Tag = "0";
            aTmp[0] = LogradouroText.Text;
            aLista.Add(gtiCore.ConvertDatReg("EN", aTmp));
            aLista.Add(gtiCore.ConvertDatReg("EC", LogradouroText.Tag.ToString().Split()));
            if (BairroText.Tag == null || BairroText.Tag.ToString() == "") BairroText.Tag = "0";
            aTmp[0] = BairroText.Text;
            aLista.Add(gtiCore.ConvertDatReg("BN", aTmp));
            aLista.Add(gtiCore.ConvertDatReg("BC", BairroText.Tag.ToString().Split()));

            for (int i = 0; i < MainListView.VirtualListSize; i++) {
                aReg[0] = MainListView.Items[i].Text;
                aReg[1] = MainListView.Items[i].SubItems[1].Text == "" ? " " : MainListView.Items[i].SubItems[1].Text;
                aReg[2] = MainListView.Items[i].SubItems[2].Text == "" ? " " : MainListView.Items[i].SubItems[2].Text;
                aReg[3] = MainListView.Items[i].SubItems[3].Text == "" ? " " : MainListView.Items[i].SubItems[3].Text;
                aReg[4] = MainListView.Items[i].SubItems[4].Text == "" ? " " : MainListView.Items[i].SubItems[4].Text;
                aReg[5] = MainListView.Items[i].SubItems[5].Text == "" ? " " : MainListView.Items[i].SubItems[5].Text;
                aReg[6] = MainListView.Items[i].SubItems[6].Text == "" ? " " : MainListView.Items[i].SubItems[6].Text;
                aReg[7] = MainListView.Items[i].SubItems[7].Text == "" ? " " : MainListView.Items[i].SubItems[7].Text;
                aReg[8] = MainListView.Items[i].SubItems[8].Text == "" ? " " : MainListView.Items[i].SubItems[8].Text;
                aReg[9] = MainListView.Items[i].SubItems[9].Text == "" ? " " : MainListView.Items[i].SubItems[9].Text;
                aLista.Add(gtiCore.ConvertDatReg("EM", aReg));
            }

            string sDir = AppDomain.CurrentDomain.BaseDirectory;
            gtiCore.CreateDatFile(sDir + "\\gti004.dat", aLista);
        }

        private void ReadDatFile() {
            string sDir = AppDomain.CurrentDomain.BaseDirectory;
            string sFileName = "\\gti004.dat";
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
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "RS");
                if (aDatResult[0].Count > 0)
                    RazaoSocialText.Text = aDatResult[0][0].ToString(); ;
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "PN");
                if (aDatResult[0].Count > 0)
                    ProprietarioText.Text = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "PC");
                if (aDatResult[0].Count > 0)
                    ProprietarioText.Tag = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "AN");
                if (aDatResult[0].Count > 0)
                    AtividadeText.Text = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "AC");
                if (aDatResult[0].Count > 0)
                    AtividadeText.Tag = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "EN");
                if (aDatResult[0].Count > 0)
                    LogradouroText.Text = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "EC");
                if (aDatResult[0].Count > 0)
                    LogradouroText.Tag= aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "BN");
                if (aDatResult[0].Count > 0)
                    BairroText.Text = aDatResult[0][0].ToString();
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "BC");
                if (aDatResult[0].Count > 0)
                    BairroText.Tag = aDatResult[0][0].ToString();

                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "EM", false);
                MainListView.VirtualListSize = aDatResult.Count;
            } catch {
            }


        }

        private void CallPB(ToolStripProgressBar pBar, int nPos, int nTot) {
            pBar.Value = nPos * 100 / nTot;
        }

        private void EnderecoAddButton_Click(object sender, EventArgs e) {
            GTI_Models.Models.Endereco reg = new GTI_Models.Models.Endereco {
                Id_pais = 1,
                Sigla_uf = "SP",
                Id_cidade = 413,
            };
            if (BairroText.Tag == null) BairroText.Tag = "0";
            reg.Id_bairro = string.IsNullOrWhiteSpace(BairroText.Tag.ToString()) ? 0 : Convert.ToInt32(BairroText.Tag.ToString());
            if (LogradouroText.Tag == null) LogradouroText.Tag = "0";
            if (string.IsNullOrWhiteSpace(LogradouroText.Tag.ToString()))
                LogradouroText.Tag = "0";
            reg.Id_logradouro = string.IsNullOrWhiteSpace(LogradouroText.Text) ? 0 : Convert.ToInt32(LogradouroText.Tag.ToString());
            reg.Nome_logradouro = LogradouroText.Text;
            reg.Numero_imovel = NumeroText.Text == "" ? 0 : Convert.ToInt32(NumeroText.Text);
            reg.Complemento = "";
            reg.Email = "";

            Forms.Endereco f1 = new Forms.Endereco(reg, true,  true, false, false);
            f1.ShowDialog();
            if (!f1.EndRetorno.Cancelar) {
                BairroText.Text = f1.EndRetorno.Nome_bairro;
                BairroText.Tag = f1.EndRetorno.Id_bairro.ToString();
                LogradouroText.Text = f1.EndRetorno.Nome_logradouro;
                LogradouroText.Tag = f1.EndRetorno.Id_logradouro.ToString();
                NumeroText.Text = f1.EndRetorno.Numero_imovel.ToString();
            }
        }

        private void EnderecoDelButton_Click(object sender, EventArgs e) {
            LogradouroText.Text = "";
            LogradouroText.Tag = "";
            NumeroText.Text = "";
            BairroText.Text = "";
            BairroText.Tag = "";
        }

        private void ProprietarioDelButton_Click(object sender, EventArgs e) {
            ProprietarioText.Text = "";
            ProprietarioText.Tag = "";
        }

        private void AtividadeDelButton_Click(object sender, EventArgs e) {
            AtividadeText.Text = "";
            AtividadeText.Tag = "";
        }

        private void ExcelButton_Click(object sender, EventArgs e) {
            if (MainListView.Items.Count == 0) return;

            using (SaveFileDialog sfd = new SaveFileDialog() {
                Filter = "Excel |* .xlsx",
                InitialDirectory = @"c:\dados\xlsx",
                FileName = "Consulta_Empresa.xlsx",
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
            if (acc.Count == 10) {
                e.Item = new ListViewItem(new string[] { acc[0].ToString(), acc[1].ToString(), acc[2].ToString(), acc[3].ToString(), acc[4].ToString(), acc[5].ToString(),
                  acc[6].ToString(), acc[7].ToString(), acc[8].ToString(), acc[9].ToString()}) {  Tag = acc, BackColor = e.ItemIndex % 2 == 0 ? Color.Beige : Color.White };
            }
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
            CNPJOption.Checked = true;
            RazaoSocialText.Text = "";
            AtividadeText.Text = "";
            AtividadeText.Tag = "";
            LogradouroText.Text = "";
            BairroText.Text = "";
            BairroText.Tag = "";
            NumeroText.Text = "";
            MainListView.BeginUpdate();
            MainListView.VirtualListSize = 0;
            MainListView.EndUpdate();
            TotalEmpresa.Text = "0";
            SaveDatFile();
        }

        private void CPFOption_CheckedChanged(object sender, EventArgs e) {
            CNPJText.Text = "";
            CNPJText.Visible = false;
            CPFText.Visible = true;
            CPFText.Focus();
        }

        private void CNPJOption_CheckedChanged(object sender, EventArgs e) {
            CPFText.Text = "";
            CPFText.Visible = false;
            CNPJText.Visible = true;
            CNPJText.Focus();
        }

        private void AtividadeAddButton_Click(object sender, EventArgs e) {
            Empresa_Atividade f1 = new Empresa_Atividade(0,false) {
                Tag = Name
            };
            var result = f1.ShowDialog(this);
            if (result == DialogResult.OK) {
                int _id_atividade = f1.ReturnValue;
                Empresa_bll empresa_Class = new Empresa_bll(_connection);
                string _nome_atividade = empresa_Class.Retorna_Nome_Atividade(_id_atividade);
                AtividadeText.Text = _id_atividade.ToString() + " - " + _nome_atividade;
                AtividadeText.Tag = _id_atividade.ToString();
            }

        }

        private void ProprietarioAddButton_Click(object sender, EventArgs e) {
            using (var form = new Cidadao_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    int val = form.ReturnValue;
                    Cidadao_bll cidadao_Class = new Cidadao_bll(_connection);
                    string _nome = cidadao_Class.Retorna_Nome_Cidadao(val);
                    ProprietarioText.Text = _nome;
                    ProprietarioText.Tag = val.ToString();
                }
            }
        }



    }
}
