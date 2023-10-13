using ReactiveUI;
using System.Collections.ObjectModel;
using ReactiveUI.Fody.Helpers;

namespace CardReader.UI.VehicleIdReader
{
    public class VehicleIdData : ReactiveObject
    {
        // SD_DOCUMENT_DATA
        [Reactive]
        public string StateIssuing { get; set; }

        [Reactive]
        public string CompetentAuthority { get; set; }

        [Reactive]
        public string AuthorityIssuing { get; set; }

        [Reactive]
        public string UnambiguousNumber { get; set; }

        [Reactive]
        public string IssuingDate { get; set; }

        [Reactive]
        public string ExpiryDate { get; set; }

        [Reactive]
        public string SerialNumber { get; set; }

        [Reactive]
        public string DateOfFirstRegistration { get; set; }

        [Reactive]
        public string YearOfProduction { get; set; }

        [Reactive]
        public string VehicleMake { get; set; }

        [Reactive]
        public string VehicleType { get; set; }

        [Reactive]
        public string CommercialDescription { get; set; }

        [Reactive]
        public string VehicleIdNumber { get; set; }

        [Reactive]
        public string RegistrationNumberOfVehicle { get; set; }

        [Reactive]
        public string MaximumNetPower { get; set; }

        [Reactive]
        public string EngineCapacity { get; set; }

        [Reactive]
        public string TypeOfFuel { get; set; }

        [Reactive]
        public string PowerWeightRatio { get; set; }

        [Reactive]
        public string VehicleMass { get; set; }

        [Reactive]
        public string MaximumPermissibleLadenMass { get; set; }

        [Reactive]
        public string TypeApprovalNumber { get; set; }

        [Reactive]
        public string NumberOfSeats { get; set; }

        [Reactive]
        public string NumberOfStandingPlaces { get; set; }

        [Reactive]
        public string EngineIdNumber { get; set; }

        [Reactive]
        public string NumberOfAxles { get; set; }

        [Reactive]
        public string VehicleCategory { get; set; }

        [Reactive]
        public string ColourOfVehicle { get; set; }

        [Reactive]
        public string RestrictionToChangeOwner { get; set; }

        [Reactive]
        public string VehicleLoad { get; set; }

        // SD_PERSONAL_DATA
        [Reactive]
        public string OwnersPersonalNo { get; set; }

        [Reactive]
        public string OwnersSurnameOrBusinessName { get; set; }

        [Reactive]
        public string OwnerName { get; set; }

        [Reactive]
        public string OwnerAddress { get; set; }

        [Reactive]
        public string UsersPersonalNo { get; set; }

        [Reactive]
        public string UsersSurnameOrBusinessName { get; set; }

        [Reactive]
        public string UsersName { get; set; }

        [Reactive]
        public string UsersAddress { get; set; }

        // SD_REGISTRATION_DATA
        [Reactive] 
        public ObservableCollection<VehicleIdRegistrationData> RegistrationData { get; set; }

        public VehicleIdData()
        {
            RegistrationData = new();
        }
    }
}
