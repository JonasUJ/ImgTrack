using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace ImgTrack
{
    [Serializable]
    public class NoCameraException : Exception
    {
        public NoCameraException() { }
        public NoCameraException(string message) : base(message) { }
        public NoCameraException(string message, Exception inner) : base(message, inner) { }
        protected NoCameraException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public class Webcam
    {
        private FilterInfoCollection videoDevices = null;
        public VideoCaptureDevice videoSource = null;
        private bool Busy = false;
        private Mutex ToggleMutex = new Mutex();

        public Mutex ImageMutex = new Mutex();
        private Bitmap currentImage;
        public Bitmap CurrentImage {
            get
            {
                ImageMutex.WaitOne();
                return currentImage;
            }
            private set { currentImage = value; }
        }
        public Size FrameSize { get => videoSource.VideoResolution.FrameSize; }

        public struct Cam
        {
            public PictureBox Box;
            public Filters.Filter Filter;
        }
        private List<Cam> Cams;

        public Webcam(List<Cam> cams)
        {
            Cams = cams;
        }

        // Get the devices names connected to the pc
        private FilterInfoCollection getCamList()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            return videoDevices;
        }

        // start the camera
        public void Start()
        {
            // Raise an exception incase no video device is found
            // or else initialise the videosource variable with the harware device
            // and other desired parameters.
            if (getCamList().Count == 0)
                throw new NoCameraException("Video device not found");
            else
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.VideoResolution = videoSource.VideoCapabilities[0];
                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                videoSource.Start();
            }
        }

        public void SetResolution(VideoCapabilities vcap)
        {
            videoSource.NewFrame -= new NewFrameEventHandler(video_NewFrame);
            Thread stopper = new Thread(delegate()
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            });
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            stopper.Start();
            stopper.Join();
            videoSource.VideoResolution = vcap;
            videoSource.Start();
        }

        private Bitmap Copy(Bitmap frame)
        {
            Bitmap newImage = new Bitmap(frame.Width, frame.Height);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(frame, new Rectangle(0, 0, frame.Width, frame.Height));
            }
            return newImage;
        }

        public void ToggleCam(Cam cam)
        {
            Thread Worker = new Thread((ThreadStart)delegate
            {
                ToggleMutex.WaitOne();
                if (Cams.Contains(cam))
                    Cams.Remove(cam);
                else
                    Cams.Add(cam);
                ToggleMutex.ReleaseMutex();
            });
            Worker.Start();
        }

        // EventHandler if new frame is ready
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (Busy) return;
            CurrentImage = Copy(eventArgs.Frame);
            CurrentImage.RotateFlip(RotateFlipType.Rotate180FlipY);
            ThreadPool.QueueUserWorkItem((WaitCallback)delegate
            {
                ToggleMutex.WaitOne();
                try
                {
                    foreach (var cam in Cams)
                    {
                        cam.Box.Invoke((MethodInvoker)delegate
                        {
                            if (cam.Box.Image != null)
                            {
                                cam.Box.Image.Dispose();
                                ((Bitmap)cam.Box.Tag).Dispose();
                            }
                            Bitmap tmp = cam.Filter(CurrentImage);
                            cam.Box.Image = Resizer.ResizeBitmap(tmp, Resizer.ResizeFrame(tmp.Size, cam.Box.Size));
                            cam.Box.Tag = tmp;
                            ImageMutex.ReleaseMutex();
                        });
                    }
                }
                catch (Exception ex) when (ex is InvalidOperationException ||
                                           ex is System.ComponentModel.InvalidAsynchronousStateException)
                {
                    // Form was closed before the invoke finished execution
                }
                ToggleMutex.ReleaseMutex();
                Busy = false;
            });
            ImageMutex.ReleaseMutex();
            Busy = true;
        }

        // Close the device safely
        public void Stop()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.NewFrame -= new NewFrameEventHandler(video_NewFrame);
                videoSource.SignalToStop();
                videoSource = null;
            }
        }
    }
}