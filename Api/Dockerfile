# Use the SDK image for build and migrations
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["*.csproj", "."]
RUN dotnet restore

COPY . . 
RUN dotnet build "dotnet-api.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "dotnet-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final image with runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=publish /app/publish . 

# ENTRYPOINT to run the application
ENTRYPOINT ["dotnet", "dotnet-api.dll"]