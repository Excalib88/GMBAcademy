FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/backend/GMBAcademy.Web/GMBAcademy.Web.csproj", "src/backend/GMBAcademy.Web/"]
RUN dotnet restore "src/backend/GMBAcademy.Web/GMBAcademy.Web.csproj"
COPY . .
WORKDIR "/src/src/backend/GMBAcademy.Web"
RUN dotnet build "GMBAcademy.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "GMBAcademy.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GMBAcademy.Web.dll"]