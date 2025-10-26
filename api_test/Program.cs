namespace api_test;

class Program
{
    static void Main(string[] args)
    { 
        Console.WriteLine("Loading........");
       var result= WineManager.GetWines().GetAwaiter().GetResult();
       

       while (true)
       {
           Console.Clear();
           Console.WriteLine("Sort the wine");
           Console.WriteLine("[1] By Wine name");
           Console.WriteLine("[2] By Winery");
           Console.WriteLine("[3] By Reviews");
           Console.WriteLine("[4] By Location");
            
           var choice = ConsoleUtils.ReadInt();
           switch (choice)
           {
               case 1:
                   WineManager.GetWineName(result);
                   break;
               case 2:
                   WineManager.GetWinery(result);
                   break;
               case 3:
                   WineManager.GetReviews(result);
                   break;
               case 4: 
                   WineManager.GetLocation(result);
                   break;
               default:
                   Console.WriteLine("Ogiltlig inmatning");
                   break;
           }

           Console.ReadKey();
       }
    }
}