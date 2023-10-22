# CardReader

Appliation for reading:

  * eIDs (Electronic identification) in Serbia - IdReader
  * Vehicle electronic identification in Serbia - VehicleIdReader

## Structure

### Dot Net Core

Application UI & Bussines logic.

* `CardReader` - WinUI 3 application.
* `CardReader.Core` - Core components for applicaiton.
* `CardReader.Services` - Servic implementations not related to UI.
* `CardReader.Tests` - Service tests.
* `CardReader.Win32` - Exported Win API methods for using in application.

### COM (C++ ATL)

Interactions with components for reading ID and Vehicle ID cards provided by Serbian goverment.

* `IdReader` - COM component for reading ID cards.
* `VehicleIdReader` - COM component for reading Vehicle ID cards.

### Others

* `Design` - designing assets (fonts, images)
* `Doc` - documentation
* `Scripts` - build helper scripts

## Building & Packaging

Visual Studio with Tools for the Windows App SDK
([Install tools for the Windows App SDK](https://learn.microsoft.com/en-us/windows/apps/windows-app-sdk/set-up-your-development-environment)).

Quick build and packaging: use scripts in `Scripts` folder.

Build order:

  * Build `IdReader` and register COM component
  * Build `VehicleIdReader` and register COM component
  * Build `CardReader` and run application

For registering and deregistering COM components check `reg.(ps1,cmd)` & `unreg.(ps1,cmd)` scripts in `Script` folder.

## IdReader

* [Addition Software, Libraries and Documentation](http://ca.mup.gov.rs/ca/ca_cyr/start/kes/)
* [Documentation](Doc/Celik%20API%201.3.3%20-%20opis%20funkcija.pdf)

## VehicleIdReader

* [Addition Software, Libraries and Documentation](http://www.mup.gov.rs/wps/portal/sr/gradjani/dokumenta/registracija+vozila/citac+elektronske+saobracajne+dozvole)
* [Documentation](Doc/eVehicle%20Registration%20SDK%20Korisnicko%20Uputstvo.pdf)

## Reporting

* [QuestPDF](https://github.com/QuestPDF/QuestPDF)

## Signing

* Certificate `Doc\signing.pfx`

## Scripts

Scripts are located in `Script` folder and contains scripts for quick build and packaging application for deployment.

Change execution policy for powershell scripts (run as administrator):

```pwsh
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned
```

## Icon Font

Incons for application are modified using [Affinti Designer](https://affinity.serif.com/en-us/designer/).
Icons file: `Design\Icons\icons.afdesign`.

Icons are exported as svg files in `Design\Icons\svg`, optimized with [SVG Optimizer](https://github.com/svg/svgo),
and cmobined in font using [SVG To Font](https://github.com/jaywcjlove/svgtofont).

Building icon font:

```pwsh
npm install
npm build
```
