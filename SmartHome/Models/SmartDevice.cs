using SmartHome.Interfaces;

namespace SmartHome.Models;

public abstract class SmartDevice : ISmartDevice
{
    public string Name { get; protected set; }
    protected bool IsOn = false;
    protected SmartDevice(string name)
    {
        Name = name;
    }

    public virtual void TurnOn()
    {
        Console.WriteLine($"{Name} sattes på");
    }

    public virtual void TurnOff()
    {
        Console.WriteLine($"{Name} stängdes av");
    }
}