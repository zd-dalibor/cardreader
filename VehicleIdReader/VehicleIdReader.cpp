// VehicleIdReader.cpp : Implementation of WinMain


#include "pch.h"
#include "framework.h"
#include "resource.h"
#include "VehicleIdReader_i.h"
#include "xdlldata.h"


using namespace ATL;


class CVehicleIdReaderModule : public ATL::CAtlExeModuleT< CVehicleIdReaderModule >
{
public :
	DECLARE_LIBID(LIBID_VehicleIdReaderLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_VEHICLEIDREADER, "{4c275aff-dea2-47ef-9ba3-5dcca319dccc}")
};

CVehicleIdReaderModule _AtlModule;



//
extern "C" int WINAPI _tWinMain(HINSTANCE /*hInstance*/, HINSTANCE /*hPrevInstance*/,
								LPTSTR /*lpCmdLine*/, int nShowCmd)
{
	return _AtlModule.WinMain(nShowCmd);
}

