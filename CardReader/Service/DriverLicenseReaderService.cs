using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CardReader.Model;
using VehicleIdReaderLib;

namespace CardReader.Service
{
    public class DriverLicenseReaderService : IDriverLicenseReaderService
    {
        public DriverLicenseData Read(string cardReaderName, int apiVersion)
        {
            var data = new DriverLicenseData();
            var reader = new MainReader();

            Startup(apiVersion, reader);
            try
            {
                var libReaderName = GetReaderName(cardReaderName, reader);
                SelectReader(libReaderName, reader);
                ProcessNewCard(reader);

                var documentData = ReadDocumentData(reader);
                data.StateIssuing = SbyteToString(documentData.stateIssuing, documentData.stateIssuingSize);
                data.CompetentAuthority = SbyteToString(documentData.competentAuthority, documentData.competentAuthoritySize);
                data.AuthorityIssuing = SbyteToString(documentData.authorityIssuing, documentData.authorityIssuingSize);
                data.UnambiguousNumber = SbyteToString(documentData.unambiguousNumber, documentData.unambiguousNumberSize);
                data.IssuingDate = SbyteToString(documentData.issuingDate, documentData.issuingDateSize);
                data.ExpiryDate = SbyteToString(documentData.expiryDate, documentData.expiryDateSize);
                data.SerialNumber = SbyteToString(documentData.serialNumber, documentData.serialNumberSize);

                var vehicleData = ReadVehicleData(reader);
                data.DateOfFirstRegistration = SbyteToString(vehicleData.dateOfFirstRegistration, vehicleData.dateOfFirstRegistrationSize);
                data.YearOfProduction = SbyteToString(vehicleData.yearOfProduction, vehicleData.yearOfProductionSize);
                data.VehicleMake = SbyteToString(vehicleData.vehicleMake, vehicleData.vehicleMakeSize);
                data.VehicleType = SbyteToString(vehicleData.vehicleType, vehicleData.vehicleTypeSize);
                data.CommercialDescription = SbyteToString(vehicleData.commercialDescription, vehicleData.commercialDescriptionSize);
                data.VehicleIdNumber = SbyteToString(vehicleData.vehicleIDNumber, vehicleData.vehicleIDNumberSize);
                data.RegistrationNumberOfVehicle = SbyteToString(vehicleData.registrationNumberOfVehicle, vehicleData.registrationNumberOfVehicleSize);
                data.MaximumNetPower = SbyteToString(vehicleData.maximumNetPower, vehicleData.maximumNetPowerSize);
                data.EngineCapacity = SbyteToString(vehicleData.engineCapacity, vehicleData.engineCapacitySize);
                data.TypeOfFuel = SbyteToString(vehicleData.typeOfFuel, vehicleData.typeOfFuelSize);
                data.PowerWeightRatio = SbyteToString(vehicleData.powerWeightRatio, vehicleData.powerWeightRatioSize);
                data.VehicleMass = SbyteToString(vehicleData.vehicleMass, vehicleData.vehicleMassSize);
                data.MaximumPermissibleLadenMass = SbyteToString(vehicleData.maximumPermissibleLadenMass, vehicleData.maximumPermissibleLadenMassSize);
                data.TypeApprovalNumber = SbyteToString(vehicleData.typeApprovalNumber, vehicleData.typeApprovalNumberSize);
                data.NumberOfSeats = SbyteToString(vehicleData.numberOfSeats, vehicleData.numberOfSeatsSize);
                data.NumberOfStandingPlaces = SbyteToString(vehicleData.numberOfStandingPlaces, vehicleData.numberOfStandingPlacesSize);
                data.EngineIdNumber = SbyteToString(vehicleData.engineIDNumber, vehicleData.engineIDNumberSize);
                data.NumberOfAxles = SbyteToString(vehicleData.numberOfAxles, vehicleData.numberOfAxlesSize);
                data.VehicleCategory = SbyteToString(vehicleData.vehicleCategory, vehicleData.vehicleCategorySize);
                data.ColourOfVehicle = SbyteToString(vehicleData.colourOfVehicle, vehicleData.colourOfVehicleSize);
                data.RestrictionToChangeOwner = SbyteToString(vehicleData.restrictionToChangeOwner, vehicleData.restrictionToChangeOwnerSize);
                data.VehicleLoad = SbyteToString(vehicleData.vehicleLoad, vehicleData.vehicleLoadSize);

                var personalData = ReadPersonalData(reader);
                data.OwnersPersonalNo = SbyteToString(personalData.ownersPersonalNo, personalData.ownersPersonalNoSize);
                data.OwnersSurnameOrBusinessName = SbyteToString(personalData.ownersSurnameOrBusinessName, personalData.ownersSurnameOrBusinessNameSize);
                data.OwnerName = SbyteToString(personalData.ownerName, personalData.ownerNameSize);
                data.OwnerAddress = SbyteToString(personalData.ownerAddress, personalData.ownerAddressSize);
                data.UsersPersonalNo = SbyteToString(personalData.usersPersonalNo, personalData.usersPersonalNoSize);
                data.UsersSurnameOrBusinessName = SbyteToString(personalData.usersSurnameOrBusinessName, personalData.usersSurnameOrBusinessNameSize);
                data.UsersName = SbyteToString(personalData.usersName, personalData.usersNameSize);
                data.UsersAddress = SbyteToString(personalData.usersAddress, personalData.usersAddressSize);

                data.RegistrationData = Enumerable.Range(1, 3).Select(i =>
                {
                    var tmp = ReadRegistration(i, reader);
                    var regData = new DriverLicenseRegistrationData
                    {
                        RegistrationData = CopyBytes(tmp.registrationData, tmp.registrationDataSize),
                        SignatureData = CopyBytes(tmp.signatureData, tmp.signatureDataSize),
                        IssuingAuthority = CopyBytes(tmp.issuingAuthority, tmp.issuingAuthoritySize)
                    };
                    VerifyRegistrationData(regData);
                    return regData;
                }).ToList();
            }
            finally
            {
                Cleanup(reader);
            }

            return data;
        }

        private static void VerifyRegistrationData(DriverLicenseRegistrationData regData)
        {
            try
            {
                var signature = regData.SignatureData.Take(256).ToArray();
                var cert = new X509Certificate2(regData.IssuingAuthority);

                using var rsa = cert.GetRSAPublicKey();
                regData.IsValid = rsa?.VerifyData(regData.RegistrationData, signature, HashAlgorithmName.SHA1,
                    RSASignaturePadding.Pkcs1);
            }
            catch (Exception e)
            {
                regData.VerificationErrorMsg = e.Message;
                regData.VerificationErrorDetails = e.StackTrace;
                regData.IsValid = false;
            }
        }

        private static void Startup(int apiVersion, IMainReader reader)
        {
            var result = reader.sdStartup(apiVersion);
            if (result != IDriverLicenseReaderService.ERROR_SERVICE_ALREADY_RUNNING &&
                result != IDriverLicenseReaderService.S_OK)
            {
                throw new DriverLicenseReaderServiceException(result);
            }
        }

        private static void Cleanup(IMainReader reader)
        {
            var result = reader.sdCleanup();
            if (result != IDriverLicenseReaderService.ERROR_SERVICE_NOT_ACTIVE &&
                result != IDriverLicenseReaderService.S_OK)
            {
                throw new DriverLicenseReaderServiceException(result);
            }
        }

        private static string GetReaderName(string cardReaderName, IMainReader reader)
        {
            var index = 0;
            while (true)
            {
                var size = 100;
                Array data = new sbyte[size];
                var result = reader.GetReaderName(index, ref data, ref size);
                if (result == IDriverLicenseReaderService.SCARD_E_INSUFFICIENT_BUFFER)
                {
                    data = new sbyte[size];
                    result = reader.GetReaderName(index, ref data, ref size);
                }

                if (result != IDriverLicenseReaderService.S_OK)
                {
                    throw new DriverLicenseReaderServiceException(result);
                }

                var libReaderName = SbyteToString(data.OfType<sbyte>(), size);
                if (libReaderName.Equals(cardReaderName))
                {
                    return libReaderName;
                }

                index++;
            }
        }

        private static void SelectReader(string cardReaderName, IMainReader reader)
        {
            var data = StringToSbyte(cardReaderName);
            VerifyResult(reader.SelectReader(data));
        }

        private static void ProcessNewCard(IMainReader reader)
        {
            VerifyResult(reader.sdProcessNewCard());
        }

        private static SD_DOCUMENT_DATAx ReadDocumentData(IMainReader reader)
        {
            var data = new SD_DOCUMENT_DATAx();
            VerifyResult(reader.sdReadDocumentData(ref data));
            return data;
        }

        private static SD_VEHICLE_DATAx ReadVehicleData(IMainReader reader)
        {
            var data = new SD_VEHICLE_DATAx();
            VerifyResult(reader.sdReadVehicleData(ref data));
            return data;
        }

        private static SD_PERSONAL_DATAx ReadPersonalData(IMainReader reader)
        {
            var data = new SD_PERSONAL_DATAx();
            VerifyResult(reader.sdReadPersonalData(ref data));
            return data;
        }

        private static SD_REGISTRATION_DATAx ReadRegistration(int index, IMainReader reader)
        {
            var data = new SD_REGISTRATION_DATAx();
            VerifyResult(reader.sdReadRegistration(ref data, index));
            return data;
        }

        private static string SbyteToString(IEnumerable<sbyte> data, int size)
        {
            return Encoding.UTF8.GetString(data.Take(size).Select(x => (byte)x).ToArray()).TrimEnd((char)0);
        }

        private static sbyte[] StringToSbyte(string str)
        {
            return Encoding.UTF8.GetBytes(str + '\0').Select(x => (sbyte)x).ToArray();
        }

        private static byte[] CopyBytes(IEnumerable<sbyte> data, int size)
        {
            return data.Take(size).Select(x => (byte)x).ToArray();
        }

        private static void VerifyResult(int result)
        {
            if (result != IDriverLicenseReaderService.S_OK)
            {
                throw new DriverLicenseReaderServiceException(result);
            }
        }

        public Task<DriverLicenseData> ReadAsync(string cardReaderName, int apiVersion, CancellationToken token = default)
        {
            return Task.Factory.StartNew(() => Read(cardReaderName, apiVersion), token);
        }
    }
}
