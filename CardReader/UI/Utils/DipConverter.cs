using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.UI.Utils
{
    public static class DipConverter
    {
        [DllImport("user32.dll")]
        private static extern int GetDpiForWindow(nint hWnd);

        public static int GetDpi(nint hWnd)
        {
            return GetDpiForWindow(hWnd);
        }

        public static int PixelValue(double dipValue, int dpi)
        {
            return (int) Math.Round((dipValue * dpi) / 96.0d);
        }

        public static double DipValue(int pixelValue, int dpi)
        {
            return dpi != 0 ? (pixelValue * 96.0d) / dpi : 0;
        }
    }
}
