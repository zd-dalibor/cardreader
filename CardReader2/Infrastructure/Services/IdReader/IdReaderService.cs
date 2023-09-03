using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CardReader.Core.Model.IdReader;
using CardReader.Core.Service.IdReader;
using CardReader.Infrastructure.Exceptions;
using IdReaderLib;

namespace CardReader.Infrastructure.Services.IdReader
{
    internal class IdReaderService : IIdReaderService
    {
        public IdReaderData Read(string cardReaderName, int apiVersion)
        {
            var data = new IdReaderData();
            var reader = new MainReader();
            SetOption(reader, IIdReaderService.EID_O_KEEP_CARD_CLOSED, 0);
            try
            {
                Startup(reader, apiVersion);
                data.CardType = BeginRead(reader, cardReaderName);
                try
                {
                    var documentData = ReadDocumentData(reader);
                    data.DocRegNo = SbyteToString(documentData.docRegNo, documentData.docRegNoSize);
                    data.DocumentType = SbyteToString(documentData.documentType, documentData.documentTypeSize);
                    data.IssuingDate = SbyteToString(documentData.issuingDate, documentData.issuingDateSize);
                    data.ExpiryDate = SbyteToString(documentData.expiryDate, documentData.expiryDateSize);
                    data.IssuingAuthority = SbyteToString(documentData.issuingAuthority, documentData.issuingAuthoritySize);
                    data.DocumentSerialNumber = SbyteToString(documentData.documentSerialNumber, documentData.documentSerialNumberSize);
                    data.ChipSerialNumber = SbyteToString(documentData.chipSerialNumber, documentData.chipSerialNumberSize);

                    var fixedPersonalData = ReadFixedPersonalData(reader);
                    data.PersonalNumber = SbyteToString(fixedPersonalData.personalNumber, fixedPersonalData.personalNumberSize);
                    data.Surname = SbyteToString(fixedPersonalData.surname, fixedPersonalData.surnameSize);
                    data.GivenName = SbyteToString(fixedPersonalData.givenName, fixedPersonalData.givenNameSize);
                    data.ParentGivenName = SbyteToString(fixedPersonalData.parentGivenName, fixedPersonalData.parentGivenNameSize);
                    data.Sex = SbyteToString(fixedPersonalData.sex, fixedPersonalData.sexSize);
                    data.PlaceOfBirth = SbyteToString(fixedPersonalData.placeOfBirth, fixedPersonalData.placeOfBirthSize);
                    data.StateOfBirth = SbyteToString(fixedPersonalData.stateOfBirth, fixedPersonalData.stateOfBirthSize);
                    data.DateOfBirth = SbyteToString(fixedPersonalData.dateOfBirth, fixedPersonalData.dateOfBirthSize);
                    data.CommunityOfBirth = SbyteToString(fixedPersonalData.communityOfBirth, fixedPersonalData.communityOfBirthSize);
                    data.StatusOfForeigner = SbyteToString(fixedPersonalData.statusOfForeigner, fixedPersonalData.statusOfForeignerSize);
                    data.NationalityFull = SbyteToString(fixedPersonalData.nationalityFull, fixedPersonalData.nationalityFullSize);

                    var variablePersonalData = ReadVariablePersonalData(reader);
                    data.State = SbyteToString(variablePersonalData.state, variablePersonalData.stateSize);
                    data.Community = SbyteToString(variablePersonalData.community, variablePersonalData.communitySize);
                    data.Place = SbyteToString(variablePersonalData.place, variablePersonalData.placeSize);
                    data.Street = SbyteToString(variablePersonalData.street, variablePersonalData.streetSize);
                    data.HouseNumber = SbyteToString(variablePersonalData.houseNumber, variablePersonalData.houseNumberSize);
                    data.HouseLetter = SbyteToString(variablePersonalData.houseLetter, variablePersonalData.houseLetterSize);
                    data.Entrance = SbyteToString(variablePersonalData.entrance, variablePersonalData.entranceSize);
                    data.Floor = SbyteToString(variablePersonalData.floor, variablePersonalData.floorSize);
                    data.ApartmentNumber = SbyteToString(variablePersonalData.apartmentNumber, variablePersonalData.apartmentNumberSize);
                    data.AddressDate = SbyteToString(variablePersonalData.addressDate, variablePersonalData.addressDateSize);
                    data.AddressLabel = SbyteToString(variablePersonalData.addressLabel, variablePersonalData.addressLabelSize);

                    var portraitData = ReadPortrait(reader);
                    data.Portrait = CopyBytes(portraitData.portrait, portraitData.portraitSize);

                    //if (data.CardType == IIdReaderService.EID_CARD_ID2008)
                    //{
                    //    var certIntermediateCaData = ReadCertificate(reader, IIdReaderService.EID_Cert_MoiIntermediateCA);
                    //    data.CertIntermediateCa = CopyBytes(certIntermediateCaData.certificate, certIntermediateCaData.certificateSize);

                    //    var certUser1Data = ReadCertificate(reader, IIdReaderService.EID_Cert_User1);
                    //    data.CertUser1 = CopyBytes(certUser1Data.certificate, certUser1Data.certificateSize);

                    //    var certUser2Data = ReadCertificate(reader, IIdReaderService.EID_Cert_User2);
                    //    data.CertUser2 = CopyBytes(certUser2Data.certificate, certUser2Data.certificateSize);
                    //}

                    try
                    {
                        VerifySignature(reader, IIdReaderService.EID_SIG_CARD);
                        data.SigCardVerified = true;
                    }
                    catch (IdReaderServiceException)
                    {
                        data.SigCardVerified = false;
                    }

                    try
                    {
                        VerifySignature(reader, IIdReaderService.EID_SIG_FIXED);
                        data.SigFixedVerified = true;
                    }
                    catch (IdReaderServiceException)
                    {
                        data.SigFixedVerified = false;
                    }

                    try
                    {
                        VerifySignature(reader, IIdReaderService.EID_SIG_VARIABLE);
                        data.SigVariableVerified = true;
                    }
                    catch (IdReaderServiceException)
                    {
                        data.SigVariableVerified = false;
                    }

                    if (data.CardType == IIdReaderService.EID_CARD_ID2008)
                    {
                        try
                        {
                            VerifySignature(reader, IIdReaderService.EID_SIG_PORTRAIT);
                            data.SigPortraitVerified = true;
                        }
                        catch (IdReaderServiceException)
                        {
                            data.SigPortraitVerified = false;
                        }
                    }
                }
                finally
                {
                    EndRead(reader);
                }
            }
            finally
            {
                Cleanup(reader);
            }

            return data;
        }

        public Task<IdReaderData> ReadAsync(string cardReaderName, int apiVersion, CancellationToken token = default)
        {
            return Task.Factory.StartNew(() =>
            {
                var result = Read(cardReaderName, apiVersion);
                token.ThrowIfCancellationRequested();
                return result;
            }, token);
        }

        private static byte[] CopyBytes(IEnumerable<byte> data, int size)
        {
            return data.Take(size).ToArray();
        }

        private static string SbyteToString(IEnumerable<sbyte> data, int size)
        {
            return Encoding.UTF8.GetString(data.Take(size).Select(x => (byte)x).ToArray());
        }

        private static void SetOption(IMainReader reader, int optionId, ulong optionValue)
        {
            VerifyResult(reader.EidSetOption(optionId, optionValue));
        }

        private static void Startup(IMainReader reader, int apiVersion)
        {
            VerifyResult(reader.EidStartup(apiVersion));
        }

        private static void Cleanup(IMainReader reader)
        {
            VerifyResult(reader.EidCleanup());
        }

        private static int BeginRead(IMainReader reader, string cardReaderName)
        {
            VerifyResult(reader.EidBeginRead(cardReaderName, out var cardType));
            return cardType;
        }

        private static void EndRead(IMainReader reader)
        {
            VerifyResult(reader.EidEndRead());
        }

        private static EID_DOCUMENT_DATAx ReadDocumentData(IMainReader reader)
        {
            VerifyResult(reader.EidReadDocumentData(out var pData));
            return pData;
        }

        private static EID_FIXED_PERSONAL_DATAx ReadFixedPersonalData(IMainReader reader)
        {
            VerifyResult(reader.EidReadFixedPersonalData(out var pData));
            return pData;
        }

        private static EID_VARIABLE_PERSONAL_DATAx ReadVariablePersonalData(IMainReader reader)
        {
            VerifyResult(reader.EidReadVariablePersonalData(out var pData));
            return pData;
        }

        private static EID_PORTRAITx ReadPortrait(IMainReader reader)
        {
            VerifyResult(reader.EidReadPortrait(out var pData));
            return pData;
        }

        private static EID_CERTIFICATEx ReadCertificate(IMainReader reader, int certificateType)
        {
            VerifyResult(reader.EidReadCertificate(out var pData, certificateType));
            return pData;
        }

        private static void VerifySignature(IMainReader reader, uint signatureId)
        {
            VerifyResult(reader.EidVerifySignature(signatureId));

        }

        private static void VerifyResult(int result)
        {
            if (result != IIdReaderService.EID_OK)
            {
                throw new IdReaderServiceException(result);
            }
        }
    }
}
