using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Console.Part2
{
    public class Programmer : Employee
    {
        public string ProgrammingLanguage { get; set; }
        public Programmer(string n, int a, string c, string l) : base(n, a, c, "Программист") { ProgrammingLanguage = l; }
        public override void ShowInfo() { base.ShowInfo(); Console.WriteLine($"  Язык программирования: {ProgrammingLanguage}"); }
        public override string ToString() => $"{base.ToString()}, Язык: {ProgrammingLanguage}";
    }
}
