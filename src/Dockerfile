FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["server/GhostProject.App/GhostProject.App.Web/GhostProject.App.Web.csproj", "server/GhostProject.App/GhostProject.App.Web/"]
RUN dotnet restore "server/GhostProject.App/GhostProject.App.Web/GhostProject.App.Web.csproj"
COPY . .
WORKDIR "/src/server/GhostProject.App/GhostProject.App.Web"
RUN dotnet build "GhostProject.App.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GhostProject.App.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GhostProject.App.Web.dll"]