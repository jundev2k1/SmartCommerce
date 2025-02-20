#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Manager/SmartCommerce.Manager.csproj", "Manager/"]
COPY ["Common/Common/SmartCommerce.Common.csproj", "Common/Common/"]
COPY ["Common/Domain/SmartCommerce.Domain.csproj", "Common/Domain/"]
COPY ["Common/Infrastructure/SmartCommerce.Infrastructure.csproj", "Common/Infrastructure/"]
COPY ["Common/Persistence/SmartCommerce.Persistence.csproj", "Common/Persistence/"]
RUN dotnet restore "./Manager/SmartCommerce.Manager.csproj"
COPY . .
WORKDIR "/src/Manager"
RUN dotnet build "./SmartCommerce.Manager.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SmartCommerce.Manager.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartCommerce.Manager.dll"]