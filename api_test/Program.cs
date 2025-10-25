namespace api_test;

class Program
{
    static void Main(string[] args)
    {
        WineManager.GetWines().GetAwaiter().GetResult();
        Console.ReadKey();
    }
}