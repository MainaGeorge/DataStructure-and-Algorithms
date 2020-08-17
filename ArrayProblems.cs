using System;
using System.Collections.Generic;
using System.Linq;
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

        public static void SpiralMatrixAlgorithm(int arrSize)
        {
            // Write a function that accepts an integer N
            // and returns a NxN spiral matrix.
            // --- Examples
            //   matrix(2)
            //     [[1, 2],
            //     [4, 3]]
            //   matrix(3)
            //     [[1, 2, 3],
            //     [8, 9, 4],
            //     [7, 6, 5]]
            //  matrix(4)
            //     [[1,   2,  3, 4],
            //     [12, 13, 14, 5],
            //     [11, 16, 15, 6],
            //     [10,  9,  8, 7]]

            var (lastRowIndex, lastColumnIndex, rowIndex, columnIndex)
                = (arrSize - 1, arrSize - 1, 0, 0);
            var currentIntValue = 1;
            var resultArray = new int[arrSize][];

            for (var i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] = new int[arrSize];
            }

            while (rowIndex <= lastRowIndex && columnIndex <= lastColumnIndex)
            {
                for (var topRowIndex = columnIndex; topRowIndex <= lastColumnIndex; topRowIndex++)
                {
                    resultArray[rowIndex][topRowIndex] = currentIntValue;
                    currentIntValue++;
                }

                rowIndex++;

                for (var rightCornerIndex = rowIndex; rightCornerIndex <= lastRowIndex; rightCornerIndex++)
                {
                    resultArray[rightCornerIndex][lastColumnIndex] = currentIntValue;
                    currentIntValue++;
                }

                lastColumnIndex--;

                for (var bottomRowIndex = lastColumnIndex; bottomRowIndex >= columnIndex; bottomRowIndex--)
                {
                    resultArray[lastRowIndex][bottomRowIndex] = currentIntValue;
                    currentIntValue++;
                }

                lastRowIndex--;

                for (var leftCornerIndex = lastRowIndex; leftCornerIndex >= rowIndex; leftCornerIndex--)
                {
                    resultArray[leftCornerIndex][columnIndex] = currentIntValue;
                    currentIntValue++;
                }

                columnIndex++;
            }

            foreach (var item in resultArray)
            {
                Console.WriteLine(string.Join(' ', item));
            }

        }

        private static int FindMissingNumberInAnArrayOfDistinctConsecutiveElements(IList<int> source)
        {
            //given an array of len n with consecutive distinct numbers up to n in any order, find the missing number
            //u can sort the array and find which number exceeds the previous by more than one, then subtract 1 from it and woila
            //or use gauss law sum of consecutive numbers in an array = len(arr) * (len(arr)+1)/2 

            var lengthArray = source.Contains(0) ? source.Count : source.Count + 1;
            var currentSum = source.Sum();
            var intendedSum = lengthArray * (lengthArray + 1) / 2;


            return intendedSum - currentSum;
        }

        private static int FindMissingNumberInAnArrayIfEachElementOccursTwiceButThatNumber(IList<int> source)
        {
            var setInt = source.Distinct();
            return 2 * setInt.Sum() - source.Sum();
        }

        private static int GreatestSumOfConsecutive(IReadOnlyList<int> source, int consecutive)
        {
            if (source.Count() < consecutive)
            {
                throw new ArgumentException($"array can not have less than {consecutive} elements");
            }

            var initialSum = source.Take(consecutive).Sum();

            for (var j = 0; j < source.Count() - consecutive; j++)
            {
                var currentSum = initialSum + source[j + consecutive] - source[j];
                if (currentSum > initialSum)
                {
                    initialSum = currentSum;
                }
            }

            return initialSum;


        }

        private static bool MountainArray(IList<int> source)
        {
            // array should have more than three elements and the beginning numbers index i=0 
            //     to some index i should be increasing in Value and from that point i to the end
            //     decreasing in Value;
            var arrayLength = source.Count;

            if (arrayLength < 4)
            {
                return false;
            }

            var j = 1;

            while (j < arrayLength && source[j] > source[j - 1])
            {
                j++;
            }

            if (j == 1 || j == arrayLength)
            {
                return false;
            }

            while (j < arrayLength && source[j] < source[j - 1])
            {
                j++;
            }

            return j == arrayLength;
        }

        private static (int, int) FindFirstAndLastOccurenceOfElementInASortedList(IList<int> source, int target)
        {

            if (!source.Contains(target))
            {
                throw new ArgumentException($"the list does not contain {target}");
            }

            var length = source.Count;

            const int left = 0;
            var right = length - 1;

            var firstOccurence = FindFirstOccurrenceOfANumberInASortedList(source, target, left, right);
            var lastOccurence = FindLastOccurenceOfANumberInASortedList(source, target, left, right);

            return (firstOccurence, lastOccurence);


        }
        private static int FindLastOccurenceOfANumberInASortedList(IList<int> source, int target, int left, int right)
        {
            var lastOccurence = -1;

            while (left <= right)
            {

                var mid = (int)Math.Floor((double)(left + (right - left) / 2));

                var currentValue = source[mid];

                if (currentValue == target)
                {
                    if (mid == source.Count - 1 || source[mid + 1] != target)
                    {
                        lastOccurence = mid;
                        break;
                    }
                    else
                    {
                        left = mid + 1;
                    }

                }
                else if (currentValue > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }

            }

            return lastOccurence;
        }
        private static int FindFirstOccurrenceOfANumberInASortedList(IList<int> source, int target, int left, int right)
        {
            var firstOccurence = -1;
            while (left <= right)
            {

                var mid = (int)Math.Floor((left + (right - left) / 2.0));

                var currentValue = source[mid];

                if (currentValue == target)
                {
                    if (mid == 0 || source[mid - 1] != target)
                    {
                        firstOccurence = mid;
                        break;
                    }
                    else
                    {
                        right = mid - 1;
                    }

                }
                else if (currentValue > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }

            }

            return firstOccurence;
        }
        private static string MoveZeroesToTheEnd(IList<int> source)
        {
            // Move all zeroes to the end of a given array while maintaining the order
            //     or elements in the array
            var j = 0;

            foreach (var num in source)
            {
                if (num == 0)
                {
                    continue;
                }

                source[j] = num;
                j++;
            }

            for (var i = j; i < source.Count; i++)
            {
                source[i] = 0;
            }

            return string.Join(' ', source);
        }

        private static (int, int) FindTheIndicesOfFirstTwoElementsThatAddUpToTarget(IList<int> source, int target)
        {
            // Given an array of integers and a number, say target, find the index of two numbers in the array that sum up to the target: 
            // e.g given[1, 3, 4, 5, 6, 7, 8] and 9, you should return 1,4 for the values 3 and 6 that sum up to 9
            // if no such numbers exist return (-1, -1)

            var elementHolders = new Dictionary<int, int>(); // will hold the value of each element and its index

            for (var i = 0; i < source.Count; i++)
            {
                var missingNumber = target - source[i];

                if (elementHolders.ContainsKey(missingNumber))
                {
                    return (elementHolders[missingNumber], i);
                }
                else
                {
                    elementHolders.Add(source[i], i);
                }
            }

            return (-1, -1);
        }

        public static void GetChunksOfArraysFromAGivenArray(List<int> source, int lengthOfArrayChunks)
        {
            // --- Directions
            // Given an array and chunk size, divide the array into many subarrays
            // where each sub array is of length size
            // --- Examples
            // chunk([1, 2, 3, 4], 2) --> [[ 1, 2], [3, 4]]
            // chunk([1, 2, 3, 4, 5], 2) --> [[ 1, 2], [3, 4], [5]]
            // chunk([1, 2, 3, 4, 5, 6, 7, 8], 3) --> [[ 1, 2, 3], [4, 5, 6], [7, 8]]
            // chunk([1, 2, 3, 4, 5], 4) --> [[ 1, 2, 3, 4], [5]]
            // chunk([1, 2, 3, 4, 5], 10) --> [[ 1, 2, 3, 4, 5]]
            var numberOfArraysToBeCreated = (int)Math.Ceiling((double)source.Count / lengthOfArrayChunks);
            var counter = 0;
            var sourceLength = source.Count - 1;
            var indexCounter = 0;
            var resultArray = new List<List<int>>();

            while (counter < numberOfArraysToBeCreated)
            {
                if (indexCounter + lengthOfArrayChunks > sourceLength)
                {
                    resultArray.Add(source.GetRange(indexCounter, source.Count - indexCounter));
                }
                else
                {
                    resultArray.Add(source.GetRange(indexCounter, lengthOfArrayChunks));
                    indexCounter += lengthOfArrayChunks;
                }
                counter++;
            }

            foreach (var arr in resultArray)
            {
                Console.WriteLine(string.Join(' ', arr));
            }
        }
        private static bool DoesArrayContainDuplicateValues(IEnumerable<int> source)
        {
            var dataKeeper = new Dictionary<int, int>();
            foreach (var num in source)
            {
                if (dataKeeper.ContainsKey(num))
                {
                    return true;
                }
                else
                {
                    dataKeeper[num] = num;
                }
            }

            return false;
        }





    }
}
