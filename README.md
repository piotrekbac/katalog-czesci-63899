# Katalog części rowerowych

Lista części do roweru. Autor: Piotr Bacior, numer indeksu 63899.

Strona główna pokazuje listę. Adres /products zwraca te same części jako JSON.

## Uruchomienie

Potrzebny .NET SDK 8.

    dotnet test
    dotnet run --project BikePartsApi

Adres wypisze konsola. JSON jest pod /products.

## Docker

    docker build -t katalog-czesci .
    docker run --rm -p 8080:8080 katalog-czesci

Strona: http://localhost:8080

## Azure

Adres: https://app-bacior-63899-bpbmbmefczc2gndu.norwayeast-01.azurewebsites.net/

Po scaleniu do main workflow CD wgrywa aplikację na App Service.
Hasło wdrożenia jest w GitHub Secrets jako AZURE_WEBAPP_PUBLISH_PROFILE.