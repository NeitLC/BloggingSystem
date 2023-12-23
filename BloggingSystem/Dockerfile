FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BloggingSystem/BloggingSystem.csproj", "BloggingSystem/"]
COPY ["BloggingSystem.Domain/BloggingSystem.Domain.csproj", "BloggingSystem.Domain/"]
COPY ["BloggingSystem.Services/BloggingSystem.Services.csproj", "BloggingSystem.Services/"]
RUN dotnet restore "BloggingSystem/BloggingSystem.csproj"
COPY . .
WORKDIR "/src/BloggingSystem"
RUN dotnet build "BloggingSystem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BloggingSystem.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BloggingSystem.dll"]
