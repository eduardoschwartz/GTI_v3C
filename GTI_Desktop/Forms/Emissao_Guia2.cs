using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static GTI_Models.modelCore;

namespace GTI_Desktop.Forms {
    public partial class Emissao_Guia2 : Form {
        string _connection = gtiCore.Connection_Name();
        int _codigo, hoveredIndex = -1;

        public Emissao_Guia2(int Codigo) {
            InitializeComponent();
            TipoGuiaList.SelectedIndex = 0;
            _codigo = Codigo;
            for (int i = 1994; i <= DateTime.Now.Year; i++) {
                ExercicioList.Items.Add(i.ToString());
            }
            for (int i = 2011; i <= DateTime.Now.Year ; i++) {
                TabelaList.Items.Add(i.ToString());
            }

            TabelaList.SelectedIndex = TabelaList.Items.Count - 1;
            ExercicioList.SelectedIndex = ExercicioList.Items.Count - 1;
        }

        private void CarregaTL() {
            AtividadeList.Items.Clear();
            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            EmpresaStruct reg= empresa_Class.Retorna_Empresa(_codigo);
            AtividadeList.Items.Add(new GtiTypes.CustomListBoxItem(reg.Atividade_nome, (int)reg.Atividade_codigo));
        }

        private void CarregaISS() {
            AtividadeList.Items.Clear();
            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            List<MobiliarioAtividadeISSStruct> _lista = empresa_Class.Lista_AtividadeISS_Empresa(_codigo);
            foreach (MobiliarioAtividadeISSStruct item in _lista) {
                AtividadeList.Items.Add(new GtiTypes.CustomListBoxItem(item.Descricao, item.Codigo_atividade));
            }
        }

        private void CarregaVS() {
            AtividadeList.Items.Clear();
            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            List<CnaeStruct> _lista = empresa_Class.Lista_Cnae_Empresa_VS(_codigo);
            foreach (CnaeStruct item in _lista) {
                AtividadeList.Items.Add(new GtiTypes.CustomListBoxItem(item.CNAE+'-'+item.Descricao, 0));
            }
        }

        private void LancamentoList_SelectedIndexChanged(object sender, EventArgs e) {
            if (LancamentoList.SelectedIndex > -1 && _codigo>0) {
                GtiTypes.CustomListBoxItem selectedItem = (GtiTypes.CustomListBoxItem)LancamentoList.SelectedItem;
                int _codLancamento = selectedItem._value;
                if(_codLancamento==50 || _codLancamento == 65) {
                    AbateNFText.ReadOnly = false;
                    AbateNFText.BackColor = Color.White;
                } else {
                    AbateNFText.ReadOnly = true;
                    AbateNFText.BackColor = BackColor;
                }
                Sistema_bll sistema_Class = new Sistema_bll(_connection);
                Contribuinte_Header_Struct _contribuinte = sistema_Class.Contribuinte_Header(_codigo);
                int _tipoGuia = TipoGuiaList.SelectedIndex;
                if (_contribuinte.Tipo == TipoCadastro.Imovel) {
                    if(_tipoGuia>1 && _tipoGuia < 4) {
                        MessageBox.Show("Um imóvel não pode ter lançamentos de ISS, Taxa de Licença e Vigilância Sanitária.","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        TipoGuiaList.SelectedIndex = 0;
                    }
                } else {
                    if (_tipoGuia == 5) {
                        MessageBox.Show("Apenas imóveis podem ter lançamentos de Roçada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TipoGuiaList.SelectedIndex = 0;
                    } else {
                        if (_tipoGuia == 1) {
                            MessageBox.Show("Apenas imóveis podem ter lançamentos de IPTU.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            TipoGuiaList.SelectedIndex = 0;
                        }
                    }
                }
                Carrega_Tributo(_codLancamento);
            }
        }

        private void Carrega_Lancamento(int _tipo) {
            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            List<GTI_Models.Models.Lancamento> _lista = tributario_Class.Lista_Lancamento();
            LancamentoList.Items.Clear();

            if (_tipo == 0) {
                foreach (GTI_Models.Models.Lancamento item in _lista) {
                    if ((item.Codlancamento != 1 && item.Codlancamento != 2 && item.Codlancamento != 3 && item.Codlancamento != 5 && item.Codlancamento != 6 &&
                          item.Codlancamento != 7 && item.Codlancamento != 8 && item.Codlancamento != 12 && item.Codlancamento != 13 &&
                          item.Codlancamento != 14 && item.Codlancamento != 20 && item.Codlancamento != 21 && item.Codlancamento != 29 && item.Codlancamento != 30))
                        LancamentoList.Items.Add(new GtiTypes.CustomListBoxItem(item.Descreduz, item.Codlancamento));
                }
            } else {
                foreach (GTI_Models.Models.Lancamento item in _lista) {
                    if (item.Codlancamento == _tipo)
                        LancamentoList.Items.Add(new GtiTypes.CustomListBoxItem(item.Descfull, item.Codlancamento));
                }
            }

            LancamentoList.SelectedIndex = 0;
        }

        private void TipoGuiaList_SelectedIndexChanged(object sender, EventArgs e) {
            switch (TipoGuiaList.SelectedIndex) {
                case 0:
                    Carrega_Lancamento(0);
                    break;
                case 1:
                    Carrega_Lancamento(1);
                    break;
                case 2:
                    if (_codigo >= 500000)
                        Carrega_Lancamento(6);
                    else {
                        CarregaTL();
                        if (AtividadeList.Items.Count > 0)
                            Carrega_Lancamento(6);
                        else {
                            MessageBox.Show("Empresa não possui atividade de taxa de licença cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            TipoGuiaList.SelectedIndex = 0;
                        }
                    }
                    break;
                case 3:
                    CarregaISS();
                    if (AtividadeList.Items.Count > 0)
                        Carrega_Lancamento(14);
                    else {
                        MessageBox.Show("Empresa não possui atividade de Iss Fixo cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TipoGuiaList.SelectedIndex = 0;
                    }
                    break;
                case 4:
                    CarregaVS();
                    if (AtividadeList.Items.Count > 0)
                        Carrega_Lancamento(13);
                    else {
                        MessageBox.Show("Empresa não possui atividade de Vigilância Sanitária cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TipoGuiaList.SelectedIndex = 0;
                    }
                    break;
                case 5:
                    Carrega_Lancamento(38);
                    break;
                default:
                    break;
            }
        }

        private void AtividadeList_MouseMove(object sender, MouseEventArgs e) {
            int newHoveredIndex =AtividadeList.IndexFromPoint(e.Location);
            if (hoveredIndex != newHoveredIndex) {
                hoveredIndex = newHoveredIndex;
                if (hoveredIndex > -1) {
                    ToolTip.Active = false;
                    ToolTip.SetToolTip(AtividadeList, ((GtiTypes.CustomListBoxItem)AtividadeList.Items[hoveredIndex])._name);
                    ToolTip.Active = true;
                }
            }
        }

        private void Carrega_Tributo(int _codigo_lancamento) {

        }
    }
}
