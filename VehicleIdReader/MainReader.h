// MainReader.h : Declaration of the CMainReader

#pragma once
#include "resource.h"       // main symbols



#include "VehicleIdReader_i.h"



#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif

using namespace ATL;


// CMainReader

class ATL_NO_VTABLE CMainReader :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CMainReader, &CLSID_MainReader>,
	public IDispatchImpl<IMainReader, &IID_IMainReader, &LIBID_VehicleIdReaderLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CMainReader()
	{
	}

DECLARE_REGISTRY_RESOURCEID(106)


BEGIN_COM_MAP(CMainReader)
	COM_INTERFACE_ENTRY(IMainReader)
	COM_INTERFACE_ENTRY(IDispatch)
END_COM_MAP()



	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
	}

public:
	STDMETHOD(sdStartup)(int apiVersion, long* res);
	STDMETHOD(sdCleanup)(long* res);
	STDMETHOD(GetReaderName)(long index, SAFEARRAY** readerName, long* nameSize, long* res);
	STDMETHOD(SelectReader)(SAFEARRAY* readerName, long* res);
	STDMETHOD(sdProcessNewCard)(long* res);
	STDMETHOD(sdReadRegistration)(SD_REGISTRATION_DATAx* data, long index, long* res);
	STDMETHOD(sdReadDocumentData)(SD_DOCUMENT_DATAx* data, long* res);
	STDMETHOD(sdReadVehicleData)(SD_VEHICLE_DATAx* data, long* res);
	STDMETHOD(sdReadPersonalData)(SD_PERSONAL_DATAx* data, long* res);
};

OBJECT_ENTRY_AUTO(__uuidof(MainReader), CMainReader)
