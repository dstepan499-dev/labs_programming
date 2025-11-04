using System;
using System.Collections;

namespace CollectionsPractice
{
    public static class Task1
    {
        public static void Execute()
        {
            ArrayList arrayList = new ArrayList();
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                arrayList.Add(random.Next(1, 101));
            }
            Console.WriteLine("Коллекция после добавления 5 случайных чисел:");
            CollectionHelper.PrintCollection(arrayList);

            arrayList.Add("some string");
            Console.WriteLine("\nКоллекция после добавления строки:");
            CollectionHelper.PrintCollection(arrayList);

            arrayList.Remove("some string");

            Console.WriteLine($"\nТекущее количество элементов: {arrayList.Count}");
            Console.WriteLine("Коллекция после удаления:");
            CollectionHelper.PrintCollection(arrayList);

            int valueToSearch = (int)arrayList[2];
            bool contains = arrayList.Contains(valueToSearch);
            Console.WriteLine($"\nПоиск значения {valueToSearch} в коллекции. Результат: {(contains ? "Найдено" : "Не найдено")}");
        }
    }
}
