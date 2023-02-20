// MainReader.cpp : Implementation of CMainReader

#include "pch.h"
#include "MainReader.h"

#include <algorithm>
using namespace std;


#define DATA_COPY(SRC, PDESC, FIELD) \
    copy(begin((SRC).FIELD), end((SRC).FIELD), (PDESC)->FIELD); \
    (PDESC)->FIELD ## Size = (SRC).FIELD ## Size;

// CMainReader



STDMETHODIMP CMainReader::EidSetOption(int nOptionID, UINT_PTR nOptionValue, int* result)
{
	*result = ::EidSetOption(nOptionID, nOptionValue);

	return S_OK;
}


STDMETHODIMP CMainReader::EidStartup(int nApiVersion, int* result)
{
	*result = ::EidStartup(nApiVersion);

	return S_OK;
}


STDMETHODIMP CMainReader::EidCleanup(int* result)
{
	*result = ::EidCleanup();

	return S_OK;
}


STDMETHODIMP CMainReader::EidBeginRead(LPCSTR szReader, int* pnCardType, int* result)
{
	*result = ::EidBeginRead(szReader, pnCardType);

	return S_OK;
}

STDMETHODIMP CMainReader::EidEndRead(int* result)
{
	*result = ::EidEndRead();

	return S_OK;
}


STDMETHODIMP CMainReader::EidReadDocumentData(EID_DOCUMENT_DATAx* pData, int* result)
{
	EID_DOCUMENT_DATA data;
	*result = ::EidReadDocumentData(&data);
	if (*result == EID_OK)
	{
		DATA_COPY(data, pData, docRegNo)
		DATA_COPY(data, pData, documentType)
		DATA_COPY(data, pData, issuingDate)
		DATA_COPY(data, pData, expiryDate)
		DATA_COPY(data, pData, issuingAuthority)
		DATA_COPY(data, pData, documentSerialNumber)
		DATA_COPY(data, pData, chipSerialNumber)
	}

	return S_OK;
}


STDMETHODIMP CMainReader::EidReadFixedPersonalData(EID_FIXED_PERSONAL_DATAx* pData, int* result)
{
	EID_FIXED_PERSONAL_DATA data;
	*result = ::EidReadFixedPersonalData(&data);
	if (*result == EID_OK)
	{
		DATA_COPY(data, pData, personalNumber)
		DATA_COPY(data, pData, surname)
		DATA_COPY(data, pData, givenName)
		DATA_COPY(data, pData, parentGivenName)
		DATA_COPY(data, pData, sex)
		DATA_COPY(data, pData, placeOfBirth)
		DATA_COPY(data, pData, stateOfBirth)
		DATA_COPY(data, pData, dateOfBirth)
		DATA_COPY(data, pData, communityOfBirth)
		DATA_COPY(data, pData, statusOfForeigner)
		DATA_COPY(data, pData, nationalityFull)
	}

	return S_OK;
}
