using practice4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice4
{
    public static class StudentTasks
    {
        public static void Execute()
        {
            Console.WriteLine("Задания 3 и 4\n");

            var students = new List<Student>
            {
                new Student("Иванов", "Иван", "Иванович", new DateTime(2004, 5, 15), 3, "ИТ-31"),
                new Student("Петров", "Сергей", "Александрович", new DateTime(2005, 8, 22), 2, "ЭК-22"),
                new Student("Сидорова", "Анна", "Владимировна", new DateTime(2003, 1, 10), 4, "ПИ-41"),
                new Student("Кузнецов", "Дмитрий", "Сергеевич", new DateTime(2004, 11, 30), 3, "ИТ-31"),
                new Student("Смирнова", "Ольга", "Олеговна", new DateTime(2006, 3, 5), 1, "ПИ-11"),

                new Student("Козлов", "Никита", "Дмитриевич", new DateTime(2005, 10, 11), 2, "ЭК-22"),
                new Student("Павлова", "Алина", "Александровна", new DateTime(2004, 6, 23), 3, "ИТ-31"),
                new Student("Семенов", "Егор", "Андреевич", new DateTime(2003, 3, 17), 4, "ПИ-41")
            };

            int targetCourse = 3;
            ConsoleHelper.PrintQueryResult($"1. Студенты {targetCourse} курса:", students.Where(s => s.Course == targetCourse));

            Console.WriteLine("2. Самый молодой студент:");
            var youngestStudent = students.OrderByDescending(s => s.DateOfBirth).FirstOrDefault();
            Console.WriteLine("   " + (youngestStudent?.ToString() ?? "Не найдено"));
            Console.WriteLine();

            string targetGroup = "ЭК-22";
            int countInGroup = students.Count(s => s.Group == targetGroup);
            Console.WriteLine($"3. Количество студентов в группе {targetGroup}: {countInGroup}\n");

            string targetName = "Иван";
            var studentByName = students.FirstOrDefault(s => s.FirstName == targetName);
            Console.WriteLine($"4. Первый студент с именем '{targetName}':");
            Console.WriteLine("   " + (studentByName?.ToString() ?? "Не найдено"));
            Console.WriteLine();

            ConsoleHelper.PrintQueryResult("5.1. Список студентов, отсортированный по фамилии (А-Я):", students.OrderBy(s => s.LastName));
            ConsoleHelper.PrintQueryResult("5.2. Список студентов, отсортированный по фамилии (Я-А):", students.OrderByDescending(s => s.LastName));
        }
    }
}

