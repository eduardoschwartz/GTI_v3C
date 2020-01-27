using CrystalDecisions.CrystalReports.Engine;
using GTI_Bll.Classes;
using GTI_Models;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace GTI_Web.Pages {
    public partial class certidaoendereco : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            String s = Request.QueryString["d"];
            if (s != "gti")
                Response.Redirect("~/Pages/gtiMenu.aspx");

        }

        protected void btPrint_Click(object sender, EventArgs e) {

            if (txtIM.Text == "") 
                lblMsg.Text = "Digite o código do imóvel.";
            else {
                lblMsg.Text = "";
                int Codigo = Convert.ToInt32(txtIM.Text);
                Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
                bool ExisteImovel = imovel_Class.Existe_Imovel(Codigo);
                if (!ExisteImovel)
                    lblMsg.Text = "Imóvel não cadastrado.";
                else {
                    if (txtimgcode.Text != Session["randomStr"].ToString())
                        lblMsg.Text = "Código da imagem inválido";
                    else
                        PrintReport(Codigo);
                }
            }
        }

        private void PrintReport(int Codigo) {
            Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
            ImovelStruct Reg = imovel_Class.Dados_Imovel(Codigo);
            string sComplemento = string.IsNullOrWhiteSpace(Reg.Complemento) ? "" : " " + Reg.Complemento.ToString().Trim();
            string sQuadras = string.IsNullOrWhiteSpace(Reg.QuadraOriginal) ? "" : " Quadra: " + Reg.QuadraOriginal.ToString().Trim();
            string sLotes = string.IsNullOrWhiteSpace(Reg.LoteOriginal) ? "" : " Lote: " + Reg.LoteOriginal.ToString().Trim();
            sComplemento += sQuadras + sLotes;
            string sEndereco = Reg.NomeLogradouro + ", " + Reg.Numero.ToString() + sComplemento;
            string sBairro = Reg.NomeBairro;
            string sInscricao = Reg.Distrito.ToString() + "." + Reg.Setor.ToString("00") + "." + Reg.Quadra.ToString("0000") + "." + Reg.Lote.ToString("00000") + "." +
                Reg.Seq.ToString("00") + "." + Reg.Unidade.ToString("00") + "." + Reg.SubUnidade.ToString("000");
            List<ProprietarioStruct>Lista = imovel_Class.Lista_Proprietario(Codigo, true);
            string sNome = Lista[0].Nome;

            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/CertidaoEndereco.rpt"));

            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            int _numero_certidao = tributario_Class.Retorna_Codigo_Certidao(modelCore.TipoCertidao.Endereco);
            int _ano_certidao = DateTime.Now.Year;

            Certidao_endereco cert = new Certidao_endereco();
            cert.Codigo = Codigo;
            cert.Ano = _ano_certidao;
            cert.Numero = _numero_certidao;
            cert.Data = DateTime.Now;
            cert.Inscricao = sInscricao;
            cert.Nomecidadao = sNome;
            cert.Logradouro =Reg.NomeLogradouro;
            cert.Li_num = Convert.ToInt32(Reg.Numero);
            cert.Li_compl = Reg.Complemento;
            cert.descbairro = sBairro;
            cert.Li_quadras = Reg.QuadraOriginal;
            cert.Li_lotes = Reg.LoteOriginal;
            Exception ex = tributario_Class.Insert_Certidao_Endereco(cert);
            if (ex != null) {
                throw ex;
            } else {
                crystalReport.SetParameterValue("NUMCERTIDAO", _numero_certidao.ToString("00000") + "/" + _ano_certidao.ToString("0000"));
                crystalReport.SetParameterValue("DATAEMISSAO", DateTime.Now.ToString("dd/MM/yyyy") + " às " + DateTime.Now.ToString("HH:mm:ss"));
                crystalReport.SetParameterValue("CONTROLE", _numero_certidao.ToString("00000") + _ano_certidao.ToString("0000") + "/" + Codigo.ToString() + "-EA");
                crystalReport.SetParameterValue("ENDERECO", sEndereco);
                crystalReport.SetParameterValue("CADASTRO", Codigo.ToString("000000"));
                crystalReport.SetParameterValue("NOME", sNome);
                crystalReport.SetParameterValue("INSCRICAO", sInscricao);
                crystalReport.SetParameterValue("BAIRRO", sBairro);

                HttpContext.Current.Response.Buffer = false;
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ClearHeaders();

                try {
                    crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "certidao" + _numero_certidao.ToString() + _ano_certidao.ToString());
                } catch {
                } finally {
                    crystalReport.Close();
                    crystalReport.Dispose();
                }
            }
        }

        protected void ValidarButton_Click(object sender, EventArgs e) {
            string sCod = Codigo.Text;
            string sTipo = "";
            lblMsg.Text = "";
            int nPos = 0, nPos2 = 0, nCodigo = 0, nAno = 0, nNumero = 0;
            if (sCod.Trim().Length < 8)
                lblMsg.Text = "Código de validação inválido.";
            else {
                nPos = sCod.IndexOf("-");
                if (nPos < 6)
                    lblMsg.Text = "Código de validação inválido.";
                else {
                    nPos2 = sCod.IndexOf("/");
                    if (nPos2 < 5 || nPos - nPos2 < 2)
                        lblMsg.Text = "Código de validação inválido.";
                    else {
                        nCodigo = Convert.ToInt32(sCod.Substring(nPos2 + 1, nPos - nPos2 - 1));
                        nAno = Convert.ToInt32(sCod.Substring(nPos2 - 4, 4));
                        nNumero = Convert.ToInt32(sCod.Substring(0, 5));
                        if (nAno < 2010 || nAno > DateTime.Now.Year + 1)
                            lblMsg.Text = "Código de validação inválido.";
                        else {
                            sTipo = sCod.Substring(sCod.Length - 2, 2);
                            if (sTipo == "EA") {
                                Certidao_endereco dados = Valida_Endereco(nNumero, nAno, nCodigo);
                                if (dados != null)
                                    Exibe_Certidao_Endereco(dados);
                                else
                                    lblMsg.Text = "Certidão não cadastrada.";
                            } else {
                                lblMsg.Text = "Código de validação inválido.";
                            }
                        }
                    }
                }
            }
        }

        private Certidao_endereco Valida_Endereco(int Numero, int Ano, int Codigo) {
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            Certidao_endereco dados = tributario_Class.Retorna_Certidao_Endereco(Ano, Numero, Codigo);
            return dados;
        }

        private void Exibe_Certidao_Endereco(Certidao_endereco dados) {
            lblMsg.Text = "";
            string sComplemento = dados.Li_compl;
            string sQuadras = string.IsNullOrWhiteSpace(dados.Li_quadras) ? "" : " Quadra: " + dados.Li_quadras.ToString().Trim();
            string sLotes = string.IsNullOrWhiteSpace(dados.Li_lotes) ? "" : " Lote: " + dados.Li_lotes.ToString().Trim();
            sComplemento += sQuadras + sLotes;
            string sEndereco = dados.Logradouro + ", " + dados.Numero.ToString() + sComplemento;


            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/CertidaoEnderecoValida.rpt"));
            crystalReport.SetParameterValue("NUMCERTIDAO", dados.Numero.ToString("00000") + "/" + dados.Ano.ToString("0000"));
            crystalReport.SetParameterValue("DATAEMISSAO", dados.Data.ToString("dd/MM/yyyy") + " às " + dados.Data.ToString("HH:mm:ss"));
            crystalReport.SetParameterValue("CONTROLE", dados.Numero.ToString("00000") + dados.Ano.ToString("0000") + "/" + dados.Codigo.ToString() + "-EA");
            crystalReport.SetParameterValue("ENDERECO", sEndereco);
            crystalReport.SetParameterValue("CADASTRO", dados.Codigo.ToString("000000"));
            crystalReport.SetParameterValue("NOME", dados.Nomecidadao);
            crystalReport.SetParameterValue("INSCRICAO", dados.Inscricao);
            crystalReport.SetParameterValue("BAIRRO", dados.descbairro);

            HttpContext.Current.Response.Buffer = false;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();

            try {
                crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "comp" + dados.Numero.ToString() + dados.Ano.ToString()+"_EA");
            } catch {
            } finally {
                crystalReport.Close();
                crystalReport.Dispose();
            }

        }


    }
}