param(
    [string]$Configuartion,
    [string]$Platform
)

$ErrorActionPreference = 'Stop'

function DetectMsBuild {
    param ()

    $vs = & "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe" `
        -version "[17.0,18.0)" `
        -products * `
        -requires Microsoft.Component.MSBuild `
        -prerelease `
        -latest `
        -utf8 `
        -format json | ConvertFrom-Json
    return Join-Path $vs[0].installationPath "MSBuild" "Current" "Bin" "MSBuild.exe"
}

$msbuild = DetectMsBuild
$AppxPackageDir = Join-Path "bin" "$Platform" "$Configuartion" "AppPackages\"
$DestDir = Join-Path "bin" "$Platform" "$Configuartion"
$ComDir = Join-Path $DestDir "Com"

$IdReaderComFiles = @()
$VehicleIdReaderComFiles = @()

if ($Configuartion -eq "Debug" -And $Platform -eq "x64") {
    $IdReaderComFiles = @(
        # debug-x64
        ".\x64\Debug\CelikApi.dll",
        ".\x64\Debug\IdReader.exe",
        ".\x64\Debug\IdReader.pdb"
    )

    $VehicleIdReaderComFiles = @(
        # debug-x64|debug-x86
        ".\Debug\eVehicleRegistrationAPI.dll",
        ".\Debug\VehicleIdReader.exe",
        ".\Debug\VehicleIdReader.pdb"
    )
}

if ($Configuartion -eq "Debug" -And $Platform -eq "x86") {
    $IdReaderComFiles = @(
        # debug-x86
        ".\Debug\CelikApi.dll",
        ".\Debug\IdReader.exe",
        ".\Debug\IdReader.pdb"
    )

    $VehicleIdReaderComFiles = @(
        # debug-x64|debug-x86
        ".\Debug\eVehicleRegistrationAPI.dll",
        ".\Debug\VehicleIdReader.exe",
        ".\Debug\VehicleIdReader.pdb"
    )
}

if ($Configuartion -eq "Release" -And $Platform -eq "x64") {
    $IdReaderComFiles = @(
        # release-x64
        ".\x64\Release\CelikApi.dll",
        ".\x64\Release\IdReader.exe",
        ".\x64\Release\IdReader.pdb"
    )

    $VehicleIdReaderComFiles = @(
        # release-x64|release-x86
        ".\Release\eVehicleRegistrationAPI.dll",
        ".\Release\VehicleIdReader.exe",
        ".\Release\VehicleIdReader.pdb"
    )
}

if ($Configuartion -eq "Release" -And $Platform -eq "x86") {
    $IdReaderComFiles = @(
        # release-x86
        ".\Release\CelikApi.dll",
        ".\Release\IdReader.exe",
        ".\Release\IdReader.pdb"
    )

    $VehicleIdReaderComFiles = @(
        # release-x64|release-x86
        ".\Release\eVehicleRegistrationAPI.dll",
        ".\Release\VehicleIdReader.exe",
        ".\Release\VehicleIdReader.pdb"
    )
}

$ComRegistrationFiles = @(
    ".\Scripts\reg.cmd",
    ".\Scripts\unreg.cmd",
    ".\Scripts\reg.ps1",
    ".\Scripts\unreg.ps1"
)

Write-Host "###### Prepare Build ######"

& $msbuild .\CardReader.sln "/t:Clean;Restore"

Write-Host "###### Building IdReader ######"

& $msbuild .\CardReader.sln "/t:IdReader:Rebuild" "/p:Configuration=$Configuartion;Platform=$Platform"

Write-Host "###### Building VehicleIdReader ######"

& $msbuild .\CardReader.sln "/t:VehicleIdReader:Rebuild" "/p:Configuration=$Configuartion;Platform=$Platform"

Write-Host "###### Building CardReader ######"

& $msbuild .\CardReader.sln "/t:CardReader:Rebuild" "/p:Configuration=$Configuartion;Platform=$Platform;AppxPackageDir=$AppxPackageDir;UapAppxPackageBuildMode=SideloadOnly;AppxBundle=Auto;GenerateAppxPackageOnBuild=true"

Write-Host "###### Copy Files ######"

if (!(Test-Path -Path $DestDir)) {
    New-Item -Path $DestDir -ItemType Directory | Out-Null
}

if (!(Test-Path -Path $ComDir)) {
    New-Item -Path $ComDir -ItemType Directory | Out-Null
}

Copy-Item -Path $IdReaderComFiles -Destination "$ComDir" -Force
Copy-Item -Path $VehicleIdReaderComFiles -Destination "$ComDir" -Force
Copy-Item -Path $ComRegistrationFiles -Destination "$ComDir" -Force
Copy-Item -Path ".\CardReader\$AppxPackageDir" -Destination $DestDir -Recurse -Force
Copy-Item -Path ".\README.md" -Destination $DestDir -Force

Write-Host "###### Compress Files ######"

Compress-Archive -Path "$DestDir\*" -DestinationPath "$DestDir.zip"
