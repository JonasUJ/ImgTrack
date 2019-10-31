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
        private bool picking = false;
        //først erklære vi en række variabler, et billede og et bitmap som vi skal bruge senere i koden

        public FormSettings(Image img)
        {
            InitializeComponent();
            this.img = img;
            trackBarR.Value = Settings.R;
            trackBarG.Value = Settings.G;
            trackBarB.Value = Settings.B;
            trackN.Value = Settings.Accuracy;
            trackC.Value = (int)(Settings.Compression * 100);
            labelRed.Text = $"Rød: {Settings.R}";
            labelGreen.Text = $"Grøn: {Settings.G}";
            labelBlue.Text = $"Blå: {Settings.B}";
            pb_preview.SizeChanged += new EventHandler(Resizer.PictureboxResize);
            //Her hentes indstillinger, og sliders osv. bliver sat til deresretmæssige værdi
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            Settings.InSettings = true;
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
            labelRed.Text = $"Rød: {Settings.R}";
        }

        private void trackBarG_Scroll(object sender, EventArgs e)
        {
            Settings.G = (byte)trackBarG.Value;
            labelGreen.Text = $"Grøn: {Settings.G}";
        }

        private void trackBarB_Scroll(object sender, EventArgs e)
        {
            Settings.B = (byte)trackBarB.Value;
            labelBlue.Text = $"Blå: {Settings.B}";
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

        private void btn_picker_Click(object sender, EventArgs e)
        {
            if (picking)
            {
                btn_picker.BackColor = SystemColors.Control;
                gb_settings.Enabled = true;
                ChangeImage();
            }
            else
            {
                gb_settings.Enabled = false;
                btn_picker.BackColor = Color.FromArgb(30, 180, 30);
                pb_preview.Image = Resizer.ResizeBitmap(Oimg, Resizer.ResizeFrame(Oimg.Size, pb_preview.Size)); ;
                pb_preview.Tag = Oimg;
            }
            picking = !picking;
        }

        private void pb_preview_MouseClick(object sender, MouseEventArgs e)
        {
            if (!picking) return;
            Bitmap pbimg = pb_preview.Image as Bitmap;
            int x = e.X - (pb_preview.Width - pbimg.Width) / 2;
            int y = e.Y - (pb_preview.Height - pbimg.Height) / 2;
            if (!(x >= 0 && y >= 0 && x <= pbimg.Width && y <= pbimg.Height)) return;
            btn_picker.BackColor = SystemColors.Control;
            gb_settings.Enabled = true;
            picking = false;
            Color color = pbimg.GetPixel(x, y);
            Settings.R = color.R;
            Settings.G = color.G;
            Settings.B = color.B;
            trackBarR.Value = Settings.R;
            trackBarG.Value = Settings.G;
            trackBarB.Value = Settings.B;
            ChangeImage();
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.InSettings = false;
        }
    }
}
