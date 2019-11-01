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

        /// <summary>
        /// A Form for choosing video resolution
        /// </summary>
        /// <param name="webcam">Webcam whose resolutions to use as options</param>
        public VideoSettings(Webcam webcam)
        {
            InitializeComponent();
            this.webcam = webcam;
        }

        private void VideoSettings_Load(object sender, EventArgs e)
        {
            // Add options from the Webcams VideoCapabilities
            foreach (VideoCapabilities vcap in webcam.videoSource.VideoCapabilities)
            {
                AddOption(vcap);
            }
        }

        // Adds a RadioButton to the Control using the passed VideoCapabilities
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

        /// <summary>
        /// Get the selected VideoCapabilities
        /// </summary>
        /// <returns>The VideoCapabilities selected in the from</returns>
        public VideoCapabilities GetSelection()
        {
            RadioButton rbtn = flow_videoSettings.Controls.OfType<RadioButton>().Where(r => r.Checked).First(); // The checked RadioButton
            return (VideoCapabilities)rbtn.Tag;
        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
