using System;
using System.Collections.Generic;
using System.Text;

namespace dojo
{
    public static class ArrayProblems
    {
        public static int[] LeftCircularRotation(int[] source)
        {
            var firstElement = source[0];

            for (var i = 1; i < source.Length; i++)
            {
                source[i - 1] = source[i];
            }

            source[^1] = firstElement;

            Console.WriteLine(string.Join(" ", source));
            return source;
        }

        public static int[] RightCircularRotation(int[] source)
        {
            var lastElement = source[^1];

            for (var i = source.Length - 1; i > 0; i--)
            {
                source[i] = source[i - 1];
            }

            source[0] = lastElement;
            Console.WriteLine(string.Join(' ', source));

            return source;
        }

        private static int MakeAnInt(IEnumerable<int> source)
        {
            var result = new StringBuilder();
            foreach (var st in source)
            {
                result.Append(st);
            }

            return int.Parse(result.ToString());
        }
        public static int FindLargestNumberCombinationInAnArray(int[] source)
        {
            var counter = 0;
            var maxCombination = MakeAnInt(source);

            Console.WriteLine(string.Join(' ', source));
            Console.WriteLine($"current max value is {maxCombination}");


            while (counter < source.Length)
            {
                source = RightCircularRotation(source);
                var numericValueOfNumbers = MakeAnInt(source);

                if (numericValueOfNumbers > maxCombination)
                {
                    maxCombination = numericValueOfNumbers;
                }

                counter++;

                Console.WriteLine($"current max value is {maxCombination}");

            }

            return maxCombination;
        }

        private static int CalculateArraySize(int numbers)
        {
            var lengthOfArray = 0;

            while (numbers > 0)
            {
                lengthOfArray++;
                numbers /= 10;
            }

            return lengthOfArray;
        }

        private static int[] MakeArrayFromIntegers(int numbers)
        {
            var length = CalculateArraySize(numbers);
            var resultArray = new int[length];

            for (var i = 0; i < length; i++)
            {
                resultArray[i] = numbers % 10;
                numbers /= 10;
            }

            return resultArray;
        }

        public static int GetTheBiggestByValueCombinationOfGivenIntegers(int numbers)
        {
            return FindLargestNumberCombinationInAnArray(MakeArrayFromIntegers(numbers));
        }
    }
}
