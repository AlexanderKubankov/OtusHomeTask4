#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Api.Data.Migrations/Api.Data.Migrations.csproj", "Api.Data.Migrations/"]
COPY ["Api.Data/Api.Data.csproj", "Api.Data/"]
RUN dotnet restore "./Api.Data.Migrations/./Api.Data.Migrations.csproj"
COPY . .
WORKDIR "/src/Api.Data.Migrations"
RUN dotnet build "./Api.Data.Migrations.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Api.Data.Migrations.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.Data.Migrations.dll"]