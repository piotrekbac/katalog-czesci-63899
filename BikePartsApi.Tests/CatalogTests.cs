// Moje dane: Piotr Bacior 63899
// Testy samego katalogu, bez odpalania strony - sekcja testów jednostkowych

namespace BikePartsApi.Tests;

// Klasa CatalogTests zawiera testy jednostkowe dla klasy Catalog, która przechowuje informacje o produktach rowerowych. Testy sprawdzają poprawność działania metod i właściwości klasy Catalog
public class CatalogTests
{
    // Test metody Katalog_MaCoNajmniejDwieCzesci sprawdza, czy katalog produktów zawiera co najmniej dwie części. W tym przypadku oczekujemy, że liczba produktów w katalogu będzie większa lub równa 2
    [Fact]
    public void Katalog_MaCoNajmniejDwieCzesci()
    {
        // Sprawdzamy, czy liczba produktów w katalogu jest większa lub równa 2
        Assert.True(Catalog.Products.Count >= 2);
    }

    // Test metody Find_ZwracaCzescOPodanymId sprawdza, czy metoda Find zwraca poprawny produkt dla podanego identyfikatora (ID).
    // W tym przypadku oczekujemy, że produkt o ID 1 istnieje w katalogu i zawiera nazwę "Shimano"
    [Fact]
    public void Find_ZwracaCzescOPodanymId()
    {
        // Wywołujemy metodę Find z identyfikatorem 1, aby znaleźć produkt o tym ID w katalogu
        var product = Catalog.Find(1);

        // Sprawdzamy, czy produkt nie jest nullem (czy został znaleziony)
        Assert.NotNull(product);

        // Sprawdzamy, czy ID znalezionego produktu jest równe 1.
        // Wykrzyknik po product jest dla kompilatora: po NotNull wiadomo, że wartość istnieje
        Assert.Equal(1, product!.Id);

        // Sprawdzamy, czy nazwa znalezionego produktu zawiera słowo "Shimano"
        Assert.Contains("Shimano", product.Name);
    }

    // Test metody Find_NieznaneIdZwracaNull sprawdza, czy metoda Find zwraca null dla nieistniejącego identyfikatora (ID)
    [Fact]
    public void Find_NieznaneIdZwracaNull()
    {
        // Wywołujemy metodę Find z nieistniejącym identyfikatorem 999, aby sprawdzić, czy metoda zwraca null
        var product = Catalog.Find(999);

        // Sprawdzamy, czy produkt jest nullem (czy nie został znaleziony)
        Assert.Null(product);
    }
}
