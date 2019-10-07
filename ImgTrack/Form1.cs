using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var open_file = dialog.FileName;
                using (var reader = new StreamReader(open_file))
                {
                    var imported_colors = reader.ReadLine();  
                    string[] colors = imported_colors.Split(',');
                    color = Color.FromArgb(Convert.ToInt32(colors[0]), Convert.ToInt32(colors[1]), Convert.ToInt32(colors[2]));
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
            dialog.Title = "I reject me humanity, JoJo!";

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
            fsettings.ShowDialog();
            color = fsettings.GetSelectedColor();
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
    }
}
