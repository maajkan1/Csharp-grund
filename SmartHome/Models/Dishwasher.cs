namespace SmartHome.Models
{
    public class Dishwasher : SmartDevice
    {
        public long SerialNumber { get; set; }
        public DateTime ProgramDuration { get; private set; }

        public Dishwasher(string name, long serialNumber) : base(name)
        {
            SerialNumber = serialNumber;
        }

        public void StartWashingMachine()
        {
            ProgramDuration = DateTime.Now.AddHours(2);
            Console.WriteLine("Ditt program är klart om två timmar.");
        }

        public override void TurnOn()
        {
            Console.WriteLine($"{Name} sattes på");
            StartWashingMachine();
        }

        public override void TurnOff()
        {
            if (ProgramDuration > DateTime.Now)
            {
                Console.WriteLine("Disken är inte klar, men stängs av ändå");
            }
            else
            {
                Console.WriteLine($"{Name} stängdes av");
            }
        }

        public void GetRemainingTimeLeft()
        {
            var remainingTimeLeft = ProgramDuration.Subtract(DateTime.Now);
            Console.WriteLine($"Det är {remainingTimeLeft.TotalMinutes:F0} minuter kvar.");
        }
    }
}