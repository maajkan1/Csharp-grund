using System.Globalization;

namespace HotelBooking;

class Program
{
    static void Main(string[] args)
    {
        var hotel = new Hotel();
        var guest = new Guest();
        guest.Name = "Guest";
        guest.Email = "guest@email.com";
        guest.Phone = "0763189243";
        var hotelRooms = hotel.Rooms;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=====Make Your Choices=====");
            Console.WriteLine("[1] Book a hotelroom");
            Console.WriteLine("[2] Check for available rooms");
            Console.WriteLine("[3] Check your bookings");
            Console.WriteLine("[4] Cancel booking");
            
            var choice = ConsoleUtils.ReadInt();
            switch (choice)
            {
                case 1:
                    hotel.CreateReservation(guest);
                    break;
                case 2:
                    hotel.ShowAvailableRooms().ForEach(Console.WriteLine);
                    Console.ReadKey();
                    break;
                case 3:
                    hotel.ShowReservationForGuest(guest).ForEach(Console.WriteLine);
                    break;
                case 4: 
                    //TODO : hotel.CancelBookings
                    break;
                default:
                    Console.WriteLine("Ogiltlig inmatning");
                    break;
            }
            Thread.Sleep(1000);
        }
    }
}