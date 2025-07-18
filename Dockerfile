FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /App

# Instala herramientas necesarias para AOT
RUN apt-get update && apt-get install -y clang zlib1g-dev

COPY . .
RUN cd EventLog.API
RUN dotnet restore --disable-parallel
RUN dotnet publish -c Release -o /App/out \
    --no-restore \
    --runtime linux-x64 \
    -p:PublishAot=true \
    -p:PublishReadyToRun=true

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /App
COPY --from=build-env /App/out .

RUN chmod +x EventLog.API

EXPOSE 80
ENV ASPNETCORE_HTTP_PORTS=80

ENTRYPOINT ["./EventLog.API"]
