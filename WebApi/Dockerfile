FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

RUN apt update
RUN apt-get -y install clang zlib1g-dev

WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish --self-contained -c Release -o out /p:PublishAot=true /p:StripSymbols=true

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["./WebApi"]