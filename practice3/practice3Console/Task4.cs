using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CollectionsPractice
{
    public static class Task4
    {
        public static void Execute()
        {
            ObservableCollection<Vehicle> observableVehicles = new ObservableCollection<Vehicle>();
            observableVehicles.CollectionChanged += OnCollectionChanged;

            Console.WriteLine("Добавление нового элемента (Car)");
            observableVehicles.Add(new Car("Mersedes CLS63"));

            Console.WriteLine("\nДобавление элемента (ElectricScooter)");
            observableVehicles.Add(new ElectricScooter("Kugoo G1"));

            Console.WriteLine("\nУдаление первого элемента");
            observableVehicles.RemoveAt(0);

            observableVehicles.CollectionChanged -= OnCollectionChanged;
        }

        private static void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine($"[Событие]: В коллекции произошло изменение (Действие: {e.Action})");

            if (e.OldItems != null)
            {
                Console.WriteLine("  Старые элементы:");
                foreach (var item in e.OldItems)
                {
                    Console.WriteLine($"\t- {item}");
                }
            }

            if (e.NewItems != null)
            {
                Console.WriteLine("  Новые элементы:");
                foreach (var item in e.NewItems)
                {
                    Console.WriteLine($"\t- {item}");
                }
            }
        }
    }
}
