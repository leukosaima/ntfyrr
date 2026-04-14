FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine@sha256:16fcd544bb71edae6abee5b2ea25bc5f372734f18568d81c64ebac74d6f00239 AS build
WORKDIR /app

COPY ./src ./

RUN dotnet restore

RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine@sha256:2a80ec9b84fed7ede84708e3e366a56b9790bbf7978e875a31bc01ae80689534 AS runtime
WORKDIR /app

COPY --from=build /app/out .

RUN addgroup -S appgroup && adduser -S appuser -G appgroup
USER appuser

ENTRYPOINT ["dotnet", "ntfyrr.dll"]
