#!/bin/bash

# Build the SPP-MA-TAHFIDH-ANNUQAYAH application for both 32-bit and 64-bit architectures

# Define the solution and project files
SOLUTION_FILE="../SPP-MA-TAHFIDH-ANNUQAYAH.sln"
BUILD_DIR="../build"

# Function to build the application
build_application() {
    local architecture=$1
    echo "Building for $architecture..."
    
    if [ "$architecture" == "x86" ]; then
        dotnet build "$SOLUTION_FILE" -c Release -r win-x86
    elif [ "$architecture" == "x64" ]; then
        dotnet build "$SOLUTION_FILE" -c Release -r win-x64
    else
        echo "Unsupported architecture: $architecture"
        exit 1
    fi

    if [ $? -eq 0 ]; then
        echo "Build for $architecture completed successfully."
    else
        echo "Build for $architecture failed."
        exit 1
    fi
}

# Build for both architectures
build_application "x86"
build_application "x64"

echo "All builds completed."