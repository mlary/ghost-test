#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
ARG GITHUB_ACCOUNT_USERNAME=local
ENV GITHUB_ACCOUNT_USERNAME ${GITHUB_ACCOUNT_USERNAME}
COPY ["GhostProject.App.Web/GhostProject.App.Web.csproj", "nuget.config", "GhostProject.App.Web/"]
RUN dotnet restore "GhostProject.App.Web/GhostProject.App.Web.csproj"
COPY . .
WORKDIR "/src/GhostProject.App.Web"
RUN dotnet build "GhostProject.App.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GhostProject.App.Web.csproj" -c Release -o /app/publish

FROM base AS final
# Install the New Relic agent
RUN apt-get update && apt-get install -y wget ca-certificates gnupg \
&& echo 'deb http://apt.newrelic.com/debian/ newrelic non-free' | tee /etc/apt/sources.list.d/newrelic.list \
&& wget https://download.newrelic.com/548C16BF.gpg \
&& apt-key add 548C16BF.gpg \
&& apt-get update \
&& apt-get install -y newrelic-netcore20-agent

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GhostProject.App.Web.dll"]
