using System;

namespace Lab1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleManager manager = new VehicleManager();

            manager.AddVehicle(new ElectricScooter("Xiaomi M365"));
            manager.AddVehicle(new ElectricScooter("Segway Ninebot"));
            manager.AddVehicle(new Car("Tesla Model 3"));

            manager.DisplayAllVehicles();

            Console.ReadKey();
        }
    }
}
