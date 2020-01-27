using GTI_Desktop.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class ErrorBox : Form {
        public ErrorBox(string Title,string Message,Exception exception) {
            InitializeComponent();
            this.Text = Title;
            txtMsg.Text = Message;
            if ( exception.InnerException != null)
                txtDetail.Text = exception.InnerException.InnerException.ToString();
            else
                txtDetail.Text = "";
        }

        private void BtDetail_Click(object sender, EventArgs e) {
            if (this.Size.Height < 300) {
                this.Size = new Size(400, 330);
                btDetail.Image = Resources.Acima;
            } else {
                this.Size = new Size(400, 147);
                btDetail.Image = Resources.Abaixo;
            }
        }

        private void BtOk_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ErrorBox_Load(object sender, EventArgs e) {
            btDetail.Image = Resources.Abaixo;
        }
    }
}
