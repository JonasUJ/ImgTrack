using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgTrack
{
    public partial class FormSettings : Form
    {
        public int R;
        public int G;
        public int B;
        public double Rp;
        public double Gp;
        public double Bp;
        private Image img;
        private Bitmap bt;
        private Bitmap Oimg;

        public FormSettings(Image img)
        {
            InitializeComponent();
            this.img = img;
        }

        private void trackBarR_Scroll(object sender, EventArgs e)
        {
            R = trackBarR.Value;
            panelColor.BackColor = Color.FromArgb(R, G, B);
            Rp = R / 255.0;
            labelRed.Text = "Red"+Rp+"%";
            ChangeImage();
        }

        private void trackBarG_Scroll(object sender, EventArgs e)
        {
            G = trackBarG.Value;
            panelColor.BackColor = Color.FromArgb(R, G, B);
            Gp = G / 255.0;
            labelGreen.Text = "Green"+Gp+"%";
            ChangeImage();
        }

        private void trackBarB_Scroll(object sender, EventArgs e)
        {
            B = trackBarB.Value;
            panelColor.BackColor = Color.FromArgb(R, G, B);
            Bp = B / 255.0;
            labelBlue.Text = "Blue"+Bp+"%";
            ChangeImage();
        }

        private void ChangeImage()
        {
            for (int y = 0; y < bt.Height; y++)
            {
                for (int x = 0; x < bt.Width; x++)
                {
                    Color c = Oimg.GetPixel(x, y);
                    //bt.SetPixel(x, y, Color.FromArgb((int)(c.R*Rp), (int)(c.G*Gp), (int)(c.B*Bp)));
                    bt.SetPixel(x, y, (c.R > R && c.G > G && c.B > B) ? Color.Black : Color.White);
                }
            }
            pictureBoxPreview.Image = bt;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            bt = new Bitmap(img);
            Oimg = new Bitmap(img);
        }
    }
}
