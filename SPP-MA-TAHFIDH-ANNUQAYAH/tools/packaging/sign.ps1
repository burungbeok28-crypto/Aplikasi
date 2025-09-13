# PowerShell script for signing the application package

# This script is intended to sign the application package for SPP-MA-TAHFIDH-ANNUQAYAH.
# Ensure that you have the necessary certificates and tools installed to perform the signing.

param (
    [string]$packagePath,
    [string]$certificatePath,
    [string]$certificatePassword
)

function Sign-Package {
    param (
        [string]$package,
        [string]$certPath,
        [string]$certPassword
    )

    if (-Not (Test-Path $package)) {
        Write-Host "Package not found: $package"
        return
    }

    if (-Not (Test-Path $certPath)) {
        Write-Host "Certificate not found: $certPath"
        return
    }

    $cert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2
    $cert.Import($certPath, $certPassword, [System.Security.Cryptography.X509Certificates.X509KeyStorageFlags]::Exportable)

    try {
        $signToolPath = "C:\Path\To\signtool.exe" # Update this path to your signtool.exe location
        $arguments = "sign /f `"$certPath`" /p `"$certificatePassword`" `"$package`""
        Start-Process -FilePath $signToolPath -ArgumentList $arguments -Wait -NoNewWindow
        Write-Host "Package signed successfully: $package"
    } catch {
        Write-Host "Error signing package: $_"
    }
}

Sign-Package -package $packagePath -certPath $certificatePath -certPassword $certificatePassword