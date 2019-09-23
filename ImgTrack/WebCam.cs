using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace ImgTrack
{
    class Webcam
    {
        private FilterInfoCollection videoDevices = null;       //list of all videosources connected to the pc
        private VideoCaptureDevice videoSource = null;          //the selected videosource
        private Size resolution;
        private PictureBox pb;

        public Size Resolution { get => resolution; set => resolution = value; }

        public Webcam(Size resolution, PictureBox pb)
        {
            this.resolution = resolution;
            this.pb = pb;
        }

        // get the devices names cconnected to the pc
        private FilterInfoCollection getCamList()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            return videoDevices;
        }

        //start the camera
        public Size Start()
        {
            //raise an exception incase no video device is found
            //or else initialise the videosource variable with the harware device
            //and other desired parameters.
            if (getCamList().Count == 0)
                throw new Exception("Video device not found");
            else
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                videoSource.Start();
                return videoSource.VideoCapabilities[0].FrameSize;
            }
        }

        //dummy method required for Image.GetThumbnailImage() method
        private bool imageconvertcallback()
        {
            return false;
        }

        //eventhandler if new frame is ready
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            this.pb.Image = (Bitmap)eventArgs.Frame.GetThumbnailImage(resolution.Width, resolution.Height, new Image.GetThumbnailImageAbort(imageconvertcallback), IntPtr.Zero);
        }

        //close the device safely
        public void Stop()
        {
            if (!(videoSource == null))
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
        }
    }
}