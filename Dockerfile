FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV TZ=America/Sao_Paulo
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["HealthCheck.Appointments.API/HealthCheck.Appointments.API.csproj", "HealthCheck.Appointments.API/"]
COPY ["HealthCheck.Appointments.Application/HealthCheck.Appointments.Application.csproj", "HealthCheck.Appointments.Application/"]
COPY ["HealthCheck.Appointments.Domain/HealthCheck.Appointments.Domain.csproj", "HealthCheck.Appointments.Domain/"]
COPY ["HealthCheck.Appointments.Infrastructure/HealthCheck.Appointments.Infrastructure.csproj", "HealthCheck.Appointments.Infrastructure/"]
COPY ["HealthCheck.Appointments.IOC/HealthCheck.Appointments.IOC.csproj", "HealthCheck.Appointments.IOC/"]
RUN dotnet restore "HealthCheck.Appointments.API/HealthCheck.Appointments.API.csproj"
COPY . .
WORKDIR "/src/HealthCheck.Appointments.API"
RUN dotnet build "HealthCheck.Appointments.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HealthCheck.Appointments.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HealthCheck.Appointments.API.dll"]