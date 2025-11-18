using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Console.Part2
{
    public class Employee : Person, IWorker
    {
        public string Company { get; set; }
        public string Position { get; set; }
        public Employee(string n, int a, string c, string p) : base(n, a) { Company = c; Position = p; }
        public void Work() => Console.WriteLine($"{Name} работает в {Company}.");
        public override void ShowInfo() { base.ShowInfo(); Console.WriteLine($"  Компания: {Company}, Должность: {Position}"); }
        public override string ToString() => $"{base.ToString()}, Компания: {Company}";
    }
}
