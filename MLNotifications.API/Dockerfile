#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MLNotifications.API/MLNotifications.API.csproj", "MLNotifications.API/"]
COPY ["MLNotifications.Infra.Data/MLNotifications.Infra.Data.csproj", "MLNotifications.Infra.Data/"]
COPY ["MLNotifications.Domain/MLNotifications.Domain.csproj", "MLNotifications.Domain/"]
COPY ["MLNotifications.Application/MLNotifications.Application.csproj", "MLNotifications.Application/"]
RUN dotnet restore "MLNotifications.API/MLNotifications.API.csproj"
COPY . .
WORKDIR "/src/MLNotifications.API"
RUN dotnet build "MLNotifications.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MLNotifications.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MLNotifications.API.dll"]