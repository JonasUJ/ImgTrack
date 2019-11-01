using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImgTrack
{
    /// <summary>
    /// Utilities for drawing creating a Chart
    /// </summary>
    public static class ChartUtil
    {
        /// <summary>
        /// Get the average of the R, G and B components of a Color
        /// </summary>
        /// <param name="color">The color to get the averaage of</param>
        /// <returns>An average value of the R, G and B components of the Color</returns>
        public static int Average(Color color)
        {
            return (color.R + color.G + color.B) / 3;
        }

        /// <summary>
        /// Makes a chart into a histogram using the data in an Image
        /// </summary>
        /// <param name="chart">Chart to make into histogram</param>
        /// <param name="img">Image whose data to use</param>
        public static void MakeIntoHistogram(Chart chart, Image img)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();

            ChartArea ca = new ChartArea
            {
                Name = "DrawingArea",
            };

            // Hate this, why not just use bools
            ca.AxisX.Enabled = AxisEnabled.False;
            ca.AxisY.Enabled = AxisEnabled.False;

            Series series = new Series
            {
                Name = "Pixel data",
                ChartArea = "DrawingArea",
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Column,
                Color = Color.Gray,
            };

            // Use the data from the image to draw the histogram
            ImageData imgd = new ImageData(img, Color.Black);
            for (int i = 0; i < imgd.GreyscaleValues.Length; i++)
            {
                series.Points.AddXY(i, imgd.GreyscaleValues[i]);
            }

            chart.ChartAreas.Add(ca);
            chart.Series.Add(series);
        }
    }
}
