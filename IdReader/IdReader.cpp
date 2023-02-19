// IdReader.cpp : Implementation of WinMain


#include "pch.h"
#include "framework.h"
#include "resource.h"
#include "IdReader_i.h"
#include "xdlldata.h"


using namespace ATL;


class CIdReaderModule : public ATL::CAtlExeModuleT< CIdReaderModule >
{
public :
	DECLARE_LIBID(LIBID_IdReaderLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_IDREADER, "{280de70d-0847-4e73-89c1-c3b43da1a0e8}")
};

CIdReaderModule _AtlModule;



//
extern "C" int WINAPI _tWinMain(HINSTANCE /*hInstance*/, HINSTANCE /*hPrevInstance*/,
								LPTSTR /*lpCmdLine*/, int nShowCmd)
{
	return _AtlModule.WinMain(nShowCmd);
}

