using CrystalDecisions.CrystalReports.Engine;
using GTI_Bll.Classes;
using GTI_Models;
using GTI_Models.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using UIWeb;
using static GTI_Models.modelCore;
using CrystalDecisions.Shared;

namespace GTI_Web.Pages {
    public partial class certidaoinscricao : System.Web.UI.Page {
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
                CodigoList.Items.Clear();
            }
        }

        protected void optCNPJ_CheckedChanged(object sender, EventArgs e) {
            if (optCNPJ.Checked) {
                txtCPF.Visible = false;
                txtCNPJ.Visible = true;
                txtCPF.Text = "";
                txtCNPJ.Text = "";
                CodigoList.Items.Clear();
            }
        }

        protected void btPrint_Click(object sender, EventArgs e) {
            string sCPF = txtCPF.Text,sCNPJ=txtCNPJ.Text;
            int Codigo = 0;

            if (sCPF == "" && sCNPJ=="")
                lblMsg.Text = "Digite o CPF/CNPJ da empresa.";
            else {
                
                if (CodigoList.Items.Count > 0) {
                    Codigo = Convert.ToInt32(CodigoList.Text);
                }
                lblMsg.Text = "";
                if (Codigo > 0) {
                    if (txtimgcode.Text != Session["randomStr"].ToString())
                        lblMsg.Text = "Código da imagem inválido";
                    else {
                        if (ExtratoCheckBox.Checked && optCNPJ.Checked)
                            lblMsg.Text = "Resumo de pagamento apenas para pessoas físicas.";
                        else
                            PrintReport(Codigo, TipoCadastro.Empresa);
                    }
                } else {
                    lblMsg.Text = "Selecione uma inscrição municipal da lista.";
                }
            }
        }

        private void PrintReport(int Codigo, TipoCadastro _tipo_cadastro) {
            ReportDocument crystalReport = new ReportDocument();
            string sComplemento = "", sQuadras = "", sLotes = "", sEndereco = "", sBairro = "",  sNome = "", sCidade = "", sUF = "";
            string sData = "18/04/2012",  sCPF = "", sCNPJ = "", sAtividade = "", sRG = "", sProcAbertura = "", sSufixo = "", sProcEncerramento="", sDoc = "";
            string sCep = "",sInscEstadual="",sFantasia="",sFone="",sEmail="",sTaxaLicenca="",sVigilancia="",sMei="",sSituacao="",sAtividade2="";
            short nNumeroImovel = 0;
            string sArea = "0";
            DateTime dDataProc = Convert.ToDateTime(sData);
            DateTime?  dDataAbertura = null,dDataEncerramento = null;

            Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
            EmpresaStruct Reg = empresa_Class.Retorna_Empresa(Codigo);
            sComplemento = string.IsNullOrWhiteSpace(Reg.Complemento) ? "" : " " + Reg.Complemento.ToString().Trim();
            sComplemento += sQuadras + sLotes;
            sEndereco = Reg.Endereco_nome + ", " + Reg.Numero.ToString() + sComplemento;
            nNumeroImovel = (short)Reg.Numero;
            sBairro = Reg.Bairro_nome;
            sCidade = Reg.Cidade_nome;
            sUF = Reg.UF;
            sCep = Reg.Cep;
            sNome = Reg.Razao_social;
            sFantasia = string.IsNullOrWhiteSpace(Reg.Nome_fantasia)?"NÃO INFORMADO":Reg.Nome_fantasia;
            sCPF = string.IsNullOrWhiteSpace( Reg.Cpf)  ? "" : Reg.Cpf;
            sCNPJ = string.IsNullOrWhiteSpace( Reg.Cnpj)  ? "" : Reg.Cnpj;
            sRG = Reg.Rg ?? "";
            sInscEstadual = string.IsNullOrWhiteSpace(Reg.Inscricao_estadual)?"ISENTO":Reg.Inscricao_estadual;
            sFone = Reg.Fone_contato;
            sEmail = Reg.Email_contato;
            sArea = Convert.ToSingle(Reg.Area).ToString("#0.00");
            sDoc = gtiCore.FormatarCpfCnpj( Reg.Cpf_cnpj);
            sProcAbertura = Reg.Numprocesso==null?"": Reg.Numprocesso.ToString();
            dDataAbertura = Reg.Data_abertura;
            if (Reg.Data_Encerramento != null) {
                dDataEncerramento = Reg.Data_Encerramento;
                sProcEncerramento = Reg.Numprocessoencerramento.ToString();
            }
            sVigilancia = empresa_Class.Empresa_tem_VS(Codigo) ? "SIM" : "NÃO";
            sTaxaLicenca = empresa_Class.Existe_Debito_TaxaLicenca(Codigo,DateTime.Now.Year) ? "SIM" : "NÃO";
            sMei = empresa_Class.Empresa_Mei(Codigo) ? "SIM" : "NÃO";
            sSituacao = Reg.Situacao;

            List<CnaeStruct> Lista_Cnae = empresa_Class.Lista_Cnae_Empresa(Codigo);
            foreach (CnaeStruct item in Lista_Cnae) {
                if (item.Principal)
                    sAtividade += item.CNAE + "-" + item.Descricao;
                else
                    sAtividade2+=item.CNAE + "-" + item.Descricao + "; "  ;
            }
            List<CnaeStruct> Lista_Cnae2 = empresa_Class.Lista_Cnae_Empresa_VS(Codigo);
            foreach (CnaeStruct item in Lista_Cnae) {
                bool _find = false;
                for (int i = 0; i < Lista_Cnae.Count; i++) {
                    if (item.CNAE == Lista_Cnae[i].CNAE) {
                        _find = true;
                        break;
                    }
                }
                if(!_find)
                    sAtividade2 += item.CNAE + "-" + item.Descricao + "; ";
            }


            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            int _numero_certidao = tributario_Class.Retorna_Codigo_Certidao(modelCore.TipoCertidao.Debito);
            short _ano_certidao = (short)DateTime.Now.Year;


            if (ExtratoCheckBox.Checked) {
                
                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                Tables CrTables;

                if (dDataEncerramento != null) {
                    crystalReport.Load(Server.MapPath("~/Report/CertidaoInscricaoExtratoEncerrada.rpt"));
                    sSufixo = "XE";
                } else {
                    crystalReport.Load(Server.MapPath("~/Report/CertidaoInscricaoExtratoAtiva.rpt"));
                    sSufixo = "XA";
                }
                string Controle = Grava_Extrato_Pagamento(Codigo, _numero_certidao, _ano_certidao,sSufixo);
                crystalReport.RecordSelectionFormula = "{Certidao_inscricao_extrato.Id}='" + Controle + "'";
                crConnectionInfo.ServerName = "200.232.123.115";
                crConnectionInfo.DatabaseName = "Tributacao";
                crConnectionInfo.UserID = "gtisys";
                crConnectionInfo.Password = "everest";

                CrTables = crystalReport.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables) {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

            } else {
                    crystalReport.Load(Server.MapPath("~/Report/ComprovanteInscricao.rpt"));
                    sSufixo = "IE";
            }

            Certidao_inscricao cert = new Certidao_inscricao();
            cert.Cadastro = Codigo;
            cert.Ano = (short)_ano_certidao;
            cert.Numero = _numero_certidao;
            cert.Data_emissao = DateTime.Now;
            cert.Nome = sNome;
            cert.Endereco = sEndereco;
            cert.Rg = sRG;
            cert.Bairro = sBairro;
            cert.Cidade = sCidade;
            cert.Processo_abertura = sProcAbertura;
            cert.Data_abertura = Convert.ToDateTime( dDataAbertura);
            if (dDataEncerramento != null) {
                cert.Processo_encerramento = sProcEncerramento;
                cert.Data_encerramento =  Convert.ToDateTime(dDataEncerramento);
            }
            cert.Documento = sDoc;
            cert.Atividade = sAtividade;
            cert.Area = Convert.ToDecimal( sArea);
            cert.Atividade_secundaria = sAtividade2;
            cert.Cep = sCep;
            cert.Complemento = sComplemento;
            cert.Email = sEmail;
            cert.Inscricao_estadual = sInscEstadual;
            cert.Mei = sMei;
            cert.Nome_fantasia = sFantasia;
            cert.Situacao = sSituacao;
            cert.Taxa_licenca = sTaxaLicenca;
            if (sFone == null)
                cert.Telefone = "";
            else
                cert.Telefone =  sFone.Length>30? sFone.Substring(0,30)  : sFone;
            cert.Vigilancia_sanitaria = sVigilancia;

            Exception ex = tributario_Class.Insert_Certidao_Inscricao(cert);
            if (ex != null) {
                throw ex;
            } else {
                crystalReport.SetParameterValue("NUMCERTIDAO", _numero_certidao.ToString("00000") + "/" + _ano_certidao.ToString("0000"));
                crystalReport.SetParameterValue("DATAEMISSAO", DateTime.Now.ToString("dd/MM/yyyy") + " às " + DateTime.Now.ToString("HH:mm:ss"));
                crystalReport.SetParameterValue("CONTROLE", _numero_certidao.ToString("00000") + _ano_certidao.ToString("0000") + "/" + Codigo.ToString() + "-" + sSufixo);
                crystalReport.SetParameterValue("ENDERECO", sEndereco);
                crystalReport.SetParameterValue("CADASTRO", Codigo.ToString("000000"));
                crystalReport.SetParameterValue("NOME", sNome);
                crystalReport.SetParameterValue("BAIRRO", sBairro);
                crystalReport.SetParameterValue("RG", sRG);
                crystalReport.SetParameterValue("DOCUMENTO", sDoc);
                crystalReport.SetParameterValue("CIDADE", sCidade + "/" + sUF);
                crystalReport.SetParameterValue("ATIVIDADE", sAtividade);
                crystalReport.SetParameterValue("DATAABERTURA", dDataAbertura);
                crystalReport.SetParameterValue("PROCESSOABERTURA", sProcAbertura==null?"":sProcAbertura);
                crystalReport.SetParameterValue("DATAENCERRAMENTO", dDataEncerramento==null?DateTime.Now:dDataEncerramento);
                crystalReport.SetParameterValue("PROCESSOENCERRAMENTO", sProcEncerramento);
                crystalReport.SetParameterValue("IESTADUAL", sInscEstadual==null?"":sInscEstadual);
                crystalReport.SetParameterValue("FANTASIA", sFantasia);
                crystalReport.SetParameterValue("ATIVIDADE2", sAtividade2);
                crystalReport.SetParameterValue("COMPLEMENTO", sComplemento==null?"":sComplemento);
                crystalReport.SetParameterValue("CEP", sCep);
                crystalReport.SetParameterValue("SITUACAO", sSituacao);
                crystalReport.SetParameterValue("TELEFONE", sFone==null?"":sFone);
                crystalReport.SetParameterValue("EMAIL",sEmail==null?"":sEmail);
                crystalReport.SetParameterValue("TAXALICENCA", sTaxaLicenca);
                crystalReport.SetParameterValue("VIGILANCIA", sVigilancia);
                crystalReport.SetParameterValue("MEI", sMei);
                crystalReport.SetParameterValue("AREA", sArea);
                

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
                            if (sTipo == "IE" || sTipo == "IA" || sTipo== "XA" || sTipo == "XE") {
                                Certidao_inscricao dados = Valida_Dados(nNumero, nAno, nCodigo);
                                if (dados != null)
                                    Exibe_Certidao_Inscricao(dados,sTipo);
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
        
        private Certidao_inscricao Valida_Dados(int Numero, int Ano, int Codigo) {
            Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
            Certidao_inscricao dados = empresa_Class.Certidao_inscricao_gravada(Ano, Numero);
            //            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            //Certidao_inscricao dados = tributario_Class.Retorna_Certidao_Inscricao(Ano, Numero, Codigo);
            return dados;
        }

        private void Exibe_Certidao_Inscricao(Certidao_inscricao dados, string Tipo) {
            lblMsg.Text = "";

            ReportDocument crystalReport = new ReportDocument();

            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;

            if (Tipo == "IE" || Tipo == "IA")
                crystalReport.Load(Server.MapPath("~/Report/ComprovanteInscricaoValida.rpt"));
            else {
                crystalReport.Load(Server.MapPath("~/Report/CertidaoInscricaoExtratoValida.rpt"));
                crystalReport.RecordSelectionFormula = "{certidao_inscricao_extrato.ano_certidao}=" + dados.Ano +  " and {certidao_inscricao_extrato.numero_certidao}=" +dados.Numero ;
            }

            crConnectionInfo.ServerName = "200.232.123.115";
            crConnectionInfo.DatabaseName = "Tributacao";
            crConnectionInfo.UserID = "gtisys";
            crConnectionInfo.Password = "everest";

            CrTables = crystalReport.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables) {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            crystalReport.SetParameterValue("NUMCERTIDAO", dados.Numero.ToString("00000") + "/" + dados.Ano.ToString("0000"));
            crystalReport.SetParameterValue("DATAEMISSAO", Convert.ToDateTime(dados.Data_emissao).ToString("dd/MM/yyyy") + " às " + Convert.ToDateTime(dados.Data_emissao).ToString("HH:mm:ss"));
            crystalReport.SetParameterValue("CONTROLE", dados.Numero.ToString("00000") + dados.Ano.ToString("0000") + "/" + dados.Cadastro.ToString() + "-" + "IE");
            crystalReport.SetParameterValue("ENDERECO", dados.Endereco);
            crystalReport.SetParameterValue("CADASTRO", dados.Cadastro.ToString("000000"));
            crystalReport.SetParameterValue("NOME", dados.Nome);
            crystalReport.SetParameterValue("BAIRRO", dados.Bairro);
            crystalReport.SetParameterValue("DOCUMENTO", dados.Documento);
            crystalReport.SetParameterValue("CIDADE", dados.Cidade );
            crystalReport.SetParameterValue("ATIVIDADE", dados.Atividade);
            crystalReport.SetParameterValue("IESTADUAL", dados.Inscricao_estadual);
            crystalReport.SetParameterValue("DATAABERTURA", Convert.ToDateTime(dados.Data_abertura).ToString("dd/MM/yyyy"));
            crystalReport.SetParameterValue("FANTASIA", dados.Nome_fantasia);
            crystalReport.SetParameterValue("ATIVIDADE2", dados.Atividade_secundaria);
            crystalReport.SetParameterValue("COMPLEMENTO", dados.Complemento==null?"":dados.Complemento);
            crystalReport.SetParameterValue("CEP", dados.Cep);
            crystalReport.SetParameterValue("RG", "");
            crystalReport.SetParameterValue("SITUACAO", dados.Situacao);
            crystalReport.SetParameterValue("TELEFONE", dados.Telefone==null?"":dados.Telefone);
            crystalReport.SetParameterValue("EMAIL", dados.Email==null?"":dados.Email);
            crystalReport.SetParameterValue("TAXALICENCA", dados.Taxa_licenca);
            crystalReport.SetParameterValue("VIGILANCIA", dados.Vigilancia_sanitaria);
            crystalReport.SetParameterValue("MEI", dados.Mei);
            crystalReport.SetParameterValue("AREA", Convert.ToDouble(dados.Area).ToString("#0.00"));
            crystalReport.SetParameterValue("DATAENCERRAMENTO", Convert.ToDateTime(dados.Data_encerramento).ToString("dd/MM/yyyy"));
            crystalReport.SetParameterValue("PROCESSOABERTURA", dados.Processo_abertura);
            crystalReport.SetParameterValue("PROCESSOENCERRAMENTO", dados.Processo_encerramento==null?"":dados.Processo_encerramento);

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

        private string Grava_Extrato_Pagamento(int Codigo, int NumeroCertidao,short AnoCertidao,string Sufixo) {
            string Controle = NumeroCertidao.ToString("00000") + AnoCertidao.ToString("0000") + "/" + Codigo.ToString() + "-" + Sufixo;
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            List<SpExtrato> ListaTributo = tributario_Class.Lista_Extrato_Tributo(Codigo, 1980, 2050, 0, 99, 0, 99, 0, 999, 0, 99, 0, 99, DateTime.Now, "Web");
            List<SpExtrato> ListaParcela = tributario_Class.Lista_Extrato_Parcela(ListaTributo);
            
            foreach (SpExtrato item in ListaParcela.Where(x=>(x.Codlancamento==2 ||x.Codlancamento==6 || x.Codlancamento==14) && x.Statuslanc<3) ) {
                Certidao_inscricao_extrato reg = new Certidao_inscricao_extrato();
                reg.Id = Controle;
                reg.Numero_certidao = NumeroCertidao;
                reg.Ano_certidao = AnoCertidao;
                reg.Ano = item.Anoexercicio;
                reg.Codigo = item.Codreduzido;
                reg.Complemento = item.Codcomplemento;
                if (item.Datapagamento != null)
                    reg.Data_Pagamento = Convert.ToDateTime(item.Datapagamento);
                reg.Data_Vencimento = item.Datavencimento;
                reg.Lancamento_Codigo = item.Codlancamento;
                reg.Lancamento_Descricao = item.Desclancamento;
                reg.Parcela = (byte)item.Numparcela;
                reg.Sequencia= (byte)item.Seqlancamento;
                reg.Valor_Pago = (decimal)item.Valorpagoreal;
                Exception ex = tributario_Class.Insert_Certidao_Inscricao_Extrato(reg);
                if (ex != null)
                    throw ex;
            }
            
            return Controle;
        }

        protected void VerificarButton_Click(object sender, EventArgs e) {
            string sCPF = txtCPF.Text, sCNPJ = txtCNPJ.Text;
            List<int> _codigos = new List<int>();
            Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
            if (sCPF != "")
               _codigos = empresa_Class.Retorna_Codigo_por_CPF(gtiCore.RetornaNumero(sCPF));
            else {
                if (sCNPJ != "")
                    _codigos = empresa_Class.Retorna_Codigo_por_CNPJ(gtiCore.RetornaNumero(sCNPJ));
            }
            CodigoList.Items.Clear();
            foreach (int item in _codigos) {
                CodigoList.Items.Add(item.ToString());
            }
            if (CodigoList.Items.Count > 0)
                CodigoList.Items[0].Selected = true;

        }

        protected void txtCPF_TextChanged(object sender, EventArgs e) {
            if (CodigoList.Items.Count > 0)
                CodigoList.Items.Clear();
        }

        protected void txtCNPJ_TextChanged(object sender, EventArgs e) {
            if (CodigoList.Items.Count > 0)
                CodigoList.Items.Clear();
        }

        //Function to get random number
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber() {
            lock (syncLock) { // synchronize
                return getrandom.Next(1, 2000000);
            }
        }


    }
}