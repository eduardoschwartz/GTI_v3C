using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Web;

namespace GTI_Web.Pages {
    public partial class Turing : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Bitmap objBMP = new System.Drawing.Bitmap(70, 20);
            Graphics objGraphics = System.Drawing.Graphics.FromImage(objBMP);
            objGraphics.Clear(Color.LightYellow);
            objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            //' Configure font to use for text
            Font objFont = new Font("Arial", 16, FontStyle.Bold);
            string randomStr = "";
            int[] myIntArray = new int[5];
            int x;
            //That is to create the random # and add it to our string 
            Random autoRand = new Random();
            for (x = 0; x < 5; x++) {
                myIntArray[x] = System.Convert.ToInt32(autoRand.Next(0, 9));
                randomStr += (myIntArray[x].ToString());
            }
            HttpContext context = HttpContext.Current;
            context.Session.Add("randomStr", randomStr);
            //' Write out the text
            objGraphics.DrawString(randomStr, objFont, Brushes.LightBlue, 0, 0);
            HatchBrush hb = new HatchBrush(HatchStyle.DottedGrid, Color.White, Color.YellowGreen);
            objGraphics.DrawString(randomStr, objFont, hb, 0, 0);
            //' Set the content type and return the image
            Response.ContentType = "image/GIF";
            objBMP.Save(Response.OutputStream, ImageFormat.Gif);
            objFont.Dispose();
            objGraphics.Dispose();
            objBMP.Dispose();
        }
    }



}
