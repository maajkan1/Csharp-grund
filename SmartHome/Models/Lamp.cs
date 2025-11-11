namespace SmartHome.Models;

public class Lamp : SmartDevice
{
    public int LightBulbProcent { get; set; }

    public Lamp(string name) : base(name)
    {
        LightBulbProcent = 100;
    }

    public override void TurnOn()
    {
        if (IsOn)
        {
            Console.WriteLine($"{Name} är redan på");
            return;
        }

        if (LightBulbProcent == 0)
        {
            Console.WriteLine("Du måste byta glödlampan innan du kan sätta på igen.");
                return;
        }

        Console.WriteLine($"{Name} sattes på");
        LightBulbProcent -= 1;
        IsOn = true;
        
    }
    public override void TurnOff()
    {
        if (!IsOn)
        {
            Console.WriteLine($"{Name} är redan avstängd");
            return;
        }
        Console.WriteLine($"{Name} stängdes av");
        IsOn = false;
    }
}