namespace HotelBooking;

public class Reservation
{
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int RoomNumber { get; set; }
    public Guest GuestInformation { get; set; }
}