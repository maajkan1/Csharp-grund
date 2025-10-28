using System.Globalization;

namespace HotelBooking;

class Program
{
    static void Main(string[] args)
    {
        var hotel = new Hotel();
        foreach (var room in hotel.Rooms)
        {
            Console.WriteLine(room.Key + " " +room.Value.RoomPrice);
        }
        
    }
}