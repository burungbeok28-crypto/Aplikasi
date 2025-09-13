# BUILD_WINDOWS.md

# Building the SPP-MA-TAHFIDH-ANNUQAYAH Application on Windows

This document provides instructions for building the SPP-MA-TAHFIDH-ANNUQAYAH application on Windows platforms, compatible with Windows 7 through Windows 11.

## Prerequisites

1. **.NET SDK**: Ensure that you have the .NET SDK installed. You can download it from the [.NET website](https://dotnet.microsoft.com/download).
2. **Visual Studio**: It is recommended to use Visual Studio 2019 or later with the .NET desktop development workload installed.
3. **Inno Setup**: For creating installers, download and install Inno Setup from [here](http://www.jrsoftware.org/isinfo.php).
4. **WiX Toolset**: For creating MSI installers, download and install the WiX Toolset from [here](https://wixtoolset.org/).

## Building the Application

### Step 1: Clone the Repository

Clone the repository to your local machine using Git:

```bash
git clone <repository-url>
cd SPP-MA-TAHFIDH-ANNUQAYAH
```

### Step 2: Restore Dependencies

Navigate to the `src/SPP.App` directory and restore the project dependencies:

```bash
cd src/SPP.App
dotnet restore
```

### Step 3: Build the Application

To build the application for both 32-bit and 64-bit architectures, run the following commands:

#### For 32-bit Build

```bash
dotnet build -c Release -r win-x86
```

#### For 64-bit Build

```bash
dotnet build -c Release -r win-x64
```

### Step 4: Create Installers

#### Using Inno Setup

1. Navigate to the `installers/inno-setup` directory.
2. Open the `installer.iss` file in Inno Setup and customize it as needed.
3. Compile the script to create the installer.

#### Using WiX Toolset

1. Navigate to the `installers/wix` directory.
2. Open the `Product.wxs` file and customize it as needed.
3. Use the WiX command line tools to build the MSI package.

## Running the Application

After building the application, you can run it directly from the output directory or use the installer created in the previous step to install it on your system.

## Troubleshooting

- Ensure that all prerequisites are installed correctly.
- Check for any build errors in the output window of Visual Studio or the command line.
- If you encounter issues with the installer, verify the configuration files for any discrepancies.

## Conclusion

You have successfully built the SPP-MA-TAHFIDH-ANNUQAYAH application on Windows. For further assistance, refer to the documentation in the `docs` directory or contact the development team.