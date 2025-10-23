using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;

namespace E_commerce_console;
/*
 * Namn på produkt
 * Pris
 * Typ av produkt
 * Rabatterad? //Optional
 * Lägg till/Ta bort
 */
public class Products
{  
    // Definerar produkterna
    public string ProductName { get; }
    public string ProductDescription { get; }
    public decimal ProductPrice { get; }
    public bool ProductInStock { get; set; }
    private int ProductId { get; }
    //För att kunna ge ett unikt ID på alla varor (där man targetar dom)
    private static int _nextId = 1;
    public Products(string name, string description, decimal price)
    {
        ProductId = _nextId++;
        ProductName = name;
        ProductDescription = description;
        ProductPrice = price;
        ProductInStock = true;
    }
    public static void ProductsDisplay(List<Products> products, ShoppingCart cart)
    {
        products.Sort((id1, id2) => id1.ProductId.CompareTo(id2.ProductId));
        // För varje product så kollar den så ProductInStock = true
        // Är ProductInStock = false, så är den i ShoppingCart
        foreach (var product in products)
        {
            if (product.ProductInStock == true)
            {
                //Displayar alla produkter som finns
                Console.WriteLine(
                    $"[{product.ProductId}] Produkt: {product.ProductName}\nPris: {product.ProductPrice}kr\nBeskrivning: {product.ProductDescription}");
                Console.WriteLine("----------------------------------------");
            }
        }
        //Tar emot användarens input
        Console.WriteLine("För att köpa någon av produkterna, var snäll att skriv in deras siffra:");
        Console.WriteLine("O för att återgå till menyn");
        int productChoice = ConsoleUtils.ReadInt();
        // Om valet är 0 eller en siffra som inte finns, så bryts loopen och går till början av while
        if (productChoice == 0)
        {
            return;
        } else if (productChoice > products.Count)
        {
            Console.WriteLine("Den valda siffran fanns inte som en produkt");
            return;
        }
        //Kollar så att produkten finns genom att gå igenom alla ProductId med int i
        for (int i = 0; i < products.Count; i++)
        {
            if (productChoice == products[i].ProductId)
            {   
                // Använder inbyggd metod för att lägga till Product
                cart.AddProduct(products[i]);
                products[i].ProductInStock = false;
                break;
            }
        }
    }

    public static void AddNewProduct(List<Products> product)
    {
        Console.WriteLine("Namn på produkten:");
        var name = ConsoleUtils.ReadString();

        Console.WriteLine("Beskrivning av produkten:");
        var description = ConsoleUtils.ReadString();

        Console.WriteLine("Pris på produkten:");
        var price = ConsoleUtils.ReadDecimal();
        
        var newProduct = new Products(name, description, price);
        
        product.Add(newProduct);
    }
    
}