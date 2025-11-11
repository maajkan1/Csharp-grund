using ChatApp.Models;

namespace ChatApp;
using SocketIOClient;
public class SocketManager
{
    private static SocketIO _client;
    private static readonly string Path = "/sys25d";

    public static async Task Connect()
    {
        _client = new SocketIO("wss://api.leetcode.se", new SocketIOOptions
        {
            Path = "/sys25d"
        });
        

        _client.OnConnected += (sender, args) =>
        {
            Console.WriteLine("Connected");
        };
        
        _client.OnDisconnected += (sender, args) =>
        {
            Console.WriteLine("Disconnected");
        };
        
        await  _client.ConnectAsync();

        await Task.Delay(200);
    }
    public static async Task Send(string currentChannel, UserMessage message)
    {
        await _client.EmitAsync(currentChannel, message);
        MessageFromUser.Messages.Add(message);
    }

    public static async Task ChannelConnect(string channelName, User user)
    {
        _client.On($"{channelName}.systemevents", async response =>
        {
            var  userJoined = response.GetValue<UserEvents>();
            Console.WriteLine($"{userJoined.Timestamp:HH:mm} {userJoined.Username}: {userJoined.Status}");
            Thread.Sleep(5000);
            await DisplayMessages();
        });
        
        _client.On(channelName, async response =>
        {
            var receivedMessage = response.GetValue<UserMessage>();
            MessageFromUser.Messages.Add(receivedMessage); 
            await DisplayMessages();
        });
        await _client.EmitAsync($"{channelName}.systemevents", new UserEvents
        {
            Status = "Joined",
            Timestamp = DateTime.Now,
            Username = $"{user.Username}"
        } );
    }

    public static async Task DisplayMessages()
    {
        Console.Clear();
        Console.WriteLine("=================================");
        foreach (var messages in MessageFromUser.Messages)
        {
            Console.WriteLine($"{messages.Timestamp:HH:mm} {messages.Username}: {messages.MessageText}");
            
        }
        Console.WriteLine("=================================");
    }
    


}