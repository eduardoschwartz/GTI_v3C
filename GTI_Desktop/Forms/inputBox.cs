using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTI_Desktop.Classes;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class inputBox : Form {
        private System.ComponentModel.Container components = null;
        private gtiCore.eTweakMode eMode;
        private int eDecimal = 2;


        public inputBox() {
            InitializeComponent();
        }

        private void TxtInput_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                cmdOK.PerformClick();
            else if (e.KeyCode == Keys.Escape)
                cmdCancel.PerformClick();
        }

        public string Show(string previewInput, string Title, string TheMessage) {
            eMode = gtiCore.eTweakMode.Normal;
            this.Text = Title;
            lblTitulo.Text = TheMessage;
            this.txtInput.Text = previewInput;
            base.ShowDialog();
            return this.txtInput.Text;
        }

        public string Show(string previewInput, string Title, string TheMessage, int length) {
            eMode = gtiCore.eTweakMode.Normal;
            if (length > 0) this.txtInput.MaxLength = length;
            this.Text = Title;
            lblTitulo.Text = TheMessage;
            this.txtInput.Text = previewInput;
            base.ShowDialog();
            return this.txtInput.Text;
        }
        public string Show(string previewInput, string Title, string TheMessage, int length, gtiCore.eTweakMode Mode) {
            eMode = Mode;
            if (length > 0) this.txtInput.MaxLength = length;
            this.Text = Title;
            lblTitulo.Text = TheMessage;
            this.txtInput.Text = previewInput;
            base.ShowDialog();
            return this.txtInput.Text;
        }
        public string Show(string previewInput, string Title, string TheMessage, int length, gtiCore.eTweakMode Mode, int decimalNumber) {
            eMode = Mode;
            eDecimal = decimalNumber;
            if (length > 0) this.txtInput.MaxLength = length;
            this.Text = Title;
            lblTitulo.Text = TheMessage;
            this.txtInput.Text = previewInput;
            base.ShowDialog();
            return this.txtInput.Text;
        }

        public new string Show() {
            this.txtInput.Text = "";
            base.ShowDialog();
            return this.txtInput.Text;
        }
        public new string ShowDialog() {
            return this.Show();
        }
        public new string Show(IWin32Window owner) {
            this.txtInput.Text = "";
            base.ShowDialog(owner);
            return this.txtInput.Text;
        }
        public new string ShowDialog(IWin32Window owner) {
            return this.Show(owner);
        }

        private void CmdCancel_Click(object sender, EventArgs e) {
            txtInput.Text = "";
            this.Close();
        }

        private void CmdOK_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void TxtInput_KeyPress(object sender, KeyPressEventArgs e) {
            e.KeyChar = gtiCore.Tweak(txtInput, e.KeyChar, eMode, eDecimal);
            if (e.KeyChar == '\0')
                e.Handled = true;
        }
    }
}
