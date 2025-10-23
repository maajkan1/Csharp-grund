namespace Library;
/*
 * Uppgiften
Du ska skapa en konsolapplikation i C# där användaren kan se en lista av böcker. En bok kan
redan vara lånad, och då får man isåfall se när den ska återlämnas. Användaren kan välja vilka
böcker den vill låna och sedan låna böckerna.
Användaren kan även se sina lånade böcker, och välja att lämna tillbaka dem.
 */
public class Book
{
    /*
     * Loaned? Bool
     * Title String
     * Author
     * ISBN 13 digits; (string -> double)
     * Genre Enum
     * Description String
     */
    
    public string Title {get; set;}
    public string Author {get; set;}
    public string Description {get; set;}
    public string ISBN {get; set;}
    public bool IsLoaned { get; set; }
    
    public Genres Genre { get; private set; }

    public Book(string title, string author, string description, string isbn, Genres genre)
    {
        Title = title;
        Author = author;
        Description = description;
        ISBN = isbn;
        IsLoaned = false;
        Genre = genre;
    }
}
public enum Genres
{
    Comedy,
    SciFi,
    Fantasy,
    Drama,
    Mystery,
    Cooking,
}