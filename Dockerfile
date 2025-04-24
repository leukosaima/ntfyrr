FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
WORKDIR /app

COPY ./src ./

RUN dotnet restore

RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS runtime
WORKDIR /app

COPY --from=build /app/out .

RUN addgroup -S appgroup && adduser -S appuser -G appgroup
USER appuser

ENTRYPOINT ["dotnet", "ntfyrr.dll"]
