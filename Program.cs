using System;
using MoshDataStructures;

namespace dojo
{
    internal class Program
    {
        private static void Main()
        {
            var dict = new DictionaryStructure { [0] = "zero", [4] = "four", [9] = "nine" };

            // dict.Add(9, "nine");
            dict.Add(10, "ten");
            dict.Add(14, "fourteen");
            dict.Add(24, "twenty four");

            Console.WriteLine(string.Join(" ", dict.Keys()));
            Console.WriteLine(string.Join(" ", dict.Values()));
            Console.WriteLine("dict has " + dict.Count + " items");

            dict.Add(24, "twenty five by mistake");
            dict.Remove(10);
            Console.WriteLine(string.Join(" ", dict.Values()));
            Console.WriteLine("dict has " + dict.Count + " items");



            

        }


    }

}
