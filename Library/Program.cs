namespace Library;
/*
 * Uppgiften
Du ska skapa en konsolapplikation i C# där användaren kan se en lista av böcker. En bok kan
redan vara lånad, och då får man isåfall se när den ska återlämnas. Användaren kan välja vilka
böcker den vill låna och sedan låna böckerna.
Användaren kan även se sina lånade böcker, och välja att lämna tillbaka dem. 
 */
class Program
{
    static void Main(string[] args)
    {
        var menu = true;
        var library = new Library();
        var users = new User("admin", 1234, []);
        library.Users.Add(users);
        
        
        
        var libraryBooks = library.LibraryBooks;
        Console.WriteLine(libraryBooks);
        var book = new Book("Edisons recept", "Edison Kadirsson", "Massa fantastiska recept", "12345123412341",
            Genres.Cooking);
        libraryBooks.Add(book);
        library.DisplayLibrary();
        users.UserBooks = libraryBooks;

        while (menu)
        {
            Console.Clear();
            Console.WriteLine("Välkommen till ditt bibliotek");
            Console.WriteLine("[1] Låna böcker");
            Console.WriteLine("[2] Visa lånade böcker");
            Console.WriteLine("[3] Skapa användare");
            Console.WriteLine("[4] Logga ut");

            var choice = ConsoleUtils.ReadInt();
            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    users.DisplayLoanedBooks();
                    Console.ReadKey();
                    break;
                case 3:
                    break;
                case 4:
                    menu = false;
                    break;
                default:
                    Console.WriteLine("Ogiltlig inmatning");
                    break;
            }
            
        }
    }
}
