using System.Xml;

namespace E_commerce_console;
/*
 * Totalsumma
 * Tid ordern skapades
 * Produkter
 *
*/

 
public class Order
{
    public decimal TotalSum { get; set; }
    public DateTime OrderDate { get; set; }
    
    public List<Products> ProductsOrdered { get; set; } = new List<Products>();
    

    public void DisplayOrders()
    {
        Console.WriteLine("Ordrar:");
        Console.WriteLine("");
        Console.WriteLine($"Order Datum: {OrderDate}");
        Console.WriteLine("Produkter:");
        decimal totalSum = 0;
        foreach (var product in ProductsOrdered)
        {
            Console.WriteLine($"- {product.ProductName} ({product.ProductPrice:C})");
            totalSum += product.ProductPrice;
            Console.WriteLine("----------------------------------------------------");
        }

        Console.WriteLine($"Total summan på ordern: {totalSum:C}");
    }
}