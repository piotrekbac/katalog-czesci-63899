// Piotr Bacior 63899
// Testy samego katalogu, bez odpalania strony - to sa testy jednostkowe

namespace BikePartsApi.Tests;

public class CatalogTests
{
    // wymagane sa co najmniej dwa testy i co najmniej dwie czesci na liscie
    [Fact]
    public void Katalog_MaCoNajmniejDwieCzesci()
    {
        Assert.True(Catalog.Products.Count >= 2);
    }

    // id 1 to lancuch Shimano, wykrzyknik po product jest dla kompilatora
    // po Assert.NotNull wiadomo, ze nie ma tam nulla
    [Fact]
    public void Find_ZwracaCzescOPodanymId()
    {
        var product = Catalog.Find(1);

        Assert.NotNull(product);
        Assert.Equal(1, product!.Id);
        Assert.Contains("Shimano", product.Name);
    }

    // 999 nie wystepuje w katalogu
    [Fact]
    public void Find_NieznaneIdZwracaNull()
    {
        var product = Catalog.Find(999);

        Assert.Null(product);
    }
}
