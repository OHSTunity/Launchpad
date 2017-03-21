@ECHO OFF

IF "%CONFIGURATION%"=="" SET CONFIGURATION=Debug

star --resourcedir="%~dp0src\Launchpad\wwwroot" "%~dp0src\Launchpad\bin\%CONFIGURATION%\Launchpad.exe"
