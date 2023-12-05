#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ReceiveMessageAoT/ReceiveMessageAoT.csproj", "ReceiveMessageAoT/"]
RUN dotnet restore "ReceiveMessageAoT/ReceiveMessageAoT.csproj"
COPY . .
WORKDIR "/src/ReceiveMessageAoT"
RUN dotnet build "ReceiveMessageAoT.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReceiveMessageAoT.csproj" -c Release -o /app/publish -r linux-arm64 --self-contained false /p:UseAppHost=false /p:PublishReadyToRun=true /p:PublishTrimmed=true /p:PublishSingleFile=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReceiveMessageAoT.dll"]