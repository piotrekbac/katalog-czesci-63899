namespace BikePartsApi.Tests;

public class CatalogTests
{
    [Fact]
    public void Katalog_MaCoNajmniejDwieCzesci()
    {
        Assert.True(Catalog.Products.Count >= 2);
    }

    [Fact]
    public void Find_ZwracaCzescOPodanymId()
    {
        var product = Catalog.Find(1);

        Assert.NotNull(product);
        Assert.Equal(1, product!.Id);
        Assert.Contains("Shimano", product.Name);
    }

    [Fact]
    public void Find_NieznaneIdZwracaNull()
    {
        var product = Catalog.Find(999);

        Assert.Null(product);
    }
}
