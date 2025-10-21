using Blackjack;
Console.Clear();
static void RunGame()
{
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Deck deck = new Deck();
    deck.ShuffleDeck();
    int playerScore = 0;
    int computerScore = 0;
    List<Card> playerCards = new List<Card>();
    List<Card> computerCards = new List<Card>();
    Console.WriteLine("Välkommen till Blackjack");
    Console.WriteLine("Du kommer få två kort, målet är att få 21 eller lägre");
    Console.WriteLine("Du drar ett kort via tangenten 'h' och stannar med tangenten 's'");
    Console.WriteLine("Lycka till!");
    Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
    Console.ReadKey();
    Console.WriteLine("");
    playerCards.Add(deck.DrawCard());
    playerCards.Add(deck.DrawCard());
    computerCards.Add(deck.DrawCard());
    computerCards.Add(deck.DrawCard());

    void AddInitialCardValue(List<Card> cards, ref int score)
    {
        foreach (var cardValue in cards)
        {

            score += cardValue.GetNumber();
        }
    }

    AddInitialCardValue(playerCards, ref playerScore);
    AddInitialCardValue(computerCards, ref computerScore);

    while (true)
    {

        Console.WriteLine($"Din summa: = {playerScore}");

        for (int row = 0; row < 8; row++)
        {
            foreach (var card in playerCards)
            {
                Console.Write(card.GetLines()[row] + "  ");
            }

            Console.WriteLine();
        }

        if (playerScore > 21)
        {
            Console.WriteLine("Du hamnade tyvärr över 21..");
            break;
        } else if (playerScore == 21)
        {
            break;
        }
        
        Console.WriteLine("Vänligen tryck 'h' för att dra kort, eller 's' för att stanna.");
        string val;
        bool isValidInput = false;

        do
        {
            val = Console.ReadKey().KeyChar.ToString();

            if (val == "h" || val == "s")
            {
                isValidInput = true;
            }
            else
            {
                Console.WriteLine("Felaktig inmatning. Vänligen tryck 'h' för att dra kort, eller 's' för att stanna.");
            }
        } while (!isValidInput);



        if (val == "h")
        {

            playerScore += deck.Cards[0].GetNumber();
            playerCards.Add(deck.DrawCard());
        }
        else if (val == "s")
        {
            break;
        }
    }
    Console.Clear();
    
    while (true)
    {
        if (playerScore > 21)
        {
            Console.WriteLine("Du blev för tjock! :(");
            Console.WriteLine(playerScore);
            break;
        } else if (playerScore == 21)

        {   
            Console.WriteLine("Du vann! Grattis! :)");
            Console.WriteLine(playerScore);
            break;
        }

        Console.WriteLine($"Din summa: = {playerScore}");
        Console.WriteLine($"Datorns summa: = {computerScore}");
        for (int row = 0; row < 8; row++)
        {
            foreach (var card in computerCards)
            {
                Console.Write(card.GetLines()[row] + "  ");
            }

            Console.WriteLine();
        }
        Thread.Sleep(1500);
        if (computerScore < playerScore)
        {
            computerScore += deck.Cards[0].GetNumber();
            computerCards.Add(deck.DrawCard());
        }
        else if (computerScore > playerScore && computerScore <= 21)
        {
            Console.WriteLine("Datorn vann! :)");
            break;
        }
        else if (computerScore == playerScore)
        {
            Console.WriteLine("Huset(datorn) vinner! :)");
            break;
        }
        else
        {
            Console.WriteLine("Du vann! Grattis! :)");
            break;
        }
    }
}
var restartGame = true;
    
do
{
    RunGame(); 

    Console.WriteLine("\nSpela igen? (J/N)");
    var input = Console.ReadLine()?.ToUpper();
    
    restartGame = input == "J";


} while (restartGame);

Console.WriteLine("Tack för idag! Tryck på valfri tangent för att avsluta.");
Console.ReadKey();
