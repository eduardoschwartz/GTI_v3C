using CrystalDecisions.CrystalReports.Engine;
using GTI_Bll.Classes;
using GTI_Models;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;

namespace GTI_Web.Pages {
    public partial class certidaoisencao : System.Web.UI.Page {
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
                    ImovelStruct _dadosImovel = imovel_Class.Dados_Imovel(Codigo);
                    if (_dadosImovel.ResideImovel == false)
                        lblMsg.Text = "Isenção válida apenas proprietários residentes no imóvel.";
                    else {


                        if (txtimgcode.Text != Session["randomStr"].ToString())
                            lblMsg.Text = "Código da imagem inválido";
                        else
                            PrintReport(Codigo);
                    }                }
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
                            if (sTipo == "CI") {
                                Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
                                ImovelStruct _dadosImovel = imovel_Class.Dados_Imovel(Convert.ToInt32(sCod));
                                
                                    Certidao_isencao dados = Valida_Dados(nNumero, nAno, nCodigo);
                                    if (dados != null)
                                        Exibe_Certidao_Isencao(dados);
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

        private void PrintReport(int Codigo) {
            Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
            decimal SomaArea = imovel_Class.Soma_Area(Codigo);

            ImovelStruct Reg = imovel_Class.Dados_Imovel(Codigo);
            string sComplemento = string.IsNullOrWhiteSpace(Reg.Complemento) ? "" : " " + Reg.Complemento.ToString().Trim();
            string sQuadras = string.IsNullOrWhiteSpace(Reg.QuadraOriginal) ? "" : " Quadra: " + Reg.QuadraOriginal.ToString().Trim();
            string sLotes = string.IsNullOrWhiteSpace(Reg.LoteOriginal) ? "" : " Lote: " + Reg.LoteOriginal.ToString().Trim();
            sComplemento += sQuadras + sLotes;
            string sEndereco = Reg.NomeLogradouro + ", " + Reg.Numero.ToString() + sComplemento;
            string sBairro = Reg.NomeBairro;
            string sInscricao = Reg.Distrito.ToString() + "." + Reg.Setor.ToString("00") + "." + Reg.Quadra.ToString("0000") + "." + Reg.Lote.ToString("00000") + "." +
                Reg.Seq.ToString("00") + "." + Reg.Unidade.ToString("00") + "." + Reg.SubUnidade.ToString("000");
            List<ProprietarioStruct> Lista = imovel_Class.Lista_Proprietario(Codigo, true);
            string sNome = Lista[0].Nome;
            string sNumeroProcesso = "",sDataProcesso="";


            ReportDocument crystalReport = new ReportDocument();

            bool bImune = imovel_Class.Verifica_Imunidade(Codigo);
            bool bIsentoProcesso = false;
            List<IsencaoStruct> ListaIsencao=null;
            if (!bImune) {
                ListaIsencao = imovel_Class.Lista_Imovel_Isencao(Codigo, DateTime.Now.Year);
                if (ListaIsencao.Count > 0)
                    bIsentoProcesso = true;
            }

            decimal nPerc = 0;
            if (bImune) {
                crystalReport.Load(Server.MapPath("~/Report/CertidaoImunidade.rpt"));
                nPerc = 100;
                crystalReport.SetParameterValue("PERC", nPerc.ToString() + "%");
                crystalReport.SetParameterValue("DATAPROCESSO", sDataProcesso);
            } else {
                if (bIsentoProcesso) {
                    crystalReport.Load(Server.MapPath("~/Report/CertidaoIsencaoProcesso.rpt"));
                    nPerc = (decimal)ListaIsencao[0].Percisencao;
                    sNumeroProcesso = ListaIsencao[0].Numprocesso;
                    crystalReport.SetParameterValue("PERC", nPerc);
                    crystalReport.SetParameterValue("DATAPROCESSO", ListaIsencao[0].dataprocesso);
                } else {
                    if (SomaArea <= 65) {
                        //Se tiver área < 65m² mas tiver mais de 1 imóvel, perde a isenção.
                        int nQtdeImovel = imovel_Class.Qtde_Imovel_Cidadao(Codigo);
                        if (nQtdeImovel > 1) {
                            lblMsg.Text = "Este imóvel não esta isento da cobrança de IPTU no ano atual.";
                            return;
                        }
                        crystalReport.Load(Server.MapPath("~/Report/CertidaoIsencao65.rpt"));
                        crystalReport.SetParameterValue("PERC", nPerc.ToString() + "%");
                        crystalReport.SetParameterValue("DATAPROCESSO", sDataProcesso);
                    } else {
                        lblMsg.Text = "Este imóvel não esta isento da cobrança de IPTU no ano atual.";
                        return;
                    }
                }
            }
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            int _numero_certidao = tributario_Class.Retorna_Codigo_Certidao(modelCore.TipoCertidao.Isencao);
            int _ano_certidao = DateTime.Now.Year;

            Certidao_isencao cert = new Certidao_isencao();
            cert.Codigo = Codigo;
            cert.Ano = _ano_certidao;
            cert.Numero = _numero_certidao;
            cert.Data = DateTime.Now;
            cert.Inscricao = sInscricao;
            cert.Nomecidadao = sNome;
            cert.Logradouro = Reg.NomeLogradouro;
            cert.Li_num = Convert.ToInt32(Reg.Numero);
            cert.Li_compl = Reg.Complemento;
            cert.Descbairro = sBairro;
            cert.Li_quadras = Reg.QuadraOriginal;
            cert.Li_lotes = Reg.LoteOriginal;
            cert.Area = SomaArea;
            cert.Percisencao = nPerc;

            Exception ex = tributario_Class.Insert_Certidao_Isencao(cert);
            if (ex != null) {
                throw ex;
            } else {
                crystalReport.SetParameterValue("NUMCERTIDAO", _numero_certidao.ToString("00000") + "/" + _ano_certidao.ToString("0000"));
                crystalReport.SetParameterValue("DATAEMISSAO", DateTime.Now.ToString("dd/MM/yyyy") + " às " + DateTime.Now.ToString("HH:mm:ss"));
                crystalReport.SetParameterValue("CONTROLE", _numero_certidao.ToString("00000") + _ano_certidao.ToString("0000") + "/" + Codigo.ToString() + "-CI");
                crystalReport.SetParameterValue("ENDERECO", sEndereco);
                crystalReport.SetParameterValue("CADASTRO", Codigo.ToString("000000"));
                crystalReport.SetParameterValue("NOME", sNome);
                crystalReport.SetParameterValue("INSCRICAO", sInscricao);
                crystalReport.SetParameterValue("BAIRRO", sBairro);
                crystalReport.SetParameterValue("ANO", DateTime.Now.Year.ToString());
                crystalReport.SetParameterValue("AREA", string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:#,###.##}m²", SomaArea));
                crystalReport.SetParameterValue("NUMPROCESSO", sNumeroProcesso);

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

        private Certidao_isencao Valida_Dados(int Numero, int Ano, int Codigo) {
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            Certidao_isencao dados = tributario_Class.Retorna_Certidao_Isencao(Ano, Numero, Codigo);
            return dados;
        }

        private void Exibe_Certidao_Isencao(Certidao_isencao dados) {
            lblMsg.Text = "";
            string sComplemento = dados.Li_compl==null?"":" " + dados.Li_compl;
            string sQuadras = string.IsNullOrWhiteSpace(dados.Li_quadras) ? "" : " Quadra: " + dados.Li_quadras.ToString().Trim();
            string sLotes = string.IsNullOrWhiteSpace(dados.Li_lotes) ? "" : " Lote: " + dados.Li_lotes.ToString().Trim();
            sComplemento += sQuadras + sLotes;
            string sEndereco = dados.Logradouro + ", " + dados.Numero.ToString() + sComplemento;

            Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
            decimal nPerc = (decimal)dados.Percisencao;
            if (nPerc == 0) nPerc = 100;
            string sProc = "";

            if (dados.Numero >0) {
                List<IsencaoStruct> ListaIsencao = null;
                ListaIsencao = imovel_Class.Lista_Imovel_Isencao(dados.Codigo, DateTime.Now.Year);
                sProc = ListaIsencao[0].Numprocesso + " de " + Convert.ToDateTime(ListaIsencao[0].dataprocesso).ToString("dd/MM/yyyy");
            }

            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/CertidaoIsencaoValida.rpt"));
            crystalReport.SetParameterValue("NUMCERTIDAO", dados.Numero.ToString("00000") + "/" + dados.Ano.ToString("0000"));
            crystalReport.SetParameterValue("DATAEMISSAO", dados.Data.ToString("dd/MM/yyyy") + " às " + dados.Data.ToString("HH:mm:ss"));
            crystalReport.SetParameterValue("CONTROLE", dados.Numero.ToString("00000") + dados.Ano.ToString("0000") + "/" + dados.Codigo.ToString() + "-CI");
            crystalReport.SetParameterValue("ENDERECO", sEndereco);
            crystalReport.SetParameterValue("CADASTRO", dados.Codigo.ToString("000000"));
            crystalReport.SetParameterValue("NOME", dados.Nomecidadao);
            crystalReport.SetParameterValue("INSCRICAO", dados.Inscricao);
            crystalReport.SetParameterValue("BAIRRO", dados.Descbairro);
            crystalReport.SetParameterValue("PERC", nPerc);
            crystalReport.SetParameterValue("PROCESSO", sProc);

            HttpContext.Current.Response.Buffer = false;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();

            try {
                crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "comp" + dados.Numero.ToString() + dados.Ano.ToString());
            } catch {
            } finally {
                crystalReport.Close();
                crystalReport.Dispose();
            }

        }




    }
}