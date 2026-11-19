public record Product(int Id, string Name, string Category, decimal Price);

public static class Catalog
{
    public static IReadOnlyList<Product> Products { get; } = new List<Product>
    {
        new(1, "Lancuch Shimano CN-HG71", "Naped", 89.00m),
        new(2, "Klocki hamulcowe Shimano B05S", "Hamulce", 36.00m),
        new(3, "Opona Continental Ultra Sport", "Kola", 79.00m),
        new(4, "Przerzutka tylna Shimano Altus", "Naped", 129.00m)
    };

    public static Product? Find(int id)
    {
        foreach (var product in Products)
        {
            if (product.Id == id)
            {
                return product;
            }
        }

        return null;
    }
}
