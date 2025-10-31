using System.Globalization;

namespace HotelBooking;

public class Hotel
{
    public Dictionary<int, Room> Rooms { get; set; }
    public Dictionary <string, List<Reservation>> Reservations { get; set; }
    private double _totalEarnings;
    public Hotel()
    {
        Reservations = new Dictionary<string, List<Reservation>>();
        Rooms = new Dictionary<int, Room>();
        CreateRooms();
        AddPriceClass(Rooms.Values.ToList());
    }
        // Creates room from 101 to 509 (45 total)
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
                1 or 2 => 6000,
                3 or 4 => 6500,
                5 => 7000,
                _ => 5000
                //Used Riders suggestion for nicer switch template.
            };
        }
    }

    public void CreateReservation(Guest guest)
    {
        Console.WriteLine("What room number would you like to reserve?");
        Console.WriteLine("Room numbers go from 101 to 509 (1-9)");
        var roomNumber = ConsoleUtils.ReadInt();
        
        var room = GetRoomByNumber(roomNumber);
        if (room == null)
        {
            //Quick check to see if the room even exist
            Console.WriteLine("That room does not exist.");
            return;
        }
        //Gets the dates from the user when it wants to stay
        if (GetDates(out var checkIn, out var checkOut)) return;
        
        //Projects and writes out the cost of the room for selected days
        var costOfRoom = Room.RoomPriceAdjuster(room, checkIn, checkOut);
        Console.WriteLine($"It will cost {costOfRoom} for {Math.Round((checkOut - checkIn).TotalDays), 2} days");
        
        //Checks if the room is available with the input from users
        if (CheckForAvailability(roomNumber, checkOut, checkIn))
        {
            Console.WriteLine("Room is available, Would you like to book?");
            Console.WriteLine("Y/N");
            string choice =  ConsoleUtils.ReadString();
            if (choice.ToLower() == "y")
            {
                _totalEarnings += costOfRoom;
                //If it's available it will add all the inputs to the Reservation Dictionary
                var key = guest.Email.ToLower();
                var newReservation = new Reservation
                {
                    RoomNumber = roomNumber,
                    CheckIn = checkIn,
                    CheckOut = checkOut,
                    GuestInformation = guest,
                    CostOfReservation = costOfRoom,
                };
                //Adds the guest email number as a key to search for.
                //its Dictionary<Users email, List<Reservations by that User>>
                if (!Reservations.ContainsKey(key))
                {
                    Reservations[key] = new List<Reservation>();
                }

                //Add the reservation to the list (key : email , booking info : list of reservation
                Reservations[key].Add(newReservation);

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
    
    private Room GetRoomByNumber(int roomNumber)
    {
        return Rooms.TryGetValue(roomNumber, out var room) ? room : null;
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
            Console.WriteLine("Please try again");
            return true;
        } else if (checkIn < DateTime.Now) {
            Console.WriteLine("Check in can't be before the current date");
            Console.WriteLine("Please try again");
            return true;
        }

        return false;
    }

    public bool CheckForAvailability(int roomNumber, DateTime checkIn, DateTime checkOut)
    {
        //Checks if the check-in and check-out is clear for booking.
        bool checkingIfRoomIsBooked = Reservations.Values
            .SelectMany(reservationList => reservationList)
            .Any(reservation =>
                reservation.RoomNumber == roomNumber &&
                (checkIn < reservation.CheckOut) &&
                (checkOut > reservation.CheckIn));

        return !checkingIfRoomIsBooked;
    }

    public List<string> ShowAvailableRooms()
    {
        //Secures the right input for dates
        if (GetDates(out var checkIn, out var checkOut))
        {
            //If not available returns an empty string
            //Can change this to "No rooms available on selected date" or "wrong input, please try again"
            return new List<string>();
        }
        //Writes out all the available rooms 
        var availableRoom = Rooms.Values.
            Where(room => CheckForAvailability(room.RoomNumber, checkIn, checkOut))
            .Select(s => $"{s.RoomNumber} is available")
            .ToList();
        return availableRoom;
    }

    public List<string>ShowReservationForGuest(Guest guest)
    {
            var key = guest.Email.ToLower();
            if (!Reservations.ContainsKey(key))
                return new List<string> { "No reservations for this guest" };

            return Reservations[key]
                .Select(r => $"Room {r.RoomNumber} booked\nfrom {r.CheckIn}\nto {r.CheckOut}\n----------------------------------------------------")
                .ToList();
    }

    public void CancelBooking(Guest guest)
    {
        var key = guest.Email.ToLower();
        if (Reservations.TryGetValue(key, out List<Reservation>? value))
        {
            Console.WriteLine("Lista över dina bokningar: ");
            for (int i = 0; i < value.Count; i++)
            {
                var s = value[i];
                Console.WriteLine($"{i + 1}. RoomNumber: {s.RoomNumber}");
                Console.WriteLine($"   Check-in: {s.CheckIn}");
                Console.WriteLine($"   Check-out: {s.CheckOut}");
                Console.WriteLine("----------------------------------------------------");
            } 

            Console.WriteLine("Would you like to remove a booking?");
            Console.WriteLine("Y/N");
            var choice = ConsoleUtils.ReadString();
            if (choice.ToLower() == "y")
            {
                Console.WriteLine("Enter the number of the booking you want to remove:");
                int index = ConsoleUtils.ReadInt();
                
                if (Reservations[key].Count == 1)
                {
                    var roomCost = Reservations[key][index - 1].CostOfReservation;
                    _totalEarnings -= roomCost;
                    Reservations.Remove(key);
                }
                else if (index > 0 && index <= Reservations[key].Count)
                {
                    var roomCost = Reservations[key][index - 1].CostOfReservation;
                    _totalEarnings -= roomCost;
                    Reservations[key].RemoveAt(index - 1);
                    Console.WriteLine("Booking removed successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }
        }
        else
        {
            Console.WriteLine("We found no bookings under your name");
        }
    }

    public void CheckAllBookings()
    {
        foreach (var key in Reservations.Values)
        {
            foreach (var reservation in key)
            {
                Console.WriteLine($"Reservation ID: {reservation.ReservationId}");
                Console.WriteLine($"Room: {reservation.RoomNumber}");
                Console.WriteLine($"Guest: {reservation.GuestInformation.Name}");
                Console.WriteLine($"Check-in: {reservation.CheckIn}");
                Console.WriteLine($"Check-out: {reservation.CheckOut}");
                Console.WriteLine("-----------------------------");
            }
        }

        Console.WriteLine($"Total bookings = {Reservations.Values.Count}");
    }

    public void TotalEarnings()
    {
        Console.WriteLine($"The hotel has earned {_totalEarnings:C2}\non {Reservations.Values.Count} bookings");
    }
}

