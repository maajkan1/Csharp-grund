namespace Library;
/*
 * /*
 * Uppgiften
Du ska skapa en konsolapplikation i C# där användaren kan se en lista av böcker. En bok kan
redan vara lånad, och då får man isåfall se när den ska återlämnas. Användaren kan välja vilka
böcker den vill låna och sedan låna böckerna.
Användaren kan även se sina lånade böcker, och välja att lämna tillbaka dem.
 * /
 */
public class Library
{
    public List<Book> LibraryBooks = new List<Book>();
    public List<User> Users { get; set; } = new List<User>();
    
    public void DisplayLibrary()
    {
        foreach (var book in LibraryBooks)
        {
            Console.WriteLine(book.Title);
            
        }
    }
    
}