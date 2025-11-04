using System;
using System.Collections.Generic;

namespace CollectionsPractice
{
    public static class Task2
    {
        public static void Execute()
        {
            Queue<int> intQueue = new Queue<int>();
            intQueue.Enqueue(10);
            intQueue.Enqueue(20);
            intQueue.Enqueue(30);
            intQueue.Enqueue(40);
            intQueue.Enqueue(50);

            Console.WriteLine("Исходная коллекция Queue<int>:");
            CollectionHelper.PrintCollection(intQueue);

            int n = 2;
            for (int i = 0; i < n; i++)
            {
                if (intQueue.Count > 0)
                    intQueue.Dequeue();
            }
            Console.WriteLine("Коллекция после удаления:");
            CollectionHelper.PrintCollection(intQueue);

            intQueue.Enqueue(60);
            intQueue.Enqueue(70);
            Console.WriteLine("Коллекция после добавления:");
            CollectionHelper.PrintCollection(intQueue);

            List<int> intList = new List<int>(intQueue);

            Console.WriteLine("\nВторая коллекция List<int>, созданная из Queue<int>:");
            CollectionHelper.PrintCollection(intList);

            int valueToSearch = 40;
            bool found = intList.Contains(valueToSearch);
            Console.WriteLine($"\nПоиск значения {valueToSearch} в List<int>. Результат: {(found ? "Найдено" : "Не найдено")}");
        }
    }
}
