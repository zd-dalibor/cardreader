$ScriptDir = Split-Path -Parent $PSCommandPath
<#
Available modes:
    UnregServer        - unrersgister local server
    RegServer          - regiser local server
    UnregServerPerUser - unregister local server per user
    RegServerPerUser   - register local server per user
#>
$Mode = 'UnregServerPerUser'

$Server1 = Join-Path "$ScriptDir" "IdReader.exe" | Resolve-Path
$Server2 = Join-Path "$ScriptDir" "VehicleIdReader.exe" | Resolve-Path

& $Server1 /$Mode 2>&1
Write-Host $LASTEXITCODE

& $Server2 /$Mode 2>&1
Write-Host $LASTEXITCODE
