#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["server/GhostProject.App/GhostProject.App.Web/GhostProject.App.Web.csproj", "server/GhostProject.App/GhostProject.App.Web/"]
RUN dotnet restore "GhostProject.App.Web/GhostProject.App.Web.csproj"
COPY . .
WORKDIR "/src/GhostProject.App.Web"
RUN dotnet build "GhostProject.App.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GhostProject.App.Web.csproj" -c Release -o /app/publish	

FROM base AS final
