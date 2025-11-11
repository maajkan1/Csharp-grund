namespace ChatApp.Models;

public class MessageFromUser : Message
{
    public static List<UserMessage> Messages = [];
    public static List<UserEvents> UserEvents = [];
    
    public MessageFromUser()
    {
        Messages = new List<UserMessage>();
        UserEvents = new List<UserEvents>();
    }
    
}