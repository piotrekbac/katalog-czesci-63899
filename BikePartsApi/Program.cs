// Student: Piotr Bacior 63899
// Mamy trzy adresy: /, /products i /products/{id}
// Dane bierzemy z Catalog, aby nie trzyma? drugiej listy

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*
 Wy?wietlamy stron? g?ówn? z list? cz??ci rowerowych w formacie HTML.
 Ka?da cz??? jest reprezentowana jako element <li> zawieraj?cy nazw?, cen? i kategori?.
 Dodatkowo, na stronie znajduje si? link do danych w formacie JSON pod adresem /products
*/
app.MapGet("/", () =>
{
    // Generujemy list? elementów <li> dla ka?dej cz??ci rowerowej w katalogu. Ka?dy element zawiera nazw?, cen? i kategori? cz??ci
    var items = "";
    foreach (var part in Catalog.Products)
    {
        items += $"<li>{part.Name} - {part.Price:0.00} zl ({part.Category})</li>";
    }

    // Wstawiamy wygenerowane elementy <li> do szablonu HTML, który zawiera nag?ówek, numer indeksu oraz link do danych JSON
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

    // Zwracamy wygenerowany kod HTML jako odpowied? z nag?ówkiem Content-Type ustawionym na "text/html; charset=utf-8"
    return Results.Content(html, "text/html; charset=utf-8");
});

// Zwracamy dane w formacie JSON dla wszystkich cz??ci rowerowych w katalogu. Endpoint /products zwraca list? produktów jako obiekt JSON
app.MapGet("/products", () => Catalog.Products);

// Zwracamy dane w formacie JSON dla konkretnej cz??ci rowerowej na podstawie jej identyfikatora (ID).
// W adresie {id:int} oznacza, ?e id musi by? liczb?. Endpoint zwraca produkt o tym ID albo kod 404, je?li Find nic nie znajdzie
app.MapGet("/products/{id:int}", (int id) =>
{
    // Wyszukujemy produkt w katalogu na podstawie podanego identyfikatora (ID) za pomoc? metody Find
    var product = Catalog.Find(id);

    // Je?li produkt nie zostanie znaleziony, zwracamy kod statusu 404 (Not Found).
    // W przeciwnym razie zwracamy produkt jako obiekt JSON z kodem statusu 200 (OK)
    return product is null ? Results.NotFound() : Results.Ok(product);
});

// Start serwera, port lokalnie bierze sie z launchSettings (5115)
app.Run();

// Bez public testy w drugiej bibliotece nie widz? klasy startowej, dlatego jest publiczna.
// W tym pliku klasa jest pusta. Uruchomienie aplikacji jest wy?ej, w kodzie przed app.Run
public partial class Program { }
