using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgTrack
{
    public partial class Form1 : Form
    {
        private Webcam wc;
        private Image curimg;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wc = new Webcam(pb_left.Size, pb_left);
            Size size = wc.Start();
        }

        private void Btn_capture_Click(object sender, EventArgs e)
        {
            curimg = pb_left.Image;
            pb_right.Image = curimg;
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
                    string color_r = colors[0];
                    string color_b = colors[1];
                    string color_g = colors[2];
                    MessageBox.Show("rød: " +color_r+ " blå: " +color_b+ " grøn: " +color_g);
                }
                
                
            }

        }

        private void exportSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var csv = new StringBuilder();
            var color_r = 255;
            var color_b = 255;
            var color_g = 255;
            var new_line = string.Format("{0},{1},{2}", color_r, color_b, color_g);
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
    }
}
