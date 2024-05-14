FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

LABEL APP="OnlySpans.PolyLeads.Api"
LABEL REPO="https://github.com/OnlySpans/PolyLeads"
LABEL VERSION="$VERSION"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/OnlySpans.PolyLeads.ReverseProxy/OnlySpans.PolyLeads.ReverseProxy.csproj", "src/OnlySpans.PolyLeads.ReverseProxy/"]
RUN dotnet restore "src/OnlySpans.PolyLeads.ReverseProxy/OnlySpans.PolyLeads.ReverseProxy.csproj"
COPY . .
WORKDIR "/src/src/OnlySpans.PolyLeads.ReverseProxy"
RUN dotnet build "OnlySpans.PolyLeads.ReverseProxy.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "OnlySpans.PolyLeads.ReverseProxy.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlySpans.PolyLeads.ReverseProxy.dll"]
