using System.Globalization;

namespace HotelBooking;

class Program
{
    static void Main(string[] args)
    {
        var hotel = new Hotel();
        hotel.CreateReservation();
        hotel.CreateReservation();
        hotel.CreateReservation();
        
    }
}