using System;

namespace dojo
{
    internal class Program
    {
        private static void Main()
        {
            var tree = new BinaryTree();

            tree.Add(10);
            tree.Add(15);
            tree.Add(8);
            tree.Add(6);
            tree.Add(4);
            tree.Add(12);
            tree.Add(22);

            tree.PrintInOrder();

            Console.WriteLine("\nprinting pre-order");
            tree.PrintPreOrder();

            Console.WriteLine("\nprinting post-order");
            tree.PrintPostOrder();
        }


    }

}
