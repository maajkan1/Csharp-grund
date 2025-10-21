namespace Bankkonto;

public static class Functions
{
    public static int RightChoice()
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
    public static string CorrectName()
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
    public static decimal RightChoiceDecimal()
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
    public static long RightChoiceLong()
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