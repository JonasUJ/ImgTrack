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
    // Custom exception snippet
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

        /// <summary>
        /// The current image from the videofeed
        /// </summary>
        public Bitmap CurrentImage {
            get
            {
                ImageMutex.WaitOne(); // They have to release it when they have finished using CurrentImage
                return currentImage;
            }
            private set { currentImage = value; }
        }

        /// <summary>
        /// Dimensions of the videofeed
        /// </summary>
        public Size FrameSize { get => videoSource.VideoResolution.FrameSize; }

        // Cam struct represents a PictureBox with a Filter
        public struct Cam
        {
            public PictureBox Box;
            public Filters.Filter Filter;
        }
        private List<Cam> Cams;

        /// <summary>
        /// Register a webcam with a list of Cams
        /// </summary>
        /// <param name="cams">A list of all Cams to be updated with each frame</param>
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

        /// <summary>
        /// Start the camera
        /// </summary>
        public void Start()
        {
            // Raise an exception in case no video device is found
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

        /// <summary>
        /// Set the reslution to that of the passed VideoCapabilities
        /// </summary>
        /// <param name="vcap">The new resolution</param>
        public void SetResolution(VideoCapabilities vcap)
        {
            videoSource.NewFrame -= new NewFrameEventHandler(video_NewFrame);
            Thread stopper = new Thread(delegate() // Have to do this in a seperate thread because it causes a deadlock with the UI thread
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

        // Copy the Image from AForge to a new Bitmap, because AForge disposes of it after the NewFrame event has run.
        private Bitmap Copy(Bitmap frame)
        {
            Bitmap newImage = new Bitmap(frame.Width, frame.Height);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(frame, 0, 0, frame.Width, frame.Height);
            }
            return newImage;
        }

        /// <summary>
        /// Toggle a Cam on/off
        /// </summary>
        /// <param name="cam">The Cam to toggle on/off</param>
        public void ToggleCam(Cam cam)
        {
            Thread Worker = new Thread((ThreadStart)delegate // Thread to avoid deadlock
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
            if (Busy) return; // Drop frame if we are still processing any of the previous
            Busy = true; // We are processing a frame
            CurrentImage = Copy(eventArgs.Frame); // We have to copy the image to use it outside the event
            CurrentImage.RotateFlip(RotateFlipType.Rotate180FlipY); // Mirror
            ThreadPool.QueueUserWorkItem(delegate // Thread keeps running after the event
            {
                ToggleMutex.WaitOne();
                try
                {
                    foreach (var cam in Cams) // Update all Cam PictureBoxes
                    {
                        cam.Box.Invoke((MethodInvoker)delegate // Run on UI thread
                        {
                            if (cam.Box.Image != null)
                            {
                                cam.Box.Image.Dispose(); // Dispose or we leak memory
                                ((Bitmap)cam.Box.Tag).Dispose();
                            }
                            Bitmap tmp = cam.Filter(CurrentImage);
                            cam.Box.Image = Resizer.ResizeBitmap(tmp, Resizer.ResizeFrame(tmp.Size, cam.Box.Size));
                            cam.Box.Tag = tmp;
                            ImageMutex.ReleaseMutex(); // Release because we called CurrentImage
                        });
                    }
                }
                catch (Exception ex) when (ex is InvalidOperationException ||
                                           ex is System.ComponentModel.InvalidAsynchronousStateException)
                {
                    // Form was closed before the invoke finished execution
                }
                ToggleMutex.ReleaseMutex();
                Busy = false; // Thread execution finished and we are ready to process a new frame
            });
            ImageMutex.ReleaseMutex(); // We used CurrentImage and have to release the mutex
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