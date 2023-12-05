#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
# Install clang/zlib1g-dev dependencies for publishing to native
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    clang zlib1g-dev
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WriteLogAoTDotNet7/WriteLogAoTDotNet7.csproj", "WriteLogAoTDotNet7/"]
RUN dotnet restore "./WriteLogAoTDotNet7/./WriteLogAoTDotNet7.csproj"
COPY . .
WORKDIR "/src/WriteLogAoTDotNet7"
RUN dotnet build "./WriteLogAoTDotNet7.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WriteLogAoTDotNet7.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=true

FROM mcr.microsoft.com/dotnet/runtime-deps:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./WriteLogAoTDotNet7"]