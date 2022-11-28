using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Model.Data
{
    public class DocumentData
    {
        public string DocRegNo { get; set; }
        public string DocumentType { get; set; }
        public string IssuingDate { get; set; }
        public string ExpiryDate { get; set; }
        public string IssuingAuthority { get; set; }
        public string DocumentSerialNumber { get; set; }
        public string ChipSerialNumber { get; set; }
    }
}
