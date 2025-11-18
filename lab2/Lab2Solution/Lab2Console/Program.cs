using System;

using Lab2Console.Part1;
using Lab2Console.Part2;

namespace Lab2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nЧАСТЬ 1\n");

            string testString = "программирование";
            Console.WriteLine($"Средний символ(ы) в '{testString}': '{testString.GetMiddleCharacter()}'");

            var p = new Password("Test12345");
            Console.WriteLine($"Пароль: {p.Value}, Длина валидна (6-12)? : {p.IsLengthValid()}");

            Console.WriteLine("\n\nЧАСТЬ 2\n");
            Person[] people = new Person[]
            {
                new Student("Иван Петров", 20, "МГУ", "Прикладная математика"),
                new Programmer("Анна Сидорова", 32, "Google", "C#"),
                new Turner("Василий Иванов", 45, "Завод 'Прогресс'", 5),
                new PartTimeStudent("Ольга Кузнецова", 22, "СПбГУ", "Экономика", "Starbucks")
            };

            foreach (var person in people)
            {
                person.ShowInfo();
                Console.WriteLine($"Результат ToString(): {person}");
                if (person is IWorker worker) worker.Work();
                if (person is ILearner learner) learner.Study();
            }
        }
    }
}
