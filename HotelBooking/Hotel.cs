namespace HotelBooking;

public class Hotel
{
    public List<Room> Rooms { get; set; }
    public List<Reservation> Reservations { get; set; }
    public Hotel()
    {
        Reservations = [];
        Rooms = [];
        CreateRooms();
        AddPriceClass(Rooms);
    }
        // Skapar rum från 101-509
    private void CreateRooms()
    {
        //The outer loops counts from 1-5
        //The inner loop counts from 1-9
        //The max is 509 and min is 101.
        for (var i = 1; i <= 5; i++)
        {
            for (var j = 1; j <= 9; j++)
            {
                var roomNumber = i * 100 + j;
                Rooms.Add(new Room(roomNumber));
            }
        }
    }

    private void AddPriceClass(List<Room> room)
    {
        foreach (var roomFloor in room)
        {
            int floor = roomFloor.RoomNumber / 100;
            // Adds extra the higher up you come to the floor
            // Think of it that the higher up you come, the better view and hotel room quality
            roomFloor.RoomPrice = floor switch
            {
                1 or 2 => 1000,
                3 or 4 => 1500,
                5 => 2500,
                _ => 1000
                //Följde Riders Template för snyggare switch-expression.
            };
        }
    }

    public void CreateReservation()
    {
        Console.WriteLine("What room number would you like to reserve?");
        int roomNumber = ConsoleUtils.ReadInt();
        Console.WriteLine("What date do you wanna check in? (YYYY-MM-DD)");
        string checkIn = ConsoleUtils.ReadString();
        Console.WriteLine("What date do you wanna check out? (YYYY-MM-DD)");
        string checkOut = ConsoleUtils.ReadString();
        //checkForAvailability(roomNumber, checkIn, checkOut);
        if (checkforAvailability == true)
        {
            Console.WriteLine("Room is available, Would you like to book?");
            Console.WriteLine("Y/N");
            string choice =  ConsoleUtils.ReadString();
            if (choice.ToLower() == "y")
            {
                Rooms.Add(new Room(roomNumber));
            }
            
        }
    }
}