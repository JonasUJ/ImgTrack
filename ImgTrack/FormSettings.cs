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
        public int N;
        public double Rp;
        public double Gp;
        public double Bp;
        private Image img;
        private Bitmap bt;
        private Bitmap Oimg;

        public FormSettings(Image img, Color color)
        {
            InitializeComponent();
            this.img = img;
            trackBarR.Value = color.R;
            trackBarG.Value = color.G;
            trackBarB.Value = color.B;
        }

        private void trackBarR_Scroll(object sender, EventArgs e)
        {
            R = trackBarR.Value;
            panelColor.BackColor = Color.FromArgb(R, G, B);
            labelRed.Text = $"Red: {R}";
            ChangeImage();
        }

        private void trackBarG_Scroll(object sender, EventArgs e)
        {
            G = trackBarG.Value;
            panelColor.BackColor = Color.FromArgb(R, G, B);
            labelGreen.Text = $"Green: {G}";
            ChangeImage();
        }

        private void trackBarB_Scroll(object sender, EventArgs e)
        {
            B = trackBarB.Value;
            panelColor.BackColor = Color.FromArgb(R, G, B);
            labelBlue.Text = $"Blue: {B}";
            ChangeImage();
        }

        private void trackN_Scroll(object sender, EventArgs e)
        {
            N = trackN.Value;
            ChangeImage();
        }

        private void ChangeImage()
        {
            N = trackN.Value;
            for (int y = 0; y < bt.Height; y++)
            {
                for (int x = 0; x < bt.Width; x++)
                {
                    Color c = Oimg.GetPixel(x, y);
                    //bt.SetPixel(x, y, Color.FromArgb((int)(c.R*Rp), (int)(c.G*Gp), (int)(c.B*Bp)));
                    bt.SetPixel(x, y, (c.R > R-N && c.R < R + N && c.G > G-N && c.G < G + N && c.B > B-N && c.B < B+N ) ? Color.White : Color.Black);
                }
            }
            pictureBoxPreview.Image = bt;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            bt = new Bitmap(img);
            Oimg = new Bitmap(img);
            ChartUtil.MakeIntoHistogram(chart_histogram, img);
        }

        public Color GetSelectedColor()
        {
            return Color.FromArgb(R,B,G);
        }

        
    }
}
