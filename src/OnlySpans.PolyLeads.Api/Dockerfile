FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

LABEL APP="OnlySpans.PolyLeads.Api"
LABEL REPO="https://github.com/OnlySpans/PolyLeads"
LABEL VERSION="$VERSION"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/OnlySpans.PolyLeads.Api/OnlySpans.PolyLeads.Api.csproj", "src/OnlySpans.PolyLeads.Api/"]
COPY ["src/OnlySpans.PolyLeads.Dto/OnlySpans.PolyLeads.Dto.csproj", "src/OnlySpans.PolyLeads.Dto/"]
RUN dotnet restore "src/OnlySpans.PolyLeads.Api/OnlySpans.PolyLeads.Api.csproj"
COPY . .
WORKDIR "/src/src/OnlySpans.PolyLeads.Api"
RUN dotnet build "OnlySpans.PolyLeads.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "OnlySpans.PolyLeads.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlySpans.PolyLeads.Api.dll"]
