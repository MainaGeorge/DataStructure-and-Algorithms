using System;

namespace dojo
{
    internal class Program
    {
        private static void Main()
        {
            var queue = new GenericQueueImplementationUsingTwoStacks<string>();
            queue.Enqueue("mother");
            queue.Enqueue("father");
            queue.Enqueue("daughter");
            queue.Enqueue("son");


            // Console.WriteLine($"the queue has {queue.Count} elements");

            Console.WriteLine($"The next element to be dequeued is {queue.Peek().Value}");
            queue.ShowMembers();

        }


    }

}
