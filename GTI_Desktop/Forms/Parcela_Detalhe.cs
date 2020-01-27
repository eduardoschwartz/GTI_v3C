using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Desktop.Datasets;
using GTI_Models.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace GTI_Desktop.Forms {
    public partial class Parcela_Detalhe : Form {
        Color _backColor = Color.White, _foreColor = Color.DarkBlue;
        Font _font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
        int _codigo;
        string _connection = gtiCore.Connection_Name(),_nome;
        List<SpExtrato> Lista_Extrato_Tributo=new List<SpExtrato>();

        public Parcela_Detalhe(int Codigo,string Nome, List<SpExtrato> Lista_Extrato) {
            InitializeComponent();
            _codigo = Codigo;
            _nome = Nome;
            Carrega_Detalhe(Lista_Extrato);
            Lista_Extrato_Tributo = Lista_Extrato;
        }

        private void BtPrint_Click(object sender, EventArgs e) {
            gtiCore.Ocupado(this);
            String sReportName = "Detalhe_Parcela";
            dsDetalheParcela Ds = new dsDetalheParcela();
            DataTable dTable = new dsDetalheParcela.DetalheParcelaDataTable();

            foreach (ListViewItem Item in TributoListView.Items) {
                if (Item.Index < TributoListView.Items.Count-1) {
                    DataRow dRow = dTable.NewRow();
                    dRow["Descricao"] = Item.Text;
                    dRow["Principal"] = Item.SubItems[1].Text;
                    dRow["Juros"] = Item.SubItems[2].Text;
                    dRow["Multa"] = Item.SubItems[3].Text;
                    dRow["Correcao"] = Item.SubItems[4].Text;
                    dRow["Total"] = Item.SubItems[5].Text;
                    dTable.Rows.Add(dRow);
                }
            }
            Ds.Tables.Add(dTable);

            ReportParameter p1 = new ReportParameter("prmContribuinte", NomeLabel.Text);
            ReportParameter p2 = new ReportParameter("prmExercicio", Lista_Extrato_Tributo[0].Anoexercicio.ToString());
            ReportParameter p3 = new ReportParameter("prmLancamento", LancamentoLabel.Text);
            ReportParameter p4 = new ReportParameter("prmSequencia", Lista_Extrato_Tributo[0].Seqlancamento.ToString());
            ReportParameter p5 = new ReportParameter("prmParcela", Lista_Extrato_Tributo[0].Numparcela.ToString("00"));
            ReportParameter p6 = new ReportParameter("prmComplemento", Lista_Extrato_Tributo[0].Codcomplemento.ToString("00"));
            ReportParameter p7 = new ReportParameter("prmSituacao", StatusLabel.Text);
            ReportParameter p8 = new ReportParameter("prmIsento", IsentoLabel.Text);
            ReportParameter p9 = new ReportParameter("prmDesconto", DescontoLabel.Text);
            ReportParameter p10 = new ReportParameter("prmLivro", LivroLabel.Text);
            ReportParameter p11 = new ReportParameter("prmInscricao", DataInscricaoLabel.Text);
            ReportParameter p12 = new ReportParameter("prmPagina", PaginaLabel.Text);
            ReportParameter p13 = new ReportParameter("prmCertidao", CertidaoLabel.Text);
            ReportParameter p14 = new ReportParameter("prmAjuizamento", AjuizamentoLabel.Text);
            ReportParameter p15 = new ReportParameter("prmProcessoCNJ", ProcessoCNJLabel.Text);
            ReportParameter p16 = new ReportParameter("prmProtocolo", NumProtocoloLabel.Text);
            ReportParameter p17 = new ReportParameter("prmDataRemessa", DataRemessaLabel.Text);
            ReportParameter p18 = new ReportParameter("prmDataBase", DataBaseLabel.Text);
            ReportParameter p19 = new ReportParameter("prmDataVencimento", DataVenctoLabel.Text);
            ReportParameter p20 = new ReportParameter("prmDataVencimentoCalc", DataVenctoCalcLabel.Text);
            ReportParameter p21 = new ReportParameter("prmValorLancado", ValorLancadoLabel.Text);
            ReportParameter p22 = new ReportParameter("prmValorAtual", ValorAtualLabel.Text);
            ReportParameter p23 = new ReportParameter("prmDataPagamento", DataPagtoLabel.Text);
            ReportParameter p24 = new ReportParameter("prmDataReceita", DataReceitaLabel.Text);
            ReportParameter p25 = new ReportParameter("prmBanco", BancoLabel.Text);
            ReportParameter p26 = new ReportParameter("prmValorPago", ValorPagoLabel.Text);
            ReportParameter p27 = new ReportParameter("prmValorDif", ValorDifLabel.Text);

            gtiCore.Liberado(this);
            Report f1 = new Report(sReportName, Ds, 1, true, new ReportParameter[] { p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16,p17,p18,p19,p20,p21,p22,p23,p24,p25,p26,p27 }) {
                Tag = this.Name
            };
            f1.ShowDialog();

        }

        private void BtFindCodigo_Click(object sender, EventArgs e) {
            //TODO: Rotina de duplicados/restituidos
        }

        private void CmdSair_Click(object sender, EventArgs e) {
            Close();
        }

        private void Carrega_Detalhe(List<SpExtrato> Lista) {
            decimal _valorTributo = 0,_valorMulta=0,_valorJuros=0,_valorCorrecao=0,_valorTotal=0;
            double _valorPago = 0;
            Tributario_bll tributario_Class = new Tributario_bll(_connection);

            foreach (SpExtrato item in Lista) {
                ListViewItem lvItem = new ListViewItem {
                    Text = item.Abrevtributo,
                    ForeColor = Color.Black,
                    UseItemStyleForSubItems = false
                };
                lvItem.SubItems.Add(item.Valortributo.ToString("#0.00"),  _foreColor,_backColor,_font);
                lvItem.SubItems.Add(item.Valormulta.ToString("#0.00"), _foreColor, _backColor,_font);
                lvItem.SubItems.Add(item.Valorjuros.ToString("#0.00"), _foreColor,_backColor ,_font);
                lvItem.SubItems.Add(item.Valorcorrecao.ToString("#0.00"), _foreColor,_backColor, _font);
                lvItem.SubItems.Add(item.Valortotal.ToString("#0.00"), _foreColor, _backColor, _font);
                TributoListView.Items.Add(lvItem);
                _valorTributo += item.Valortributo;
                _valorJuros += item.Valorjuros;
                _valorMulta += item.Valormulta;
                _valorCorrecao += item.Valorcorrecao;
                _valorTotal += item.Valortotal;
            }

            ListViewItem lvItem2 = new ListViewItem {
                Text = "Total ==>",
                ForeColor = Color.Brown,
                UseItemStyleForSubItems = false
            };
            lvItem2.SubItems.Add(_valorTributo.ToString("#0.00"), Color.Brown, _backColor, _font);
            lvItem2.SubItems.Add(_valorMulta.ToString("#0.00"), Color.Brown, _backColor, _font);
            lvItem2.SubItems.Add(_valorJuros.ToString("#0.00"), Color.Brown, _backColor, _font);
            lvItem2.SubItems.Add(_valorCorrecao.ToString("#0.00"), Color.Brown, _backColor, _font);
            lvItem2.SubItems.Add(_valorTotal.ToString("#0.00"), Color.Brown, _backColor, _font);
            TributoListView.Items.Add(lvItem2);

            SpExtrato reg = Lista[0];
            DataBaseLabel.Text = reg.Datadebase.ToString("dd/MM/yyyy");
            DataVenctoLabel.Text = reg.Datavencimento.ToString("dd/MM/yyyy");
            DataVenctoCalcLabel.Text = reg.Datavencimentocalc.Year < 1990 ? reg.Datavencimento.ToString("dd/MM/yyyy") : reg.Datavencimentocalc.ToString("dd/MM/yyyy");
            _valorPago = reg.Valorpagoreal == 0 ? Convert.ToDouble(_valorTotal) : Convert.ToDouble(reg.Valorpagoreal);
            ValorLancadoLabel.Text = _valorTributo.ToString("#0.00");
            ValorAtualLabel.Text = _valorTotal.ToString("#0.00");
            ValorPagoLabel.Text = Convert.ToDouble(reg.Valorpagoreal).ToString("#0.00");
            LivroLabel.Text = reg.Numlivro == null ? "0000" : Convert.ToInt32(reg.Numlivro).ToString("0000");
            DataInscricaoLabel.Text = reg.Datainscricao == null ? "  /  /    " : Convert.ToDateTime(reg.Datainscricao).ToString("dd/MM/yyyy");
            PaginaLabel.Text = reg.Pagina == null ? "00000" : Convert.ToInt32(reg.Pagina).ToString("00000");
            CertidaoLabel.Text = reg.Certidao == null ? "00000" : Convert.ToInt32(reg.Certidao).ToString("00000");
            AjuizamentoLabel.Text = reg.Dataajuiza == null ? "  /  /    " : Convert.ToDateTime(reg.Dataajuiza).ToString("dd/MM/yyyy");
            ProcessoCNJLabel.Text = reg.Processocnj ?? "0000000-00.0.0.00.0000";
            NumProtocoloLabel.Text = reg.Prot_certidao == null ? "0000000" : reg.Prot_certidao.ToString();
            DataRemessaLabel.Text = reg.Prot_dtremessa == null ? "  /  /    " : Convert.ToDateTime(reg.Prot_dtremessa).ToString("dd/MM/yyyy");
            LancamentoLabel.Text = reg.Codlancamento.ToString("000") + "-" + reg.Desclancamento;
            NomeLabel.Text = _codigo.ToString("000000") + "-" + _nome;
            StatusLabel.Text = reg.Statuslanc.ToString("00") + "-"+reg.Situacao;
            DataPagtoLabel.Text = reg.Datapagamento == null ? "  /  /    " : Convert.ToDateTime(reg.Datapagamento).ToString("dd/MM/yyyy");
            ValorPagoLabel.Text = Convert.ToDouble(reg.Valorpagoreal).ToString("#0.00");

            Debitoparcela _parcelaReg = new Debitoparcela() {
                Codreduzido=reg.Codreduzido,
                Anoexercicio=reg.Anoexercicio,
                Codlancamento=reg.Codlancamento,
                Seqlancamento=reg.Seqlancamento,
                Numparcela=(byte)reg.Numparcela,
                Codcomplemento=reg.Codcomplemento
            };

            DebitoPagoStruct dpReg = tributario_Class.Retorna_DebitoPago_Parcela(_parcelaReg);
            if (dpReg != null) {
                TaxaExpLabel.Text = Convert.ToDouble(dpReg.Valor_Tarifa).ToString("#0.00");
                if (dpReg.Data_Pagamento_Calc != null && Convert.ToDateTime(dpReg.Data_Pagamento_Calc).Year > 1970)
                    DataPagtoCalcLabel.Text = Convert.ToDateTime(dpReg.Data_Pagamento_Calc).ToString("dd/MM/yyyy");
                else
                    DataPagtoCalcLabel.Text = "  /  /    ";

                DataReceitaLabel.Text = dpReg.Data_Recebimento == null ? "  /  /    " : Convert.ToDateTime(dpReg.Data_Recebimento).ToString("dd/MM/yyyy");
                string _banco = Convert.ToInt32(dpReg.Banco_Codigo).ToString("000");
                string _agencia = Convert.ToInt32(dpReg.Codigo_Agencia).ToString("000");
                BancoLabel.Text = _banco + "/" + _agencia;
                int _numdoc = Convert.ToInt32(dpReg.Numero_Documento);
                NumDocLabel.Text = _numdoc.ToString("00000000") + "-" + tributario_Class.DvDocumento(_numdoc);
                ValorDifLabel.Text = Convert.ToDouble(dpReg.Valor_Dif).ToString("#0.00");
                Numdocumento regDoc = tributario_Class.Retorna_Dados_Documento(_numdoc);
                if (regDoc.Isentomj == 1)
                    IsentoLabel.Text = "Sim";
                else
                    IsentoLabel.Text = "Não";
                DescontoLabel.Text = Convert.ToDecimal(regDoc.Percisencao).ToString("#0.00") + "%";
            }

            if (reg.UserId>0) {
                Sistema_bll sistema_Class = new Sistema_bll(_connection);
                string _nome = sistema_Class.Retorna_User_FullName(Convert.ToInt32(reg.UserId));
                Text += " (Gerado por: " + _nome + ")";
            }

        }


    }//end Class
}
