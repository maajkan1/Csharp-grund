namespace api_test;

public static class ConsoleUtils
{
    public static int ReadInt()
    {
        while (true)
        {
            var input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                return choice;
            }

            Console.WriteLine("Felaktig inmatning, försök igen:");
        }
    }
    public static string ReadString()
    {
        while (true)
        {
            var input = Console.ReadLine();

            if (input == string.Empty)
            {
                Console.WriteLine("Felaktig inmatning, försök igen:");
                continue;
            }

            return input;
        }
    }
    public static decimal ReadDecimal()
    {
        while (true)
        {
            var input = Console.ReadLine();

            if (decimal.TryParse(input, out decimal choice))
            {
                return choice;
            }

            Console.WriteLine("Felaktig inmatning, försök igen:");
        }
    }
    public static long ReadLong()
    {
        while (true)
        {
            var input = Console.ReadLine();

            if (long.TryParse(input, out long choice))
            {
                return choice;
            }

            Console.WriteLine("Felaktig inmatning, försök igen:");
        }
    }
}