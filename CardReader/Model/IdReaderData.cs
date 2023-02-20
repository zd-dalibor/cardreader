using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Model
{
    public class IdReaderData
    {
        // documentData
        public int CardType { get; set; }
        public string DocRegNo { get; set; }
        public string DocumentType { get; set; }
        public string IssuingDate { get; set; }
        public string ExpiryDate { get; set; }
        public string IssuingAuthority { get; set; }
        public string DocumentSerialNumber { get; set; }
        public string ChipSerialNumber { get; set; }
        // fixedPersonalData
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
        // variablePersonalData
        public string State { get; set; }
        public string Community { get; set; }
        public string Place { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string HouseLetter { get; set; }
        public string Entrance { get; set; }
        public string Floor { get; set; }
        public string ApartmentNumber { get; set; }
        public string AddressDate { get; set; }
        public string AddressLabel { get; set; }
        // portraitData
        public byte[] Portrait { get; set; }
        // certData
        public byte[] CertIntermediateCa { get; set; }
        public byte[] CertUser1 { get; set; }
        public byte[] CertUser2 { get; set; }
    }
}
