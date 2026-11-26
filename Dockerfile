FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY BikePartsApi/BikePartsApi.csproj BikePartsApi/
RUN dotnet restore BikePartsApi/BikePartsApi.csproj
COPY BikePartsApi/ BikePartsApi/
RUN rm -rf BikePartsApi/bin BikePartsApi/obj \
    && dotnet publish BikePartsApi/BikePartsApi.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "BikePartsApi.dll"]