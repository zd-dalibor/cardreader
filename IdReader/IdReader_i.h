

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 8.01.0626 */
/* at Tue Jan 19 04:14:07 2038
 */
/* Compiler settings for IdReader.idl:
    Oicf, W1, Zp8, env=Win64 (32b run), target_arch=AMD64 8.01.0626 
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
#if _CONTROL_FLOW_GUARD_XFG
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


/* interface __MIDL_itf_IdReader_0000_0000 */
/* [local] */ 

typedef /* [version][uuid] */  DECLSPEC_UUID("8dd8d028-e7cd-48e2-a1cd-23fc37744083") struct EID_DOCUMENT_DATAx
    {
    unsigned char docRegNo[ 9 ];
    int docRegNoSize;
    unsigned char documentType[ 2 ];
    int documentTypeSize;
    unsigned char issuingDate[ 10 ];
    int issuingDateSize;
    unsigned char expiryDate[ 10 ];
    int expiryDateSize;
    unsigned char issuingAuthority[ 100 ];
    int issuingAuthoritySize;
    unsigned char documentSerialNumber[ 10 ];
    int documentSerialNumberSize;
    unsigned char chipSerialNumber[ 14 ];
    int chipSerialNumberSize;
    } 	EID_DOCUMENT_DATAx;

typedef /* [version][uuid] */  DECLSPEC_UUID("dfb573e7-6324-4f75-8552-56b9d46e0310") struct EID_FIXED_PERSONAL_DATAx
    {
    unsigned char personalNumber[ 13 ];
    int personalNumberSize;
    unsigned char surname[ 200 ];
    int surnameSize;
    unsigned char givenName[ 200 ];
    int givenNameSize;
    unsigned char parentGivenName[ 200 ];
    int parentGivenNameSize;
    unsigned char sex[ 2 ];
    int sexSize;
    unsigned char placeOfBirth[ 200 ];
    int placeOfBirthSize;
    unsigned char stateOfBirth[ 200 ];
    int stateOfBirthSize;
    unsigned char dateOfBirth[ 10 ];
    int dateOfBirthSize;
    unsigned char communityOfBirth[ 200 ];
    int communityOfBirthSize;
    unsigned char statusOfForeigner[ 200 ];
    int statusOfForeignerSize;
    unsigned char nationalityFull[ 200 ];
    int nationalityFullSize;
    } 	EID_FIXED_PERSONAL_DATAx;

typedef /* [version][uuid] */  DECLSPEC_UUID("730c24c1-494b-47db-abde-fe0fab25b14a") struct EID_VARIABLE_PERSONAL_DATAx
    {
    unsigned char state[ 100 ];
    int stateSize;
    unsigned char community[ 200 ];
    int communitySize;
    unsigned char place[ 200 ];
    int placeSize;
    unsigned char street[ 200 ];
    int streetSize;
    unsigned char houseNumber[ 20 ];
    int houseNumberSize;
    unsigned char houseLetter[ 8 ];
    int houseLetterSize;
    unsigned char entrance[ 10 ];
    int entranceSize;
    unsigned char floor[ 6 ];
    int floorSize;
    unsigned char apartmentNumber[ 12 ];
    int apartmentNumberSize;
    unsigned char addressDate[ 10 ];
    int addressDateSize;
    unsigned char addressLabel[ 60 ];
    int addressLabelSize;
    } 	EID_VARIABLE_PERSONAL_DATAx;

typedef /* [version][uuid] */  DECLSPEC_UUID("f2ac2748-2c33-45b6-8e62-8d84d38d6072") struct EID_PORTRAITx
    {
    BYTE portrait[ 7700 ];
    int portraitSize;
    } 	EID_PORTRAITx;

typedef /* [version][uuid] */  DECLSPEC_UUID("32acceb0-a0e9-47a0-aa34-7970f3ddc51a") struct EID_CERTIFICATEx
    {
    BYTE certificate[ 2048 ];
    int certificateSize;
    } 	EID_CERTIFICATEx;



extern RPC_IF_HANDLE __MIDL_itf_IdReader_0000_0000_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_IdReader_0000_0000_v0_0_s_ifspec;

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
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE EidStartup( 
            /* [in] */ int nApiVersion,
            /* [retval][out] */ int *result) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE EidCleanup( 
            /* [retval][out] */ int *result) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE EidBeginRead( 
            /* [in] */ LPCSTR szReader,
            /* [defaultvalue][out] */ int *pnCardType,
            /* [retval][out] */ int *result) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE EidEndRead( 
            /* [retval][out] */ int *result) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE EidReadDocumentData( 
            /* [out] */ EID_DOCUMENT_DATAx *pData,
            /* [retval][out] */ int *result) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE EidReadFixedPersonalData( 
            /* [out] */ EID_FIXED_PERSONAL_DATAx *pData,
            /* [retval][out] */ int *result) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE EidReadVariablePersonalData( 
            /* [out] */ EID_VARIABLE_PERSONAL_DATAx *pData,
            /* [retval][out] */ int *result) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE EidReadPortrait( 
            /* [out] */ EID_PORTRAITx *pData,
            /* [retval][out] */ int *result) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE EidReadCertificate( 
            /* [out] */ EID_CERTIFICATEx *pData,
            /* [in] */ int certificateType,
            /* [retval][out] */ int *result) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE EidChangePassword( 
            /* [in] */ LPCSTR szOldPassword,
            /* [in] */ LPCSTR szNewPassword,
            /* [out] */ int *pnTriesLeft,
            /* [retval][out] */ int *result) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE EidVerifySignature( 
            /* [in] */ UINT nSignatureID,
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
        
        DECLSPEC_XFGVIRT(IMainReader, EidStartup)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EidStartup )( 
            IMainReader * This,
            /* [in] */ int nApiVersion,
            /* [retval][out] */ int *result);
        
        DECLSPEC_XFGVIRT(IMainReader, EidCleanup)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EidCleanup )( 
            IMainReader * This,
            /* [retval][out] */ int *result);
        
        DECLSPEC_XFGVIRT(IMainReader, EidBeginRead)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EidBeginRead )( 
            IMainReader * This,
            /* [in] */ LPCSTR szReader,
            /* [defaultvalue][out] */ int *pnCardType,
            /* [retval][out] */ int *result);
        
        DECLSPEC_XFGVIRT(IMainReader, EidEndRead)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EidEndRead )( 
            IMainReader * This,
            /* [retval][out] */ int *result);
        
        DECLSPEC_XFGVIRT(IMainReader, EidReadDocumentData)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EidReadDocumentData )( 
            IMainReader * This,
            /* [out] */ EID_DOCUMENT_DATAx *pData,
            /* [retval][out] */ int *result);
        
        DECLSPEC_XFGVIRT(IMainReader, EidReadFixedPersonalData)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EidReadFixedPersonalData )( 
            IMainReader * This,
            /* [out] */ EID_FIXED_PERSONAL_DATAx *pData,
            /* [retval][out] */ int *result);
        
        DECLSPEC_XFGVIRT(IMainReader, EidReadVariablePersonalData)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EidReadVariablePersonalData )( 
            IMainReader * This,
            /* [out] */ EID_VARIABLE_PERSONAL_DATAx *pData,
            /* [retval][out] */ int *result);
        
        DECLSPEC_XFGVIRT(IMainReader, EidReadPortrait)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EidReadPortrait )( 
            IMainReader * This,
            /* [out] */ EID_PORTRAITx *pData,
            /* [retval][out] */ int *result);
        
        DECLSPEC_XFGVIRT(IMainReader, EidReadCertificate)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EidReadCertificate )( 
            IMainReader * This,
            /* [out] */ EID_CERTIFICATEx *pData,
            /* [in] */ int certificateType,
            /* [retval][out] */ int *result);
        
        DECLSPEC_XFGVIRT(IMainReader, EidChangePassword)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EidChangePassword )( 
            IMainReader * This,
            /* [in] */ LPCSTR szOldPassword,
            /* [in] */ LPCSTR szNewPassword,
            /* [out] */ int *pnTriesLeft,
            /* [retval][out] */ int *result);
        
        DECLSPEC_XFGVIRT(IMainReader, EidVerifySignature)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *EidVerifySignature )( 
            IMainReader * This,
            /* [in] */ UINT nSignatureID,
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

#define IMainReader_EidStartup(This,nApiVersion,result)	\
    ( (This)->lpVtbl -> EidStartup(This,nApiVersion,result) ) 

#define IMainReader_EidCleanup(This,result)	\
    ( (This)->lpVtbl -> EidCleanup(This,result) ) 

#define IMainReader_EidBeginRead(This,szReader,pnCardType,result)	\
    ( (This)->lpVtbl -> EidBeginRead(This,szReader,pnCardType,result) ) 

#define IMainReader_EidEndRead(This,result)	\
    ( (This)->lpVtbl -> EidEndRead(This,result) ) 

#define IMainReader_EidReadDocumentData(This,pData,result)	\
    ( (This)->lpVtbl -> EidReadDocumentData(This,pData,result) ) 

#define IMainReader_EidReadFixedPersonalData(This,pData,result)	\
    ( (This)->lpVtbl -> EidReadFixedPersonalData(This,pData,result) ) 

#define IMainReader_EidReadVariablePersonalData(This,pData,result)	\
    ( (This)->lpVtbl -> EidReadVariablePersonalData(This,pData,result) ) 

#define IMainReader_EidReadPortrait(This,pData,result)	\
    ( (This)->lpVtbl -> EidReadPortrait(This,pData,result) ) 

#define IMainReader_EidReadCertificate(This,pData,certificateType,result)	\
    ( (This)->lpVtbl -> EidReadCertificate(This,pData,certificateType,result) ) 

#define IMainReader_EidChangePassword(This,szOldPassword,szNewPassword,pnTriesLeft,result)	\
    ( (This)->lpVtbl -> EidChangePassword(This,szOldPassword,szNewPassword,pnTriesLeft,result) ) 

#define IMainReader_EidVerifySignature(This,nSignatureID,result)	\
    ( (This)->lpVtbl -> EidVerifySignature(This,nSignatureID,result) ) 

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


