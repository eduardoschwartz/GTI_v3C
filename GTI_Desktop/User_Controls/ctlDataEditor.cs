using GTI_Desktop.Classes;
using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace GTI_Desktop.User_Controls {
    public partial class ctlDataEditor : UserControl {
        private IWindowsFormsEditorService _editorService = null;
        public string _data_retorno, _data_inicio;

        private void MonthCalendar1_DateSelected(object sender, DateRangeEventArgs e) {
            e.Start.ToString("dd/MM/yyyy");
        }

        private void ctlDataEditor_Load(object sender, System.EventArgs e) {
            _data_retorno = _data_inicio;
            if (_data_inicio != null && gtiCore.IsDate(_data_inicio))
                MonthCalendar1.SetDate(Convert.ToDateTime(_data_inicio));
            else
                MonthCalendar1.SetDate(DateTime.Now);
        }

        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e) {
            DateTime[] myDates = { new DateTime(e.Start.Year, e.Start.Month, e.Start.Day, 0, 0, 0, 0) };
            this.MonthCalendar1.BoldedDates = myDates;
            _data_retorno = e.Start.ToString("dd/MM/yyyy");
        }

        private void cmdOK_Click(object sender, EventArgs e) {
            _editorService.CloseDropDown();
        }

        private void cmdSair_Click(object sender, EventArgs e) {
            _data_retorno = "";
            _editorService.CloseDropDown();
        }

        public ctlDataEditor(IWindowsFormsEditorService editorService) {
            InitializeComponent();
            _editorService = editorService;
        }




    }
}
