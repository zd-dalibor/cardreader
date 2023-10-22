@echo off

SET SCRIPT_DIR=%~dp0

::
:: Available modes:
::    UnregServer        - unrersgister local server
::    RegServer          - regiser local server
::    UnregServerPerUser - unregister local server per user
::    RegServerPerUser   - register local server per user
::
SET MODE=UnregServerPerUser

SET SERVER1=%SCRIPT_DIR%\IdReader.exe
for %%i in ("%SERVER1%") do SET "SERVER1=%%~fi"

SET SERVER2=%SCRIPT_DIR%\VehicleIdReader.exe
for %%i in ("%SERVER2%") do SET "SERVER2=%%~fi"

"%SERVER1%" /%MODE%
echo %ErrorLevel%

"%SERVER2%" /%MODE%
echo %ErrorLevel%
