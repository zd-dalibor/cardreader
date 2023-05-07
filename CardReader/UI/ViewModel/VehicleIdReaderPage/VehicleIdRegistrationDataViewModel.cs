using CommunityToolkit.Mvvm.ComponentModel;

namespace CardReader.UI.ViewModel.VehicleIdReaderPage
{
    public partial class VehicleIdRegistrationDataViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool? isValid;

        [ObservableProperty]
        private string verificationErrorMsg;

        [ObservableProperty]
        private string verificationErrorDetails;
    }
}
