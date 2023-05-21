#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443
COPY . ./
RUN dotnet restore "GhostProject.App.Web/GhostProject.App.Web.csproj"
RUN dotnet build "GhostProject.App.Web/GhostProject.App.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GhostProject.App.Web/GhostProject.App.Web.csproj" -c Release -o /app/publish	

FROM base AS final
