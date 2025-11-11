namespace SmartHome.Interfaces;

public interface ISmartDevice
{
    public interface ISmartDevice
    {
        string Name { get; }
        bool IsOn { get; }
        void TurnOn();
        void TurnOff();
    }
}