using CrystalDecisions.CrystalReports.Engine;
using GTI_Bll.Classes;
using GTI_Models;
using GTI_Models.Models;

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class alvara_funcionamento : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            String s = Request.QueryString["d"];
            if (s != "gti")
                Response.Redirect("~/Pages/gtiMenu.aspx");
        }

        private void EmiteAlvara(int Codigo) {

            lblmsg.Text = "";
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
            EmpresaStruct reg = empresa_Class.Retorna_Empresa(Codigo);
            
            int _ano_certidao = DateTime.Now.Year;
            int _numero_certidao = empresa_Class.Retorna_Alvara_Disponivel(_ano_certidao);

            Alvara_funcionamento alvara = new Alvara_funcionamento();
            alvara.Ano = (short)_ano_certidao;
            alvara.Numero = _numero_certidao;
            alvara.Controle = _numero_certidao.ToString("00000") + _ano_certidao.ToString("0000") + "/" + Codigo.ToString() + "-AF";
            alvara.Codigo = Codigo;
            alvara.Razao_social = reg.Razao_social;

            string sDoc = "";    
            if (reg.Cpf_cnpj.Length == 11)
                sDoc = Convert.ToInt64(gtiCore.RetornaNumero(reg.Cpf_cnpj)).ToString(@"000\.000\.000\-00");
            else
                sDoc = Convert.ToInt64(gtiCore.RetornaNumero(reg.Cpf_cnpj)).ToString(@"00\.000\.000\/0000\-00");

            alvara.Documento = sDoc;
            alvara.Endereco = reg.Endereco_nome + ", " + reg.Numero.ToString() + " " + reg.Complemento;
            alvara.Bairro = reg.Bairro_nome;
            alvara.Atividade = reg.Atividade_extenso;
            alvara.Horario = String.IsNullOrWhiteSpace(reg.Horario_extenso) ? reg.Horario_Nome : reg.Horario_extenso;
            alvara.Validade = Convert.ToDateTime("30/06/2019");
            alvara.Data_Gravada = DateTime.Now;

            Exception ex = tributario_Class.Insert_Alvara_Funcionamento(alvara);

            //Grava no histórico
            List<MobiliarioHistoricoStruct> _historicos = empresa_Class.Lista_Empresa_Historico(Codigo);
            MobiliarioHistoricoStruct _newHist = new MobiliarioHistoricoStruct() {
                Codigo=Codigo,
                Seq=(short)(_historicos.Count+1),
                Observacao="Emissão de álvara via Internet",
                Data=DateTime.Now,
                Usuario_id=478
            };
            _historicos.Add(_newHist);
            ex = empresa_Class.Incluir_Empresa_Historico(_historicos);

            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/AlvaraFuncionamento.rpt"));
            crystalReport.SetParameterValue("CADASTRO", Codigo.ToString());
            crystalReport.SetParameterValue("NOME", alvara.Razao_social);
            crystalReport.SetParameterValue("AUTENTICIDADE", alvara.Controle);
            crystalReport.SetParameterValue("DOC", alvara.Documento);
            crystalReport.SetParameterValue("ENDERECO", alvara.Endereco);
            crystalReport.SetParameterValue("BAIRRO", alvara.Bairro);
            crystalReport.SetParameterValue("ATIVIDADE", alvara.Atividade);
            crystalReport.SetParameterValue("HORARIO", alvara.Horario);

            HttpContext.Current.Response.Buffer = false;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();

            try {
                crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true,"Alvara"+ Codigo.ToString("000000"));
            } catch {
            } finally {
                crystalReport.Close();
                crystalReport.Dispose();
            }

        }

        protected void ValidarButton_Click(object sender, EventArgs e) {
            string sCod = Codigo.Text;
            lblmsg.Text = "";
            if (sCod.Trim().Length != 19)
                lblmsg.Text = "Código de validação inválido.";
            else {
                Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
                Alvara_funcionamento dados = empresa_Class.Alvara_Funcionamento_gravado(sCod);
                if (dados != null)
                    Exibe_Validacao(dados);
                else
                    lblmsg.Text = "Alvará não cadastrado.";
            }
        }

        private void Exibe_Validacao(Alvara_funcionamento alvara) {
            string _tipo = alvara.Controle.Substring(alvara.Controle.Length - 2, 2);
            ReportDocument crystalReport = new ReportDocument();
            if(_tipo=="AF" || _tipo=="AN")
                crystalReport.Load(Server.MapPath("~/Report/AlvaraFuncionamentoValida.rpt"));
            else
                crystalReport.Load(Server.MapPath("~/Report/AlvaraFuncionamentoProvisorioValida.rpt"));
            crystalReport.SetParameterValue("CADASTRO", alvara.Codigo.ToString());
            crystalReport.SetParameterValue("NOME", alvara.Razao_social);
            crystalReport.SetParameterValue("AUTENTICIDADE", alvara.Controle);
            crystalReport.SetParameterValue("DOC", alvara.Documento);
            crystalReport.SetParameterValue("ENDERECO", alvara.Endereco);
            crystalReport.SetParameterValue("BAIRRO", alvara.Bairro);
            crystalReport.SetParameterValue("ATIVIDADE", alvara.Atividade);
            crystalReport.SetParameterValue("HORARIO", alvara.Horario);
            crystalReport.SetParameterValue("VALIDADE", alvara.Validade);

            HttpContext.Current.Response.Buffer = false;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();

            try {
                crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "Alvara" + alvara.Codigo.ToString("000000"));
            } catch {
            } finally {
                crystalReport.Close();
                crystalReport.Dispose();
            }
        }
               
        protected void btPrint_Click(object sender, EventArgs e) {
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
                    } else {
                        //bool bAlvara = empresa_Class.Empresa_tem_Alvara(Num);
                        //if (!bAlvara) {
                        //    lblmsg.Text = "Esta empresa não pode emitir alvará pela internet.";
                        //    return;
                        //} else {
                            bool bSuspenso = empresa_Class.EmpresaSuspensa(Num);
                            if (bSuspenso) {
                                lblmsg.Text = "Esta empresa encontra-se suspensa.";
                                return;
                            } else {
                                EmpresaStruct empresa = empresa_Class.Retorna_Empresa(Num);
                                if (empresa.Data_Encerramento != null) {
                                    lblmsg.Text = "Esta empresa encontra-se encerrada.";
                                    return;
                                } else {
                                    if (Convert.ToDateTime(empresa.Data_abertura).Year == DateTime.Now.Year) {
                                        lblmsg.Text = "Empresa aberta este ano não pode renovar o alvará.";
                                        return;
                                    } else {
                                        int _atividade_codigo = (int)empresa.Atividade_codigo;
                                        bool bAtividadeAlvara = empresa_Class.Atividade_tem_Alvara(_atividade_codigo);
                                        if (!bAtividadeAlvara) {
                                            lblmsg.Text = "Atividade da empresa não permite renovar o alvará .";
                                            return;
                                        } else {
                                            bool bIsentoTaxa;
                                            if (empresa.Isento_taxa == 1)
                                                bIsentoTaxa = true;
                                            else
                                                bIsentoTaxa = false;

                                            if (!bIsentoTaxa) {
                                                int _qtde = empresa_Class.Qtde_Parcelas_TLL_Vencidas(Num);
                                            if (_qtde > 0) {
                                                lblmsg.Text = "A taxa de licença não esta paga, favor dirigir-se ao Sistema Prático da Prefeitura para regularizar.";
                                                return;
                                            } else {
                                                if(empresa.Endereco_codigo==123 && empresa.Numero==146 ) {
                                                    lblmsg.Text = "O endereço desta empresa não permite a emissão de alvará automático.";
                                                    return;
                                                }
                                            }

                                            }
                                            EmiteAlvara(Num);
                                        }
                                    }
                                }
//                            }
                        }
                    }
                }
            } else {
                lblmsg.Text = "Código da imagem inválido.";
            }
        }
    }
}