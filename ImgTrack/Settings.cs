using System.Drawing;

namespace ImgTrack
{
    /// <summary>
    /// Global Settings object with information needed all over the application.
    /// This is basically a bunch of global variables, except it's not at bad a practice
    /// </summary>
    public static class Settings
    {
        public static Color Color { get => Color.FromArgb(R, G, B); }
        public static byte R = 180;
        public static byte G = 180;
        public static byte B = 180;
        public static int Accuracy = 50;
        public static double Compression = 0.25;
        public static bool InSettings = false;
        public static bool IsolateColor = false;

        /// <summary>
        /// Generates a string that can be written to a file. It contains all selected settings.
        /// </summary>
        /// <returns>A string with settings</returns>
        public static string Export()
        {
            return $"{R},{G},{B},{Accuracy},{Compression}";
        }
    }
}
