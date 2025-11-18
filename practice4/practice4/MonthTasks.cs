using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Linq;

namespace practice4
{
    public static class MonthTasks
    {
        public static void Execute()
        {
            Console.WriteLine("Задание 1\n");

            string[] months = {
                "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            };

            int n = 4;
            Console.WriteLine($"1. Месяцы с длиной названия равной {n}:");
            var monthsWithLengthN = months.Where(m => m.Length == n);
            Console.WriteLine("   " + string.Join(", ", monthsWithLengthN) + "\n");

            Console.WriteLine("2. Летние и зимние месяцы:");
            string[] summerMonths = { "June", "July", "August" };
            string[] winterMonths = { "December", "January", "February" };
            var seasonMonths = months.Where(m => summerMonths.Contains(m) || winterMonths.Contains(m));
            Console.WriteLine("   " + string.Join(", ", seasonMonths) + "\n");

            Console.WriteLine("3. Месяцы в алфавитном порядке:");
            var sortedMonths = months.OrderBy(m => m);
            Console.WriteLine("   " + string.Join(", ", sortedMonths) + "\n");

            Console.WriteLine("4. Количество месяцев с буквой 'u' и длиной >= 4:");
            int countMonths = months.Count(m => m.Contains("u", StringComparison.OrdinalIgnoreCase) && m.Length >= 4);
            Console.WriteLine("   " + countMonths + "\n");
        }
    }
}
