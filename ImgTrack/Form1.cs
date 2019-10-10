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
        public Color color = Color.Black;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wc = new Webcam(pb_left);
            wc.Start();
        }

        private void Btn_capture_Click(object sender, EventArgs e)
        {
            if (curimg != null) curimg.Dispose();
            curimg = pb_left.Image.Clone() as Bitmap;
            pb_right.Image = curimg;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            wc.Stop();
        }

        private void importSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Kore ga... Requiem da";
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
            var new_line = string.Format("{0},{1},{2}", color.R, color.B, color.G);
            csv.Append(new_line);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "CSV|.csv";
            dialog.Title = "I reject my humanity, JoJo!";

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
            if (curimg == null) img = pb_left.Image;
            else img = curimg.Clone() as Bitmap;
            FormSettings fsettings = new FormSettings(img, color);
            if (fsettings.ShowDialog(this) == DialogResult.OK)
            {
                color = fsettings.GetSelectedColor();
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

        private void Pb_Resize(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (curimg == null) return;
            Size newsize = ResizeFrame(curimg.Size, pb.Size);
            Console.WriteLine(pb.Size);
            pb.Image = new Bitmap(curimg, newsize);
        }

        private Size ResizeFrame(Size originalFrame, Size newFrame)
        {
            if (newFrame.Height / (double)originalFrame.Height >= newFrame.Width / (double)originalFrame.Width)
            {
                double ratio = (double)newFrame.Width / newFrame.Height;
                Size s = new Size();
                s.Width = newFrame.Width;
                s.Height = (int)(ratio * newFrame.Height * ((double)originalFrame.Height / originalFrame.Width));
                return s;
            }
            else
            {
                double ratio = (double)newFrame.Height / newFrame.Width;
                Size s = new Size();
                s.Height = newFrame.Height;
                s.Width = (int)(ratio * newFrame.Width * ((double)originalFrame.Width / originalFrame.Height));
                return s;
            }
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
            dialog.Title = "Pick your poison, Lad";

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
