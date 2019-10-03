using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace ImgTrack
{
    public class Webcam
    {
        private FilterInfoCollection videoDevices = null;       //list of all videosources connected to the pc
        public VideoCaptureDevice videoSource = null;          //the selected videosource
        private PictureBox pb;

        public Webcam(PictureBox pb)
        {
            this.pb = pb;
        }

        // get the devices names cconnected to the pc
        private FilterInfoCollection getCamList()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            return videoDevices;
        }

        //start the camera
        public void Start()
        {
            //raise an exception incase no video device is found
            //or else initialise the videosource variable with the harware device
            //and other desired parameters.
            if (getCamList().Count == 0)
                throw new Exception("Video device not found");
            else
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.VideoResolution = videoSource.VideoCapabilities[0];
                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                videoSource.Start();
            }
        }

        private Bitmap ResizeCopy(Bitmap frame)
        {
            Bitmap newImage = new Bitmap(videoSource.VideoResolution.FrameSize.Width, videoSource.VideoResolution.FrameSize.Height);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(frame, new Rectangle(0, 0, videoSource.VideoResolution.FrameSize.Width, videoSource.VideoResolution.FrameSize.Height));
            }
            return newImage;
        }

        //eventhandler if new frame is ready
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = ResizeCopy(eventArgs.Frame);
            pb.Invoke((MethodInvoker)delegate
            {
                if (pb.Image != null)
                {
                    pb.Image.Dispose();
                }
                pb.Image = bitmap;
            });
            //Bitmap newFrame = AForge.Imaging.Image.Clone(eventArgs.Frame);
            //pb.Image = newFrame.Clone() as Bitmap;
            //newFrame.Dispose();
            //Bitmap frame = ResizeCopy(eventArgs.Frame);
            //this.pb.Image = frame.Clone() as Bitmap;
            //frame.Dispose();
        }

        //close the device safely
        public void Stop()
        {
            if (!(videoSource == null) && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource = null;
            }
        }
    }
}