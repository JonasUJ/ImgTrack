﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgTrack
{
    public partial class Form1 : Form
    {
        private Webcam wc;
        private Image curimg;
        public Color color = Color.FromArgb(180, 180, 180);
        public int N = 50;

        public Form1()
        {
            InitializeComponent();
            pb_left.SizeChanged += new EventHandler(Resizer.PictureboxResize);
            pb_right.SizeChanged += new EventHandler(Resizer.PictureboxResize);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wc = new Webcam(pb_left);
            wc.Start();
        }

        private void Btn_capture_Click(object sender, EventArgs e)
        {
            curimg = wc.CurrentImage.Clone() as Bitmap;
            pb_right.Image = curimg;
            pb_right.Tag = curimg;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            wc.Stop();
        }

        private void importSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Importér en fil med indstillinger";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var open_file = dialog.FileName;
                using (var reader = new StreamReader(open_file))
                {
                    try
                    {
                        var imported_colors = reader.ReadLine();
                        string[] colors = imported_colors.Split(',');
                        color = Color.FromArgb(Convert.ToInt32(colors[0]), Convert.ToInt32(colors[1]), Convert.ToInt32(colors[2]));
                        N = Convert.ToInt32(colors[3]);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Denne fil er ikke understøttet", "Fil kunne ikke læses!", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void exportSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var csv = new StringBuilder();
            var new_line = string.Format("{0},{1},{2},{3}", color.R, color.B, color.G,N);
            csv.Append(new_line);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "CSV|.csv";
            dialog.Title = "Exportér en fil med indstillinger";

            StreamWriter writer = null;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                writer = new StreamWriter(dialog.FileName);
                writer.WriteLine(csv);
                writer.Close();
            }
        }

        private void thresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img;
            if (curimg == null) Btn_capture_Click(btn_capture, new EventArgs());
            img = curimg.Clone() as Bitmap;
            FormSettings fsettings = new FormSettings(img, color, N);
            if (fsettings.ShowDialog(this) == DialogResult.OK)
            {
                color = fsettings.GetSelectedColor();
                N = fsettings.GetAccuracy();
            }
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VideoSettings vsetings = new VideoSettings(wc);
            if (vsetings.ShowDialog(this) == DialogResult.OK)
            {
                bgw_setres.RunWorkerAsync(vsetings);
            }
        }

        private void Bgw_setres_DoWork(object sender, DoWorkEventArgs e)
        {
            wc.SetResolution(((VideoSettings)e.Argument).GetSelection());
        }
        
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (pb_right.Image != null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                pb_right.Image.Save(dialog.FileName + ".png", ImageFormat.Png);
            }
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Åben en billedefil";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var open_file = dialog.FileName;
                Bitmap bt = new Bitmap(open_file);
                pb_right.Image = bt;
                curimg = bt;
            }


        }
    }
}
