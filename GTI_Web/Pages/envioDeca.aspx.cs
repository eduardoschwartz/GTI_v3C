using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UIWeb.Pages {
    public partial class envioDeca : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            String s = Request.QueryString["d"];
            if (s != "gti")
                Response.Redirect("~/Pages/gtiMenu.aspx");

        }

        protected void btAcesso_Click(object sender, EventArgs e) {
            if(txtAcesso.Text.ToUpper()=="VREGTI")
                Response.Redirect("~/Pages/readVRExml.aspx");
        }
    }
}