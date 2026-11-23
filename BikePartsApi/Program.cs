// Piotr Bacior 63899
// Trzy adresy: /, /products i /products/{id}
// Dane bierzemy z Catalog, zeby nie trzymac drugiej listy

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// strona dla przegladarki
app.MapGet("/", () =>
{
    // z kazdej czesci sklejam jeden <li>: nazwa, cena, kategoria
    var items = "";
    foreach (var part in Catalog.Products)
    {
        items += $"<li>{part.Name} - {part.Price:0.00} zl ({part.Category})</li>";
    }

    // {items} wstawia gotowe <li> w srodek HTML
    var html = $"""
        <!DOCTYPE html>
        <html lang="pl">
        <head>
          <meta charset="utf-8">
          <title>Katalog czesci rowerowych</title>
        </head>
        <body>
          <h1>Katalog czesci rowerowych</h1>
          <p>Piotr Bacior, indeks 63899</p>
          <ul>{items}</ul>
          <p><a href="/products">Dane JSON</a></p>
        </body>
        </html>
        """;

    return Results.Content(html, "text/html; charset=utf-8");
});

// te same cztery czesci, tylko jako JSON
app.MapGet("/products", () => Catalog.Products);

// jedna czesc, albo 404 gdy Find nic nie znajdzie
// {id:int} oznacza, ze w adresie ma byc liczba
app.MapGet("/products/{id:int}", (int id) =>
{
    var product = Catalog.Find(id);
    return product is null ? Results.NotFound() : Results.Ok(product);
});

// start serwera, port lokalnie bierze sie z launchSettings (5115)
app.Run();

// bez public testy w drugiej bibliotece nie widza klasy startowej
public partial class Program { }
