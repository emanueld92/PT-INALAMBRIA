#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Inalambria.Domino.Api/Inalambria.Domino.Api.csproj", "Inalambria.Domino.Api/"]
COPY ["Inalambria.Domino.ApplicationServices.Shared/Inalambria.Domino.ApplicationServices.Shared.csproj", "Inalambria.Domino.ApplicationServices.Shared/"]
COPY ["Inalambria.Domino.Core/Inalambria.Domino.Core.csproj", "Inalambria.Domino.Core/"]
COPY ["Inalambria.Domino.ApplicationServices/Inalambria.Domino.ApplicationServices.csproj", "Inalambria.Domino.ApplicationServices/"]
COPY ["Inalambria.Domino.EntityFramework/Inalambria.Domino.EntityFramework.csproj", "Inalambria.Domino.EntityFramework/"]
RUN dotnet restore "Inalambria.Domino.Api/Inalambria.Domino.Api.csproj"
COPY . .
WORKDIR "/src/Inalambria.Domino.Api"
RUN dotnet build "Inalambria.Domino.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Inalambria.Domino.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inalambria.Domino.Api.dll"]