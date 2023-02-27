using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Model
{
    public class DriverLicenseRegistrationData
    {
        public byte[] RegistrationData { get; set; }
        public byte[] SignatureData { get; set; }
        public byte[] IssuingAuthority { get; set; }
    }
}
