// Student: Piotr Bacior 63899
// Mamy trzy adresy: /, /products i /products/{id}
// Dane bierzemy z Catalog, aby nie trzymać drugiej listy

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*
 Wyświetlamy stronę główną z listą części rowerowych w formacie HTML.
 Każda część jest reprezentowana jako element <li> zawierający nazwę, cenę i kategorię.
 Dodatkowo, na stronie znajduje się link do danych w formacie JSON pod adresem /products
*/
app.MapGet("/", () =>
{
    // Generujemy listę elementów <li> dla każdej części rowerowej w katalogu. Każdy element zawiera nazwę, cenę i kategorię części
    var items = "";
    foreach (var part in Catalog.Products)
    {
        items += $"<li>{part.Name} - {part.Price:0.00} zl ({part.Category})</li>";
    }

    // Wstawiamy wygenerowane elementy <li> do szablonu HTML, który zawiera nagłówek, numer indeksu oraz link do danych JSON
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

    // Zwracamy wygenerowany kod HTML jako odpowiedź z nagłówkiem Content-Type ustawionym na "text/html; charset=utf-8"
    return Results.Content(html, "text/html; charset=utf-8");
});

// Zwracamy dane w formacie JSON dla wszystkich części rowerowych w katalogu. Endpoint /products zwraca listę produktów jako obiekt JSON
app.MapGet("/products", () => Catalog.Products);

// Zwracamy dane w formacie JSON dla konkretnej części rowerowej na podstawie jej identyfikatora (ID).
// W adresie {id:int} oznacza, że id musi być liczbą. Endpoint zwraca produkt o tym ID albo kod 404, jeśli Find nic nie znajdzie
app.MapGet("/products/{id:int}", (int id) =>
{
    // Wyszukujemy produkt w katalogu na podstawie podanego identyfikatora (ID) za pomocą metody Find
    var product = Catalog.Find(id);

    // Jeśli produkt nie zostanie znaleziony, zwracamy kod statusu 404 (Not Found).
    // W przeciwnym razie zwracamy produkt jako obiekt JSON z kodem statusu 200 (OK)
    return product is null ? Results.NotFound() : Results.Ok(product);
});

// Start serwera, port lokalnie bierze sie z launchSettings (5115)
app.Run();

// Bez public testy w drugiej bibliotece nie widzą klasy startowej, dlatego jest publiczna.
// W tym pliku klasa jest pusta. Uruchomienie aplikacji jest wyżej, w kodzie przed app.Run
public partial class Program { }
