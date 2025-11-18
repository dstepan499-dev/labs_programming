using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Console.Part2
{
    public class PartTimeStudent : Student, IWorker
    {
        public string Company { get; set; }
        public PartTimeStudent(string n, int a, string i, string m, string c) : base(n, a, i, m) { Company = c; }
        public void Work() => Console.WriteLine($"{Name} совмещает учебу с работой в {Company}.");
        public override void ShowInfo() { base.ShowInfo(); Console.WriteLine($"  Место работы: {Company} (заочник)"); }
        public override string ToString() => $"{base.ToString()}, работает в {Company}";
    }
}
