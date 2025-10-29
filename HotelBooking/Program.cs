using System.Globalization;

namespace HotelBooking;

class Program
{
    static void Main(string[] args)
    {
        var hotel = new Hotel();
        var hotelRooms = hotel.Rooms;
        hotel.CreateReservation();
        hotel.ShowAvailableRooms().ForEach(Console.WriteLine);

    }
}