using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Model
{
    public class DriverLicenseData
    {
        // SD_DOCUMENT_DATA
        public string StateIssuing { get; set; }
        public string CompetentAuthority { get; set; }
        public string AuthorityIssuing { get; set; }
        public string UnambiguousNumber { get; set; }
        public string IssuingDate { get; set; }
        public string ExpiryDate { get; set; }
        public string SerialNumber { get; set; }
        // SD_VEHICLE_DATA
        public string DateOfFirstRegistration { get; set; }
        public string YearOfProduction { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleType { get; set; }
        public string CommercialDescription { get; set; }
        public string VehicleIdNumber { get; set; }
        public string RegistrationNumberOfVehicle { get; set; }
        public string MaximumNetPower { get; set; }
        public string EngineCapacity { get; set; }
        public string TypeOfFuel { get; set; }
        public string PowerWeightRatio { get; set; }
        public string VehicleMass { get; set; }
        public string MaximumPermissibleLadenMass { get; set; }
        public string TypeApprovalNumber { get; set; }
        public string NumberOfSeats { get; set; }
        public string NumberOfStandingPlaces { get; set; }
        public string EngineIdNumber { get; set; }
        public string NumberOfAxles { get; set; }
        public string VehicleCategory { get; set; }
        public string ColourOfVehicle { get; set; }
        public string RestrictionToChangeOwner { get; set; }
        public string VehicleLoad { get; set; }
        // SD_PERSONAL_DATA
        public string OwnersPersonalNo { get; set; }
        public string OwnersSurnameOrBusinessName { get; set; }
        public string OwnerName { get; set; }
        public string OwnerAddress { get; set; }
        public string UsersPersonalNo { get; set; }
        public string UsersSurnameOrBusinessName { get; set; }
        public string UsersName { get; set; }
        public string UsersAddress { get; set; }
        // SD_REGISTRATION_DATA
        public List<DriverLicenseRegistrationData> RegistrationData { get; set; } = new();
    }
}
