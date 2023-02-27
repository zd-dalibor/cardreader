using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Service
{
    public class DriverLicenseReaderServiceException : Exception
    {
        public int ErrorId { get; }

        public DriverLicenseReaderServiceException(int errorId) : base(ErrorIdToMessage(errorId))
        {
            ErrorId = errorId;
        }

        private static string ErrorIdToMessage(int errorId)
        {
            return errorId switch
            {
                IDriverLicenseReaderService.ERROR_BAD_FORMAT => "ERROR_BAD_FORMAT",
                IDriverLicenseReaderService.ERROR_INVALID_ACCESS => "ERROR_INVALID_ACCESS",
                IDriverLicenseReaderService.ERROR_INVALID_DATA => "ERROR_INVALID_DATA",
                IDriverLicenseReaderService.ERROR_INVALID_PARAMETER => "ERROR_INVALID_PARAMETER",
                IDriverLicenseReaderService.ERROR_SERVICE_ALREADY_RUNNING => "ERROR_SERVICE_ALREADY_RUNNING",
                IDriverLicenseReaderService.ERROR_SERVICE_NOT_ACTIVE => "ERROR_SERVICE_NOT_ACTIVE",
                IDriverLicenseReaderService.E_POINTER => "E_POINTER",
                IDriverLicenseReaderService.SCARD_E_INSUFFICIENT_BUFFER => "SCARD_E_INSUFFICIENT_BUFFER",
                IDriverLicenseReaderService.SCARD_E_UNKNOWN_READER => "SCARD_E_UNKNOWN_READER",
                IDriverLicenseReaderService.SCARD_E_NO_SMARTCARD => "SCARD_E_NO_SMARTCARD",
                IDriverLicenseReaderService.SCARD_E_INVALID_VALUE => "SCARD_E_INVALID_VALUE",
                IDriverLicenseReaderService.SCARD_E_READER_UNAVAILABLE => "SCARD_E_READER_UNAVAILABLE",
                IDriverLicenseReaderService.SCARD_E_CARD_UNSUPPORTED => "SCARD_E_CARD_UNSUPPORTED",
                IDriverLicenseReaderService.SCARD_E_NO_READERS_AVAILABLE => "SCARD_E_NO_READERS_AVAILABLE",
                _ => "UNKNOWN_ERROR"
            };
        }
    }
}
