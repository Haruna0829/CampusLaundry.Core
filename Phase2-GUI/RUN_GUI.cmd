@echo off
cd /d "%~dp0"
where dotnet >nul 2>&1
if errorlevel 1 (
  echo Install the .NET 8 SDK for Windows, then run this file again.
  echo https://dotnet.microsoft.com/en-us/download/dotnet/8.0
  pause
  exit /b 1
)
dotnet run --project "CampusLaundry.WinForms\CampusLaundry.WinForms.csproj"
if errorlevel 1 (
  echo.
  echo The application could not start. Copy the error above for troubleshooting.
  pause
)
