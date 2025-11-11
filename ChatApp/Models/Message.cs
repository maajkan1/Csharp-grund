using ChatApp.Interface;

namespace ChatApp.Models;

public abstract class Message :  IMessage
{
    public DateTime Timestamp { get; set; }
    
    public string? Username { get; set; }
}