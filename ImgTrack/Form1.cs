using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ImgTrack
{
    public partial class Form1 : Form
    {
        private Webcam wc;
        private Image curimg;
        private Webcam.Cam TrackerCam;

        public Form1()
        {
            InitializeComponent();
            pb_left.SizeChanged += new EventHandler(Resizer.PictureboxResize);
            pb_right.SizeChanged += new EventHandler(Resizer.PictureboxResize);
            TrackerCam = new Webcam.Cam
            {
                Box = pb_right,
                Filter = Filters.TrackFilter
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wc = new Webcam(new List<Webcam.Cam> {
                new Webcam.Cam {
                    Box = pb_left,
                    Filter = Filters.NoFilter
                }
            });

            try
            {
                wc.Start();
            }
            catch (NoCameraException)
            {
                MessageBox.Show("Kunne ikke finde en kamera enhed", "Intet kamera", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void Btn_capture_Click(object sender, EventArgs e)
        {
            if (!btn_capture.Enabled) return;
            curimg = wc.CurrentImage.Clone() as Bitmap;
            pb_right.Image = Resizer.ResizeBitmap(curimg as Bitmap, Resizer.ResizeFrame(curimg.Size, pb_right.Size));
            pb_right.Tag = curimg.Clone() as Bitmap;
            wc.ImageMutex.ReleaseMutex();
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
                        var imported_settingss = reader.ReadLine();
                        string[] settings = imported_settingss.Split(',');
                        Color color = Color.FromArgb(Convert.ToInt32(settings[0]), Convert.ToInt32(settings[1]), Convert.ToInt32(settings[2]));
                        Settings.R = color.R;
                        Settings.G = color.G;
                        Settings.B = color.B;
                        Settings.Accuracy = Convert.ToInt32(settings[3]);
                        Settings.Compression = Convert.ToDouble(settings[4]);
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
            string csv = Settings.Export();

            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "CSV|.csv",
                Title = "Exportér en fil med indstillinger"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dialog.FileName);
                writer.WriteLine(csv);
                writer.Close();
            }
        }

        private void thresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img;
            if (curimg == null) Btn_capture_Click(btn_capture, new EventArgs());
            img = curimg.Clone() as Bitmap;
            FormSettings fsettings = new FormSettings(img);
            if (fsettings.ShowDialog(this) == DialogResult.OK)
            {
                //
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

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Åben en billedefil";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var open_file = dialog.FileName;
                Bitmap bt = new Bitmap(open_file);
                pb_right.Image = bt;
                pb_right.Tag = bt;
                curimg = bt;
            }
        }

        private void btn_track_Click(object sender, EventArgs e)
        {
            if (btn_track.Text == "&Start Tracking")
            {
                btn_track.Text = "&Stop Tracking";
                btn_track.BackColor = Color.FromArgb(255, 96, 96);
            }
            else
            {
                btn_track.Text = "&Start Tracking";
                btn_track.BackColor = Color.FromArgb(0, 192, 0);
            }

            thresholdToolStripMenuItem.Enabled = !thresholdToolStripMenuItem.Enabled;
            btn_capture.Enabled = !btn_capture.Enabled;
            wc.ToggleCam(TrackerCam);
        }

        private void gemBilledeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pb_right.Image != null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                    pb_right.Image.Save(dialog.FileName + ".png", ImageFormat.Png);
            }
            else
            {
                MessageBox.Show("Der er ikke blevet taget noget billede. Tag et billede og prøv igen.", "Kan ikke gemme billede", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cb_isolate_CheckedChanged(object sender, EventArgs e)
        {
            Settings.IsolateColor = cb_isolate.Checked;
        }
    }
}
