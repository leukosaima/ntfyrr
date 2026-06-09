FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine@sha256:4fdf1efc2eedaf10b7f42cc7584f71d429dc85bafce662113048bfbaaea5970e AS build
WORKDIR /app

COPY ./src ./

RUN dotnet restore

RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine@sha256:6327ae0927b5623617cf8437302e3f2700f01898e86bba60ec2e0971ce7c3add AS runtime
WORKDIR /app

COPY --from=build /app/out .

RUN addgroup -S appgroup && adduser -S appuser -G appgroup
USER appuser

ENTRYPOINT ["dotnet", "ntfyrr.dll"]
