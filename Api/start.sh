#!/bin/bash
set -e
dotnet tool restore || dotnet tool install --global dotnet-ef
dotnet add ./dotnet-api.csproj package Swashbuckle.AspNetCore
dotnet add ./dotnet-api.csproj package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add ./dotnet-api.csproj package System.IdentityModel.Tokens.Jwt
dotnet restore ./dotnet-api.csproj
dotnet build ./dotnet-api.csproj
dotnet ef database update --context RepoPatternDbContext
dotnet run --project ./dotnet-api.csproj