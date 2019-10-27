using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using AForge.Video.DirectShow;

namespace ImgTrack
{
    public partial class VideoSettings : Form
    {
        private Webcam webcam;
        public VideoSettings(Webcam webcam)
        {
            InitializeComponent();
            this.webcam = webcam;
        }

        private void VideoSettings_Load(object sender, EventArgs e)
        {
            foreach(VideoCapabilities vcap in webcam.videoSource.VideoCapabilities)
            {
                AddOption(vcap);
            }
        }

        private void AddOption(VideoCapabilities vcap)
        {
            RadioButton rbtn = new RadioButton
            {
                Text = $"{vcap.FrameSize.Width}x{vcap.FrameSize.Height} {vcap.MaximumFrameRate}fps {vcap.BitCount}bit colors",
                Width = 160,
                Checked = webcam.videoSource.VideoResolution == vcap,
                Tag = vcap,
            };
            flow_videoSettings.Controls.Add(rbtn);
        }

        public VideoCapabilities GetSelection()
        {
            RadioButton rbtn = flow_videoSettings.Controls.OfType<RadioButton>().Where(r => r.Checked).First();
            return (VideoCapabilities)rbtn.Tag;
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
