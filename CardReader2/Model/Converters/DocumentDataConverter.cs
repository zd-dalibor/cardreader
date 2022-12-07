using CardReader.Model.Data.Eid;
using CardReader.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Model.Converters
{
    internal class DocumentDataConverter
    {
        public static DocumentData From(IdReaderLib.EID_DOCUMENT_DATA data)
        {
            var documentData = new DocumentData
            {
                DocRegNo = StringUtil.BytesToString(data.docRegNo, data.docRegNoSize),
                DocumentType = StringUtil.BytesToString(data.documentType, data.documentTypeSize),
                IssuingDate = StringUtil.BytesToString(data.issuingDate, data.issuingDateSize),
                ExpiryDate = StringUtil.BytesToString(data.expiryDate, data.expiryDateSize),
                IssuingAuthority = StringUtil.BytesToString(data.issuingAuthority, data.issuingAuthoritySize),
                DocumentSerialNumber = StringUtil.BytesToString(data.documentSerialNumber, data.documentSerialNumberSize),
                ChipSerialNumber = StringUtil.BytesToString(data.chipSerialNumber, data.chipSerialNumberSize)
            };
            return documentData;
        }
    }
}
