using System.Runtime.Versioning;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace CardReader.Win32
{
    public static class HwndExtensions
    {
        [SupportedOSPlatform("windows10.0.14393")]
        public static uint GetDpiForWindow(IntPtr hwnd) => PInvoke.GetDpiForWindow(new HWND(hwnd));

        [SupportedOSPlatform("windows5.0")]
        public static bool IsWindowMaximized(IntPtr hwnd)
        {
            var lpwndpl = new WINDOWPLACEMENT();
            if (PInvoke.GetWindowPlacement(new HWND(hwnd), ref lpwndpl))
            {
                return lpwndpl.showCmd == SHOW_WINDOW_CMD.SW_MAXIMIZE;
            }

            throw new InvalidOperationException("GetWindowPlacement method failed.");
        }

        [SupportedOSPlatform("windows5.0")]
        public static nint MaximizeWindow(IntPtr hwnd)
        {
            return PInvoke.SendMessage(new HWND(hwnd), PInvoke.WM_SYSCOMMAND, PInvoke.SC_MAXIMIZE, 0);
        }
    }
}
