using System;
using System.Windows.Forms;
using GTI_Bll.Classes;
using GTI_Models.Models;
using GTI_Desktop.Classes;
using GTI_Desktop.Properties;
using System.Collections.Generic;

namespace GTI_Desktop.Forms {
    public partial class Processo_Despacho : Form {
        bool bCheck;
        string _connection = gtiCore.Connection_Name();

        public Processo_Despacho() {
            InitializeComponent();
            bCheck = false;
            Carrega_Lista();
        }

        private void Carrega_Lista() {
            gtiCore.Ocupado(this);
            Processo_bll processo_class = new Processo_bll(_connection);
            List<Despacho> lista = processo_class.Lista_Despacho();
            lstMain.Sorted = false;
            lstMain.Items.Clear();
            foreach (Despacho item in lista) {
                lstMain.Items.Add(new GtiTypes.CustomListBoxItem(item.Descricao.ToString(), item.Codigo));
                lstMain.SetItemChecked(lstMain.Items.Count - 1, Convert.ToBoolean( item.Ativo));
            }
            lstMain.Sorted = true;
            gtiCore.Liberado(this);
        }

        private void BtAdd_Click(object sender, EventArgs e) {
            inputBox iBox = new inputBox();
            String sCod = iBox.Show("", "Informação", "Digite o nome do despacho.", 40);
            if (!string.IsNullOrEmpty(sCod)) {
                Processo_bll processo_class = new Processo_bll(_connection);
                Despacho reg = new Despacho {
                    Ativo = true,
                    Descricao = sCod.ToUpper()
                };
                Exception ex = processo_class.Incluir_Despacho(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", "Despacho já cadastrado.", ex);
                    eBox.ShowDialog();
                } else
                    Carrega_Lista();
            }
        }

        private void BtEdit_Click(object sender, EventArgs e) {
            if (lstMain.SelectedItem == null) return;
            inputBox iBox = new inputBox();
            String sCod = iBox.Show(lstMain.Text, "Informação", "Digite o nome do despacho.", 40);
            if (!string.IsNullOrEmpty(sCod)) {
                Processo_bll processo_class = new Processo_bll(_connection);
                Despacho reg = new Despacho();
                GtiTypes.CustomListBoxItem selectedData = (GtiTypes.CustomListBoxItem)lstMain.SelectedItem;
                reg.Codigo = Convert.ToInt16(selectedData._value);
                reg.Descricao = sCod.ToUpper();
                reg.Ativo = lstMain.GetItemChecked(lstMain.SelectedIndex);
                Exception ex = processo_class.Alterar_Despacho(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", "Despacho já cadastrado.", ex);
                    eBox.ShowDialog();
                } else
                    Carrega_Lista();
            }
        }

        private void BtDel_Click(object sender, EventArgs e) {
            if (lstMain.SelectedItem == null) return;
            if (MessageBox.Show("Excluir este despacho?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Processo_bll processo_class = new Processo_bll(_connection);
                Despacho reg = new Despacho();
                GtiTypes.CustomListBoxItem selectedData = (GtiTypes.CustomListBoxItem)lstMain.SelectedItem;
                reg.Codigo = Convert.ToInt16(selectedData._value);
                Exception ex = processo_class.Excluir_Despacho(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", "Não foi possível excluir este despacho, consulte o detalhe para mais informações.", ex);
                    eBox.ShowDialog();
                } else
                    Carrega_Lista();
            }
        }

        private void LstMain_DoubleClick(object sender, EventArgs e) {
            if (lstMain.SelectedItem == null) return;
            btEdit.PerformClick();
        }

        private void BtExit_Click(object sender, EventArgs e) {
            this.Close();
        }
       
        private void LstMain_ItemCheck(object sender, ItemCheckEventArgs e) {
            if (bCheck) {
                bCheck = false;
                return;
            }
            if (lstMain.SelectedItem == null) return;
            e.NewValue = e.CurrentValue;
        }

        private void BtAtivar_Click(object sender, EventArgs e) {
            if (lstMain.SelectedItem == null) return;
            bCheck = true;
            lstMain.SetItemChecked(lstMain.SelectedIndex,! lstMain.GetItemChecked(lstMain.SelectedIndex));

            Despacho reg = new Despacho();
            GtiTypes.CustomListBoxItem selectedData = (GtiTypes.CustomListBoxItem)lstMain.SelectedItem;
            reg.Codigo = Convert.ToInt16(selectedData._value);
            reg.Descricao = selectedData._name;
            reg.Ativo = lstMain.GetItemChecked(lstMain.SelectedIndex);
            Processo_bll clsProcesso = new Processo_bll(_connection);
            Exception ex = clsProcesso.Alterar_Despacho(reg);
            if (ex != null) {
                ErrorBox eBox = new ErrorBox("Atenção", "Erro desconhecido.", ex);
                eBox.ShowDialog();

            }
        }
    }
}
