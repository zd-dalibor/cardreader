$Configuration = 'Debug'
$ScriptDir = Split-Path -Parent $PSCommandPath
<#
Available modes:
    UnregServer        - unrersgister local server
    RegServer          - regiser local server
    UnregServerPerUser - unregister local server per user
    RegServerPerUser   - register local server per user
#>
$Mode = 'RegServerPerUser'

$Server = Join-Path "$ScriptDir" "..\$Configuration\DriverLicenseReader.exe" | Resolve-Path
& $Server /$Mode 2>&1
Write-Host $LASTEXITCODE