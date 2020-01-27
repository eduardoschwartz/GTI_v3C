using GTI_Bll.Classes;
using GTI_Models.Models;
using System;
using System.Text.RegularExpressions;

namespace UIWeb.Pages {
    public partial class boletoBB : System.Web.UI.Page {
        public string u;
        protected void Page_Load(object sender, EventArgs e) {
            
            String s = Request.QueryString["f1"];
            txtNome.Text = s;
            s = Request.QueryString["f2"];
            txtEndereco.Text = s;
            s = Request.QueryString["f3"];
            txtDtVenc.Text = s;
            s = Request.QueryString["f4"];
            txtcpfCnpj.Text = s;
            s = Request.QueryString["f5"];
            txtrefTran.Text = s;
            s = Request.QueryString["f6"];
            txtValor.Text = s;
            s = Request.QueryString["f7"];
            txtCidade.Text = s;
            s = Request.QueryString["f8"];
            txtUF.Text = s;
            s = Request.QueryString["f9"];
            txtCep.Text = s;
            s = Request.QueryString["f10"];
            u = s;

            /*  txtNome.Text = "SÃO SEBASTIÃO AÇAÍ";
              txtEndereco.Text = "AV TIRADENTES, 330 - CENTRO";
              txtDtVenc.Text = "15/01/2018";
              txtcpfCnpj.Text = "03203004801";
              txtrefTran.Text = "28735320016301528";
              txtValor.Text = "253,00";
              txtCidade.Text = "JABOTICABAL";
              txtUF.Text = "SP";
              txtCep.Text = "14870-021";
              u = "SCHWARTZ-Dam";*/



            UpdateDatabase();
        }

        public static String RetornaNumero(String Numero) {
            if (String.IsNullOrEmpty(Numero))
                return "0";
            else
                return Regex.Replace(Numero, @"[^\d]", "");
        }

       
        public void UpdateDatabase()
        {
            comercio_eletronico Reg = new comercio_eletronico();
            Reg.Cep = Convert.ToInt32(RetornaNumero(txtCep.Text));
            Reg.Cidade = txtCidade.Text.Length>50? txtCidade.Text.Substring(0, 50):txtCidade.Text;
            Reg.Cpfcnpj = RetornaNumero(txtcpfCnpj.Text);
            Reg.Dataemissao = DateTime.Now;
            Reg.Datavencto =  gtiCore.IsDate(txtDtVenc.Text)?  Convert.ToDateTime(txtDtVenc.Text):Convert.ToDateTime("01/01/1900");
            Reg.Endereco = txtEndereco.Text.Length>200?txtEndereco.Text.Substring(0,200):txtEndereco.Text;
            Reg.Nome = txtNome.Text.Length>100?  txtNome.Text.Substring(0, 100):txtNome.Text;
            Reg.Nossonumero = txtrefTran.Text;
            Reg.Numdoc = Convert.ToInt32(txtrefTran.Text.Right(8));
            Reg.UF = txtUF.Text;
            Reg.Usuario = String.IsNullOrEmpty(u)? "DAM/Web": u;
            Reg.Valorguia = Convert.ToDecimal(txtValor.Text);

            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            tributario_Class.Insert_Boleto_Comercio_Eletronico(Reg);
        }

        protected void btResumo_Click(object sender, EventArgs e) {

        }

        protected void btResumo_Unload(object sender, EventArgs e) {
            
        }

        protected void btGerar_Click(object sender, EventArgs e) {

        }
    }
}