// Moje dane: Piotr Bacior 63899
// Testy adresow HTTP
// Aplikacja wstaje w pamięci, przeglądarka i port 5115 nie są nam potrzebne

using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BikePartsApi.Tests;

// Klasa ApiTests implementuje interfejs IClassFixture<WebApplicationFactory<Program>>, co pozwala na uruchomienie aplikacji w pamięci podczas testów
public class ApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    // Definiujemy prywatne pole _client typu HttpClient, które będzie używane do wysyłania żądań HTTP do aplikacji w pamięci
    private readonly HttpClient _client;

    // Definiujemy konstruktor klasy ApiTests, który przyjmuje obiekt WebApplicationFactory<Program> jako parametr.
    // W konstruktorze tworzymy klienta HTTP (_client) za pomocą metody CreateClient() z fabryki aplikacji
    public ApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    // Test metody StronaGlowna_ZawieraNumerIndeksu sprawdza, czy strona główna ("/") zwraca kod statusu 200 (OK) i zawiera numer indeksu "63899" w treści odpowiedzi
    [Fact]
    public async Task StronaGlowna_ZawieraNumerIndeksu()
    {
        // Wysyłamy żądanie GET do adresu "/" i oczekujemy odpowiedzi
        var response = await _client.GetAsync("/");

        // Odczytujemy treść odpowiedzi jako string
        var body = await response.Content.ReadAsStringAsync();

        // Sprawdzamy, czy kod statusu odpowiedzi jest równy 200 (OK)
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        // Sprawdzamy, czy treść odpowiedzi zawiera numer indeksu "63899"
        Assert.Contains("63899", body);
    }

    // Test metody Products_ZawieraNazweCzesci sprawdza, czy endpoint "/products" zwraca kod statusu 200 (OK) i zawiera nazwę części "Shimano" w treści odpowiedzi
    [Fact]
    public async Task Products_ZawieraNazweCzesci()
    {
        // Wysyłamy żądanie GET do adresu "/products" i oczekujemy odpowiedzi
        var response = await _client.GetAsync("/products");

        // Odczytujemy treść odpowiedzi jako string
        var body = await response.Content.ReadAsStringAsync();

        // Sprawdzamy, czy kod statusu odpowiedzi jest równy 200 (OK)
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        // Sprawdzamy, czy treść odpowiedzi zawiera nazwę części "Shimano"
        Assert.Contains("Shimano", body);
    }

    // Test metody NieznanaCzesc_Zwraca404 sprawdza, czy próba pobrania nieistniejącej części ("/products/999") zwraca kod statusu 404 (Not Found)
    [Fact]
    public async Task NieznanaCzesc_Zwraca404()
    {
        // Wysyłamy żądanie GET do adresu "/products/999" i oczekujemy odpowiedzi
        var response = await _client.GetAsync("/products/999");

        // Sprawdzamy, czy kod statusu odpowiedzi jest równy 404 (Not Found)
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
