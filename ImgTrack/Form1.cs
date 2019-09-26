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

        private void button1_Click(object sender, EventArgs e)
        {
            FormSettings Ftest = new FormSettings(curimg);
            Ftest.Show();
        }
    }
}
