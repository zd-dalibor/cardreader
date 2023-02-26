using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Media.Imaging;

namespace CardReader.UI.ViewModel.IdReaderPage
{
    public partial class IdReaderDataViewModel : ObservableObject
    {
        [ObservableProperty]
        private string cardType;

        [ObservableProperty]
        private string docRegNo;

        [ObservableProperty]
        private string documentType;

        [ObservableProperty]
        private string issuingDate;

        [ObservableProperty]
        private string expiryDate;

        [ObservableProperty]
        private string issuingAuthority;

        [ObservableProperty]
        private string documentSerialNumber;

        [ObservableProperty]
        private string chipSerialNumber;

        [ObservableProperty]
        private string personalNumber;

        [ObservableProperty]
        private string surname;

        [ObservableProperty]
        private string givenName;

        [ObservableProperty]
        private string parentGivenName;

        [ObservableProperty]
        private string sex;

        [ObservableProperty]
        private string placeOfBirth;

        [ObservableProperty]
        private string stateOfBirth;

        [ObservableProperty]
        private string dateOfBirth;

        [ObservableProperty]
        private string communityOfBirth;

        [ObservableProperty]
        private string statusOfForeigner;

        [ObservableProperty]
        private string nationalityFull;

        [ObservableProperty]
        private string state;

        [ObservableProperty]
        private string community;

        [ObservableProperty]
        private string place;

        [ObservableProperty]
        private string street;

        [ObservableProperty]
        private string houseNumber;

        [ObservableProperty]
        private string houseLetter;

        [ObservableProperty]
        private string entrance;

        [ObservableProperty]
        private string floor;

        [ObservableProperty]
        private string apartmentNumber;

        [ObservableProperty]
        private string addressDate;

        [ObservableProperty]
        private string addressLabel;

        [ObservableProperty]
        private BitmapImage portrait;
    }
}
