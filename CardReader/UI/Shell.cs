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
using CommunityToolkit.WinUI.UI.Helpers;

namespace CardReader.UI
{
    public class Shell
    {
        public AppState AppState { get; }

        public Window Window { get; private set; }

        public MainPage MainPage { get; private set; }

        public Shell(AppState appState)
        {
            AppState = appState;
        }

        public void Init()
        {
            //TestDriverLicenseReader();

            var themeListener = new ThemeListener();
            this.AppState.CurrentTheme = themeListener.CurrentTheme;
            themeListener.ThemeChanged += ThemeListener_ThemeChanged;

            this.MainPage = new MainPage();

            this.Window = new Window();
            this.Window.Activated += Window_Activated;

            this.Window.Content = this.MainPage;
            this.Window.ExtendsContentIntoTitleBar = true;
            this.Window.SetTitleBar(this.MainPage.AppTitleBar);

            this.Window.Activate();
        }

        private void ThemeListener_ThemeChanged(ThemeListener sender)
        {
            this.AppState.CurrentTheme = sender.CurrentTheme;
        }

        private void Window_Activated(object sender, WindowActivatedEventArgs args)
        {
            this.AppState.IsMainWindowActive = args.WindowActivationState != WindowActivationState.Deactivated;
        }

        //private void UpdateAppTitleTextForeground()
        //{
        //    this.MainPage.AppTitleTextBlock.Foreground = (SolidColorBrush)(this.AppState.IsMainWindowActive
        //        ? App.Current.Resources["WindowCaptionForeground"]
        //        : App.Current.Resources["WindowCaptionForegroundDisabled"]);
        //}

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
