using CardReader.Win32;
using System;

namespace CardReader.Infrastructure.Extensions
{
    internal static class WindowExtensions
    {
        public static uint GetDpiForWindow(this Microsoft.UI.Xaml.Window window) => HwndExtensions.GetDpiForWindow(window.GetWindowHandle());

        public static bool IsWindowMaximized(this Microsoft.UI.Xaml.Window window) => HwndExtensions.IsWindowMaximized(window.GetWindowHandle());

        public static nint MaximizeWindow(this Microsoft.UI.Xaml.Window window) => HwndExtensions.MaximizeWindow(window.GetWindowHandle());

        private static nint GetWindowHandle(this Microsoft.UI.Xaml.Window window)
            => window is null ? throw new ArgumentNullException(nameof(window)) : WinRT.Interop.WindowNative.GetWindowHandle(window);
    }
}
