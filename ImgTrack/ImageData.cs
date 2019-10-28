using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImgTrack
{
    public struct Pixel
    {
        public Color Color;
        public Point Position;
    }

    public class ImageData
    {
        public readonly int[] GreyscaleValues;
        public readonly int TotalPixels;
        public readonly Bitmap Bmp;
        public readonly int[] Columns;
        public readonly int[] Rows;
        public readonly int Column;
        public readonly int Row;

        public ImageData(IEnumerable<Pixel> pixels, int width, int height, int nonColorSum = 0)
        {
            GreyscaleValues = new int[256];
            TotalPixels = width * height;
            Columns = new int[width];
            Rows = new int[height];
            Bmp = new Bitmap(width, height);

            foreach (Pixel px in pixels)
            {
                int avg = ChartUtil.Average(px.Color);
                GreyscaleValues[avg]++;
                Bmp.SetPixel(px.Position.X, px.Position.Y, px.Color);
                if ((px.Color.R + px.Color.G + px.Color.B) != nonColorSum)
                {
                    Columns[px.Position.X]++;
                    Rows[px.Position.Y]++;
                }
            }

            Column = getMiddle(Columns);
            Row = getMiddle(Rows);
        }

        public ImageData(Image img, int nonColorSum = 0)
        {
            Bmp = new Bitmap(img.Clone() as Image);
            TotalPixels = Bmp.Width * Bmp.Height;
            GreyscaleValues = new int[256];
            Columns = new int[Bmp.Width];
            Rows = new int[Bmp.Height];

            for (int x = 0; x < Bmp.Width; x++)
            {
                for (int y = 0; y < Bmp.Height; y++)
                {
                    Color color = Bmp.GetPixel(x, y);
                    int avg = ChartUtil.Average(color);
                    GreyscaleValues[avg]++;
                    if ((color.R + color.G + color.B) != 0)
                    {
                        Columns[x]++;
                        Rows[y]++;
                    }
                }
            }

            Column = getMiddle(Columns);
            Row = getMiddle(Rows);
        }

        private int getMiddle(int[] data)
        {
            int middle = data.Sum() / 2;
            int res = 0;
            int i = 0;
            while (res < middle)
            {
                res += data[i++];
            }
            return i;
        }

        public Bitmap DrawCross()
        {
            Bitmap b = Bmp.Clone() as Bitmap;
            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawLine(Pens.Red, Column, 0, Column, b.Height);
                g.DrawLine(Pens.Red, 0, Row, b.Width, Row);
            }
            return b;
        }
    }
}
