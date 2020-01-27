using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Registro_Bancario : Form {
        Encoding ANSI = Encoding.Default;
        StreamWriter sw;
        string _path = AppDomain.CurrentDomain.BaseDirectory + "\\Data";
        string sFileName = "\\cobranca.txt";
        string _connection = gtiCore.Connection_Name();
        int _qtde_registros;

        public Registro_Bancario() {
            InitializeComponent();
            Directory.CreateDirectory(_path);
            TipoList.SelectedIndex = 0;
        }

        private void CalcularButton_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Gerar o arquivo de Registro de Boletos?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            int _tipo = Convert.ToInt32(TipoList.Text.Substring(0, 2));
            sw = new StreamWriter(_path+sFileName, false, ANSI);
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            Grava_Header(_tipo);
            if (_tipo== 1){
                Grava_Registro_01();
            }
            Grava_Trailer(_qtde_registros);
            sw.Flush();
            sw.Close();

            Exception ex = sistema_Class.Atualiza_Codigo_Remessa_Cobranca();
            if (ex != null) {
                ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                eBox.ShowDialog();
            }else
                MessageBox.Show("Arquivo gerado com sucesso.","Informação",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void Grava_Header(int _tipo) {
            string _codigo_banco="001", _lote = "0000", _tipo_registro = "0", _uso_febraban1 = new String(' ', 9), _tipo_inscricao = "2", _numero_inscricao = "50387844000105";
            string _codigo_convenio, _numero_conta, _dv_conta,_agencia="00269",_dv_agencia="0",_nome_empresa= "PREFEITURA MUN. DE JABOTICABAL".PadRight(30,' '),_densidade="00000";
            string _nome_banco = "BANCO DO BRASIL S.A.".PadRight(30, ' '), _uso_febraban2 = " ".PadRight(10, ' '), _codigo_remessa = "1",_seq_arquivo= "000000",_versao_layout="000";
            string _uso_banco = " ".PadLeft(20, ' '), _uso_empresa = " ".PadLeft(20, ' '), _uso_febraban3 = " ".PadLeft(29, ' ');

            if (_tipo != 5) {
                _codigo_convenio = "2873532".PadLeft(9, '0') + "001417019  ";
                _numero_conta = "74000".PadLeft(12, '0');
                _dv_conta = "4 ";
            } else {
                _codigo_convenio = "2950230".PadLeft(9, '0') + "001417019  ";
                _numero_conta = "34692".PadLeft(12, '0');
                _dv_conta = "6 ";
            }

            string _data_geracao = DateTime.Now.Day.ToString("00")+ DateTime.Now.Month.ToString("00")+ DateTime.Now.Year.ToString("0000");
            string _hora_geracao = DateTime.Now.ToString("HHmmss");

            string _header_file = _codigo_banco + _lote + _tipo_registro + _uso_febraban1 + _tipo_inscricao + _numero_inscricao + _codigo_convenio + _agencia + _dv_agencia;
            _header_file += _numero_conta + _dv_conta + _nome_empresa + _nome_banco + _uso_febraban2 + _codigo_remessa + _data_geracao + _hora_geracao + _seq_arquivo + _versao_layout;
            _header_file += _densidade + _uso_banco + _uso_empresa + _uso_febraban3;

            sw.Write(_header_file + Environment.NewLine);

            //Header lote
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            int _ultima_remessa = sistema_Class.Retorna_Ultima_Remessa_Cobranca()+1;
            _lote = "0001";
            _tipo_registro = "1";
            string _tipo_operacao = "R", _tipo_servico = "01", _numero_versao = "000", _mensagem1 = " ".PadLeft(40, ' '), _mensagem2 = " ".PadLeft(40, ' ');
            string _numero_remessa =_ultima_remessa.ToString().PadLeft(8,'0'), _data_credito= "00000000";

            _uso_febraban1 = "  ";
            _uso_febraban2 = " ";
            _uso_febraban3 = " ".PadLeft(33, ' ');
            _numero_inscricao = "050387844000105";

            string _header_lote = _codigo_banco + _lote + _tipo_registro + _tipo_operacao + _tipo_servico + _uso_febraban1 + _numero_versao + _uso_febraban2 + _tipo_inscricao + _numero_inscricao;
            _header_lote += _codigo_convenio + _agencia + _dv_agencia + _numero_conta + _dv_conta + _nome_empresa + _mensagem1 + _mensagem2 + _numero_remessa + _data_geracao + _data_credito + _uso_febraban3;
            sw.Write(_header_lote + Environment.NewLine);
        }

        private void Grava_Trailer(int _qtde_boletos) {
            int _qtde_registro_lote = (_qtde_boletos * 2) + 2;
            string _codigo_banco = "001", _lote = "0001", _tipo = "5", _uso_febraban1 = " ".PadLeft(9, ' '), _uso_febraban2 = " ".PadLeft(217, ' '), _qtde_registro_lote_str;
            _qtde_registro_lote_str = _qtde_registro_lote.ToString().PadLeft(6, '0');

            string _trailer_lote = _codigo_banco + _lote + _tipo + _uso_febraban1 + _qtde_registro_lote_str + _uso_febraban2;
            sw.Write(_trailer_lote + Environment.NewLine);

            //Trailer Arquivo
            int _qtde_registro_arquivo = _qtde_registro_lote + 2;
            string _qtde_registro_extenso = _qtde_registro_arquivo.ToString().PadLeft(6, '0'),_qtde_lote="1".PadLeft(6,'0'),_qtde_contas="0".PadLeft(6,'0');
            _lote = "9999";
            _tipo = "9";
            _uso_febraban2 = " ".PadLeft(205, ' ');

            string _trailer_arquivo = _codigo_banco + _lote + _tipo + _uso_febraban1 + _qtde_lote + _qtde_registro_extenso + _qtde_contas + _uso_febraban2;
            sw.Write(_trailer_arquivo + Environment.NewLine);
        }

        private void Grava_Registro_01() {
            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            int _contador = 1;
            string _codigo_banco = "001", _lote = "0001", _tipo = "3", _seqreg,_codigo_segmento,_uso_febraban1=" ",_codigo_movimento="01",_agencia="00269",_dvagencia="0";
            string _conta = "74000".PadLeft(12, '0'),_dvconta="4 ",_nosso_numero,_codigo_carteira="7",_forma_cadastro="1",_tipo_documento="1",_id_emissao="2",_id_distribuicao="2";
            string _numero_doc,_data_vencimento,_valor_nominal,_agencia_cobranca="00000",_dv_agencia_cobranca="0",_especie_titulo="01",_aceite="N",_data_emissao,_codigo_juros="0";
            string _data_juros = "0".PadLeft(8, '0'), _juros_mora = "0".PadLeft(15, '0'),_codigo_desconto="0",_data_desconto= "0".PadLeft(8, '0'),_valor_desconto= "0".PadLeft(15, '0');
            string _valor_IOF = "0".PadLeft(15, '0'),_valor_abatimento= "0".PadLeft(15, '0'),_identifica_titulo,_codigo_protesto="3",_dias_protesto="00",_codigo_baixa="0";
            string _dias_baixa = "000", _codigo_moeda = "09",_numero_contrato= "19663033".PadLeft(10,'0'),_uso_livre=" ",_segmentoP,_segmentoQ;

            List<Carta_cobranca> Lista = tributario_Class.Lista_Carta_Cobranca(2);
            _qtde_registros = Lista.Count;
            foreach (Carta_cobranca item in Lista) {
                //*** Segmento P ***
                _codigo_segmento = "P";
                _seqreg = _contador.ToString().PadLeft(5, '0');
                _nosso_numero = item.Nosso_Numero.PadRight(20, ' ');
                _numero_doc= item.Numero_Documento.ToString().PadRight(15, ' ');
                _data_vencimento = item.Data_Vencimento.Day.ToString("00") + item.Data_Vencimento.Month.ToString("00") + item.Data_Vencimento.Year.ToString("0000");
                _valor_nominal = gtiCore.RetornaNumero( item.Valor_Boleto.ToString()).PadLeft(15,'0');
                _data_emissao= item.Data_Documento.Day.ToString("00") + item.Data_Documento.Month.ToString("00") + item.Data_Documento.Year.ToString("0000");
                _identifica_titulo = item.Numero_Documento.ToString().PadRight(25, ' ');


//                if (item.Numero_Documento == 5109804)
 //                   _segmentoP = "h";
                _segmentoP = _codigo_banco + _lote + _tipo + _seqreg + _codigo_segmento + _uso_febraban1 + _codigo_movimento + _agencia + _dvagencia + _conta + _dvconta + _nosso_numero;
                _segmentoP += _codigo_carteira + _forma_cadastro + _tipo_documento + _id_emissao + _id_distribuicao + _numero_doc + _data_vencimento + _valor_nominal + _agencia_cobranca;
                _segmentoP += _dv_agencia_cobranca + _especie_titulo + _aceite + _data_emissao + _codigo_juros + _data_juros + _juros_mora + _codigo_desconto + _data_desconto + _valor_desconto;
                _segmentoP += _valor_IOF + _valor_abatimento + _identifica_titulo + _codigo_protesto + _dias_protesto + _codigo_baixa + _dias_baixa + _codigo_moeda + _numero_contrato + _uso_livre;

                sw.Write(_segmentoP + Environment.NewLine);

                //*** Segmento Q ***
                _contador++;
                string _endereco, _tipo_inscricao, _numero_inscricao, _nome, _bairro, _cep, _cidade,_uf,_tipo_inscricao_sacado="0",_numero_inscricao_sacado;
                string _nome_sacado,_banco_correponde="000",_nosso_numero_banco_corr,_uso_febraban2;

                _seqreg = _contador.ToString().PadLeft(5, '0');
                _codigo_segmento = "Q";
                _tipo_inscricao = item.Cpf_cnpj.Length == 11 ? "1" : "2";
                _numero_inscricao = item.Cpf_cnpj.PadLeft(15,'0');
                _numero_inscricao_sacado = item.Cpf_cnpj.PadLeft(15, '0');
                _nome = item.Nome.Length > 40 ? item.Nome.Substring(0, 40) : item.Nome.PadRight(40, ' ');
                _nome_sacado =  " ".PadRight(40, ' ');
                _nosso_numero_banco_corr = " ".PadRight(20, ' ');
                _uso_febraban2 = " ".PadRight(8, ' ');
                _endereco = item.Endereco.TrimEnd().Length > 40 ? item.Endereco.Substring(0, 40) : item.Endereco.TrimEnd().PadRight(40, ' ');
                _endereco = _endereco.TrimEnd('\r', '\n');
                _bairro = item.Bairro.Length > 15 ? item.Bairro.Substring(0, 15) : item.Bairro.PadRight(15, ' ');
                _cep = gtiCore.RetornaNumero(item.Cep);
                _cep = _cep.Length < 5 ? "00000000":_cep.PadLeft(8,'0');
                _cidade = item.Cidade.Substring(0, item.Cidade.Length - 3);
                _cidade = _cidade.Length > 15 ? _cidade.Substring(0, 15) : _cidade.PadRight(15, ' ');
                _uf = item.Cidade.Substring(item.Cidade.Length - 2, 2);

                _segmentoQ = _codigo_banco + _lote + _tipo + _seqreg + _codigo_segmento + _uso_febraban1 + _codigo_movimento + _tipo_inscricao + _numero_inscricao + _nome;
                _segmentoQ += _endereco + _bairro + _cep + _cidade + _uf + _tipo_inscricao_sacado + _numero_inscricao_sacado + _nome_sacado + _banco_correponde ;
                _segmentoQ+= _nosso_numero_banco_corr+_uso_febraban2;

                sw.Write(_segmentoQ + Environment.NewLine);

                _contador++;
            }

        }

    }
}
