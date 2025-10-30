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

    public static double RoomPriceAdjuster(Room room, DateTime checkIn, DateTime checkOut)
    {
        var roomPriceFromWeekToDay = room.RoomPrice / 7.0;
        var totalDaysAtHotel = (checkOut - checkIn).TotalDays;
        var totalCost = roomPriceFromWeekToDay * totalDaysAtHotel;
        return Math.Round(totalCost, 2);
    }
}