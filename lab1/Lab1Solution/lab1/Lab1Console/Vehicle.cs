using System;
using System.Collections.Generic;

namespace Lab1Console
{
    public class Vehicle
    {
        public string Name { get; set; }

        public Vehicle(string name)
        {
            Name = name;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Vehicle: {Name}");
        }
    }

    public class ElectricScooter : Vehicle
    {
        public ElectricScooter(string name) : base(name) { }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Electric Scooter: {Name}");
        }
    }

    public class Car : Vehicle
    {
        public Car(string name) : base(name) { }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Car: {Name}");
        }
    }

    public class VehicleManager
    {
        private List<Vehicle> vehicles = new List<Vehicle>();

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public void RemoveVehicle(int index)
        {
            if (index >= 0 && index < vehicles.Count)
            {
                vehicles.RemoveAt(index);
            }
        }

        public void DisplayAllVehicles()
        {
            foreach (var vehicle in vehicles)
            {
                vehicle.DisplayInfo();
            }
        }

        public int VehicleCount => vehicles.Count;
    }
}
