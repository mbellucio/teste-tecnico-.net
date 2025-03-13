FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["*.csproj", "."]
RUN dotnet restore
COPY . .
WORKDIR "/src/."
RUN dotnet build "dotnet-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotnet-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=publish /app/publish .
COPY aspnetcore.crt /https/aspnetcore.crt
ENTRYPOINT ["dotnet", "dotnet-api.dll"]