FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["BookHistory.App/BookHistory.App.csproj", "BookHistory.App/"]
RUN dotnet restore "BookHistory.App/BookHistory.App.csproj"
COPY . .
WORKDIR "/src/BookHistory.App"
RUN dotnet build "BookHistory.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookHistory.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookHistory.App.dll"]
