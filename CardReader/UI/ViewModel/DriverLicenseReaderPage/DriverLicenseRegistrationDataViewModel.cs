using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardReader.UI.ViewModel.DriverLicenseReaderPage
{
    public partial class DriverLicenseRegistrationDataViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool? isValid;

        [ObservableProperty]
        private string verificationErrorMsg;

        [ObservableProperty]
        private string verificationErrorDetails;
    }
}
