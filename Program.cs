using System;
using MoshDataStructures;

namespace dojo
{
    internal class Program
    {
        private static void Main()
        {
            var tree = new Tree();

            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(8);
            tree.Insert(10);
            // tree.Insert(14);
            // tree.Insert(12);
            // tree.Insert(15);

            Console.WriteLine("does the sum exist? " + tree.ExistPathLeadingToGivenSum(112));



            var tree2 = new Tree();
            tree2.Insert(7);
            tree2.Insert(4);
            tree2.Insert(9);
            tree2.Insert(3);
            tree2.Insert(6);
            tree2.Insert(8);
            tree2.Insert(10);
            tree2.Insert(11);
            tree2.Insert(12);



            Console.WriteLine("the height is " + tree.Height());
            Console.WriteLine(tree.CountLeaves());

        }


    }

}
