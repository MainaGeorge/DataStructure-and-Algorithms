using System;
using MoshDataStructures;

namespace dojo
{
    internal class Program
    {
        private static void Main()
        {
            var arrayQueue = new ArrayQueue<int>();
            arrayQueue.Enqueue(10);
            arrayQueue.Enqueue(20);
            arrayQueue.Enqueue(30);

            arrayQueue.Dequeue();
            arrayQueue.Dequeue();
            // Console.WriteLine(arrayQueue.Size);

            arrayQueue.Enqueue(40);
            arrayQueue.Enqueue(50);
            arrayQueue.Enqueue(60);
            arrayQueue.Enqueue(70);
            arrayQueue.Dequeue();
            // Console.WriteLine(arrayQueue.Size);



            // Console.WriteLine(arrayQueue);
            // Console.WriteLine(arrayQueue.Peek());


            foreach (var elem in arrayQueue)
            {
                Console.WriteLine(elem);
            }
        }


    }

}
