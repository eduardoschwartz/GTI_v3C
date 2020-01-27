using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Foto_Imovel : Form {
        string _connection = gtiCore.Connection_Name();
        string _path = gtiCore.Retorna_Path_Anexo();
        List<string> Lista_Fotos=new List<string>();
        int _pos, _total;

        public Foto_Imovel(int Codigo)
        {
            InitializeComponent();
            HeaderToolStrip.Renderer = new MySR();
            Imovel_bll imovel_Class = new Imovel_bll(_connection);
            List<Foto_imovel> Lista = imovel_Class.Lista_Foto_Imovel(Codigo);
            foreach (GTI_Models.Models.Foto_imovel item in Lista){
                string _foto = _path + "09\\"+ item.Pasta.ToString("00") + "\\" + item.Arquivo;
                Lista_Fotos.Add(_foto);
            }
            _pos = 0;_total = Lista_Fotos.Count;
            
            AnteriorButton.Enabled = false;
            if (_total == 1)
                ProximoButton.Enabled = false;
            Carrega_Foto(_pos);
        }

        private void AnteriorButton_Click(object sender, System.EventArgs e) {
            _pos--;
            if (_pos ==  0)
                AnteriorButton.Enabled = false;
            ProximoButton.Enabled = true;
            Carrega_Foto(_pos);
            AtualizaStatus();
        }

        private void ProximoButton_Click(object sender, System.EventArgs e) {
            _pos++;
            if (_pos == _total-1)
                ProximoButton.Enabled = false;
            AnteriorButton.Enabled = true;
            Carrega_Foto(_pos);
            AtualizaStatus();
        }

        private void Carrega_Foto(int Number) {

            Image i = Image.FromFile( Lista_Fotos[Number]);

            if (i.Width > MaximumSize.Width)
                Width = MaximumSize.Width;
            else
                Width = i.Width;

            if (i.Height > MaximumSize.Height)
                Height = MaximumSize.Height;
            else
                Height = i.Height;

            MainPictureBox.Image = i;
            MainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            AtualizaStatus();
        }

        private void AtualizaStatus() {
            FotoNumeroText.Text = "Foto: " + (_pos+1).ToString() + " de " + (_total).ToString();
        }

    }
}
