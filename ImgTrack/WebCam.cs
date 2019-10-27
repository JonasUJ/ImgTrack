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
        public Bitmap CurrentImage { get; private set; }
        private bool Busy = false;
        private Mutex ToggleMutex = new Mutex();

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
            Thread Worker = new Thread((ThreadStart)delegate
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
                        });
                    }
                }
                catch (System.ComponentModel.InvalidAsynchronousStateException)
                {
                    // Form was closed before the invoke finished execution
                }
                ToggleMutex.ReleaseMutex();
                Busy = false;
            });
            Busy = true;
            Worker.Start();
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

    public static class Resizer
    {
        public static void PictureboxResize(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            Bitmap bmp = pb.Tag as Bitmap;
            if (bmp == null) return;
            Size newsize = ResizeFrame(bmp.Size, pb.Size);
            pb.Image = ResizeBitmap(bmp, newsize);
        }

        public static Bitmap ResizeBitmap(Bitmap original, Size newSize)
        {
            Bitmap newbmp = new Bitmap(newSize.Width, newSize.Height);
            using (Graphics g = Graphics.FromImage(newbmp))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.Half;
                g.DrawImage(original, 0, 0, newSize.Width, newSize.Height);
            }
            return newbmp;
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

        public static Size CompressedSize(Bitmap bmp, int newWidth)
        {
            Size s = new Size();
            double ratio = (double)bmp.Size.Height / bmp.Size.Width;
            s.Width = newWidth;
            s.Height = (int)(newWidth * ratio);
            return s;
        }

        public static IEnumerable<Pixel> Compress(Bitmap bmp, int newWidth)
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

    public static class Filters
    {
        public delegate Bitmap Filter(Bitmap bmp);
        
        public static Bitmap NoFilter(Bitmap bmp)
        {
            return bmp;
        }

        private static IEnumerable<Pixel> TrackFilterIterator(Bitmap bmp, int width)
        {
            foreach (Pixel px in Resizer.Compress(bmp, width))
            {
                Pixel npx = px;
                npx.Color = (
                    px.Color.R > Settings.R - Settings.Accuracy && px.Color.R < Settings.R + Settings.Accuracy &&
                    px.Color.G > Settings.G - Settings.Accuracy && px.Color.G < Settings.G + Settings.Accuracy &&
                    px.Color.B > Settings.B - Settings.Accuracy && px.Color.B < Settings.B + Settings.Accuracy
                ) ? Color.White : Color.Black;
                yield return npx;
            }
        }

        public static Bitmap TrackFilter(Bitmap bmp)
        {
            int width = (int)(bmp.Width * Settings.Compression);
            Size csize = Resizer.CompressedSize(bmp, width);
            ImageData imgd = new ImageData(TrackFilterIterator(bmp, width), csize.Width, csize.Height);
            Bitmap withCross = imgd.DrawCross();
            return withCross;
        }
    }
}