@echo off
REM Script para ejecutar el pipeline de CI localmente en Windows
REM Ejecutar: build-local.cmd

echo.
echo === AlohaPDF - Local CI Build ===
echo.

REM Step 1: Restore
echo [1/4] Restoring dependencies...
dotnet restore
if %ERRORLEVEL% neq 0 (
    echo ERROR: Failed to restore dependencies
    exit /b %ERRORLEVEL%
)
echo OK: Dependencies restored
echo.

REM Step 2: Build
echo [2/4] Building solution...
dotnet build --configuration Release --no-restore
if %ERRORLEVEL% neq 0 (
    echo ERROR: Build failed
    exit /b %ERRORLEVEL%
)
echo OK: Build successful
echo.

REM Step 3: Test
echo [3/4] Running tests...
dotnet test --configuration Release --no-build --verbosity normal --collect:"XPlat Code Coverage" --results-directory ./coverage
if %ERRORLEVEL% neq 0 (
    echo ERROR: Tests failed
    exit /b %ERRORLEVEL%
)
echo OK: All tests passed
echo.

REM Step 4: Pack
echo [4/4] Packing NuGet package...
dotnet pack src/AlohaPDF/AlohaPDF.csproj --configuration Release --no-build --output ./artifacts
if %ERRORLEVEL% neq 0 (
    echo ERROR: Pack failed
    exit /b %ERRORLEVEL%
)
echo OK: NuGet package created
echo.

echo ===================================
echo SUCCESS: Local build completed!
echo.
echo Artifacts:
echo   - NuGet package: .\artifacts\
echo   - Coverage reports: .\coverage\
echo.
pause
