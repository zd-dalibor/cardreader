using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Service
{
    public class VehicleIdReaderServiceException : Exception
    {
        public int ErrorId { get; }

        public VehicleIdReaderServiceException(int errorId) : base(ErrorIdToMessage(errorId))
        {
            ErrorId = errorId;
        }

        private static string ErrorIdToMessage(int errorId)
        {
            return errorId switch
            {
                IVehicleIdReaderService.ERROR_BAD_FORMAT => "ERROR_BAD_FORMAT",
                IVehicleIdReaderService.ERROR_INVALID_ACCESS => "ERROR_INVALID_ACCESS",
                IVehicleIdReaderService.ERROR_INVALID_DATA => "ERROR_INVALID_DATA",
                IVehicleIdReaderService.ERROR_INVALID_PARAMETER => "ERROR_INVALID_PARAMETER",
                IVehicleIdReaderService.ERROR_SERVICE_ALREADY_RUNNING => "ERROR_SERVICE_ALREADY_RUNNING",
                IVehicleIdReaderService.ERROR_SERVICE_NOT_ACTIVE => "ERROR_SERVICE_NOT_ACTIVE",
                IVehicleIdReaderService.E_POINTER => "E_POINTER",
                IVehicleIdReaderService.SCARD_E_INSUFFICIENT_BUFFER => "SCARD_E_INSUFFICIENT_BUFFER",
                IVehicleIdReaderService.SCARD_E_UNKNOWN_READER => "SCARD_E_UNKNOWN_READER",
                IVehicleIdReaderService.SCARD_E_NO_SMARTCARD => "SCARD_E_NO_SMARTCARD",
                IVehicleIdReaderService.SCARD_E_INVALID_VALUE => "SCARD_E_INVALID_VALUE",
                IVehicleIdReaderService.SCARD_E_READER_UNAVAILABLE => "SCARD_E_READER_UNAVAILABLE",
                IVehicleIdReaderService.SCARD_E_CARD_UNSUPPORTED => "SCARD_E_CARD_UNSUPPORTED",
                IVehicleIdReaderService.SCARD_E_NO_READERS_AVAILABLE => "SCARD_E_NO_READERS_AVAILABLE",
                _ => "UNKNOWN_ERROR"
            };
        }
    }
}
