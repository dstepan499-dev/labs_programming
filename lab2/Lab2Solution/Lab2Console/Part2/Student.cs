using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Console.Part2
{
    public class Student : Person, ILearner
    {
        public string Institution { get; set; }
        public string Major { get; set; }
        public Student(string n, int a, string i, string m) : base(n, a) { Institution = i; Major = m; }
        public void Study() => Console.WriteLine($"{Name} учится в {Institution}.");
        public override void ShowInfo() { base.ShowInfo(); Console.WriteLine($"  Учебное заведение: {Institution}, Специальность: {Major}"); }
        public override string ToString() => $"{base.ToString()}, ВУЗ: {Institution}";
    }

}