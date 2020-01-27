using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static GTI_Desktop.Classes.GtiTypes;

namespace GTI_Desktop.Forms {
    public partial class Parcelamento_Lista : Form {
        string _connection = gtiCore.Connection_Name();

        public Parcelamento_Lista(List<Processo_Numero> Lista) {
            InitializeComponent();

            foreach (Processo_Numero item in Lista) {
               CustomListBoxItem5 cbItem = new CustomListBoxItem5(item.Numero_processo, (int)item.Numero, (int)item.Ano);
                ProcessoList.Items.Add(cbItem);
            }
            ProcessoList.SelectedIndex = 0;
        }

        private void ProcessoList_SelectedIndexChanged(object sender, System.EventArgs e) {
            gtiCore.Ocupado(this);
            OrigemListView.Items.Clear();
            if (ProcessoList.SelectedItem != null) {
                CustomListBoxItem5 selectedItem =(CustomListBoxItem5)ProcessoList.SelectedItem;
                int _numero_processo = selectedItem._value;
                int _ano_processo = selectedItem._value2;

                OrigemListView.Items.Clear();
                DestinoListView.Items.Clear();
                CanceladoPorText.Text = "";
                CanceladoEmText.Text = "";
                SituacaoText.Text = "";
                ParceladoEmText.Text = "";
                ParceladoPorText.Text = "";

                Carrega_Dados(_ano_processo, _numero_processo);
                Carrega_Origem(_ano_processo, _numero_processo);
                Carrega_Destino(_ano_processo, _numero_processo);
            }
            gtiCore.Liberado(this);
        }

        private void Carrega_Origem(int _ano_processo,int _numero_processo) {
            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            List<OrigemReparcStruct> Lista = tributario_Class.Lista_Origem_Parcelamento(_ano_processo, _numero_processo);
            foreach (OrigemReparcStruct item in Lista) {
                ListViewItem lv = new ListViewItem(item.Exercicio.ToString());
                lv.SubItems.Add(item.Lancamento_Codigo.ToString("00") + "-" + item.Lancamento_Descricao);
                lv.SubItems.Add(item.Sequencia.ToString());
                lv.SubItems.Add(item.Parcela.ToString("00"));
                lv.SubItems.Add(item.Complemento.ToString("00"));
                OrigemListView.Items.Add(lv);
            }
        }

        private void Carrega_Destino(int _ano_processo, int _numero_processo) {
            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            List<DestinoreparcStruct> Lista = tributario_Class.Lista_Destino_Parcelamento(_ano_processo, _numero_processo);
            foreach (DestinoreparcStruct item in Lista) {
                ListViewItem lv = new ListViewItem(item.Exercicio.ToString());
                lv.SubItems.Add(item.Lancamento_Codigo.ToString("00"));
                lv.SubItems.Add(item.Sequencia.ToString());
                lv.SubItems.Add(item.Parcela.ToString("00"));
                lv.SubItems.Add(item.Complemento.ToString("00"));
                lv.SubItems.Add(item.Data_Vencimento.ToString("dd/MM/yyyy"));
                lv.SubItems.Add(item.Situacao_Lancamento_Descricao);
                DestinoListView.Items.Add(lv);
            }
        }

        private void Carrega_Dados(int _ano_processo, int _numero_processo) {
            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            Processo_Parcelamento_Struct _reg = tributario_Class.Retorna_Dados_Parcelamento(_ano_processo, _numero_processo);
            ParceladoEmText.Text = Convert.ToDateTime(_reg.Data_Parcelamento).ToString("dd/MM/yyyy");
            ParceladoPorText.Text = _reg.Usuario_Nome;
            if (_reg.Data_Cancelado != null) {
                CanceladoPorText.Text = _reg.Funcionario_Cancelado??"";
                CanceladoEmText.Text = _reg.Data_Cancelado==null?"":Convert.ToDateTime(_reg.Data_Cancelado).ToString("dd/MM/yyyy");
                SituacaoText.Text = "CANCELADO";
            } else {
                CanceladoPorText.Text = "";
                CanceladoEmText.Text = "";
                if (DestinoListView.Items.Count == 0)
                    SituacaoText.Text = "CANCELADO";
                else {
                    bool _find = false;
                    for (int i = 0; i < DestinoListView.Items.Count; i++) {
                        if (DestinoListView.Items[i].SubItems[6].Text == "NÃO PAGO") {
                            _find = true;
                            break;
                        }
                    }
                    if (!_find)
                        SituacaoText.Text = "PAGO";
                    else
                        SituacaoText.Text = "ATIVO";
                }
            }
        }


    }
}
