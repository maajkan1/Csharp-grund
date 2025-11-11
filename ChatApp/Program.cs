using ChatApp.Models;

namespace ChatApp;
using SocketIOClient;
using System;

class Program
{
    // ws är protokollet för Web Socket (som http)
    // wss är samma som https, alltså TLS/SSL(krypterar trafiken mellan klient och server) aktiverad.

    /*
     * Händelser/Events skickas mellan klienten och servern.
     * Varje event har ett eventName och data-innehåll
     */

    static async Task Main(string[] args)
    {
        Console.CursorTop++;
        var newUser = new User("mikael");
        await SocketManager.Connect();
        await SocketManager.ChannelConnect("general", newUser);
        MessageFromUser.Messages.Add(new UserMessage("hejhejhej", newUser));

        while (true)
        {

            var input = Console.ReadLine();
            var message = new UserMessage(input, newUser);
            await SocketManager.Send("general", message);
            await SocketManager.DisplayMessages();
        }
    }
}
    