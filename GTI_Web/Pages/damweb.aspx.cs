using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using GTI_Bll.Classes;
using GTI_Models.Models;

namespace UIWeb.Pages {
    public partial class damweb : System.Web.UI.Page {
        static bool bGerado;
        private bool bRefis;
        int nPlano = 0;


        protected void Page_Load(object sender, EventArgs e) {
            DateTime DataDAM;
            if (!IsPostBack) {
                bGerado = false;
                ShowResult(false);
                String s = Request.QueryString["d"];
                try {
                    lblVenctoDam.Text = gtiCore.Decrypt(s);
                } catch (Exception) {

                    Response.Redirect("~/Pages/gtiMenu.aspx");
                }

                if (!DateTime.TryParse(lblVenctoDam.Text, out DataDAM)) {
                    Response.Redirect("~/Pages/gtiMenu.aspx");
                } else {
                    String sDataVencto = lblVenctoDam.Text;
                    String sDataNow = DateTime.Now.ToString("dd/MM/yyyy");
                    if (DateTime.ParseExact(sDataVencto, "dd/MM/yyyy", null) < DateTime.ParseExact(sDataNow, "dd/MM/yyyy", null)) {
                        Response.Redirect("~/Pages/gtiMenu.aspx");
                    } else {
                        Int32 DifDias = ((TimeSpan)(DataDAM - DateTime.Now)).Days;
                        if (DifDias > 30) {
                            Response.Redirect("~/Pages/gtiMenu.aspx");
                        } 
                    }
                }

                lblMsg2.Text = "";
            }
        }

        protected void txtCod_TextChanged(object sender, EventArgs e) {
            ShowResult(false);
        }

        protected void btSelectAll_Click(object sender, EventArgs e) {
            bool isNum;
            decimal nSomaPrincipal = 0;
            decimal nSomaJuros = 0;
            decimal nSomaMulta = 0;
            decimal nSomaCorrecao = 0;
            decimal nSomaTotal = 0;
            decimal Num = 0;
            foreach (GridViewRow r in grdMain.Rows) {
                (r.FindControl("chkRow") as CheckBox).Checked = true;
                isNum = decimal.TryParse(r.Cells[7].Text, out Num);
                nSomaPrincipal += Num;
                isNum = decimal.TryParse(r.Cells[8].Text, out Num);
                nSomaJuros += Num;
                isNum = decimal.TryParse(r.Cells[9].Text, out Num);
                nSomaMulta += Num;
                isNum = decimal.TryParse(r.Cells[10].Text, out Num);
                nSomaCorrecao += Num;
                isNum = decimal.TryParse(r.Cells[11].Text, out Num);
                nSomaTotal += Num;
            }
            TableTotal.Rows[2].Cells[2].Text = nSomaPrincipal.ToString("#0.00");
            TableTotal.Rows[2].Cells[3].Text = nSomaMulta.ToString("#0.00");
            TableTotal.Rows[2].Cells[4].Text = nSomaJuros.ToString("#0.00");
            TableTotal.Rows[2].Cells[5].Text = nSomaCorrecao.ToString("#0.00");
            TableTotal.Rows[2].Cells[6].Text = nSomaTotal.ToString("#0.00");
            TableResumo.Rows[0].Cells[1].Text = (nSomaTotal).ToString("#0.00");
        }

        protected void chkRow_CheckedChanged(object sender, EventArgs e) {
            bool isNum;
            decimal nSomaPrincipal = 0;
            decimal nSomaJuros = 0;
            decimal nSomaMulta = 0;
            decimal nSomaCorrecao = 0;
            decimal nSomaTotal = 0;
            decimal Num = 0;

            CheckBox chk = (sender as CheckBox);
            GridView gv = chk.NamingContainer.Parent.Parent as GridView;
            foreach (GridViewRow row in gv.Rows) {
                if (row.RowType == DataControlRowType.DataRow) {
                    if ((row.FindControl("chkRow") as CheckBox).Checked) {
                        isNum = decimal.TryParse(row.Cells[7].Text, out Num);
                        nSomaPrincipal += Num;
                        isNum = decimal.TryParse(row.Cells[8].Text, out Num);
                        nSomaJuros += Num;
                        isNum = decimal.TryParse(row.Cells[9].Text, out Num);
                        nSomaMulta += Num;
                        isNum = decimal.TryParse(row.Cells[10].Text, out Num);
                        nSomaCorrecao += Num;
                        isNum = decimal.TryParse(row.Cells[11].Text, out Num);
                        nSomaTotal += Num;
                    }
                }
            }

            TableTotal.Rows[2].Cells[2].Text = nSomaPrincipal.ToString("#0.00");
            TableTotal.Rows[2].Cells[3].Text = nSomaMulta.ToString("#0.00");
            TableTotal.Rows[2].Cells[4].Text = nSomaJuros.ToString("#0.00");
            TableTotal.Rows[2].Cells[5].Text = nSomaCorrecao.ToString("#0.00");
            TableTotal.Rows[2].Cells[6].Text = nSomaTotal.ToString("#0.00");
            TableResumo.Rows[0].Cells[1].Text = (nSomaTotal).ToString("#0.00");
        }

        protected void btSelectNone_Click(object sender, EventArgs e) {
            foreach (GridViewRow r in grdMain.Rows)
                (r.FindControl("chkRow") as CheckBox).Checked = false;
            TableTotal.Rows[2].Cells[2].Text = "0,00";
            TableTotal.Rows[2].Cells[3].Text = "0,00";
            TableTotal.Rows[2].Cells[4].Text = "0,00";
            TableTotal.Rows[2].Cells[5].Text = "0,00";
            TableTotal.Rows[2].Cells[6].Text = "0,00";
            TableResumo.Rows[0].Cells[1].Text = "0,00";
        }

        protected void optList_SelectedIndexChanged(object sender, EventArgs e) {
            if (optList.Items[0].Selected == true) {
                lblCod.Text = "Código do imóvel..:";
                txtCod.Width = 70;
            } else if (optList.Items[1].Selected == true) {
                lblCod.Text = "Inscrição Municipal...";
                txtCod.Width = 70;
            } else if (optList.Items[2].Selected == true) {
                lblCod.Text = "Código cidadão...";
                txtCod.Width = 120;
            }
            ShowResult(false);
        }

        private void ShowResult(bool bShow) {
            TableTotal.Rows[1].Cells[2].Text = "0,00";
            TableTotal.Rows[1].Cells[3].Text = "0,00";
            TableTotal.Rows[1].Cells[4].Text = "0,00";
            TableTotal.Rows[1].Cells[5].Text = "0,00";
            TableTotal.Rows[1].Cells[6].Text = "0,00";
            TableTotal.Rows[2].Cells[2].Text = "0,00";
            TableTotal.Rows[2].Cells[3].Text = "0,00";
            TableTotal.Rows[2].Cells[4].Text = "0,00";
            TableTotal.Rows[2].Cells[5].Text = "0,00";
            TableTotal.Rows[2].Cells[6].Text = "0,00";
            TableResumo.Rows[0].Cells[1].Text = "0,00";
            pnlTotal.Visible = bShow;
            Pnlresumo.Visible = bShow;
            btPrint.Visible = bShow;
            btSelectAll.Visible = bShow;
            btSelectNone.Visible = bShow;
            if (!bShow) {
                grdMain.DataSource = null;
                grdMain.DataBind();
                lblNome.Text = "";
                lblDoc.Text = "";
                lblEndereco.Text = "";
                lblValidate.Text = "";

            }
        }

        protected void btConsultar_Click(object sender, ImageClickEventArgs e) {
            bool isNum = false;
            int Num = 0;
            decimal nSomaPrincipal = 0;
            decimal nSomaJuros = 0;
            decimal nSomaMulta = 0;
            decimal nSomaCorrecao = 0;
            decimal nSomaTotal = 0;
            string num_cpf_cnpj = "";
            DateTime DataDAM;

            bGerado = false;
            String sTextoImagem = txtimgcode.Text;
            txtimgcode.Text = "";

            lblmsg.Text = "";
            lblMsg2.Text = "";
            lblNome.Text = "";
            lblDoc.Text = "";
            lblEndereco.Text = "";
            lblValidate.Text = "";


            if (optCPF.Checked && gtiCore.RetornaNumero( txtCPF.Text).Length < 11) {
                lblmsg.Text = "CPF inválido!";
                ShowResult(false);
                return;
            }
            if (optCNPJ.Checked && txtCNPJ.Text.Length < 18) {
                lblmsg.Text = "CNPJ inválido!";
                ShowResult(false);
                return;
            }

            if (optCPF.Checked) {
                num_cpf_cnpj = gtiCore.RetornaNumero(txtCPF.Text);
                if (!gtiCore.ValidaCpf(num_cpf_cnpj)) {
                    lblmsg.Text = "CPF inválido!";
                    ShowResult(false);
                    return;
                }
            } else {
                num_cpf_cnpj = gtiCore.RetornaNumero(txtCNPJ.Text);
                if (!gtiCore.ValidaCNPJ(num_cpf_cnpj)) {
                    lblmsg.Text = "CNPJ inválido!";
                    ShowResult(false);
                    return;
                }
            }


            if (optList.Items[0].Selected == true) {

                isNum = int.TryParse(txtCod.Text, out Num);
                if (!isNum) {
                    lblmsg.Text = "Código do imóvel inválido!";
                    ShowResult(false);
                    return;
                } else {
                    Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
                    bool bFind = imovel_Class.Existe_Imovel(Num);
                    if (bFind) {
                        ImovelStruct reg = imovel_Class.Dados_Imovel(Num);
                        List<ProprietarioStruct> regProp = imovel_Class.Lista_Proprietario(Num, true);

                        lblEndereco.Text = reg.NomeLogradouro + ", " + reg.Numero + " " + reg.Complemento;
                        lblDoc.Text = reg.NomeBairro;
                        lblNome.Text = regProp[0].Nome;
                        if (optCPF.Checked) {
                            if (Convert.ToInt64(gtiCore.RetornaNumero(regProp[0].CPF)).ToString("00000000000") != num_cpf_cnpj) {
                                lblmsg.Text = "CPF não pertence ao proprietário deste imóvel!";
                                ShowResult(false);
                                return;
                            }
                        } else {
                            if (Convert.ToInt64(gtiCore.RetornaNumero(regProp[0].CPF)).ToString("00000000000000") != num_cpf_cnpj) {
                                lblmsg.Text = "CNPJ não pertence ao proprietário deste imóvel!";
                                ShowResult(false);
                                return;
                            }
                        }
                    } else {
                        lblmsg.Text = "Código do imóvel não cadastrado!";
                        ShowResult(false);
                        return;
                    }
                }
            } else {
                if (optList.Items[1].Selected == true) {
                    isNum = Int32.TryParse(txtCod.Text, out Num);
                    if (!isNum) {
                        lblmsg.Text = "Código da empresa inválido!";
                        ShowResult(false);
                        return;
                    } else {
                        Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
                        bool bFind = empresa_Class.Existe_Empresa(Num);
                        if (bFind) {
                            EmpresaStruct reg = empresa_Class.Retorna_Empresa(Num);
                            lblEndereco.Text = reg.Endereco_nome + ", " + reg.Numero + " " + reg.Complemento;
                            lblDoc.Text = reg.Bairro_nome;
                            lblNome.Text = reg.Razao_social;

                            if (optCPF.Checked) {
                                if (Convert.ToInt64(gtiCore.RetornaNumero(reg.Cpf_cnpj)).ToString("00000000000") != num_cpf_cnpj) {
                                    lblmsg.Text = "CPF não pertence ao proprietário deste imóvel!";
                                    ShowResult(false);
                                    return;
                                }
                            } else {
                                if (Convert.ToInt64(gtiCore.RetornaNumero(reg.Cpf_cnpj)).ToString("00000000000000") != num_cpf_cnpj) {
                                    lblmsg.Text = "CNPJ não pertence ao proprietário deste imóvel!";
                                    ShowResult(false);
                                    return;
                                }
                            }
                        } else {
                            lblmsg.Text = "Inscrição Municipal não cadastrada!";
                            ShowResult(false);
                            return;
                        }
                    }
                } else {
                    if (optList.Items[2].Selected == true) {
                        isNum = Int32.TryParse(txtCod.Text, out Num);
                        if (!isNum) {
                            lblmsg.Text = "Código de contribuinte inválido!";
                            ShowResult(false);
                            return;
                        } else {
                            if (Num < 500000 || Num > 700000) {
                                lblmsg.Text = "Código de contribuinte inválido!";
                                ShowResult(false);
                                return;
                            } else {
                                Cidadao_bll cidadao_Class = new Cidadao_bll("GTIconnection");
                                bool bFind = cidadao_Class.ExisteCidadao(Num);
                                if (bFind) {
                                    CidadaoStruct reg = cidadao_Class.LoadReg(Num);
                                    if (reg.EtiquetaR != null && reg.EtiquetaR == "S") {
                                        lblEndereco.Text = reg.EnderecoR + ", " + reg.NumeroR + " " + reg.ComplementoR;
                                        lblDoc.Text = reg.NomeBairroR;

                                    } else {
                                        lblEndereco.Text = reg.EnderecoC + ", " + reg.NumeroC + " " + reg.ComplementoC;
                                        lblDoc.Text = reg.NomeBairroC;
                                    }
                                    lblNome.Text = reg.Nome;

                                    if (optCPF.Checked) {
                                        if (Convert.ToInt64(gtiCore.RetornaNumero(reg.Cpf)).ToString("00000000000") != num_cpf_cnpj) {
                                            lblmsg.Text = "CPF não pertence ao proprietário deste imóvel!";
                                            ShowResult(false);
                                            return;
                                        }
                                    } else {
                                        if (Convert.ToInt64(gtiCore.RetornaNumero(reg.Cnpj)).ToString("00000000000000") != num_cpf_cnpj) {
                                            lblmsg.Text = "CNPJ não pertence ao proprietário deste imóvel!";
                                            ShowResult(false);
                                            return;
                                        }
                                    }

                                } else {
                                    lblmsg.Text = "Contribuinte não cadastrado!";
                                    ShowResult(false);
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            if (!DateTime.TryParse(lblVenctoDam.Text, out DataDAM)) {
                lblmsg.Text = "Data de vencimento inválida.";
                ShowResult(false);
                return;
            } else {
                String sDataVencto = lblVenctoDam.Text;
                String sDataNow = DateTime.Now.ToString("dd/MM/yyyy");
                if (DateTime.ParseExact(sDataVencto, "dd/MM/yyyy", null) < DateTime.ParseExact(sDataNow, "dd/MM/yyyy", null)) {
                    lblmsg.Text = "Vencimento menor que a data atual.";
                    ShowResult(false);
                    return;
                } else {
                    Int32 DifDias = ((TimeSpan)(DataDAM - DateTime.Now)).Days;
                    if (DifDias > 30) {
                        lblmsg.Text = "Vencimento máximo de 30 dias.";
                        ShowResult(false);
                        return;
                    }
                }
            }

            if (txtimgcode.Text == Session["randomStr"].ToString()) {
                lblmsg.Text = "Código da imagem inválido.";
                ShowResult(false);
                return;
            } else {
                ShowResult(true);
                lblmsg.Text = "";
                lblMsg2.Text = "";
            }

            this.txtimgcode.Text = "";

            String sDataDAM = DataDAM.ToString("dd/MM/yyyy");
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            bRefis = tributario_Class.IsRefis();
            List<SpExtrato> ListaTributo = tributario_Class.Lista_Extrato_Tributo(Num, 1980, 2050,  0, 99, 0, 99, 0, 999, 0, 99, 0, 99, DateTime.ParseExact(sDataDAM, "dd/MM/yyyy", null), "Web");
            List<SpExtrato> ListaParcela = tributario_Class.Lista_Extrato_Parcela(ListaTributo);
            List<DebitoStructure> debitos2 = new List<DebitoStructure>();

            Decimal nPerc = 0;
            
            int nIndex = 0;
            if (bRefis) {
                foreach (var item in ListaParcela) {
                    if (Convert.ToDateTime(item.Datavencimento) <= Convert.ToDateTime("30/06/2019")) {
                        Int16 CodLanc = item.Codlancamento;
                        if (CodLanc != 48 || CodLanc != 69 || CodLanc != 78) {

                            if (Convert.ToDateTime(sDataDAM) <= Convert.ToDateTime("18/10/2019")) {
                                nPerc = 1M;
                                nPlano = 33;
                            } else if (Convert.ToDateTime(sDataDAM) > Convert.ToDateTime("18/10/2019") && Convert.ToDateTime(sDataDAM) <= Convert.ToDateTime("29/11/2019")) {
                                nPerc = 0.9M;
                                nPlano = 34;
                            } else if (Convert.ToDateTime(sDataDAM) > Convert.ToDateTime("29/11/2019") && Convert.ToDateTime(sDataDAM) <= Convert.ToDateTime("20/12/2019")) {
                                nPerc = 0.8M;
                                nPlano = 35;
                            }
                            if (nPlano > 0) {
                                item.Valorjuros = Convert.ToDecimal(item.Valorjuros) - (Convert.ToDecimal(item.Valorjuros) * nPerc);
                                item.Valormulta = Convert.ToDecimal(item.Valormulta) - (Convert.ToDecimal(item.Valormulta) * nPerc);
                                item.Valortotal = item.Valortributo + item.Valorjuros + item.Valormulta + item.Valorcorrecao;
                            }
                            ListaParcela[nIndex].Valorjuros = item.Valorjuros;
                            ListaParcela[nIndex].Valormulta = item.Valormulta;
                            ListaParcela[nIndex].Valortotal = item.Valortotal;
                        }
                    }
                    nIndex++;
                }
            }

            PlanoLabel.Text = nPlano.ToString();
            foreach (var item in ListaParcela) {
                if (item.Statuslanc == 3 || item.Statuslanc == 19 || item.Statuslanc == 38 || item.Statuslanc == 39 || item.Statuslanc == 42 || item.Statuslanc == 43) {
                    //if (item.Codlancamento != 16 && item.Codlancamento != 38) {
                        DebitoStructure reg = new DebitoStructure();
                        reg.Codigo_Reduzido = item.Codreduzido;
                        reg.Ano_Exercicio = item.Anoexercicio;
                        reg.Codigo_Lancamento = Convert.ToInt16(item.Codlancamento);
                        reg.Descricao_Lancamento = item.Desclancamento;
                        reg.Sequencia_Lancamento = Convert.ToInt16(item.Seqlancamento);
                        reg.Numero_Parcela = Convert.ToInt16(item.Numparcela);
                        reg.Complemento = item.Codcomplemento;
                        reg.Data_Vencimento = Convert.ToDateTime(item.Datavencimento);
                        reg.Codigo_Situacao = Convert.ToInt16(item.Statuslanc);
                        reg.Soma_Principal = item.Valortributo;
                        reg.Soma_Juros = item.Valorjuros;
                        reg.Soma_Multa = item.Valormulta;
                        reg.Soma_Correcao = item.Valorcorrecao;
                        reg.Soma_Total = item.Valortotal;
                        reg.Data_Ajuizamento = item.Dataajuiza;
                        debitos2.Add(reg);
                  //  }
                }
            }

            if (debitos2.Count == 0) {
                lblDoc.Text = "";
                lblmsg.Text = "Não existem débitos.";
                ShowResult(false);
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[13] { new DataColumn("Exercicio"), new DataColumn("Lancamento"), new DataColumn("Sequencia"),
                                new DataColumn("Parcela"),new DataColumn("Complemento"),new DataColumn("DtVencimento"),new DataColumn("VlPrincipal"),
                                new DataColumn("VlJuros"),new DataColumn("VlMulta"),new DataColumn("VlCorrecao"),new DataColumn("VlTotal"),new DataColumn("DtAjuiza"),new DataColumn("Protesto")});

            foreach (var item in debitos2) {
                dt.Rows.Add(item.Ano_Exercicio.ToString(), item.Codigo_Lancamento.ToString("000") + "-" + item.Descricao_Lancamento.ToString(), item.Sequencia_Lancamento.ToString(),
                            item.Numero_Parcela.ToString(), item.Complemento.ToString(), Convert.ToDateTime(item.Data_Vencimento).ToString("dd/MM/yyyy"),
                            item.Soma_Principal.ToString("#0.00"), item.Soma_Juros.ToString("#0.00"), item.Soma_Multa.ToString("#0.00"),
                            item.Soma_Correcao.ToString("#0.00"), item.Soma_Total.ToString("#0.00"), item.Data_Ajuizamento == DateTime.MinValue || item.Data_Ajuizamento==null? "NÃO" : "SIM", item.Codigo_Situacao ==38| item.Codigo_Situacao == 39 ? "SIM" : "NÃO");
                nSomaPrincipal += item.Soma_Principal;
                nSomaJuros += item.Soma_Juros;
                nSomaMulta += item.Soma_Multa;
                nSomaCorrecao += item.Soma_Correcao;
                nSomaTotal += item.Soma_Total;
            }

            grdMain.DataSource = dt;
            grdMain.DataBind();

            TableTotal.Rows[1].Cells[2].Text = nSomaPrincipal.ToString("#0.00");
            TableTotal.Rows[1].Cells[3].Text = nSomaMulta.ToString("#0.00");
            TableTotal.Rows[1].Cells[4].Text = nSomaJuros.ToString("#0.00");
            TableTotal.Rows[1].Cells[5].Text = nSomaCorrecao.ToString("#0.00");
            TableTotal.Rows[1].Cells[6].Text = nSomaTotal.ToString("#0.00");

            TableTotal.Rows[2].Cells[2].Text = "0,00";
            TableTotal.Rows[2].Cells[3].Text = "0,00";
            TableTotal.Rows[2].Cells[4].Text = "0,00";
            TableTotal.Rows[2].Cells[5].Text = "0,00";
            TableTotal.Rows[2].Cells[6].Text = "0,00";
            TableResumo.Rows[0].Cells[1].Text = "0,00";
            TableResumo.Rows[1].Cells[1].Text = lblVenctoDam.Text;
        }

        protected void btPrint_Click(object sender, EventArgs e) {
            bool bParcUnica = false;
            bool bParcNormal = false;
            bool bAnoAtual = false;
            bool bAnoAnterior = false;
            bool bFind = false;
            decimal _valor_ajuizado = 0, _valor_Honorario = 0;

            divModal.Visible = false;
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            bRefis = tributario_Class.IsRefis();
            nPlano = Convert.ToInt32(PlanoLabel.Text);
            lblmsg.Text = "";
            lblMsg2.Text = "";
            if (bGerado) {
                ShowResult(false);
                Response.Write("<script>alert('A guia já foi gerada!');</script>");
                return;
            }

            if (TableResumo.Rows[0].Cells[1].Text == "0,00")
                lblMsg2.Text = "Selecione os débitos que deseja pagar.";
            else {
                foreach (GridViewRow row in grdMain.Rows) {
                    if (row.RowType == DataControlRowType.DataRow) {

                        if ((row.FindControl("chkRow") as CheckBox).Checked) {
                            if (Convert.ToInt16(row.Cells[4].Text) == 0)
                                bParcUnica = true;
                            if (Convert.ToInt16(row.Cells[4].Text) != 0)
                                bParcNormal = true;

                            if (Convert.ToDateTime(row.Cells[6].Text) <= Convert.ToDateTime("30/06/2019") )
                                bAnoAnterior = true;
                            if (Convert.ToDateTime(row.Cells[6].Text) > Convert.ToDateTime("30/06/2019") )
                                bAnoAtual = true;

                            if (Convert.ToInt16(row.Cells[2].Text.Substring(0, 3)) == 5) {
                                if (Convert.ToDateTime(row.Cells[6].Text) > Convert.ToDateTime("05/01/2015") && !bRefis) {
                                    bGerado = false;
                                    lblMsg2.Text = "ISS Variável com vencimento após 01/05/2015 não pode ser pago por DAM.";
                                    return;
                                }
                            } else {
                                if (row.Cells[12].Text == "SIM" || row.Cells[13].Text == "SIM") {
                                    bFind = true;
                                    _valor_ajuizado += Convert.ToDecimal(row.Cells[11].Text);
                                }
                            }
                        }
                    }
                }
            }

            if (bFind) {
                _valor_Honorario = (_valor_ajuizado * (decimal)0.1);
            }

            if (bRefis) {
                if (bAnoAnterior && bAnoAtual) {
                    bGerado = false;
                    nPlano = 0;
                    //lblMsg2.Text = "Não é possível pagar débitos de 2017 com outros anos pelo Refis.";
                    lblMsg2.Text = "Não é possível pagar débitos anteriores a 30/06/2019 com débitos posteriores durante Refis. ";
                    lblMsg2.Text += "Será necessário emitir dois boletos um contendo apenas os débitos com vencimento anterior à 30/06/2018 e depois outro com débitos posteriores as esta data.";
                    return;
                }
                if (!bAnoAnterior && bAnoAtual) {
                    nPlano = 0;
                }

            }

            if (bParcUnica && bParcNormal) {
                lblMsg2.Text = "Parcela ùnica não pode ser paga junto com outras parcelas.";
            } else {
                  GeraGuia(_valor_Honorario);
            }
                
        }

        private void GeraGuia(decimal Valor_Honorario) {
            decimal tmpNumber = 0;
            bGerado = true;
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            List<DebitoStructure> lstExtrato = new List<DebitoStructure>();
            DebitoStructure reg = null;
            String DescTributo = "";
            foreach (GridViewRow row in grdMain.Rows) {
                if (row.RowType == DataControlRowType.DataRow) {
                    if ((row.FindControl("chkRow") as CheckBox).Checked) {
                        reg = new DebitoStructure();
                        reg.Codigo_Reduzido = Convert.ToInt32(txtCod.Text);
                        reg.Ano_Exercicio = Convert.ToInt32(row.Cells[1].Text);
                        reg.Codigo_Lancamento = Convert.ToInt16(row.Cells[2].Text.Substring(0, 3));
                        reg.Sequencia_Lancamento = Convert.ToInt16(row.Cells[3].Text);
                        reg.Numero_Parcela = Convert.ToInt16(row.Cells[4].Text);
                        reg.Complemento = Convert.ToInt16(row.Cells[5].Text);
                        reg.Descricao_Lancamento = row.Cells[2].Text.Substring(4, row.Cells[2].Text.ToString().Length - 4);
                        reg.Data_Vencimento = Convert.ToDateTime(row.Cells[6].Text);
                        decimal.TryParse(row.Cells[7].Text, out tmpNumber);
                        reg.Soma_Principal = tmpNumber;
                        decimal.TryParse(row.Cells[8].Text, out tmpNumber);
                        reg.Soma_Juros = tmpNumber;
                        decimal.TryParse(row.Cells[9].Text, out tmpNumber);
                        reg.Soma_Multa = tmpNumber;
                        decimal.TryParse(row.Cells[10].Text, out tmpNumber);
                        reg.Soma_Correcao = tmpNumber;
                        decimal.TryParse(row.Cells[11].Text, out tmpNumber);
                        reg.Soma_Total = tmpNumber;

                        List<SpExtrato> ListaTributo = tributario_Class.Lista_Extrato_Tributo(reg.Codigo_Reduzido, Convert.ToInt16(reg.Ano_Exercicio), Convert.ToInt16(reg.Ano_Exercicio), Convert.ToInt16(reg.Codigo_Lancamento), Convert.ToInt16(reg.Codigo_Lancamento), Convert.ToInt16(reg.Sequencia_Lancamento), Convert.ToInt16(reg.Sequencia_Lancamento),
                            Convert.ToInt16(reg.Numero_Parcela), Convert.ToInt16(reg.Numero_Parcela), reg.Complemento, reg.Complemento, 0, 99, Convert.ToDateTime(reg.Data_Vencimento), "Web");

                        List<int> aTributos = new List<int>();
                        foreach (SpExtrato Trib in ListaTributo) {
                            bool bFind = false;
                            for (int i = 0; i < aTributos.Count; i++) {
                                if (aTributos[i] == Trib.Codtributo) {
                                    bFind = true;
                                    break;
                                }
                            }
                            if (!bFind)
                                aTributos.Add(Trib.Codtributo);
                        }

                        for (int i = 0; i < aTributos.Count; i++)
                            DescTributo += aTributos[i].ToString("000") + "-" + tributario_Class.Lista_Tributo(aTributos[i])[0].Abrevtributo + ","; ;

                        DescTributo = DescTributo.Substring(0, DescTributo.Length - 1);
                        reg.Descricao_Tributo = DescTributo;
                        lstExtrato.Add(reg);
                    }

                }
            }

            if (Valor_Honorario > 0) {
                int _codigo = Convert.ToInt32(txtCod.Text);
                int _seq = tributario_Class.Retorna_Ultima_Seq_Honorario(_codigo, DateTime.Now.Year);
                _seq++;
                reg = new DebitoStructure();
                reg.Codigo_Reduzido = _codigo;
                reg.Ano_Exercicio = DateTime.Now.Year;
                reg.Codigo_Lancamento = 41;
                reg.Sequencia_Lancamento = _seq;
                reg.Numero_Parcela = 1;
                reg.Complemento = 0;
                reg.Descricao_Lancamento = "41-DESPESAS JUDICIAIS";
                reg.Data_Vencimento = Convert.ToDateTime(lblVenctoDam.Text);
                reg.Soma_Principal = Valor_Honorario;
                reg.Soma_Juros = 0;
                reg.Soma_Multa = 0;
                reg.Soma_Correcao = 0;
                reg.Soma_Total = Valor_Honorario;

                List<SpExtrato> ListaTributo = tributario_Class.Lista_Extrato_Tributo(reg.Codigo_Reduzido, Convert.ToInt16(reg.Ano_Exercicio), Convert.ToInt16(reg.Ano_Exercicio), Convert.ToInt16(reg.Codigo_Lancamento), Convert.ToInt16(reg.Codigo_Lancamento), Convert.ToInt16(reg.Sequencia_Lancamento), Convert.ToInt16(reg.Sequencia_Lancamento),
                Convert.ToInt16(reg.Numero_Parcela), Convert.ToInt16(reg.Numero_Parcela), reg.Complemento, reg.Complemento, 0, 99, Convert.ToDateTime(reg.Data_Vencimento), "Web");

                DescTributo += "090 - Honorários";
                reg.Descricao_Tributo = DescTributo;
                lstExtrato.Add(reg);

                Debitoparcela regParcela = new Debitoparcela {
                    Codreduzido=_codigo,
                    Anoexercicio=(short)DateTime.Now.Year,
                    Codlancamento=41,
                    Seqlancamento=(short)_seq,
                    Numparcela=1,
                    Codcomplemento=0,
                    Statuslanc=3,
                    Datavencimento=Convert.ToDateTime(lblVenctoDam.Text),
                    Datadebase=DateTime.Now,
                    Userid=236
                };
                Exception ex = tributario_Class.Insert_Debito_Parcela(regParcela);

                Debitotributo regTributo = new Debitotributo {
                    Codreduzido = _codigo,
                    Anoexercicio = (short)DateTime.Now.Year,
                    Codlancamento = 41,
                    Seqlancamento = (short)_seq,
                    Numparcela = 1,
                    Codcomplemento = 0,
                    Codtributo = 90,
                    Valortributo = Valor_Honorario
                };
                ex = tributario_Class.Insert_Debito_Tributo(regTributo);

            }

            decimal nValorGuia = 0;
            decimal.TryParse(TableTotal.Rows[2].Cells[6].Text, out nValorGuia);

            Numdocumento regDoc = new Numdocumento();
            regDoc.Valorguia = nValorGuia;
            regDoc.Emissor = "Gti.Web/Dam.Reg";
            regDoc.Datadocumento = DateTime.Now;
            regDoc.Registrado = true;
            regDoc.Percisencao = 0;
            if (bRefis) {
                if(nPlano==26)
                    regDoc.Percisencao = 100;
                else {
                    if(nPlano==27)
                        regDoc.Percisencao = 90;
                    else {
                        if (nPlano == 28)
                            regDoc.Percisencao = 80;
                    }
                }
            }
            int NumDoc= tributario_Class.Insert_Documento(regDoc);
           
            foreach (DebitoStructure Lanc in lstExtrato) {
                Parceladocumento regParc = new Parceladocumento();
                regParc.Codreduzido = Lanc.Codigo_Reduzido;
                regParc.Anoexercicio = Convert.ToInt16(Lanc.Ano_Exercicio);
                regParc.Codlancamento = Convert.ToInt16(Lanc.Codigo_Lancamento);
                regParc.Seqlancamento = Convert.ToInt16(Lanc.Sequencia_Lancamento);
                regParc.Numparcela = Convert.ToByte(Lanc.Numero_Parcela);
                regParc.Codcomplemento = Convert.ToByte(Lanc.Complemento);
                regParc.Numdocumento = NumDoc;
                regParc.Valorjuros = Convert.ToDecimal(Lanc.Soma_Juros);
                regParc.Valormulta = Convert.ToDecimal(Lanc.Soma_Multa);
                regParc.Valorcorrecao = Convert.ToDecimal(Lanc.Soma_Correcao);
                regParc.Plano = Convert.ToInt16( nPlano);
                
                tributario_Class.Insert_Parcela_Documento(regParc);
            }

            String sDataDAM = lblVenctoDam.Text;
            if (lstExtrato.Count == 0) {
                lblMsg2.Text = "Selecione ao menos uma parcela.";
                return;
            }
            int nSid = tributario_Class.Insert_Boleto_DAM(lstExtrato, NumDoc, DateTime.ParseExact(sDataDAM, "dd/MM/yyyy", null));
            if (nSid > 0) {
                
                Session["sid"] = nSid;
//                if (Convert.ToInt32(txtCod.Text) == 38 || Convert.ToInt32(txtCod.Text) == 118777 || Convert.ToInt32(txtCod.Text) == 500000) {
                    Response.Redirect("~/Pages/damwebend2.aspx");
                    ShowResult(false);
                    Response.Write("<script>window.open('damwebend2.aspx','_blank');</script>");
  //              } else
    //                Response.Redirect("~/Pages/damwebend.aspx");
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

        protected void btnOpenModal_Click(object sender, EventArgs e) {
            bool _find = false;
            foreach (GridViewRow row in grdMain.Rows) {
                if (row.RowType == DataControlRowType.DataRow) {
                    if ((row.FindControl("chkRow") as CheckBox).Checked) {
                        if (row.Cells[12].Text == "SIM" || row.Cells[13].Text == "SIM") {
                            bGerado = false;
                            _find = true;
                            break;
                        }
                    }
                }
            }
            if(_find)
                divModal.Visible = true;
            else 
                btPrint_Click(sender, e);
        }

        protected void CloseModal(object sender, EventArgs e) {
            divModal.Visible = false;
        }


    }//end class
}