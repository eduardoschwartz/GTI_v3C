using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static GTI_Desktop.Classes.GtiTypes;

namespace GTI_Desktop.Forms {
    public partial class Extrato_Debito_Cancelar : Form {
        public int ReturnValue { get; set; }
        int _codigo,_UserId;
        string _connection = gtiCore.Connection_Name();
        string _connection_integrativa = gtiCore.Connection_Name("GTI_Integrativa");

        public Extrato_Debito_Cancelar(List<SpExtrato> Lista) {
            InitializeComponent();
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            _UserId = sistema_Class.Retorna_User_LoginId(gtiCore.Retorna_Last_User());

            _codigo = Lista[0].Codreduzido;
            foreach (SpExtrato item in Lista) {
                ListViewItem lv = new ListViewItem(item.Anoexercicio.ToString());
                lv.SubItems.Add(item.Desclancamento);
                lv.SubItems.Add(item.Seqlancamento.ToString());
                lv.SubItems.Add(item.Numparcela.ToString());
                lv.SubItems.Add(item.Codcomplemento.ToString());
                lv.SubItems.Add(item.Datavencimento.ToString("dd/MM/yyyy"));
                lv.SubItems.Add(item.Valortributo.ToString("#0.00"));
                lv.SubItems.Add(item.Valorjuros.ToString("#0.00"));
                lv.SubItems.Add(item.Valormulta.ToString("#0.00"));
                lv.SubItems.Add(item.Valorcorrecao.ToString("#0.00"));
                lv.SubItems.Add(item.Valortotal.ToString("#0.00"));
                lv.SubItems.Add(item.Numlivro.ToString());
                lv.SubItems.Add(item.Pagina.ToString());
                MainListView.Items.Add(lv);
            }

            List<CustomListBoxItem> myItems = new List<CustomListBoxItem> {
                new CustomListBoxItem("Cancelado pelo motivo abaixo", 5),
                new CustomListBoxItem("Cancelado por duplicidade", 12),
                new CustomListBoxItem("Cancelado por recurso", 8),
                new CustomListBoxItem("Compensado por recurso", 6),
                new CustomListBoxItem("Compensação tributária", 32),
                new CustomListBoxItem("ISS variável sem movimento", 14),
                new CustomListBoxItem("Retido pelo tomador", 27),
                new CustomListBoxItem("Suspensão de débito/Trâmite", 19)
            };

            TipoList.DisplayMember = "_name";
            TipoList.ValueMember = "_value";
            TipoList.DataSource = myItems;
            TipoList.SelectedIndex = 0;
        }

        private void SairButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        private void TipoList_SelectedIndexChanged(object sender, EventArgs e) {
            CustomListBoxItem _tipo_Cancel = (CustomListBoxItem)TipoList.SelectedItem;
            if (_tipo_Cancel._value == 5 || _tipo_Cancel._value == 12) {
                DataProcessoText.Text = "";
                NumeroProcessoText.Text = "";
                NumeroProcessoText.ReadOnly = true;
                NumeroProcessoText.BackColor = BackColor;
            } else {
                NumeroProcessoText.ReadOnly = false;
                NumeroProcessoText.BackColor = Color.White;
            }
        }

        private void NumeroProcessoText_Leave(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(NumeroProcessoText.Text)) {
                Processo_bll processo_Class = new Processo_bll(_connection);
                Exception ex = processo_Class.ValidaProcesso(NumeroProcessoText.Text);
                if (ex == null) {
                    int _numero_processo = processo_Class.ExtractNumeroProcessoNoDV(NumeroProcessoText.Text);
                    int _ano_processo = processo_Class.ExtractAnoProcesso(NumeroProcessoText.Text);
                    ProcessoStruct _processo = processo_Class.Dados_Processo(_ano_processo, _numero_processo);
                    DataProcessoText.Text = Convert.ToDateTime(_processo.DataEntrada).ToString("dd/MM/yyyy");
                } else {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    DataProcessoText.Text = "";
                    NumeroProcessoText.Focus();
                    eBox.ShowDialog();
                }
            }
        }

        private void NumeroProcessoText_TextChanged(object sender, EventArgs e) {
            if (DataProcessoText.Text != "")
                DataProcessoText.Text = "";
        }

        private void NumeroProcessoText_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return)
                NumeroProcessoText_Leave(sender, e);
        }

        private void CancelarButton_Click(object sender, EventArgs e) {
            if (NumeroProcessoText.ReadOnly == false && !gtiCore.IsDate(DataProcessoText.Text)) {
                MessageBox.Show("Número de processo não cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Tributario_bll tributario_Class = new Tributario_bll(_connection);

            if (MessageBox.Show("Confirmar operação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                foreach (ListViewItem  item in MainListView.Items) {
                    short _ano = Convert.ToInt16(item.Text);
                    short _lanc = Convert.ToInt16(item.SubItems[1].Text.Substring(0,2));
                    short _seq = Convert.ToInt16(item.SubItems[2].Text);
                    byte _parc = Convert.ToByte(item.SubItems[3].Text);
                    byte _compl = Convert.ToByte(item.SubItems[4].Text);
                    decimal _principal= Convert.ToDecimal(item.SubItems[6].Text);
                    decimal _juros = Convert.ToDecimal(item.SubItems[7].Text);
                    decimal _multa = Convert.ToDecimal(item.SubItems[8].Text);
                    decimal _correcao = Convert.ToDecimal(item.SubItems[9].Text);
                    decimal _total = Convert.ToDecimal(item.SubItems[10].Text);
                    int _livro = Convert.ToInt32(item.SubItems[11].Text);
                    int _pagina = Convert.ToInt32(item.SubItems[12].Text);

                    CustomListBoxItem _tipo_Cancel = (CustomListBoxItem)TipoList.SelectedItem;
                    byte _status = Convert.ToByte( _tipo_Cancel._value);

                    Exception ex = tributario_Class.Alterar_Status_Lancamento(_codigo, _ano, _lanc, _seq, _parc, _compl, _status);
                    if (ex == null) {
                        if (NumeroProcessoText.Text != "") {
                            Processo_bll processo_Class = new Processo_bll(_connection);
                            int _numero_processo = processo_Class.ExtractNumeroProcessoNoDV(NumeroProcessoText.Text);
                            int _ano_processo = processo_Class.ExtractAnoProcesso(NumeroProcessoText.Text);
                            string _processo = "";
                            _processo = _numero_processo.ToString() + "/" + _ano_processo.ToString();

                            Debitocancel reg = new Debitocancel() {
                                Numprocesso = _processo,
                                Codreduzido = _codigo,
                                Anoexercicio = _ano,
                                Codlancamento = _lanc,
                                Seqlancamento = _seq,
                                Numparcela = _parc,
                                Codcomplemento = _compl,
                                Datacancel = DateTime.Now,
                                Motivo = MotivoText.Text.Trim(),
                                Userid = _UserId
                            };

                            ex = tributario_Class.Excluir_Debito_Cancel(reg);
                            if (ex == null) {
                                ex = tributario_Class.Insert_Debito_Cancel(reg);
                                if (ex != null) {
                                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                                    eBox.ShowDialog();
                                } else {
                                    //Gravar no log do sistema
                                    string _obs = "Ano:" + _ano.ToString() + " Código:" + _codigo.ToString() + " Lançamento:" + _lanc.ToString();
                                    _obs += " Seq:" + _seq.ToString() + " Parcela:" + _parc.ToString() + " Compl:" + _compl.ToString();
                                    _obs += " Vencto:" + item.SubItems[5].Text + " Motivo: " + MotivoText.Text;
                                    Sistema_bll sistema_Class = new Sistema_bll(_connection);
                                    Logevento _log = new Logevento() {
                                        Computador = Environment.MachineName,
                                        Datahoraevento = DateTime.Now,
                                        LogEvento = _obs,
                                        Evento = 3,
                                        Secevento = (short)gtiCore.EventoForm.Delete,
                                        Form = Name,
                                        Userid = _UserId
                                    };
                                    ex = sistema_Class.Incluir_LogEvento(_log);
                                    if (ex != null) {
                                        ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                                        eBox.ShowDialog();
                                    } else {
                                    }
                                }
                            } else {
                                ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                                eBox.ShowDialog();
                            }


                        } //Cancelar na Integrativa
                        Cancelamentos _creg = new Cancelamentos() {
                            Dtcancelamento = DateTime.Now,
                            Iddevedor = _codigo,
                            Nrolivro = _livro,
                            Nrofolha = _pagina,
                            Seq = _seq,
                            Lancamento = _lanc,
                            Exercicio = _ano,
                            Vlroriginal = _principal,
                            Vlrjuros = _juros,
                            Vlrmulta = _multa,
                            Vlrtotal = _total,
                            Nroparcela = _parc,
                            Complparcela = _compl,
                            Dtgeracao = DateTime.Now
                        };
                        Integrativa_bll tributario_Class_Int = new Integrativa_bll(_connection_integrativa);
                        ex = tributario_Class_Int.Insert_Integrativa_Cancelamento(_creg);
                        if (ex != null) {
                            ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                            eBox.ShowDialog();
                        }
                    } else {
                        ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                        eBox.ShowDialog();
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }

    }
}
