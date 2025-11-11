namespace ChatApp.Models;

public class User
{
    public string? Username { get; set; }

    public User(string name)
    {
        Username = name;
    }
}