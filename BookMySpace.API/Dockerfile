FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BookMySpace.API/BookMySpace.API.csproj", "BookMySpace.API/"]
RUN dotnet restore "BookMySpace.API/BookMySpace.API.csproj"
COPY . .
WORKDIR "/src/BookMySpace.API"
RUN dotnet build "BookMySpace.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookMySpace.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookMySpace.API.dll"]
