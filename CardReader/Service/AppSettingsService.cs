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
    }
}
