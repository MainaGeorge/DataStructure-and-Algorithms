using System;
using MoshDataStructures;

namespace dojo
{
    internal class Program
    {
        private static void Main()
        {
            var dynamic = new DynamicArray<int>(3);
            var dynamic2 = new DynamicArray<int>(5);
            var comp = new[] { 1, 12, 13, 4, 5 };
            dynamic.Insert(1);
            dynamic.Insert(2);
            dynamic.Insert(3);

            dynamic.InsertAt(0, 4);
            dynamic.Insert(5);
            dynamic2.Insert(45);
            dynamic2.Insert(10);
            dynamic2.Insert(5);
            dynamic2.Insert(4);
            dynamic2.Insert(32);
            dynamic2.Insert(13);

            Console.WriteLine(string.Join(" ", dynamic2.Intersect(comp)));

        }


    }

}
