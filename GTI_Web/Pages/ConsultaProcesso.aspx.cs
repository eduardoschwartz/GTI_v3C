using GTI_Bll.Classes;
using GTI_Models.Models;
using System;
using System.Web;
using System.Web.UI;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class ConsultaProcesso : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            String s = Request.QueryString["d"];
            if (s != "gti")
                Response.Redirect("~/Pages/gtiMenu.aspx");

        }

        protected void VerificarButton_Click(object sender, EventArgs e) {
            lblMsg.Text = "";
            int _numero = 0, _ano = 0;
            if (Numero.Text != "")
                int.TryParse( gtiCore.RetornaNumero(Numero.Text),out _numero);
            if (Ano.Text != "")
                int.TryParse(gtiCore.RetornaNumero(Ano.Text), out _ano);

            if (_numero == 0 || _ano == 0)
                lblMsg.Text = "Nº de processo inválido.";
            else {
//                if(!Numero.Text.Contains("-"))
 //                   lblMsg.Text = "Nº de processo inválido.";
            //    else {
                    string NumeroProcesso = Numero.Text + "/" + Ano.Text;
                    Processo_bll processo_Class = new Processo_bll("GTIconnection");
                    _numero = processo_Class.ExtractNumeroProcessoNoDV(NumeroProcesso);
                    
                    bool _existe = processo_Class.Existe_Processo(_ano, _numero);
                    Exception ex = processo_Class.ValidaProcesso(NumeroProcesso);
                    if (ex != null)
                        lblMsg.Text = ex.Message;
                    else {
                        if (_existe )
                            if (Page.IsValid && (txtimgcode.Text == Session["randomStr"].ToString())) {
                                Response.Redirect("~/Pages/ConsultaProcessoend.aspx?d=gti&x=" + HttpUtility.UrlEncode(gtiCore.Encrypt(NumeroProcesso)));
                            } else {
                                lblMsg.Text = "Código da imagem inválido.";
                            }
                        else
                            lblMsg.Text = "Processo não cadastrado.";
                    }
   //             }
            }
        }
    }
}