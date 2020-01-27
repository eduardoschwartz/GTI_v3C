using GTI_Bll.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;

namespace UIWeb {
    public partial class SegundaViaIPTU : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            String s = Request.QueryString["d"];
            if (s != "gti")
                Response.Redirect("~/Pages/gtiMenu.aspx");

        }

        protected void btPrint_Click(object sender, EventArgs e) {
            int Num = 0;
            String sTextoImagem = txtimgcode.Text;
            txtimgcode.Text = "";
            Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
            bool isNum = Int32.TryParse(txtCod.Text, out Num);
            if (!isNum) {
                lblmsg.Text = "Código do imóvel inválido!";
                return;
            } else {
                bool bExiste = imovel_Class.Existe_Imovel(Num);
                if (!bExiste) {
                    lblmsg.Text = "Código do imóvel inválido!";
                    return;
                }
                else {
                    if(String.IsNullOrWhiteSpace(txtIC.Text))
                    {
                        lblmsg.Text = "Inscrição cadastral obrigatória!";
                        return;
                    }
                    else {
                        ImovelStruct reg = imovel_Class.Dados_Imovel(Num);
                        if (gtiCore.RetornaNumero( txtIC.Text) != gtiCore.RetornaNumero(reg.Inscricao))
                        {
                            lblmsg.Text = "Inscrição cadastral inválida!";
                            return;
                        }
                    }
                }
            }

            if (Page.IsValid && (txtimgcode.Text == Session["randomStr"].ToString())) {
                lblmsg.Text = "Código da imagem inválido.";
                return;
            }

            lblmsg.Text = "";
            this.txtimgcode.Text = "";
            int nSid=gravaCarne();
            if (nSid > 0) {
                Session["sid"] = nSid;
                Response.Redirect("~/Pages/SegundaViaIPTUend.aspx?d=gti");
            }
        }

        private int gravaCarne() {
            int nSid = gtiCore.GetRandomNumber();
            int nImovel = Convert.ToInt32(txtCod.Text);
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
            List<DebitoStructure> Extrato_Lista = tributario_Class.Lista_Parcelas_IPTU( nImovel, 2020);
            if (Extrato_Lista.Count == 0) {
                lblmsg.Text = "Não é possível emitir segunda via para este código";
                return 0;
            }
            short nSeq = 0;
            ImovelStruct dados_imovel = imovel_Class.Dados_Imovel(nImovel);
            List<ProprietarioStruct> lstProprietario = imovel_Class.Lista_Proprietario(nImovel, true);

            foreach (DebitoStructure item in Extrato_Lista) {



            Boletoguia reg = new Boletoguia();
                reg.Usuario = "Gti.Web/2ViaIPTU";
                reg.Computer = "web";
                reg.Sid =nSid;
                reg.Seq = nSeq;
                reg.Codreduzido = item.Codigo_Reduzido.ToString("000000");
                reg.Nome = lstProprietario[0].Nome;
                reg.Cpf = lstProprietario[0].CPF;
                reg.Numimovel = (short)dados_imovel.Numero;
                reg.Endereco = dados_imovel.NomeLogradouro + ", " + dados_imovel.Numero.ToString();
                reg.Complemento = dados_imovel.Complemento.Length > 10 ? dados_imovel.Complemento.Substring(0, 10) : dados_imovel.Complemento;
                reg.Bairro = dados_imovel.NomeBairro;
                reg.Cidade = "JABOTICABAL";
                reg.Uf = "SP";
                reg.Desclanc = "IMPOSTO PREDIAL E TERRITORIAL URBANO - 2ª VIA";
                reg.Fulllanc = "IMPOSTO PREDIAL E TERRITORIAL URBANO - 2ª VIA";
                reg.Numdoc = item.Numero_Documento.ToString();
                reg.Numparcela = (short)item.Numero_Parcela;
                reg.Quadra = dados_imovel.QuadraOriginal.Length > 15 ? dados_imovel.QuadraOriginal.Substring(0, 15) : dados_imovel.QuadraOriginal;
                reg.Lote = dados_imovel.LoteOriginal.Length > 15 ? dados_imovel.LoteOriginal.Substring(0, 15) : dados_imovel.LoteOriginal;
                reg.Datadoc = item.Data_Base;
                reg.Datavencto = Convert.ToDateTime( item.Data_Vencimento);
                reg.Numdoc2 = item.Numero_Documento.ToString();
                reg.Digitavel = "linha digitavel";
                reg.Valorguia = Convert.ToDecimal(item.Soma_Principal);
                reg.Inscricao_cadastral = dados_imovel.Distrito.ToString() + "." + dados_imovel.Setor.ToString("00") + "." + dados_imovel.Quadra.ToString("0000") + 
                    "." + dados_imovel.Lote.ToString("00000") + "." + dados_imovel.Seq.ToString("00") + "." + dados_imovel.Unidade.ToString("00") + "." + dados_imovel.SubUnidade.ToString("000");
                Laseriptu RegIPTU = tributario_Class.Carrega_Dados_IPTU(item.Codigo_Reduzido, 2020);
                if (RegIPTU == null) {
                    lblmsg.Text = "Solicitação inválida, entre em contato com o Sistema Prático na Prefeitura.";
                    return 0; 
                }
                reg.Totparcela = (short)RegIPTU.Qtdeparc;
                if (item.Numero_Parcela == 0) {
                    if(item.Complemento==0)
                        reg.Parcela = "Única 5%";
                    else {
                        if (item.Complemento == 91)
                            reg.Parcela = "Única 4%";
                        else
                            reg.Parcela = "Única 3%";
                    }
                } else
                    reg.Parcela = reg.Numparcela.ToString("00") + "/" + reg.Totparcela.ToString("00");


                string sFullLanc = "Dados do Imovel:" + Environment.NewLine + Environment.NewLine + "Área do terreno: " + string.Format("{0:#.00}", Convert.ToDecimal(RegIPTU.Areaterreno.ToString()) ) + " m²";
                sFullLanc+=Environment.NewLine + "Área construída: " + string.Format("{0:#.00}", Convert.ToDecimal(RegIPTU.Areaconstrucao.ToString())) + " m²";
                sFullLanc += Environment.NewLine + "Testada principal: " + string.Format("{0:#.00}", Convert.ToDecimal(RegIPTU.Testadaprinc.ToString())) + " m";
                sFullLanc += Environment.NewLine + "Valor venal territorial: R$ " + string.Format("{0:#.00}", Convert.ToDecimal(RegIPTU.Vvt.ToString()));
                sFullLanc += Environment.NewLine + "Valor venal predial: R$ " + string.Format("{0:#.00}", Convert.ToDecimal(RegIPTU.Vvc.ToString()));
                sFullLanc += Environment.NewLine + "Valor venal imóvel: R$ " + string.Format("{0:#.00}", Convert.ToDecimal(RegIPTU.Vvi.ToString()));
                sFullLanc += Environment.NewLine + "Valor IPTU parcelado: R$ " + string.Format("{0:#.00}", Convert.ToDecimal((RegIPTU.Valortotalparc*RegIPTU.Qtdeparc).ToString()));
                sFullLanc += Environment.NewLine + "Valor IPTU único: R$ " + string.Format("{0:#.00}", Convert.ToDecimal(RegIPTU.Valortotalunica.ToString()));

                reg.Obs = sFullLanc;
                reg.Numproc = "";
                reg.Cep = dados_imovel.Cep;
                //decimal nValorguia = Math.Truncate(Convert.ToDecimal(reg.Valorguia * 100));
                string _convenio = "2873532";


                //***** GERA CÓDIGO DE BARRAS BOLETO REGISTRADO*****
                DateTime _data_base = Convert.ToDateTime("07/10/1997");
                TimeSpan ts = Convert.ToDateTime(item.Data_Vencimento) - _data_base;
                int _fator_vencto = ts.Days;
                string _quinto_grupo = String.Format("{0:D4}", _fator_vencto);
                string _valor_boleto_str = string.Format("{0:0.00}", reg.Valorguia);
                _quinto_grupo += string.Format("{0:D10}", Convert.ToInt64(gtiCore.RetornaNumero(_valor_boleto_str)));
                string _barra = "0019" + _quinto_grupo + String.Format("{0:D13}", Convert.ToInt32(_convenio));
                _barra += String.Format("{0:D10}", Convert.ToInt64( reg.Numdoc)) + "17";
                string _campo1 = "0019" + _barra.Substring(19, 5);
                string _digitavel = _campo1 + gtiCore.Calculo_DV10(_campo1).ToString();
                string _campo2 = _barra.Substring(23, 10);
                _digitavel += _campo2 + gtiCore.Calculo_DV10(_campo2).ToString();
                string _campo3 = _barra.Substring(33, 10);
                _digitavel += _campo3 + gtiCore.Calculo_DV10(_campo3).ToString();
                string _campo5 = _quinto_grupo;
                string _campo4 = gtiCore.Calculo_DV11(_barra).ToString();
                _digitavel += _campo4 + _campo5;
                _barra = _barra.Substring(0, 4) + _campo4 + _barra.Substring(4, _barra.Length - 4);
                //**Resultado final**
                string _linha_digitavel = _digitavel.Substring(0, 5) + "." + _digitavel.Substring(5, 5) + " " + _digitavel.Substring(10, 5) + "." + _digitavel.Substring(15, 6) + " ";
                _linha_digitavel += _digitavel.Substring(21, 5) + "." + _digitavel.Substring(26, 6) + " " + _digitavel.Substring(32, 1) + " " + gtiCore.StringRight(_digitavel, 14);
                string _codigo_barra = gtiCore.Gera2of5Str(_barra);
                //**************************************************

                reg.Digitavel = _linha_digitavel;
                reg.Codbarra = _codigo_barra;
                reg.Nossonumero = _convenio + String.Format("{0:D10}", Convert.ToInt64(reg.Numdoc));
                tributario_Class.Insert_Boleto_Guia(reg);

                Segunda_via_web reg_sv = new Segunda_via_web();
                reg_sv.Numero_documento = Convert.ToInt32(item.Numero_Documento);
                reg_sv.Data = DateTime.Now;
                tributario_Class.Insert_Numero_Segunda_Via(reg_sv);

                nSeq++;
            }

            return nSid;
        }
       
    }//end class
}//end namespace