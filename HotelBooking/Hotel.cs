namespace HotelBooking;

public class Hotel
{
    public Dictionary<int, Room> Rooms { get; set; }
    public Dictionary <int, Reservation> Reservations { get; set; }
    public Hotel()
    {
        Reservations = new Dictionary<int, Reservation>();
        Rooms = new Dictionary<int, Room>();
        CreateRooms();
        AddPriceClass(Rooms.Values.ToList());
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
                var newRoom = new Room(roomNumber);
                Rooms.Add(roomNumber, newRoom);
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
        var roomNumber = ConsoleUtils.ReadInt();
        
        if (GetDates(out var checkIn, out var checkOut)) return;
        //Checks if the room is available with the input from users
        if (CheckForAvailability(roomNumber, checkIn, checkOut))
        {
            Console.WriteLine("Room is available, Would you like to book?");
            Console.WriteLine("Y/N");
            string choice =  ConsoleUtils.ReadString();
            if (choice.ToLower() == "y")
            {
                //If it's available it will add all the inputs to the Reservation Dictionary
                var newReservation = new Reservation
                {
                    RoomNumber = roomNumber,
                    CheckIn = checkIn,
                    CheckOut = checkOut
                    //Guest = guest;
                };
                //Adds into the Dictionary
                Reservations.Add(newReservation.ReservationId, newReservation);

                Console.WriteLine($"Your room {roomNumber} is booked from {checkIn} to  {checkOut}");
            }
            else
            {
                Console.WriteLine("Booking was cancelled");
            }
            
        }
        else
        {
            Console.WriteLine("The room was booked the selected date, please try another room");
        }
    }

    private static bool GetDates(out DateTime checkIn, out DateTime checkOut)
    {
        Console.WriteLine("What date do you wanna check in? (YYYY-MM-DD)");
        var checkInFromUser = ConsoleUtils.ReadDateTime();
        
        Console.WriteLine("What date do you wanna check out? (YYYY-MM-DD)");
        var checkOutFromUser = ConsoleUtils.ReadDateTime();
        //Adds so checkin is at 15:00 and checkout is 11:00
        checkIn = checkInFromUser.Date.AddHours(15);
        checkOut = checkOutFromUser.Date.AddHours(11);
        if (checkOut <= checkIn)
        {
            Console.WriteLine("Check out date cant be before check in date");
            return true;
        }

        return false;
    }

    public bool CheckForAvailability(int roomNumber, DateTime checkIn, DateTime checkOut)
    {
        //Checks if the check-in and check-out is clear for booking.
        bool checkingIfRoomIsBooked = Reservations.Any(reservation =>
            reservation.Value.RoomNumber == roomNumber &&
            (checkIn.Date < reservation.Value.CheckOut) &&
            (checkOut.Date > reservation.Value.CheckIn));
        
        return !checkingIfRoomIsBooked;
    }

    public List<string> ShowAvailableRooms()
    {
        if (GetDates(out var checkIn, out var checkOut))
        {
            return new List<string>();
        }
        var availableRoom = Rooms.Values.
            Where(room => CheckForAvailability(room.RoomNumber, checkIn, checkOut))
            .Select(s => $"{s.RoomNumber} is available")
            .ToList();
        return availableRoom;
    }
}

