// Moje dane: Piotr Bacior 63899
// Testy samego katalogu, bez odpalania strony - sekcja testów jednostkowych

namespace BikePartsApi.Tests;

// Klasa CatalogTests zawiera testy jednostkowe dla klasy Catalog, która przechowuje informacje o produktach rowerowych. Testy sprawdzaj? poprawno?? dzia?ania metod i w?a?ciwo?ci klasy Catalog
public class CatalogTests
{
    // Test metody Katalog_MaCoNajmniejDwieCzesci sprawdza, czy katalog produktów zawiera co najmniej dwie cz??ci. W tym przypadku oczekujemy, ?e liczba produktów w katalogu b?dzie wi?ksza lub równa 2
    [Fact]
    public void Katalog_MaCoNajmniejDwieCzesci()
    {
        // Sprawdzamy, czy liczba produktów w katalogu jest wi?ksza lub równa 2
        Assert.True(Catalog.Products.Count >= 2);
    }

    // Test metody Find_ZwracaCzescOPodanymId sprawdza, czy metoda Find zwraca poprawny produkt dla podanego identyfikatora (ID).
    // W tym przypadku oczekujemy, ?e produkt o ID 1 istnieje w katalogu i zawiera nazw? "Shimano"
    [Fact]
    public void Find_ZwracaCzescOPodanymId()
    {
        // Wywo?ujemy metod? Find z identyfikatorem 1, aby znale?? produkt o tym ID w katalogu
        var product = Catalog.Find(1);

        // Sprawdzamy, czy produkt nie jest nullem (czy zosta? znaleziony)
        Assert.NotNull(product);

        // Sprawdzamy, czy ID znalezionego produktu jest równe 1.
        // Wykrzyknik po product jest dla kompilatora: po NotNull wiadomo, ?e warto?? istnieje
        Assert.Equal(1, product!.Id);

        // Sprawdzamy, czy nazwa znalezionego produktu zawiera s?owo "Shimano"
        Assert.Contains("Shimano", product.Name);
    }

    // Test metody Find_NieznaneIdZwracaNull sprawdza, czy metoda Find zwraca null dla nieistniej?cego identyfikatora (ID)
    [Fact]
    public void Find_NieznaneIdZwracaNull()
    {
        // Wywo?ujemy metod? Find z nieistniej?cym identyfikatorem 999, aby sprawdzi?, czy metoda zwraca null
        var product = Catalog.Find(999);

        // Sprawdzamy, czy produkt jest nullem (czy nie zosta? znaleziony)
        Assert.Null(product);
    }
}
