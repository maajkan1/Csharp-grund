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
            Console.WriteLine("[1] Book a hotel room");
            Console.WriteLine("[2] Check for available rooms");
            Console.WriteLine("[3] Check your bookings");
            Console.WriteLine("[4] Cancel booking");
            Console.WriteLine("[5] Check all bookings");
            Console.WriteLine("[6] Total Earnings");
            
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
                    Console.ReadKey();
                    break;
                case 4:
                    hotel.CancelBooking(guest);
                    Console.ReadKey();
                    break;
                case 5:
                    hotel.CheckAllBookings();
                    Console.ReadKey();
                    break;
                case 6:
                    hotel.TotalEarnings();
                    break;
                default:
                    Console.WriteLine("Ogiltlig inmatning");
                    break;
            }
            Thread.Sleep(1000);
        }
    }
}