using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Comunicado_Isencao : Form {
        private string _connection = gtiCore.Connection_Name();
        short _remessa = 1;

        public Comunicado_Isencao() {
            InitializeComponent();
        }

        private void PrintButton_Click(object sender, EventArgs e) {
            
//            goto PrintReport;
//          return;
            Imovel_bll imovel_Class = new Imovel_bll(_connection);
            Sistema_bll sistema_Class = new Sistema_bll(_connection);

            List<int> _lista_codigos = imovel_Class.Lista_Comunicado_Isencao();
            int _pos = 1,_total=_lista_codigos.Count;

            foreach (int _codigo in _lista_codigos) {

                if (_pos % 10 == 0) {
                    PBar.Value = _pos * 100 / _total;
                    PBar.Update();
                    Refresh();
                    Application.DoEvents();
                }

                //Dados contribuinte
                string _nome = "", _cpfcnpj = "", _endereco = "", _bairro = "", _cidade = "", _cep = "", _inscricao = "", _lote = "", _quadra = "";
                string  _complemento = "", _complemento_entrega = "", _endereco_entrega = "", _bairro_entrega = "", _cidade_entrega = "", _cep_entrega = "";

                Contribuinte_Header_Struct dados = sistema_Class.Contribuinte_Header(_codigo);
                if (dados == null)
                    goto Proximo;

                _nome = dados.Nome;
                _cpfcnpj = dados.Cpf_cnpj;
                _inscricao = dados.Inscricao;
                _complemento = dados.Complemento == "" ? "" : " " + dados.Complemento;
                _endereco = dados.Endereco + ", " + dados.Numero.ToString() + _complemento;
                _bairro = dados.Nome_bairro;
                _cidade = dados.Nome_cidade + "/" + dados.Nome_uf;
                _cep = dados.Cep;
                _lote = dados.Lote_original;
                _quadra = dados.Quadra_original;

                //Endereço de Entrega
                EnderecoStruct endImovel = imovel_Class.Dados_Endereco(_codigo, dados.TipoEndereco);
                _complemento_entrega = endImovel.Complemento == "" ? "" : " " + endImovel.Complemento;
                _endereco_entrega = endImovel.Endereco + ", " + endImovel.Numero.ToString() + _complemento_entrega;
                _bairro_entrega = endImovel.NomeBairro;
                _cidade_entrega = endImovel.NomeCidade + "/" + endImovel.UF;
                _cep_entrega = endImovel.Cep;

                string _cep_str = gtiCore.RetornaNumero(_cep_entrega);
                int _cep_numero = Convert.ToInt32(_cep_str);
                _cep_entrega = _cep_numero.ToString("00000-000");

                Comunicado_isencao Reg = new Comunicado_isencao();
                Reg.Remessa = _remessa;
                Reg.Codigo = _codigo;
                Reg.Nome = _nome.Length > 50 ? _nome.Substring(0, 50) : _nome;
                Reg.Cpf_cnpj = _cpfcnpj;
                Reg.Endereco = _endereco;
                Reg.Bairro = _bairro ?? "";
                Reg.Cidade = _cidade ?? "";
                Reg.Cep = _cep ?? "";
                Reg.Endereco_entrega = _endereco_entrega;
                Reg.Bairro_entrega = _bairro_entrega ?? "";
                Reg.Cidade_entrega = _cidade_entrega ?? "";
                Reg.Cep_entrega = _cep_entrega;
                Reg.Data_documento = DateTime.Now;
                Reg.Inscricao = _inscricao;
                Reg.Lote = _lote.Length > 15 ? _lote.Substring(0, 15) : _lote;
                Reg.Quadra = _quadra.Length > 15 ? _quadra.Substring(0, 15) : _quadra;
                Reg.Cep_entrega_cod = _cep_numero;

                Exception ex = imovel_Class.Insert_Comunicado_Isencao(Reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                }
                _pos++;
Proximo:;
            }
            PBar.Value = 100;
            ReportCR fRpt = new ReportCR("Comunicado_Isencao", null, null, _remessa);
            fRpt.ShowDialog();



        }


    }
}
