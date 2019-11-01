using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace ImgTrack
{
    /// <summary>
    /// Represents a Pixel in a Bitmap with a Color and a Position
    /// </summary>
    public struct Pixel
    {
        public Color Color;
        public Point Position;
    }

    /// <summary>
    /// Exctract and calculates information from an image
    /// </summary>
    public class ImageData
    {
        public readonly int[] GreyscaleValues; // Used for generating a histogram
        public readonly int TotalPixels;
        public readonly Bitmap Bmp;

        // Shows the distribution of nonColor Pixels in the image
        public readonly int[] Columns;
        public readonly int[] Rows;

        // The middle of the corrosponding array
        public readonly int Column;
        public readonly int Row;

        /// <summary>
        /// Exctract and calculates information from an IEnumerable of Pixels that represents an image
        /// </summary>
        /// <param name="pixels">An iterator with each Pixel in the image</param>
        /// <param name="width">The width of the image</param>
        /// <param name="height">The height of the image</param>
        /// <param name="nonColor">The color that is present in place of Pixels that shouldn't be tracked</param>
        public ImageData(IEnumerable<Pixel> pixels, int width, int height, Color nonColor)
        {
            GreyscaleValues = new int[256];
            TotalPixels = width * height;
            Columns = new int[width];
            Rows = new int[height];
            Bmp = new Bitmap(width, height);

            foreach (Pixel px in pixels)
            {
                // The index at the average of R, G and B components in the Color is increased
                int avg = ChartUtil.Average(px.Color);
                GreyscaleValues[avg]++;

                // Add the Pixel to the Bitmap
                Bmp.SetPixel(px.Position.X, px.Position.Y, px.Color);

                // If the Pixel is tracked, add it in Columns and Rows
                if (px.Color.R != nonColor.R && px.Color.G != nonColor.G && px.Color.B != nonColor.B)
                {
                    Columns[px.Position.X]++;
                    Rows[px.Position.Y]++;
                }
            }

            // Get the middle of the arrays
            Column = getMiddle(Columns);
            Row = getMiddle(Rows);
        }

        /// <summary>
        /// Exctract and calculates information from an Image
        /// </summary>
        /// <param name="img">The image to use</param>
        /// <param name="nonColor">The color that is present in place of Pixels that shouldn't be tracked</param>
        public ImageData(Image img, Color nonColor)
        {
            Bmp = new Bitmap(img.Clone() as Image);
            TotalPixels = Bmp.Width * Bmp.Height;
            GreyscaleValues = new int[256];
            Columns = new int[Bmp.Width];
            Rows = new int[Bmp.Height];

            // Look at every pixel in the Image
            for (int x = 0; x < Bmp.Width; x++)
            {
                for (int y = 0; y < Bmp.Height; y++)
                {
                    Color color = Bmp.GetPixel(x, y);

                    // The index at the average of R, G and B components in the Color is increased
                    int avg = ChartUtil.Average(color);
                    GreyscaleValues[avg]++;

                    // If the Pixel is tracked, add it in Columns and Rows
                    if (color.R != nonColor.R && color.G != nonColor.G && color.B != nonColor.B)
                    {
                        Columns[x]++;
                        Rows[y]++;
                    }
                }
            }

            // Get the middle of the arrays
            Column = getMiddle(Columns);
            Row = getMiddle(Rows);
        }

        /// <summary>
        /// Get the index in an int[] at which the sum of numbers in indices below is equal to the sum of those above
        /// </summary>
        /// <param name="data">An array of integers to find the middle of</param>
        /// <returns>The index that is the middle of the array</returns>
        private int getMiddle(int[] data)
        {
            int middle = data.Sum() / 2; // Sum when the middle is reached
            int res = 0; // The sum so far
            int i = 0; // Iteration variable
            while (res < middle)
            {
                res += data[i++];
            }
            return i; // Return the index
        }

        /// <summary>
        /// Draw a cross at x=Column y=Row on this objects Bmp
        /// </summary>
        /// <returns>A Bitmap with a cross</returns>
        public Bitmap DrawCross()
        {
            return DrawCross(Bmp);
        }

        /// <summary>
        /// Draw a cross at x=Column y=Row on the passed Bitmap
        /// </summary>
        /// <param name="bmp">A Bitmap to draw a cross on</param>
        /// <returns>A Bitmap with a cross</returns>
        public Bitmap DrawCross(Bitmap bmp)
        {
            // Scale Column and Row to that of the passed Bitmap
            int column = bmp.Height / Bmp.Height * Column;
            int row = bmp.Width / Bmp.Width * Row;

            Bitmap b = bmp.Clone() as Bitmap;
            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawLine(Pens.Red, column, 0, column, b.Height);
                g.DrawLine(Pens.Red, 0, row, b.Width, row);
            }
            return b;
        }
    }
}
