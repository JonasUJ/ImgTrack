using System.Collections.Generic;
using System.Drawing;

namespace ImgTrack
{
    /// <summary>
    /// Filters for the camera
    /// </summary>
    public static class Filters
    {
        /// <summary>
        /// Filter delegate that all Filters follow
        /// </summary>
        /// <param name="bmp">The Bitmap to apply the filter to</param>
        /// <returns>A Bitmap with the filter applied</returns>
        public delegate Bitmap Filter(Bitmap bmp);

        /// <summary>
        /// A filter with no effect
        /// </summary>
        /// <param name="bmp">The Bitmap to apply the filter to</param>
        /// <returns>The same Bitmap that was passed</returns>
        public static Bitmap NoFilter(Bitmap bmp)
        {
            return bmp;
        }

        // Helper method for TrackFilter
        private static IEnumerable<Pixel> TrackFilterIterator(Bitmap bmp, int width, Color nonColor)
        {
            // Foreach Pixel in the compressed image
            foreach (Pixel px in Resizer.Compress(bmp, width))
            {
                Pixel npx = px;

                // Set the Color to to either the same Color or nonColor, depending on the selected setings
                npx.Color = (
                    px.Color.R > Settings.R - Settings.Accuracy && px.Color.R < Settings.R + Settings.Accuracy &&
                    px.Color.G > Settings.G - Settings.Accuracy && px.Color.G < Settings.G + Settings.Accuracy &&
                    px.Color.B > Settings.B - Settings.Accuracy && px.Color.B < Settings.B + Settings.Accuracy
                ) ? px.Color : nonColor;

                yield return npx;
            }
        }

        /// <summary>
        /// A filter that tracks the selected Color on the image by drawing a cross on it
        /// </summary>
        /// <param name="bmp">The Bitmap to apply the filter to</param>
        /// <returns>The image with a cross on the tracked Color</returns>
        public static Bitmap TrackFilter(Bitmap bmp)
        {
            int width = (int)(bmp.Width * Settings.Compression); // Width after compression
            Size csize = Resizer.CompressedSize(bmp, width); // Size after compression
            Color nonColor = Settings.Color.GetBrightness() < 0.5 ? Color.White : Color.Black; // Color to use as nonColor is decided depending on Color brightness
            ImageData imgd = new ImageData(TrackFilterIterator(bmp, width, nonColor), csize.Width, csize.Height, nonColor); // Get ImageData from the image when the TrackFilter is applied
            Bitmap withCross = Settings.IsolateColor && !Settings.InSettings ? imgd.DrawCross(bmp) : imgd.DrawCross(); // Draw a cross on the image
            return withCross;
        }
    }
}
