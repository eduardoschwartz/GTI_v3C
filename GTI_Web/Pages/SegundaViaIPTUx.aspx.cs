using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using GTI_Bll.Classes;
using GTI_Models.Models;
using GTI_Web.Report;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace UIWeb.Pages {
    public partial class SegundaViaIPTUFim : System.Web.UI.Page {

        TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
        TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
        ConnectionInfo crConnectionInfo = new ConnectionInfo();
        Tables CrTables;
        
        protected void Page_Load(object sender, EventArgs e) {
            lblMsg.Text = "";
            if (!IsPostBack) {
                if (Session["sid"] != null && Session["sid"].ToString() != "") {
                    Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
                    List<Boletoguia> ListaBoleto = tributario_Class.Lista_Boleto_Guia(Convert.ToInt32(Session["sid"]));
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
                tributario_Class.Insert_Carne_Web(Convert.ToInt32( ListaBoleto[0].Codreduzido), 2019);
                DataSet Ds = gtiCore.ToDataSet(ListaBoleto);
                ReportDataSource rdsAct = new ReportDataSource("dsBoletoGuia", Ds.Tables[0]);
                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.Refresh();
                viewer.LocalReport.ReportPath = "Report/BoletoRegistrado.rdlc";
                viewer.LocalReport.DataSources.Add(rdsAct); // Add  datasource here         
                byte[] bytes = viewer.LocalReport.Render( "PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
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

        //private void printCarne(int nSid) {
        //    lblMsg.Text = "";
        //    int _codigo = Convert.ToInt32(lblCod.Text);

           
        //    ReportDocument crystalReport = new ReportDocument();
        //    crystalReport.Load(Server.MapPath("~/Report/Carne_IPTU.rpt"));
            
        //    crystalReport.SetDatabaseLogon("gtisys", "everest","200.232.123.115","Tributacao");
        //    crystalReport.RecordSelectionFormula = "{boletoguia.sid}=" + nSid;
        //    //  crystalReport.SetParameterValue("NUMCERTIDAO", dados.Numero.ToString("00000") + "/" + dados.Ano.ToString("0000"));

        //    HttpContext.Current.Response.Buffer = false;
        //    HttpContext.Current.Response.ClearContent();
        //    HttpContext.Current.Response.ClearHeaders();

        //    try {
        //        crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "IPTU_2019");
        //    } catch  {
        //    } finally {
        //        crystalReport.Close();
        //        crystalReport.Dispose();

        //        Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
        //        tributario_Class.Excluir_Carne(nSid);

        //    }
        //}

        protected void btPrint_Click(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty( Session["sid"].ToString() )) {
                printCarne(Convert.ToInt32(Session["sid"]));
                Session["sid"] = "";
            }
            else
                Response.Redirect("~/Pages/gtiMenu.aspx");
        }

    }
}