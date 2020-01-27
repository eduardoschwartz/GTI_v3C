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
using System.Data;

namespace GTI_Web.Pages {
    public partial class situacao_pagto : System.Web.UI.Page {

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

        protected void Submit_Click(object sender, EventArgs e) {

        }

        protected void txtCPF_TextChanged(object sender, EventArgs e) {
            lblMsg.Text = "";
        }

        protected void txtCNPJ_TextChanged(object sender, EventArgs e) {
            lblMsg.Text = "";
        }

        protected void VerificarButton_Click(object sender, EventArgs e) {
            string sCPF = txtCPF.Text, sCNPJ = txtCNPJ.Text, num_cpf_cnpj="",sNome="",sAtividade="";
            int _codigo = 0;

            bool isNum = Int32.TryParse(Codigo.Text, out _codigo);
            if (!isNum) {
                lblMsg.Text = "Código de contribuinte inválido!";
            } else {
                if (_codigo < 100000 || _codigo >= 300000) {
                    lblMsg.Text = "Código de contribuinte inválido!";
                } else {
                    if (txtimgcode.Text != Session["randomStr"].ToString())
                        lblMsg.Text = "Código da imagem inválido";
                    else {
                        if (sCPF == "" && sCNPJ == "")
                            lblMsg.Text = "Digite o CPF/CNPJ da empresa.";
                        else {
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

                            Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
                            bool bFind = empresa_Class.Existe_Empresa(_codigo);
                            if (bFind) {
                                EmpresaStruct reg = empresa_Class.Retorna_Empresa(_codigo);
                                if (optCPF.Checked) {
                                    if (Convert.ToInt64(gtiCore.RetornaNumero(reg.Cpf_cnpj)).ToString("00000000000") != num_cpf_cnpj) {
                                        lblMsg.Text = "CPF não pertence ao proprietário deste imóvel!";
                                        return;
                                    }
                                } else {
                                    if (Convert.ToInt64(gtiCore.RetornaNumero(reg.Cpf_cnpj)).ToString("00000000000000") != num_cpf_cnpj) {
                                        lblMsg.Text = "CNPJ não pertence ao proprietário deste imóvel!";
                                        return;
                                    }
                                }
                                sNome = reg.Razao_social;
                                sAtividade = reg.Atividade_extenso;
                            } else {
                                lblMsg.Text = "Inscrição Municipal não cadastrada!";
                                return;
                            }

                            //se chegou até aqui então a empresa esta ok para verificar os débitos
                            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
                            List<SpExtrato> ListaTributo = tributario_Class.Lista_Extrato_Tributo(_codigo,(short) DateTime.Now.Year, (short)DateTime.Now.Year, 0, 99, 0, 99, 0, 999, 0, 99, 0, 99, DateTime.Now,  "Web");
                            List<SpExtrato> ListaParcela = tributario_Class.Lista_Extrato_Parcela(ListaTributo);

                            DataSets.dsSituacaoPagto set1 = new DataSets.dsSituacaoPagto(); ;
                            int nSid = gtiCore.GetRandomNumber();
                            if (ListaParcela.Count == 0) {
                                lblMsg.Text = "Não existem débitos de ISS Fixo,Taxa de Licença e Vig.Sanitária para o ano atual.";
                                return;
                            }


                            foreach (SpExtrato item in ListaParcela) {
                                if (item.Codlancamento == 2 || item.Codlancamento == 6 || item.Codlancamento == 13 || item.Codlancamento == 14) {
                                    if (item.Numparcela > 0 && item.Statuslanc == 1) goto Proximo;
                                    if (item.Numparcela == 0 && item.Statuslanc != 1) goto Proximo;
                                    DataRow row = set1.Tables["dtSituacaoPagto"].NewRow();
                                    row["sid"] = nSid ;
                                    row["ano"] = item.Anoexercicio;
                                    row["lancamento"] = item.Codlancamento;
                                    row["seq"] = item.Seqlancamento;
                                    row["parcela"] = item.Numparcela;
                                    row["complemento"] = item.Codcomplemento;
                                    row["valor_pago"] = 0;
                                    if (item.Datapagamento != null) {
                                        row["data_pagamento"] = item.Datapagamento;
                                        row["valor_pago"] = item.Valorpagoreal;
                                    }
                                    row["data_vencimento"] = item.Datavencimento;
                                    row["descricao"] = item.Desclancamento;
                                    row["situacao"] = item.Situacao;
                                    set1.Tables["dtSituacaoPagto"].Rows.Add(row);
                                }
                                Proximo:;
                            }

                            int _numero_certidao = tributario_Class.Retorna_Codigo_Certidao(modelCore.TipoCertidao.Comprovante_Pagamento);
                            int _ano_certidao = DateTime.Now.Year;

                            ReportDocument crystalReport = new ReportDocument();

                            crystalReport.Load(Server.MapPath("~/Report/SituacaoPagamento.rpt"));
                            crystalReport.SetDataSource(set1);
                            crystalReport.SetParameterValue("NUMCOMPROVANTE", _numero_certidao.ToString("00000") + "/" + _ano_certidao.ToString("0000"));
                            crystalReport.SetParameterValue("DATAEMISSAO", DateTime.Now.ToString("dd/MM/yyyy") + " às " + DateTime.Now.ToString("HH:mm:ss"));
                            crystalReport.SetParameterValue("CONTROLE", _numero_certidao.ToString("00000") + _ano_certidao.ToString("0000") + "/" + _codigo.ToString() + "-PG");
                            crystalReport.SetParameterValue("CADASTRO", _codigo.ToString("000000"));
                            crystalReport.SetParameterValue("NOME", sNome);
                            crystalReport.SetParameterValue("CPFCNPJ", num_cpf_cnpj);
                            crystalReport.SetParameterValue("ATIVIDADE", sAtividade);
                            crystalReport.RecordSelectionFormula = "{dtSituacaoPagto.sid}=" + nSid;
                            

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
                }
            }
        }
    }
}

