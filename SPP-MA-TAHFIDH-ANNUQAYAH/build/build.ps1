# PowerShell script to build the SPP-MA-TAHFIDH-ANNUQAYAH application

# Define the solution and project paths
$solutionPath = "..\SPP-MA-TAHFIDH-ANNUQAYAH.sln"

# Define the output directories for 32-bit and 64-bit builds
$outputDir32 = "bin\32bit"
$outputDir64 = "bin\64bit"

# Create output directories if they do not exist
if (-Not (Test-Path $outputDir32)) {
    New-Item -ItemType Directory -Path $outputDir32
}
if (-Not (Test-Path $outputDir64)) {
    New-Item -ItemType Directory -Path $outputDir64
}

# Build the solution for 32-bit
Write-Host "Building 32-bit version..."
msbuild $solutionPath /p:Configuration=Release /p:Platform="x86" /p:OutputPath=$outputDir32

# Build the solution for 64-bit
Write-Host "Building 64-bit version..."
msbuild $solutionPath /p:Configuration=Release /p:Platform="x64" /p:OutputPath=$outputDir64

Write-Host "Build completed successfully!"