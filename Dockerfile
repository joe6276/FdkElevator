FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy just the project file first (better layer caching)
COPY FdkElevator/FdkElevator.csproj FdkElevator/
RUN dotnet restore FdkElevator/FdkElevator.csproj

# Copy everything else and build
COPY FdkElevator/ FdkElevator/
WORKDIR /src/FdkElevator
RUN dotnet publish -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app .
EXPOSE 8080
ENTRYPOINT ["dotnet", "FdkElevator.dll"]