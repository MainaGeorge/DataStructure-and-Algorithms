using System;
using MoshDataStructures;

namespace dojo
{
    internal class Program
    {
        private static void Main()
        {
            var linked = new LinkedLIst<int>();

            linked.AddLast(7);
            // linked.AddFirst(12);
            // linked.RemoveAt(1);
            // linked.InsertAt(1, 8);
            // linked.InsertAt(1, 15);
            // linked.RemoveAt(3);
            linked.PrintValues();
            linked.BetterReverse();
            Console.WriteLine("after reverse");
            linked.PrintValues();


            Console.WriteLine($"the list has {linked.Size} elements");



        }


    }

}
