using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Model
{
    public class IdReaderData
    {
        public int CardType { get; set; }
        public string DocRegNo { get; set; }
        public string DocumentType { get; set; }
        public string IssuingDate { get; set; }
        public string ExpiryDate { get; set; }
        public string IssuingAuthority { get; set; }
        public string DocumentSerialNumber { get; set; }
        public string ChipSerialNumber { get; set; }
        public string PersonalNumber { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public string ParentGivenName { get; set; }
        public string Sex { get; set; }
        public string PlaceOfBirth { get; set; }
        public string StateOfBirth { get; set; }
        public string DateOfBirth { get; set; }
        public string CommunityOfBirth { get; set; }
        public string StatusOfForeigner { get; set; }
        public string NationalityFull { get; set; }
    }
}
