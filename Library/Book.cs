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
    
    private DateTime LoanDate { get; set; }
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

    public static void LoanBook(Book book)
    {
        if (book.IsLoaned)
        {
            book.LoanDate = DateTime.Today;
            book.IsLoaned = true;
        }
    }

    public static string TimeLeftOnLoan(Book book)
    {
        var dueDate = book.LoanDate.AddDays(7);
        var timeLeft = dueDate - DateTime.Now;
        
        return timeLeft.TotalDays > 0
            ? $"{timeLeft.Days} dagar kvar"
            : "Lånet är förfallet!";
    }
    public static List<Book> GetRandomizedBooks()
    {
        var book1 = new Book("Den förlorade stjärnan", "Linnea Holm", "Ett storslaget äventyr i en avlägsen galax", "9789123450001", Genres.SciFi);
        var book2 = new Book("Skuggor över Norrland", "Erik Sandström", "En nervkittlande kriminalroman i midnattssolens land", "9789123450002", Genres.Crime);
        var book3 = new Book("Kaffet i Kabul", "Sofia Bergqvist", "En gripande berättelse om hopp och mod", "9789123450003", Genres.Drama);
        var book4 = new Book("Kodnamn Vinter", "Alex Jarl", "En spionthriller fylld av oväntade vändningar", "9789123450004", Genres.Thriller);
        var book5 = new Book("Det sista receptet", "Edison Kadirsson", "En kulinarisk resa med dödliga konsekvenser", "9789123450005", Genres.Cooking);
        var book6 = new Book("Himlens kartor", "Nadia Persson", "En poetisk utforskning av stjärnor, tro och mänsklighet", "9789123450006", Genres.Poetry);
        var book7 = new Book("Cyberhjärtan", "Max Larsson", "En sci-fi-roman om kärlek i den digitala tidsåldern", "9789123450007", Genres.Romance);
        var book8 = new Book("Eld över Stockholm", "Jonas Ekberg", "En actionfylld berättelse om sabotage och mod", "9789123450008", Genres.Action);
        var book9 = new Book("Sanningens pris", "Emma Lind", "En journalist avslöjar mer än hon förväntade sig", "9789123450009", Genres.Mystery);
        var book10 = new Book("Tidens väktare", "Oskar Björk", "En fantasyroman om att stoppa tiden innan den rinner ut", "9789123450010", Genres.Fantasy);
        var book11 = new Book("Iskalla lögner", "Frida Norén", "En psykologisk thriller i en liten svensk by", "9789123450011", Genres.Thriller);
        var book12 = new Book("Staden utan ljud", "David Alster", "En dystopisk berättelse om tystnad, kontroll och frihet", "9789123450012", Genres.Dystopian);
        var book13 = new Book("Sommar på Sälön", "Hanna Öst", "En varm feelgoodroman om kärlek, hav och hemligheter", "9789123450013", Genres.Romance);
        var book14 = new Book("Kod 47", "Tobias Lantz", "En intensiv IT-thriller om en hackare på flykt", "9789123450014", Genres.Thriller);
        var book15 = new Book("Drömmen om Atlantis", "Clara Bergman", "Ett äventyr under havet med mytiska undertoner", "9789123450015", Genres.Adventure);

        return
        [
            book1, book2, book3, book4, book5,
            book6, book7, book8, book9, book10,
            book11, book12, book13, book14, book15
        ];
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
    Thriller,
    Romance,
    Crime,
    Action,
    Adventure,
    Horror,
    Historical,
    Poetry,
    Dystopian,
    Biography,
}

