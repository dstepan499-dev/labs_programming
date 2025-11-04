using System;
using System.Collections.Generic;

namespace CollectionsPractice
{
    public static class Task3
    {
        public static void Execute()
        {
            Queue<Vehicle> vehicleQueue = new Queue<Vehicle>();
            vehicleQueue.Enqueue(new Car("Tesla Model S"));
            vehicleQueue.Enqueue(new ElectricScooter("Xiaomi M365"));
            vehicleQueue.Enqueue(new Car("Audi A6"));
            vehicleQueue.Enqueue(new ElectricScooter("Segway Ninebot"));

            Console.WriteLine("Исходная коллекция Queue<Vehicle>:");
            CollectionHelper.PrintCollection(vehicleQueue);

            vehicleQueue.Dequeue();
            CollectionHelper.PrintCollection(vehicleQueue);

            vehicleQueue.Enqueue(new Car("BMW X5"));
            CollectionHelper.PrintCollection(vehicleQueue);

            List<Vehicle> vehicleList = new List<Vehicle>(vehicleQueue);

            Console.WriteLine("\nВторая коллекция List<Vehicle>:");
            CollectionHelper.PrintCollection(vehicleList);

            var vehicleToSearch = vehicleList[1];
            Console.WriteLine($"\nПоиск элемента '{vehicleToSearch}' выполнен. Результат: {(vehicleList.Contains(vehicleToSearch) ? "Найден" : "Не найден")}");

            Console.WriteLine("\nДемонстрация интерфейсов:");

            Console.WriteLine("\n1. Демонстрация ICloneable");
            Vehicle originalVehicle = vehicleList[0];
            Vehicle clonedVehicle = (Vehicle)originalVehicle.Clone();
            originalVehicle.Name = "CHANGED NAME";
            Console.WriteLine($"Оригинал после изменения: {originalVehicle}");
            Console.WriteLine($"Клон остался без изменений: {clonedVehicle}");

            Console.WriteLine("\n2. Демонстрация IComparable");
            vehicleList.Sort();
            CollectionHelper.PrintCollection(vehicleList);

            Console.WriteLine("\n3. Демонстрация IComparer");
            vehicleList.Sort(new VehicleComparer());
            CollectionHelper.PrintCollection(vehicleList);
        }
    }
}
