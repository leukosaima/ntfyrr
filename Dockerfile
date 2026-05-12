FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine@sha256:5c559aa5d99337e400d39ab4fa1f6979d126c29b20939d53658ed38300571e74 AS build
WORKDIR /app

COPY ./src ./

RUN dotnet restore

RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine@sha256:1e37a8236c558ae31bd6bc8144e38e6036b73cf1b0616fe56d79e60babb9d93b AS runtime
WORKDIR /app

COPY --from=build /app/out .

RUN addgroup -S appgroup && adduser -S appuser -G appgroup
USER appuser

ENTRYPOINT ["dotnet", "ntfyrr.dll"]
