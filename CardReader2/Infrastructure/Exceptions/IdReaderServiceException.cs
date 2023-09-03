using System;
using CardReader.Core.Service.IdReader;

namespace CardReader.Infrastructure.Exceptions
{
    internal class IdReaderServiceException : Exception
    {
        public int ErrorId { get; }

        public IdReaderServiceException(int errorId) : base(ErrorIdToMessage(errorId))
        {
            ErrorId = errorId;
        }

        private static string ErrorIdToMessage(int errorId)
        {
            return errorId switch
            {
                IIdReaderService.EID_E_GENERAL_ERROR => "EID_E_GENERAL_ERROR",
                IIdReaderService.EID_E_INVALID_PARAMETER => "EID_E_INVALID_PARAMETER",
                IIdReaderService.EID_E_VERSION_NOT_SUPPORTED => "EID_E_VERSION_NOT_SUPPORTED",
                IIdReaderService.EID_E_NOT_INITIALIZED => "EID_E_NOT_INITIALIZED",
                IIdReaderService.EID_E_UNABLE_TO_EXECUTE => "EID_E_UNABLE_TO_EXECUTE",
                IIdReaderService.EID_E_READER_ERROR => "EID_E_READER_ERROR",
                IIdReaderService.EID_E_CARD_MISSING => "EID_E_CARD_MISSING",
                IIdReaderService.EID_E_CARD_UNKNOWN => "EID_E_CARD_UNKNOWN",
                IIdReaderService.EID_E_CARD_MISMATCH => "EID_E_CARD_MISMATCH",
                IIdReaderService.EID_E_UNABLE_TO_OPEN_SESSION => "EID_E_UNABLE_TO_OPEN_SESSION",
                IIdReaderService.EID_E_DATA_MISSING => "EID_E_DATA_MISSING",
                IIdReaderService.EID_E_CARD_SECFORMAT_CHECK_ERROR => "EID_E_CARD_SECFORMAT_CHECK_ERROR",
                IIdReaderService.EID_E_SECFORMAT_CHECK_CERT_ERROR => "EID_E_SECFORMAT_CHECK_CERT_ERROR",
                IIdReaderService.EID_E_INVALID_PASSWORD => "EID_E_INVALID_PASSWORD",
                IIdReaderService.EID_E_PIN_BLOCKED => "EID_E_PIN_BLOCKED",
                _ => "UNKNOWN_ERROR"
            };
        }
    }
}
