using System;
using System.Collections.Generic;
using System.Linq;

namespace dojo
{
    public static class SortingAlgorithms
    {
        public static IList<int> BubbleSort(IList<int> source)
        {
            var arrLength = source.Count;
            for (var i = 0; i < arrLength; i++)
            {
                for (var j = 0; j < arrLength - 1; j++)
                {
                    if (source[j] > source[j + 1])
                    {
                        SwapTwoElementsInAnArray(source, j, j + 1);
                    }
                }
            }

            return source;
        }
        private static void SwapTwoElementsInAnArray(IList<int> source, int firstIndex, int secondIndex)
        {
            if (firstIndex >= source.Count || secondIndex >= source.Count || firstIndex < 0 || secondIndex < 0)
            {
                throw new ArgumentException("indices can not be larger than the size of array or less than 0");
            }

            var temp = source[firstIndex];
            source[firstIndex] = source[secondIndex];
            source[secondIndex] = temp;
        }
        public static IList<int> MergeSortAlgorithm(int[] source)
        {
            if (source.Length == 1)
            {
                Console.WriteLine(string.Join(' ', source));
                return source;
            }

            Console.WriteLine(string.Join(' ', source));

            var midPoint = (int)Math.Floor(source.Length / 2.0);

            return MergeTwoSortedArrays(MergeSortAlgorithm(source[0..midPoint]), MergeSortAlgorithm(source[midPoint..]));
        }
        private static IEnumerable<int> MergeTwoArrays(IList<int> left, IList<int> right)
        {
            var result = new List<int>();

            while (left.Any() && right.Any())
            {
                if (left[0] < right[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            result = AddElementsToAnArray(result, left);
            result = AddElementsToAnArray(result, right);

            return result;
        }

        private static List<int> AddElementsToAnArray(List<int> source, IList<int> toTransfer)
        {
            if (!toTransfer.Any()) return source;

            source.AddRange(toTransfer);

            return source;
        }

        public static IList<int> MergeTwoSortedArrays(IList<int> first, IList<int> second)
        {
            var resultArray = new List<int>();
            var firstArrayIndex = 0;
            var secondArrayIndex = 0;

            while (firstArrayIndex < first.Count && secondArrayIndex < second.Count)
            {
                if (first[firstArrayIndex] <= second[secondArrayIndex])
                {
                    resultArray.Add(first[firstArrayIndex]);
                    firstArrayIndex++;
                }
                else
                {
                    resultArray.Add(second[secondArrayIndex]);
                    secondArrayIndex++;
                }

            }

            AddRemainingElementsToSortedArray(resultArray, first, firstArrayIndex);
            AddRemainingElementsToSortedArray(resultArray, second, secondArrayIndex);

            return resultArray;
        }

        private static void AddRemainingElementsToSortedArray(ICollection<int> destination, IList<int> source,
            int indexToStartFrom)
        {
            while (indexToStartFrom < source.Count)
            {
                destination.Add(source[indexToStartFrom]);
                indexToStartFrom++;
            }
        }


    }
}
