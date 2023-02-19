

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 8.01.0628 */
/* at Tue Jan 19 04:14:07 2038
 */
/* Compiler settings for IdReader.idl:
    Oicf, W1, Zp8, env=Win64 (32b run), target_arch=AMD64 8.01.0628 
    protocol : all , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */



/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 500
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif /* __RPCNDR_H_VERSION__ */

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __IdReader_i_h__
#define __IdReader_i_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

#ifndef DECLSPEC_XFGVIRT
#if defined(_CONTROL_FLOW_GUARD_XFG)
#define DECLSPEC_XFGVIRT(base, func) __declspec(xfg_virtual(base, func))
#else
#define DECLSPEC_XFGVIRT(base, func)
#endif
#endif

/* Forward Declarations */ 

#ifndef __IMainReader_FWD_DEFINED__
#define __IMainReader_FWD_DEFINED__
typedef interface IMainReader IMainReader;

#endif 	/* __IMainReader_FWD_DEFINED__ */


#ifndef __MainReader_FWD_DEFINED__
#define __MainReader_FWD_DEFINED__

#ifdef __cplusplus
typedef class MainReader MainReader;
#else
typedef struct MainReader MainReader;
#endif /* __cplusplus */

#endif 	/* __MainReader_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"
#include "shobjidl.h"

#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __IMainReader_INTERFACE_DEFINED__
#define __IMainReader_INTERFACE_DEFINED__

/* interface IMainReader */
/* [unique][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IMainReader;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("964e82fb-0486-4e42-9e64-a126c7c69c47")
    IMainReader : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE EidSetOption( 
            /* [in] */ int nOptionID,
            /* [in] */ UINT_PTR nOptionValue,
            /* [retval][out] */ int *result) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IMainReaderVtbl
    {
        BEGIN_INTERFACE
        
        DECLSPEC_XFGVIRT(IUnknown, QueryInterface)
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMainReader * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        DECLSPEC_XFGVIRT(IUnknown, AddRef)
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMainReader * This);
        
        DECLSPEC_XFGVIRT(IUnknown, Release)
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMainReader * This);
        
        DECLSPEC_XFGVIRT(IDispatch, GetTypeInfoCount)
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IMainReader * This,
            /* [out] */ UINT *pctinfo);
        
        DECLSPEC_XFGVIRT(IDispatch, GetTypeInfo)
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IMainReader * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        DECLSPEC_XFGVIRT(IDispatch, GetIDsOfNames)
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IMainReader * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        DECLSPEC_XFGVIRT(IDispatch, Invoke)
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IMainReader * This,
            /* [annotation][in] */ 
            _In_  DISPID dispIdMember,
            /* [annotation][in] */ 
            _In_  REFIID riid,
            /* [annotation][in] */ 
            _In_  LCID lcid,
            /* [annotation][in] */ 
            _In_  WORD wFlags,
            /* [annotation][out][in] */ 
            _In_  DISPPARAMS *pDispParams,
            /* [annotation][out] */ 
            _Out_opt_  VARIANT *pVarResult,
            /* [annotation][out] */ 
            _Out_opt_  EXCEPINFO *pExcepInfo,
            /* [annotation][out] */ 
            _Out_opt_  UINT *puArgErr);
        
        DECLSPEC_XFGVIRT(IMainReader, EidSetOption)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EidSetOption )( 
            IMainReader * This,
            /* [in] */ int nOptionID,
            /* [in] */ UINT_PTR nOptionValue,
            /* [retval][out] */ int *result);
        
        END_INTERFACE
    } IMainReaderVtbl;

    interface IMainReader
    {
        CONST_VTBL struct IMainReaderVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMainReader_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IMainReader_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IMainReader_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IMainReader_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IMainReader_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IMainReader_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IMainReader_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define IMainReader_EidSetOption(This,nOptionID,nOptionValue,result)	\
    ( (This)->lpVtbl -> EidSetOption(This,nOptionID,nOptionValue,result) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IMainReader_INTERFACE_DEFINED__ */



#ifndef __IdReaderLib_LIBRARY_DEFINED__
#define __IdReaderLib_LIBRARY_DEFINED__

/* library IdReaderLib */
/* [version][uuid] */ 


EXTERN_C const IID LIBID_IdReaderLib;

EXTERN_C const CLSID CLSID_MainReader;

#ifdef __cplusplus

class DECLSPEC_UUID("69d69136-49d2-4039-add3-14d220f6464a")
MainReader;
#endif
#endif /* __IdReaderLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


