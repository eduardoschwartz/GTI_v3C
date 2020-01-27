using GTI_Bll.Classes;
using GTI_Models.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;


namespace UIWeb.Pages {
    public partial class SegundaViaCIPFim : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            lblMsg.Text = "";
            if (!IsPostBack) {
                String s = Request.QueryString["d"];
                if (s != "gti")
                    Response.Redirect("~/Pages/gtiMenu.aspx");

                if (Session["sid"] != null && Session["sid"].ToString() != "") {
                    Tributario_bll debito_Class = new Tributario_bll("GTIconnection");
                    List<Boletoguia> ListaBoleto = debito_Class.Lista_Boleto_Guia(Convert.ToInt32(Session["sid"]));
                    lblCod.Text = ListaBoleto[0].Codreduzido;
                    lblNome.Text = ListaBoleto[0].Nome;
                } else
                    Response.Redirect("~/Pages/gtiMenu.aspx");
            }
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
            if (ListaBoleto.Count > 0) {
                tributario_Class.Insert_Carne_Web(Convert.ToInt32(ListaBoleto[0].Codreduzido), 2019);
                DataSet Ds = gtiCore.ToDataSet(ListaBoleto);
                ReportDataSource rdsAct = new ReportDataSource("dsBoletoGuia", Ds.Tables[0]);
                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.Refresh();
                //viewer.LocalReport.ReportPath = "Report/rptDamParceladoCIP.rdlc";
                viewer.LocalReport.ReportPath = "Report/Carne_CIP.rdlc";
                viewer.LocalReport.DataSources.Add(rdsAct); // Add  datasource here         

                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("QUADRA", "Quadra: " + ListaBoleto[0].Quadra + " Lote: " + ListaBoleto[0].Lote));
                parameters.Add(new ReportParameter("DATADOC", Convert.ToDateTime(ListaBoleto[0].Datadoc).ToString("dd/MM/yyyy")));
                parameters.Add(new ReportParameter("NOME", ListaBoleto[0].Nome));
                parameters.Add(new ReportParameter("ENDERECO", ListaBoleto[0].Endereco + " " + ListaBoleto[0].Complemento));
                parameters.Add(new ReportParameter("BAIRRO", ListaBoleto[0].Bairro??""));
                parameters.Add(new ReportParameter("CIDADE", ListaBoleto[0].Cidade + "/" + ListaBoleto[0].Uf));
                parameters.Add(new ReportParameter("QUADRAO", ListaBoleto[0].Quadra??""));
                parameters.Add(new ReportParameter("LOTEO", ListaBoleto[0].Lote??""));
                parameters.Add(new ReportParameter("CODIGO", ListaBoleto[0].Codreduzido));
                parameters.Add(new ReportParameter("INSC", ListaBoleto[0].Inscricao_cadastral??""));
                parameters.Add(new ReportParameter("FRACAO", "a"));
                parameters.Add(new ReportParameter("NATUREZA", "a"));
                parameters.Add(new ReportParameter("TESTADA", "a"));
                parameters.Add(new ReportParameter("AREAT", "a"));
                parameters.Add(new ReportParameter("AREAC", "a"));
                parameters.Add(new ReportParameter("VVT", "a"));
                parameters.Add(new ReportParameter("VVC", "a"));
                parameters.Add(new ReportParameter("VVI", "a"));
                parameters.Add(new ReportParameter("IPTU", "a"));
                parameters.Add(new ReportParameter("ITU", "a"));
                parameters.Add(new ReportParameter("TOTALPARC", "a"));
                parameters.Add(new ReportParameter("UNICA1", "a"));
                parameters.Add(new ReportParameter("UNICA2", "a"));
                parameters.Add(new ReportParameter("UNICA3", "a"));
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

        protected void btPrint_Click(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(Session["sid"].ToString())) {
                printCarne(Convert.ToInt32(Session["sid"]));
                Session["sid"] = "";
            } else
                Response.Redirect("~/Pages/gtiMenu.aspx");
        }
    }
}