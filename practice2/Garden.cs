using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac2
{
    public class Garden : IGarden
    {
        private List<Fruit> _plants;
        public Garden()
        {
            _plants = new List<Fruit>();
        }
        public void AddPlant(Fruit fruit)
        {
            _plants.Add(fruit);
        }
        public void ShowPlants()
        {
            Console.WriteLine("\n--- В саду растет: ---");
            foreach (var plant in _plants)
            {
                (Weight w, string s) = plant;
                Console.WriteLine($"Растение: {s}, Вес: {w}");
            }
            Console.WriteLine("----------------------\n");
        }
    }
}
