using System;

namespace dojo
{
    internal class Program
    {
        private static void Main()
        {
            var arr = new[] { 21, -4, 17, 9, 2, 3, -7, 18 };

            Console.WriteLine(string.Join(' ',
                SortingAlgorithms.InsertSort(arr)));
            // var tree = new BinaryTree();
            //
            // tree.Add(10);
            // tree.Add(15);
            // tree.Add(8);
            // tree.Add(6);
            // tree.Add(4);
            // tree.Add(12);
            // tree.Add(22);
            //
            // tree.PrintInOrder();
            //
            // Console.WriteLine("\nprinting pre-order");
            // tree.PrintPreOrder();
            //
            // Console.WriteLine("\nprinting post-order");
            // tree.PrintPostOrder();
        }


    }

}
