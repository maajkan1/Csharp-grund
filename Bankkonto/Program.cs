using System.Security.Cryptography;

namespace Bankkonto;
/*
Du ska skapa en konsolapplikation i C# där användaren kan skapa ett bankkonto. Kontot ska ha en
kontoinnehavare och ett saldo. Användaren ska kunna sätta in pengar, göra uttag och visa sitt
aktuella saldo. Saldot ska vara skyddat så att det inte kan ändras direkt utifrån, utan endast via
insättningar och uttag.

Bonus
Skapa en bank som har bankkonton. Varje bankkonto är kopplad till ett personnummer, så
användaren kan ange sitt personnummer och hantera sitt ärende.
Spara alla transaktioner som görs på kontot. En transaktion ska ange datum/tid, typ av transaktion
(uttag/insättning), belopp samt saldo.
*/
    
    
class Program
{
    static void Main(string[] args)
    {
        var banken = new Bank();

        while (true)
        {
            Console.WriteLine("Ange ditt personnummer (10 siffror)");
            long accountNumber = Functions.RightChoiceLong();
            Konto accessBank = banken.FetchAccount(accountNumber);

            if (accessBank == null)
            {
                Console.WriteLine("Kontot finns inte, vill du skapa ett nytt? (y/n)");
                string answer = Functions.CorrectName();
                if (answer.ToLower() == "y")
                {
                    Console.WriteLine("Skriv namn:");
                    string name = Functions.CorrectName();
                    banken.CreateAccount(name, accountNumber);
                    accessBank = banken.FetchAccount(accountNumber);
                }
                else
                {
                    continue; 
                }
            }
    
            bool inMenu = true;
            while (inMenu)
            {
                Console.WriteLine("[1] Saldo");
                Console.WriteLine("[2] Insättning");
                Console.WriteLine("[3] Uttag");
                Console.WriteLine("[4] Transaktioner");
                Console.WriteLine("[5] Logga ut");

                int val = Functions.RightChoice();
                Console.Clear();

                switch (val)
                {
                    case 1:
                        Console.WriteLine($"Ditt saldo är: {accessBank.PrintBalance()} kr");
                        break;
                    case 2:
                        Console.WriteLine("Hur mycket vill du sätta in?");
                        decimal update = Functions.RightChoiceDecimal();
                        accessBank.Deposit(update);
                        Console.WriteLine($"Ditt nuvarande saldo är: {accessBank.PrintBalance()} kr");
                        break;
                    case 3:
                        Console.WriteLine("Hur mycket vill du ta ut?");
                        decimal withdrawal = Functions.RightChoiceDecimal();
                        accessBank.Withdrawal(withdrawal);
                        Console.WriteLine($"Ditt nuvarande saldo är: {accessBank.PrintBalance()} kr");
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Transaktioner:");
                        foreach (var transact in accessBank.Transactions) {
                            Console.WriteLine($"Summa: {transact.Amount}\nTyp:{transact.Type}\nDatum:{transact.DateTime}\nSaldo efter transaktion:{transact.BalanceAfterTransaction}");
                            Console.WriteLine("-------------------------------------------------------------------------------------------------");
                        }
                        break;
                    case 5:
                        inMenu = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltligt val");
                        break;
                }
            }
        }

    }
    
}