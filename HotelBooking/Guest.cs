namespace HotelBooking;

public class Guest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public Guest GetGuestInfo()
    {
        Console.WriteLine("Welcome to Hotel Imaginary");
        Console.WriteLine("Please enter your name:");
        var name = ConsoleUtils.ReadString();
        Console.WriteLine("Please enter your email:");
        var email = ConsoleUtils.ReadString();
        Console.WriteLine("Please enter your phone:");
        var phone = ConsoleUtils.ReadString();
        return new Guest { Name = name, Email = email, Phone = phone };
    }
}