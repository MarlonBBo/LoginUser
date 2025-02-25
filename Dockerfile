# Base para execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=http://+:80

# Build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LoginUser/LoginUser.csproj", "LoginUser/"]
RUN dotnet restore "./LoginUser/LoginUser.csproj"
COPY . .
WORKDIR "/src/LoginUser"
RUN dotnet build "./LoginUser.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LoginUser.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Container final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoginUser.dll"]
