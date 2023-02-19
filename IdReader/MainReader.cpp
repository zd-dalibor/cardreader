// MainReader.cpp : Implementation of CMainReader

#include "pch.h"
#include "MainReader.h"


// CMainReader



STDMETHODIMP CMainReader::EidSetOption(int nOptionID, UINT_PTR nOptionValue, int* result)
{
	*result = ::EidSetOption(nOptionID, nOptionValue);

	return S_OK;
}
