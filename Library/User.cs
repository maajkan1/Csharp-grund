namespace Library;
/*
 * Uppgiften
Du ska skapa en konsolapplikation i C# där användaren kan se en lista av böcker. En bok kan
redan vara lånad, och då får man isåfall se när den ska återlämnas. Användaren kan välja vilka
böcker den vill låna och sedan låna böckerna.
Användaren kan även se sina lånade böcker, och välja att lämna tillbaka dem.
 */
public class User
{
    private string Name { get; set; }
    private int PinCode { get; set; }
    public List<Book> UserBooks { get; set; }

    public User(string name, int pinCode, List<Book> userBooks)
    {
        Name = name;
        PinCode = pinCode;
        UserBooks = userBooks;
    }

    public void DisplayLoanedBooks()
    {
        foreach(var book in UserBooks)
        {
            Console.WriteLine($"Boktitel: {book.Title}\nFörfattare: {book.Author}\n" +
                              $"Tid till återlämning: {book.IsLoaned}");
        }
    }
}