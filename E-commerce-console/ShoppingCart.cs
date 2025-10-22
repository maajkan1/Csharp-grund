namespace E_commerce_console;
/*
 * List av produkter i en varukorg
 * Summa av totalen av pris
 * Kolla så användaren lagt till en vara
 */
public class ShoppingCart
{
    private readonly List<Products> _cart = [];

   public  decimal TotalSum()
   {
       decimal sum = 0;
       foreach (var product in _cart)
       {
           sum += product.ProductPrice;
       }

       return sum;
   }

   private void EmptyCart()
   {
       if (_cart.Count == 0)
       {
           Console.WriteLine("Du måste lägga till något i din varukorg för att fortsätta!");
       }
   }

   public void AddProduct(Products product)
   {
       _cart.Add(product);
   }

   public void RemoveProduct(Products product)
   {
       _cart.Remove(product);
   }

   public void DisplayCart(List<Order> orders)
   {
       if (_cart.Count == 0)
       {
           EmptyCart();
           return;
       }
       
       Console.WriteLine("Här har du din varukorg!");
       foreach (var product in _cart)
       {
           
           Console.WriteLine($"Produkt: {product.ProductName} -  Pris: {product.ProductPrice:C}");
       }
       Console.WriteLine($"Totalpriset för alla produkter är: {TotalSum()}");
       Console.WriteLine("Vill du slutföra ditt köp? Y/N");
       var buy = ConsoleUtils.ReadString();
       if (buy.ToLower() == "n")
       {
           foreach (var product in _cart)
           {
               product.ProductInStock = true;
           }
           _cart.Clear();
       }
       if (buy.ToLower() == "y")
       {
           var order = new Order
           {
               ProductsOrdered = new List<Products>(_cart),
               OrderDate = DateTime.Now
           };
           orders.Add(order);
           _cart.Clear();

           Console.WriteLine("Köpet är gjort! Kolla (3) Ordrar för mer info.");
       }
       else
       {
           Console.WriteLine("Tillbaka till huvudmeny");
       }
   }
    
}