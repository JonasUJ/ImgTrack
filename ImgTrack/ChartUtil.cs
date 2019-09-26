using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImgTrack
{
    public static class ChartUtil
    {
        public static int Average(Color color)
        {
            return (color.R + color.G + color.B) / 3;
        }

        public static void MakeIntoHistogram(Chart chart, Image img)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();

            ChartArea ca = new ChartArea
            {
                Name = "DrawingArea",
            };
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

            ImageData imgd = new ImageData(img);
            for (int i = 0; i < imgd.GreyscaleValues.Length; i++)
            {
                series.Points.AddXY(i, imgd.GreyscaleValues[i]);
            }
            chart.ChartAreas.Add(ca);
            chart.Series.Add(series);
        }
    }
}
