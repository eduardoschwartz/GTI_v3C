using GTI_Desktop.User_Controls;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;


namespace GTI_Desktop.Editores {
    public class Data_Editor : UITypeEditor{

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
            if (context != null && provider != null) {
                IWindowsFormsEditorService editorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
                if (editorService != null) {
                    ctlDataEditor dropDownEditor = new ctlDataEditor(editorService);

                    if (value == null)
                        dropDownEditor._data_inicio = DateTime.Now.ToString("dd/MM/yyyy");
                    else
                        dropDownEditor._data_inicio = value.ToString();

                    editorService.DropDownControl(dropDownEditor);
                    return dropDownEditor._data_retorno.ToString();
                }
            }
            return EditValue(context, provider, value);
        }

    }
}
