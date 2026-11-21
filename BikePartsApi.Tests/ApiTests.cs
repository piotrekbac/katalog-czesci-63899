// Piotr Bacior 63899
// Testy adresow HTTP
// Aplikacja wstaje w pamieci, przegladarka i port 5115 nie sa potrzebne

using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BikePartsApi.Tests;

// fabryka buduje aplikacje raz dla calej klasy
public class ApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    // strona glowna ma oddac 200 i numer indeksu
    [Fact]
    public async Task StronaGlowna_ZawieraNumerIndeksu()
    {
        var response = await _client.GetAsync("/");
        var body = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("00000", body);
    }

    // /products ma oddac 200 i nazwe czesci z katalogu
    [Fact]
    public async Task Products_ZawieraNazweCzesci()
    {
        var response = await _client.GetAsync("/products");
        var body = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Shimano", body);
    }

    // takiego id nie ma, oczekuje 404
    [Fact]
    public async Task NieznanaCzesc_Zwraca404()
    {
        var response = await _client.GetAsync("/products/999");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
