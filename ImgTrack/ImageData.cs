using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImgTrack
{
    public class ImageData
    {
        public readonly int[] GreyscaleValues;
        public readonly int TotalPixels;
        public readonly Bitmap Bmp;

        public ImageData(Image img)
        {
            Bmp = new Bitmap(img);
            TotalPixels = img.Width * img.Height;
            GreyscaleValues = new int[256];
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    Color color = Bmp.GetPixel(x, y);
                    int avg = ChartUtil.Average(color);
                    GreyscaleValues[avg]++;
                }
            }
        }
    }
}
