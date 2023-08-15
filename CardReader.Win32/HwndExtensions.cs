using System.Runtime.Versioning;
using Windows.Win32;
using Windows.Win32.Foundation;

namespace CardReader.Win32
{
    public static class HwndExtensions
    {
        [SupportedOSPlatform("windows10.0.14393")]
        public static uint GetDpiForWindow(IntPtr hwnd) => PInvoke.GetDpiForWindow(new HWND(hwnd));
    }
}
