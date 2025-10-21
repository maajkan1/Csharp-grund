namespace Bankkonto;
public class Bank
{
    private List<Konto> _accounts = new List<Konto>();

    public void CreateAccount(string name, long securityNumber)
    {
        foreach (var account in _accounts)
        {
            if (account.SecurityNumber == securityNumber)
            {
                Console.WriteLine("Kontot finns redan");
                return;
            }
        }
        _accounts.Add(new Konto(name, securityNumber));
    }

    public Konto FetchAccount(long securityNumber)
    {
        foreach (var account in _accounts)
        {
            if (account.SecurityNumber == securityNumber)
            {
                return account;
            }
        }

        Console.WriteLine("Account not found");
        return null;
    }
}