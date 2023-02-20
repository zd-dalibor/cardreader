using CardReader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardReader.Service
{
    public interface IIdReaderService
    {
        public const int EID_O_KEEP_CARD_CLOSED     = 1;

        public const int EID_CARD_ID2008            = 1; // old card type
        public const int EID_CARD_ID2014            = 2; // new card type
        public const int EID_CARD_IF2020            = 3; // ID for foreigners

        // results
        public const int EID_OK                            =  0;
        public const int EID_E_GENERAL_ERROR               = -1;
        public const int EID_E_INVALID_PARAMETER           = -2;
        public const int EID_E_VERSION_NOT_SUPPORTED       = -3;
        public const int EID_E_NOT_INITIALIZED             = -4;
        public const int EID_E_UNABLE_TO_EXECUTE           = -5;
        public const int EID_E_READER_ERROR                = -6;
        public const int EID_E_CARD_MISSING                = -7;
        public const int EID_E_CARD_UNKNOWN                = -8;
        public const int EID_E_CARD_MISMATCH               = -9;
        public const int EID_E_UNABLE_TO_OPEN_SESSION      = -10;
        public const int EID_E_DATA_MISSING                = -11;
        public const int EID_E_CARD_SECFORMAT_CHECK_ERROR  = -12;
        public const int EID_E_SECFORMAT_CHECK_CERT_ERROR  = -13;
        public const int EID_E_INVALID_PASSWORD            = -14;
        public const int EID_E_PIN_BLOCKED                 = -15;

        public IdReaderData Read(string cardReaderName, int apiVersion);
    }
}
