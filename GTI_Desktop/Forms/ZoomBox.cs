using System;
using System.Drawing;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class ZoomBox : Form {
        private Form FormCalled { get; set; }
        public string ReturnText;

        public ZoomBox(String Titulo, Form FormCalling, string Texto, bool ReadOnly,int MaxLength=0) {
            InitializeComponent();
            this.Text = Titulo;
            this.Location = new Point(FormCalling.Location.X + (FormCalling.Width - this.Width) / 2, FormCalling.Location.Y + (FormCalling.Height - this.Height) + 55 / 2);
            FormCalled = FormCalling;
            if(MaxLength>0)
                txtZoom.MaxLength = MaxLength;
            txtZoom.Text = Texto;
            txtZoom.ReadOnly = ReadOnly;
            if (ReadOnly)
                tBar.Focus();
        }

        private void BtSair_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ZoomBox_FormClosing(object sender, FormClosingEventArgs e) {
            ReturnText = txtZoom.Text;
        }
    }
}
