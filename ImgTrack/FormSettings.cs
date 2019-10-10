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

        public FormSettings(Image img, Color color)
        {
            InitializeComponent();
            this.img = img;
            trackBarR.Value = color.R;
            trackBarG.Value = color.G;
            trackBarB.Value = color.B;
            R = color.R;
            G = color.G;
            B = color.B;
            labelRed.Text = $"Red: {R}";
            labelGreen.Text = $"Green: {G}";
            labelBlue.Text = $"Blue: {B}";
        }

        private void trackBarR_Scroll(object sender, EventArgs e)
        {
            R = trackBarR.Value;
            labelRed.Text = $"Red: {R}";
            ChangeImage();
        }

        private void trackBarG_Scroll(object sender, EventArgs e)
        {
            G = trackBarG.Value;
            labelGreen.Text = $"Green: {G}";
            ChangeImage();
        }

        private void trackBarB_Scroll(object sender, EventArgs e)
        {
            B = trackBarB.Value;
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
            panelColor.BackColor = Color.FromArgb(R, G, B);
            ImageData imgd = new ImageData(bt);
            pictureBoxPreview.Image = imgd.DrawCross();
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
                    
                    /*if (c.R>c.G && c.R>c.B)
                    {
                        Rcount = Rcount + 1;
                    }
                    if (c.G>c.R && c.G>c.B)
                    {
                        Gcount = Gcount + 1;
                    }
                    if (c.B>c.G && c.B>c.R)
                    {
                        Bcount = Bcount + 1;
                    } */
                }
            }
            int total = (Rcount + Bcount + Gcount);
            /* panelAvg.BackColor = Color.FromArgb((int)((double)Rcount / total * 255), (int)((double)Gcount / total * 255), (int)((double)Bcount / total * 255)); */
            panelAvg.BackColor = Color.FromArgb((int)(((double)Rcount / total) * 255), (int)(((double)Gcount / total) * 255), (int)(((double)Bcount / total) * 255));
        }

        public Color GetSelectedColor()
        {
            return Color.FromArgb(R,B,G);
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
