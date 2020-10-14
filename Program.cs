using System;
using MoshDataStructures;

namespace dojo
{
    internal class Program
    {
        private static void Main()
        {
            var prior = new ArrayPriorityQueue();
            prior.Add(10);
            prior.Add(5);
            prior.Add(3);
            prior.Add(12);

            prior.Remove();
            prior.Remove();
            Console.WriteLine(prior.Peek());

            Console.WriteLine(prior);
        }


    }

}
