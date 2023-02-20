using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Service
{
    public interface IAppSettingsService
    {
        public void SaveIdReaderCardReaderId(string value);
        public string GetIdReaderCardReaderId();
        public int GetIdReaderApiVersion();

        public void SaveDriverLicenseReaderCardReaderId(string value);
        public string GetDriverLicenseReaderCardReaderId();
    }
}
