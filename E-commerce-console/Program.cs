using System.ComponentModel;

namespace E_commerce_console;
/*
Uppgiften
Du ska skapa en konsolapplikation i C# där användaren välja produkter att lägga till i sin varukorg.
Efter att ha lagt in minst en produkt i sin varukorg kan användaren välja att gå till kassan varefter
användaren kan se totalbelopp och bekräfta sin order. Då skapas det en order.
Bonus – Lägg in momssats på produkter, och låt användaren se “Varav moms” i kassan – Lägg in inköpspris på produkter, så att t.ex en admin kan se dagens ordrar och hur mycket vinst
som hittills genererats.
*/

class Program
{
    static void Main(string[] args)
    {
        //Skapar en lista av ordrar
        var orders = new List<Order>();
        //Skapar en lista av ShoppingCart
        var cart = new ShoppingCart();
        //Skapar en lista av Products klassen
        List<Products> products =
            //Lägger in några manuella för att simulera en shop.
            [
                new("Jeans", "Blåa jeans", 250m),
                new("Kavaj", "Blå kavaj", 500m),
                new("Tröja", "Rödgul tröja", 350m)
            ];
        // Startar Loopen för programmet
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===Shop of Commerce===");
            Console.WriteLine("[1] Produkter");
            Console.WriteLine("[2] Varukorg");
            Console.WriteLine("[3] Ordrar");
            Console.WriteLine("[4] Lägg till produkter");
            
            var choice = ConsoleUtils.ReadInt();
            switch (choice)
            {
                case 1:
                    Products.ProductsDisplay(products, cart);
                    break;
                case 2:
                    cart.DisplayCart(orders);
                    break;
                case 3:
                    if (orders.Count == 0)
                    {
                        Console.WriteLine("Det är inga ordrar lagda.");
                        Thread.Sleep(3000);
                    }
                    foreach (var order in orders)
                    {
                        order.DisplayOrders();
                    }
                    break;
                case 4: Products.AddNewProduct(products);
                    break;
                default:
                    Console.WriteLine("Ogiltlig inmatning");
                    break;
            }
            Thread.Sleep(1000);
        }
    }
    
}