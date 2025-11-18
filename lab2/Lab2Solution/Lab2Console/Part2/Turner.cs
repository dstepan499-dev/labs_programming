using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Console.Part2
{
    public sealed class Turner : Employee
    {
        public int Rank { get; set; }
        public Turner(string n, int a, string c, int r) : base(n, a, c, "Токарь") { Rank = r; }
        public override void ShowInfo() { base.ShowInfo(); Console.WriteLine($"  Разряд: {Rank}"); }
        public override string ToString() => $"{base.ToString()}, Разряд: {Rank}";
    }
}

