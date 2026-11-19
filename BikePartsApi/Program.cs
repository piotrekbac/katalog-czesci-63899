var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    var items = "";
    foreach (var part in Catalog.Products)
    {
        items += $"<li>{part.Name} - {part.Price:0.00} zl ({part.Category})</li>";
    }

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

app.MapGet("/products", () => Catalog.Products);

app.MapGet("/products/{id:int}", (int id) =>
{
    var product = Catalog.Find(id);
    return product is null ? Results.NotFound() : Results.Ok(product);
});

app.Run();

public partial class Program { }
