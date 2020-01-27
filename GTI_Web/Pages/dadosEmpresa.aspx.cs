using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using GTI_Models.Models;
using GTI_Bll.Classes;


namespace UIWeb.Pages {
    public partial class dadosEmpresa : System.Web.UI.Page {
        public static string sCnae2;
        public static string sSocio2;
        protected void Page_Load(object sender, EventArgs e) {
            String s = Request.QueryString["d"];
            if (s != "gti")
                Response.Redirect("~/Pages/gtiMenu.aspx");

            if (!IsPostBack) {
                txtCNPJ.Text = "";
                txtIM.Text = "";
                lblMsg.Text = "";
            }
        }

        protected void btAcesso_Click(object sender, EventArgs e) {
            lblMsg.Text = "";
            ClearTable();
            Empresa_bll empresa_class = new Empresa_bll("GTIconnection");
            if (string.IsNullOrWhiteSpace(txtIM.Text) && string.IsNullOrWhiteSpace(txtCNPJ.Text) && string.IsNullOrWhiteSpace(txtCPF.Text))
                lblMsg.Text = "Digite IM ou CPF ou CNPJ.";
            else {
                if (!string.IsNullOrWhiteSpace(txtIM.Text) && !string.IsNullOrWhiteSpace(txtCNPJ.Text) && !string.IsNullOrWhiteSpace(txtCPF.Text))
                    lblMsg.Text = "Erro: Digite a inscrição municipal ou o CPF ou o cNPJ da empresa.";

                else {
                    if (!string.IsNullOrWhiteSpace(txtIM.Text)) {
                        if (!empresa_class.Existe_Empresa(Convert.ToInt32(txtIM.Text)))
                            lblMsg.Text = "Erro: Cadastro inexistente.";
                        else
                            FillTable();
                    } else {

                        if (optCPF.Checked && txtCPF.Text.Length < 14) {
                            lblMsg.Text = "CPF inválido!";
                            return;
                        }
                        if (optCNPJ.Checked && txtCNPJ.Text.Length < 18) {
                            lblMsg.Text = "CNPJ inválido!";
                            return;
                        }
                        string num_cpf_cnpj = "";
                        int nCodigo = 0;
                        if (optCPF.Checked) {
                            num_cpf_cnpj = gtiCore.RetornaNumero(txtCPF.Text);
                            if (!gtiCore.ValidaCpf(num_cpf_cnpj)) {
                                lblMsg.Text = "CPF inválido!";
                                return;
                            } else {
                                List<int> ListaCPF = empresa_class.Retorna_Codigo_por_CPF(num_cpf_cnpj);
                                if(ListaCPF.Count>0)
                                    nCodigo = ListaCPF[0];
                            }
                        } else {
                            num_cpf_cnpj = gtiCore.RetornaNumero(txtCNPJ.Text);
                            if (!gtiCore.ValidaCNPJ(num_cpf_cnpj)) {
                                lblMsg.Text = "CNPJ inválido!";
                                return;
                            } else {
                                List<int> ListaCNPJ = empresa_class.Retorna_Codigo_por_CNPJ(num_cpf_cnpj);
                                if (ListaCNPJ.Count > 0)
                                    nCodigo = ListaCNPJ[0];
                            }
                        }

                        if (nCodigo == 0)
                            lblMsg.Text = "Erro: Cadastro inexistente.";
                        else {
                            txtIM.Text = nCodigo.ToString("000000");
                            FillTable();
                        }
                    }
                }
            }
        }

        private void ClearTable() {
            IM.Text = "";
            CNPJ.Text = "";
            RAZAOSOCIAL.Text = "";
            DATAABERTURA.Text = "";
            DATAENCERRAMENTO.Text = "";
            SITUACAO.Text = "";
            IE.Text = "";
            EMAIL.Text = "";
            TELEFONE.Text = "";
            REGIMEISS.Text = "";
            VIGSANIT.Text = "";
            TAXALICENCA.Text = "";
            MEI.Text = "";
            PROPRIETARIO.Text = "";
            CNAE.Text = "";
            ENDERECO.Text = "";
        }

        private void FillTable() {
            Empresa_bll empresa_class = new Empresa_bll("GTIconnection");
            Int32 Codigo = Convert.ToInt32(txtIM.Text);
            EmpresaStruct reg = empresa_class.Retorna_Empresa(Codigo);
            if (reg.Juridica)
                CNPJ.Text = Convert.ToUInt64(reg.Cpf_cnpj).ToString(@"00\.000\.000\/0000\-00");
            else {
                if (reg.Cpf_cnpj.Length > 1)
                    CNPJ.Text = Convert.ToUInt64(reg.Cpf_cnpj).ToString(@"000\.000\.000\-00");
                else
                    CNPJ.Text = "";
            }
            IM.Text = reg.Codigo.ToString();
            RAZAOSOCIAL.Text = reg.Razao_social;
            IE.Text = reg.Inscricao_estadual;
            DATAABERTURA.Text = Convert.ToDateTime(reg.Data_abertura).ToString("dd/MM/yyyy");
            DATAENCERRAMENTO.Text = String.IsNullOrEmpty(reg.Data_Encerramento.ToString()) ? "" : Convert.ToDateTime(reg.Data_Encerramento).ToString("dd/MM/yyyy");
            SITUACAO.Text = reg.Situacao;
            ENDERECO.Text = reg.Endereco_nome + ", " + reg.Numero + " " + reg.Complemento + " ";
            ENDERECO.Text += reg.Bairro_nome + "-" + reg.Cidade_nome + "/" + reg.UF + " Cep: " + reg.Cep;
            EMAIL.Text = reg.Email_contato;
            TELEFONE.Text = reg.Fone_contato;
            AREA.Text = string.Format("{0:0.00}", reg.Area);
            string sRegime = empresa_class.RegimeEmpresa(Codigo);
            if (sRegime == "F")
                sRegime = "ISS FIXO";
            else {
                if (sRegime == "V")
                    sRegime = "ISS VARIÁVEL";
                else {
                    if (sRegime == "E")
                        sRegime = "ISS ESTIMADO";
                    else
                        sRegime = "NENHUM";
                }
            }
            REGIMEISS.Text = sRegime;
            VIGSANIT.Text = empresa_class.Empresa_tem_VS(Codigo) ? "SIM" : "NÃO";
            TAXALICENCA.Text = empresa_class.Empresa_tem_TL(Codigo) ? "SIM" : "NÃO";
            MEI.Text = empresa_class.Empresa_Mei(Codigo) ? "SIM" : "NÃO";
            List<CidadaoStruct> ListaSocio = empresa_class.ListaSocio(Codigo);
            string sSocio = "";
            sSocio2 = "";
            foreach (CidadaoStruct Socio in ListaSocio) {
                sSocio += Socio.Nome + System.Environment.NewLine;
                sSocio2 += Socio.Nome + ", ";
            }
            if (!string.IsNullOrWhiteSpace(sSocio2))
                sSocio2 = sSocio2.Substring(0, sSocio2.Length - 2);
            PROPRIETARIO.Text = "<pre>" + sSocio + "</pre>";

            List<CnaeStruct> ListaCnae = empresa_class.Lista_Cnae_Empresa(Codigo);
            string sCnae = "";
            sCnae2 = "";
            foreach (CnaeStruct cnae in ListaCnae) {
                sCnae += cnae.CNAE + "-" + cnae.Descricao + System.Environment.NewLine;
                sCnae2 += cnae.CNAE + "-" + cnae.Descricao + System.Environment.NewLine;
            }
            if (!string.IsNullOrWhiteSpace(sCnae2))
                sCnae2 = sCnae2.Substring(0, sCnae2.Length - 1);

            CNAE.Text = "<pre>" + sCnae + "</pre>";
        }

        protected void btPrint_Click(object sender, EventArgs e) {
            if (String.IsNullOrWhiteSpace(RAZAOSOCIAL.Text))
                lblMsg.Text = "Selecione uma empresa para imprimir";
            else {
                lblMsg.Text = "";

                List<DEmpresa> aLista = new List<DEmpresa>();
                int nSid = gtiCore.GetRandomNumber();
                DEmpresa reg = new DEmpresa();
                reg.sid = nSid;
                reg.nome = "Inscrição Municipal";
                reg.valor = IM.Text;
                aLista.Add(reg);
                reg = new DEmpresa();
                reg.sid = nSid;
                reg.nome = "Razão Social";
                reg.valor = RAZAOSOCIAL.Text;
                aLista.Add(reg);
                reg = new DEmpresa();
                reg.sid = nSid;
                reg.nome = "CNPJ/CPF";
                reg.valor = CNPJ.Text;
                aLista.Add(reg);
                reg = new DEmpresa();
                reg.sid = nSid;
                reg.nome = "Data de Abertura";
                reg.valor = DATAABERTURA.Text;
                aLista.Add(reg);
                reg = new DEmpresa();
                reg.sid = nSid;
                reg.nome = "Data de Encerramento";
                reg.valor = DATAENCERRAMENTO.Text;
                aLista.Add(reg);
                reg = new DEmpresa();
                reg.sid = nSid;
                reg.nome = "Inscrição Estadual";
                reg.valor = IE.Text;
                aLista.Add(reg);
                reg = new DEmpresa();
                reg.sid = nSid;
                reg.nome = "Situação";
                reg.valor = SITUACAO.Text;
                aLista.Add(reg);
                reg = new DEmpresa();
                reg.sid = nSid;
                reg.nome = "Endereço";
                reg.valor = ENDERECO.Text;
                aLista.Add(reg);
                reg = new DEmpresa();
                reg.sid = nSid;
                reg.nome = "Email";
                reg.valor = EMAIL.Text;
                aLista.Add(reg);
                reg = new DEmpresa();
                reg.sid = nSid;
                reg.nome = "Telefone";
                reg.valor = TELEFONE.Text;
                aLista.Add(reg);
                reg = new DEmpresa();
                reg.sid = nSid;
                reg.nome = "Regime de ISS";
                reg.valor = REGIMEISS.Text;
                aLista.Add(reg);
                reg = new DEmpresa();
                reg.sid = nSid;
                reg.nome = "Vigilância Sanitária";
                reg.valor = VIGSANIT.Text;
                aLista.Add(reg);
                reg = new DEmpresa();
                reg.sid = nSid;
                reg.nome = "Taxa de Licença";
                reg.valor = TAXALICENCA.Text;
                aLista.Add(reg);
                reg = new DEmpresa();
                reg.sid = nSid;
                reg.nome = "Micro Emp. Individual";
                reg.valor = MEI.Text;
                aLista.Add(reg);
                reg = new DEmpresa();
                reg.sid = nSid;
                reg.nome = "Área";
                reg.valor = AREA.Text;
                aLista.Add(reg);
                reg = new DEmpresa();
                reg.sid = nSid;
                reg.nome = "Proprietário";
                reg.valor = sSocio2;
                aLista.Add(reg);
                reg = new DEmpresa();
                reg.sid = nSid;
                reg.nome = "Atividades";
                reg.valor = sCnae2;
                aLista.Add(reg);
                Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
                Exception ex = empresa_Class.Incluir_DEmp(aLista);
                if (ex != null) {
                    lblMsg.Text = "Erro na solicitação e dados ao servidor.";
                } else {
                    List<DEmpresa> ListaEmp = empresa_Class.ListaDEmpresa(nSid);
                    DataTable dt = gtiCore.ConvertToDatatable(ListaEmp);

                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType = string.Empty;
                    string encoding = string.Empty;
                    string extension = string.Empty;

                    DataSet Ds = gtiCore.ToDataSet(ListaEmp);
                    ReportDataSource rdsAct = new ReportDataSource("dsDadosEmpresa", Ds.Tables[0]);
                    ReportViewer viewer = new ReportViewer();
                    viewer.LocalReport.Refresh();
                    viewer.LocalReport.ReportPath = Server.MapPath("~/Report/rptDadosEmpresa.rdlc");
                    viewer.LocalReport.DataSources.Add(rdsAct); // Add  datasource here         
                    byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                    ex = empresa_Class.Delete_DEmpresa(nSid);
                    Response.Buffer = true;
                    Response.Clear();
                    Response.ContentType = mimeType;
                    Response.AddHeader("content-disposition", "attachment; filename= guia_pmj" + "." + extension);
                    Response.OutputStream.Write(bytes, 0, bytes.Length);
                    Response.Flush();
                    Response.End();
                }

            }
        }

        protected void optCPF_CheckedChanged(object sender, EventArgs e) {
            if (optCPF.Checked) {
                txtCPF.Visible = true;
                txtCNPJ.Visible = false;
                txtCPF.Text = "";
                txtCNPJ.Text = "";
                txtIM.Text = "";
            }
        }

        protected void optCNPJ_CheckedChanged(object sender, EventArgs e) {
            if (optCNPJ.Checked) {
                txtCPF.Visible = false;
                txtCNPJ.Visible = true;
                txtCPF.Text = "";
                txtCNPJ.Text = "";
                txtIM.Text = "";
            }
        }

        protected void txtCPF_TextChanged(object sender, EventArgs e) {
            txtCNPJ.Text = "";
            txtIM.Text = "";
        }

        protected void txtCNPJ_TextChanged(object sender, EventArgs e) {
            txtCPF.Text = "";
            txtIM.Text = "";
        }
    }

}