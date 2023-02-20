using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardReader.Model;
using IdReaderLib;
using iText.Kernel.Geom;

namespace CardReader.Service
{
    public class IdReaderService : IIdReaderService
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

        private static void VerifyResult(int result)
        {
            if (result != IIdReaderService.EID_OK)
            {
                throw new IdReaderServiceException(result);
            }
        }
    }
}
