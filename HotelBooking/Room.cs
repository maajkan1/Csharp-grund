using System.Security.AccessControl;

namespace HotelBooking;

public class Room
{
    public string RoomType { get; set; }
    public int RoomNumber { get; set; }
    public double RoomPrice { get; set; }

    public Room(int roomNumber)
    {
        RoomNumber = roomNumber;
    }
}