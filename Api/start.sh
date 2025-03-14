#!/bin/bash

set -e

dotnet tool restore || dotnet tool install --global dotnet-ef
dotnet add ./dotnet-api.csproj package Swashbuckle.AspNetCore
dotnet restore ./dotnet-api.csproj
dotnet build ./dotnet-api.csproj
dotnet ef database update --context RepoPatternDbContext

dotnet run --project ./dotnet-api.csproj