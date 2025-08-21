FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HorizonCalender.Data.Migrator/HorizonCalender.Data.Migrator.csproj", "HorizonCalender.Data.Migrator/"]
COPY ["HorizonCalender.ServiceDefaults/HorizonCalender.ServiceDefaults.csproj", "HorizonCalender.ServiceDefaults/"]
COPY ["HorizonCalender.Data/HorizonCalender.Data.csproj", "HorizonCalender.Data/"]
RUN dotnet restore "HorizonCalender.Data.Migrator/HorizonCalender.Data.Migrator.csproj"
COPY . .
WORKDIR "/src/HorizonCalender.Data.Migrator"
RUN dotnet build "./HorizonCalender.Data.Migrator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HorizonCalender.Data.Migrator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HorizonCalender.Data.Migrator.dll"]
