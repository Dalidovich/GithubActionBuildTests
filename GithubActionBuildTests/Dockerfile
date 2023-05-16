#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ENV TestValues__Value1="I am on gcp1"
WORKDIR /src
COPY ["GithubActionBuildTests/GithubActionBuildTests.csproj", "GithubActionBuildTests/"]
COPY ["GithubActionBuildTests.Domain/GithubActionBuildTests.Domain.csproj", "GithubActionBuildTests.Domain/"]
RUN dotnet restore "GithubActionBuildTests/GithubActionBuildTests.csproj"
COPY . .
WORKDIR "/src/GithubActionBuildTests"
RUN dotnet build "GithubActionBuildTests.csproj" -c Release -o /app/build

FROM build AS publish
ENV TestValues__Value1="I am on gcp2"
RUN dotnet publish "GithubActionBuildTests.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
ENV TestValues__Value1="I am on gcp3"
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GithubActionBuildTests.dll"]