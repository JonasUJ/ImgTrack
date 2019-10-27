using System.Drawing;

namespace ImgTrack
{
    public static class Settings
    {
        public static byte R = 180;
        public static byte G = 180;
        public static byte B = 180;
        public static int Accuracy = 50;
        public static double Compression = 0.25;

        public static string Export()
        {
            return $"{R},{G},{B},{Accuracy},{Compression}";
        }
    }
}
