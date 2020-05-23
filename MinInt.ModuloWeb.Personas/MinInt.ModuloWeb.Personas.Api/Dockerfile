#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MinInt.ModuloWeb.Personas.Api/MinInt.ModuloWeb.Personas.Api.csproj", "MinInt.ModuloWeb.Personas.Api/"]
COPY ["MinInt.ModuloWeb.Personas.EventHandlers/MinInt.ModuloWeb.Personas.EventHandlers.csproj", "MinInt.ModuloWeb.Personas.EventHandlers/"]
COPY ["MinInt.ModuloWeb.Personas.CrossCutting/MinInt.ModuloWeb.Personas.CrossCutting.csproj", "MinInt.ModuloWeb.Personas.CrossCutting/"]
COPY ["MinInt.ModuloWeb.Personas.Queries/MinInt.ModuloWeb.Personas.Queries.csproj", "MinInt.ModuloWeb.Personas.Queries/"]
COPY ["MinInt.ModuloWeb.Personas.Utilities/MinInt.ModuloWeb.Personas.Utilities.csproj", "MinInt.ModuloWeb.Personas.Utilities/"]
COPY ["MinInt.ModuloWeb.Personas.Persistence.Database/MinInt.ModuloWeb.Personas.Persistence.Database.csproj", "MinInt.ModuloWeb.Personas.Persistence.Database/"]
COPY ["MinInt.ModuloWeb.Personas.Domain/MinInt.ModuloWeb.Personas.Domain.csproj", "MinInt.ModuloWeb.Personas.Domain/"]
RUN dotnet restore "MinInt.ModuloWeb.Personas.Api/MinInt.ModuloWeb.Personas.Api.csproj"
COPY . .
WORKDIR "/src/MinInt.ModuloWeb.Personas.Api"
RUN dotnet build "MinInt.ModuloWeb.Personas.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MinInt.ModuloWeb.Personas.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MinInt.ModuloWeb.Personas.Api.dll"]