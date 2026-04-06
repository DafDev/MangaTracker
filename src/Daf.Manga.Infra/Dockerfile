FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Daf.Manga.Infra/Daf.Manga.Infra.csproj", "src/Daf.Manga.Infra/"]
RUN dotnet restore "src/Daf.Manga.Infra/Daf.Manga.Infra.csproj"
COPY . .
WORKDIR "/src/src/Daf.Manga.Infra"
RUN dotnet build "./Daf.Manga.Infra.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Daf.Manga.Infra.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Daf.Manga.Infra.dll"]
