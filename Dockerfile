FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine@sha256:2b0e46d490f5b53a8dc07fbf636cdf5b90796878a256e1ce5b441e8d9675c5f4 AS build
WORKDIR /app

COPY ./src ./

RUN dotnet restore

RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine@sha256:49dce27611d8fe4fbe50483ea9438abd18ccb0198d0737af231335244d0c9b94 AS runtime
WORKDIR /app

COPY --from=build /app/out .

RUN addgroup -S appgroup && adduser -S appuser -G appgroup
USER appuser

ENTRYPOINT ["dotnet", "ntfyrr.dll"]
