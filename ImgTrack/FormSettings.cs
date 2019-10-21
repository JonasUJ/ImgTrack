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
        public int Rcount;
        public int Gcount;
        public int Bcount;
        public int N;
        private Image img;
        private Bitmap bt;
        private Bitmap Oimg;

        public FormSettings(Image img, Color color, int N)
        {
            InitializeComponent();
            this.img = img;
            trackBarR.Value = color.R;
            trackBarG.Value = color.G;
            trackBarB.Value = color.B;
            trackN.Value = N;
            R = color.R;
            G = color.G;
            B = color.B;
            this.N = N;
            labelRed.Text = $"Red: {R}";
            labelGreen.Text = $"Green: {G}";
            labelBlue.Text = $"Blue: {B}";
            pb_preview.SizeChanged += new EventHandler(Resizer.PictureboxResize);
        }

        private void trackBarR_Scroll(object sender, EventArgs e)
        {
            R = trackBarR.Value;
            labelRed.Text = $"Red: {R}";
        }

        private void trackBarG_Scroll(object sender, EventArgs e)
        {
            G = trackBarG.Value;
            labelGreen.Text = $"Green: {G}";
        }

        private void trackBarB_Scroll(object sender, EventArgs e)
        {
            B = trackBarB.Value;
            labelBlue.Text = $"Blue: {B}";
        }

        private void trackN_Scroll(object sender, EventArgs e)
        {
            N = trackN.Value;
        }

        private void ChangeImage()
        {
            N = trackN.Value;
            for (int y = 0; y < bt.Height; y++)
            {
                for (int x = 0; x < bt.Width; x++)
                {
                    Color c = Oimg.GetPixel(x, y);
                    bt.SetPixel(x, y, (c.R > R-N && c.R < R+N && c.G > G-N && c.G < G+N && c.B > B-N && c.B < B+N ) ? Color.White : Color.Black);
                }
            }
            panelColor.BackColor = Color.FromArgb(R, G, B);
            ImageData imgd = new ImageData(bt);
            Bitmap withCross = imgd.DrawCross();
            pb_preview.Tag = withCross;
            pb_preview.Image = new Bitmap(withCross, Resizer.ResizeFrame(withCross.Size, pb_preview.Size));
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            bt = new Bitmap(img);
            Oimg = new Bitmap(img);
            ChartUtil.MakeIntoHistogram(chart_histogram, img);
            ChangeImage();
            for (int y = 0; y < bt.Height; y++)
            {
                for (int x = 0; x < bt.Width; x++)
                {
                    Color c = Oimg.GetPixel(x, y);
                    Rcount = c.R + Rcount;
                    Gcount = c.G + Gcount;
                    Bcount = c.B + Bcount;
                }
            }
            int total = (Rcount + Bcount + Gcount);
            panelAvg.BackColor = Color.FromArgb((int)(((double)Rcount / total) * 255), (int)(((double)Gcount / total) * 255), (int)(((double)Bcount / total) * 255));
        }

        public Color GetSelectedColor()
        {
            return Color.FromArgb(R,B,G);
        }

        public int GetAccuracy()
        {
            return N;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tb_MouseUp(object sender, MouseEventArgs e)
        {
            ChangeImage();
        }
    }
}
