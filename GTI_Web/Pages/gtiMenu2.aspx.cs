using System;
using System.Security.Cryptography;
using System.Web;
using System.Text;


namespace UIWeb.Pages {
    public partial class gtiMenu2 : System.Web.UI.Page {
        DateTime DataDAM;

        protected void Page_Load(object sender, EventArgs e) {
            //txtVencto.Text = DateTime.Now.ToString("dd/MM/yyyy");
            String s = Request.QueryString["d"];
            if (s != "gti")
                Response.Redirect("~/Pages/gtiMenu.aspx");
        }

        protected void btOK_Click(object sender, EventArgs e) {
            if (!DateTime.TryParse(txtVencto.Text, out DataDAM)) {
                lblMsg.Text = "Data de vencimento inválida.";
                return;
            } else {
                String sDataVencto = txtVencto.Text;
                String sDataNow = DateTime.Now.ToString("dd/MM/yyyy");
                if (DateTime.ParseExact(sDataVencto, "dd/MM/yyyy", null) < DateTime.ParseExact(sDataNow, "dd/MM/yyyy", null)) {
                    lblMsg.Text = "Vencimento menor que a data atual.";
                    return;
                } else {
                    Int32 DifDias = ((TimeSpan)(DataDAM - DateTime.Now)).Days;
                    if (DifDias > 30) {
                        lblMsg.Text = "Vencimento máximo de 30 dias.";
                        return;
                    } else
                        Response.Redirect("~/Pages/damweb.aspx?d=" + HttpUtility.UrlEncode(gtiCore.Encrypt(DataDAM.ToString("dd/MM/yyyy"))));
                }
            }
        }

    }
}