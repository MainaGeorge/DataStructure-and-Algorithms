using System;

namespace dojo
{
    internal class Program
    {
        private static void Main()
        {
            var arr = new[] { 8, 7, 9, 3, 4, 5 };
            // ArrayProblems.LeftCircularRotation(arr);

            // ArrayProblems.RightCircularRotation(arr);

            // ArrayProblems.FindLargestNumberCombinationInAnArray(arr);
            var largest = ArrayProblems.GetTheBiggestByValueCombinationOfGivenIntegers(112345);
            Console.WriteLine(largest);
        }


    }

}
