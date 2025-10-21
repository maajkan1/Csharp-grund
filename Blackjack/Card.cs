namespace Blackjack;

public class Card
{
    // TODO: Properties instead of variables
    // Suit, Rank, Value (färg, valör, numeriskt värde)
    
    public string Symbol { get; set; }

    public string Rank { get; set; }
    public int Number { get; set; }

    string[] symbols = new string[] { "\u2660", "\u2663", "\u2665", "\u2666" };
    public Card(string symbol, string rank, int number)
    {
        Symbol = symbol;
        Rank = rank;
        Number = number;
    }

    public string[] GetLines()
    {
        if (Rank == "10")
        {
            return new string[]
            {
                "**************",
                $"* {Rank}         *",
                $"* {Symbol}          *",
                "*            *",
                "*            *",
                $"*          {Symbol} *",
                $"*         {Rank} *",
                "**************"
            };
        }
        else
        {
            return new string[]
            {
                "**************",
                $"* {Rank}          *",
                $"* {Symbol}          *",
                "*            *",
                "*            *",
                $"*          {Symbol} *",
                $"*          {Rank} *",
                "**************"
            };
        }
    }

    public int GetNumber() => Number;
    
    public string GetSymbol() => Symbol;
}
