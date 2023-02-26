using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace CardReader.Service
{
    public class AppSettingsService : IAppSettingsService
    {
        // private readonly ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public void SaveIdReaderCardReaderId(string value)
        {
            Properties.Settings.Default.IdReaderCardReaderId = value;
            Properties.Settings.Default.Save();
        }

        public string GetIdReaderCardReaderId()
        {
            return Properties.Settings.Default.IdReaderCardReaderId;
        }

        public int GetIdReaderApiVersion()
        {
            return Properties.Settings.Default.IdReaderApiVersion;
        }

        public void SaveDriverLicenseReaderCardReaderId(string value)
        {
            Properties.Settings.Default.DriverLicenseReaderCardReaderId = value;
            Properties.Settings.Default.Save();
        }

        public string GetDriverLicenseReaderCardReaderId()
        {
            return Properties.Settings.Default.DriverLicenseReaderCardReaderId;
        }

        public void SaveWindowWidthDip(double windowWidthDip)
        {
            Properties.Settings.Default.WindowWidithDip = windowWidthDip;
            Properties.Settings.Default.Save();
        }

        public double GetWindowWidthDip(double defaultValue = default)
        {
            return Properties.Settings.Default.WindowWidithDip != 0 ? Properties.Settings.Default.WindowWidithDip : defaultValue;
        }

        public void SaveWindowHeightDip(double windowHeightDip)
        {
            Properties.Settings.Default.WindowHeightDip = windowHeightDip;
            Properties.Settings.Default.Save();
        }

        public double GetWindowHeightDip(double defaultValue = default)
        {
            return Properties.Settings.Default.WindowHeightDip != 0 ? Properties.Settings.Default.WindowHeightDip : defaultValue;
        }

        public void SaveWindowWidthInPixels(int windowWidthInPixels)
        {
            Properties.Settings.Default.WindowWidthInPixels = windowWidthInPixels;
            Properties.Settings.Default.Save();
        }

        public int GetWindowWidthInPixels(int defaultValue = default)
        {
            return Properties.Settings.Default.WindowWidthInPixels  != 0 ? Properties.Settings.Default.WindowWidthInPixels : defaultValue;
        }

        public void SaveWindowHeightInPixels(int windowHeightInPixels)
        {
            Properties.Settings.Default.WindowHeightInPixels = windowHeightInPixels;
            Properties.Settings.Default.Save();
        }

        public int GetWindowHeightInPixels(int defaultValue = default)
        {
            return Properties.Settings.Default.WindowHeightInPixels  != 0 ? Properties.Settings.Default.WindowHeightInPixels : defaultValue;
        }
    }
}
