namespace E_commerce_console;
/*
 * List av produkter i en varukorg
 * Summa av totalen av pris
 * Kolla så användaren lagt till en vara
 */
public class ShoppingCart
{
   public List<Products> Cart = new List<Products>();

   public  decimal TotalSum(decimal sum)
   {
       foreach (var product in Cart)
       {
           sum += product.ProductPrice;
       }

       return sum;
   }

   public void EmptyCart()
   {
       if (Cart.Count == 0)
       {
           Console.WriteLine("Du måste lägga till något i din varukorg för att fortsätta!");
       }
   }

   public void AddProduct(Products product)
   {
       Cart.Add(product);
   }

   public void RemoveProduct(Products product)
   {
       Cart.Remove(product);
   }
    
}