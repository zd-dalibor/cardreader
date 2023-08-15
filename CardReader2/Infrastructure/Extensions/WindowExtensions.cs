using CardReader.Win32;
using System;

namespace CardReader.Infrastructure.Extensions
{
    internal static class WindowExtensions
    {
        public static uint GetDpiForWindow(this Microsoft.UI.Xaml.Window window) => HwndExtensions.GetDpiForWindow(window.GetWindowHandle());

        private static nint GetWindowHandle(this Microsoft.UI.Xaml.Window window)
            => window is null ? throw new ArgumentNullException(nameof(window)) : WinRT.Interop.WindowNative.GetWindowHandle(window);
    }
}
