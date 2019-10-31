using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ImgTrack
{
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
}
