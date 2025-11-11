using SmartHome.Models;

namespace SmartHome;

class Program
{
    static void Main(string[] args)
    {
        // var dishWasher = new Dishwasher("Diskmaskin", 1234567124356);
                                     // dishWasher.TurnOn();
                                     // Console.WriteLine(dishWasher.ProgramDuration);
                                     // Thread.Sleep(5000);
                                     // dishWasher.GetRemainingTimeLeft();
                                     // Thread.Sleep(5000);
                                     // dishWasher.TurnOff();
                                     // Console.ReadKey();
        var lampBasement = new Lamp("Lamp Basement");
        Console.WriteLine(lampBasement.LightBulbProcent);
        lampBasement.TurnOn();
        lampBasement.TurnOn();
        lampBasement.TurnOff();
        lampBasement.TurnOff();
        lampBasement.TurnOn();
        Console.WriteLine(lampBasement.LightBulbProcent);
    }
}