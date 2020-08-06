using System;
using System.Collections.Generic;
using System.Linq;

namespace dojo
{
    internal class Program
    {
        private static void Main()
        {
            var stack = new StackImplementation();
            stack.Push(8);
            stack.Push(12);

            var queue = new QueueImplementation();
            queue.Enqueue(6);
            queue.Enqueue(9);
            queue.Enqueue(80);

            Console.WriteLine("first value in queue " + queue.Peek.Value);
            Console.WriteLine("removed from queue " + queue.Dequeue.Value);

            Console.WriteLine("elements in queue " + queue.Count);

            var removed = stack.Pop;

            var next = stack.Peek;
            Console.WriteLine($"next in line : {next.Value}");
            Console.WriteLine($"deleted : {removed.Value}");

        }

        
    }

}
