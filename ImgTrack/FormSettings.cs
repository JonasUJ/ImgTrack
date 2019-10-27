using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImgTrack
{
    public partial class FormSettings : Form
    {
        public int Rcount;
        public int Gcount;
        public int Bcount;
        private Image img;
        private Bitmap Oimg;

        public FormSettings(Image img)
        {
            InitializeComponent();
            this.img = img;
            trackBarR.Value = Settings.R;
            trackBarG.Value = Settings.G;
            trackBarB.Value = Settings.B;
            trackN.Value = Settings.Accuracy;
            trackC.Value = (int)(Settings.Compression * 100);
            labelRed.Text = $"Red: {Settings.R}";
            labelGreen.Text = $"Green: {Settings.G}";
            labelBlue.Text = $"Blue: {Settings.B}";
            pb_preview.SizeChanged += new EventHandler(Resizer.PictureboxResize);
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(img);
            Oimg = new Bitmap(img);
            ChartUtil.MakeIntoHistogram(chart_histogram, img);
            ChangeImage();
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
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

        private void trackBarR_Scroll(object sender, EventArgs e)
        {
            Settings.R = (byte)trackBarR.Value;
            labelRed.Text = $"Red: {Settings.R}";
        }

        private void trackBarG_Scroll(object sender, EventArgs e)
        {
            Settings.G = (byte)trackBarG.Value;
            labelGreen.Text = $"Green: {Settings.G}";
        }

        private void trackBarB_Scroll(object sender, EventArgs e)
        {
            Settings.B = (byte)trackBarB.Value;
            labelBlue.Text = $"Blue: {Settings.B}";
        }

        private void trackN_Scroll(object sender, EventArgs e)
        {
            Settings.Accuracy = trackN.Value;
        }

        private void trackC_Scroll(object sender, EventArgs e)
        {
            Settings.Compression = trackC.Value / 100.0;
        }

        private void ChangeImage()
        {
            Bitmap withCross = Filters.TrackFilter(Oimg);
            panelColor.BackColor = Color.FromArgb(Settings.R, Settings.G, Settings.B);
            pb_preview.Tag = withCross;
            pb_preview.Image = Resizer.ResizeBitmap(withCross, Resizer.ResizeFrame(withCross.Size, pb_preview.Size));
        }

        private void Tb_MouseUp(object sender, MouseEventArgs e)
        {
            ChangeImage();
        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
