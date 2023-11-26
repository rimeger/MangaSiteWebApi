#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Manga.WebAPI/Manga.WebAPI.csproj", "src/Manga.WebAPI/"]
COPY ["src/Manga.Infrastructure/Manga.Infrastructure.csproj", "src/Manga.Infrastructure/"]
COPY ["src/Manga.Application/Manga.Application.csproj", "src/Manga.Application/"]
COPY ["src/Manga.Domain/Manga.Domain.csproj", "src/Manga.Domain/"]
RUN dotnet restore "./src/Manga.WebAPI/./Manga.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/Manga.WebAPI"
RUN dotnet build "./Manga.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "./Manga.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Manga.WebAPI.dll"]