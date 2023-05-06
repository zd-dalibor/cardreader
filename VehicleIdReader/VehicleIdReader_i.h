

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 8.01.0628 */
/* at Tue Jan 19 04:14:07 2038
 */
/* Compiler settings for VehicleIdReader.idl:
    Oicf, W1, Zp8, env=Win32 (32b run), target_arch=X86 8.01.0628 
    protocol : dce , ms_ext, c_ext, robust
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

#ifndef __VehicleIdReader_i_h__
#define __VehicleIdReader_i_h__

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


/* interface __MIDL_itf_VehicleIdReader_0000_0000 */
/* [local] */ 

typedef /* [version][uuid] */  DECLSPEC_UUID("5e1a86ef-7069-46a8-9102-16fe5834c40e") struct SD_REGISTRATION_DATAx
    {
    unsigned char registrationData[ 4096 ];
    long registrationDataSize;
    unsigned char signatureData[ 1024 ];
    long signatureDataSize;
    unsigned char issuingAuthority[ 4096 ];
    long issuingAuthoritySize;
    } 	SD_REGISTRATION_DATAx;

typedef /* [version][uuid] */  DECLSPEC_UUID("3406fbb1-815e-4370-8c93-c079ce5a01fa") struct SD_DOCUMENT_DATAx
    {
    unsigned char stateIssuing[ 50 ];
    long stateIssuingSize;
    unsigned char competentAuthority[ 50 ];
    long competentAuthoritySize;
    unsigned char authorityIssuing[ 50 ];
    long authorityIssuingSize;
    unsigned char unambiguousNumber[ 30 ];
    long unambiguousNumberSize;
    unsigned char issuingDate[ 16 ];
    long issuingDateSize;
    unsigned char expiryDate[ 16 ];
    long expiryDateSize;
    unsigned char serialNumber[ 20 ];
    long serialNumberSize;
    } 	SD_DOCUMENT_DATAx;

typedef /* [version][uuid] */  DECLSPEC_UUID("54fb0c83-d753-4b7c-ad76-dd81b9136495") struct SD_VEHICLE_DATAx
    {
    unsigned char dateOfFirstRegistration[ 16 ];
    long dateOfFirstRegistrationSize;
    unsigned char yearOfProduction[ 5 ];
    long yearOfProductionSize;
    unsigned char vehicleMake[ 100 ];
    long vehicleMakeSize;
    unsigned char vehicleType[ 100 ];
    long vehicleTypeSize;
    unsigned char commercialDescription[ 100 ];
    long commercialDescriptionSize;
    unsigned char vehicleIDNumber[ 100 ];
    long vehicleIDNumberSize;
    unsigned char registrationNumberOfVehicle[ 20 ];
    long registrationNumberOfVehicleSize;
    unsigned char maximumNetPower[ 20 ];
    long maximumNetPowerSize;
    unsigned char engineCapacity[ 20 ];
    long engineCapacitySize;
    unsigned char typeOfFuel[ 100 ];
    long typeOfFuelSize;
    unsigned char powerWeightRatio[ 20 ];
    long powerWeightRatioSize;
    unsigned char vehicleMass[ 20 ];
    long vehicleMassSize;
    unsigned char maximumPermissibleLadenMass[ 20 ];
    long maximumPermissibleLadenMassSize;
    unsigned char typeApprovalNumber[ 50 ];
    long typeApprovalNumberSize;
    unsigned char numberOfSeats[ 20 ];
    long numberOfSeatsSize;
    unsigned char numberOfStandingPlaces[ 20 ];
    long numberOfStandingPlacesSize;
    unsigned char engineIDNumber[ 100 ];
    long engineIDNumberSize;
    unsigned char numberOfAxles[ 20 ];
    long numberOfAxlesSize;
    unsigned char vehicleCategory[ 50 ];
    long vehicleCategorySize;
    unsigned char colourOfVehicle[ 50 ];
    long colourOfVehicleSize;
    unsigned char restrictionToChangeOwner[ 200 ];
    long restrictionToChangeOwnerSize;
    unsigned char vehicleLoad[ 20 ];
    long vehicleLoadSize;
    } 	SD_VEHICLE_DATAx;

typedef /* [version][uuid] */  DECLSPEC_UUID("c827838b-f7ef-41eb-ad8e-3e81ea49d4bd") struct SD_PERSONAL_DATAx
    {
    unsigned char ownersPersonalNo[ 20 ];
    long ownersPersonalNoSize;
    unsigned char ownersSurnameOrBusinessName[ 100 ];
    long ownersSurnameOrBusinessNameSize;
    unsigned char ownerName[ 100 ];
    long ownerNameSize;
    unsigned char ownerAddress[ 200 ];
    long ownerAddressSize;
    unsigned char usersPersonalNo[ 20 ];
    long usersPersonalNoSize;
    unsigned char usersSurnameOrBusinessName[ 100 ];
    long usersSurnameOrBusinessNameSize;
    unsigned char usersName[ 100 ];
    long usersNameSize;
    unsigned char usersAddress[ 200 ];
    long usersAddressSize;
    } 	SD_PERSONAL_DATAx;



extern RPC_IF_HANDLE __MIDL_itf_VehicleIdReader_0000_0000_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_VehicleIdReader_0000_0000_v0_0_s_ifspec;

#ifndef __IMainReader_INTERFACE_DEFINED__
#define __IMainReader_INTERFACE_DEFINED__

/* interface IMainReader */
/* [unique][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IMainReader;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("ca7cf799-8d7a-4852-854c-07348b0ba59c")
    IMainReader : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE sdStartup( 
            /* [in] */ int apiVersion,
            /* [retval][out] */ long *res) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE sdCleanup( 
            /* [retval][out] */ long *res) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetReaderName( 
            /* [in] */ long index,
            /* [out][in] */ SAFEARRAY * *readerName,
            /* [out][in] */ long *nameSize,
            /* [retval][out] */ long *res) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE SelectReader( 
            /* [in] */ SAFEARRAY * readerName,
            /* [retval][out] */ long *res) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE sdProcessNewCard( 
            /* [retval][out] */ long *res) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE sdReadRegistration( 
            /* [out][in] */ SD_REGISTRATION_DATAx *data,
            /* [in] */ long index,
            /* [retval][out] */ long *res) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE sdReadDocumentData( 
            /* [out][in] */ SD_DOCUMENT_DATAx *data,
            /* [retval][out] */ long *res) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE sdReadVehicleData( 
            /* [out][in] */ SD_VEHICLE_DATAx *data,
            /* [retval][out] */ long *res) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE sdReadPersonalData( 
            /* [out][in] */ SD_PERSONAL_DATAx *data,
            /* [retval][out] */ long *res) = 0;
        
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
        
        DECLSPEC_XFGVIRT(IMainReader, sdStartup)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *sdStartup )( 
            IMainReader * This,
            /* [in] */ int apiVersion,
            /* [retval][out] */ long *res);
        
        DECLSPEC_XFGVIRT(IMainReader, sdCleanup)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *sdCleanup )( 
            IMainReader * This,
            /* [retval][out] */ long *res);
        
        DECLSPEC_XFGVIRT(IMainReader, GetReaderName)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *GetReaderName )( 
            IMainReader * This,
            /* [in] */ long index,
            /* [out][in] */ SAFEARRAY * *readerName,
            /* [out][in] */ long *nameSize,
            /* [retval][out] */ long *res);
        
        DECLSPEC_XFGVIRT(IMainReader, SelectReader)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *SelectReader )( 
            IMainReader * This,
            /* [in] */ SAFEARRAY * readerName,
            /* [retval][out] */ long *res);
        
        DECLSPEC_XFGVIRT(IMainReader, sdProcessNewCard)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *sdProcessNewCard )( 
            IMainReader * This,
            /* [retval][out] */ long *res);
        
        DECLSPEC_XFGVIRT(IMainReader, sdReadRegistration)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *sdReadRegistration )( 
            IMainReader * This,
            /* [out][in] */ SD_REGISTRATION_DATAx *data,
            /* [in] */ long index,
            /* [retval][out] */ long *res);
        
        DECLSPEC_XFGVIRT(IMainReader, sdReadDocumentData)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *sdReadDocumentData )( 
            IMainReader * This,
            /* [out][in] */ SD_DOCUMENT_DATAx *data,
            /* [retval][out] */ long *res);
        
        DECLSPEC_XFGVIRT(IMainReader, sdReadVehicleData)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *sdReadVehicleData )( 
            IMainReader * This,
            /* [out][in] */ SD_VEHICLE_DATAx *data,
            /* [retval][out] */ long *res);
        
        DECLSPEC_XFGVIRT(IMainReader, sdReadPersonalData)
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *sdReadPersonalData )( 
            IMainReader * This,
            /* [out][in] */ SD_PERSONAL_DATAx *data,
            /* [retval][out] */ long *res);
        
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


#define IMainReader_sdStartup(This,apiVersion,res)	\
    ( (This)->lpVtbl -> sdStartup(This,apiVersion,res) ) 

#define IMainReader_sdCleanup(This,res)	\
    ( (This)->lpVtbl -> sdCleanup(This,res) ) 

#define IMainReader_GetReaderName(This,index,readerName,nameSize,res)	\
    ( (This)->lpVtbl -> GetReaderName(This,index,readerName,nameSize,res) ) 

#define IMainReader_SelectReader(This,readerName,res)	\
    ( (This)->lpVtbl -> SelectReader(This,readerName,res) ) 

#define IMainReader_sdProcessNewCard(This,res)	\
    ( (This)->lpVtbl -> sdProcessNewCard(This,res) ) 

#define IMainReader_sdReadRegistration(This,data,index,res)	\
    ( (This)->lpVtbl -> sdReadRegistration(This,data,index,res) ) 

#define IMainReader_sdReadDocumentData(This,data,res)	\
    ( (This)->lpVtbl -> sdReadDocumentData(This,data,res) ) 

#define IMainReader_sdReadVehicleData(This,data,res)	\
    ( (This)->lpVtbl -> sdReadVehicleData(This,data,res) ) 

#define IMainReader_sdReadPersonalData(This,data,res)	\
    ( (This)->lpVtbl -> sdReadPersonalData(This,data,res) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IMainReader_INTERFACE_DEFINED__ */



#ifndef __VehicleIdReaderLib_LIBRARY_DEFINED__
#define __VehicleIdReaderLib_LIBRARY_DEFINED__

/* library VehicleIdReaderLib */
/* [version][uuid] */ 






EXTERN_C const IID LIBID_VehicleIdReaderLib;

EXTERN_C const CLSID CLSID_MainReader;

#ifdef __cplusplus

class DECLSPEC_UUID("96c631a1-1594-40b6-b54b-f9b428a4e51d")
MainReader;
#endif
#endif /* __VehicleIdReaderLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  LPSAFEARRAY_UserSize(     unsigned long *, unsigned long            , LPSAFEARRAY * ); 
unsigned char * __RPC_USER  LPSAFEARRAY_UserMarshal(  unsigned long *, unsigned char *, LPSAFEARRAY * ); 
unsigned char * __RPC_USER  LPSAFEARRAY_UserUnmarshal(unsigned long *, unsigned char *, LPSAFEARRAY * ); 
void                      __RPC_USER  LPSAFEARRAY_UserFree(     unsigned long *, LPSAFEARRAY * ); 

unsigned long             __RPC_USER  LPSAFEARRAY_UserSize64(     unsigned long *, unsigned long            , LPSAFEARRAY * ); 
unsigned char * __RPC_USER  LPSAFEARRAY_UserMarshal64(  unsigned long *, unsigned char *, LPSAFEARRAY * ); 
unsigned char * __RPC_USER  LPSAFEARRAY_UserUnmarshal64(unsigned long *, unsigned char *, LPSAFEARRAY * ); 
void                      __RPC_USER  LPSAFEARRAY_UserFree64(     unsigned long *, LPSAFEARRAY * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


