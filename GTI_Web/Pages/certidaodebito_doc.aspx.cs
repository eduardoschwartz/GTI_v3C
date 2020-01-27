using CrystalDecisions.CrystalReports.Engine;
using GTI_Bll.Classes;
using GTI_Models;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Web;
using UIWeb;
using static GTI_Models.modelCore;

namespace GTI_Web.Pages {
    public partial class certidaodebito_doc : System.Web.UI.Page {
        
        protected void Page_Load(object sender, EventArgs e) {
            lblMsg.Text = "";
            String s = Request.QueryString["d"];
            if (s != "gti")
                Response.Redirect("~/Pages/gtiMenu.aspx");

        }

        protected void optCPF_CheckedChanged(object sender, EventArgs e) {
            if (optCPF.Checked) {
                txtCPF.Visible = true;
                txtCNPJ.Visible = false;
                txtCPF.Text = "";
                txtCNPJ.Text = "";
            }
        }

        protected void optCNPJ_CheckedChanged(object sender, EventArgs e) {
            if (optCNPJ.Checked) {
                txtCPF.Visible = false;
                txtCNPJ.Visible = true;
                txtCPF.Text = "";
                txtCNPJ.Text = "";
            }
        }

        //Function to get random number
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber() {
            lock (syncLock) { // synchronize
                return getrandom.Next(1, 2000000);
            }
        }

        protected void btPrint_Click(object sender, EventArgs e) {
            string sCPF = txtCPF.Text, sCNPJ = txtCNPJ.Text;
            if (sCPF == "" && sCNPJ == "")
                lblMsg.Text = "Digite o CPF/CNPJ da empresa.";
            else {
                if (sCPF != "") {
                    bool _validacpf = gtiCore.ValidaCpf(txtCPF.Text);
                    if (!_validacpf) {
                        lblMsg.Text = "CPF inválido.";
                        return;
                    }
                } else {
                    bool _validacnpj = gtiCore.ValidaCNPJ(txtCNPJ.Text);
                    if (!_validacnpj) {
                        lblMsg.Text = "CNPJ inválido.";
                        return;
                    }
                }

                lblMsg.Text = "";
                bool bCompetenciaOK = true;
                Sistema_bll sistema_Class = new Sistema_bll("GTIconnection");
                List<int> _codigos = sistema_Class.Lista_Codigos_Documento(sCPF != "" ? sCPF : sCNPJ, sCPF != "" ?TipoDocumento.Cpf:TipoDocumento.Cnpj);
                if (_codigos.Count > 0) {
                    if (txtimgcode.Text != Session["randomStr"].ToString())
                        lblMsg.Text = "Código da imagem inválido";
                    else {
                        Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
                        foreach (int _codigo in _codigos) {
                            if (_codigo >= 100000 && _codigo < 500000) {
                                string Regime = empresa_Class.RegimeEmpresa(_codigo);
                                if (Regime == "V") {
                                    //Verifica competência en
                                    Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
                                    Eicon_bll eicon_Class = new Eicon_bll("GTIEicon");
                                    int _holes = tributario_Class.Competencias_Nao_Encerradas(eicon_Class.Resumo_CompetenciaISS(_codigo));
                                    if (_holes != 0)
                                        bCompetenciaOK = false;
                                }
                            }
                        }
                    }

                    if (bCompetenciaOK)
                        PrintReport(_codigos);
                    else
                        lblMsg.Text = "Existem competências não encerradas.";
                } else {
                    lblMsg.Text = "Não há inscrições cadastradas com este CPF/CNPJ.";
                }
            }
        }

        private void PrintReport(List<int>_codigos) {
            ReportDocument crystalReport = new ReportDocument();
            string sData = "18/04/2012", sTributo = "",sNao="",sCertifica = "";
            short  nRet = 0;
            List<Certidao_debito_documento> _lista_certidao = new List<Certidao_debito_documento>();
            RetornoCertidaoDebito _tipo_Certidao; 

            DateTime dDataProc = Convert.ToDateTime(sData);
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");

            if (_codigos.Count == 0) {
                nRet = 0;
                sTributo = "";
                goto SEM_INSCRICAO;
            }

            bool  bEmpresa = false, bCidadao = false,bImovel=false;
            Sistema_bll sistema_Class = new Sistema_bll("GTIconnection");
            string sNome = "";
            if (optCPF.Checked)
                sNome = sistema_Class.Nome_por_Cpf(gtiCore.RetornaNumero( txtCPF.Text));
            else
                sNome = sistema_Class.Nome_por_Cnpj(gtiCore.RetornaNumero( txtCNPJ.Text));


            foreach (int _codigo in _codigos) {
                TipoCadastro _tipo_cadastro = _codigo < 100000 ? TipoCadastro.Imovel : _codigo >= 100000 && _codigo < 500000 ? TipoCadastro.Empresa : TipoCadastro.Cidadao;

 //               Contribuinte_Header_Struct _header = sistema_Class.Contribuinte_Header(_codigo);
                //string sNome =  _header==null?"":   _header.Nome;

                //***Verifica débito
                Certidao_debito_detalhe dadosCertidao = tributario_Class.Certidao_Debito(_codigo);
                if (dadosCertidao.Tipo_Retorno == RetornoCertidaoDebito.Negativa) {
                    nRet = 3;
                    sTributo = "";
                } else {
                    if (dadosCertidao.Tipo_Retorno == RetornoCertidaoDebito.Positiva) {
                        if (_tipo_cadastro == TipoCadastro.Empresa) bEmpresa = true;
                        if (_tipo_cadastro == TipoCadastro.Cidadao) bCidadao = true;
                        if (_tipo_cadastro == TipoCadastro.Imovel) bImovel = true;
                        nRet = 4;
                        sTributo = dadosCertidao.Descricao_Lancamentos;
                    } else {
                        if (dadosCertidao.Tipo_Retorno == RetornoCertidaoDebito.NegativaPositiva) {
                            nRet = 5;
                            sTributo = dadosCertidao.Descricao_Lancamentos;
                        }
                    }
                }
                
                Certidao_debito_documento reg = new Certidao_debito_documento();
                reg._Codigo = _codigo;
                reg._Ret = nRet;
                reg._Tributo = sTributo;
                reg._Nome = sNome==null?"": sNome.Trim();
                _lista_certidao.Add(reg);
            }

            bool _find = false;
            foreach (Certidao_debito_documento reg in _lista_certidao) {
                if (reg._Ret != 3) {
                    _find = true;
                    break;
                }
            }
            if (!_find) {
                _tipo_Certidao = RetornoCertidaoDebito.Negativa;
                sNao = " não";
            } else {
                _find = false;
                foreach (Certidao_debito_documento reg in _lista_certidao) {
                    if (reg._Ret == 4) {
                        _find = true;
                        break;
                    }
                }
                if (_find) {
                    _tipo_Certidao = RetornoCertidaoDebito.Positiva;
                    if (!bEmpresa && !bCidadao && !bImovel) {
                        //Se a certidão positiva for apenas de imóvel, verifica se esta no prazo das parcelas únicas em aberto.
                        bool bUnicaNaoPago = false;
                        foreach (int _codigo in _codigos) {
                            bUnicaNaoPago = tributario_Class.Parcela_Unica_IPTU_NaoPago(_codigo, DateTime.Now.Year);
                            if (bUnicaNaoPago) break;
                        }
                        if (bUnicaNaoPago) {
                            sCertifica = " embora conste parcela(s) não paga(s) do IPTU de " + DateTime.Now.Year.ToString() + ", em razão da possibilidade do pagamento integral deste imposto em data futura, ";
                            sNao = " não";
                            nRet = 3;
                            _tipo_Certidao = RetornoCertidaoDebito.Negativa;
                        }
                    }
                } else {
                    _tipo_Certidao = RetornoCertidaoDebito.NegativaPositiva;
                }
            }

            string _tributo = "";
            foreach (Certidao_debito_documento item in _lista_certidao) {
                if (item._Tributo != "")
                    _tributo += item._Tributo + " (IM:" + item._Codigo + ")" + ",";
            }
            if(_tributo.Length>0)
                _tributo = _tributo.Substring(0, _tributo.Length - 1);
            int _numero_certidao = tributario_Class.Retorna_Codigo_Certidao(modelCore.TipoCertidao.Debito_Doc);
            int _ano_certidao = DateTime.Now.Year;
            certidao_debito_doc cert = new certidao_debito_doc();
            cert.Ano = (short)_ano_certidao;
            
            cert.Numero = _numero_certidao;
            cert.Data_emissao = DateTime.Now;
            cert.Nome = _lista_certidao[0]._Nome;
            cert.Cpf_cnpj = optCPF.Checked ? txtCPF.Text : txtCNPJ.Text;

            if (_tipo_Certidao == RetornoCertidaoDebito.Negativa) {
                cert.Validacao = _numero_certidao.ToString("00000") + _ano_certidao.ToString("0000") + "/" + _lista_certidao[0]._Codigo.ToString() + "-IN";
                cert.Tributo = "Não consta débito apurado contra o(a) mesmo(a).";
                cert.Ret = 1;
            } else {
                if (_tipo_Certidao == RetornoCertidaoDebito.Positiva) {
                    cert.Validacao = _numero_certidao.ToString("00000") + _ano_certidao.ToString("0000") + "/" + _lista_certidao[0]._Codigo.ToString() + "-IP";
                    cert.Tributo = "Consta débito apurado contra o(a) mesmo(a) com referência a: " + _tributo;
                    cert.Ret = 2;
                } else {
                    if (_tipo_Certidao == RetornoCertidaoDebito.NegativaPositiva) {
                        cert.Validacao = _numero_certidao.ToString("00000") + _ano_certidao.ToString("0000") + "/" + _lista_certidao[0]._Codigo.ToString() + "-IS";
                        cert.Tributo = "Consta débito apurado contra o(a) mesmo(a) com referência a: " + _tributo + " que se encontram em sua exigibilidade suspensa, em razão de parcelamento dos débitos";
                        cert.Ret = 3;
                    }
                }
            }

            Exception ex = tributario_Class.Insert_Certidao_Debito_Doc(cert);
                    
            if (ex != null) {
                throw ex;
            } else {
                if (_tipo_Certidao == RetornoCertidaoDebito.Negativa) {
                    crystalReport.Load(Server.MapPath("~/Report/CertidaoDebitoDocumentoN.rpt"));
                    crystalReport.SetParameterValue("NUMCERTIDAO", _numero_certidao.ToString("00000") + "/" + _ano_certidao.ToString("0000"));
                    crystalReport.SetParameterValue("DATAEMISSAO", DateTime.Now.ToString("dd/MM/yyyy") + " às " + DateTime.Now.ToString("HH:mm:ss"));
                    crystalReport.SetParameterValue("CONTROLE", cert.Validacao);
                    crystalReport.SetParameterValue("NOME", _lista_certidao[0]._Nome);
                    crystalReport.SetParameterValue("DOC", optCPF.Checked ? txtCPF.Text : txtCNPJ.Text);
                    crystalReport.SetParameterValue("NAO", sNao);
                    crystalReport.SetParameterValue("CERTIFICA", sCertifica);
                    HttpContext.Current.Response.Buffer = false;
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.ClearHeaders();

                    try {
                        crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "certidao" + _numero_certidao.ToString() + _ano_certidao.ToString());
                    } catch  {
                    } finally {
                        crystalReport.Close();
                        crystalReport.Dispose();
                    }
                } else {
                    if (_tipo_Certidao == RetornoCertidaoDebito.Positiva) {

                        crystalReport.Load(Server.MapPath("~/Report/CertidaoDebitoDocumentoP.rpt"));
                        crystalReport.SetParameterValue("NUMCERTIDAO", _numero_certidao.ToString("00000") + "/" + _ano_certidao.ToString("0000"));
                        crystalReport.SetParameterValue("DATAEMISSAO", DateTime.Now.ToString("dd/MM/yyyy") + " às " + DateTime.Now.ToString("HH:mm:ss"));
                        crystalReport.SetParameterValue("CONTROLE", cert.Validacao);
                        crystalReport.SetParameterValue("NOME", _lista_certidao[0]._Nome);
                        crystalReport.SetParameterValue("TRIBUTO", _tributo);
                        crystalReport.SetParameterValue("DOC", optCPF.Checked ? txtCPF.Text : txtCNPJ.Text);
                        HttpContext.Current.Response.Buffer = false;
                        HttpContext.Current.Response.ClearContent();
                        HttpContext.Current.Response.ClearHeaders();

                        try {
                            crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "certidao" + _numero_certidao.ToString() + _ano_certidao.ToString());
                        } catch  {
                        } finally {
                            crystalReport.Close();
                            crystalReport.Dispose();
                        }
                    } else {
                        if (_tipo_Certidao == RetornoCertidaoDebito.NegativaPositiva) {
                            crystalReport.Load(Server.MapPath("~/Report/CertidaoDebitoDocumentoPN.rpt"));
                            crystalReport.SetParameterValue("NUMCERTIDAO", _numero_certidao.ToString("00000") + "/" + _ano_certidao.ToString("0000"));
                            crystalReport.SetParameterValue("DATAEMISSAO", DateTime.Now.ToString("dd/MM/yyyy") + " às " + DateTime.Now.ToString("HH:mm:ss"));
                            crystalReport.SetParameterValue("CONTROLE", cert.Validacao);
                            crystalReport.SetParameterValue("NOME", _lista_certidao[0]._Nome);
                            crystalReport.SetParameterValue("TRIBUTO", _tributo);
                            crystalReport.SetParameterValue("DOC", optCPF.Checked ? txtCPF.Text : txtCNPJ.Text);
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
                }
            }

SEM_INSCRICAO:;

        }

        protected void ValidarButton_Click(object sender, EventArgs e) {
            string sCod = Codigo.Text.Trim();
            string sTipo = "";
            lblMsg.Text = "";
            int nPos = 0, nPos2 = 0, nCodigo = 0, nAno = 0, nNumero = 0;
            if (sCod.Length < 8)
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
                            if (sTipo == "IN" || sTipo == "IP" || sTipo == "IS") {
                                certidao_debito_doc dados = Valida_Dados(sCod);
                                if (dados != null)
                                  Exibe_Certidao_Debito(dados);
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

        private certidao_debito_doc Valida_Dados(string Validacao) {
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            certidao_debito_doc dados = tributario_Class.Retorna_Certidao_Debito_Doc(Validacao);
            return dados;
        }

        private void Exibe_Certidao_Debito(certidao_debito_doc dados) {
            lblMsg.Text = "";
            string sTipo = "";
            if (dados.Ret == 2)
                sTipo = "CERTDÂO POSITIVA";
            else {
                if (dados.Ret == 3)
                    sTipo = "CERTIDÃO POSITIVA EFEITO NEGATIVA";
                else
                    sTipo = "CERTIDÃO NEGATIVA";
            }

            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/CertidaoDebitoDocValida.rpt"));
            crystalReport.SetParameterValue("NUMCERTIDAO", dados.Numero.ToString("00000") + "/" + dados.Ano.ToString("0000"));
            crystalReport.SetParameterValue("DATAEMISSAO", Convert.ToDateTime(dados.Data_emissao).ToString("dd/MM/yyyy") + " às " + Convert.ToDateTime(dados.Data_emissao).ToString("HH:mm:ss"));
            crystalReport.SetParameterValue("CONTROLE", dados.Validacao);
            crystalReport.SetParameterValue("NOME", dados.Nome);
            crystalReport.SetParameterValue("CPF", dados.Cpf_cnpj);
            crystalReport.SetParameterValue("TIPO", sTipo);
            crystalReport.SetParameterValue("TRIBUTO", string.IsNullOrWhiteSpace(dados.Tributo) ? "N/A" : dados.Tributo);

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

    class Certidao_debito_documento {
        public int _Codigo { get; set; }
        public string _Nome { get; set; }
        public int _Ret { get; set; }
        public string _Tributo { get; set; }
    }


}