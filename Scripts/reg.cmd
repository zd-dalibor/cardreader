@echo off

SET CONFIGURATION=Debug
SET SCRIPT_DIR=%~dp0

::
:: Available modes:
::    UnregServer        - unrersgister local server
::    RegServer          - regiser local server
::    UnregServerPerUser - unregister local server per user
::    RegServerPerUser   - register local server per user
::
SET MODE=RegServerPerUser

SET SERVER=%SCRIPT_DIR%..\%CONFIGURATION%\VehicleIdReader.exe
for %%i in ("%SERVER%") do SET "SERVER=%%~fi"

"%SERVER%" /%MODE%
echo %ErrorLevel%