# escape=`
ARG BASE
FROM mcr.microsoft.com/dotnet/sdk:6.0-nanoserver-${BASE} AS build

WORKDIR /src

COPY ["container-sysinfo.csproj", "."]
RUN dotnet restore "container-sysinfo.csproj"
COPY . ./

USER ContainerAdministrator
RUN dotnet build "container-sysinfo.csproj" -c Release -o /app/build
RUN dotnet publish "container-sysinfo.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0-nanoserver-${BASE} AS final
EXPOSE 80

WORKDIR /app
COPY --from=build /app/publish .

USER ContainerAdministrator
ENTRYPOINT ["dotnet", "container-sysinfo.dll"]