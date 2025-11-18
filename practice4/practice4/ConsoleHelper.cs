using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice4
{
    public static class ConsoleHelper
    {
        public static void PrintQueryResult<T>(string title, IEnumerable<T> collection)
        {
            Console.WriteLine(title);
            if (!collection.Any())
            {
                Console.WriteLine("   Результатов не найдено.");
            }
            else
            {
                foreach (var item in collection)
                {
                    Console.WriteLine("   " + item);
                }
            }
            Console.WriteLine();
        }
    }
}
