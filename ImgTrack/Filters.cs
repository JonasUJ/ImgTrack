using System.Collections.Generic;
using System.Drawing;

namespace ImgTrack
{
    public static class Filters
    {
        public delegate Bitmap Filter(Bitmap bmp);

        public static Bitmap NoFilter(Bitmap bmp)
        {
            return bmp;
        }

        private static IEnumerable<Pixel> TrackFilterIterator(Bitmap bmp, int width, Color nonColor)
        {
            foreach (Pixel px in Resizer.Compress(bmp, width))
            {
                Pixel npx = px;
                npx.Color = (
                    px.Color.R > Settings.R - Settings.Accuracy && px.Color.R < Settings.R + Settings.Accuracy &&
                    px.Color.G > Settings.G - Settings.Accuracy && px.Color.G < Settings.G + Settings.Accuracy &&
                    px.Color.B > Settings.B - Settings.Accuracy && px.Color.B < Settings.B + Settings.Accuracy
                ) ? px.Color : nonColor;
                yield return npx;
            }
        }

        public static Bitmap TrackFilter(Bitmap bmp)
        {
            int width = (int)(bmp.Width * Settings.Compression);
            Size csize = Resizer.CompressedSize(bmp, width);
            Color nonColor = Settings.Color.GetBrightness() < 0.5 ? Color.White : Color.Black;
            ImageData imgd = new ImageData(TrackFilterIterator(bmp, width, nonColor), csize.Width, csize.Height, nonColor.R + nonColor.G + nonColor.B);
            Bitmap withCross = Settings.IsolateColor && !Settings.InSettings ? imgd.DrawCross(bmp) : imgd.DrawCross();
            return withCross;
        }
    }
}
