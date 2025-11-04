using System;
using System.Collections;

namespace CollectionsPractice
{
    public static class CollectionHelper
    {
        public static void PrintCollection(IEnumerable collection)
        {
            int i = 0;
            foreach (var item in collection)
            {
                Console.WriteLine($"  [{i++}]: {item}");
            }
        }
    }
}
