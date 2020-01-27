using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Emissao_Guia : Form {
        string _connection = gtiCore.Connection_Name();

        public Emissao_Guia() {
            InitializeComponent();
        }

        private void ConsultarCodigoButton_Click(object sender, EventArgs e) {
            HeaderMenu.Show(ConsultarCodigoButton, new System.Drawing.Point(0, 20));
        }

        private void CodigoText_TextChanged(object sender, EventArgs e) {
            ClearAll();
        }

        private void CodigoText_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void CodigoText_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (CodigoText.Text != "")
                    Carrega_Dados(Convert.ToInt32(CodigoText.Text));
            }
        }

        private void ClearAll() {
            NomeText.Text = "";
            DocText.Text = "";
            EnderecoText.Text = "";
            BairroText.Text = "";
            CidadeText.Text = "";
            UFText.Text = "";
            CepText.Text = "";
            LoteText.Text = "";
            QuadraText.Text = "";
            EnderecoEntText.Text = "";
            BairroEntText.Text = "";
            CidadeEntText.Text = "";
            UFEntText.Text = "";
            var formToHide = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Emissao_Guia2);
            if (formToHide != null)
                formToHide.Close();
        }

        private void Carrega_Dados(int _codigo) {
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            Contribuinte_Header_Struct _header = sistema_Class.Contribuinte_Header(_codigo);
            NomeText.Text = _header.Nome;
            if(!string.IsNullOrWhiteSpace(_header.Cpf_cnpj))
                DocText.Text = _header.Cpf_cnpj.Length==11? Convert.ToUInt64(_header.Cpf_cnpj).ToString(@"000\.000\.000\-00") :
                                                           Convert.ToUInt64(_header.Cpf_cnpj).ToString(@"00\.000\.000\/0000\-00");
            EnderecoText.Text = _header.Endereco  + ", " + _header.Numero.ToString()  + " " + _header.Complemento;
            BairroText.Text = _header.Nome_bairro ?? "";
            CidadeText.Text = _header.Nome_cidade ?? "";
            UFText.Text = _header.Nome_uf ?? "";
            CepText.Text = _header.Cep ?? "";
            QuadraText.Text = _header.Quadra_original ?? "";
            LoteText.Text = _header.Lote_original ?? "";

            EnderecoEntText.Text=_header.Endereco_entrega + ", " + _header.Numero_entrega.ToString() + " " + _header.Complemento_entrega;
            BairroEntText.Text = _header.Nome_bairro_entrega ?? "";
            CidadeEntText.Text = _header.Nome_cidade_entrega ?? "";
            UFEntText.Text = _header.Nome_uf_entrega ?? "";
            CepEntText.Text = _header.Cep_entrega ?? "";

            if (DocText.Text == "")
                MessageBox.Show("CPF/CNPJ obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                Form mdiForm = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Main);
                Emissao_Guia2 f1 = new Emissao_Guia2(Convert.ToInt32(CodigoText.Text)) { Tag = "Menu", MdiParent = mdiForm };
                f1.TopMost = true;
                f1.Show();
            }
        }

        private void ImovelMenuItem_Click(object sender, EventArgs e) {
            using (var form = new Imovel_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    int val = form.ReturnValue;
                    CodigoText.Text = val.ToString();
                    Carrega_Dados(val);
                }
            }
        }

        private void EmpresaMenuItem_Click(object sender, EventArgs e) {
            using (var form = new Empresa_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    int val = form.ReturnValue;
                    CodigoText.Text = val.ToString();
                    Carrega_Dados(val);
                }
            }
        }

        private void CidadaoMenuItem_Click(object sender, EventArgs e) {
            using (var form = new Cidadao_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    int val = form.ReturnValue;
                    CodigoText.Text = val.ToString();
                    Carrega_Dados(val);
                }
            }
        }
    }


}
