using GTI_Bll.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;


namespace UIWeb.Pages {
    public partial class SegundaViaCIP : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            String s = Request.QueryString["d"];
            if (s != "gti")
                Response.Redirect("~/Pages/gtiMenu.aspx");

        }

        protected void btPrint_Click(object sender, EventArgs e) {
            int Num = 0;
            String sTextoImagem = txtimgcode.Text;
            txtimgcode.Text = "";

            string sCPF = txtCPF.Text, sCNPJ = txtCNPJ.Text;
            if (sCPF == "" && sCNPJ == "")
                lblmsg.Text = "Digite o CPF/CNPJ da empresa.";
            else {
                if (sCPF != "") {
                    bool _validacpf = gtiCore.ValidaCpf(txtCPF.Text);
                    if (!_validacpf) {
                        lblmsg.Text = "CPF inválido.";
                        return;
                    }
                } else {
                    bool _validacnpj = gtiCore.ValidaCNPJ(txtCNPJ.Text);
                    if (!_validacnpj) {
                        lblmsg.Text = "CNPJ inválido.";
                        return;
                    }
                }
            }

            Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
            bool isNum = Int32.TryParse(txtCod.Text, out Num);
            if (!isNum) {
                lblmsg.Text = "Código do imóvel inválido!";
                return;
            } else {
                bool bExiste = imovel_Class.Existe_Imovel(Num);
                List<ProprietarioStruct> ListaProprietario = imovel_Class.Lista_Proprietario(Num, true);
                if (!bExiste) {
                    lblmsg.Text = "Código do imóvel inválido!";
                    return;
                } else {
                    if (sCPF != "") {
                        if (gtiCore.RetornaNumero( ListaProprietario[0].CPF) !=gtiCore.RetornaNumero( sCPF)) {
                            lblmsg.Text = "O CPF informado não pertence ao proprietário principal deste imóve!";
                            return;
                        }
                    } else {
                        if (gtiCore.RetornaNumero( ListaProprietario[0].CPF) != gtiCore.RetornaNumero( sCNPJ)) {
                            lblmsg.Text = "O CNPJ informado não pertence ao proprietário principal deste imóve!";
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
            int nSid = gravaCarne();
            if (nSid > 0) {
                Session["sid"] = nSid;
                Response.Redirect("~/Pages/SegundaViaCIPFim.aspx?d=gti");
            }
        }


        private int gravaCarne() {
            int nSid = gtiCore.GetRandomNumber();
            int nImovel = Convert.ToInt32(txtCod.Text);
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
            List<DebitoStructure> Extrato_Lista = tributario_Class.Lista_Parcelas_CIP(nImovel, 2019);
            if (Extrato_Lista.Count == 0) {
                lblmsg.Text = "Não é possível emitir segunda via para este código";
                return 0;
            }

            short nSeq = 0;
            foreach (DebitoStructure item in Extrato_Lista) {
                ImovelStruct dados_imovel = imovel_Class.Dados_Imovel(nImovel);
                List<ProprietarioStruct> lstProprietario = imovel_Class.Lista_Proprietario(nImovel, true);
                Boletoguia reg = new Boletoguia();
                reg.Usuario = "Gti.Web/2ViaIPTU";
                reg.Computer = "web";
                reg.Sid = nSid;
                reg.Seq = nSeq;
                reg.Codreduzido = nImovel.ToString("000000");
                reg.Nome = lstProprietario[0].Nome;
                reg.Cpf = lstProprietario[0].CPF;
                reg.Endereco = dados_imovel.NomeLogradouro;
                reg.Numimovel = (short)dados_imovel.Numero;
                reg.Complemento = dados_imovel.Complemento.Length > 10 ? dados_imovel.Complemento.Substring(0, 10) : dados_imovel.Complemento;
                reg.Bairro = dados_imovel.NomeBairro;
                reg.Cidade = "JABOTICABAL";
                reg.Uf = "SP";
                reg.Desclanc = "CONTRIBUIÇÃO DE ILUMINAÇÃO PÚBLICA (CIP-2019)";
                reg.Fulllanc = "CONTRIBUIÇÃO DE ILUMINAÇÃO PÚBLICA (CIP-2019)";
                reg.Numdoc = item.Numero_Documento.ToString();
                reg.Numparcela = (short)item.Numero_Parcela;
                reg.Datavencto = Convert.ToDateTime(item.Data_Vencimento);
                reg.Numdoc2 = item.Numero_Documento.ToString();
                reg.Digitavel = "linha digitavel";
                reg.Valorguia = Convert.ToDecimal(item.Soma_Principal);
                reg.Totparcela = 3;
                reg.Obs = "";
                reg.Numproc = "Q:" + dados_imovel.QuadraOriginal.ToString().Trim() + " L:" + dados_imovel.LoteOriginal.ToString().Trim();
                reg.Cep = dados_imovel.Cep;


                string _convenio = "2950230";

                //***** GERA CÓDIGO DE BARRAS BOLETO REGISTRADO*****
                DateTime _data_base = Convert.ToDateTime("07/10/1997");
                TimeSpan ts = Convert.ToDateTime(item.Data_Vencimento) - _data_base;
                int _fator_vencto = ts.Days;
                string _quinto_grupo = String.Format("{0:D4}", _fator_vencto);
                string _valor_boleto_str = string.Format("{0:0.00}", reg.Valorguia);
                _quinto_grupo += string.Format("{0:D10}", Convert.ToInt64(gtiCore.RetornaNumero(_valor_boleto_str)));
                string _barra = "0019" + _quinto_grupo + String.Format("{0:D13}", Convert.ToInt32(_convenio));
                _barra += String.Format("{0:D10}", Convert.ToInt64(reg.Numdoc)) + "17";
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
    }
}