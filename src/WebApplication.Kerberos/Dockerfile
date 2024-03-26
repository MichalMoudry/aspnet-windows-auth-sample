FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApplication.Kerberos/WebApplication.Kerberos.csproj", "WebApplication.Kerberos/"]
RUN dotnet restore "./WebApplication.Kerberos/WebApplication.Kerberos.csproj"
COPY . .
WORKDIR "/src/WebApplication.Kerberos"
RUN dotnet build "./WebApplication.Kerberos.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApplication.Kerberos.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
USER root
RUN apt-get update
RUN apt-get -y install libgssapi-krb5-2

USER $APP_UID
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication.Kerberos.dll"]