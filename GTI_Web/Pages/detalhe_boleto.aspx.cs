using GTI_Bll.Classes;
using GTI_Models.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UIWeb.Pages {
    public partial class detalhe_boleto : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                lblMsg.Text = "";
                txtCod.Text = "";
                String s = Request.QueryString["d"];
                if (s != "gti")
                    Response.Redirect("~/Pages/gtiMenu.aspx");

            }
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


        protected void txtCod_TextChanged(object sender, EventArgs e) {
            lblMsg.Text = "";
        }

        protected void btConsultar_Click(object sender, EventArgs e) {
            string num_cpf_cnpj = "";

            lblMsg.Text = "";
            if (txtCod.Text.Trim() == "") {
                lblMsg.Text = "Digite o número do documento.";
                return;
            }
            if (txtCod.Text.Length < 17) {
                lblMsg.Text = "Número de documento inválido.";
                return;
            }

            if (optCPF.Checked && txtCPF.Text.Length < 14) {
                lblMsg.Text = "CPF inválido!";
                return;
            }
            if (optCNPJ.Checked && txtCNPJ.Text.Length < 18) {
                lblMsg.Text = "CNPJ inválido!";
                return;
            }

            if (optCPF.Checked) {
                num_cpf_cnpj = gtiCore.RetornaNumero(txtCPF.Text);
                if (!gtiCore.ValidaCpf(num_cpf_cnpj)) {
                    lblMsg.Text = "CPF inválido!";
                    return;
                }
            } else {
                num_cpf_cnpj = gtiCore.RetornaNumero(txtCNPJ.Text);
                if (!gtiCore.ValidaCNPJ(num_cpf_cnpj)) {
                    lblMsg.Text = "CNPJ inválido!";
                    return;
                }
            }
            int nNumDoc = Convert.ToInt32(txtCod.Text.Substring(txtCod.Text.Length - 8, 8));
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            int nCodigo = 0;
            DateTime dDataDoc = Convert.ToDateTime("01/01/1900");
            decimal nValorGuia = 0;
            bool bExisteDoc = tributario_Class.Existe_Documento(nNumDoc);
            if (!bExisteDoc) {
                lblMsg.Text = "Número de documento não cadastrado.";
            } else {
                
                nCodigo = tributario_Class.Retorna_Codigo_por_Documento(nNumDoc);
                Numdocumento DadosDoc = tributario_Class.Retorna_Dados_Documento(nNumDoc);
                dDataDoc = Convert.ToDateTime(DadosDoc.Datadocumento);
                nValorGuia = Convert.ToDecimal( DadosDoc.Valorguia);
            }

            if (nCodigo < 100000) {
                Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
                ImovelStruct reg = imovel_Class.Dados_Imovel(nCodigo);
                List<ProprietarioStruct> regProp = imovel_Class.Lista_Proprietario(nCodigo, true);
                if (optCPF.Checked) {
                    if (Convert.ToInt64(gtiCore.RetornaNumero(regProp[0].CPF)).ToString("00000000000") != num_cpf_cnpj) {
                        lblMsg.Text = "CPF informado não pertence a este documento.";
                        return;
                    }
                } else {
                    if (Convert.ToInt64(gtiCore.RetornaNumero(regProp[0].CPF)).ToString("00000000000000") != num_cpf_cnpj) {
                        lblMsg.Text = "CNPJ informado não pertence a este documento.";
                        return;
                    }
                }
            } else {
                if (nCodigo >= 100000 && nCodigo < 500000) {
                    Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
                    EmpresaStruct reg = empresa_Class.Retorna_Empresa(nCodigo);
                    if (optCPF.Checked) {
                        if (Convert.ToInt64(gtiCore.RetornaNumero(reg.Cpf_cnpj)).ToString("00000000000") != num_cpf_cnpj) {
                            lblMsg.Text = "CPF informado não pertence a este documento.";
                            return;
                        }
                    } else {
                        if (Convert.ToInt64(gtiCore.RetornaNumero(reg.Cpf_cnpj)).ToString("00000000000000") != num_cpf_cnpj) {
                            lblMsg.Text = "CNPJ informado não pertence a este documento.";
                            return;
                        }
                    }
                } else {
                    Cidadao_bll cidadao_Class = new Cidadao_bll("GTIconnection");
                    CidadaoStruct reg = cidadao_Class.LoadReg(nCodigo);
                    if (optCPF.Checked) {
                        if (Convert.ToInt64(gtiCore.RetornaNumero(reg.Cpf)).ToString("00000000000") != num_cpf_cnpj) {
                            lblMsg.Text = "CPF informado não pertence a este documento.";
                            return;
                        }
                    } 
                    else {
                        if (Convert.ToInt64(gtiCore.RetornaNumero(reg.Cnpj)).ToString("00000000000000") != num_cpf_cnpj) {
                            lblMsg.Text = "CNPJ informado não pertence a este documento.";
                            return;
                        }
                    }
                }
            }

            List<DebitoStructure>ListaParcelas= Carregaparcelas(nNumDoc,dDataDoc);
            int nSid = tributario_Class.Insert_Boleto_DAM(ListaParcelas,nNumDoc, dDataDoc);
            printCarne(nSid);
        }

        private List<DebitoStructure> Carregaparcelas(int nNumDoc,DateTime dDataDoc) {
            int i = 0;
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            List<DebitoStructure> ListaParcelas = tributario_Class.Lista_Tabela_Parcela_Documento(    nNumDoc);
            foreach (DebitoStructure Linha in ListaParcelas) {
                List<SpExtrato> ListaTributo = tributario_Class.Lista_Extrato_Tributo(Linha.Codigo_Reduzido, (short)Linha.Ano_Exercicio, (short)Linha.Ano_Exercicio, (short)Linha.Codigo_Lancamento, (short)Linha.Codigo_Lancamento,
                    (short)Linha.Sequencia_Lancamento, (short)Linha.Sequencia_Lancamento, (short)Linha.Numero_Parcela, (short)Linha.Numero_Parcela, Linha.Complemento, Linha.Complemento, 0, 99, dDataDoc, "Web");
                List<SpExtrato> ListaParcela = tributario_Class.Lista_Extrato_Parcela(ListaTributo);

                for (i = 0; i < ListaParcelas.Count; i++) {
                    if (ListaParcelas[i].Ano_Exercicio == Linha.Ano_Exercicio & ListaParcelas[i].Codigo_Lancamento == Linha.Codigo_Lancamento & ListaParcelas[i].Sequencia_Lancamento == Linha.Sequencia_Lancamento &
                        ListaParcelas[i].Numero_Parcela == Linha.Numero_Parcela & ListaParcelas[i].Complemento == Linha.Complemento)
                        break;
                }
                ListaParcelas[i].Soma_Principal = ListaParcela[0].Valortributo;
                ListaParcelas[i].Soma_Multa = ListaParcela[0].Valormulta;
                ListaParcelas[i].Soma_Juros = ListaParcela[0].Valorjuros;
                ListaParcelas[i].Soma_Correcao = ListaParcela[0].Valorcorrecao;
                ListaParcelas[i].Soma_Total = ListaParcela[0].Valortotal;
                ListaParcelas[i].Descricao_Lancamento = ListaParcela[0].Desclancamento;
                string DescTributo = "";

                List<int> aTributos = new List<int>();
                foreach (SpExtrato Trib in ListaTributo) {
                    bool bFind = false;
                    for (int b = 0; b < aTributos.Count; b++) {
                        if (aTributos[b] == Trib.Codtributo) {
                            bFind = true;
                            break;
                        }
                    }
                    if (!bFind)
                        aTributos.Add(Trib.Codtributo);
                }

                for (int c = 0; c < aTributos.Count; c++)
                    DescTributo += aTributos[c].ToString("000") + "-" + tributario_Class.Lista_Tributo(aTributos[c])[0].Abrevtributo + ",";

                DescTributo = DescTributo.Substring(0, DescTributo.Length - 1);
                ListaParcelas[i].Descricao_Tributo = DescTributo;
                ListaParcelas[i].Data_Vencimento = ListaParcela[0].Datavencimento;
            }

            return ListaParcelas;

        }

        private void printCarne(int nSid) {
            lblMsg.Text = "";
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            Session["sid"] = "";
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            List<Boleto> ListaBoleto = tributario_Class.Lista_Boleto_DAM(nSid);
            DataSet Ds = gtiCore.ToDataSet(ListaBoleto);
            ReportDataSource rdsAct = new ReportDataSource("dsDam", Ds.Tables[0]);
            ReportViewer viewer = new ReportViewer();
            viewer.LocalReport.Refresh();
            viewer.LocalReport.ReportPath = Server.MapPath("~/Report/rptDetalheBoleto.rdlc");
            viewer.LocalReport.DataSources.Add(rdsAct); // Add  datasource here         
            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            tributario_Class.Excluir_Carne(nSid);
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