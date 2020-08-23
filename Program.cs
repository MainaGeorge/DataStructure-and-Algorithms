using System;

namespace dojo
{
    internal class Program
    {
        private static void Main()
        {
            // Console.WriteLine(StringProblems.MakeString('a', "bcd", "bcd".Length));
            Console.WriteLine(StringProblems.GetSubstrings("oliver"));

            var linked = new GenericLinkedListImplementation<string>();

            linked.AddNode("dad");
            linked.AddNode("mom");
            linked.AddNode("son");
            linked.AddNode("daughter");

            linked.ShowMembers();
            linked.RemoveAt(2);
            linked.ShowMembers();
        }


    }

}
