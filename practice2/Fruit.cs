using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac2
{
    public class Fruit
    {
        public Weight FruitWeight { get; set; }
        public string Sort { get; set; }
        public Fruit(double weight, string sort)
        {
            FruitWeight = new Weight(weight);
            Sort = sort;
        }
        public Fruit()
        {
            FruitWeight = new Weight(0);
            Sort = "Неизвестно";
        }
        public void Deconstruct(out Weight weight, out string sort)
        {
            weight = FruitWeight;
            sort = Sort;
        }
        public virtual void Info()
        {
            Console.WriteLine($"Фрукт: {Sort}, Вес: {FruitWeight}");
        }
    }
}
