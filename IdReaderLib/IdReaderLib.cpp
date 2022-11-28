#include "pch.h"

#include "IdReaderLib.h"

using namespace System::Runtime::InteropServices;

namespace IdReaderLib {
    int IdReader::EID_CARD_ID2008::get() { return ::EID_CARD_ID2008; }
    int IdReader::EID_CARD_ID2014::get() { return ::EID_CARD_ID2014; }
    int IdReader::EID_CARD_IF2020::get() { return ::EID_CARD_IF2020; }

    int IdReader::EID_O_KEEP_CARD_CLOSED::get() { return ::EID_O_KEEP_CARD_CLOSED; }

    int IdReader::EID_Cert_MoiIntermediateCA::get() { return ::EID_Cert_MoiIntermediateCA; }
    int IdReader::EID_Cert_User1::get() { return ::EID_Cert_User1; }
    int IdReader::EID_Cert_User2::get() { return ::EID_Cert_User2; }

    int IdReader::EID_SIG_CARD::get() { return ::EID_SIG_CARD; }
    int IdReader::EID_SIG_FIXED::get() { return ::EID_SIG_FIXED; }
    int IdReader::EID_SIG_VARIABLE::get() { return ::EID_SIG_VARIABLE; }
    int IdReader::EID_SIG_PORTRAIT::get() { return ::EID_SIG_PORTRAIT; }

    int IdReader::EID_OK::get() { return ::EID_OK;	}
    int IdReader::EID_E_GENERAL_ERROR::get() { return ::EID_E_GENERAL_ERROR; }
    int IdReader::EID_E_INVALID_PARAMETER::get() { return ::EID_E_INVALID_PARAMETER; }
    int IdReader::EID_E_VERSION_NOT_SUPPORTED::get() { return ::EID_E_VERSION_NOT_SUPPORTED; }
    int IdReader::EID_E_NOT_INITIALIZED::get() { return ::EID_E_NOT_INITIALIZED; }
    int IdReader::EID_E_UNABLE_TO_EXECUTE::get() { return ::EID_E_UNABLE_TO_EXECUTE; }
    int IdReader::EID_E_READER_ERROR::get() { return ::EID_E_READER_ERROR; }
    int IdReader::EID_E_CARD_MISSING::get() { return ::EID_E_CARD_MISSING; }
    int IdReader::EID_E_CARD_UNKNOWN::get() { return ::EID_E_CARD_UNKNOWN; }
    int IdReader::EID_E_CARD_MISMATCH::get() { return ::EID_E_CARD_MISMATCH; }
    int IdReader::EID_E_UNABLE_TO_OPEN_SESSION::get() { return ::EID_E_UNABLE_TO_OPEN_SESSION; }
    int IdReader::EID_E_DATA_MISSING::get() { return ::EID_E_DATA_MISSING; }
    int IdReader::EID_E_CARD_SECFORMAT_CHECK_ERROR::get() { return::EID_E_CARD_SECFORMAT_CHECK_ERROR; }
    int IdReader::EID_E_SECFORMAT_CHECK_CERT_ERROR::get() { return ::EID_E_SECFORMAT_CHECK_CERT_ERROR; }
    int IdReader::EID_E_INVALID_PASSWORD::get() { return ::EID_E_INVALID_PASSWORD; }
    int IdReader::EID_E_PIN_BLOCKED::get() { return::EID_E_PIN_BLOCKED; }

    int IdReader::EidSetOption(int nOptionID, UIntPtr nOptionValue)
    {
        return ::EidSetOption(nOptionID, static_cast<UINT_PTR>(nOptionValue));
    }

    int IdReader::EidStartup(int nApiVersion)
    {
        return ::EidStartup(nApiVersion);
    }

    int IdReader::EidCleanup()
    {
        return ::EidCleanup();
    }

    int IdReader::EidBeginRead(String^ szReader, [Out] int% pnCardType)
    {
        IntPtr pszReader = Marshal::StringToHGlobalAnsi(szReader);
        LPCSTR nszReader = static_cast<LPCSTR>(pszReader.ToPointer());
        pin_ptr<int> ppnCardType = &pnCardType;

        int result = ::EidBeginRead(nszReader, ppnCardType);

        Marshal::FreeHGlobal(pszReader);

        return result;
    }

    int IdReader::EidBeginRead(String^ szReader)
    {
        int pnCardType;
        return EidBeginRead(szReader, pnCardType);
    }

    int IdReader::EidEndRead()
    {
        return ::EidEndRead();
    }

    int IdReader::EidReadDocumentData(EID_DOCUMENT_DATA% pData)
    {
        ::EID_DOCUMENT_DATA npData;
        int result = ::EidReadDocumentData(&npData);

        if (result == ::EID_OK) {
            pData.docRegNo = gcnew array<Byte>(EID_MAX_DocRegNo);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.docRegNo)), pData.docRegNo, 0, EID_MAX_DocRegNo);
            pData.docRegNoSize = npData.docRegNoSize;

            pData.documentType = gcnew array<Byte>(EID_MAX_DocumentType);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.documentType)), pData.documentType, 0, EID_MAX_DocumentType);
            pData.documentTypeSize = npData.documentTypeSize;

            pData.issuingDate = gcnew array<Byte>(EID_MAX_IssuingDate);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.issuingDate)), pData.issuingDate, 0, EID_MAX_IssuingDate);
            pData.issuingDateSize = npData.issuingDateSize;

            pData.expiryDate = gcnew array<Byte>(EID_MAX_ExpiryDate);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.expiryDate)), pData.expiryDate, 0, EID_MAX_ExpiryDate);
            pData.expiryDateSize = npData.expiryDateSize;

            pData.issuingAuthority = gcnew array<Byte>(EID_MAX_IssuingAuthority);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.issuingAuthority)), pData.issuingAuthority, 0, EID_MAX_IssuingAuthority);
            pData.issuingAuthoritySize = npData.issuingAuthoritySize;

            pData.documentSerialNumber = gcnew array<Byte>(EID_MAX_DocumentSerialNumber);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.documentSerialNumber)), pData.documentSerialNumber, 0, EID_MAX_DocumentSerialNumber);
            pData.documentSerialNumberSize = npData.documentSerialNumberSize;

            pData.chipSerialNumber = gcnew array<Byte>(EID_MAX_ChipSerialNumber);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.chipSerialNumber)), pData.chipSerialNumber, 0, EID_MAX_ChipSerialNumber);
            pData.chipSerialNumberSize = npData.chipSerialNumberSize;
        }

        return result;
    }

    int IdReader::EidReadFixedPersonalData(EID_FIXED_PERSONAL_DATA% pData)
    {
        ::EID_FIXED_PERSONAL_DATA npData;
        int result = ::EidReadFixedPersonalData(&npData);

        if (result == ::EID_OK) {
            pData.personalNumber = gcnew array<Byte>(EID_MAX_PersonalNumber);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.personalNumber)), pData.personalNumber, 0, EID_MAX_PersonalNumber);
            pData.personalNumberSize = npData.personalNumberSize;

            pData.surname = gcnew array<Byte>(EID_MAX_Surname);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.surname)), pData.surname, 0, EID_MAX_Surname);
            pData.surnameSize = npData.surnameSize;

            pData.givenName = gcnew array<Byte>(EID_MAX_GivenName);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.givenName)), pData.givenName, 0, EID_MAX_GivenName);
            pData.givenNameSize = npData.givenNameSize;

            pData.parentGivenName = gcnew array<Byte>(EID_MAX_ParentGivenName);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.parentGivenName)), pData.parentGivenName, 0, EID_MAX_ParentGivenName);
            pData.parentGivenNameSize = npData.parentGivenNameSize;

            pData.sex = gcnew array<Byte>(EID_MAX_Sex);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.sex)), pData.sex, 0, EID_MAX_Sex);
            pData.sexSize = npData.sexSize;

            pData.placeOfBirth = gcnew array<Byte>(EID_MAX_PlaceOfBirth);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.placeOfBirth)), pData.placeOfBirth, 0, EID_MAX_PlaceOfBirth);
            pData.placeOfBirthSize = npData.placeOfBirthSize;

            pData.stateOfBirth = gcnew array<Byte>(EID_MAX_StateOfBirth);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.stateOfBirth)), pData.stateOfBirth, 0, EID_MAX_StateOfBirth);
            pData.stateOfBirthSize = npData.stateOfBirthSize;

            pData.dateOfBirth = gcnew array<Byte>(EID_MAX_DateOfBirth);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.dateOfBirth)), pData.dateOfBirth, 0, EID_MAX_DateOfBirth);
            pData.dateOfBirthSize = npData.dateOfBirthSize;

            pData.communityOfBirth = gcnew array<Byte>(EID_MAX_CommunityOfBirth);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.communityOfBirth)), pData.communityOfBirth, 0, EID_MAX_CommunityOfBirth);
            pData.communityOfBirthSize = npData.communityOfBirthSize;

            pData.statusOfForeigner = gcnew array<Byte>(EID_MAX_StatusOfForeigner);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.statusOfForeigner)), pData.statusOfForeigner, 0, EID_MAX_StatusOfForeigner);
            pData.statusOfForeignerSize = npData.statusOfForeignerSize;

            pData.nationalityFull = gcnew array<Byte>(EID_MAX_NationalityFull);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.nationalityFull)), pData.nationalityFull, 0, EID_MAX_NationalityFull);
            pData.nationalityFullSize = npData.nationalityFullSize;
        }

        return result;
    }

    int IdReader::EidReadVariablePersonalData(EID_VARIABLE_PERSONAL_DATA% pData)
    {
        ::EID_VARIABLE_PERSONAL_DATA npData;
        int result = ::EidReadVariablePersonalData(&npData);

        if (result == ::EID_OK) {
            pData.state = gcnew array<Byte>(EID_MAX_State);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.state)), pData.state, 0, EID_MAX_State);
            pData.stateSize = npData.stateSize;

            pData.community = gcnew array<Byte>(EID_MAX_Community);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.community)), pData.community, 0, EID_MAX_Community);
            pData.communitySize = npData.communitySize;

            pData.place = gcnew array<Byte>(EID_MAX_Place);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.place)), pData.place, 0, EID_MAX_Place);
            pData.placeSize = npData.placeSize;

            pData.street = gcnew array<Byte>(EID_MAX_Street);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.street)), pData.street, 0, EID_MAX_Street);
            pData.streetSize = npData.streetSize;

            pData.houseNumber = gcnew array<Byte>(EID_MAX_HouseNumber);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.houseNumber)), pData.houseNumber, 0, EID_MAX_HouseNumber);
            pData.houseNumberSize = npData.houseNumberSize;

            pData.houseLetter = gcnew array<Byte>(EID_MAX_HouseLetter);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.houseLetter)), pData.houseLetter, 0, EID_MAX_HouseLetter);
            pData.houseLetterSize = npData.houseLetterSize;

            pData.entrance = gcnew array<Byte>(EID_MAX_Entrance);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.entrance)), pData.entrance, 0, EID_MAX_Entrance);
            pData.entranceSize = npData.entranceSize;

            pData.floor = gcnew array<Byte>(EID_MAX_Floor);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.floor)), pData.floor, 0, EID_MAX_Floor);
            pData.floorSize = npData.floorSize;

            pData.apartmentNumber = gcnew array<Byte>(EID_MAX_ApartmentNumber);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.apartmentNumber)), pData.apartmentNumber, 0, EID_MAX_ApartmentNumber);
            pData.apartmentNumberSize = npData.apartmentNumberSize;

            pData.addressDate = gcnew array<Byte>(EID_MAX_AddressDate);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.addressDate)), pData.addressDate, 0, EID_MAX_AddressDate);
            pData.addressDateSize = npData.addressDateSize;

            pData.addressLabel = gcnew array<Byte>(EID_MAX_AddressLabel);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.addressLabel)), pData.addressLabel, 0, EID_MAX_AddressLabel);
            pData.addressLabelSize = npData.addressLabelSize;
        }

        return result;
    }

    int IdReader::EidReadPortrait(EID_PORTRAIT% pData)
    {
        ::EID_PORTRAIT npData;
        int result = ::EidReadPortrait(&npData);

        if (result == ::EID_OK) {
            pData.portrait = gcnew array<Byte>(EID_MAX_Portrait);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.portrait)), pData.portrait, 0, EID_MAX_Portrait);
            pData.portraitSize = npData.portraitSize;
        }

        return result;
    }

    int IdReader::EidReadCertificate(EID_CERTIFICATE% pData, int certificateType)
    {
        ::EID_CERTIFICATE npData;
        int result = ::EidReadCertificate(&npData, certificateType);

        if (result == ::EID_OK) {
            pData.certificate = gcnew array<Byte>(EID_MAX_Certificate);
            Marshal::Copy(IntPtr(static_cast<void*>(npData.certificate)), pData.certificate, 0, EID_MAX_Certificate);
            pData.certificateSize = npData.certificateSize;
        }

        return result;
    }

    int IdReader::EidChangePassword(String^ szOldPassword, String^ szNewPassword, int% pnTriesLeft)
    {
        IntPtr pszOldPassword = Marshal::StringToHGlobalAnsi(szOldPassword);
        LPCSTR nszOldPassword = static_cast<LPCSTR>(pszOldPassword.ToPointer());
        IntPtr pszNewPassword = Marshal::StringToHGlobalAnsi(szNewPassword);
        LPCSTR nszNewPassword = static_cast<LPCSTR>(pszNewPassword.ToPointer());
        pin_ptr<int> ppnTriesLeft = &pnTriesLeft;

        int result = ::EidChangePassword(nszOldPassword, nszNewPassword, ppnTriesLeft);

        Marshal::FreeHGlobal(pszOldPassword);
        Marshal::FreeHGlobal(pszNewPassword);

        return result;
    }

    int IdReader::EidVerifySignature(unsigned int nSignatureID)
    {
        return ::EidVerifySignature(nSignatureID);
    }
}