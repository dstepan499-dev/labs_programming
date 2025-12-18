using System;
namespace prac2
{
    class Program
    {
        static void Main(string[] args)
        {
            Watermelon myWatermelon = null;
            Garden myGarden = new Garden();
            while (true)
            {
                Console.WriteLine("1. Создать арбуз (Задание параметров)");
                Console.WriteLine("2. Вывод свойств объекта");
                Console.WriteLine("3. Постучать по арбузу (Метод)");
                Console.WriteLine("4. Порезать арбуз (Метод)");
                Console.WriteLine("5. Съесть кусочки (Метод)");
                Console.WriteLine("6. Тест перегрузки оператора +");
                Console.WriteLine("7. Добавить текущий арбуз в Сад и показать Сад");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите пункт: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Введите вес (кг): ");
                        if (!double.TryParse(Console.ReadLine(), out double w))
                        {
                            Console.WriteLine("Ошибка ввода числа."); break;
                        }
                        Console.WriteLine("Выберите сорт (0-CrimsonSweet, 1-SugarBaby, 2-CharlestonGray): ");
                        if (!int.TryParse(Console.ReadLine(), out int sortIdx))
                        {
                            Console.WriteLine("Ошибка ввода числа."); break;
                        }
                        WatermelonSort sort = (WatermelonSort)sortIdx;
                        Console.Write("Количество начальных кусков: ");
                        if (!int.TryParse(Console.ReadLine(), out int slices))
                        {
                            Console.WriteLine("Ошибка ввода числа."); break;
                        }
                        myWatermelon = new Watermelon(w, sort, slices);
                        Console.WriteLine("Арбуз создан!");
                        break;
                    case "2":
                        if (myWatermelon == null) Console.WriteLine("Сначала создайте арбуз!");
                        else Console.WriteLine(myWatermelon.ToString());
                        break;
                    case "3":
                        if (myWatermelon == null) Console.WriteLine("Сначала создайте арбуз!");
                        else myWatermelon.Knock();
                        break;
                    case "4":
                        if (myWatermelon == null) Console.WriteLine("Сначала создайте арбуз!");
                        else
                        {
                            Console.Write("На сколько частей еще порезать? ");
                            if (int.TryParse(Console.ReadLine(), out int cuts))
                                myWatermelon.Cut(cuts);
                        }
                        break;
                    case "5":
                        if (myWatermelon == null) Console.WriteLine("Сначала создайте арбуз!");
                        else
                        {
                            Console.Write("Сколько кусочков съесть? ");
                            if (int.TryParse(Console.ReadLine(), out int eat))
                                myWatermelon.Eat(eat);
                        }
                        break;
                    case "6":
                        if (myWatermelon == null) Console.WriteLine("Сначала создайте арбуз!");
                        else
                        {
                            Watermelon other = new Watermelon(5.0, WatermelonSort.YellowMellow, 1);
                            Console.WriteLine($"Создан временный арбуз: {other}");
                            Watermelon sumWatermelon = myWatermelon + other;
                            Console.WriteLine("Результат сложения:");
                            Console.WriteLine(sumWatermelon.ToString());
                        }
                        break;
                    case "7":
                        if (myWatermelon == null) Console.WriteLine("Сначала создайте арбуз!");
                        else
                        {
                            myGarden.AddPlant(myWatermelon);
                            myGarden.ShowPlants();
                        }
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;
                }
            }
        }
    }
}
