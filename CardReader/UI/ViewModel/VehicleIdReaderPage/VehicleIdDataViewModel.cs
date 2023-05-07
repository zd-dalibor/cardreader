using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardReader.UI.ViewModel.VehicleIdReaderPage
{
    public partial class VehicleIdDataViewModel : ObservableObject
    {
        // SD_DOCUMENT_DATA
        [ObservableProperty]
        private string stateIssuing;

        [ObservableProperty]
        private string competentAuthority;

        [ObservableProperty]
        private string authorityIssuing;

        [ObservableProperty]
        private string unambiguousNumber;

        [ObservableProperty]
        private string issuingDate;

        [ObservableProperty]
        private string expiryDate;

        [ObservableProperty]
        private string serialNumber;

        // SD_VEHICLE_DATA
        [ObservableProperty]
        private string dateOfFirstRegistration;

        [ObservableProperty]
        private string yearOfProduction;

        [ObservableProperty]
        private string vehicleMake;

        [ObservableProperty]
        private string vehicleType;

        [ObservableProperty]
        private string commercialDescription;

        [ObservableProperty]
        private string vehicleIdNumber;

        [ObservableProperty]
        private string registrationNumberOfVehicle;

        [ObservableProperty]
        private string maximumNetPower;

        [ObservableProperty]
        private string engineCapacity;

        [ObservableProperty]
        private string typeOfFuel;

        [ObservableProperty]
        private string powerWeightRatio;

        [ObservableProperty]
        private string vehicleMass;

        [ObservableProperty]
        private string maximumPermissibleLadenMass;

        [ObservableProperty]
        private string typeApprovalNumber;

        [ObservableProperty]
        private string numberOfSeats;

        [ObservableProperty]
        private string numberOfStandingPlaces;

        [ObservableProperty]
        private string engineIdNumber;

        [ObservableProperty]
        private string numberOfAxles;

        [ObservableProperty]
        private string vehicleCategory;

        [ObservableProperty]
        private string colourOfVehicle;

        [ObservableProperty]
        private string restrictionToChangeOwner;

        [ObservableProperty]
        private string vehicleLoad;

        // SD_PERSONAL_DATA
        [ObservableProperty]
        private string ownersPersonalNo;

        [ObservableProperty]
        private string ownersSurnameOrBusinessName;

        [ObservableProperty]
        private string ownerName;

        [ObservableProperty]
        private string ownerAddress;

        [ObservableProperty]
        private string usersPersonalNo;

        [ObservableProperty]
        private string usersSurnameOrBusinessName;

        [ObservableProperty]
        private string usersName;

        [ObservableProperty]
        private string usersAddress;

        // SD_REGISTRATION_DATA
        [ObservableProperty]
        private ObservableCollection<VehicleIdRegistrationDataViewModel> registrationData = new();
    }
}
