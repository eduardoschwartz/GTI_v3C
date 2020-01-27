using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Desktop.Editores;
using GTI_Models.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Parcela_Edit : Form {
        public static List<SpExtrato> _lista_tributo;
        int _codigo;
        short _ano, _lanc, _seq;
        byte _parc,_compl;
        string _connection = gtiCore.Connection_Name();

        public Parcela_Edit(List<SpExtrato> ListaTributo) {
            InitializeComponent();
            _lista_tributo = ListaTributo;
            _codigo = _lista_tributo[0].Codreduzido;
            _ano = _lista_tributo[0].Anoexercicio;
            _lanc = _lista_tributo[0].Codlancamento;
            _seq = _lista_tributo[0].Seqlancamento;
            _parc =(byte) _lista_tributo[0].Numparcela;
            _compl = _lista_tributo[0].Codcomplemento;

            LoadProperty clsProperty = new LoadProperty {
                Exercicio = ListaTributo[0].Anoexercicio,
                Lancamento = ListaTributo[0].Codlancamento.ToString("00") + "-" + ListaTributo[0].Desclancamento,
                Sequencia = ListaTributo[0].Seqlancamento,
                Parcela = ListaTributo[0].Numparcela,
                Complemento = ListaTributo[0].Codcomplemento,
                Data_Vencimento = Convert.ToDateTime(ListaTributo[0].Datavencimento).ToString("dd/MM/yyyy"),
                Data_Base = Convert.ToDateTime(ListaTributo[0].Datadebase).ToString("dd/MM/yyyy"),
                StatusLancamento = ListaTributo[0].Statuslanc.ToString() + "-" + ListaTributo[0].Situacao,
                Data_Inscricao = ListaTributo[0].Datainscricao == null ? "" : Convert.ToDateTime(ListaTributo[0].Datainscricao).ToString("dd/MM/yyyy"),
                Numero_Certidao = ListaTributo[0].Certidao == null ? 0 : (int)ListaTributo[0].Certidao,
                Pagina_Livro = ListaTributo[0].Pagina == null ? 0 : (int)ListaTributo[0].Pagina,
                Numero_Livro = ListaTributo[0].Numlivro == null ? 0 : (int)ListaTributo[0].Numlivro,
                Data_Ajuizamento = ListaTributo[0].Dataajuiza == null ? "" : Convert.ToDateTime(ListaTributo[0].Dataajuiza).ToString("dd/MM/yyyy"),
                Tributos = "(...) ==>"
            };

            
            pGrid.SelectedObject = clsProperty;
            pGrid.ExpandAllGridItems();
            EnableGrid();

        }

        private void PGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            Exception ex = null;
            string _valor = e.ChangedItem.Value.ToString();
            switch (e.ChangedItem.Label) {
                case "Situação do lançamento":
                    byte _status = Convert.ToByte(_valor.Substring(0, _valor.ToString().IndexOf("-")));
                    ex = tributario_Class.Alterar_Status_Lancamento(_codigo,_ano,_lanc,_seq,_parc,_compl,_status);
                    break;
                case "Data de vencimento":
                    DateTime _vencto = Convert.ToDateTime(_valor);
                    ex = tributario_Class.Alterar_Data_Vencimento(_codigo, _ano, _lanc, _seq, _parc, _compl, _vencto);
                    break;
                case "Data base":
                    DateTime _data_base = Convert.ToDateTime(_valor);
                    ex = tributario_Class.Alterar_Data_Base(_codigo, _ano, _lanc, _seq, _parc, _compl, _data_base);
                    break;
                case "N° do livro":
                    int _livro = Convert.ToInt32(_valor);
                    ex = tributario_Class.Alterar_Numero_Livro(_codigo, _ano, _lanc, _seq, _parc, _compl, _livro);
                    break;
                case "N° da certidão":
                    int _certidao = Convert.ToInt32(_valor);
                    ex = tributario_Class.Alterar_Numero_Certidao(_codigo, _ano, _lanc, _seq, _parc, _compl, _certidao);
                    break;
                case "N° da página":
                    int _pagina = Convert.ToInt32(_valor);
                    ex = tributario_Class.Alterar_Pagina_Livro(_codigo, _ano, _lanc, _seq, _parc, _compl, _pagina);
                    break;
                case "Data de inscrição":
                    DateTime _data_insc = Convert.ToDateTime(_valor);
                    ex = tributario_Class.Alterar_Data_Inscricao(_codigo, _ano, _lanc, _seq, _parc, _compl, _data_insc);
                    break;
                case "Data de ajuizamento":
                    DateTime _data_ajuiza = Convert.ToDateTime(_valor);
                    ex = tributario_Class.Alterar_Data_Ajuizamento(_codigo, _ano, _lanc, _seq, _parc, _compl, _data_ajuiza);
                    break;
                default:
                    break;
            }
        }

        private void EnableGrid() {

            bool bAllow = !gtiCore.GetBinaryAccess((int)TAcesso.Editar_Parcela_Lancamentos);

            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(pGrid.SelectedObject.GetType())["Data_Vencimento"];
            ReadOnlyAttribute attrib = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
            FieldInfo isReadOnly = attrib.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            isReadOnly.SetValue(attrib, bAllow);

            descriptor = TypeDescriptor.GetProperties(pGrid.SelectedObject.GetType())["Data_Base"];
            attrib = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
            isReadOnly = attrib.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            isReadOnly.SetValue(attrib, bAllow);

            descriptor = TypeDescriptor.GetProperties(pGrid.SelectedObject.GetType())["StatusLancamento"];
            attrib = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
            isReadOnly = attrib.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            isReadOnly.SetValue(attrib, bAllow);

            descriptor = TypeDescriptor.GetProperties(pGrid.SelectedObject.GetType())["Tributos"];
            attrib = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
            isReadOnly = attrib.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            isReadOnly.SetValue(attrib, bAllow);

            bAllow = !gtiCore.GetBinaryAccess((int)TAcesso.Editar_Parcela_Divida_Ativa);

            descriptor = TypeDescriptor.GetProperties(pGrid.SelectedObject.GetType())["Data_Inscricao"];
            attrib = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
            isReadOnly = attrib.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            isReadOnly.SetValue(attrib, bAllow);

            descriptor = TypeDescriptor.GetProperties(pGrid.SelectedObject.GetType())["Numero_Certidao"];
            attrib = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
            isReadOnly = attrib.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            isReadOnly.SetValue(attrib, bAllow);

            descriptor = TypeDescriptor.GetProperties(pGrid.SelectedObject.GetType())["Numero_Livro"];
            attrib = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
            isReadOnly = attrib.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            isReadOnly.SetValue(attrib, bAllow);

            descriptor = TypeDescriptor.GetProperties(pGrid.SelectedObject.GetType())["Pagina_Livro"];
            attrib = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
            isReadOnly = attrib.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            isReadOnly.SetValue(attrib, bAllow);

            descriptor = TypeDescriptor.GetProperties(pGrid.SelectedObject.GetType())["Data_Ajuizamento"];
            attrib = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
            isReadOnly = attrib.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            isReadOnly.SetValue(attrib, bAllow);

            pGrid.SelectedObject = pGrid.SelectedObject;

        }
    }

    class LoadProperty {
        private int _exercicio, _sequencia, _parcela, _complemento, _numero_certidao, _numero_livro, _pagina_livro;
        private string _lancamento, _data_vencto, _data_base, _status, _data_inscricao, _data_ajuiza, _tributo ;

        [CategoryAttribute("Atributos"), DescriptionAttribute("Ano de exercício"), ReadOnly(true), DisplayName("Ano de exercício")]
        public int Exercicio {
            get {return _exercicio;}
            set { _exercicio = value; }
        }

        [CategoryAttribute("Atributos"), DescriptionAttribute("Lançamento"), ReadOnly(true), DisplayName("Lançamento")]
        public string Lancamento {
            get {return _lancamento;}
            set { _lancamento = value; }
        }

        [CategoryAttribute("Atributos"), DescriptionAttribute("Nº da sequencia"), ReadOnly(true), DisplayName("Nº da sequencia")]
        public int Sequencia {
            get {return _sequencia;}
            set { _sequencia = value; }
        }

        [CategoryAttribute("Atributos"), DescriptionAttribute("Nº da parcela"), ReadOnly(true), DisplayName("Nº da parcela")]
        public int Parcela {
            get {return _parcela;}
            set { _parcela = value; }
        }

        [CategoryAttribute("Atributos"), DescriptionAttribute("N° do complemento"), ReadOnly(true), DisplayName("N° do complemento")]
        public int Complemento {
            get {return _complemento;}
            set { _complemento = value; }
        }

        [CategoryAttribute("Dados do Lançamento"), DescriptionAttribute("Data de vencimento"), ReadOnly(true), DisplayName("Data de vencimento")]
        [EditorAttribute(typeof(Data_Editor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Data_Vencimento {
            get {return _data_vencto;}
            set {
                if (!gtiCore.IsDate(value) || Convert.ToDateTime(value) > Convert.ToDateTime("31/12/2020") || Convert.ToDateTime(value) < Convert.ToDateTime("01/01/1980"))
                    MessageBox.Show("Data de vencimento inválida.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    _data_vencto = Convert.ToDateTime(value).ToString("dd/MM/yyyy");
            }
        }

        [CategoryAttribute("Dados do Lançamento"), DescriptionAttribute("Data base"), ReadOnly(true), DisplayName("Data base")]
        [EditorAttribute(typeof(Data_Editor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Data_Base {
            get {return _data_base;}
            set {
                if (!gtiCore.IsDate(value) || Convert.ToDateTime(value) > Convert.ToDateTime("31/12/2020") || Convert.ToDateTime(value) < Convert.ToDateTime("01/01/1980"))
                    MessageBox.Show("Data base inválida.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    _data_base = Convert.ToDateTime(value).ToString("dd/MM/yyyy");
            }
        }

        [CategoryAttribute("Divida Ativa"), DescriptionAttribute("Data de inscrição"), ReadOnly(true), DisplayName("Data de inscrição")]
        [EditorAttribute(typeof(Data_Editor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Data_Inscricao {
            get {return _data_inscricao;}
            set {
                if (!gtiCore.IsDate(value))
                    _data_inscricao = null;
                else {
                    if (Convert.ToDateTime(value) > Convert.ToDateTime("31/12/2020") || Convert.ToDateTime(value) < Convert.ToDateTime("01/01/1980"))
                        MessageBox.Show("Data de inscrição inválida.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        _data_inscricao = Convert.ToDateTime(value).ToString("dd/MM/yyyy");
                }
            }
        }

        [CategoryAttribute("Divida Ativa"), DescriptionAttribute("N° da certidão"), ReadOnly(true), DisplayName("N° da certidão")]
        public int Numero_Certidao {
            get {return _numero_certidao;}
            set { _numero_certidao = value; }
        }

        [CategoryAttribute("Divida Ativa"), DescriptionAttribute("N° do livro"), ReadOnly(true), DisplayName("N° do livro")]
        public int Numero_Livro {
            get {return _numero_livro;}
            set { _numero_livro = value; }
        }

        [CategoryAttribute("Divida Ativa"), DescriptionAttribute("N° da página"), ReadOnly(true), DisplayName("N° da página")]
        public int Pagina_Livro {
            get {return _pagina_livro;}
            set { _pagina_livro = value; }
        }

        [CategoryAttribute("Divida Ativa"), DescriptionAttribute("Data de ajuizamento"), ReadOnly(true), DisplayName("Data de ajuizamento")]
        [EditorAttribute(typeof(Data_Editor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Data_Ajuizamento {
            get {return _data_ajuiza;}
            set {
                if (!gtiCore.IsDate(value))
                    _data_ajuiza = null;
                else {
                    if (Convert.ToDateTime(value) > Convert.ToDateTime("31/12/2020") || Convert.ToDateTime(value) < Convert.ToDateTime("01/01/1980"))
                        MessageBox.Show("Data de ajuizamento inválida.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        _data_ajuiza = Convert.ToDateTime(value).ToString("dd/MM/yyyy");
                }
            }
        }

        [CategoryAttribute("Dados do Lançamento"), DescriptionAttribute("Situação do lançamento"), ReadOnly(true), DisplayName("Situação do lançamento")]
        [TypeConverter(typeof(StatusConverter))]
        public string StatusLancamento {
            get { return _status;}
            set { _status = value;}
        }

        [CategoryAttribute("Dados dos Tributos"), DescriptionAttribute("Lista de tributos"), ReadOnly(true), DisplayName("Lista de tributos")]
        [EditorAttribute(typeof(Tributo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Tributos {
            get { return _tributo; }
            set {
                    _tributo = "(...) ==>";
            }
        }

    }

    public class StatusConverter : StringConverter {

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
            ArrayList _status = new ArrayList();
            Tributario_bll clsTributario = new Tributario_bll(gtiCore.Connection_Name());
            List<Situacaolancamento> Lista = clsTributario.Lista_Status();
            foreach (Situacaolancamento item in Lista) {
                _status.Add(item.Codsituacao.ToString("00") + "-" + item.Descsituacao);
            }

            return new StandardValuesCollection(_status);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) {
            return true;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {
            return true;
        }

    }


}
