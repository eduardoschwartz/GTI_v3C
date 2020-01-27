using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static GTI_Models.modelCore;

namespace GTI_Desktop.Forms {
    public partial class Imovel : Form {
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        bool bAddNew,bNovaArea;
        string _connection = gtiCore.Connection_Name();

        public Imovel() {
            gtiCore.Ocupado(this);
            InitializeComponent();
            HistoricoBar.Renderer = new MySR();
            AreasBar.Renderer = new MySR();
            ClearFields();
            Carrega_Lista();
            bAddNew = false;
            ControlBehaviour(true);
            gtiCore.Liberado(this);
        }

        private void TabImovel_DrawItem(object sender, DrawItemEventArgs e) {
            TabPage page = ImovelTab.TabPages[e.Index];
            e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
        }

        private void ClearFields() {
            IptuChart.Series.Clear();
            bNovaArea = false;
            Inscricao.Text = "";
            SomaArea.Text = "0,00";
            Matricula.Text = "";
            Condominio.Text = "";
            MT1Check.Checked = true;
            MT2Check.Checked = false;
            End1Option.Checked = true;
            End2Option.Checked = false;
            End3Option.Checked = false;
            ProprietarioListView.Items.Clear();
            TestadaListView.Items.Clear();
            AreaListView.Items.Clear();
            HistoricoListView.Items.Clear();
            Distrito.Text = "0";
            Setor.Text = "00";
            Quadra.Text = "0000";
            Lote.Text = "00000";
            Face.Text = "00";
            Unidade.Text = "00";
            SubUnidade.Text = "000";
            Logradouro.Text = "";
            Logradouro.Tag = "";
            Complemento.Text = "";
            Numero.Text = "";
            Bairro.Text = "";
            Bairro.Tag = "";
            Quadras.Text = "";
            Lotes.Text = "";
            Ativo.Text = "";
            ResideCheck.Checked = false;
            ImuneCheck.Checked = false;
            IsentoCIPCheck.Checked = false;
            ConjugadoCheck.Checked = false;
            BenfeitoriaList.SelectedIndex = -1;
            CategoriaTerrenoList.SelectedIndex = -1;
            PedologiaList.SelectedIndex = -1;
            SituacaoList.SelectedIndex = -1;
            TopografiaList.SelectedIndex = -1;
            UsoTerrenoList.SelectedIndex = -1;
            TipoConstrucaoList.SelectedIndex = -1;
            UsoConstrucaoList.SelectedIndex = -1;
            CategoriaConstrucaoList.SelectedIndex = -1;
            ImovelTab.SelectedTab = ImovelTab.TabPages[0];
            Limpa_endereco_Entrega();
            Refresh();
        }

        private void Limpa_endereco_Entrega() {
            Logradouro_EE.Text = "";
            Logradouro_EE.Tag = "";
            Numero_EE.Text = "";
            Complemento_EE.Text = "";
            CEP_EE.Text = "";
            Bairro_EE.Text = "";
            Bairro_EE.Tag = "";
            UF_EE.Text = "";
            Cidade_EE.Text = "";
            Cidade_EE.Tag = "";   
        }

        private void ControlBehaviour(bool bStart) {
            Color cor_enabled = Color.White,cor_disabled = SystemColors.ButtonFace ;

            NovoButton.Enabled = bStart;
            AlterarButton.Enabled = bStart;
            InativarButton.Enabled = bStart;
            SairButton.Enabled = bStart;
            ImprimirButton.Enabled = bStart;
            LocalizarButton.Enabled = bStart;
            GravarButton.Enabled = !bStart;
            CancelarButton.Enabled = !bStart;
            CodigoButton.Enabled = bStart;
            AdicionarProprietarioMenu.Enabled = !bStart;
            RemoverProprietarioMenu.Enabled = !bStart;
            ConsultarProprietarioMenu.Enabled = !bStart;
            PrincipalProprietarioMenu.Enabled = !bStart;
            AddAreaButton.Enabled = !bStart;
            EditAreaButton.Enabled = !bStart;
            DelAreaButton.Enabled = !bStart;
            AddHistoricoButton.Enabled = !bStart;
            EditHistoricoButton.Enabled = !bStart;
            DelHistoricoButton.Enabled = !bStart;
            ZoomHistoricoButton.Enabled = true;
            ResideCheck.AutoCheck = !bStart;
            ImuneCheck.AutoCheck = !bStart;
            IsentoCIPCheck.AutoCheck = !bStart;
            ConjugadoCheck.AutoCheck = !bStart;
            MT1Check.AutoCheck = !bStart;
            MT2Check.AutoCheck= !bStart;
            LocalImovelButton.Enabled = !bStart;
            Quadras.ReadOnly = bStart;
            Quadras.BackColor = bStart ? cor_disabled : cor_enabled;
            Lotes.ReadOnly = bStart;
            Lotes.BackColor = bStart ? cor_disabled : cor_enabled;
            Matricula.ReadOnly = bStart;
            Matricula.BackColor = bStart ? cor_disabled : cor_enabled;
            AreaPnl.Visible = false;
            OkAreaButton.Enabled = !bStart;
            End1Option.AutoCheck = !bStart;
            End2Option.AutoCheck = !bStart;
            End3Option.AutoCheck = !bStart;
            if(End1Option.Checked || End2Option.Checked)
                EndEntregaButton.Enabled = false;
            else
                EndEntregaButton.Enabled = !bStart;
            AddTestada.Enabled = !bStart;
            DelTestada.Enabled = !bStart;
            Testada_Face.ReadOnly = bStart;
            Testada_Face.BackColor = bStart ? cor_disabled : cor_enabled;
            Testada_Metro.ReadOnly = bStart;
            Testada_Metro.BackColor = bStart ? cor_disabled : cor_enabled;
            AreaTerreno.ReadOnly = bStart;
            AreaTerreno.BackColor = bStart ? cor_disabled : cor_enabled;
            FracaoIdeal.ReadOnly = bStart;
            FracaoIdeal.BackColor = bStart ? cor_disabled : cor_enabled;

            BenfeitoriaList.Visible = !bStart;
            CategoriaTerrenoList.Visible = !bStart;
            PedologiaList.Visible = !bStart;
            SituacaoList.Visible = !bStart;
            TopografiaList.Visible = !bStart;
            UsoTerrenoList.Visible = !bStart;
            Benfeitoria.Visible = bStart;
            Categoria.Visible = bStart;
            Pedologia.Visible = bStart;
            Situacao.Visible = bStart;
            Topografia.Visible = bStart;
            UsoTerreno.Visible = bStart;
            IPTUButton.Visible = bStart;
            IptuChart.Visible = false;
        }

        private void Carrega_Lista() {
            Imovel_bll clsImovel = new Imovel_bll(_connection);
            CategoriaTerrenoList.DataSource = clsImovel.Lista_Categoria_Propriedade();
            CategoriaTerrenoList.DisplayMember = "Desccategprop";
            CategoriaTerrenoList.ValueMember = "Codcategprop";

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

            UsoTerrenoList.DataSource = clsImovel.Lista_uso_terreno();
            UsoTerrenoList.DisplayMember = "Descusoterreno";
            UsoTerrenoList.ValueMember = "Codusoterreno";

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

        private void TxtMatricula_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void BtAdd_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroImovel_Novo);
            if (bAllow) {
                using (var form = new Imovel_Novo()) {
                    var result = form.ShowDialog(this);
                    if (result == DialogResult.OK) {
                        ClearFields();
                        Inscricao.Text = form.ReturnInscricao;
                        Distrito.Text = Inscricao.Text.Substring(0, 1);
                        Setor.Text = Inscricao.Text.Substring(2, 2);
                        Quadra.Text = Inscricao.Text.Substring(5, 4);
                        Lote.Text = Inscricao.Text.Substring(10, 5);
                        Face.Text = Inscricao.Text.Substring(16, 2);
                        Unidade.Text = Inscricao.Text.Substring(19, 2);
                        SubUnidade.Text = Inscricao.Text.Substring(22, 3);
                        Condominio.Text = form.ReturnCondominio;
                        int _condominio = form.ReturnCondominioCodigo;
                        this.Condominio.Tag = _condominio.ToString();
                        if (_condominio > 0)
                            Carrega_Dados_Condominio(_condominio);
                        bAddNew = true;
                        ControlBehaviour(false);
                    }
                }
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Carrega_Dados_Condominio(int _codigo_condominio) {
            Imovel_bll imovel_Class = new Imovel_bll(_connection);
            CondominioStruct regImovel = imovel_Class.Dados_Condominio(_codigo_condominio);
            Logradouro.Text = regImovel.Nome_Logradouro;
            Logradouro.Tag = regImovel.Codigo_Logradouro.ToString();
            Numero.Text = regImovel.Numero.ToString();
            Complemento.Text = regImovel.Complemento;
            Bairro.Text =  regImovel.Nome_Bairro;
            Bairro.Tag = regImovel.Codigo_Bairro;
            Lotes.Text = regImovel.Lote_Original;
            Quadras.Text = regImovel.Quadra_Original;
            Cep.Text = regImovel.Cep;
            AreaTerreno.Text = string.Format("{0:0.00}", regImovel.Area_Terreno); 
            UsoTerreno.Text = regImovel.Uso_terreno_Nome;
            Situacao.Text = regImovel.Situacao_Nome;
            Pedologia.Text = regImovel.Pedologia_Nome;
            Benfeitoria.Text = regImovel.Benfeitoria_Nome;
            Topografia.Text = regImovel.Topografia_Nome;
            Categoria.Text = regImovel.Categoria_Nome;
            BenfeitoriaList.SelectedValue = regImovel.Benfeitoria == 0 ? -1 : regImovel.Benfeitoria;
            CategoriaTerrenoList.SelectedValue = regImovel.Categoria == 0 ? -1 : regImovel.Categoria;
            PedologiaList.SelectedValue = regImovel.Pedologia == 0 ? -1 : regImovel.Pedologia;
            SituacaoList.SelectedValue = regImovel.Situacao == 0 ? -1 : regImovel.Situacao;
            TopografiaList.SelectedValue = regImovel.Topografia == 0 ? -1 : regImovel.Topografia;
            UsoTerrenoList.SelectedValue = regImovel.Uso_terreno == 0 ? -1 : regImovel.Uso_terreno;
            FracaoIdeal.Text = string.Format("{0:0.00}", regImovel.Fracao_Ideal);

            Cidadao_bll cidadao_Class = new Cidadao_bll(_connection);
            string sNome = cidadao_Class.Retorna_Nome_Cidadao((int)regImovel.Codigo_Proprietario);
            ListViewItem lvProp = new ListViewItem {
                Group = ProprietarioListView.Groups["groupPP"]
            };
            lvProp.Text = sNome + " (Principal)";
            lvProp.Tag = regImovel.Codigo_Proprietario.ToString();
            ProprietarioListView.Items.Add(lvProp);


            List<AreaStruct> ListaArea = imovel_Class.Lista_Area_Condominio(_codigo_condominio);
            short n = 1;
            decimal SomaArea = 0;
            foreach (AreaStruct reg in ListaArea) {
                ListViewItem lvItem = new ListViewItem(n.ToString("00"));
                lvItem.SubItems.Add(string.Format("{0:0.00}", (decimal)reg.Area));
                lvItem.SubItems.Add(reg.Uso_Nome);
                lvItem.SubItems.Add(reg.Tipo_Nome);
                lvItem.SubItems.Add(reg.Categoria_Nome);
                lvItem.SubItems.Add(reg.Pavimentos.ToString());
                if (reg.Data_Aprovacao != null)
                    lvItem.SubItems.Add(Convert.ToDateTime(reg.Data_Aprovacao).ToString("dd/MM/yyyy"));
                else
                    lvItem.SubItems.Add("");
                if (string.IsNullOrWhiteSpace(reg.Numero_Processo))
                    lvItem.SubItems.Add("");
                else {
                    if (reg.Numero_Processo.Contains("-"))//se já tiver DV não precisa inserir novamente
                        lvItem.SubItems.Add(reg.Numero_Processo);
                    else {
                        Processo_bll processo_Class = new Processo_bll(_connection);
                        lvItem.SubItems.Add(processo_Class.Retorna_Processo_com_DV(reg.Numero_Processo));//corrige o DV
                    }
                }
                lvItem.Tag = reg.Seq.ToString();
                lvItem.SubItems[2].Tag = reg.Uso_Codigo.ToString();
                lvItem.SubItems[3].Tag = reg.Tipo_Codigo.ToString();
                lvItem.SubItems[4].Tag = reg.Categoria_Codigo.ToString();
                AreaListView.Items.Add(lvItem);
                SomaArea += reg.Area;
                n++;
            }
            if (AreaListView.Items.Count > 0)
                AreaListView.Items[0].Selected = true;
            this.SomaArea.Text = string.Format("{0:0.00}", SomaArea);

            EnderecoStruct regEntrega = imovel_Class.Dados_Endereco(regImovel.Codigo, TipoEndereco.Local);
            if (regEntrega != null) {
                Logradouro_EE.Text = regEntrega.Endereco.ToString();
                Logradouro_EE.Tag = regEntrega.CodLogradouro.ToString();
                Numero_EE.Text = regEntrega.Numero.ToString();
                Complemento_EE.Text = regEntrega.Complemento.ToString();
                UF_EE.Text = regEntrega.UF.ToString();
                Cidade_EE.Text = regEntrega.NomeCidade.ToString();
                Cidade_EE.Tag = regEntrega.CodigoCidade.ToString();
                Bairro_EE.Text = regEntrega.NomeBairro.ToString();
                Bairro_EE.Tag = regEntrega.CodigoBairro.ToString();
                CEP_EE.Text = regEntrega.Cep == null ? "00000-000" : Convert.ToInt32(regEntrega.Cep.ToString()).ToString("00000-000");
            }

            //Carrega testada
            List<GTI_Models.Models.Testada> ListaT = imovel_Class.Lista_Testada(regImovel.Codigo);
            foreach (GTI_Models.Models.Testada reg in ListaT) {
                ListViewItem lvItem = new ListViewItem(reg.Numface.ToString("00"));
                lvItem.SubItems.Add(string.Format("{0:0.00}", (decimal)reg.Areatestada));
                TestadaListView.Items.Add(lvItem);
            }


        }

        private void BtEdit_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroImovel_Alterar_Total);
            if (bAllow) {
                bAddNew = false;
                if (String.IsNullOrEmpty(Inscricao.Text))
                    MessageBox.Show("Nenhum imóvel carregado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    ControlBehaviour(false);
                    CodigoButton.Focus();
                }
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtGravar_Click(object sender, EventArgs e) {
            if (ValidateReg()) {
                SaveReg();
                ControlBehaviour(true);
            }
        }

        private void SaveReg() {
            Cadimob reg = new Cadimob();
            reg.Cip = IsentoCIPCheck.Checked;
            reg.Codcondominio = Convert.ToInt32( Condominio.Tag.ToString());
            reg.Conjugado = ConjugadoCheck.Checked;
            reg.Datainclusao = DateTime.Now;
            reg.Dc_qtdeedif = (short)AreaListView.Items.Count;
            reg.Distrito = Convert.ToInt16(Distrito.Text);
            reg.Dt_areaterreno = Convert.ToDecimal(AreaTerreno.Text);
            reg.Dt_codbenf = (short)BenfeitoriaList.SelectedValue;
            reg.Dt_codcategprop = (short)CategoriaTerrenoList.SelectedValue;
            reg.Dt_codpedol= (short)PedologiaList.SelectedValue;
            reg.Dt_codsituacao = (short)SituacaoList.SelectedValue;
            reg.Dt_codtopog = (short)TopografiaList.SelectedValue;
            reg.Dt_codusoterreno = (short)UsoTerrenoList.SelectedValue;
            if (FracaoIdeal.Text != "")
                reg.Dt_fracaoideal = Convert.ToDecimal(FracaoIdeal.Text);
            else
                reg.Dt_fracaoideal = 0;
            reg.Ee_tipoend = End1Option.Checked ? (short)0 : End2Option.Checked ? (short)1 : (short)2;
            reg.Imune = ImuneCheck.Checked;
            reg.Inativo = Ativo.Text == "ATIVO" ? false : true;
            reg.Li_cep = Cep.Text;
            reg.Li_codbairro = Convert.ToInt16( Bairro.Tag.ToString());
            reg.Li_codcidade = 413;
            reg.Li_compl = Complemento.Text;
            reg.Li_lotes = Lotes.Text;
            reg.Li_num = Convert.ToInt16(Numero.Text);
            reg.Li_quadras = Quadras.Text;
            reg.Li_uf = "SP";
            reg.Lote = Convert.ToInt32(Lote.Text);
            if (Matricula.Text != "")
                reg.Nummat = Convert.ToInt32(Matricula.Text);
            else
                reg.Nummat = 0;
            reg.Quadra = Convert.ToInt16(Quadra.Text);
            reg.Resideimovel = ResideCheck.Checked;
            reg.Seq = Convert.ToInt16(Face.Text);
            reg.Setor = Convert.ToInt16(Setor.Text);
            reg.Subunidade = Convert.ToInt16(SubUnidade.Text);
            reg.Tipomat = MT1Check.Checked ? "M" : "T";
            reg.Unidade = Convert.ToInt16(Unidade.Text);

            Imovel_bll imovel_Class = new Imovel_bll(_connection);
            Exception ex;
            
            if (bAddNew) {
                reg.Codreduzido = imovel_Class.Retorna_Codigo_Disponivel();
                ex = imovel_Class.Incluir_Imovel(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                    goto Final;
                } else {
                    Codigo.Text = reg.Codreduzido.ToString("000000");
                }
            } else {
                reg.Codreduzido = Convert.ToInt32(Codigo.Text);
                ex = imovel_Class.Alterar_Imovel(reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                    goto Final;
                } 
            }
            int nCodReduzido = reg.Codreduzido;

            //grava proprietário
            List<Proprietario> Lista = new List<Proprietario>();
            foreach (ListViewItem item in ProprietarioListView.Items) {
                Proprietario regProp = new Proprietario();
                regProp.Codreduzido = nCodReduzido;
                regProp.Codcidadao = Convert.ToInt32(item.Tag.ToString());
                regProp.Principal = item.Text.Substring(item.Text.Length - 1, 1) == ")" ? true : false;
                regProp.Tipoprop = item.Group.Name == "groupPP" ? "P" : "C";
                Lista.Add(regProp);
            }
            ex = imovel_Class.Incluir_Proprietario(Lista);
            if (ex != null) {
                ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                eBox.ShowDialog();
                goto Final;
            }

            //grava testada
            List<Testada> ListaTestada = new List<Testada>();
            foreach (ListViewItem item in TestadaListView.Items) {
                Testada regT = new Testada();
                regT.Codreduzido = nCodReduzido;
                regT.Numface = Convert.ToInt16(item.Text.ToString());
                regT.Areatestada = Convert.ToDecimal(item.SubItems[1].Text.ToString()); 
                ListaTestada.Add(regT);
            }
            if (ListaTestada.Count > 0) {
                ex = imovel_Class.Incluir_Testada(ListaTestada);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                    goto Final;
                }
            }

            //grava historico
            List<Historico> ListaHist = new List<Historico>();
            foreach (ListViewItem item in HistoricoListView.Items) {
                Historico regH = new Historico();
                regH.Codreduzido = nCodReduzido;
                regH.Seq = Convert.ToInt16(item.Text.ToString());
                regH.Datahist2 = Convert.ToDateTime(item.SubItems[1].Text.ToString());
                regH.Deschist = item.SubItems[2].Text;
                regH.Userid = Convert.ToInt32(item.Tag.ToString());
                ListaHist.Add(regH);
            }
            if (ListaHist.Count > 0) {
                ex = imovel_Class.Incluir_Historico(ListaHist);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                    goto Final;
                }
            }

            //grava area
            List<Areas> ListaArea = new List<Areas>();
            foreach (ListViewItem item in AreaListView.Items) {
                Areas regA = new Areas();
                regA.Codreduzido = nCodReduzido;
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
                ex = imovel_Class.Incluir_Area(ListaArea);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                    goto Final;
                }
            }

            Final:;
            ControlBehaviour(true);
        }

        private void BtCancelar_Click(object sender, EventArgs e) {
            ControlBehaviour(true);
        }

        private void BtSair_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BtCod_Click(object sender, EventArgs e) {
            inputBox z = new inputBox();
            String sCod = z.Show("", "Informação", "Digite o código do imóvel.", 6, gtiCore.eTweakMode.IntegerPositive);
            if (!string.IsNullOrEmpty(sCod)) {
                gtiCore.Ocupado(this);
                Imovel_bll clsImovel = new Imovel_bll(_connection);
                if (clsImovel.Existe_Imovel(Convert.ToInt32(sCod))) {
                    int Codigo = Convert.ToInt32(sCod);
                    this.Codigo.Text = Codigo.ToString("000000");
                    ControlBehaviour(true);
                    ClearFields();
                    CarregaImovel(Codigo);
                } else
                    MessageBox.Show("Imóvel não cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gtiCore.Liberado(this);
            }
        }

        private void TxtNumero_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void LvProp_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e) {
            if (ProprietarioListView.SelectedIndices.Count > 0)
                ProprietarioListView.Items[ProprietarioListView.SelectedIndices[0]].ToolTipText = ProprietarioListView.Items[ProprietarioListView.SelectedIndices[0]].Tag.ToString();
        }

        private void LvProp_MouseHover(object sender, EventArgs e) {
            ProprietarioListView.Focus();
        }

        private bool ValidateReg() {
            if (ProprietarioListView.Items.Count == 0) {
                MessageBox.Show("Cadastre o(s) proprietário(s) do imóvel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Cep.Text == "") {
                MessageBox.Show("Digite o CEP do imóvel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (AreaTerreno.Text == "")
                AreaTerreno.Text = "0";
            if (Convert.ToDecimal(AreaTerreno.Text) == 0) {
                MessageBox.Show("Digite a área do terreno.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool bFind = false;
            foreach (ListViewItem item in TestadaListView.Items) {
                if(Convert.ToInt32(item.Text) == Convert.ToInt32(Face.Text)) {
                    bFind = true;
                    break;
                }
            }
            if (!bFind) {
                MessageBox.Show("Digite a testada correspondente a face do imóvel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Logradouro.Text == "") {
                MessageBox.Show("Digite o endereço do imóvel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Bairro.Text == "") {
                MessageBox.Show("Digite o bairro do imóvel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Logradouro_EE.Text == "") {
                MessageBox.Show("Digite o endereço de entrega do imóvel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Bairro_EE.Text == "") {
                MessageBox.Show("Digite o bairro de entrega do imóvel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(BenfeitoriaList.SelectedIndex==-1||CategoriaTerrenoList.SelectedIndex==-1||PedologiaList.SelectedIndex==-1||SituacaoList.SelectedIndex==-1|| TopografiaList.SelectedIndex == -1 || UsoTerrenoList.SelectedIndex == -1) {
                MessageBox.Show("Selecione todas as opções dos dados do terreno.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if(Condominio.Tag == null) Condominio.Tag="999";
                   

            return true;
        }

        private void MnuProprietario_Click(object sender, EventArgs e) {
            inputBox z = new inputBox();
            int nContaP = 0;
            String sCod = z.Show("", "Incluir proprietário", "Digite o código do cidadão.", 6, gtiCore.eTweakMode.IntegerPositive);
            if (!string.IsNullOrEmpty(sCod)) {
                int nCod = Convert.ToInt32(sCod);
                if(nCod<500000 || nCod>700000)
                    MessageBox.Show("Código de cidadão inválido!","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                else {
                    Cidadao_bll clsCidadao = new Cidadao_bll(_connection);
                    if (!clsCidadao.ExisteCidadao(nCod))
                        MessageBox.Show("Código não cadastrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        bool bFind = false;
                        foreach (ListViewItem item in ProprietarioListView.Items) {
                            if (item.Tag.ToString() == sCod) {
                                bFind = true;
                                break;
                            }
                        }
                        if (bFind)
                            MessageBox.Show("Código já cadastrado no imóvel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else {
                            if (ProprietarioListView.Groups["groupPP"].Items.Count > 0)
                                nContaP = ProprietarioListView.Groups["groupPP"].Items.Count;
                            else
                                nContaP = 0;

                            string sNome = clsCidadao.Retorna_Nome_Cidadao(nCod);
                            ListViewItem lvItem = new ListViewItem {
                                Group = ProprietarioListView.Groups["groupPP"]
                            };
                            if (nContaP == 0)
                                lvItem.Text = sNome + " (Principal)";
                            else
                                lvItem.Text = sNome;
                            lvItem.Tag = sCod;
                            ProprietarioListView.Items.Add(lvItem);
                        }
                    }
                }
            }
        }

        private void MnuSolidario_Click(object sender, EventArgs e) {
            inputBox z = new inputBox();
            String sCod = z.Show("", "Incluir proprietário solidário", "Digite o código do cidadão.", 6, gtiCore.eTweakMode.IntegerPositive);
            if (!string.IsNullOrEmpty(sCod)) {
                int nCod = Convert.ToInt32(sCod);
                if (nCod < 500000 || nCod > 700000)
                    MessageBox.Show("Código de cidadão inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    Cidadao_bll clsCidadao = new Cidadao_bll(_connection);
                    if (!clsCidadao.ExisteCidadao(nCod))
                        MessageBox.Show("Código não cadastrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        bool bFind = false;
                        foreach (ListViewItem item in ProprietarioListView.Items) {
                            if (item.Tag.ToString() == sCod) {
                                bFind = true;
                                break;
                            }
                        }
                        if (bFind)
                            MessageBox.Show("Código já cadastrado no imóvel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else {
                            string sNome = clsCidadao.Retorna_Nome_Cidadao(nCod);
                            ListViewItem lvItem = new ListViewItem {
                                Group = ProprietarioListView.Groups["groupPS"],
                                Text = sNome,
                                Tag = sCod
                            };
                            ProprietarioListView.Items.Add(lvItem);
                        }
                    }
                }
            }
        }

        private void MnuRemover_Click(object sender, EventArgs e) {
            if(ProprietarioListView.SelectedItems.Count==0)
                MessageBox.Show("Selecione o cidadão a ser removido.","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else {
                if (MessageBox.Show("Remover este cidadão?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                    ProprietarioListView.SelectedItems[0].Remove();
            }
        }

        private void MnuConsultar_Click(object sender, EventArgs e) {
            if (ProprietarioListView.SelectedItems.Count == 0)
                MessageBox.Show("Selecione o cidadão que deseja consultar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                int nCod = Convert.ToInt32(ProprietarioListView.SelectedItems[0].Tag.ToString());
                Cidadao f1 = (Cidadao)Application.OpenForms["Cidadao"];
                if (f1 != null) 
                    f1.Close();
                Cidadao f2 = new Cidadao {
                    Tag = "Imovel",
                    CodCidadao = nCod
                };
                f2.ShowDialog();
            }
        }

        private void MnuPrincipal_Click(object sender, EventArgs e) {
            int nContaP = 0;

            if (ProprietarioListView.SelectedItems.Count == 0)
                MessageBox.Show("Selecione o cidadão a ser promovido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (ProprietarioListView.SelectedItems[0].Group.Name == "groupPS")
                    MessageBox.Show("Proprietário solidário não pode ser o proprietário principal do imóvel. É necessário remover ele do grupo solidário e adicioná-lo ao grupo proprietário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    //verifica se o grupo principal esta criado
                    if (ProprietarioListView.Groups["groupPP"].Items.Count > 0)
                        nContaP = ProprietarioListView.Groups["groupPP"].Items.Count;
                    //porque se existir remove o atributo do proprietário principal
                    if (nContaP > 0) {
                        foreach (ListViewItem item in ProprietarioListView.Groups["groupPP"].Items) {
                            if (item.Text.Contains("(Principal)")) {
                                item.Text = item.Text.Substring(0, item.Text.IndexOf("("));
                                break;
                            }
                        }
                    }
                    ProprietarioListView.SelectedItems[0].Text = ProprietarioListView.SelectedItems[0].Text + " (Principal)";
                }
            }
        }

        private void BtLocalImovel_Click(object sender, EventArgs e) {
            GTI_Models.Models.Endereco reg = new GTI_Models.Models.Endereco {
                Id_pais = 1,
                Sigla_uf = "SP",
                Id_cidade = 413,
                Id_bairro = string.IsNullOrWhiteSpace(Bairro.Text) ? 0 : Convert.ToInt32(Bairro.Tag.ToString())
            };
            if (Logradouro.Tag == null) Logradouro.Tag = "0";
            if (string.IsNullOrWhiteSpace(Logradouro.Tag.ToString()))
                Logradouro.Tag = "0";
            reg.Id_logradouro = string.IsNullOrWhiteSpace(Logradouro.Text) ? 0 : Convert.ToInt32(Logradouro.Tag.ToString());
            reg.Nome_logradouro = reg.Id_cidade != 413 ? Logradouro.Text : "";
            reg.Numero_imovel = Numero.Text == "" ? 0 : Convert.ToInt32(Numero.Text);
            reg.Complemento = Complemento.Text;
            reg.Email ="";

            Forms.Endereco f1 = new Forms.Endereco(reg, true, true, true, true);
            f1.ShowDialog();
            if (!f1.EndRetorno.Cancelar) {
                Bairro.Text = f1.EndRetorno.Nome_bairro;
                Bairro.Tag = f1.EndRetorno.Id_bairro.ToString();
                Logradouro.Text = f1.EndRetorno.Nome_logradouro;
                Logradouro.Tag = f1.EndRetorno.Id_logradouro.ToString();
                Numero.Text = f1.EndRetorno.Numero_imovel.ToString();
                Complemento.Text = f1.EndRetorno.Complemento;
                Cep.Text = f1.EndRetorno.Cep.ToString("00000-000");
                if (End1Option.Checked) {
                    Carrega_Endereco_Entrega_Imovel();
                }
            }
        }

        private void BtEndEntrega_Click(object sender, EventArgs e) {
            GTI_Models.Models.Endereco reg = new GTI_Models.Models.Endereco {
                Id_pais = 1,
                Sigla_uf = UF_EE.Text == "" ? "SP" : UF_EE.Text,
                Id_cidade = string.IsNullOrWhiteSpace(Cidade_EE.Text) ? 413 : Convert.ToInt32(Cidade_EE.Tag.ToString()),
                Id_bairro = string.IsNullOrWhiteSpace(Bairro_EE.Text) ? 0 : Convert.ToInt32(Bairro_EE.Tag.ToString())
            };
            if (Logradouro_EE.Tag == null) Logradouro_EE.Tag = "0";
            if (string.IsNullOrWhiteSpace(Logradouro_EE.Tag.ToString()))
                Logradouro_EE.Tag = "0";
            reg.Id_logradouro = string.IsNullOrWhiteSpace(Logradouro_EE.Text) ? 0 : Convert.ToInt32(Logradouro_EE.Tag.ToString());
            reg.Nome_logradouro = reg.Id_cidade != 413 ? Logradouro_EE.Text : "";
            reg.Numero_imovel = Numero_EE.Text == "" ? 0 : Convert.ToInt32(Numero_EE.Text);
            reg.Complemento = Complemento_EE.Text;
            reg.Email = "";


            Endereco f1 = new Endereco(reg, false, true, true, false);
            f1.ShowDialog();
            if (!f1.EndRetorno.Cancelar) {
                UF_EE.Text = f1.EndRetorno.Sigla_uf;
                Cidade_EE.Text = f1.EndRetorno.Nome_cidade;
                Cidade_EE.Tag = f1.EndRetorno.Id_cidade.ToString();
                Bairro_EE.Text = f1.EndRetorno.Nome_bairro;
                Bairro_EE.Tag = f1.EndRetorno.Id_bairro.ToString();
                Logradouro_EE.Text = f1.EndRetorno.Nome_logradouro;
                Logradouro_EE.Tag = f1.EndRetorno.Id_logradouro.ToString();
                Numero_EE.Text = f1.EndRetorno.Numero_imovel.ToString();
                Complemento_EE.Text = f1.EndRetorno.Complemento;
                CEP_EE.Text = f1.EndRetorno.Cep.ToString("00000-000");
            }
        }

        private void TxtTestada_Face_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void TxtTestada_Metro_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void BtAddTestada_Click(object sender, EventArgs e) {
            if(Testada_Face.Text.Trim()=="")
                MessageBox.Show("Digite o nº da face.","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else {
                if(gtiCore.ExtractNumber( Testada_Metro.Text.Trim())=="")
                    MessageBox.Show("Digite o comprimento da testada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    bool bFind = false;
                    foreach (ListViewItem item in TestadaListView.Items) {
                        if (Convert.ToInt32(item.Text) == Convert.ToInt32(Testada_Face.Text)) {
                            bFind = true;
                            break;
                        }
                    }
                    if (bFind)
                        MessageBox.Show("Face já cadastrada.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        ListViewItem reg = new ListViewItem(Convert.ToInt32(Testada_Face.Text).ToString("00"));
                        reg.SubItems.Add( string.Format("{0:0.00}", Convert.ToDecimal(Testada_Metro.Text)));
                        TestadaListView.Items.Add(reg);
                        Testada_Face.Text = "";
                        Testada_Metro.Text = "";
                    }
                }
            }
        }

        private void BtDelTestada_Click(object sender, EventArgs e) {
            if (TestadaListView.SelectedItems.Count == 0)
                MessageBox.Show("Selecione a testada a ser removida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                TestadaListView.SelectedItems[0].Remove();
        }

        private void BtCancelPnlArea_Click(object sender, EventArgs e) {
            AreaPnl.Visible = false;
            TopPanel.Enabled = true;
            ImovelTab.Enabled = true;
            BarToolStrip.Enabled = true;
        }

        private void TxtNumProcesso_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != (char)Keys.Return && e.KeyChar != (char)Keys.Tab) {
                const char Delete = (char)8;
                const char Minus = (char)45;
                const char Barra = (char)47;
                if (e.KeyChar == Minus && ProcessoArea.Text.Contains("-"))
                    e.Handled = true;
                else {
                    if (e.KeyChar == Barra && ProcessoArea.Text.Contains("/"))
                        e.Handled = true;
                    else
                        e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete && e.KeyChar != Barra && e.KeyChar != Minus;
                }
            }
        }

        private void TxtQtdePav_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void TxtAreaTerreno_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }

        }

        private void TxtFracao_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }

        }

        private void TxtAreaConstruida_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }

        }

        private void BtFoto_Click(object sender, EventArgs e) {
            if (!bAddNew){
                int _codigo = Convert.ToInt32(Codigo.Text);
                Imovel_bll imovel_Class = new Imovel_bll(_connection);
                List<Foto_imovel> Lista = imovel_Class.Lista_Foto_Imovel(_codigo);
                if (Lista.Count > 0)
                {
                    Foto_Imovel frm = new Foto_Imovel(_codigo);
                    frm.ShowDialog(this);
                }
                else
                    MessageBox.Show("Não existem fotos cadastradas para este imóvel.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtFind_Click(object sender, EventArgs e) {
            using (var form = new Imovel_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    int val = form.ReturnValue;
                    ClearFields();
                    CarregaImovel(val);
                }
            }
        }

        private void BtPrint_Click(object sender, EventArgs e) {
            //TODO: Imprimir dados do imóvel
        }

        private void BtOkPnlArea_Click(object sender, EventArgs e) {
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

            if (!gtiCore.IsEmptyDate(DataAprovacao.Text)  && !gtiCore.IsDate(DataAprovacao.Text) ) {
                MessageBox.Show("Data de aprovação inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!string.IsNullOrWhiteSpace(ProcessoArea.Text)) {
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
                AreaListView.Items[idx].SubItems[2].Text= UsoConstrucaoList.Text;
                AreaListView.Items[idx].SubItems[3].Text= TipoConstrucaoList.Text;
                AreaListView.Items[idx].SubItems[4].Text= CategoriaConstrucaoList.Text;
                AreaListView.Items[idx].SubItems[5].Text= QtdePavimentos.Text;
                AreaListView.Items[idx].SubItems[6].Text= DataAprovacao.Text;
                AreaListView.Items[idx].SubItems[7].Text = ProcessoArea.Text;
                AreaListView.Items[idx].SubItems[2].Tag = UsoConstrucaoList.SelectedValue.ToString();
                AreaListView.Items[idx].SubItems[3].Tag = TipoConstrucaoList.SelectedValue.ToString();
                AreaListView.Items[idx].SubItems[4].Tag = CategoriaConstrucaoList.SelectedValue.ToString();
            }
            Renumera_Sequencia_Area();

            AreaPnl.Visible = false;
            TopPanel.Enabled = true;
            ImovelTab.Enabled = true;
            BarToolStrip.Enabled = true;
        }

        private void Renumera_Sequencia_Area() {
            int n = 1;
            foreach (ListViewItem item in AreaListView.Items) {
                item.Text = n.ToString("00");
                n++;
            }
        }

        private void CarregaImovel(int Codigo) {
            if (string.IsNullOrEmpty(this.Codigo.Text)) return;
            
            Imovel_bll clsImovel = new Imovel_bll(_connection);
            ImovelStruct regImovel = clsImovel.Dados_Imovel(Codigo);
            if (regImovel.Codigo == 0)
                MessageBox.Show("Imóvel não cadastrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                this.Codigo.Text = Codigo.ToString("000000");
                StringBuilder sInscricao = new StringBuilder();
                sInscricao.Append(regImovel.Distrito.ToString() + ".");
                sInscricao.Append(regImovel.Setor.ToString("00") + ".");
                sInscricao.Append(regImovel.Quadra.ToString("0000") + ".");
                sInscricao.Append(regImovel.Lote.ToString("00000") + ".");
                sInscricao.Append(regImovel.Seq.ToString("00") + ".");
                sInscricao.Append(regImovel.Unidade.ToString("00") + ".");
                sInscricao.Append(regImovel.SubUnidade.ToString("000"));
                Inscricao.Text = sInscricao.ToString();
                Condominio.Text = "[" + regImovel.NomeCondominio.ToString() + "]";
                ImuneCheck.Checked = Convert.ToBoolean(regImovel.Imunidade);
                IsentoCIPCheck.Checked = Convert.ToBoolean(regImovel.Cip);
                ConjugadoCheck.Checked = Convert.ToBoolean(regImovel.Conjugado);
                ResideCheck.Checked = Convert.ToBoolean(regImovel.ResideImovel);
                if (Convert.ToBoolean(regImovel.Inativo)) {
                    Ativo.Text = "INATIVO";
                    Ativo.ForeColor = Color.Red;
                } else {
                    Ativo.Text = "ATIVO";
                    Ativo.ForeColor = Color.Green;
                }

                MT1Check.Checked = regImovel.TipoMat == "M" ? true : false;
                MT2Check.Checked = regImovel.TipoMat == "T" ? true : false;
                Matricula.Text = regImovel.NumMatricula.ToString();
                Distrito.Text = regImovel.Distrito.ToString();
                Setor.Text = regImovel.Setor.ToString("00");
                Face.Text = regImovel.Seq.ToString("00");
                Quadra.Text = regImovel.Quadra.ToString("0000");
                Lote.Text = regImovel.Lote.ToString("00000");
                Face.Text = regImovel.Seq.ToString("00");
                Unidade.Text = regImovel.Unidade.ToString("00");
                SubUnidade.Text = regImovel.SubUnidade.ToString("000");
                Complemento.Text = regImovel.Complemento.ToString();
                Numero.Text = regImovel.Numero.ToString();
                Logradouro.Text = regImovel.NomeLogradouro.ToString();
                Logradouro.Tag = regImovel.CodigoLogradouro.ToString();
                Bairro.Text = regImovel.NomeBairro.ToString();
                Bairro.Tag = regImovel.CodigoBairro.ToString();
                Quadras.Text = regImovel.QuadraOriginal.ToString();
                Lotes.Text = regImovel.LoteOriginal.ToString();
                Cep.Text =  Convert.ToInt32(regImovel.Cep.ToString()).ToString("00000-000");
                FracaoIdeal.Text = string.Format("{0:0.00}", regImovel.FracaoIdeal);
                AreaTerreno.Text = string.Format("{0:0.00}", regImovel.Area_Terreno);
                BenfeitoriaList.SelectedValue = regImovel.Benfeitoria == 0 ? -1 : regImovel.Benfeitoria;
                CategoriaTerrenoList.SelectedValue = regImovel.Categoria == 0 ? -1 : regImovel.Categoria;
                PedologiaList.SelectedValue = regImovel.Pedologia == 0 ? -1 : regImovel.Pedologia;
                SituacaoList.SelectedValue = regImovel.Situacao == 0 ? -1 : regImovel.Situacao;
                TopografiaList.SelectedValue = regImovel.Topografia == 0 ? -1 : regImovel.Topografia;
                UsoTerrenoList.SelectedValue = regImovel.Uso_terreno == 0 ? -1 : regImovel.Uso_terreno;
                Benfeitoria.Text = regImovel.Benfeitoria_Nome;
                Categoria.Text = regImovel.Categoria_Nome;
                Pedologia.Text = regImovel.Pedologia_Nome;
                Situacao.Text = regImovel.Situacao_Nome;
                Topografia.Text = regImovel.Topografia_Nome;
                UsoTerreno.Text = regImovel.Uso_terreno_Nome;

                //Carrega proprietário
                List<ProprietarioStruct> Lista = clsImovel.Lista_Proprietario(Codigo);
                foreach (ProprietarioStruct reg in Lista) {
                    ListViewItem lvItem = new ListViewItem();
                    if (reg.Tipo == "P")
                        lvItem.Group = ProprietarioListView.Groups["groupPP"];
                    else
                        lvItem.Group = ProprietarioListView.Groups["groupPS"];
                    if (reg.Principal == true)
                        lvItem.Text = reg.Nome + " (Principal)";
                    else
                        lvItem.Text = reg.Nome;
                    lvItem.Tag = reg.Codigo.ToString();
                    ProprietarioListView.Items.Add(lvItem);
                }

                //Carrega testada
                List<GTI_Models.Models.Testada> ListaT = clsImovel.Lista_Testada(Codigo);
                foreach (GTI_Models.Models.Testada reg in ListaT) {
                    ListViewItem lvItem = new ListViewItem(reg.Numface.ToString("00"));
                    lvItem.SubItems.Add(string.Format("{0:0.00}", (decimal)reg.Areatestada));
                    TestadaListView.Items.Add(lvItem);
                }

                //Carrega Endereço de Entrega
                End1Option.Checked = false;End2Option.Checked = false;End3Option.Checked = false;
                if (regImovel.EE_TipoEndereco == 0)
                    End1Option.Checked = true;
                else if (regImovel.EE_TipoEndereco == 1)
                    End2Option.Checked = true;
                else
                    End3Option.Checked = true;

                TipoEndereco Tipoend = regImovel.EE_TipoEndereco == 0 ? TipoEndereco.Local : regImovel.EE_TipoEndereco == 1 ? TipoEndereco.Proprietario : TipoEndereco.Entrega;
                EnderecoStruct regEntrega = clsImovel.Dados_Endereco(Codigo, Tipoend);
                if (regEntrega != null) {
                    Logradouro_EE.Text = regEntrega.Endereco.ToString();
                    Logradouro_EE.Tag = regEntrega.CodLogradouro.ToString();
                    Numero_EE.Text = regEntrega.Numero.ToString();
                    Complemento_EE.Text = regEntrega.Complemento??"";
                    UF_EE.Text = regEntrega.UF.ToString();
                    Cidade_EE.Text = regEntrega.NomeCidade.ToString();
                    Cidade_EE.Tag = regEntrega.CodigoCidade.ToString();
                    Bairro_EE.Text = regEntrega.NomeBairro.ToString();
                    Bairro_EE.Tag = regEntrega.CodigoBairro.ToString();
                    CEP_EE.Text = regEntrega.Cep==null?"00000-000":  Convert.ToInt32(regEntrega.Cep.ToString()).ToString("00000-000");
                }

                //Carrega Área
                short n = 1;
                decimal SomaArea = 0;
                List<AreaStruct> ListaA = clsImovel.Lista_Area(Codigo);
                foreach (AreaStruct reg in ListaA) {
                    ListViewItem lvItem = new ListViewItem(n.ToString("00"));
                    lvItem.SubItems.Add(string.Format("{0:0.00}", (decimal)reg.Area));
                    lvItem.SubItems.Add(reg.Uso_Nome);
                    lvItem.SubItems.Add(reg.Tipo_Nome);
                    lvItem.SubItems.Add(reg.Categoria_Nome);
                    lvItem.SubItems.Add(reg.Pavimentos.ToString());
                    if(reg.Data_Aprovacao!=null)
                        lvItem.SubItems.Add(Convert.ToDateTime(reg.Data_Aprovacao).ToString("dd/MM/yyyy"));
                    else
                        lvItem.SubItems.Add("");
                    if (string.IsNullOrWhiteSpace(reg.Numero_Processo))
                        lvItem.SubItems.Add("");
                    else {
                        if (reg.Numero_Processo.Contains("-"))//se já tiver DV não precisa inserir novamente
                            lvItem.SubItems.Add(reg.Numero_Processo);
                        else {
                            Processo_bll processo_Class = new Processo_bll(_connection);
                            lvItem.SubItems.Add(processo_Class.Retorna_Processo_com_DV(reg.Numero_Processo));//corrige o DV
                        }
                    }
                    lvItem.Tag = reg.Seq.ToString();
                    lvItem.SubItems[2].Tag = reg.Uso_Codigo.ToString();
                    lvItem.SubItems[3].Tag = reg.Tipo_Codigo.ToString();
                    lvItem.SubItems[4].Tag = reg.Categoria_Codigo.ToString();
                    AreaListView.Items.Add(lvItem);
                    SomaArea += reg.Area;
                    n++;
                }
                if (AreaListView.Items.Count > 0)
                    AreaListView.Items[0].Selected = true;
                this.SomaArea.Text = string.Format("{0:0.00}", SomaArea);

                //Carrega Histórico
                n = 1;
                List<HistoricoStruct> ListaH = clsImovel.Lista_Historico(Codigo);
                foreach (HistoricoStruct reg in ListaH) {
                    ListViewItem lvItem = new ListViewItem(n.ToString("000"));
                    lvItem.SubItems.Add( Convert.ToDateTime(reg.Data).ToString("dd/MM/yyyy"));
                    lvItem.SubItems.Add(reg.Descricao);
                    lvItem.SubItems.Add(reg.Usuario_Nome);
                    lvItem.Tag = reg.Usuario_Codigo.ToString();
                    HistoricoListView.Items.Add(lvItem);
                    n++;
                }
                if (HistoricoListView.Items.Count > 0)
                    HistoricoListView.Items[0].Selected = true;

                
            }
        }

        private void btDel_Click(object sender, EventArgs e) {
            int Codigo = Convert.ToInt32(this.Codigo.Text);
            if (Codigo == 0)
                MessageBox.Show("Selecione um imóvel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroImovel_Inativar);
                if (!bAllow)
                    MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    if (Ativo.Text == "INATIVO")
                        MessageBox.Show("Este imóvel já esta inativo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        if (MessageBox.Show("Inativar este imóvel?","Confirmação",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes) {
                            Imovel_bll imovel_Class = new Imovel_bll(_connection);
                            Exception ex = imovel_Class.Inativar_imovel(Codigo);
                            if (ex != null) {
                                ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                                eBox.ShowDialog();
                            } else {
                                Ativo.Text = "INATIVO";
                                Ativo.ForeColor = Color.Red;
                            }
                        }
                    }
                }
            }
        }

        private void mnuAddHistorico_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroImovel_Alterar_Historico);
            if (bAllow) {
                if (String.IsNullOrEmpty(Inscricao.Text))
                    MessageBox.Show("Nenhum imóvel carregado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {

                }
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuRemoverHistorico_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroImovel_Alterar_Historico);
            if (bAllow) {
                if (String.IsNullOrEmpty(Inscricao.Text))
                    MessageBox.Show("Nenhum imóvel carregado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    if (HistoricoListView.Items.Count==0 && HistoricoListView.SelectedItems.Count>0)
                        MessageBox.Show("Selecione um histórico.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {

                    }
                }
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RemoverAreaMenu_Click(object sender, EventArgs e) {
            if (AreaListView.Items.Count == 0 || AreaListView.SelectedItems.Count == 0)
                MessageBox.Show("Selecione uma área.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (MessageBox.Show("Remover esta área?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    AreaListView.SelectedItems[0].Remove();
                    Renumera_Sequencia_Area();
                }
            }
        }

        private void MnuAdicionarA_Click(object sender, EventArgs e) {
            AreaConstruida.Text = "";
            UsoConstrucaoList.SelectedIndex=0;
            TipoConstrucaoList.SelectedIndex=0;
            CategoriaConstrucaoList.SelectedIndex=0;
            QtdePavimentos.Text = "";
            DataAprovacao.Text = "";
            ProcessoArea.Text = "";
            bNovaArea = true;
            ImovelTab.Enabled = false;
            BarToolStrip.Enabled = false;
            TopPanel.Enabled = false;
            AreaPnl.Visible = true;
            AreaPnl.BringToFront();
            AreaConstruida.Focus();
        }

        private void AlterarAreaMenu_Click(object sender, EventArgs e) {
            if (AreaListView.Items.Count == 0 || AreaListView.SelectedItems.Count == 0)
                MessageBox.Show("Selecione uma área.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                bNovaArea = false;
                ImovelTab.Enabled = false;
                BarToolStrip.Enabled = false;
                TopPanel.Enabled = false;
                AreaPnl.Visible = true;
                AreaPnl.BringToFront();
                ListViewItem item = AreaListView.SelectedItems[0];
                AreaConstruida.Text = item.SubItems[1].Text;
                UsoConstrucaoList.SelectedValue = Convert.ToInt16(item.SubItems[2].Tag.ToString());
                TipoConstrucaoList.SelectedValue = Convert.ToInt16(item.SubItems[3].Tag.ToString());
                CategoriaConstrucaoList.SelectedValue = Convert.ToInt16(item.SubItems[4].Tag.ToString());
                QtdePavimentos.Text = item.SubItems[5].Text;
                DataAprovacao.Text = item.SubItems[6].Text;
                ProcessoArea.Text = item.SubItems[7].Text;
                AreaConstruida.Focus();
            }
        }

        private void IptuChart_MouseMove(object sender, MouseEventArgs e) {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = IptuChart.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results) {
                if (result.ChartElementType == ChartElementType.DataPoint) {
                    var prop = result.Object as DataPoint;
                    if (prop != null) {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 10 &&
                            Math.Abs(pos.Y - pointYPixel) < 10) {
                            tooltip.Show("Exercício: " + prop.XValue + Environment.NewLine + ", Valor: R$" + string.Format("{0:0.00}", prop.YValues[0]), this.IptuChart,
                                            pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }

        private void OpcoesAreaButton_Click(object sender, EventArgs e) {

        }

        private void ZoomHistoricoButton_Click(object sender, EventArgs e) {
            if (HistoricoListView.SelectedItems.Count > 0) {
                string sData = HistoricoListView.SelectedItems[0].SubItems[1].Text;
                string sTexto = HistoricoListView.SelectedItems[0].SubItems[2].Text;
                ZoomBox f1 = new ZoomBox("Histórico do imóvel de " + sData, this, sTexto, true);
                f1.ShowDialog();
            } else
                MessageBox.Show("Selecione um histórico.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EditHistoricoButton_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroImovel_Alterar_Historico);
            if (bAllow) {
                if (HistoricoListView.SelectedItems.Count > 0) {
                    string sData = HistoricoListView.SelectedItems[0].SubItems[1].Text;
                    string sTexto = HistoricoListView.SelectedItems[0].SubItems[2].Text;
                    ZoomBox f1 = new ZoomBox("Histórico do imóvel de " + sData, this, sTexto, false);
                    f1.ShowDialog();
                    Sistema_bll sistema_Class = new Sistema_bll(_connection);
                    string sLogin = Properties.Settings.Default.LastUser;
                    HistoricoListView.SelectedItems[0].SubItems[1].Text = DateTime.Now.ToString("dd/MM/yyyy");
                    HistoricoListView.SelectedItems[0].SubItems[2].Text = f1.ReturnText;
                    HistoricoListView.SelectedItems[0].SubItems[3].Text = sistema_Class.Retorna_User_FullName(sLogin);
                    HistoricoListView.SelectedItems[0].Tag = sistema_Class.Retorna_User_LoginId(sLogin).ToString();
                } else
                    MessageBox.Show("Selecione um histórico.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AddHistoricoButton_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroImovel_Alterar_Historico);
            if (bAllow) {
                if (HistoricoListView.SelectedItems.Count > 0) {
                    string sData = DateTime.Now.ToString("dd/MM/yyyy");
                    ZoomBox f1 = new ZoomBox("Histórico do imóvel de " + sData, this, "", false);
                    f1.ShowDialog();
                    if (f1.ReturnText != "") {
                        Sistema_bll sistema_Class = new Sistema_bll(_connection);
                        ListViewItem lvItem = new ListViewItem((HistoricoListView.Items.Count + 1).ToString("000"));
                        lvItem.SubItems.Add(sData);
                        lvItem.SubItems.Add(f1.ReturnText);
                        string sLogin = Properties.Settings.Default.LastUser;
                        lvItem.SubItems.Add(sistema_Class.Retorna_User_FullName(sLogin));
                        lvItem.Tag = sistema_Class.Retorna_User_LoginId(sLogin).ToString();
                        HistoricoListView.Items.Add(lvItem);
                    }
                } else
                    MessageBox.Show("Selecione um histórico.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DelHistoricoButton_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroImovel_Alterar_Historico);
            if (bAllow) {
                if (HistoricoListView.SelectedItems.Count > 0) {
                    HistoricoListView.Items.Remove(HistoricoListView.SelectedItems[0]);
                } else
                    MessageBox.Show("Selecione um histórico.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void End1Option_CheckedChanged(object sender, EventArgs e) {
            if (End1Option.Checked) {
                Limpa_endereco_Entrega();
                Carrega_Endereco_Entrega_Imovel();
                EndEntregaButton.Enabled = false;
            }
        }

        private void End2Option_CheckedChanged(object sender, EventArgs e) {
            if (End2Option.Checked) {
                if (ProprietarioListView.Items.Count == 0) {
                    MessageBox.Show("Selecione antes os proprietários do imóvel", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    End1Option.Checked = true;
                } else {
                    int nCodigo = Convert.ToInt32(ProprietarioListView.Items[0].Tag.ToString());
                    Limpa_endereco_Entrega();
                    Carrega_Endereco_Entrega_Proprietario(nCodigo);
                    EndEntregaButton.Enabled = false;
                }
            }
        }

        private void End3Option_CheckedChanged(object sender, EventArgs e) {
            if (End3Option.Checked) {
                Limpa_endereco_Entrega();
                EndEntregaButton.Enabled = true;
            }
        }

        private void Carrega_Endereco_Entrega_Imovel() {
            Logradouro_EE.Text = Logradouro.Text;
            Logradouro_EE.Tag = Logradouro.Tag;
            Numero_EE.Text = Numero.Text;
            Complemento_EE.Text = Complemento.Text;
            Bairro_EE.Text = Bairro.Text;
            Bairro_EE.Tag = Bairro.Tag;
            CEP_EE.Text = Cep.Text;
            Cidade_EE.Text = "JABOTICABAL";
            Cidade_EE.Tag = "413";
            UF_EE.Text = "SP";
        }

        private void Carrega_Endereco_Entrega_Proprietario(int Codigo_Proprietario) {
            Cidadao_bll clsCidadao = new Cidadao_bll(_connection);
            CidadaoStruct _cidadao = clsCidadao.LoadReg(Codigo_Proprietario);
            if (_cidadao.EtiquetaC == "S") {
                Logradouro_EE.Text = _cidadao.EnderecoC;
                Logradouro_EE.Tag = _cidadao.CodigoLogradouroC;
                Numero_EE.Text = _cidadao.NumeroC.ToString();
                Complemento_EE.Text = _cidadao.ComplementoC;
                Bairro_EE.Text = _cidadao.NomeBairroC;
                Bairro_EE.Tag = _cidadao.CodigoBairroC.ToString();
                CEP_EE.Text = _cidadao.CepC.ToString();
                Cidade_EE.Text = _cidadao.NomeCidadeC;
                Cidade_EE.Tag = _cidadao.CodigoCidadeC.ToString();
                UF_EE.Text = _cidadao.UfC;
            } else {
                Logradouro_EE.Text = _cidadao.EnderecoR;
                Logradouro_EE.Tag = _cidadao.CodigoLogradouroR;
                Numero_EE.Text = _cidadao.NumeroR.ToString();
                Complemento_EE.Text = _cidadao.ComplementoR;
                Bairro_EE.Text = _cidadao.NomeBairroR;
                Bairro_EE.Tag = _cidadao.CodigoBairroR.ToString();
                CEP_EE.Text = _cidadao.CepR.ToString();
                Cidade_EE.Text = _cidadao.NomeCidadeR;
                Cidade_EE.Tag = _cidadao.CodigoCidadeR.ToString();
                UF_EE.Text = _cidadao.UfR;
            }
        }

        private void IPTUButton_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroImovel_IPTU);
            if (bAllow) {
                int nCodigo = Convert.ToInt32(Codigo.Text);
                if (nCodigo > 0) {
                    DrawGraph(nCodigo);
                    IPTUButton.Visible = false;
                    IptuChart.Visible = true;
                }
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DrawGraph(int Codigo) {
            gtiCore.Ocupado(this);
            IptuChart.Update();
            Series seriesTraffic = new Series();
            IptuChart.ChartAreas[0].Area3DStyle.Enable3D = true;
            seriesTraffic.ChartType = SeriesChartType.Bubble;
            seriesTraffic.BorderWidth = 2;

            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            List<SpExtrato> listaExtrato = tributario_Class.Lista_Extrato_Tributo(Codigo: Codigo);
            int[] xValues=new int[0];
            decimal[] yValues = new decimal[0];
            int nSize = 0;
            foreach  (SpExtrato item in listaExtrato) {
                bool bFind = false;
                for (int i = 0; i < xValues.Length; i++) {
                    if (xValues[i] == item.Anoexercicio) {
                        bFind = true;
                        break;
                    }
                }
                if (!bFind) {
                    Array.Resize(ref xValues, nSize + 1);
                    Array.Resize(ref yValues, nSize + 1);
                    xValues[nSize] = item.Anoexercicio;
                    nSize++;
                }
            }

            for (int i = 0; i < xValues.Length; i++) {
                decimal nSoma = 0;
                foreach (SpExtrato item in listaExtrato) {
                    if (item.Anoexercicio == xValues[i] && (item.Codlancamento==1 || item.Codlancamento==29)  && item.Numparcela>0 && item.Statuslanc!=5 )
                        nSoma += item.Valortributo;
                    else {
                        if (item.Anoexercicio > xValues[i])
                            break;
                    }
                }
                yValues[i] = nSoma;
            }

            for (int i = 0; i < xValues.Length; i++) {
                seriesTraffic.Points.AddXY(xValues[i], yValues[i]);
            }
            if (xValues.Length > 0) {
                IptuChart.BackGradientStyle = GradientStyle.TopBottom;
                IptuChart.BackColor = Color.LightSkyBlue;
                IptuChart.BackSecondaryColor = Color.WhiteSmoke;
                IptuChart.ChartAreas[0].BackColor = Color.LightSalmon;
                IptuChart.ChartAreas[0].AxisY.Minimum = 0;
                IptuChart.ChartAreas[0].AxisX.Minimum = xValues[0];
                IptuChart.ChartAreas[0].AxisX.Maximum = xValues[xValues.Length - 1];
                IptuChart.Series.Add(seriesTraffic);
                IptuChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightSteelBlue;
                IptuChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightSeaGreen;
                IptuChart.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
                IptuChart.ChartAreas[0].AxisY.LabelStyle.Enabled = true;
                IptuChart.ChartAreas[0].AxisX.IsStartedFromZero = false;
                IptuChart.ChartAreas[0].AxisY.LabelStyle.Format = "R$ #0.00";
                IptuChart.Series[0].IsValueShownAsLabel = true;
                IptuChart.ChartAreas[0].AxisX.Interval = 1;
                IptuChart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
                IptuChart.Series[0].LabelAngle = 90;
            }
            gtiCore.Liberado(this);
        }


    }
}
