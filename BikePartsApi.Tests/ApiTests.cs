using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BikePartsApi.Tests;

public class ApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task StronaGlowna_ZawieraNumerIndeksu()
    {
        var response = await _client.GetAsync("/");
        var body = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("63899", body);
    }

    [Fact]
    public async Task Products_ZawieraNazweCzesci()
    {
        var response = await _client.GetAsync("/products");
        var body = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Shimano", body);
    }

    [Fact]
    public async Task NieznanaCzesc_Zwraca404()
    {
        var response = await _client.GetAsync("/products/999");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
