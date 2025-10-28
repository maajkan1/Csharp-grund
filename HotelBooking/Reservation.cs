namespace HotelBooking;

public class Reservation
{
    private readonly int _nextId = 1;
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int RoomNumber { get; set; }
    public int ReservationId { get; set; }
    public Guest GuestInformation { get; set; }

    public Reservation()
    {
        ReservationId = _nextId++;
    }
}