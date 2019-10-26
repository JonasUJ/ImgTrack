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
    public class Webcam
    {
        private FilterInfoCollection videoDevices = null; //list of all videosources connected to the pc
        public VideoCaptureDevice videoSource = null; //the selected videosource
        private PictureBox pb;
        public Bitmap CurrentImage { get; private set; }

        public double Width { get => videoSource.VideoResolution.FrameSize.Width; }
        public double Height { get => videoSource.VideoResolution.FrameSize.Height; }

        public Webcam(PictureBox pb)
        {
            this.pb = pb;
        }

        // get the devices names connected to the pc
        private FilterInfoCollection getCamList()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            return videoDevices;
        }

        // start the camera
        public void Start()
        {
            // raise an exception incase no video device is found
            // or else initialise the videosource variable with the harware device
            // and other desired parameters.
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

        private Size getWidthHeight()
        {
            if (pb.Height / Height >= pb.Width / Width)
            {
                double ratio = (double)pb.Width / pb.Height;
                Size s = new Size();
                s.Width = pb.Width;
                s.Height = (int)(ratio * pb.Height * (Height / Width));
                return s;
            }
            else
            {
                double ratio = (double)pb.Height / pb.Width;
                Size s = new Size();
                s.Height = pb.Height;
                s.Width = (int)(ratio * pb.Width * (Width / Height));
                return s;
            }
        }

        private Bitmap ResizeCopy(Bitmap frame)
        {
            Size s = getWidthHeight();
            Bitmap newImage = new Bitmap(s.Width, s.Height);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(frame, new Rectangle(0, 0, s.Width, s.Height));
            }
            return newImage;
        }

        // eventhandler if new frame is ready
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            CurrentImage = ResizeCopy(eventArgs.Frame);
            CurrentImage.RotateFlip(RotateFlipType.Rotate180FlipY);
            try
            {
                pb.Invoke((MethodInvoker)delegate
                {
                    if (pb.Image != null)
                    {
                        pb.Image.Dispose();
                        ((Bitmap)pb.Tag).Dispose();
                    }
                    pb.Image = CurrentImage;
                    pb.Tag = CurrentImage;
                });
            }
            catch (System.ComponentModel.InvalidAsynchronousStateException)
            {
                // Form was closed before the invoke finished execution
            }
        }

        // close the device safely
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

    public struct Pixel
    {
        public Color Color;
        public Point Position;
    }

    public static class Resizer
    {
        public static void PictureboxResize(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            Bitmap bmp = pb.Tag as Bitmap;
            if (bmp == null) return;
            Size newsize = ResizeFrame(bmp.Size, pb.Size);
            pb.Image = new Bitmap(bmp, newsize);
        }

        public static Size ResizeFrame(Size originalFrame, Size newFrame)
        {
            if (newFrame.Height / (double)originalFrame.Height >= newFrame.Width / (double)originalFrame.Width)
            {
                double ratio = (double)newFrame.Width / newFrame.Height;
                Size s = new Size();
                s.Width = newFrame.Width;
                s.Height = (int)(ratio * newFrame.Height * ((double)originalFrame.Height / originalFrame.Width));
                return s;
            }
            else
            {
                double ratio = (double)newFrame.Height / newFrame.Width;
                Size s = new Size();
                s.Height = newFrame.Height;
                s.Width = (int)(ratio * newFrame.Width * ((double)originalFrame.Width / originalFrame.Height));
                return s;
            }
        }

        public static Size CompressedSize(Bitmap bmp, int newWidth = 200)
        {
            Size s = new Size();
            double ratio = (double)bmp.Size.Height / bmp.Size.Width;
            s.Width = newWidth;
            s.Height = (int)(newWidth * ratio);
            return s;
        }

        public static IEnumerable<Pixel> Compress(Bitmap bmp, int newWidth = 200)
        {
            Size s = CompressedSize(bmp, newWidth);
            double wskip = (double)bmp.Size.Width / s.Width;
            double hskip = (double)bmp.Size.Height / s.Height;

            int i = 0;
            for (double x = 0; x < bmp.Size.Width; x += wskip)
            {
                int j = 0;
                if (i >= s.Width) continue;
                for (double y = 0; y < bmp.Size.Height; y += hskip)
                {
                    if (j >= s.Height) continue;
                    yield return new Pixel
                    {
                        Color = bmp.GetPixel((int)Math.Round(x), (int)Math.Round(y)),
                        Position = new Point(i, j),
                    };
                    j++;
                }
                i++;
            }
        }
    }
}