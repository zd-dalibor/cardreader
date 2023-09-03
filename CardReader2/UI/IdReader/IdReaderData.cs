using Microsoft.UI.Xaml.Media.Imaging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace CardReader.UI.IdReader
{
    public class IdReaderData : ReactiveObject
    {
        [Reactive]
        public string CardType { get; set; }

        [Reactive]
        public string DocRegNo { get; set; }

        [Reactive]
        public string DocumentType { get; set; }

        [Reactive]
        public string IssuingDate { get; set; }

        [Reactive]
        public string ExpiryDate { get; set; }

        [Reactive]
        public string IssuingAuthority { get; set; }

        [Reactive]
        public string DocumentSerialNumber { get; set; }

        [Reactive]
        public string ChipSerialNumber { get; set; }

        [Reactive]
        public string PersonalNumber { get; set; }

        [Reactive]
        public string Surname { get; set; }

        [Reactive]
        public string GivenName { get; set; }

        [Reactive]
        public string ParentGivenName { get; set; }

        [Reactive]
        public string Sex { get; set; }

        [Reactive]
        public string PlaceOfBirth { get; set; }

        [Reactive]
        public string StateOfBirth { get; set; }

        [Reactive]
        public string DateOfBirth { get; set; }

        [Reactive]
        public string CommunityOfBirth { get; set; }

        [Reactive]
        public string StatusOfForeigner { get; set; }

        [Reactive]
        public string NationalityFull { get; set; }

        [Reactive]
        public string State { get; set; }

        [Reactive]
        public string Community { get; set; }

        [Reactive]
        public string Place { get; set; }

        [Reactive]
        public string Street { get; set; }

        [Reactive]
        public string HouseNumber { get; set; }

        [Reactive]
        public string HouseLetter { get; set; }

        [Reactive]
        public string Entrance { get; set; }

        [Reactive]
        public string Floor { get; set; }

        [Reactive]
        public string ApartmentNumber { get; set; }

        [Reactive]
        public string AddressDate { get; set; }

        [Reactive]
        public string AddressLabel { get; set; }

        [Reactive]
        public BitmapImage Portrait { get; set; }

        [Reactive]
        public bool? SigCardVerified { get; set; }

        [Reactive]
        public bool? SigFixedVerified { get; set; }

        [Reactive]
        public bool? SigVariableVerified { get; set; }

        [Reactive]
        public bool? SigPortraitVerified { get; set; }
    }
}
