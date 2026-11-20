// Piotr Bacior 63899
// Lista czesci, z ktorej korzysta strona i adres /products
// Nie ma bazy, po restarcie wraca ta sama czworka

// id, nazwa, kategoria i cena
public record Product(int Id, string Name, string Category, decimal Price);

public static class Catalog
{
    // cztery czesci na sztywno, ta sama kolekcja idzie do HTML i do JSON
    public static IReadOnlyList<Product> Products { get; } = new List<Product>
    {
        new(1, "Lancuch Shimano CN-HG71", "Naped", 89.00m),
        new(2, "Klocki hamulcowe Shimano B05S", "Hamulce", 36.00m),
        new(3, "Opona Continental Ultra Sport", "Kola", 79.00m),
        new(4, "Przerzutka tylna Shimano Altus", "Naped", 129.00m)
    };

    // szuka czesci po numerze z adresu, np. /products/1
    // jak zadne id nie pasuje, zwraca null i endpoint oddaje 404
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
