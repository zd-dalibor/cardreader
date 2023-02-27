using CardReader.UI.Pages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardReader.Service;
using CardReader.UI.Utils;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml.Controls;

namespace CardReader.UI
{
    public class Shell
    {
        private const double WINDOW_WIDTH_DPI = 1200D;
        private const double WINDOW_HEIGHT_DPI = 800D;

        private static int DPI;

        private readonly AppState appState;

        private readonly Window window;

        private readonly MainPage mainPage;

        private readonly IAppSettingsService appSettingsService;

        private nint hWnd;

        public Shell(AppState appState, IAppSettingsService appSettingsService)
        {
            this.appState = appState;
            this.appSettingsService = appSettingsService;

            mainPage = new MainPage();
            window = new Window
            {
                ExtendsContentIntoTitleBar = true,
                Content = mainPage
            };
            window.SetTitleBar(mainPage.AppTitleBar);

            window.Activated += Window_Activated;
            window.SizeChanged += Window_SizeChanged;
        }

        public void Init()
        {
            hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
            var appWindow = GetAppWindow(hWnd);

            DPI = DipConverter.GetDpi(hWnd);
            var windowWidthDip = appSettingsService.GetWindowWidthDip(WINDOW_WIDTH_DPI);
            var windowHeightDip = appSettingsService.GetWindowHeightDip(WINDOW_HEIGHT_DPI);
            var size = new Windows.Graphics.SizeInt32
            {
                Width = DipConverter.PixelValue(windowWidthDip, DPI),
                Height = DipConverter.PixelValue(windowHeightDip, DPI)
            };

            appWindow.Resize(size);

            window.Activate();
        }

        private void Window_Activated(object sender, WindowActivatedEventArgs args)
        {
            appState.IsMainWindowActive = args.WindowActivationState != WindowActivationState.Deactivated;
        }

        private void Window_SizeChanged(object sender, WindowSizeChangedEventArgs args)
        {
            if (hWnd == nint.Zero) return;

            DPI = DipConverter.GetDpi(hWnd);

            var appWindow = GetAppWindow(hWnd);
            var windowWidthDip = DipConverter.DipValue(appWindow.Size.Width, DPI);
            var windowHeightDip = DipConverter.DipValue(appWindow.Size.Height, DPI);
            
            appSettingsService.SaveWindowWidthDip(windowWidthDip);
            appSettingsService.SaveWindowHeightDip(windowHeightDip);
        }

        private static AppWindow GetAppWindow(nint hWnd)
        {
            var windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
            return AppWindow.GetFromWindowId(windowId);
        }
    }
}
