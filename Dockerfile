FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /app

COPY . ./
RUN dotnet publish -c $configuration -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Evaluations.WebApi.dll", "--urls=http://*:4040"]

