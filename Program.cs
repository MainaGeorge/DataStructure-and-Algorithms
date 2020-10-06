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
            linked.AddLast(8);
            linked.AddLast(9);
            linked.AddLast(10);
            linked.AddLast(11);
            linked.PrintValues();
            
            Console.WriteLine(linked.GetNthNodeFromEnd(6).Value + "4");



            Console.WriteLine($"the list has {linked.Size} elements");



        }


    }

}
