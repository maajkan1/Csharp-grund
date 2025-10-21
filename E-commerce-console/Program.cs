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
        //Skapar en lista av Products klassen
        List<Products> products = new List<Products>();
        //Lägger in några manuella för att simulera en shop.
        products.Add(new Products("Jeans", "Snygga blåa jeans", 250m));
        products.Add(new Products("Kavaj", "Snygga kavaj", 500));
        products.Add(new Products("Tröja", "Snygga tröja", 350));

        foreach (var product in products)
        {
            Console.WriteLine(product.ProductId);
        }

        while (true)
        {
            Console.WriteLine("===Shop of Commerce===");
            Console.WriteLine("[1] Produkter");
            Console.WriteLine("[2] Varukorg");
            Console.WriteLine("[3] Ordrar");
            Console.WriteLine("[4] Lägg till produkter");

            string val = Console.ReadLine();

            // switch (val)
            // {
            //     case 1: Products();
            //         break;
            //     case 2: ShoppingCart();
            //         break;
            //     case 3: Order();
            //         break;
            //     case 4: addProducts();
            // }
        }
    }
}