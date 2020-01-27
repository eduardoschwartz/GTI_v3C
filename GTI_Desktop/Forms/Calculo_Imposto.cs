using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Calculo_Imposto : Form {
        string _connection = gtiCore.Connection_Name();
        string _path = @"c:\cadastro\bin\";
        int _ano = 2020;
        int _documento = 17770764;
        decimal _ipca = (decimal)2.894;
 
        private enum Tipo_imposto {
            Iptu = 1,
            ISS_Fixo_TLL=2,
            Vigilancia=5
        }

        public Calculo_Imposto() {
            InitializeComponent();
        }

        private void Calculo_Imposto_Load(object sender, EventArgs e) {
            ImpostoList.SelectedIndex = 0;
        }

        private void ExecutarButton_Click(object sender, EventArgs e) {
            ExecutarButton.Enabled = false;
            gtiCore.Ocupado(this);
            switch (ImpostoList.SelectedIndex) {
                case 0:
                    Calculo_Iptu();
                    break;
                case 1:
                    Calculo_IssTLL();
                    break; 
                case 2:
                    Calculo_Vigilancia();
                    break;
                default:
                    break;
            }
            gtiCore.Liberado(this);
            ExecutarButton.Enabled = true;
        }

        private int _qtde_normal { get; set; }

        private void Calculo_Iptu() {

            FileStream fsDP = new FileStream(_path + "DEBITOPARCELA.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs1 = new StreamWriter(fsDP, System.Text.Encoding.Default);
            FileStream fsDT = new FileStream(_path + "DEBITOTRIBUTO.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs2 = new StreamWriter(fsDT, System.Text.Encoding.Default);
            FileStream fsPD = new FileStream(_path + "PARCELADOCUMENTO.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs3 = new StreamWriter(fsPD, System.Text.Encoding.Default);
            FileStream fsND = new FileStream(_path + "NUMDOCUMENTO.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs4 = new StreamWriter(fsND, System.Text.Encoding.Default);
            FileStream fsCC = new FileStream(_path + "CALCULO_RESUMO.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs5 = new StreamWriter(fsCC, System.Text.Encoding.Default);
            FileStream fsLS = new FileStream(_path + "LASERIPTU.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs6 = new StreamWriter(fsLS, System.Text.Encoding.Default);

            MsgToolStrip.Text = "Calculando IPTU";

            List<DateTime> aVencimento = new List<DateTime>();
            List<decimal> aDesconto = new List<decimal>();

            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            Paramparcela _Prm = tributario_Class.Retorna_Parametro_Parcela(_ano, (int)Tipo_imposto.Iptu);

            aDesconto.Add((decimal)_Prm.Descontounica);
            if (_Prm.Descontounica2 != null)
                aDesconto.Add((decimal)_Prm.Descontounica2);
            if (_Prm.Descontounica3 != null)
                aDesconto.Add((decimal)_Prm.Descontounica3);

            aVencimento.Add((DateTime)_Prm.Venc01);
            aVencimento.Add((DateTime)_Prm.Venc02);
            aVencimento.Add((DateTime)_Prm.Venc03);
            aVencimento.Add((DateTime)_Prm.Venc04);
            aVencimento.Add((DateTime)_Prm.Venc05);
            aVencimento.Add((DateTime)_Prm.Venc06);
            aVencimento.Add((DateTime)_Prm.Venc07);
            aVencimento.Add((DateTime)_Prm.Venc08);
            aVencimento.Add((DateTime)_Prm.Venc09);
            aVencimento.Add((DateTime)_Prm.Venc10);
            aVencimento.Add((DateTime)_Prm.Venc11);
            aVencimento.Add((DateTime)_Prm.Venc12);

            Imovel_bll imovel_Class = new Imovel_bll(_connection);
            List<int> ListaAtivos = imovel_Class.Lista_Imovel_Ativo();

            int _total = ListaAtivos.Count, _pos = 1;
            int _qtde_normal = 0,_qtde_imune=0,_qtde_isento_area=0,_qtde_isento_processo=0,_qtde_total=0,_qtde_laminas=0;
            decimal _valor_si_normal = 0, _valor_si_imune = 0, _valor_si_isento_area = 0, _valor_si_isento_processo = 0, _valor_si_total = 0;
            decimal _valor_ci_normal = 0, _valor_ci_imune = 0, _valor_ci_isento_area = 0, _valor_ci_isento_processo = 0, _valor_ci_total = 0;

            string[] aDocumento = new string[15];
            string  _valor0 = "",_valor91="",_valor92="", _valor1 = "";

            foreach (int Codigo in ListaAtivos) {

//                if (Codigo > 50) break;
                if (_pos % 50 == 0) {
                    PBar.Value = _pos * 100 / _total;
                    PBar.Update();
                    Refresh();
                    QtdeNormal.Text = _qtde_normal.ToString("00000");
                    QtdeImune.Text = _qtde_imune.ToString("00000");
                    QtdeIsentoArea.Text = _qtde_isento_area.ToString("00000");
                    QtdeIsentoProcesso.Text = _qtde_isento_processo.ToString("00000");
                    QtdeLamina.Text = _qtde_laminas.ToString("000000");
                    QtdeTotal.Text = _qtde_total.ToString("00000");
                    Valor_ci_Normal.Text = _valor_ci_normal.ToString("#0.00");
                    Valor_si_Normal.Text = _valor_si_normal.ToString("#0.00");
                    Valor_si_IsentoArea.Text = _valor_si_isento_area.ToString("#0.00");
                    Valor_si_IsentoProcesso.Text = _valor_si_isento_processo.ToString("#0.00");
                    Valor_si_Imune.Text = _valor_si_imune.ToString("#0.00");
                    Valor_si_Total.Text = _valor_si_total.ToString("#0.00");
                    Valor_ci_Total.Text = _valor_ci_total.ToString("#0.00");

                    Application.DoEvents();
                }

                SpCalculo _calc = tributario_Class.Calculo_IPTU(Codigo, _ano);
                int _tipo_isencao = _calc.Tipoisencao;
                int _qtde_parcela = _calc.Qtdeparc;
                decimal _perc_Isencao = _calc.Percisencao;
                decimal _vvp = _calc.Vvp,_vvt=_calc.Vvt,_vvi=_calc.Vvi;
                string _natureza = _calc.Natureza;
                decimal _valor_parcela =_calc.Valorparcela;
                decimal _valor_unica = _calc.Valorunica;
                decimal _valor_unica2 = _calc.Valorunica2;
                decimal _valor_unica3 = _calc.Valorunica3;
                decimal _valor_IPTU = _calc.Valoriptu;
                decimal _valor_ITU = _calc.Valoritu;
                decimal _area_predial = _calc.Areapredial;
                decimal _area_terreno = _calc.Areaterreno;
                decimal _testada = _calc.Testadaprinc;
                decimal _fcat = _calc.Fcat, _fped = _calc.Fped, _fsit = _calc.Fsit, _fpro = _calc.Fpro, _ftop = _calc.Ftop, _fdis = _calc.Fdis, _fgle = _calc.Fgle;
                decimal _agrupamento = _calc.Agrupamento, _fracao = _calc.Fracao, _aliquota = _calc.Aliquota;

                _qtde_laminas += _qtde_parcela + 3;

                int _tributo = _vvp == 0 ? 2 : 1;
                switch (_tipo_isencao) {
                    case 0:
                        _qtde_normal += 1;
                        _valor_ci_normal += _calc.Valorfinal;
                        _valor_si_normal += _calc.Valorfinalfull;
                        break;
                    case 1:
                        _qtde_imune += 1;
                        _valor_si_imune += _calc.Valorfinalfull;
                        break;
                    case 2:
                        _qtde_isento_area += 1;
                        _valor_si_isento_area += _calc.Valorfinalfull;
                        break;
                    case 3:
                        _qtde_isento_processo += 1;
                        _valor_si_isento_processo += _calc.Valorfinalfull;
                        break;
                    default:
                        break;
                }
                _qtde_total = _qtde_normal + _qtde_imune + _qtde_isento_area + _qtde_isento_processo;
                _valor_ci_total = _valor_ci_normal + _valor_ci_imune + _valor_ci_isento_area + _valor_ci_isento_processo;
                _valor_si_total = _valor_si_normal + _valor_si_imune + _valor_si_isento_area + _valor_si_isento_processo;

                if (_tipo_isencao == 0 || (_tipo_isencao == 3 && _perc_Isencao < 100)) {

                    //parcelas únicas
                    string _linha = Codigo + "#" + _ano + "#1#0#0#0#18#" + aVencimento[0].ToString("dd/MM/yyyy") + "#01/01/" + _ano;
                    fs1.WriteLine(_linha);
                    _linha = Codigo + "#" + _ano + "#1#0#0#0#" + _tributo.ToString() + "#" + _valor_unica.ToString("#0.00");
                    fs2.WriteLine(_linha);
                    _linha = Codigo + "#" + _ano + "#1#0#0#0#" + _documento;
                    fs3.WriteLine(_linha);
                    _linha = _documento + "#" + DateTime.Now.ToString("dd/MM/yyyy");
                    fs4.WriteLine(_linha);
                    aDocumento[0]=_documento.ToString();
                    _valor0 = _valor_unica.ToString("#0.00");
                    _documento++;

                    if (_Prm.Descontounica2 != null) {
                        _linha = Codigo + "#" + _ano + "#1#0#0#91#18#" + aVencimento[1].ToString("dd/MM/yyyy") + "#01/01/" + _ano;
                        fs1.WriteLine(_linha);
                        _linha = Codigo + "#" + _ano + "#1#0#0#91#" + _tributo.ToString() + "#" + _valor_unica2.ToString("#0.00");
                        fs2.WriteLine(_linha);
                        _linha = Codigo + "#" + _ano + "#1#0#0#91#" + _documento;
                        fs3.WriteLine(_linha);
                        _linha = _documento + "#" + DateTime.Now.ToString("dd/MM/yyyy");
                        fs4.WriteLine(_linha);
                        _valor91 = _valor_unica2.ToString("#0.00");
                        aDocumento[13] = _documento.ToString();
                        _documento++;
                    }

                    if (_Prm.Descontounica3 != null) {
                        _linha = Codigo + "#" + _ano + "#1#0#0#92#18#" + aVencimento[2].ToString("dd/MM/yyyy") + "#01/01/" + _ano;
                        fs1.WriteLine(_linha);
                        _linha = Codigo + "#" + _ano + "#1#0#0#92#" + _tributo.ToString() + "#" + _valor_unica3.ToString("#0.00");
                        fs2.WriteLine(_linha);
                        _linha = Codigo + "#" + _ano + "#1#0#0#92#" + _documento;
                        fs3.WriteLine(_linha);
                        _linha = _documento + "#" + DateTime.Now.ToString("dd/MM/yyyy");
                        fs4.WriteLine(_linha);
                        _valor92 = _valor_unica3.ToString("#0.00");
                        aDocumento[14] = _documento.ToString();
                        _documento++;
                    }

                    //parcelas normais
                    for (int _parcela = 1; _parcela <= _qtde_parcela; _parcela++) {
                        string _vencto = aVencimento[_parcela - 1].ToString("dd/MM/yyyy");
                        _linha = Codigo + "#" + _ano + "#1#0#" + _parcela + "#0#18#" + _vencto + "#01/01/" + _ano;
                        fs1.WriteLine(_linha);
                        _linha = Codigo + "#" + _ano + "#1#0#" + _parcela + "#0#" + _tributo.ToString() + "#" + _valor_parcela.ToString("#0.00");
                        fs2.WriteLine(_linha);
                        _linha = Codigo + "#" + _ano + "#1#0#" + _parcela + "#0#" + _documento;
                        fs3.WriteLine(_linha);
                        _linha = _documento + "#" + DateTime.Now.ToString("dd/MM/yyyy");
                        fs4.WriteLine(_linha);

                        _valor1 = _valor_parcela.ToString("#0.00");
                        aDocumento[_parcela] = _documento.ToString();

                        _documento++;
                    }

                    //grava cálculo
                    string _linha_calc = _ano.ToString() + "#" + Codigo + "#1#" + _qtde_parcela.ToString() + "#" +  _valor0 + "#" + _valor1 + "#" + _valor91 + "#" + _valor92 + "#";
                    _linha_calc += aDocumento[0] + "#" + aDocumento[13] + "#" + aDocumento[14] + "#" ;
                    for (int i = 1; i <= _qtde_parcela; i++) {
                        _linha_calc += aDocumento[i] + "#" + aVencimento[i - 1].ToString("dd/MM/yyyy") + "#";
                    }
                    _linha_calc = _linha_calc.Substring(0, _linha_calc.Length - 1);
                    fs5.WriteLine(_linha_calc);

                    //grava laseriptu
                    _linha_calc = _ano.ToString() + "#" + Codigo + "#" + _vvt.ToString("#0.00") + "#" + _vvp.ToString("#0.00") + "#" + _vvi.ToString("#0.00") + "#" + _valor_IPTU.ToString("#0.00") + "#" + _valor_ITU.ToString("#0.00") + "#";
                    _linha_calc += _natureza + "#" + _area_predial + "#" + _testada + "#" +  _valor1 + "#" +_valor0 + "#" + _valor91 + "#" + _valor92 + "#" + _qtde_parcela + "#0#0#" + _area_terreno.ToString("#0.00") + "#";
                    _linha_calc += _fcat.ToString("#0.00") + "#" + _fped.ToString("#0.00") + "#" + _fsit.ToString("#0.00") + "#" + _fpro.ToString("#0.00") + "#" + _ftop.ToString("#0.00") + "#" + _fdis.ToString("#0.00") + "#";
                    _linha_calc += _fgle.ToString("#0.00") + "#" + _agrupamento.ToString("#0.00") + "#" + _fracao.ToString("#0.00") + "#" + _aliquota.ToString("#0.00") ;

                    fs6.WriteLine(_linha_calc);
                }
                _pos++;
            }

            fs1.Close(); fs2.Close(); fs3.Close(); fs4.Close(); fs5.Close(); fsDP.Close(); fsDT.Close(); fsND.Close(); fsPD.Close(); fsCC.Close();
            PBar.Value = 100;
            PBar.Update();

            MsgToolStrip.Text = "Selecione uma opção de cálculo";
            QtdeNormal.Text = _qtde_normal.ToString("00000");
            QtdeImune.Text = _qtde_imune.ToString("00000");
            QtdeIsentoArea.Text = _qtde_isento_area.ToString("00000");
            QtdeIsentoProcesso.Text = _qtde_isento_processo.ToString("00000");
            QtdeLamina.Text = _qtde_laminas.ToString("000000");
            QtdeTotal.Text = _qtde_total.ToString("00000");
            Valor_ci_Normal.Text = _valor_ci_normal.ToString("#0.00");
            Valor_si_Normal.Text = _valor_si_normal.ToString("#0.00");
            Valor_si_IsentoArea.Text = _valor_si_isento_area.ToString("#0.00");
            Valor_si_IsentoProcesso.Text = _valor_si_isento_processo.ToString("#0.00");
            Valor_si_Imune.Text = _valor_si_imune.ToString("#0.00");
            Valor_si_Total.Text = _valor_si_total.ToString("#0.00");
            Valor_ci_Total.Text = _valor_ci_total.ToString("#0.00");

            Refresh();
            MessageBox.Show("Cálculo finalizado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Calculo_IssTLL() {

            _ipca = (decimal)3.5116;
            FileStream fsDP = new FileStream(_path + "DEBITOPARCELA.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs1 = new StreamWriter(fsDP, System.Text.Encoding.Default);
            FileStream fsDT = new FileStream(_path + "DEBITOTRIBUTO.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs2 = new StreamWriter(fsDT, System.Text.Encoding.Default);
            FileStream fsPD = new FileStream(_path + "PARCELADOCUMENTO.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs3 = new StreamWriter(fsPD, System.Text.Encoding.Default);
            FileStream fsND = new FileStream(_path + "NUMDOCUMENTO.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs4 = new StreamWriter(fsND, System.Text.Encoding.Default);
            FileStream fsCC = new FileStream(_path + "CALCULO_RESUMO.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs5 = new StreamWriter(fsCC, System.Text.Encoding.Default);

            MsgToolStrip.Text = "Calculando ISS Fixo/Taxa de Licença";
            List<DateTime> aVencimento = new List<DateTime>();
            List<decimal> aDesconto = new List<decimal>();
            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            Paramparcela _Prm = tributario_Class.Retorna_Parametro_Parcela(_ano, (int)Tipo_imposto.ISS_Fixo_TLL);
            if (_Prm.Venc01 != null) {
                aVencimento.Add((DateTime)_Prm.Venc01);
                if (_Prm.Descontounica != null)
                    aDesconto.Add((decimal)_Prm.Descontounica);
                if (_Prm.Venc02 != null) {
                    aVencimento.Add((DateTime)_Prm.Venc02);
                    if (_Prm.Descontounica2 != null)
                        aDesconto.Add((decimal)_Prm.Descontounica2);
                    if (_Prm.Venc03 != null) {
                        aVencimento.Add((DateTime)_Prm.Venc03);
                        if (_Prm.Descontounica3 != null)
                            aDesconto.Add((decimal)_Prm.Descontounica3);
                        if (_Prm.Venc04 != null) {
                            aVencimento.Add((DateTime)_Prm.Venc04);
                        }
                    }
                }
            }

            int _qtde_parcelas = aVencimento.Count;
            bool _unica = _Prm.Parcelaunica == "S" ? true : false;
            
            decimal _valor_vistoria = tributario_Class.Retorna_Valor_Tributo(_ano, 24);
            decimal _valor_vistoria_parcelado = _valor_vistoria / _qtde_parcelas;

            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            List<EmpresaStruct> ListaEmpresas = empresa_Class.Lista_Empresas_Taxa_Licenca();
            List<Mobiliarioatividadeiss> ListaEmpresas_ISS_Fixo = empresa_Class.Lista_Empresas_ISS_Fixo();
            int _total = ListaEmpresas.Count, _pos = 1;
            string _documento0 = "", _documento1 = "", _documento2 = "", _documento3 = "", _valor0 = "", _valor1 = "";
            string _vencimento0 = "", _vencimento1 = "", _vencimento2 = "", _vencimento3 = "";
            decimal _valor_aliquota = 0;

            foreach (EmpresaStruct item in ListaEmpresas) {
                bool _possui_taxa = false;
                bool _vistoria = item.Vistoria == 1 ? true : false;
                decimal _area = item.Area == null ? 0 : (decimal)item.Area;
                int Codigo = item.Codigo;
                if (Codigo == 100006)
                    _possui_taxa = false;

                int _codigo_aliquota = item.Codigo_aliquota == null ? 0 : (int)item.Codigo_aliquota;
                switch (_codigo_aliquota) {
                    case 0:;
                        break;
                    case 1:
                        _valor_aliquota = item.Valor_aliquota1==null?0:(decimal)item.Valor_aliquota1;
                        break;
                    case 2:
                        _valor_aliquota = item.Valor_aliquota2 == null ? 0 : (decimal)item.Valor_aliquota2;
                        break;
                    case 3:
                        _valor_aliquota = item.Valor_aliquota3 == null ? 0 : (decimal)item.Valor_aliquota3;
                        break;
                    default:
                        break;
                }

                int _qtdeISS = 0;
                decimal _valor_aliquota_ISS = 0;
                foreach (Mobiliarioatividadeiss itemISS in ListaEmpresas_ISS_Fixo) {
                    if (itemISS.Codmobiliario == Codigo) {
                        _qtdeISS = itemISS.Qtdeiss == 0 ? 1 : itemISS.Qtdeiss;
                        _valor_aliquota_ISS += (itemISS.Valoriss * _qtdeISS * _ipca);
                    }
                }

                //Limitante de área
                if (_area > 27000 && _valor_aliquota == (decimal)0.29)
                    _area = 27000;
                else {
                    if (_area > 9000 && (_valor_aliquota == (decimal)0.58 || _valor_aliquota == (decimal)0.36))
                        _area = 9000;
                    else {
                        if (_area > 6000 && (_valor_aliquota == (decimal)0.72 || _valor_aliquota == (decimal)0.86))
                            _area = 6000;
                    }
                }

                _valor_aliquota *= _ipca;
                if (_valor_aliquota < 14)
                    _valor_aliquota *= _area;

                if (_valor_aliquota == 0 ) {
                    _possui_taxa = false;
                } else
                    _possui_taxa = true;


                for (int _parcela = 0; _parcela <= _qtde_parcelas; _parcela++) {
                    string _vencto = _parcela == 0 ? aVencimento[0].ToString("dd/MM/yyyy") : aVencimento[_parcela - 1].ToString("dd/MM/yyyy");
                    string _linha = Codigo + "#" + _ano + "#6#0#" + _parcela + "#0#18#" + _vencto + "#01/01/" + _ano;
                    fs1.WriteLine(_linha);
                    
                    decimal _valor = _valor_aliquota/3, _valor_unica = (_valor_aliquota) - ((_valor_aliquota) * (decimal)0.05);
                    decimal _valor_parcela = _parcela > 0 ? _valor : _valor_unica;
                    decimal _valor_boleto_parcela = _valor_parcela, _valor_boleto_unica = _valor_unica;
                    if (_valor_parcela > 0) {
                        _linha = Codigo + "#" + _ano + "#6#0#" + _parcela + "#0#14#" + _valor_parcela.ToString("#0.00");
                        fs2.WriteLine(_linha);
                    }
                    //if (_vistoria) {
                    //    decimal _valor_vistoria_tmp = _parcela == 0 ? _valor_vistoria-(_valor_vistoria * (decimal)0.05) : _valor_vistoria_parcelado;
                    //    _linha = item.Codigo + "#" + _ano + "#6#0#" + _parcela + "#0#24#" + _valor_vistoria_tmp.ToString("#0.00");
                    //    fs2.WriteLine(_linha);
                    //    _valor_boleto_parcela += _valor_vistoria_parcelado; _valor_boleto_unica += _valor_vistoria_tmp;
                    //}

                    if (_possui_taxa) {
                        _linha = Codigo + "#" + _ano + "#6#0#" + _parcela + "#0#" + _documento;
                        fs3.WriteLine(_linha);
                        _linha = _documento + "#" + DateTime.Now.ToString("dd/MM/yyyy");
                        fs4.WriteLine(_linha);
                    }


                    if (_valor_aliquota_ISS > 0  ) {
                        _linha = Codigo + "#" + _ano + "#14#0#" + _parcela + "#0#18#" + _vencto + "#01/01/" + _ano;
                        fs1.WriteLine(_linha);

                        _valor = _valor_aliquota_ISS / 3;
                        _valor_unica = (_valor_aliquota_ISS ) - ((_valor_aliquota_ISS ) * (decimal)0.05);
                        _valor_parcela = _parcela > 0 ? _valor : _valor_unica;
                        _valor_boleto_parcela += _valor_parcela; _valor_boleto_unica += _valor_unica;
                        _linha = Codigo + "#" + _ano + "#14#0#" + _parcela + "#0#11#" + _valor_parcela.ToString("#0.00");
                        fs2.WriteLine(_linha);
                        if (!_possui_taxa) {
                            _linha = Codigo + "#" + _ano + "#14#0#" + _parcela + "#0#" + _documento;
                            fs3.WriteLine(_linha);

                            _linha = _documento + "#" + DateTime.Now.ToString("dd/MM/yyyy");
                            fs4.WriteLine(_linha);
                        } else {
                            _linha = Codigo + "#" + _ano + "#14#0#" + _parcela + "#0#" + _documento;
                            fs3.WriteLine(_linha);
                        }
                    }

                    switch (_parcela) {
                        case 0:
                            _documento0 = _documento.ToString();
                            _vencimento0 = _vencto.ToString();
                            _valor0 = _valor_boleto_unica.ToString("#0.00");
                            break;
                        case 1:
                            _documento1 = _documento.ToString();
                            _vencimento1 = _vencto.ToString();
                            _valor1 = _valor_boleto_parcela.ToString("#0.00");
                            break;
                        case 2:
                            _documento2 = _documento.ToString();
                            _vencimento2 = _vencto.ToString();
                            break;
                        case 3:
                            _documento3 = _documento.ToString();
                            _vencimento3 = _vencto.ToString();
                            break;
                        default:
                            break;
                    }

                    _documento++;
                }

                string _linha_calc = _ano.ToString() + "#" + Codigo + "#6#" + _qtde_parcelas.ToString() + "#" + _valor0 + "#" + _valor1 + "#0#0#" +
                _documento0 + "#0#0#" + _documento1 + "#" + _vencimento1 + "#" + _documento2 + '#' + _vencimento2 + "#" + _documento3 + "#" +
                _vencimento3  ;
                fs5.WriteLine(_linha_calc);

                _pos++;
            }

            fs1.Close(); fs2.Close(); fs3.Close(); fs4.Close(); fs5.Close(); fsDP.Close(); fsDT.Close(); fsND.Close(); fsPD.Close(); fsCC.Close();
            PBar.Value = 100;
            PBar.Update();
            MsgToolStrip.Text = "Selecione uma opção de cálculo";
            Refresh();
            MessageBox.Show("Cálculo finalizado.", "Infiormação", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Calculo_Vigilancia() {
            FileStream fsDP = new FileStream(_path + "DEBITOPARCELA.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs1 = new StreamWriter(fsDP, System.Text.Encoding.Default);
            FileStream fsDT = new FileStream(_path + "DEBITOTRIBUTO.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs2 = new StreamWriter(fsDT, System.Text.Encoding.Default);
            FileStream fsPD = new FileStream(_path + "PARCELADOCUMENTO.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs3 = new StreamWriter(fsPD, System.Text.Encoding.Default);
            FileStream fsND = new FileStream(_path + "NUMDOCUMENTO.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs4 = new StreamWriter(fsND, System.Text.Encoding.Default);
            FileStream fsCC = new FileStream(_path + "CALCULO_RESUMO.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs5 = new StreamWriter(fsCC, System.Text.Encoding.Default);

            MsgToolStrip.Text = "Calculando vigilância sanitária";
            List<DateTime> aVencimento = new List<DateTime>();
            List<decimal> aDesconto = new List<decimal>();
            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            Paramparcela _Prm = tributario_Class.Retorna_Parametro_Parcela(_ano, (int)Tipo_imposto.Vigilancia);
            if( _Prm.Venc01 != null) {
                aVencimento.Add((DateTime)_Prm.Venc01);
                if(_Prm.Descontounica!=null)
                    aDesconto.Add((decimal)_Prm.Descontounica);
                if (_Prm.Venc02 != null) {
                    aVencimento.Add((DateTime)_Prm.Venc02);
                    if (_Prm.Descontounica2 != null)
                        aDesconto.Add((decimal)_Prm.Descontounica2);
                    if (_Prm.Venc03 != null) {
                        aVencimento.Add((DateTime)_Prm.Venc03);
                        if (_Prm.Descontounica3 != null)
                            aDesconto.Add((decimal)_Prm.Descontounica3);
                        if (_Prm.Venc04 != null) {
                            aVencimento.Add((DateTime)_Prm.Venc04);
                        }
                    }
                }
            }

            int _qtde_parcelas = aVencimento.Count;
            bool _unica = _Prm.Parcelaunica == "S" ? true : false;

            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            List<MobiliariovsStruct> ListaEmpresas = empresa_Class.Lista_Empresas_Vigilancia_Sanitaria();
            List<MobiliariovsStruct> ListaVS = new List<MobiliariovsStruct>();
            foreach (MobiliariovsStruct item in ListaEmpresas) {
                //if (item.Codigo != 303947) {
                //    goto PROXIMO;
                //}

                bool _find = false;
                for (int i = 0; i < ListaVS.Count; i++) {
                    if (item.Codigo == ListaVS[i].Codigo) {
                        _find = true;
                        ListaVS[i].Valor += item.Valor * item.Qtde;
                        break;
                    }
                }
                
                if (!_find) {
                    MobiliariovsStruct reg = new MobiliariovsStruct();
                    reg.Codigo = item.Codigo;
                    reg.Qtde = item.Qtde;
                    reg.Valor = item.Valor * item.Qtde ;
                    ListaVS.Add(reg);
                }
//PROXIMO:;
            }

            int _total = ListaVS.Count, _pos = 1;
            string _documento0="", _documento1="", _documento2="", _documento3="", _documento4="", _valor0="", _valor1="";
            string _vencimento0="", _vencimento1="", _vencimento2="", _vencimento3="", _vencimento4="";

            foreach (MobiliariovsStruct item in ListaVS) {
               
                if (_pos % 10 == 0) {
                    PBar.Value = _pos * 100 / _total;
                    PBar.Update();
                    Refresh();
                    Application.DoEvents();
                }

                for (int _parcela = 0; _parcela <= _qtde_parcelas; _parcela++) {
                    string _vencto =  _parcela==0 ? aVencimento[0].ToString("dd/MM/yyyy"):   aVencimento[_parcela-1].ToString("dd/MM/yyyy");
                    string _linha = item.Codigo + "#" + _ano + "#13#0#" + _parcela + "#0#18#" + _vencto + "#01/01/" + _ano ;
                    fs1.WriteLine(_linha);
                    decimal _valor = Convert.ToDecimal(item.Valor)/_qtde_parcelas, _valor_unica = (Convert.ToDecimal(item.Valor) - (Convert.ToDecimal(item.Valor) * (decimal)0.05)) ;
                    decimal _valor_parcela = _parcela > 0 ? _valor : _valor_unica;
                    //_valor_parcela = _valor_parcela ;
                    _linha = item.Codigo + "#" + _ano + "#13#0#" + _parcela + "#0#25#" +  _valor_parcela.ToString("#0.00") ;
                    fs2.WriteLine(_linha);
                    _linha = item.Codigo + "#" + _ano + "#13#0#" + _parcela + "#0#" + _documento;
                    fs3.WriteLine(_linha);
                    _linha = _documento + "#" + DateTime.Now.ToString("dd/MM/yyyy");
                    fs4.WriteLine(_linha);

                    switch (_parcela) {
                        case 0:
                            _documento0 = _documento.ToString();
                            _vencimento0 = _vencto.ToString();
                            _valor0 = _valor_parcela.ToString("#0.00");
                            break;
                        case 1:
                            _documento1 = _documento.ToString();
                            _vencimento1 = _vencto.ToString();
                            _valor1 = _valor_parcela.ToString("#0.00");
                            break;
                        case 2:
                            _documento2 = _documento.ToString();
                            _vencimento2 = _vencto.ToString();
                            break;
                        case 3:
                            _documento3 = _documento.ToString();
                            _vencimento3 = _vencto.ToString();
                            break;
                        case 4:
                            _documento4 = _documento.ToString();
                            _vencimento4 = _vencto.ToString();
                            break;
                        default:
                            break;
                    }

                    _documento++;
                }

                string _linha_calc = _ano.ToString() + "#" + item.Codigo + "#13#" + _qtde_parcelas.ToString() + "#" + _valor0 + "#" + _valor1 + "#0#0#" +
                _documento0 + "#0#0#" + _documento1 + "#" + _vencimento1 + "#" + _documento2 + '#' + _vencimento2 ;
                fs5.WriteLine(_linha_calc);


                _pos++;
            }

            fs1.Close(); fs2.Close(); fs3.Close(); fs4.Close();fs5.Close() ; fsDP.Close(); fsDT.Close(); fsND.Close(); fsPD.Close();fsCC.Close();
            PBar.Value = 100;
            PBar.Update();
            MsgToolStrip.Text = "Selecione uma opção de cálculo";
            Refresh();
            MessageBox.Show("Cálculo finalizado.","Infiormação",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void ExportarButton_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Exportar para o banco de dados?", "Confimação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            Tributario_bll tributario_Class = new Tributario_bll(_connection);

            #region DEBITOPARCELA
            MsgToolStrip.Text = "Inserindo parcelas";
            Refresh();

            DataTable dt = new DataTable();
            dt.Columns.Add("codreduzido", typeof(int));
            dt.Columns.Add("anoexercicio", typeof(short));
            dt.Columns.Add("codlancamento", typeof(short));
            dt.Columns.Add("seqlancamento", typeof(short));
            dt.Columns.Add("numparcela", typeof(byte));
            dt.Columns.Add("codcomplemento", typeof(byte));
            dt.Columns.Add("statuslanc", typeof(byte));
            dt.Columns.Add("datavencimento", typeof(DateTime));
            dt.Columns.Add("datadebase", typeof(DateTime));

            FileStream fs = new FileStream(_path + "DEBITOPARCELA.TXT", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
            while (!sr.EndOfStream) {
                string _line = sr.ReadLine();
                string[] _fields = _line.Split('#');
                DataRow _row = dt.NewRow();
                _row["codreduzido"] = Convert.ToInt32(_fields[0]);
                _row["anoexercicio"] = Convert.ToInt16(_fields[1]);
                _row["codlancamento"] = Convert.ToInt16(_fields[2]);
                _row["seqlancamento"] = Convert.ToInt16(_fields[3]);
                _row["numparcela"] = Convert.ToByte(_fields[4]);
                _row["codcomplemento"] = Convert.ToByte(_fields[5]);
                _row["statuslanc"] = Convert.ToByte(_fields[6]);
                _row["datavencimento"] =Convert.ToDateTime( _fields[7]);
                _row["datadebase"] = Convert.ToDateTime(_fields[8]);
                dt.Rows.Add(_row);
            }

            SqlBulkCopy sbc = new SqlBulkCopy(_connection);
            sbc.BulkCopyTimeout = 0;
            sbc.DestinationTableName = "DEBITOPARCELA";
            sbc.WriteToServer(dt);
            sbc.Close();
            dt.Dispose(); fs.Close(); sr.Close();

            MsgToolStrip.Text = "Inserindo tributos";
            Refresh();
            #endregion

            #region DEBITOTRIBUTO
            MsgToolStrip.Text = "Inserindo tributos";
            Refresh();

            dt = new DataTable();
            dt.Columns.Add("codreduzido", typeof(int));
            dt.Columns.Add("anoexercicio", typeof(short));
            dt.Columns.Add("codlancamento", typeof(short));
            dt.Columns.Add("seqlancamento", typeof(short));
            dt.Columns.Add("numparcela", typeof(byte));
            dt.Columns.Add("codcomplemento", typeof(byte));
            dt.Columns.Add("codtributo", typeof(short));
            dt.Columns.Add("valortributo", typeof(decimal));

            fs = new FileStream(_path + "DEBITOTRIBUTO.TXT", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs, System.Text.Encoding.Default);
            while (!sr.EndOfStream) {
                string _line = sr.ReadLine();
                string[] _fields = _line.Split('#');
                DataRow _row = dt.NewRow();
                _row["codreduzido"] = Convert.ToInt32(_fields[0]);
                _row["anoexercicio"] = Convert.ToInt16(_fields[1]);
                _row["codlancamento"] = Convert.ToInt16(_fields[2]);
                _row["seqlancamento"] = Convert.ToInt16(_fields[3]);
                _row["numparcela"] = Convert.ToByte(_fields[4]);
                _row["codcomplemento"] = Convert.ToByte(_fields[5]);
                _row["codtributo"] = Convert.ToInt16(_fields[6]);
                _row["valortributo"] = Convert.ToDecimal(_fields[7]);
                dt.Rows.Add(_row);
            }

            sbc = new SqlBulkCopy(_connection);
            sbc.BulkCopyTimeout = 0;
            sbc.DestinationTableName = "DEBITOTRIBUTO";
            sbc.WriteToServer(dt);
            sbc.Close();
            dt.Dispose(); fs.Close(); sr.Close();

            #endregion

            #region PARCELADOCUMENTO
            MsgToolStrip.Text = "Inserindo parcelas por documento";
            Refresh();

            dt = new DataTable();
            dt.Columns.Add("codreduzido", typeof(int));
            dt.Columns.Add("anoexercicio", typeof(short));
            dt.Columns.Add("codlancamento", typeof(short));
            dt.Columns.Add("seqlancamento", typeof(short));
            dt.Columns.Add("numparcela", typeof(byte));
            dt.Columns.Add("codcomplemento", typeof(byte));
            dt.Columns.Add("numdocumento", typeof(int));

            fs = new FileStream(_path + "PARCELADOCUMENTO.TXT", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs, System.Text.Encoding.Default);
            while (!sr.EndOfStream) {
                string _line = sr.ReadLine();
                string[] _fields = _line.Split('#');
                DataRow _row = dt.NewRow();
                _row["codreduzido"] = Convert.ToInt32(_fields[0]);
                _row["anoexercicio"] = Convert.ToInt16(_fields[1]);
                _row["codlancamento"] = Convert.ToInt16(_fields[2]);
                _row["seqlancamento"] = Convert.ToInt16(_fields[3]);
                _row["numparcela"] = Convert.ToByte(_fields[4]);
                _row["codcomplemento"] = Convert.ToByte(_fields[5]);
                _row["numdocumento"] = Convert.ToInt32(_fields[6]);
                dt.Rows.Add(_row);
            }

            sbc = new SqlBulkCopy(_connection);
            sbc.BulkCopyTimeout = 0;
            sbc.DestinationTableName = "PARCELADOCUMENTO";
            sbc.WriteToServer(dt);
            sbc.Close();
            dt.Dispose(); sr.Close(); fs.Close();

            #endregion

            #region NUMDOCUMENTO
            MsgToolStrip.Text = "Inserindo números de documento";
            Refresh();

            dt = new DataTable();
            dt.Columns.Add("numdocumento", typeof(int));
            dt.Columns.Add("datadocumento", typeof(DateTime));

            fs = new FileStream(_path + "NUMDOCUMENTO.TXT", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs, System.Text.Encoding.Default);
            while (!sr.EndOfStream) {
                string _line = sr.ReadLine();
                string[] _fields = _line.Split('#');
                DataRow _row = dt.NewRow();
                _row["numdocumento"] = Convert.ToInt32(_fields[0]);
                _row["datadocumento"] = Convert.ToDateTime(_fields[1]);
                dt.Rows.Add(_row);
            }

            sbc = new SqlBulkCopy(_connection);
            sbc.BulkCopyTimeout = 0;
            sbc.DestinationTableName = "NUMDOCUMENTO";
            sbc.WriteToServer(dt);
            sbc.Close();
            dt.Dispose(); sr.Close(); fs.Close();

            #endregion

            #region CALCULO_RESUMO
            MsgToolStrip.Text = "Gravando cálculo";
            Refresh();

            dt = new DataTable();
            dt.Columns.Add("ano", typeof(short));
            dt.Columns.Add("codigo", typeof(int));
            dt.Columns.Add("lancamento", typeof(short));
            dt.Columns.Add("qtde_parcela", typeof(byte));
            dt.Columns.Add("valor0", typeof(decimal));
            dt.Columns.Add("valor1", typeof(decimal));
            dt.Columns.Add("valor91", typeof(decimal));
            dt.Columns.Add("valor92", typeof(decimal));
            dt.Columns.Add("documento0", typeof(int));
            dt.Columns.Add("documento91", typeof(int));
            dt.Columns.Add("documento92", typeof(int));
            dt.Columns.Add("documento1", typeof(int));
            dt.Columns.Add("vencimento1", typeof(DateTime));
            dt.Columns.Add("documento2", typeof(int));
            dt.Columns.Add("vencimento2", typeof(DateTime));
            dt.Columns.Add("documento3", typeof(int));
            dt.Columns.Add("vencimento3", typeof(DateTime));
            dt.Columns.Add("documento4", typeof(int));
            dt.Columns.Add("vencimento4", typeof(DateTime));
            dt.Columns.Add("documento5", typeof(int));
            dt.Columns.Add("vencimento5", typeof(DateTime));
            dt.Columns.Add("documento6", typeof(int));
            dt.Columns.Add("vencimento6", typeof(DateTime));
            dt.Columns.Add("documento7", typeof(int));
            dt.Columns.Add("vencimento7", typeof(DateTime));
            dt.Columns.Add("documento8", typeof(int));
            dt.Columns.Add("vencimento8", typeof(DateTime));
            dt.Columns.Add("documento9", typeof(int));
            dt.Columns.Add("vencimento9", typeof(DateTime));
            dt.Columns.Add("documento10", typeof(int));
            dt.Columns.Add("vencimento10", typeof(DateTime));
            dt.Columns.Add("documento11", typeof(int));
            dt.Columns.Add("vencimento11", typeof(DateTime));
            dt.Columns.Add("documento12", typeof(int));
            dt.Columns.Add("vencimento12", typeof(DateTime));


            fs = new FileStream(_path + "CALCULO_RESUMO.TXT", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs, System.Text.Encoding.Default);
            while (!sr.EndOfStream) {
                string _line = sr.ReadLine();
                string[] _fields = _line.Split('#');
                DataRow _row = dt.NewRow();
                _row["ano"] = Convert.ToInt16( _fields[0]);
                _row["codigo"] = Convert.ToInt32(_fields[1]);
                _row["lancamento"] = Convert.ToInt16(_fields[2]);
                _row["qtde_parcela"] = Convert.ToByte(_fields[3]);
                _row["valor0"] = Convert.ToDecimal(_fields[4]);
                _row["valor1"] = Convert.ToDecimal(_fields[5]);
                _row["valor91"] = Convert.ToDecimal(_fields[6]==""?"0": _fields[6]);
                _row["valor92"] = Convert.ToDecimal(_fields[7] == "" ? "0" : _fields[7]);
                _row["documento0"] = Convert.ToInt32(_fields[8] == "" ? "0" : _fields[8]);
                _row["documento91"] = Convert.ToInt32(_fields[9] == "" ? "0" : _fields[9]);
                _row["documento92"] = Convert.ToInt32(_fields[10] == "" ? "0" : _fields[10]);
                _row["documento1"] = Convert.ToInt32(_fields[11] == "" ? "0" : _fields[11]);
                _row["vencimento1"] = Convert.ToDateTime(_fields[12] == "" ? "0" : _fields[12]);
                if (_fields.Length > 13) {
                    _row["documento2"] = Convert.ToInt32(_fields[13]);
                    _row["vencimento2"] = Convert.ToDateTime(_fields[14]);
                }
                if (_fields.Length>15) {
                    _row["documento3"] = Convert.ToInt32(_fields[15]);
                    _row["vencimento3"] = Convert.ToDateTime(_fields[16]);
                }
                if (_fields.Length>17) {
                    _row["documento4"] = Convert.ToInt32(_fields[17]);
                    _row["vencimento4"] = Convert.ToDateTime(_fields[18]);
                }
                if (_fields.Length>19) {
                    _row["documento5"] = Convert.ToInt32(_fields[19]);
                    _row["vencimento5"] = Convert.ToDateTime(_fields[20]);
                }
                if (_fields.Length>21) {
                    _row["documento6"] = Convert.ToInt32(_fields[21]);
                    _row["vencimento6"] = Convert.ToDateTime(_fields[22]);
                }
                if (_fields.Length>23) {
                    _row["documento7"] = Convert.ToInt32(_fields[23]);
                    _row["vencimento7"] = Convert.ToDateTime(_fields[24]);
                }
                if (_fields.Length>25) {
                    _row["documento8"] = Convert.ToInt32(_fields[25]);
                    _row["vencimento8"] = Convert.ToDateTime(_fields[26]);
                }
                if (_fields.Length>27) {
                    _row["documento9"] = Convert.ToInt32(_fields[27]);
                    _row["vencimento9"] = Convert.ToDateTime(_fields[28]);
                }
                if (_fields.Length>29) {
                    _row["documento10"] = Convert.ToInt32(_fields[29]);
                    _row["vencimento10"] = Convert.ToDateTime(_fields[30]);
                }
                if (_fields.Length>31) {
                    _row["documento11"] = Convert.ToInt32(_fields[31]);
                    _row["vencimento11"] = Convert.ToDateTime(_fields[32]);
                }
                if (_fields.Length>33) {
                    _row["documento12"] = Convert.ToInt32(_fields[33]);
                    _row["vencimento12"] = Convert.ToDateTime(_fields[34]);
                }

                dt.Rows.Add(_row);
            }

            sbc = new SqlBulkCopy(_connection);
            sbc.BulkCopyTimeout = 0;
            sbc.DestinationTableName = "CALCULO_RESUMO";
            sbc.WriteToServer(dt);
            sbc.Close();
            dt.Dispose(); sr.Close(); fs.Close();

            #endregion

            #region LASERIPTU
            if (ImpostoList.SelectedIndex == 0) {
                MsgToolStrip.Text = "Inserindo LaserIPTU";
                Refresh();

                dt = new DataTable();
                dt.Columns.Add("ano", typeof(short));
                dt.Columns.Add("codreduzido", typeof(int));
                dt.Columns.Add("vvt", typeof(decimal));
                dt.Columns.Add("vvc", typeof(decimal));
                dt.Columns.Add("vvi", typeof(decimal));
                dt.Columns.Add("impostopredial", typeof(decimal));
                dt.Columns.Add("impostoterritorial", typeof(decimal));
                dt.Columns.Add("natureza", typeof(string));
                dt.Columns.Add("areaconstrucao", typeof(decimal));
                dt.Columns.Add("testadaprinc", typeof(decimal));
                dt.Columns.Add("valortotalparc", typeof(decimal));
                dt.Columns.Add("valortotalunica", typeof(decimal));
                dt.Columns.Add("valortotalunica2", typeof(decimal));
                dt.Columns.Add("valortotalunica3", typeof(decimal));
                dt.Columns.Add("qtdeparc", typeof(short));
                dt.Columns.Add("txexpparc", typeof(decimal));
                dt.Columns.Add("txexpunica", typeof(decimal));
                dt.Columns.Add("areaterreno", typeof(decimal));
                dt.Columns.Add("fatorcat", typeof(decimal));
                dt.Columns.Add("fatorped", typeof(decimal));
                dt.Columns.Add("fatorsit", typeof(decimal));
                dt.Columns.Add("fatorpro", typeof(decimal));
                dt.Columns.Add("fatortop", typeof(decimal));
                dt.Columns.Add("fatordis", typeof(decimal));
                dt.Columns.Add("fatorgle", typeof(decimal));
                dt.Columns.Add("agrupamento", typeof(decimal));
                dt.Columns.Add("fracaoideal", typeof(decimal));
                dt.Columns.Add("aliquota", typeof(decimal));

                fs = new FileStream(_path + "LASERIPTU.TXT", FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs, System.Text.Encoding.Default);
                while (!sr.EndOfStream) {
                    string _line = sr.ReadLine();
                    string[] _fields = _line.Split('#');
                    DataRow _row = dt.NewRow();
                    _row["ano"] = Convert.ToInt16(_fields[0]);
                    _row["codreduzido"] = Convert.ToInt32(_fields[1]);
                    _row["vvt"] = Convert.ToDecimal(_fields[2] == "" ? "0" : _fields[2]);
                    _row["vvc"] = Convert.ToDecimal(_fields[3] == "" ? "0" : _fields[3]);
                    _row["vvi"] = Convert.ToDecimal(_fields[4]);
                    _row["impostopredial"] = Convert.ToDecimal(_fields[5]);
                    _row["impostoterritorial"] = Convert.ToDecimal(_fields[6]);
                    _row["natureza"] = _fields[7];
                    _row["areaconstrucao"] = Convert.ToDecimal(_fields[8]);
                    _row["testadaprinc"] = Convert.ToDecimal(_fields[9]);
                    _row["valortotalparc"] = Convert.ToDecimal(_fields[10]);
                    _row["valortotalunica"] = Convert.ToDecimal(_fields[11]);
                    _row["valortotalunica2"] = Convert.ToDecimal(_fields[12] == "" ? "0" : _fields[12]);
                    _row["valortotalunica3"] = Convert.ToDecimal(_fields[13] == "" ? "0" : _fields[13]);
                    _row["qtdeparc"] = Convert.ToInt16(_fields[14]);
                    _row["txexpparc"] = Convert.ToDecimal(_fields[15]);
                    _row["txexpunica"] = Convert.ToDecimal(_fields[16]);
                    _row["areaterreno"] = Convert.ToDecimal(_fields[17]);
                    _row["fatorcat"] = Convert.ToDecimal(_fields[18]);
                    _row["fatorped"] = Convert.ToDecimal(_fields[19]);
                    _row["fatorsit"] = Convert.ToDecimal(_fields[20]);
                    _row["fatorpro"] = Convert.ToDecimal(_fields[21]);
                    _row["fatortop"] = Convert.ToDecimal(_fields[22]);
                    _row["fatordis"] = Convert.ToDecimal(_fields[23]);
                    _row["fatorgle"] = Convert.ToDecimal(_fields[24]);
                    _row["agrupamento"] = Convert.ToDecimal(_fields[25] == "" ? "0" : _fields[25]);
                    _row["fracaoideal"] = Convert.ToDecimal(_fields[26] == "" ? "0" : _fields[26]);
                    _row["aliquota"] = Convert.ToDecimal(_fields[27] == "" ? "0" : _fields[27]);

                    dt.Rows.Add(_row);
                }

                sbc = new SqlBulkCopy(_connection);
                sbc.BulkCopyTimeout = 0;
                sbc.DestinationTableName = "LASERIPTU";
                sbc.WriteToServer(dt);
                sbc.Close();
                dt.Dispose(); fs.Close(); sr.Close();
            }

            #endregion

            MsgToolStrip.Text = "Selecione uma opção de cálculo";
            Refresh();
            MessageBox.Show("Exportação finalizada.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
