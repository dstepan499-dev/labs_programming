using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public class Vehicle : IComparable<Vehicle>, ICloneable
{
    public string Name { get; set; }

    public Vehicle(string name)
    {
        Name = name;
    }

    public int CompareTo(Vehicle other)
    {
        if (other == null) return 1;
        return string.Compare(this.Name, other.Name, StringComparison.Ordinal);
    }

    public object Clone()
    {
        return new Vehicle(this.Name);
    }

    public override string ToString()
    {
        return $"Vehicle: {Name}";
    }
}

public class ElectricScooter : Vehicle
{
    public ElectricScooter(string name) : base(name) { }

    public override string ToString()
    {
        return $"Electric Scooter: {Name}";
    }
}

public class Car : Vehicle
{
    public Car(string name) : base(name) { }

    public override string ToString()
    {
        return $"Car: {Name}";
    }
}

public class VehicleComparer : IComparer<Vehicle>
{
    public int Compare(Vehicle x, Vehicle y)
    {
        if (x == null || y == null)
        {
            return 0;
        }
        return x.Name.Length.CompareTo(y.Name.Length);
    }
}
