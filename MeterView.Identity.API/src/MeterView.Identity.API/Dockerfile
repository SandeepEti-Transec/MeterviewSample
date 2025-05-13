FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ["MeterView.Identity.API/src/MeterView.Identity.API/MeterView.Identity.API.csproj", "./MeterView.Identity.API/src/MeterView.Identity.API/"]
COPY ["SharedKernel/SharedKernel.csproj", "./SharedKernel/"]
RUN dotnet restore "./MeterView.Identity.API/src/MeterView.Identity.API/MeterView.Identity.API.csproj"

# Copy everything else and build
COPY . ./
RUN dotnet build "MeterView.Identity.API/src/MeterView.Identity.API/MeterView.Identity.API.csproj" -c Release -o /app/build

FROM build-env AS publish
RUN dotnet publish "MeterView.Identity.API/src/MeterView.Identity.API/MeterView.Identity.API.csproj" -c Release -o /app/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=publish /app/out .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/MeterView.Identity.API.dll"]
