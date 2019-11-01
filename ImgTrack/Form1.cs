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
        private Webcam wc; // Webcam object for handling connection to (and manipulation of) the computers videofeed
        private Image curimg; // The lastest picture taken with the Capture btn
        private Webcam.Cam TrackerCam; // Cam object with a Filters.TrackFilter

        public Form1()
        {
            InitializeComponent();

            // Make the PictureBoxes resize the image automatically
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
            // Register the Webcam with a Cam that has no filter (I.e. just a normal video feed)
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
            // But you can't click the button if it's not enabled, right?
            // Yes, but we call this event from thresholdToolStripMenuItem_Click in order to set curimg
            if (!btn_capture.Enabled) return;

            curimg = wc.CurrentImage.Clone() as Bitmap;
            pb_right.Image = Resizer.ResizeBitmap(curimg as Bitmap, Resizer.ResizeFrame(curimg.Size, pb_right.Size)); // Resize the image
            pb_right.Tag = curimg.Clone() as Bitmap;
            wc.ImageMutex.ReleaseMutex(); // Release a mutex... Kind of bad API design, but who cares.
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
            if (curimg == null) Btn_capture_Click(btn_capture, new EventArgs()); // Make sure curimg is set
            img = curimg.Clone() as Bitmap;
            FormSettings fsettings = new FormSettings(img);
            fsettings.ShowDialog(this);
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VideoSettings vsettings = new VideoSettings(wc);
            if (vsettings.ShowDialog(this) == DialogResult.OK)
            {
                bgw_setres.RunWorkerAsync(vsettings); // Changing camera in the background as to not slow down the UI
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
            // if/else changes btn appearance
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

            // Toggles the TrackerCam on/off. We can call it like this and be sure it's on/off according
            // to what the button says, because we call this nowhere else.
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
