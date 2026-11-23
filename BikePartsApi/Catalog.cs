// Student: Piotr Bacior 63899
// W tym pliku mamy list? cz??ci, z której korzysta strona i adres /products
// Nie ma bazy, po restarcie wraca ta sama czworka

// Publiczny rekord Product reprezentuje cz??? rowerow? z w?a?ciwo?ciami Id, Name, Category i Price. W?a?ciwo?ci s? inicjalizowane w konstruktorze rekordu
public record Product(int Id, string Name, string Category, decimal Price);

// Publiczna klasa Catalog przechowuje informacje o dost?pnych cz??ciach rowerowych w formie listy produktów. Klasa zawiera w?a?ciwo?? Products, która jest list? tylko do odczytu (IReadOnlyList<Product>) i metod? Find, która pozwala na wyszukiwanie produktów po identyfikatorze (ID). Je?li produkt o podanym ID nie zostanie znaleziony, metoda Find zwraca null
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

    // Definiujemy metod? Find, która przyjmuje identyfikator (ID) jako parametr i zwraca produkt o podanym ID lub null, je?li produkt nie zostanie znaleziony.
    // Metoda iteruje po li?cie produktów i porównuje ID ka?dego produktu z podanym ID. Je?li znajdzie dopasowanie, zwraca produkt; w przeciwnym razie zwraca null
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
