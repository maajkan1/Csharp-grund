
using System.Transactions;

namespace Bankkonto;

public class Konto
{
    public string? AccountName { get; set; }
    public long SecurityNumber { get; set; }
    
    public List<Transactions> Transactions { get; private set; } = new List<Transactions>();
    private decimal Balance { get; set; }

    public Konto(string accountName, long securityNumber)
    {
        AccountName = accountName;
        SecurityNumber = securityNumber;
        Balance = 0;
    }



    public decimal PrintBalance()
    {
        return Balance;
    }
    
    public decimal Deposit(decimal update)
    {
        Balance += update;
        Transactions.Add(new Transactions
        {
            DateTime = DateTime.Now,
            Type = "Insättning",
            Amount = update,
            BalanceAfterTransaction = Balance
                
        });
        return Balance;
    }
    public decimal Withdrawal(decimal update)
    {
        if (update > Balance)
        {
            Console.WriteLine("Du försöker ta ut mer än du har på ditt konto");
            return Balance;
        }
        if (Balance > 0)
        {
            Balance -= update;
            Transactions.Add(new Transactions
            {
                DateTime = DateTime.Now,
                Type = "Uttag",
                Amount = update,
                BalanceAfterTransaction = Balance
                
            });
            return Balance;
        }
        Console.WriteLine("Du kan inte ta ut då ditt saldo är: " + PrintBalance());
        return Balance;
    }
    

}