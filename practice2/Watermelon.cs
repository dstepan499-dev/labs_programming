using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac2
{
    public class Watermelon : Fruit
    {
        private int _quantityOfSlices;
        public readonly string BotanicalName = "Citrullus lanatus";
        public int Quantity
        {
            get { return _quantityOfSlices; }
            set
            {
                if (value < 0) _quantityOfSlices = 0;
                else _quantityOfSlices = value;
            }
        }
        public bool IsTasty { get; private set; }
        public Watermelon(double weight, WatermelonSort sort, int slices)
            : base(weight, sort.ToString())
        {
            Quantity = slices;
            IsTasty = true;
        }
        public Watermelon(double weight)
            : base(weight, WatermelonSort.SugarBaby.ToString())
        {
            Quantity = 1;
            IsTasty = true;
        }
        public void Cut(int slices)
        {
            if (slices <= 0)
            {
                Console.WriteLine("Нельзя порезать на 0 или отрицательное число кусков.");
                return;
            }
            Quantity += slices;
            Console.WriteLine($"Арбуз порезан! Теперь кусочков: {Quantity}");
        }
        public void Eat(int amountToEat)
        {
            if (amountToEat > Quantity)
            {
                Console.WriteLine("Нельзя съесть больше, чем есть!");
                Quantity = 0;
            }
            else
            {
                Quantity -= amountToEat;
                Console.WriteLine($"Ням-ням. Осталось кусочков: {Quantity}");
            }
        }
        public void Knock()
        {
            if (FruitWeight.ValueKg > 5)
                Console.WriteLine("*Глухой звук* (Звучит как спелый!)");
            else
                Console.WriteLine("*Звонкий звук* (Возможно, еще зеленый)");
        }
        public override string ToString()
        {
            return $"Арбуз сорта {Sort} ({BotanicalName}). Вес: {FruitWeight}. Кусочков: {Quantity}.";
        }
        public static Watermelon operator +(Watermelon w1, Watermelon w2)
        {
            double newWeight = w1.FruitWeight.ValueKg + w2.FruitWeight.ValueKg;
            return new Watermelon(newWeight, WatermelonSort.Unknown, w1.Quantity + w2.Quantity);
        }
        public static Watermelon operator *(Watermelon w, double growthFactor)
        {
            return new Watermelon(w.FruitWeight.ValueKg * growthFactor, WatermelonSort.Unknown, w.Quantity);
        }
    }
}
