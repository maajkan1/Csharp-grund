namespace Blackjack;

public class Deck
{
    public List<Card>? Cards {get; set;} 

    public Deck()
    {
        GenerateDeck();
        //TODO: ShuffleDeck();
    }

    public void GenerateDeck()
    {
        // instantiate Cards List
        Cards = new List<Card>();
        // array of symbols (string)
        string[] symbols = ["\u2660", "\u2663", "\u2665", "\u2666"];
        
        // array of ranks (string)
        string[] ranks = ["A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"];
        
        // array of numbers (int)
        int[] numbers = [1,2,3,4,5,6,7,8,9,10,10,10,10];

        // TODO: for loop for generating the cards
        for (int i = 0; i < symbols.Length; i++) 
        {
            for (int j = 0; j < numbers.Length; j++) 
            {
                Cards.Add(new Card(symbols[i], ranks[j], numbers[j]));
            }
        }
    }

    public void ShuffleDeck()
    {
        // create random
        Random random = new Random();
        // check if Cards is valid
        if (Cards != null)
        {
            // local variable of cards count
            int n = Cards.Count;
            // for loop to shuffle the deck
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                var temp = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = temp;
            }
        }
        
    }
    
    // TODO: DrawCard()
    public Card DrawCard() 
    {
        // Draw a card from Cards list
        Card card = Cards[0];
        Cards.RemoveAt(0);
        return card;
        
    }
}