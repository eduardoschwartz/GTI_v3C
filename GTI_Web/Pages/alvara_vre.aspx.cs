using GTI_Bll.Classes;
using GTI_Models.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace UIWeb {
    public partial class alvara_vre : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            String s = Request.QueryString["d"];
            if (s != "gti")
                Response.Redirect("~/Pages/gtiMenu.aspx");
        }


        private void EmiteAlvara(int Codigo) {
            
            Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
            EmpresaStruct empresa = empresa_Class.Retorna_Empresa(Codigo);
            SilStructure sil = empresa_Class.CarregaSil(Codigo);
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            ReportViewer viewer = new ReportViewer();
            viewer.LocalReport.Refresh();
            viewer.LocalReport.ReportPath = "Report/rptAlvara_vre.rdlc";

            string _protocolo = sil.Protocolo == null ? "" : sil.Protocolo;
            string _endereco = empresa.Endereco_nome + ", " + empresa.Numero + " " + empresa.Complemento;

            List<ReportParameter> parameters = new List<ReportParameter>();
            parameters.Add(new ReportParameter("RazaoSocial", empresa.Razao_social));
            parameters.Add(new ReportParameter("Protocolo", _protocolo==""?" ":_protocolo));
            parameters.Add(new ReportParameter("Endereco", _endereco==""?" ":_endereco));
            parameters.Add(new ReportParameter("Cidade", empresa.Cidade_nome == "" ? " " : empresa.Cidade_nome));
            parameters.Add(new ReportParameter("Horario", empresa.Horario_Nome == "" ? " " : empresa.Horario_Nome));
            parameters.Add(new ReportParameter("Bairro", empresa.Bairro_nome == "" ? " " : empresa.Bairro_nome));
            parameters.Add(new ReportParameter("Cep", empresa.Cep == "" ? " " : empresa.Cep));
            parameters.Add(new ReportParameter("CPF", empresa.Cpf_cnpj == "" ? " " : empresa.Cpf_cnpj));
            parameters.Add(new ReportParameter("Inscricao", empresa.Codigo.ToString()));
            parameters.Add(new ReportParameter("InscEstadual", string.IsNullOrWhiteSpace(empresa.Inscricao_estadual) ? " " : empresa.Inscricao_estadual));
            parameters.Add(new ReportParameter("Atividade", empresa.Atividade_extenso == "" ? " " : empresa.Atividade_extenso));

            viewer.LocalReport.SetParameters(parameters);

            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename= guia_pmj" + "." + extension);
            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.Flush();
            Response.End();

        }

        protected void Submit_Click(object sender, EventArgs e) {
            int Num = 0;
            
            if (Page.IsValid && (txtimgcode.Text == Session["randomStr"].ToString())) {
                Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
                bool isNum = Int32.TryParse(txtCod.Text, out Num);
                if (!isNum) {
                    lblmsg.Text = "Inscrição Municipal inválida!";
                    return;
                } else {
                    bool bExiste = empresa_Class.Existe_Empresa(Num);
                    if (!bExiste) {
                        lblmsg.Text = "Inscrição Municipal inválida!";
                        return;
                    }
                }

                SilStructure Sil = empresa_Class.CarregaSil(Num);

                if (Sil.Codigo == 0) {
                    lblmsg.Text = "Solicitação inválida!";
                    return;
                } else if (Sil.Protocolo == null) {
                    lblmsg.Text = "Solicitação inválida!";
                    return;
                } else if (Sil.Data_Validade < DateTime.Now) {
                    lblmsg.Text = "Solicitação inválida!";
                    return;
                }

           
                EmiteAlvara(Num);
            } else {
                lblmsg.Text = "Código da imagem inválido.";
            }

        }



    }//end class
}//end namespace