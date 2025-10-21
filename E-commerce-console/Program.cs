using System.ComponentModel;

namespace E_commerce_console;
/*
Uppgiften
Du ska skapa en konsolapplikation i C# där användaren välja produkter att lägga till i sin varukorg.
Efter att ha lagt in minst en produkt i sin varukorg kan användaren välja att gå till kassan varefter
användaren kan se totalbelopp och bekräfta sin order. Då skapas det en order.
Bonus – Lägg in momssats på produkter, och låt användaren se “Varav moms” i kassan – Lägg in inköpspris på produkter, så att t.ex. en admin kan se dagens ordrar och hur mycket vinst
som hittills genererats.
*/

class Program
{
    static void Main(string[] args)
    {
        var cart = new ShoppingCart();
        //Skapar en lista av Products klassen
        List<Products> products =
            //Lägger in några manuella för att simulera en shop.
            [
                new Products("Jeans", "Blåa jeans", 250m),
                new Products("Kavaj", "Blå kavaj", 500m),
                new Products("Tröja", "Rödgul tröja", 350m)
            ];

        while (true)
        {
            Console.WriteLine("===Shop of Commerce===");
            Console.WriteLine("[1] Produkter");
            Console.WriteLine("[2] Varukorg");
            Console.WriteLine("[3] Ordrar");
            Console.WriteLine("[4] Lägg till produkter");

            int choice = ConsoleUtils.ReadInt();
            Console.Clear();
            switch (choice)
            {
                case 1:
                    foreach (var product in products)
                    {
                        if (product.ProductInStock == true)
                        {
                            Console.WriteLine(
                                $"[{product.ProductId}] Produkt: {product.ProductName}\nPris: {product.ProductPrice}kr\nBeskrivning: {product.ProductDescription}");
                            Console.WriteLine("----------------------------------------");
                        }
                    }

                    Console.WriteLine("För att köpa någon av produkterna, var snäll att skriv in deras siffra:");
                    Console.WriteLine("O för att återgå till menyn");
                    int productChoice = ConsoleUtils.ReadInt();
                    if (productChoice == 0)
                    {
                        break;
                    } else if (productChoice > products.Count)
                    {
                        Console.WriteLine("Den valda siffran fanns inte som en produkt");
                        break;
                    }
                    
                    for (int i = 0; i < products.Count; i++)
                    {
                        if (productChoice == products[i].ProductId)
                        {
                            cart.AddProduct(products[i]);
                            products[i].ProductInStock = false;
                            break;
                        }
                    }
                    break;
                case 2: ShoppingCart();
                 
                    break;
                case 3: Order();
                    break;
                case 4: addProducts();*/
                default:
                    Console.WriteLine("Ogiltlig inmatning");
                    break;
            }
        }
    }
}