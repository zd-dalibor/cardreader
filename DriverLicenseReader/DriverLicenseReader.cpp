// DriverLicenseReader.cpp : Implementation of WinMain


#include "pch.h"
#include "framework.h"
#include "resource.h"
#include "DriverLicenseReader_i.h"


using namespace ATL;


class CDriverLicenseReaderModule : public ATL::CAtlExeModuleT< CDriverLicenseReaderModule >
{
public :
	DECLARE_LIBID(LIBID_DriverLicenseReaderLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_DRIVERLICENSEREADER, "{ce18ab4b-0703-4a4c-890d-6e997291578a}")
};

CDriverLicenseReaderModule _AtlModule;



//
extern "C" int WINAPI _tWinMain(_In_ HINSTANCE /*hInstance*/, _In_opt_ HINSTANCE /*hPrevInstance*/,
								_In_ LPTSTR /*lpCmdLine*/, _In_ int nShowCmd)
{
	return _AtlModule.WinMain(nShowCmd);
}

