#!/bin/bash

# Solution's path
SOLUTION_DIR=$(pwd)

# Base namespace for all projects
COMMON_NAMESPACE="DecisionTree.Plugins.SimpleCMS"

# Dist folder, to store only the DLLs related to this plugin
DIST_DIR="$SOLUTION_DIR/dist"
mkdir -p "$DIST_DIR"

# Define the suffixes for projects to be built
declare -a PROJECT_SUFFIXES=(
    ".Web"
    ".EntityFrameworkCore"
    ".MongoDB"
    ".HttpApi"
    ".Application"
)

# Compiles the specified projects and copies their DLLs to the dist folder.
for SUFFIX in "${PROJECT_SUFFIXES[@]}"; do
    # Finds project files that match the pattern in the src directory
    for CSPROJ in $(find src -type f -name "*$SUFFIX.csproj"); do
        # Extracts the project name
        PROJECT_NAME=$(basename "$CSPROJ" ".csproj")
        echo "Building project $PROJECT_NAME"

        # Determines the output directory based on the project suffix
        OUTPUT_DIR="$DIST_DIR"
        SPECIAL_CASE=false
        if [[ "$SUFFIX" == ".EntityFrameworkCore" ]]; then
            OUTPUT_DIR="$DIST_DIR/EntityFrameworkCore"
            SPECIAL_CASE=true
        elif [[ "$SUFFIX" == ".MongoDB" ]]; then
            OUTPUT_DIR="$DIST_DIR/Mongo"
            SPECIAL_CASE=true
        fi
        mkdir -p "$OUTPUT_DIR"
        
        # Builds the project
        dotnet build "$CSPROJ" -c Release -o "$OUTPUT_DIR"

        # For special cases, copy only the DLL that matches the project name
        if [[ "$SPECIAL_CASE" == true ]]; then
            find "$OUTPUT_DIR" -maxdepth 1 -type f -name "${PROJECT_NAME}.dll" -exec cp '{}' "$OUTPUT_DIR" \;
            # Remove other files that are not the DLLs we want to keep
            find "$OUTPUT_DIR" -maxdepth 1 -type f ! -name "${PROJECT_NAME}.dll" -exec rm '{}' \;
        else
            # For non-special cases, make sure we're not removing DLLs that should be there
            find "$OUTPUT_DIR" -maxdepth 1 -type f ! -name "${COMMON_NAMESPACE}*.dll" -exec rm '{}' \;
        fi
    done
done

echo "Build finished. Files copied to dist folder."
