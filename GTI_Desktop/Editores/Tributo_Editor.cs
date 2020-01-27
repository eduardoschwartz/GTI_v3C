using GTI_Desktop.User_Controls;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace GTI_Desktop.Editores {
    public class Tributo_Editor :UITypeEditor{
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
            if (context != null && provider != null) {
                IWindowsFormsEditorService editorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
                if (editorService != null) {
                    ctlTributoEditor dropDownEditor = new ctlTributoEditor(editorService);
                    editorService.DropDownControl(dropDownEditor);
                }
            }
            return base.EditValue(context, provider, value);
        }

    }
}
