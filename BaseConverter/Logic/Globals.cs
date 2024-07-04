using System.Drawing;
using System.Drawing.Text;

namespace BaseConverter.Logic
{
    internal static class Globals
    {
        public static bool PreloadComplete { get; set; }
        public const int FONTSIZE = 7;
        public static readonly Color BACKCOLOR = Color.FromArgb(255, 170, 170, 170);
        public static PrivateFontCollection Fonts { get; } = new();
    }
}
