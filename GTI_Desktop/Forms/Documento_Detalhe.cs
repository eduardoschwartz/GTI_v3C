using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace GTI_Desktop.Forms {
    public partial class Documento_Detalhe : Form {
        string _connection = gtiCore.Connection_Name();
        int _numero;

        public Documento_Detalhe(int Numero=0) {
            InitializeComponent();
            _numero = Numero;
            if (Numero > 0) {
                NumDocumentoText.Text = Numero.ToString("00000000");
                Carrega_Detalhe(Numero);
            }
        }

        private void Carrega_Detalhe(int Numero) {
            Limpa();
            Tributario_bll tributacao_Class = new Tributario_bll(_connection);
            List<Documento_parcela_valor> Lista_Parcela = tributacao_Class.Lista_Detalhe_Documento(Numero);
            foreach (Documento_parcela_valor item in Lista_Parcela) {
                ListViewItem lvItem = new ListViewItem(item.Codigo.ToString("000000"));
                lvItem.SubItems.Add(item.Ano.ToString());
                lvItem.SubItems.Add(item.Lancamento_codigo.ToString("00") + "-" + item.Lancamento_nome);
                lvItem.SubItems.Add(item.Sequencia.ToString());
                lvItem.SubItems.Add(item.Parcela.ToString());
                lvItem.SubItems.Add(item.Complemento.ToString());
                lvItem.SubItems.Add(item.Data_vencimento.ToString("dd/MM/yyyy"));
                lvItem.SubItems.Add(item.Valor_parcela.ToString("#0.00"));
                MainListView.Items.Add(lvItem);
            }

        }

        private void Limpa() {
            MainListView.Items.Clear();
        }

        private void NumDocumentoText_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (NumDocumentoText.Text.Length >7) {
                    _numero=Convert.ToInt32(NumDocumentoText.Text);
                    Carrega_Detalhe(_numero);
                } else
                    MessageBox.Show("Digite um nº de documento válido","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }

}
