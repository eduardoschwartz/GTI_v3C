using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Escritorio_Contabil : Form {

        bool bAddNew;
        string _connection = gtiCore.Connection_Name();

        public Escritorio_Contabil() {
            InitializeComponent();
            
            tBar.Renderer = new MySR();
            Clear_Reg();
            ControlBehaviour(true);
        }

        private void Clear_Reg() {
            CodigoEscritorio.Text = "000";
            Nome.Text = "";
            Nome.Tag = "";
            CPF.Text = "";
            CNPJ.Text = "";
            IM.Text = "";
            Logradouro.Text = "";
            Logradouro.Tag = "";
            Numero.Text = "";
            Complemento.Text = "";
            Bairro.Text = "";
            Bairro.Tag = "";
            Cidade.Text = "";
            Cidade.Tag = "";
            UF.Text = "";
            Cep.Text = "";
            Pais.Text = "";
            Fone.Text = "";
            Email.Text = "";
            RecebeCarneCheck.Checked = false;
        }

        private void IM_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void ControlBehaviour(bool bStart) {
            Color color_disable = !bStart ? Color.White : BackColor;
            AddButton.Enabled = bStart;
            EditButton.Enabled = bStart;
            DelButton.Enabled = bStart;
            SairButton.Enabled = bStart;
            FindButton.Enabled = bStart;
            GravarButton.Enabled = !bStart;
            CancelarButton.Enabled = !bStart;
            EnderecoButton.Enabled = !bStart;

            Nome.ReadOnly = bStart;
            Crc.ReadOnly = bStart;
            Crc.BackColor = color_disable;
            CPF.ReadOnly = bStart;
            CNPJ.ReadOnly = bStart;
            IM.ReadOnly = bStart;
            IM.BackColor = color_disable;
            RecebeCarneCheck.Enabled = !bStart;

        }

        private void CancelButton_Click(object sender, EventArgs e) {
            ControlBehaviour(true);
        }

        private void AddButton_Click(object sender, EventArgs e) {
            bAddNew = true;
            ControlBehaviour(false);
            Clear_Reg();
            Crc.Focus();
        }

        private void EditButton_Click(object sender, EventArgs e) {
            bAddNew=false;
            ControlBehaviour(false);
            Crc.Focus();
        }

        private void SairButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void FindButton_Click(object sender, EventArgs e) {
            using (var form = new Escritorio_Contabil_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    short val = form.ReturnValue;
                    CarregaDados(val);
                }
            }
        }

        private void CarregaDados(int Codigo) {
            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            EscritoriocontabilStruct reg = empresa_Class.Dados_Escritorio_Contabil(Codigo);
            CodigoEscritorio.Text = reg.Codigo.ToString("000");
            Nome.Text = reg.Nome;
            CPF.Text = reg.Cpf;
            CNPJ.Text = reg.Cnpj;
            IM.Text = reg.Im.ToString();
            Logradouro.Text = reg.Logradouro_Nome;
            Logradouro.Tag = reg.Logradouro_Codigo.ToString();
            Numero.Text = reg.Numero.ToString();
            Complemento.Text = reg.Complemento;
            Bairro.Text = reg.Bairro_Nome;
            Bairro.Tag = reg.Bairro_Codigo.ToString();
            Cidade.Text = reg.Cidade_Nome;
            Cidade.Tag = reg.Cidade_Codigo.ToString();
            UF.Text = reg.UF;
            Cep.Text = reg.Cep;
            Fone.Text = reg.Telefone;
            Email.Text = reg.Email;
            Pais.Text = "BRASIL";
            RecebeCarneCheck.Checked = (bool)reg.Recebecarne;
        }

        private void EnderecoButton_Click(object sender, EventArgs e) {
            GTI_Models.Models.Endereco reg = new GTI_Models.Models.Endereco {
                Id_pais = 1,
                Sigla_uf = UF.Text == "" ? "SP" : UF.Text,
                Id_cidade = string.IsNullOrWhiteSpace(Cidade.Text) ? 413 : Convert.ToInt32(Cidade.Tag.ToString()),
                Id_bairro = string.IsNullOrWhiteSpace(Bairro.Text) ? 0 : Convert.ToInt32(Bairro.Tag.ToString())
            };
            if (Logradouro.Tag == null) Logradouro.Tag = "0";
            if (string.IsNullOrWhiteSpace(Logradouro.Tag.ToString()))
                Logradouro.Tag = "0";
            reg.Id_logradouro = string.IsNullOrWhiteSpace(Logradouro.Text) ? 0 : Convert.ToInt32(Logradouro.Tag.ToString());
            reg.Nome_logradouro = reg.Id_cidade != 413 ? Logradouro.Text : "";
            reg.Numero_imovel = Numero.Text == "" ? 0 : Convert.ToInt32(Numero.Text);
            reg.Complemento = Complemento.Text;
            reg.Email = Email.Text;
            reg.Cep = reg.Id_cidade != 413 ? Cep.Text == "" ? 0 : Convert.ToInt32(gtiCore.ExtractNumber(Cep.Text)) : 0;

            Forms.Endereco f1 = new Forms.Endereco(reg, false, true, true, true);
            f1.ShowDialog();
            if (!f1.EndRetorno.Cancelar) {
                Pais.Text = "BRASIL";
                Pais.Tag = "1";
                UF.Text = f1.EndRetorno.Sigla_uf;
                Cidade.Text = f1.EndRetorno.Nome_cidade;
                Cidade.Tag = f1.EndRetorno.Id_cidade.ToString();
                Bairro.Text = f1.EndRetorno.Nome_bairro;
                Bairro.Tag = f1.EndRetorno.Id_bairro.ToString();
                Logradouro.Text = f1.EndRetorno.Nome_logradouro;
                Logradouro.Tag = f1.EndRetorno.Id_logradouro.ToString();
                Numero.Text = f1.EndRetorno.Numero_imovel.ToString();
                Complemento.Text = f1.EndRetorno.Complemento;
                Email.Text = f1.EndRetorno.Email;
                Cep.Text = f1.EndRetorno.Cep.ToString("00000-000");
            }
        }

        private void GravarButton_Click(object sender, EventArgs e) {
            Bairro.Tag = string.IsNullOrWhiteSpace(Bairro.Tag.ToString()) ? "0" : Bairro.Tag;
            Cidade.Tag = string.IsNullOrWhiteSpace(Cidade.Tag.ToString()) ? "0" : Cidade.Tag;
            Logradouro.Tag = string.IsNullOrWhiteSpace(Logradouro.Tag.ToString()) ? "0" : Logradouro.Tag;
            IM.Text = string.IsNullOrWhiteSpace(IM.Text) ? "0" : IM.Text;
            Numero.Text = string.IsNullOrWhiteSpace(Numero.Text) ? "0" : Numero.Text;

            Escritoriocontabil reg = new Escritoriocontabil();
            reg.Cep = Cep.Text;
            reg.Cnpj = CNPJ.Text;
            reg.Codbairro = Convert.ToInt16(Bairro.Tag);
            reg.Codcidade = Convert.ToInt32(Cidade.Tag);
            reg.Codigoesc = Convert.ToInt32(CodigoEscritorio.Text);
            reg.Codlogradouro = Convert.ToInt32(Logradouro.Tag);
            reg.Complemento = Complemento.Text;
            reg.Cpf = CPF.Text;
            reg.Crc = Crc.Text;
            reg.Email = Email.Text;
            reg.Im = Convert.ToInt32(IM.Text);
            reg.Nomeesc = Nome.Text;
            reg.Nomelogradouro = Logradouro.Text;
            reg.Numero = Convert.ToInt32(Numero.Text);
            reg.Recebecarne = RecebeCarneCheck.Checked;
            reg.Telefone = Fone.Text;
            reg.UF = UF.Text;

            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            Exception ex;
            if (bAddNew) {
                int nLastCod = empresa_Class.Retorna_Ultimo_Codigo_Escritorio() ;
                reg.Codigoesc=++nLastCod;
                ex = empresa_Class.Incluir_escritorio(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                } else {
                    CarregaDados(nLastCod);
                    ControlBehaviour(true);
                }
            } else {
                reg.Codigoesc = Convert.ToInt32(CodigoEscritorio.Text);
                ex = empresa_Class.Alterar_escritorio(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                } else {
                    ControlBehaviour(true);
                }
            }
        }

        private void DelButton_Click(object sender, EventArgs e) {
            int nCodigo = Convert.ToInt32(CodigoEscritorio.Text);
            if (nCodigo == 0)
                MessageBox.Show("Selecione um escritório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (MessageBox.Show("Excluir este registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    Empresa_bll empresa_Class = new Empresa_bll(_connection);
                    Exception ex = empresa_Class.Excluir_Escritorio(nCodigo);
                    if (ex != null) {
                        ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                        eBox.ShowDialog();
                    } else
                        Clear_Reg();
                }
            }
        }
    }
}
