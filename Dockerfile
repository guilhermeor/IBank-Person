FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build-env
WORKDIR /app
COPY . .
RUN dotnet build
RUN dotnet test
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/core/aspnet:5.0-alpine
WORKDIR /app
COPY --from=build-env /app/out/ ./
ENTRYPOINT ["dotnet", "ClientInfo.Api.dll"]