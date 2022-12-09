// MainReader.cpp : Implementation of CMainReader

#include "pch.h"
#include "MainReader.h"

#include <string>
#include <algorithm>
#include <iterator>
using namespace std;


#define DATA_COPY(SRC, PDESC, FIELD) \
    copy(begin(SRC.FIELD), end(SRC.FIELD), PDESC->FIELD); \
    PDESC->FIELD ## Size = SRC.FIELD ## Size;



// CMainReader



STDMETHODIMP CMainReader::sdStartup(int apiVersion, long* res)
{
    *res = ::sdStartup(apiVersion);

    return S_OK;
}


STDMETHODIMP CMainReader::sdCleanup(long* res)
{
    *res = ::sdCleanup();

    return S_OK;
}


STDMETHODIMP CMainReader::GetReaderName(long index, SAFEARRAY** readerName, long* nameSize, long* res)
{
    *res = ::GetReaderName(index, static_cast<char*>((*readerName)->pvData), nameSize);

    return S_OK;
}


STDMETHODIMP CMainReader::SelectReader(SAFEARRAY* readerName, long* res)
{
    *res = ::SelectReader(static_cast<char*>(readerName->pvData));

    return S_OK;
}


STDMETHODIMP CMainReader::sdProcessNewCard(long* res)
{
    *res = ::sdProcessNewCard();

    return S_OK;
}


STDMETHODIMP CMainReader::sdReadRegistration(SD_REGISTRATION_DATAx* data, long index, long* res)
{
    SD_REGISTRATION_DATA tmp{};
    *res = ::sdReadRegistration(&tmp, index);

    if (res == S_OK) {
        DATA_COPY(tmp, data, registrationData)
        DATA_COPY(tmp, data, signatureData)
        DATA_COPY(tmp, data, issuingAuthority)
    }

    return S_OK;
}


STDMETHODIMP CMainReader::sdReadDocumentData(SD_DOCUMENT_DATAx* data, long* res)
{
    SD_DOCUMENT_DATA tmp{};
    *res = ::sdReadDocumentData(&tmp);

    if (res == S_OK) {
        DATA_COPY(tmp, data, stateIssuing)
        DATA_COPY(tmp, data, competentAuthority)
        DATA_COPY(tmp, data, authorityIssuing)
        DATA_COPY(tmp, data, unambiguousNumber)
        DATA_COPY(tmp, data, issuingDate)
        DATA_COPY(tmp, data, expiryDate)
        DATA_COPY(tmp, data, serialNumber)
    }

    return S_OK;
}


STDMETHODIMP CMainReader::sdReadVehicleData(SD_VEHICLE_DATAx* data, long* res)
{
    SD_VEHICLE_DATA tmp{};
    *res = ::sdReadVehicleData(&tmp);

    if (res == S_OK) {
        DATA_COPY(tmp, data, dateOfFirstRegistration)
        DATA_COPY(tmp, data, yearOfProduction)
        DATA_COPY(tmp, data, vehicleMake)
        DATA_COPY(tmp, data, vehicleType)
        DATA_COPY(tmp, data, commercialDescription)
        DATA_COPY(tmp, data, vehicleIDNumber)
        DATA_COPY(tmp, data, registrationNumberOfVehicle)
        DATA_COPY(tmp, data, maximumNetPower)
        DATA_COPY(tmp, data, engineCapacity)
        DATA_COPY(tmp, data, typeOfFuel)
        DATA_COPY(tmp, data, powerWeightRatio)
        DATA_COPY(tmp, data, vehicleMass)
        DATA_COPY(tmp, data, maximumPermissibleLadenMass)
        DATA_COPY(tmp, data, typeApprovalNumber)
        DATA_COPY(tmp, data, numberOfSeats)
        DATA_COPY(tmp, data, numberOfStandingPlaces)
        DATA_COPY(tmp, data, engineIDNumber)
        DATA_COPY(tmp, data, numberOfAxles)
        DATA_COPY(tmp, data, vehicleCategory)
        DATA_COPY(tmp, data, colourOfVehicle)
        DATA_COPY(tmp, data, restrictionToChangeOwner)
        DATA_COPY(tmp, data, vehicleLoad)
    }

    return S_OK;
}


STDMETHODIMP CMainReader::sdReadPersonalData(SD_PERSONAL_DATAx* data, long* res)
{
    SD_PERSONAL_DATA tmp{};
    *res = ::sdReadPersonalData(&tmp);

    if (*res == S_OK) {
        DATA_COPY(tmp, data, ownersPersonalNo)
        DATA_COPY(tmp, data, ownersSurnameOrBusinessName)
        DATA_COPY(tmp, data, ownerName)
        DATA_COPY(tmp, data, ownerAddress)
        DATA_COPY(tmp, data, usersPersonalNo)
        DATA_COPY(tmp, data, usersSurnameOrBusinessName)
        DATA_COPY(tmp, data, usersName)
        DATA_COPY(tmp, data, usersAddress)
    }

    return S_OK;
}
