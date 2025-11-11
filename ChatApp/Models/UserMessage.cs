namespace ChatApp.Models;

public class UserMessage : Message
{
   public string? MessageText { get; set; }

   public UserMessage()
    {
        
    }

    public UserMessage(string messageText, User name)
    {
        Username = name.Username;
        MessageText = messageText;
        Timestamp = DateTime.Now;
    }
}