using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Condominio : Form {
        bool bAddNew, bNovaArea;
        string _connection = gtiCore.Connection_Name();

        public Condominio() {
            InitializeComponent();
            AreasToolBar.Renderer = new MySR();
            ClearReg();
            Carrega_Lista();
            ControlBehaviour(true);
        }

        private void BtSair_Click(object sender, EventArgs e) {
            Close();
        }

        private void ControlBehaviour(bool bStart) {
            Color color_disable = !bStart ? Color.White : BackColor;
            AddButton.Enabled = bStart;
            EditButton.Enabled = bStart;
            DelButton.Enabled = bStart;
            SairButton.Enabled = bStart;
            FindButton.Enabled = bStart;
            SaveButton.Enabled = !bStart;
            CancelarButton.Enabled = !bStart;
            EnderecoButton.Enabled = !bStart;
            UnidadesButton.Enabled = !bStart;
            TestadaAddButton.Enabled = !bStart;
            TestadaDelButton.Enabled = !bStart;
            AtualizarUnidade.Enabled = !bStart;
            ProprietarioButton.Enabled = !bStart;
            Nome.ReadOnly = bStart;
            Nome.BackColor = color_disable;
            Setor.ReadOnly = bStart;
            Setor.BackColor = color_disable;
            Quadra.ReadOnly = bStart;
            Quadra.BackColor = color_disable;
            Lote.ReadOnly = bStart;
            Lote.BackColor = color_disable;
            Face.ReadOnly = bStart;
            Face.BackColor = color_disable;
            Quadra_Original.ReadOnly = bStart;
            Quadra_Original.BackColor = color_disable;
            Lote_Original.ReadOnly = bStart;
            Lote_Original.BackColor = color_disable;
            QtdeUnidade.ReadOnly = bStart;
            QtdeUnidade.BackColor = color_disable;
            AreaPredial.ReadOnly = bStart;
            AreaPredial.BackColor = color_disable;
            AreaTerreno.ReadOnly = bStart;
            AreaTerreno.BackColor = color_disable;
            Unidades.ReadOnly = bStart;
            Unidades.BackColor = color_disable;
            Benfeitoria.Visible = bStart;
            Topografia.Visible = bStart;
            Situacao.Visible = bStart;
            Uso.Visible = bStart;
            Categoria.Visible = bStart;
            Pedologia.Visible = bStart;
            BenfeitoriaList.Visible = !bStart;
            TopografiaList.Visible = !bStart;
            SituacaoList.Visible = !bStart;
            UsoList.Visible = !bStart;
            CategoriaList.Visible = !bStart;
            PedologiaList.Visible = !bStart;
            AddAreaButton.Enabled = !bStart;
            EditAreaButton.Enabled = !bStart;
            DelAreaButton.Enabled = !bStart;
        }

        private void AddButton_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroCondominio_Alterar);
            if (bAllow) {
                bAddNew = true;
                ClearReg();
                ControlBehaviour(false);
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EditButton_Click(object sender, EventArgs e) {
            if (AddButton.Enabled && Convert.ToInt32(CodigoCondominio.Text) == 0)
                MessageBox.Show("Selecione um condomínio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroCondominio_Alterar);
                if (bAllow) {
                    bAddNew = false;
                    ControlBehaviour(false);
                } else
                    MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            if (ValidateReg()) {
                SaveReg();
                ControlBehaviour(true);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            ControlBehaviour(true);
        }

        private void Setor_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void Quadra_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void Lote_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void Face_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void AreaTerreno_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void AreaPredial_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void Unidades_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void FindButton_Click(object sender, EventArgs e) {
            using (var form = new Condominio_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    short val = form.ReturnValue;
                    CarregaDados(val);
                }
            }
        }

        private void Carrega_Lista() {
            Imovel_bll clsImovel = new Imovel_bll(_connection);
            CategoriaList.DataSource = clsImovel.Lista_Categoria_Propriedade();
            CategoriaList.DisplayMember = "Desccategprop";
            CategoriaList.ValueMember = "Codcategprop";

            TopografiaList.DataSource = clsImovel.Lista_Topografia();
            TopografiaList.DisplayMember = "Desctopografia";
            TopografiaList.ValueMember = "Codtopografia";

            SituacaoList.DataSource = clsImovel.Lista_Situacao();
            SituacaoList.DisplayMember = "Descsituacao";
            SituacaoList.ValueMember = "Codsituacao";

            BenfeitoriaList.DataSource = clsImovel.Lista_Benfeitoria();
            BenfeitoriaList.DisplayMember = "Descbenfeitoria";
            BenfeitoriaList.ValueMember = "Codbenfeitoria";

            PedologiaList.DataSource = clsImovel.Lista_Pedologia();
            PedologiaList.DisplayMember = "Descpedologia";
            PedologiaList.ValueMember = "Codpedologia";

            UsoList.DataSource = clsImovel.Lista_uso_terreno();
            UsoList.DisplayMember = "Descusoterreno";
            UsoList.ValueMember = "Codusoterreno";

            UsoConstrucaoList.DataSource = clsImovel.Lista_Uso_Construcao();
            UsoConstrucaoList.DisplayMember = "Descusoconstr";
            UsoConstrucaoList.ValueMember = "Codusoconstr";

            CategoriaConstrucaoList.DataSource = clsImovel.Lista_Categoria_Construcao();
            CategoriaConstrucaoList.DisplayMember = "Desccategconstr";
            CategoriaConstrucaoList.ValueMember = "Codcategconstr";

            TipoConstrucaoList.DataSource = clsImovel.Lista_Tipo_Construcao();
            TipoConstrucaoList.DisplayMember = "Desctipoconstr";
            TipoConstrucaoList.ValueMember = "Codtipoconstr";
        }

        private void ClearReg() {
            CodigoCondominio.Text = "000000";
            Nome.Text = "";
            ProprietarioCodigo.Text = "000000";
            Distrito.Text = "1";
            Setor.Text = "00";
            Quadra.Text = "0000";
            Lote.Text = "00000";
            Face.Text = "00";
            Logradouro.Text = "";
            Logradouro.Tag = "";
            Numero.Text = "";
            Complemento.Text = "";
            CEP.Text = "";
            Bairro.Text = "";
            Bairro.Tag = "";
            Lote_Original.Text = "";
            Quadra_Original.Text = "";
            Benfeitoria.Text = "";
            BenfeitoriaList.SelectedValue = -1;
            Topografia.Text = "";
            TopografiaList.SelectedValue = -1;
            Pedologia.Text = "";
            PedologiaList.SelectedValue = -1;
            Situacao.Text = "";
            SituacaoList.SelectedValue = -1;
            Categoria.Text = "";
            CategoriaList.SelectedValue = -1;
            TipoConstrucaoList.SelectedIndex = -1;
            UsoConstrucaoList.SelectedIndex = -1;
            CategoriaConstrucaoList.SelectedIndex = -1;
            Uso.Text = "";
            UsoList.SelectedValue = -1;
            UnidadesListView.Items.Clear();
            TestadaListView.Items.Clear();
            AreaListView.Items.Clear();
            SomaArea.Text = "0,00";
            AreaTerreno.Text = "";
            AreaConstruida.Text = "";
            Unidades.Text = "";
        }

        private void CarregaDados(int Codigo) {
            ClearReg();
            Imovel_bll imovel_Class = new Imovel_bll(_connection);
            CondominioStruct reg = imovel_Class.Dados_Condominio(Codigo);
            CodigoCondominio.Text = Codigo.ToString("000000");
            Nome.Text = reg.Nome;
            ProprietarioCodigo.Text = Convert.ToInt32(reg.Codigo_Proprietario).ToString("000000");
            Distrito.Text = reg.Distrito.ToString();
            Setor.Text = reg.Setor.ToString("00");
            Quadra.Text = reg.Quadra.ToString("0000");
            Lote.Text = reg.Lote.ToString("00000");
            Face.Text = reg.Seq.ToString("00");
            Logradouro.Text = reg.Nome_Logradouro;
            Logradouro.Tag = reg.Codigo_Logradouro.ToString();
            Numero.Text = reg.Numero.ToString();
            Complemento.Text = reg.Complemento;
            CEP.Text = reg.Cep;
            Bairro.Text = reg.Nome_Bairro;
            Bairro.Tag = reg.Codigo_Bairro.ToString();
            Lote_Original.Text = reg.Lote_Original;
            Quadra_Original.Text = reg.Quadra_Original;
            Benfeitoria.Text = reg.Benfeitoria_Nome;
            BenfeitoriaList.SelectedValue = reg.Benfeitoria;
            Topografia.Text = reg.Topografia_Nome;
            TopografiaList.SelectedValue = reg.Topografia;
            Pedologia.Text = reg.Pedologia_Nome;
            PedologiaList.SelectedValue = reg.Pedologia;
            Situacao.Text = reg.Situacao_Nome;
            SituacaoList.SelectedValue = reg.Situacao;
            Categoria.Text = reg.Categoria_Nome;
            CategoriaList.SelectedValue = reg.Categoria;
            Uso.Text = reg.Uso_terreno_Nome;
            UsoList.SelectedValue = reg.Uso_terreno;
            AreaPredial.Text = Convert.ToDecimal(reg.Area_Construida).ToString("#0.00");
            AreaTerreno.Text = Convert.ToDecimal(reg.Area_Terreno).ToString("#0.00");
            Unidades.Text = reg.Qtde_Unidade.ToString();
            
            List<Testadacondominio> ListaTestada = imovel_Class.Lista_Testada_Condominio(Codigo);
            foreach (Testadacondominio Testada in ListaTestada) {
                ListViewItem lvItem = new ListViewItem(Testada.Numface.ToString("00"));
                lvItem.SubItems.Add(Testada.Areatestada.ToString("#0.00"));
                TestadaListView.Items.Add(lvItem);
            }

            List<Condominiounidade> ListaUnidade = imovel_Class.Lista_Unidade_Condominio(Codigo);
            foreach (Condominiounidade Unidade in ListaUnidade) {
                ListViewItem lvItem = new ListViewItem(Unidade.Cd_unidade.ToString("00"));
                lvItem.SubItems.Add(Unidade.Cd_subunidades.ToString("000"));
                UnidadesListView.Items.Add(lvItem);
            }

            short n = 1;
            List<AreaStruct> ListaArea = imovel_Class.Lista_Area_Condominio(Codigo);
            foreach (AreaStruct regA in ListaArea) {
                ListViewItem lvItem = new ListViewItem(n.ToString("00"));
                lvItem.SubItems.Add(string.Format("{0:0.00}", (decimal)regA.Area));
                lvItem.SubItems.Add(regA.Uso_Nome);
                lvItem.SubItems.Add(regA.Tipo_Nome);
                lvItem.SubItems.Add(regA.Categoria_Nome);
                lvItem.SubItems.Add(regA.Pavimentos.ToString());
                if (regA.Data_Aprovacao != null)
                    lvItem.SubItems.Add(Convert.ToDateTime(regA.Data_Aprovacao).ToString("dd/MM/yyyy"));
                else
                    lvItem.SubItems.Add("");
                if (string.IsNullOrWhiteSpace(regA.Numero_Processo))
                    lvItem.SubItems.Add("");
                else {
                    if (regA.Numero_Processo.Contains("-"))//se já tiver DV não precisa inserir novamente
                        lvItem.SubItems.Add(regA.Numero_Processo);
                    else {
                        Processo_bll processo_Class = new Processo_bll(_connection);
                        lvItem.SubItems.Add(processo_Class.Retorna_Processo_com_DV(regA.Numero_Processo));//corrige o DV
                    }
                }
                lvItem.Tag = regA.Seq.ToString();
                lvItem.SubItems[2].Tag = regA.Uso_Codigo.ToString();
                lvItem.SubItems[3].Tag = regA.Tipo_Codigo.ToString();
                lvItem.SubItems[4].Tag = regA.Categoria_Codigo.ToString();
                AreaListView.Items.Add(lvItem);
                n++;
            }
           
        }
        
        private void AreasButton_Click(object sender, EventArgs e) {
            if (AddButton.Enabled && Convert.ToInt32(CodigoCondominio.Text) == 0)
                MessageBox.Show("Selecione um condomínio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                AreaPanel.BringToFront();
                AreaPanel.Visible = true;
                PanelDados.Enabled = false;
                PanelHeader.Enabled = false;
                PanelLocal.Enabled = false;
                PanelOutro.Enabled = false;
                tBar.Enabled = false;
            }
        }

        private void CloseAreaButton_Click(object sender, EventArgs e) {
            AreasButton.Checked = false;
            AreasButton_Click(null, null);
            
        }

        private void MnuSair_Click(object sender, EventArgs e) {
            AreasButton.Checked = false;
            AreasButton_Click(null, null);
        }

        private void AdicionarMenuItem_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroCondominio_Alterar);
            if (bAllow) {
                bNovaArea = true;
                AreaPanel.Enabled = false;
                AreaEditPanel.Visible = true;
                CategoriaConstrucaoList.SelectedIndex = 0;
                UsoConstrucaoList.SelectedIndex = 0;
                TipoConstrucaoList.SelectedIndex = 0;
                AreaEditPanel.BringToFront();
                AreaConstruida.Focus();
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RemoverMenuItem_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroCondominio_Alterar);
            if (bAllow) {
                if (AreaListView.Items.Count == 0 || AreaListView.SelectedItems.Count == 0)
                    MessageBox.Show("Selecione uma área.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    if (MessageBox.Show("Remover esta área?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        AreaListView.SelectedItems[0].Remove();
                        Renumera_Sequencia_Area();
                    }
                }
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OkAreaButton_Click(object sender, EventArgs e) {
            decimal area = 0;
            int Pavimento = 0;

            try {
                area = decimal.Parse(AreaConstruida.Text);
            } catch {
                MessageBox.Show("Digite o valor da área.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (area == 0) {
                MessageBox.Show("Digite o valor da área.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!gtiCore.IsEmptyDate(DataAprovacao.Text) && !gtiCore.IsDate(DataAprovacao.Text)) {
                MessageBox.Show("Data de aprovação inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrWhiteSpace(ProcessoArea.Text)) {
                Processo_bll processo_Class = new Processo_bll(_connection);
                Exception ex = processo_Class.ValidaProcesso(ProcessoArea.Text);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                    return;
                }
                int Numero = processo_Class.ExtractNumeroProcessoNoDV(ProcessoArea.Text);
                int Ano = processo_Class.ExtractAnoProcesso(ProcessoArea.Text);
                bool Existe = processo_Class.Existe_Processo(Ano, Numero);
                if (!Existe) {
                    MessageBox.Show("Número de processo inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            try {
                Pavimento = int.Parse(QtdePavimentos.Text);
            } catch {
                QtdePavimentos.Text = "1";
            }

            if (bNovaArea) {
                ListViewItem lvItem = new ListViewItem("00");
                lvItem.SubItems.Add(string.Format("{0:0.00}", area));
                lvItem.SubItems.Add(UsoConstrucaoList.Text);
                lvItem.SubItems.Add(TipoConstrucaoList.Text);
                lvItem.SubItems.Add(CategoriaConstrucaoList.Text);
                lvItem.SubItems.Add(QtdePavimentos.Text);
                lvItem.SubItems.Add(DataAprovacao.Text);
                lvItem.SubItems.Add(ProcessoArea.Text);
                lvItem.SubItems[2].Tag = UsoConstrucaoList.SelectedValue.ToString();
                lvItem.SubItems[3].Tag = TipoConstrucaoList.SelectedValue.ToString();
                lvItem.SubItems[4].Tag = CategoriaConstrucaoList.SelectedValue.ToString();
                AreaListView.Items.Add(lvItem);
            } else {
                int idx = AreaListView.SelectedItems[0].Index;
                AreaListView.Items[idx].SubItems[1].Text = string.Format("{0:0.00}", area);
                AreaListView.Items[idx].SubItems[2].Text = UsoConstrucaoList.Text;
                AreaListView.Items[idx].SubItems[3].Text = TipoConstrucaoList.Text;
                AreaListView.Items[idx].SubItems[4].Text = CategoriaConstrucaoList.Text;
                AreaListView.Items[idx].SubItems[5].Text = QtdePavimentos.Text;
                AreaListView.Items[idx].SubItems[6].Text = DataAprovacao.Text;
                AreaListView.Items[idx].SubItems[7].Text = ProcessoArea.Text;
                AreaListView.Items[idx].SubItems[2].Tag = UsoConstrucaoList.SelectedValue.ToString();
                AreaListView.Items[idx].SubItems[3].Tag = TipoConstrucaoList.SelectedValue.ToString();
                AreaListView.Items[idx].SubItems[4].Tag = CategoriaConstrucaoList.SelectedValue.ToString();
            }
            Renumera_Sequencia_Area();

            AreaPanel.Enabled = true;
            AreaEditPanel.Visible = false;
        }

        private void Renumera_Sequencia_Area() {
            int n = 1;
            foreach (ListViewItem item in AreaListView.Items) {
                item.Text = n.ToString("00");
                n++;
            }
        }

        private void AlterarMenuItem_Click(object sender, EventArgs e) {
            if (AreaListView.Items.Count == 0 || AreaListView.SelectedItems.Count == 0)
                MessageBox.Show("Selecione uma área.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {

                bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroCondominio_Alterar);
                if (bAllow) {
                    bNovaArea = false;
                    AreaPanel.Enabled = false;
                    AreaEditPanel.Visible = true;
                    AreaEditPanel.BringToFront();
                    ListViewItem item = AreaListView.SelectedItems[0];
                    AreaConstruida.Text = item.SubItems[1].Text;
                    UsoConstrucaoList.SelectedValue = Convert.ToInt16(item.SubItems[2].Tag.ToString());
                    TipoConstrucaoList.SelectedValue = Convert.ToInt16(item.SubItems[3].Tag.ToString());
                    CategoriaConstrucaoList.SelectedValue = Convert.ToInt16(item.SubItems[4].Tag.ToString());
                    QtdePavimentos.Text = item.SubItems[5].Text;
                    DataAprovacao.Text = item.SubItems[6].Text;
                    ProcessoArea.Text = item.SubItems[7].Text;
                    AreaConstruida.Focus();
                } else
                    MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DelButton_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroCondominio_Alterar);
            if (bAllow)
                //TODO Excluir condominio
                bAllow = true;//apagar linha
            else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CancelAreaButton_Click(object sender, EventArgs e) {
            AreaPanel.Enabled = true;
            AreaEditPanel.Visible = false;
        }

        private void TestadaAddButton_Click(object sender, EventArgs e) {
            int Testada_Face = 0;
            Decimal Testada_Metro = 0;

            inputBox z = new inputBox();
            String sCod = z.Show("", "Informação", "Digite a face da testada.", 2, gtiCore.eTweakMode.IntegerPositive);
            if (!string.IsNullOrEmpty(sCod)) {
                Testada_Face = Convert.ToInt32(sCod);
                bool bFind = false;
                foreach (ListViewItem item in TestadaListView.Items) {
                    if (Convert.ToInt32(item.Text) == Testada_Face) {
                        bFind = true;
                        break;
                    }
                }
                if (bFind)
                    MessageBox.Show("Face já cadastrada.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    sCod = z.Show("", "Informação", "Digite o comprimento da testada.", 7, gtiCore.eTweakMode.DecimalPositive);
                    if (!string.IsNullOrEmpty(sCod)) {
                        Testada_Metro = Convert.ToDecimal(sCod);
                        if (Testada_Metro > 10000)
                            MessageBox.Show("Comprimento inválido.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else {
                            ListViewItem reg = new ListViewItem(Testada_Face.ToString("00"));
                            reg.SubItems.Add(string.Format("{0:0.00}", Testada_Metro));
                            TestadaListView.Items.Add(reg);
                        }
                    } else {
                        MessageBox.Show("Comprimento inválido.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                MessageBox.Show("Nº de face inválida.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TestadaDelButton_Click(object sender, EventArgs e) {
            if (TestadaListView.SelectedItems.Count == 0)
                MessageBox.Show("Selecione a testada a ser removida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                TestadaListView.SelectedItems[0].Remove();
        }

        private void SairAreaButton_Click(object sender, EventArgs e) {
            AreaPanel.Visible = false;
            PanelDados.Enabled = true;
            PanelHeader.Enabled = true;
            PanelLocal.Enabled = true;
            PanelOutro.Enabled = true;
            tBar.Enabled = true;
            
        }

        private bool ValidateReg() {

            int distrito = 0, setor = 0, quadra = 0, lote = 0, face = 0;
            try {
                distrito = Int32.Parse(Distrito.Text);
            } catch {
                MessageBox.Show("Distrito inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try {
                setor = Int32.Parse(Setor.Text);
            } catch {
                MessageBox.Show("Setor inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try {
                quadra = Int32.Parse(Quadra.Text);
            } catch {
                MessageBox.Show("Quadra inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try {
                lote = Int32.Parse(Lote.Text);
            } catch {
                MessageBox.Show("Lote inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try {
                face = Int32.Parse(Face.Text);
            } catch {
                MessageBox.Show("Face inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (lote > 10000) {
                MessageBox.Show("Nº de lote inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (bAddNew) {
                Imovel_bll imovel_Class = new Imovel_bll(_connection);
                int nCodigo = imovel_Class.Existe_Imovel(distrito, setor, quadra, lote, 0, 0);
                if (nCodigo > 0) {
                    MessageBox.Show("Já existe um imóvel com esta inscrição cadastral (" + nCodigo.ToString("000000") + ")", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                } else {
                    bool ExisteFace = imovel_Class.Existe_Face_Quadra(distrito, setor, quadra, face);
                    if (!ExisteFace) {
                        MessageBox.Show("Face de quadra não cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            if (AreaListView.Items.Count == 0) {
                MessageBox.Show("Digite as áreas do condomínio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (TestadaListView.Items.Count == 0) {
                MessageBox.Show("Digite as testadas do condomínio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Convert.ToInt32( ProprietarioCodigo.Text)==0) {
                MessageBox.Show("Cadastre o proprietário do condomínio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (CEP.Text == "") {
                MessageBox.Show("Digite o CEP do condomínio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (AreaTerreno.Text == "")
                AreaTerreno.Text = "0";
            if (Convert.ToDecimal(AreaTerreno.Text) == 0) {
                MessageBox.Show("Digite a área do terreno.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (AreaPredial.Text == "")
                AreaPredial.Text = "0";
            if (Convert.ToDecimal(AreaPredial.Text) == 0) {
                MessageBox.Show("Digite a área da construção.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            bool bFind = false;
            foreach (ListViewItem item in TestadaListView.Items) {
                if (Convert.ToInt32(item.Text) == Convert.ToInt32(Face.Text)) {
                    bFind = true;
                    break;
                }
            }
            if (!bFind) {
                MessageBox.Show("Digite a testada correspondente a face do condomínio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Logradouro.Text == "") {
                MessageBox.Show("Digite o endereço do condomínio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Bairro.Text == "") {
                MessageBox.Show("Digite o bairro do condomínio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (BenfeitoriaList.SelectedIndex == -1 || CategoriaList.SelectedIndex == -1 || PedologiaList.SelectedIndex == -1 || SituacaoList.SelectedIndex == -1 || TopografiaList.SelectedIndex == -1 || UsoList.SelectedIndex == -1) {
                MessageBox.Show("Selecione todas as opções dos dados do terreno.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ProprietarioButton_Click(object sender, EventArgs e) {
            inputBox z = new inputBox();
            String sCod = z.Show("", "Informação", "Digite o código do proprietário.", 6, gtiCore.eTweakMode.IntegerPositive);
            if (!string.IsNullOrEmpty(sCod)) {
                int _codigo = Convert.ToInt32(sCod);
                Cidadao_bll cidadao_Class = new Cidadao_bll(_connection);
                bool bExiste = cidadao_Class.ExisteCidadao(_codigo);
                if (bExiste && _codigo>=500000)
                    ProprietarioCodigo.Text = _codigo.ToString("000000");
                else
                    MessageBox.Show("Código de contribuinte inválido.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QtdeUnidade_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void Distrito_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void UnidadesButton_Click(object sender, EventArgs e) {
            if(UnidadesListView.SelectedItems.Count==0)
                MessageBox.Show("Selecione uma unidade.","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else {
                if(QtdeUnidade.Text=="")
                    MessageBox.Show("Digite a quantidade de subunidades para a unidade selecionada.","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                else {
                    UnidadesListView.SelectedItems[0].SubItems[1].Text = Convert.ToInt32(QtdeUnidade.Text).ToString("000");
                }
            }
        }

        private void AtualizarUnidade_Click(object sender, EventArgs e) {
            int nQtde = 0;
            try {
                nQtde = Int32.Parse(Unidades.Text);
            } catch {
                MessageBox.Show("Quantidade de unidades inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Imovel_bll imovel_Class = new Imovel_bll(_connection);
            if (nQtde > UnidadesListView.Items.Count) {
                int QtdeAcrescentar = nQtde- UnidadesListView.Items.Count  ;
                int Inicio = UnidadesListView.Items.Count + 1;
                int Final = Inicio + QtdeAcrescentar;
                for (int i = Inicio; i < Final; i++) {
                    ListViewItem lvItem = new ListViewItem(i.ToString("00"));
                    lvItem.SubItems.Add("000");
                    UnidadesListView.Items.Add(lvItem);
                }
                return;
            } else {
                int distrito = 0, setor = 0, quadra = 0, lote = 0, face = 0,Codigo=0;
                distrito = Int32.Parse(Distrito.Text);
                setor = Int32.Parse(Setor.Text);
                quadra = Int32.Parse(Quadra.Text);
                lote = Int32.Parse(Lote.Text);
                face = Int32.Parse(Face.Text);
                bool bFind = false;
                foreach (ListViewItem item in UnidadesListView.Items) {
                    Codigo= imovel_Class.Existe_Imovel(distrito, setor, quadra, lote, Convert.ToInt32(item.Text), Convert.ToInt32(item.SubItems[1].Text));
                    if (Codigo > 0) {
                        bFind = true;
                        break;
                    }
                }
                if (bFind)
                    MessageBox.Show("Existem imóveis cadastrados neste condomínio (Ex: " + Codigo.ToString() +"). Exclua-os antes de reduzir a lista de unidades.","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                else {
                    UnidadesListView.Items.Clear();
                    for (int i = 1; i < Int32.Parse(Unidades.Text); i++) {
                        ListViewItem lvItem = new ListViewItem(i.ToString("00"));
                        lvItem.SubItems.Add("000");
                        UnidadesListView.Items.Add(lvItem);
                    }
                }

            }
        }

        private void SaveReg() {
            GTI_Models.Models.Condominio reg = new GTI_Models.Models.Condominio();
            reg.Cd_areaterreno = Convert.ToDecimal(AreaTerreno.Text);
            reg.Cd_areatotconstr = Convert.ToDecimal(AreaPredial.Text);
            reg.Cd_cep = CEP.Text;
            reg.Cd_codbairro= Convert.ToInt16(Bairro.Tag.ToString());
            reg.Cd_codbenf = (short)BenfeitoriaList.SelectedValue;
            reg.Cd_codcategprop = (short)CategoriaList.SelectedValue;
            reg.Cd_codcidade = 413;
            reg.Cd_codpedol = (short)PedologiaList.SelectedValue;
            reg.Cd_codsituacao = (short)SituacaoList.SelectedValue;
            reg.Cd_codtopog = (short)TopografiaList.SelectedValue;
            reg.Cd_codusoterreno = (short)UsoList.SelectedValue;
            reg.Cd_compl =Complemento.Text;
            reg.Cd_distrito= Convert.ToInt16(Distrito.Text);
            reg.Cd_lote= Convert.ToInt32(Lote.Text);
            reg.Cd_lotes = Lote_Original.Text;
            reg.Cd_nomecond = Nome.Text;
            reg.Cd_num=Convert.ToInt16(Numero.Text);
            reg.Cd_numunid = Convert.ToInt16(Unidades.Text);
            reg.Cd_prop = Convert.ToInt32(ProprietarioCodigo.Text);
            reg.Cd_quadra= Convert.ToInt16(Quadra.Text);
            reg.Cd_quadras= Quadra_Original.Text;
            reg.Cd_seq= Convert.ToInt16(Face.Text);
            reg.Cd_setor = Convert.ToInt16(Setor.Text);
            reg.Cd_uf = "SP";
            
            Imovel_bll imovel_Class = new Imovel_bll(_connection);
            Exception ex;

            if (bAddNew) {
                reg.Cd_codigo = imovel_Class.Retorna_Codigo_Condominio_Disponivel();
                ex = imovel_Class.Incluir_Condominio(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                    goto Final;
                } else {
                    CodigoCondominio.Text = reg.Cd_codigo.ToString("000000");
                }
            } else {
                reg.Cd_codigo = Convert.ToInt32(CodigoCondominio.Text);
                ex = imovel_Class.Alterar_Condominio(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                    goto Final;
                }
            }
            int nCodReduzido = reg.Cd_codigo;

            //grava testada
            List<Testadacondominio> ListaTestada = new List<Testadacondominio>();
            foreach (ListViewItem item in TestadaListView.Items) {
                Testadacondominio regT = new Testadacondominio();
                regT.Codcond = nCodReduzido;
                regT.Numface = Convert.ToInt16(item.Text.ToString());
                regT.Areatestada = Convert.ToDecimal(item.SubItems[1].Text.ToString());
                ListaTestada.Add(regT);
            }
            if (ListaTestada.Count > 0) {
                ex = imovel_Class.Incluir_Testada_Condominio(ListaTestada);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                    goto Final;
                }
            }

            //grava area
            List<Condominioarea> ListaArea = new List<Condominioarea>();
            foreach (ListViewItem item in AreaListView.Items) {
                Condominioarea regA = new Condominioarea();
                regA.Codcondominio = nCodReduzido;
                regA.Seqarea = Convert.ToInt16(item.Text.ToString());
                regA.Areaconstr = Convert.ToDecimal(item.SubItems[1].Text.ToString());
                regA.Usoconstr = Convert.ToInt16(item.SubItems[2].Tag.ToString());
                regA.Tipoconstr = Convert.ToInt16(item.SubItems[3].Tag.ToString());
                regA.Catconstr = Convert.ToInt16(item.SubItems[4].Tag.ToString());
                regA.Tipoarea = "";
                regA.Qtdepav = Convert.ToInt16(item.SubItems[5].Text);
                regA.Dataaprova = Convert.ToDateTime(item.SubItems[6].Text);
                regA.Numprocesso = item.SubItems[7].Text;
                ListaArea.Add(regA);
            }
            if (ListaArea.Count > 0) {
                ex = imovel_Class.Incluir_Area_Condominio(ListaArea);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                    goto Final;
                }
            }

            //grava unidades
            List<Condominiounidade> ListaUnidade = new List<Condominiounidade>();
            foreach (ListViewItem item in UnidadesListView.Items) {
                Condominiounidade regT = new Condominiounidade();
                regT.Cd_codigo = nCodReduzido;
                regT.Cd_unidade = Convert.ToInt16(item.Text.ToString());
                regT.Cd_subunidades = Convert.ToInt16(item.SubItems[1].Text.ToString());
                ListaUnidade.Add(regT);
            }
            if (ListaUnidade.Count > 0) {
                ex = imovel_Class.Incluir_Unidade_Condominio(ListaUnidade);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                    goto Final;
                }
            }


            Final:;
            ControlBehaviour(true);
        }

    }
}
