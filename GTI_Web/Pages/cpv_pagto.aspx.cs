using System;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using GTI_Bll.Classes;
using GTI_Models;
using GTI_Models.Models;

namespace GTI_Web.Pages {
    public partial class cpv_pagto : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            String s = Request.QueryString["d"];
            if (s != "gti")
                Response.Redirect("~/Pages/gtiMenu.aspx");
        }

        protected void Submit_Click(object sender, EventArgs e) {
            int _codigo = 0,_numeroDoc=0;
            bool bIsNumber= int.TryParse(Codigo.Text,out _codigo);
            if (!bIsNumber) {
                lblmsg.Text = "Digite a inscrição cadastral/municipal.";
            } else {
                if(Documento.Text.Length<17)
                    lblmsg.Text = "Número de documento inválido, digite conforme consta no boleto.";
                else {
                    string sDoc = Documento.Text.Substring(9, 8);
                    _numeroDoc = Convert.ToInt32(sDoc);

                    Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
                    int _codigoBD = tributario_Class.Retorna_Codigo_por_Documento(_numeroDoc);
                    if (_codigo != _codigoBD) {
                        lblmsg.Text = "O número de documento informado não pertence a esta inscrição.";
                    } else
                        if(txtimgcode.Text != Session["randomStr"].ToString())
                          lblmsg.Text = "Código da imagem inválido.";
                    else {
                        DebitoPagoStruct reg = tributario_Class.Retorna_DebitoPago_Documento(_numeroDoc);
                        if (reg == null)
                            lblmsg.Text = "Pagamento não encontrado para este documento.";
                        else {
                            PrintReport(reg);
                        }
                    }
                }
            }
        }

        private void PrintReport(DebitoPagoStruct reg) {
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/ComprovantePagamento.rpt"));

            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            int _numero_certidao = tributario_Class.Retorna_Codigo_Certidao(modelCore.TipoCertidao.Comprovante_Pagamento);
            int _ano_certidao = DateTime.Now.Year;

            string _nome="", _cpfcnpj="";
            Sistema_bll sistema_Class = new Sistema_bll("GTIConnection");
            Contribuinte_Header_Struct _header = sistema_Class.Contribuinte_Header(reg.Codigo);
            _nome = _header.Nome;
            _cpfcnpj = _header.Cpf_cnpj;

            Comprovante_pagamento cpv = new Comprovante_pagamento();
            cpv.Ano = _ano_certidao;
            cpv.Numero = _numero_certidao;
            cpv.Banco = reg.Banco_Nome + " Agência: " + reg.Codigo_Agencia ?? "";
            cpv.Controle = _numero_certidao.ToString("00000") + _ano_certidao.ToString("0000") + "/" + reg.Codigo.ToString() + "-PG";
            cpv.Cpfcnpj = _cpfcnpj;
            cpv.Data_emissao = DateTime.Now ;
            cpv.Data_pagamento = reg.Data_Pagamento;
            cpv.Documento = Documento.Text;
            cpv.Nome = _nome;
            cpv.Valor = (decimal)reg.Valor_Pago_Real;
            Exception ex = tributario_Class.Insert_Comprovante_Pagamento(cpv);
            if (ex != null) {
                throw ex;
            } else {
                crystalReport.SetParameterValue("NUMCOMPROVANTE", _numero_certidao.ToString("00000") + "/" + _ano_certidao.ToString("0000"));
                crystalReport.SetParameterValue("DATAEMISSAO", DateTime.Now.ToString("dd/MM/yyyy") + " às " + DateTime.Now.ToString("HH:mm:ss"));
                crystalReport.SetParameterValue("CONTROLE", _numero_certidao.ToString("00000") + _ano_certidao.ToString("0000") + "/" + reg.Codigo.ToString() + "-PG");
                crystalReport.SetParameterValue("BANCO", reg.Banco_Nome + " Agência: " + reg.Codigo_Agencia??"");
                crystalReport.SetParameterValue("CADASTRO", reg.Codigo.ToString("000000"));
                crystalReport.SetParameterValue("NOME",_nome);
                crystalReport.SetParameterValue("DATAPAGAMENTO", reg.Data_Pagamento);
                crystalReport.SetParameterValue("VALOR", reg.Valor_Pago_Real);
                crystalReport.SetParameterValue("DOCUMENTO", Documento.Text);
                crystalReport.SetParameterValue("CPFCNPJ", _cpfcnpj);

                HttpContext.Current.Response.Buffer = false;
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ClearHeaders();

                try {
                    crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "cpv_pagto" + _numero_certidao.ToString() + _ano_certidao.ToString());
                } catch {
                } finally {
                    crystalReport.Close();
                    crystalReport.Dispose();
                }
            }
        }


    }
}