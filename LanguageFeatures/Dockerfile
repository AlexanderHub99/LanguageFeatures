FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LanguageFeatures/LanguageFeatures.csproj", "LanguageFeatures/"]
RUN dotnet restore "LanguageFeatures/LanguageFeatures.csproj"
COPY . .
WORKDIR "/src/LanguageFeatures"
RUN dotnet build "LanguageFeatures.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LanguageFeatures.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LanguageFeatures.dll"]
