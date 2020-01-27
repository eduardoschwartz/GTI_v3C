using GTI_Bll.Classes;
using GTI_Models.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class SegundaViaISSend : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            lblMsg.Text = "";
            if (!IsPostBack) {
                String s = Request.QueryString["d"];
                if (s != "gti")
                    Response.Redirect("~/Pages/gtiMenu.aspx");

                if (Session["sid"] != null && Session["sid"].ToString() != "") {
                    Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
                    List<Boletoguia> ListaBoleto = tributario_Class.Lista_Boleto_Guia(Convert.ToInt32(Session["sid"]));
                    lblCod.Text = ListaBoleto[0].Codreduzido;
                    lblNome.Text = ListaBoleto[0].Nome;
                } else
                    Response.Redirect("~/Pages/gtiMenu.aspx");
            }

        }

        protected void btPrint_Click(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(Session["sid"].ToString())) {
                printCarne(Convert.ToInt32(Session["sid"]));
                Session["sid"] = "";
            } else
                Response.Redirect("~/Pages/gtiMenu.aspx");

        }

        private void printCarne(int nSid) {
            lblMsg.Text = "";
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            Session["sid"] = "";
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            List<Boletoguia> ListaBoleto = tributario_Class.Lista_Boleto_Guia(nSid);
            int _codigo = Convert.ToInt32( ListaBoleto[0].Codreduzido);
            if (ListaBoleto.Count > 0) {
                tributario_Class.Insert_Carne_Web(_codigo, 2020);
                DataSet Ds = gtiCore.ToDataSet(ListaBoleto);
                ReportDataSource rdsAct = new ReportDataSource("dsBoletoGuia", Ds.Tables[0]);
                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.Refresh();
                viewer.LocalReport.ReportPath = "Report/Carne_ISS_TLL.rdlc";
                viewer.LocalReport.DataSources.Add(rdsAct); // Add  datasource here       

                Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
                EmpresaStruct _empresa = empresa_Class.Retorna_Empresa(_codigo);
                decimal _valor_aliquota = empresa_Class.Aliquota_Taxa_Licenca(_codigo);

                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("DATADOC", Convert.ToDateTime(ListaBoleto[0].Datadoc).ToString("dd/MM/yyyy")));
                parameters.Add(new ReportParameter("NOME", ListaBoleto[0].Nome));
                parameters.Add(new ReportParameter("ENDERECO", ListaBoleto[0].Endereco + " " + ListaBoleto[0].Complemento));
                parameters.Add(new ReportParameter("BAIRRO", ListaBoleto[0].Bairro));
                parameters.Add(new ReportParameter("CIDADE", ListaBoleto[0].Cidade + "/" + ListaBoleto[0].Uf));
                parameters.Add(new ReportParameter("CODIGO", _codigo.ToString()));
                parameters.Add(new ReportParameter("IE", _empresa.Inscricao_estadual==""? " ": _empresa.Inscricao_estadual));
                parameters.Add(new ReportParameter("DOC", ListaBoleto[0].Cpf));
                parameters.Add(new ReportParameter("ATIVIDADE", _empresa.Atividade_extenso));
                parameters.Add(new ReportParameter("ISS", Convert.ToDecimal(ListaBoleto[0].Valor_ISS).ToString("#0.00") ));
                parameters.Add(new ReportParameter("TAXA", Convert.ToDecimal(ListaBoleto[0].Valor_Taxa).ToString("#0.00")));
                parameters.Add(new ReportParameter("AREA", Convert.ToDecimal(_empresa.Area).ToString("#0.00")));
                parameters.Add(new ReportParameter("ALIQUOTA", _valor_aliquota.ToString("#0.00")));
                viewer.LocalReport.SetParameters(parameters);


                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                tributario_Class.Excluir_Carne(nSid);
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename= guia_pmj" + "." + extension);
                Response.OutputStream.Write(bytes, 0, bytes.Length);
                Response.Flush();
                Response.End();
            } else
                lblMsg.Text = "A guia já foi impressa!";
        }


    }
}