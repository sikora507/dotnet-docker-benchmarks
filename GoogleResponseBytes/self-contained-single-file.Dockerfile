FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -r linux-x64 --self-contained -c Release  -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:7.0-bullseye-slim-amd64
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "GoogleResponseBytes.dll"]