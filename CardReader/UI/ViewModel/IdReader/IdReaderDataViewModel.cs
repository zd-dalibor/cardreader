using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardReader.UI.ViewModel.IdReader
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
    }
}
