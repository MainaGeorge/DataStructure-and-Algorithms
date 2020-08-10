using System.Collections.Generic;

namespace dojo
{
    internal class Program
    {
        private static void Main()
        {
            var iEnum = new List<int>() { 21, -4, 17, 9, 2, 3, -7, 18 };


            UnclassifiedAlgorithms.GetChunksOfArraysFromAGivenArray(iEnum, 4);
            // var arr = new List<int>(iEnum);
            //
            // Console.WriteLine(string.Join(' ', arr.GetRange(0, 4)));
            //
            // var loan = new TestStaticConstructorAndProperties(8000);
            //
            // Console.WriteLine(loan.GetInterest);
            //
            // TestStaticConstructorAndProperties.InterestRate = 6.0;


            // Console.WriteLine(loan.GetInterest);
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
