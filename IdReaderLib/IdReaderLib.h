#pragma once

using namespace System;
using namespace System::Runtime::InteropServices;

namespace IdReaderLib {
	public value struct EID_DOCUMENT_DATA
	{
		array<Byte>^ docRegNo;
		int docRegNoSize;
		array<Byte>^ documentType;
		int documentTypeSize;
		array<Byte>^ issuingDate;
		int issuingDateSize;
		array<Byte>^ expiryDate;
		int expiryDateSize;
		array<Byte>^ issuingAuthority;
		int issuingAuthoritySize;
		array<Byte>^ documentSerialNumber;
		int documentSerialNumberSize;
		array<Byte>^ chipSerialNumber;
		int chipSerialNumberSize;
	};

	public value struct EID_FIXED_PERSONAL_DATA
	{
		array<Byte>^ personalNumber;
		int personalNumberSize;
		array<Byte>^ surname;
		int surnameSize;
		array<Byte>^ givenName;
		int givenNameSize;
		array<Byte>^ parentGivenName;
		int parentGivenNameSize;
		array<Byte>^ sex;
		int sexSize;
		array<Byte>^ placeOfBirth;
		int placeOfBirthSize;
		array<Byte>^ stateOfBirth;
		int stateOfBirthSize;
		array<Byte>^ dateOfBirth;
		int dateOfBirthSize;
		array<Byte>^ communityOfBirth;
		int communityOfBirthSize;
		array<Byte>^ statusOfForeigner;
		int statusOfForeignerSize;
		array<Byte>^ nationalityFull;
		int nationalityFullSize;
	};

	public value struct EID_VARIABLE_PERSONAL_DATA
	{
		array<Byte>^ state;
		int stateSize;
		array<Byte>^ community;
		int communitySize;
		array<Byte>^ place;
		int placeSize;
		array<Byte>^ street;
		int streetSize;
		array<Byte>^ houseNumber;
		int houseNumberSize;
		array<Byte>^ houseLetter;
		int houseLetterSize;
		array<Byte>^ entrance;
		int entranceSize;
		array<Byte>^ floor;
		int floorSize;
		array<Byte>^ apartmentNumber;
		int apartmentNumberSize;
		array<Byte>^ addressDate;
		int addressDateSize;
		array<Byte>^ addressLabel;
		int addressLabelSize;
	};

	public value struct EID_PORTRAIT
	{
		array<Byte>^ portrait;
		int portraitSize;
	};

	public value struct EID_CERTIFICATE
	{
		array<Byte>^ certificate;
		int certificateSize;
	};

	public ref class IdReader abstract sealed
	{
	public:
		//
		// Card types, used in function EidBeginRead
		//

		static property int EID_CARD_ID2008 { int get(); }
		static property int EID_CARD_ID2014 { int get(); };
		static property int EID_CARD_IF2020 { int get(); }; // ID for foreigners

		//
		// Option identifiers, used in function EidSetOption
		//

		static property int EID_O_KEEP_CARD_CLOSED { int get(); };

		//
		// Certificate types, used in function EidReadCertificate
		//

		static property int EID_Cert_MoiIntermediateCA { int get(); };
		static property int EID_Cert_User1 { int get(); };
		static property int EID_Cert_User2 { int get(); };

		//
		// Block types, used in function EidVerifySignature
		//

		static property int EID_SIG_CARD { int get(); };
		static property int EID_SIG_FIXED { int get(); };
		static property int EID_SIG_VARIABLE { int get(); };
		static property int EID_SIG_PORTRAIT { int get(); };

		// For new card version EidVerifySignature function will return EID_E_UNABLE_TO_EXECUTE for
		// parameter EID_SIG_PORTRAIT. Portrait is in new cards part of EID_SIG_FIXED. To determine
		// the card version use second parameter of function EidBeginRead

		//
		// Function return values
		//

		static property int EID_OK { int get();  };
		static property int EID_E_GENERAL_ERROR { int get(); };
		static property int EID_E_INVALID_PARAMETER { int get(); };
		static property int EID_E_VERSION_NOT_SUPPORTED { int get(); };
		static property int EID_E_NOT_INITIALIZED { int get(); };
		static property int EID_E_UNABLE_TO_EXECUTE { int get(); };
		static property int EID_E_READER_ERROR { int get(); };
		static property int EID_E_CARD_MISSING { int get(); };
		static property int EID_E_CARD_UNKNOWN { int get(); };
		static property int EID_E_CARD_MISMATCH { int get(); };
		static property int EID_E_UNABLE_TO_OPEN_SESSION { int get(); };
		static property int EID_E_DATA_MISSING { int get(); };
		static property int EID_E_CARD_SECFORMAT_CHECK_ERROR { int get(); };
		static property int EID_E_SECFORMAT_CHECK_CERT_ERROR { int get(); };
		static property int EID_E_INVALID_PASSWORD { int get(); };
		static property int EID_E_PIN_BLOCKED { int get(); };

		//
		// Functions
		//
		
		static int EidSetOption(int nOptionID, UIntPtr nOptionValue);

		static int EidStartup(int nApiVersion);
		static int EidCleanup();

		static int EidBeginRead(String^ szReader, [Out] int% pnCardType);
		static int EidBeginRead(String^ szReader);
		static int EidEndRead();

		static int EidReadDocumentData(EID_DOCUMENT_DATA% pData);
		static int EidReadFixedPersonalData(EID_FIXED_PERSONAL_DATA% pData);
		static int EidReadVariablePersonalData(EID_VARIABLE_PERSONAL_DATA% pData);
		static int EidReadPortrait(EID_PORTRAIT% pData);
		static int EidReadCertificate(EID_CERTIFICATE% pData, int certificateType);

		static int EidChangePassword(String^ szOldPassword, String^ szNewPassword, [Out] int% pnTriesLeft);
		static int EidVerifySignature(unsigned int nSignatureID);
	};
}
