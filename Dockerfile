FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine@sha256:d8ee39817ca03a3757288e83c37ed73cc969a286c603b827c7cbe33add1c2d1c AS build
WORKDIR /app

COPY ./src ./

RUN dotnet restore

RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine@sha256:27b6b84beeede74fd16886177d360799c8e4299ceadfbd64eef57bafead7878a AS runtime
WORKDIR /app

COPY --from=build /app/out .

RUN addgroup -S appgroup && adduser -S appuser -G appgroup
USER appuser

ENTRYPOINT ["dotnet", "ntfyrr.dll"]
