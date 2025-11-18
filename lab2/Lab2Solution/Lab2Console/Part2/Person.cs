using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Console.Part2
{
    public abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        protected Person(string name, int age) { Name = name; Age = age; }
        public virtual void ShowInfo() => Console.WriteLine($"Персона: {Name}, Возраст: {Age}");
        public override string ToString() => $"Тип: {GetType().Name}, Имя: {Name}";
        public override bool Equals(object obj) => obj is Person p && Name == p.Name && Age == p.Age;
        public override int GetHashCode() => (Name, Age).GetHashCode();
    }
}

