// Student: Piotr Bacior 63899
// W tym pliku mamy listę części, z której korzysta strona i adres /products
// Nie ma bazy, po restarcie wraca ta sama czworka

// Publiczny rekord Product reprezentuje część rowerową z właściwościami Id, Name, Category i Price. Właściwości są inicjalizowane w konstruktorze rekordu
public record Product(int Id, string Name, string Category, decimal Price);

// Publiczna klasa Catalog przechowuje informacje o dostępnych częściach rowerowych w formie listy produktów. Klasa zawiera właściwość Products, która jest listą tylko do odczytu (IReadOnlyList<Product>) i metodę Find, która pozwala na wyszukiwanie produktów po identyfikatorze (ID). Jeśli produkt o podanym ID nie zostanie znaleziony, metoda Find zwraca null
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

    // Definiujemy metodę Find, która przyjmuje identyfikator (ID) jako parametr i zwraca produkt o podanym ID lub null, jeśli produkt nie zostanie znaleziony.
    // Metoda iteruje po liście produktów i porównuje ID każdego produktu z podanym ID. Jeśli znajdzie dopasowanie, zwraca produkt; w przeciwnym razie zwraca null
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
