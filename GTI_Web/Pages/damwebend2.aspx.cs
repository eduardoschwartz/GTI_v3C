using GTI_Bll.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static GTI_Models.modelCore;

namespace UIWeb.Pages {
    public partial class damwebend2 : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            int nCodigo = 0;
            if (!IsPostBack) {
                if (Session["sid"] != null && Session["sid"].ToString() != "") {
                    Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
                    List<Boleto> ListaBoleto = tributario_Class.Lista_Boleto_DAM(Convert.ToInt32(Session["sid"]));
                    txtDtVenc.Text = Convert.ToDateTime(ListaBoleto[0].Datadam).ToString("dd/MM/yyyy");
                    txtValor.Text = Convert.ToDouble(ListaBoleto[0].Valordam).ToString("#0.00");

                    txtcpfCnpj.Text = ListaBoleto[0].Cpf;
                    txtrefTran.Text = "287353200" + ListaBoleto[0].Numdoc2.Substring(0,8); 

                    nCodigo = Convert.ToInt32( ListaBoleto[0].Codreduzido);
                    if (nCodigo < 100000) {
                        //Imóvel
                        Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
                        
                        int nTipoEndereco = (int)imovel_Class.Dados_Imovel(nCodigo).EE_TipoEndereco;
                        nTipoEndereco = 0;
                        EnderecoStruct reg = imovel_Class.Dados_Endereco(nCodigo, nTipoEndereco==0?TipoEndereco.Local:nTipoEndereco==1?TipoEndereco.Entrega:TipoEndereco.Proprietario);
                        txtNome.Text = imovel_Class.Lista_Proprietario(nCodigo, true)[0].Nome;
                        txtEndereco.Text = reg.Endereco + ", " + reg.Numero.ToString() + " " + reg.Complemento + " " + reg.NomeBairro ;
                        txtCidade.Text = reg.NomeCidade;
                        txtCep.Text = reg.Cep;
                        txtUF.Text = reg.UF;
                    } else {
                        if(nCodigo>=100000 && nCodigo < 500000) {
                            //Empresa
                            Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
                            EmpresaStruct reg = empresa_Class.Retorna_Empresa(nCodigo);
                            txtNome.Text = reg.Razao_social;
                            txtEndereco.Text = reg.Endereco_nome + ", " + reg.Numero.ToString() + " " + reg.Complemento + " " + reg.Bairro_nome;
                            txtCidade.Text = reg.Cidade_nome;
                            txtcpfCnpj.Text = reg.Cpf_cnpj;
                            txtCep.Text = reg.Cep;
                            txtUF.Text = reg.UF;
                        } else {
                            //Cidadão
                            Cidadao_bll cidadao_Class = new Cidadao_bll("GTIconnection");
                            CidadaoStruct reg = cidadao_Class.LoadReg(nCodigo);
                            txtcpfCnpj.Text = string.IsNullOrWhiteSpace(reg.Cpf)?reg.Cnpj:reg.Cpf;
                            txtNome.Text = reg.Nome;
                            txtEndereco.Text = reg.EnderecoR + ", " + reg.NumeroR.ToString() + " " + reg.ComplementoR + " " + reg.NomeBairroR;
                            txtCidade.Text = reg.NomeCidadeR;
                            txtCep.Text = reg.CepR.ToString();
                            txtUF.Text = reg.UfR;
                        }
                    }
                    UpdateDatabase();
                } else
                    Response.Redirect("~/Pages/gtiMenu.aspx");
            }
            else
                Response.Redirect("~/Pages/gtiMenu.aspx");
        }

        protected void btPrint_Click(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(Session["sid"].ToString())) {
                printCarne(Convert.ToInt32(Session["sid"]));
                Session["sid"] = "";
            } else
                Response.Redirect("~/Pages/gtiMenu.aspx");

        }

        private void printCarne(int nSid) {
        }

        public static String RetornaNumero(String Numero) {
            if (String.IsNullOrEmpty(Numero))
                return "0";
            else
                return Regex.Replace(Numero, @"[^\d]", "");
        }

        public void UpdateDatabase() {
            if (txtCidade.Text.Length == 0) {
            } else {
                comercio_eletronico Reg = new comercio_eletronico();
                Reg.Cep = Convert.ToInt32(gtiCore.RetornaNumero(txtCep.Text));
                Reg.Cidade = txtCidade.Text.Length > 50 ? txtCidade.Text.Substring(0, 50) : txtCidade.Text;
                Reg.Cpfcnpj = gtiCore.RetornaNumero(txtcpfCnpj.Text);
                Reg.Dataemissao = DateTime.Now;
                Reg.Datavencto = gtiCore.IsDate(txtDtVenc.Text) ? Convert.ToDateTime(txtDtVenc.Text) : Convert.ToDateTime("01/01/1900");
                Reg.Endereco = txtEndereco.Text.Length > 200 ? txtEndereco.Text.Substring(0, 200) : txtEndereco.Text;
                Reg.Nome = txtNome.Text.Length > 100 ? txtNome.Text.Substring(0, 100) : txtNome.Text;
                Reg.Nossonumero = txtrefTran.Text;
                Reg.Numdoc = Convert.ToInt32(txtrefTran.Text.Right(8));
                Reg.UF = txtUF.Text;
                Reg.Usuario = "DAM/Web";
                Reg.Valorguia = Convert.ToDecimal(txtValor.Text);

                Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
                if (tributario_Class.Existe_Comercio_Eletronico(Reg.Numdoc))
                    Response.Redirect("~/Pages/gtiMenu.aspx");
                else
                    tributario_Class.Insert_Boleto_Comercio_Eletronico(Reg);
            }
        }

        protected void btGerar_Click(object sender, EventArgs e) {

        }


    }
}