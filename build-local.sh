#!/bin/bash
# Script para ejecutar el pipeline de CI localmente
# Ejecutar: chmod +x build-local.sh && ./build-local.sh

set -e  # Exit on error

echo "🌺 AlohaPDF - Local CI Build"
echo "=============================="
echo ""

# Colors
GREEN='\033[0;32m'
BLUE='\033[0;34m'
RED='\033[0;31m'
NC='\033[0m' # No Color

# Step 1: Restore
echo -e "${BLUE}📦 Restoring dependencies...${NC}"
dotnet restore
echo -e "${GREEN}✓ Dependencies restored${NC}"
echo ""

# Step 2: Build
echo -e "${BLUE}🔨 Building solution...${NC}"
dotnet build --configuration Release --no-restore
echo -e "${GREEN}✓ Build successful${NC}"
echo ""

# Step 3: Test
echo -e "${BLUE}🧪 Running tests...${NC}"
dotnet test --configuration Release --no-build --verbosity normal --collect:"XPlat Code Coverage" --results-directory ./coverage
echo -e "${GREEN}✓ All tests passed${NC}"
echo ""

# Step 4: Pack
echo -e "${BLUE}📦 Packing NuGet package...${NC}"
dotnet pack src/AlohaPDF/AlohaPDF.csproj --configuration Release --no-build --output ./artifacts
echo -e "${GREEN}✓ NuGet package created${NC}"
echo ""

# Summary
echo "=============================="
echo -e "${GREEN}🎉 Local build completed successfully!${NC}"
echo ""
echo "Artifacts:"
echo "  • NuGet package: ./artifacts/"
echo "  • Coverage reports: ./coverage/"
echo ""
