using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OfficeOpenXml;

namespace GTI_Desktop.Forms {
    public partial class Processo_Atraso : Form {
        
        string _connection = gtiCore.Connection_Name();
        List<ArrayList> aDatResult;

        public Processo_Atraso() {
            InitializeComponent();
        }

        private void GerarButton_Click(object sender, EventArgs e) {
            Processo_bll processo_Class = new Processo_bll(_connection);
            int _ano = 0, _numero = 0, _pos = 1;
            string _numero_processo,_assunto,_requerente,_data_entrada;

            if (aDatResult == null) aDatResult = new List<ArrayList>();
            aDatResult.Clear();
            gtiCore.Ocupado(this);

            ProcessoFilter Reg = new ProcessoFilter();
            Reg.AnoIni = 2017;
            Reg.AnoFim = 2017;
            Reg.Arquivado = false;
            List<ProcessoStruct>ListaProcesso= processo_Class.Lista_Processos(Reg);
            int _total = ListaProcesso.Count;

            foreach (ProcessoStruct _processo in ListaProcesso) {

                if (_pos % 10 == 0) {
                    PBar.Value = _pos * 100 / _total;
                    PBar.Update();
                    System.Windows.Forms.Application.DoEvents();
                    break;
                }

                _ano = _processo.Ano;
                _numero = _processo.Numero;
                _numero_processo = _numero.ToString("00000") + "-" + processo_Class.DvProcesso(_numero).ToString();
                _assunto = _processo.Complemento ?? "";
                _requerente = _processo.NomeCidadao == null ? _processo.CentroCustoNome : _processo.NomeCidadao;
                _data_entrada = Convert.ToDateTime(_processo.DataEntrada).ToString("dd/MM/yyyy");


                List<TramiteStruct> ListaTramite = processo_Class.DadosTramite((short)_ano, _numero, 0);
                string _ultimo_tramite = "",_ultimo_despacho="",_proximo_tramite="";
                DateTime _data_envio=DateTime.Now;

                if (_numero == 180)
                    _ano = 23;
                for (int i = ListaTramite.Count - 1; i >=0 ; i--) {
                    if (!string.IsNullOrWhiteSpace(ListaTramite[i].DataEntrada)) {
                        if (string.IsNullOrWhiteSpace(ListaTramite[i].DataEnvio)) {
                            if (i > 0) {
                                if (string.IsNullOrWhiteSpace(ListaTramite[i - 1].DataEnvio))
                                    _data_envio = Convert.ToDateTime(ListaTramite[i].DataEntrada);
                                else
                                    _data_envio = Convert.ToDateTime(ListaTramite[i - 1].DataEnvio);

                                _ultimo_tramite = ListaTramite[i - 1].CentroCustoNome;
                                _ultimo_despacho = ListaTramite[i - 1].DespachoNome;
                            } else {
                                _data_envio = Convert.ToDateTime(ListaTramite[i].DataEntrada);

                                _ultimo_tramite = ListaTramite[i].CentroCustoNome;
                                _ultimo_despacho = ListaTramite[i].DespachoNome;
                            }
                            _proximo_tramite = ListaTramite[i].CentroCustoNome;
                        } else {
                            if (i == ListaTramite.Count - 1) goto Proximo;
                            _data_envio = Convert.ToDateTime(ListaTramite[i].DataEnvio);
                            _ultimo_tramite = ListaTramite[i].CentroCustoNome;
                            _ultimo_despacho = ListaTramite[i].DespachoNome;
                            _proximo_tramite = ListaTramite[i + 1].CentroCustoNome;
                        }
                        break;
                    } 
                }

                if (_ultimo_despacho.Length>8 && _ultimo_despacho.Substring(0, 9) == "ARQUIVADO")
                    goto Proximo;

                if (_proximo_tramite == "SETOR DE ARQUIVO" || _proximo_tramite=="SETOR DE PROTOCOLO E DISTRIBUIÇÃO")
                    goto Proximo;

                TimeSpan t;
                double _numero_dias = 0;
                t = (DateTime.Now - _data_envio);
                _numero_dias = (int)t.TotalDays;

                if (_numero_dias <= 30)
                    goto Proximo;

                ArrayList itemlv = new ArrayList();
                itemlv.Add(_ano.ToString());
                itemlv.Add(_numero_processo);
                itemlv.Add(_assunto);
                itemlv.Add(_requerente);
                itemlv.Add(_data_entrada);
                itemlv.Add(_ultimo_tramite);
                itemlv.Add(_ultimo_despacho);
                itemlv.Add(_numero_dias.ToString());
                itemlv.Add(_proximo_tramite);
                aDatResult.Add(itemlv);
                Proximo:
                _pos++;
            }
            gtiCore.Liberado(this);
            MainListView.BeginUpdate();
            MainListView.VirtualListSize = aDatResult.Count;
            MainListView.EndUpdate();
            PBar.Value = 100;
            Gerar_Excel();
        }

        private void MainListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
            var acc = aDatResult[e.ItemIndex];
            e.Item = new ListViewItem(
                new string[]
                { acc[0].ToString(), acc[1].ToString(), acc[2].ToString() ,acc[3].ToString(),acc[4].ToString(),acc[5].ToString(),acc[6].ToString(),acc[7].ToString(),
                    acc[8].ToString()}) {
                Tag = acc,
                BackColor = e.ItemIndex % 2 == 0 ? Color.Beige : Color.White
            };
        }

        private void Gerar_Excel() {
            using (SaveFileDialog sfd = new SaveFileDialog() {
                Filter = "Excel |* .xlsx",
                InitialDirectory = @"c:\dados\xlsx",
                FileName = "processo_atraso.xlsx",
                ValidateNames = true
            }) {
                if (sfd.ShowDialog() == DialogResult.OK) {
                    gtiCore.Ocupado(this);

                    ExcelPackage package = new ExcelPackage();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Lista");
                    worksheet.Cells[1, 1].Value = "Ano";
                    worksheet.Cells[1, 2].Value = "Número";
                    worksheet.Cells[1, 3].Value = "Assunto";
                    worksheet.Cells[1, 4].Value = "Requerente";
                    worksheet.Cells[1, 5].Value = "Dt.Entrada";
                    worksheet.Cells[1, 6].Value = "Último Trâmite";
                    worksheet.Cells[1, 7].Value = "Último Descpacho";
                    worksheet.Cells[1, 8].Value = "Dias";
                    worksheet.Cells[1, 9].Value = "Próximo trâmite";

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
                        worksheet.Cells[i + r, 8].Value = MainListView.Items[i].SubItems[8].Text;
                    }

                    worksheet.Cells.AutoFitColumns(0);  
                    var xlFile = gtiCore.GetFileInfo(sfd.FileName);
                    package.SaveAs(xlFile);

                    gtiCore.Liberado(this);
                    MessageBox.Show("Seus dados foram exportados para o Excel com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


    }




}
