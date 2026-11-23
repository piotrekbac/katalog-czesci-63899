// Moje dane: Piotr Bacior 63899
// Testy adresow HTTP
// Aplikacja wstaje w pami?ci, przegl?darka i port 5115 nie s? nam potrzebne

using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BikePartsApi.Tests;

// Klasa ApiTests implementuje interfejs IClassFixture<WebApplicationFactory<Program>>, co pozwala na uruchomienie aplikacji w pami?ci podczas testów
public class ApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    // Definiujemy prywatne pole _client typu HttpClient, które b?dzie u?ywane do wysy?ania ??da? HTTP do aplikacji w pami?ci
    private readonly HttpClient _client;

    // Definiujemy konstruktor klasy ApiTests, który przyjmuje obiekt WebApplicationFactory<Program> jako parametr.
    // W konstruktorze tworzymy klienta HTTP (_client) za pomoc? metody CreateClient() z fabryki aplikacji
    public ApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    // Test metody StronaGlowna_ZawieraNumerIndeksu sprawdza, czy strona g?ówna ("/") zwraca kod statusu 200 (OK) i zawiera numer indeksu "63899" w tre?ci odpowiedzi
    [Fact]
    public async Task StronaGlowna_ZawieraNumerIndeksu()
    {
        // Wysy?amy ??danie GET do adresu "/" i oczekujemy odpowiedzi
        var response = await _client.GetAsync("/");

        // Odczytujemy tre?? odpowiedzi jako string
        var body = await response.Content.ReadAsStringAsync();

        // Sprawdzamy, czy kod statusu odpowiedzi jest równy 200 (OK)
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        // Sprawdzamy, czy tre?? odpowiedzi zawiera numer indeksu "63899"
        Assert.Contains("63899", body);
    }

    // Test metody Products_ZawieraNazweCzesci sprawdza, czy endpoint "/products" zwraca kod statusu 200 (OK) i zawiera nazw? cz??ci "Shimano" w tre?ci odpowiedzi
    [Fact]
    public async Task Products_ZawieraNazweCzesci()
    {
        // Wysy?amy ??danie GET do adresu "/products" i oczekujemy odpowiedzi
        var response = await _client.GetAsync("/products");

        // Odczytujemy tre?? odpowiedzi jako string
        var body = await response.Content.ReadAsStringAsync();

        // Sprawdzamy, czy kod statusu odpowiedzi jest równy 200 (OK)
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        // Sprawdzamy, czy tre?? odpowiedzi zawiera nazw? cz??ci "Shimano"
        Assert.Contains("Shimano", body);
    }

    // Test metody NieznanaCzesc_Zwraca404 sprawdza, czy próba pobrania nieistniej?cej cz??ci ("/products/999") zwraca kod statusu 404 (Not Found)
    [Fact]
    public async Task NieznanaCzesc_Zwraca404()
    {
        // Wysy?amy ??danie GET do adresu "/products/999" i oczekujemy odpowiedzi
        var response = await _client.GetAsync("/products/999");

        // Sprawdzamy, czy kod statusu odpowiedzi jest równy 404 (Not Found)
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
