using GTI_Bll.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;

namespace UIWeb.Pages {
    public partial class cipendereco : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                txtNumDoc.Text = "";
                lblMsg.Text = "";
                String s = Request.QueryString["d"];
                if (s != "gti")
                    Response.Redirect("~/Pages/gtiMenu.aspx");

            }

        }

        protected void btAcesso_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtNumDoc.Text))
                lblMsg.Text = "Erro: Digite o nº do documento.";
            else {
                int number;
                bool result = Int32.TryParse(txtNumDoc.Text, out number);
                if (result) {
                    ClearTable();
                    Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
                    bool bExiste = tributario_Class.Existe_Documento_CIP(number);
                    if (!bExiste)
                        lblMsg.Text = "Erro: Documento inválido.";
                    else
                        FillTable(number);
                } else
                    lblMsg.Text = "Erro: Documento inválido.";
            }
        }


        private void ClearTable() {
            IM.Text = "";
            NOME.Text = "";
            ENDERECOIMOVEL.Text = "";
            BAIRRO.Text = "";
        }

        private void FillTable(int NumDocumento) {
            Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            int Codigo = tributario_Class.Retorna_Codigo_por_Documento(NumDocumento);
            ImovelStruct regDados = imovel_Class.Dados_Imovel(Codigo);
            List<ProprietarioStruct> lstProprietario = imovel_Class.Lista_Proprietario(Codigo, true);
            IM.Text = regDados.Codigo.ToString();
            NOME.Text = lstProprietario[0].Nome;
            ENDERECOIMOVEL.Text = regDados.NomeLogradouro + ", " + regDados.Numero.ToString() + " " + regDados.Complemento.ToString();
            BAIRRO.Text = regDados.NomeBairro.ToString();
        }


    }
}