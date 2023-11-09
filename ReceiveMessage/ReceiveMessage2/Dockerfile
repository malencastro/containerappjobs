#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ReceiveMessage2/ReceiveMessage2.csproj", "ReceiveMessage2/"]
RUN dotnet restore "ReceiveMessage2/ReceiveMessage2.csproj"
COPY . .
WORKDIR "/src/ReceiveMessage2"
RUN dotnet build "ReceiveMessage2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReceiveMessage2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReceiveMessage2.dll"]