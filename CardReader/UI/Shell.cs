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
            //TestDriverLicenseReader();

            hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
            var windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
            var appWindow = AppWindow.GetFromWindowId(windowId);

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
            appSettingsService.SaveWindowWidthDip(args.Size.Width);
            appSettingsService.SaveWindowHeightDip(args.Size.Height);

            if (hWnd != nint.Zero)
            {
                DPI = DipConverter.GetDpi(hWnd);
            }
        }

        private static void TestDriverLicenseReader()
        {
            var test = new DriverLicenseReaderLib.MainReader();
            var result = test.sdStartup(0);
            Debug.WriteLine($"Ovo je results: 0x{result:X}!!!");

            var nameSize = 100;
            Array readerName = new sbyte[nameSize];
            result = test.GetReaderName(0, ref readerName, ref nameSize);
            string readerNameStr = null;
            Debug.WriteLine($"Ovo je results: 0x{result:X}!!!");
            if (result == 0)
            {
                var bytes = new ArrayList(readerName).ToArray().Take(nameSize - 1).Select(x => Convert.ToByte((sbyte)x)).ToArray();
                readerNameStr = Encoding.UTF8.GetString(bytes);
                Debug.WriteLine($"Ovo je results: {readerNameStr}!!!");
            }

            if (readerNameStr != null)
            {
                var bytes = Encoding.UTF8.GetBytes(readerNameStr + "\0").Select(Convert.ToSByte).ToArray();
                result = test.SelectReader(bytes);
                Debug.WriteLine($"Ovo je results: 0x{result:X}!!!");

                result = test.sdProcessNewCard();
                Debug.WriteLine($"Ovo je results: 0x{result:X}!!!");

                var registrationData = new DriverLicenseReaderLib.SD_REGISTRATION_DATAx();
                result = test.sdReadRegistration(ref registrationData, 1);
                Debug.WriteLine($"Ovo je results: 0x{result:X}!!!");

                registrationData = new DriverLicenseReaderLib.SD_REGISTRATION_DATAx();
                result = test.sdReadRegistration(ref registrationData, 2);
                Debug.WriteLine($"Ovo je results: 0x{result:X}!!!");

                registrationData = new DriverLicenseReaderLib.SD_REGISTRATION_DATAx();
                result = test.sdReadRegistration(ref registrationData, 3);
                Debug.WriteLine($"Ovo je results: 0x{result:X}!!!");

                var documentData = new DriverLicenseReaderLib.SD_DOCUMENT_DATAx();
                result = test.sdReadDocumentData(ref documentData);
                Debug.WriteLine($"Ovo je results: 0x{result:X}!!!");

                var vehicleData = new DriverLicenseReaderLib.SD_VEHICLE_DATAx();
                result = test.sdReadVehicleData(ref vehicleData);
                Debug.WriteLine($"Ovo je results: 0x{result:X}!!!");

                var personalData = new DriverLicenseReaderLib.SD_PERSONAL_DATAx();
                result = test.sdReadPersonalData(ref personalData);
                Debug.WriteLine($"Ovo je results: 0x{result:X}!!!");
            }

            result = test.sdCleanup();
            Debug.WriteLine($"Ovo je results: 0x{result:X}!!!");
        }
    }
}
