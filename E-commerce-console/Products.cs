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
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public bool ProductInStock { get; set; }
    public int ProductId { get; set; }
    private static int _nextId = 1;
    public Products(string name, string description, decimal price)
    {
        ProductId = _nextId++;
        ProductName = name;
        ProductDescription = description;
        ProductPrice = price;
        ProductInStock = true;
    }
    
}