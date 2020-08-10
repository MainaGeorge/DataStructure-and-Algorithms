using System;
using System.Collections.Generic;
using System.Linq;

namespace dojo
{
    public static class UnclassifiedAlgorithms
    {
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

        private static readonly Dictionary<int, int> Cache = new Dictionary<int, int>();
        private static int MemoizeFib(int n)
        {
            if (n == 2 || n == 3)
            {
                return 1;
            }

            if (Cache.ContainsKey(n))
            {
                return Cache[n];
            }
            else
            {
                Cache[n] = MemoizeFib(n - 1) + MemoizeFib(n - 2);
                return Cache[n];
            }
        }
        private static int FibSequence(int n)
        {
            if (n == 2 || n == 3)
            {
                return 1;
            }

            return FibSequence(n - 1) + FibSequence(n - 2);
        }
        private static int FindPossibleNumberOfTimesSumsToZero(IEnumerable<int> first,
            IEnumerable<int> second, IEnumerable<int> third, IEnumerable<int> fourth)
        {
            // Given four arrays a, b, c and d, find how many possible combinations
            // such that if we took an element from each array and added them together the result would be 0.
            var results = new Dictionary<int, int>(); //this will hold sum of two elements from two arrays and the number of times it repeats throughout the calculation

            foreach (var num in first)
            {
                foreach (var num2 in second)
                {
                    var currentSum = num + num2;

                    if (results.ContainsKey(currentSum))
                    {
                        results[currentSum]++;
                    }
                    else
                    {
                        results[currentSum] = 1;
                    }
                }
            }

            var numberOfCombinations = third.Sum(num => fourth.Select(num2 => -(num + num2)).Where(currentSum => results.ContainsKey(currentSum)).Sum(currentSum => results[currentSum]));
            return numberOfCombinations;
        }
        private static IEnumerable<IEnumerable<string>> GroupAnagrams(IEnumerable<string> source)
        {
            var anagramsGroupingsContainer = new Dictionary<string, List<string>>();

            foreach (var word in source)
            {
                var sorted = string.Concat(word.OrderBy(w => w));

                if (anagramsGroupingsContainer.ContainsKey(sorted))
                {
                    anagramsGroupingsContainer[sorted].Add(word);
                }
                else
                {
                    anagramsGroupingsContainer[sorted] = new List<string> { word };
                }
            }

            return anagramsGroupingsContainer.Values;
        }
        private static int FindTheMostFrequentElement(IEnumerable<int> source)
        {
            var counter = new Dictionary<int, int>();

            foreach (var num in source)
            {
                if (counter.ContainsKey(num))
                {
                    counter[num] += 1;
                }
                else
                {
                    counter[num] = 1;
                }
            }

            return counter
                .OrderByDescending(m => m.Value)
                .Select(m => m.Key)
                .First();

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
        private static string MoveZeroesToTheEnd(IList<int> source)
        {
            // Move all zeroes to the end of a given array while maintaining the order
            //     or elements in the array
            var j = 0;

            foreach (var num in source)
            {
                if (num == 0) continue;

                source[j] = num;
                j++;
            }

            for (var i = j; i < source.Count; i++)
                source[i] = 0;

            return string.Join(' ', source);
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
        private static int CalculateNumberOfBoats(IList<int> weights, int limit)
        {
            weights = weights.OrderBy(w => w).ToArray();
            var leftPointer = 0;
            var rightPointer = weights.Count - 1;
            var boats = 0;

            while (leftPointer <= rightPointer)
            {
                if (leftPointer == rightPointer)
                {
                    boats++;
                    break;
                }

                if (weights[leftPointer] + weights[rightPointer] <= limit)
                {
                    leftPointer++;
                    rightPointer--;
                }
                else
                {
                    rightPointer--;
                }

                boats++;
            }

            return boats;
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
        private static int FindFirstOccurrenceOfANumberInASortedList(IList<int> source, int target, int left, int right)
        {
            var firstOccurence = -1;
            while (left <= right)
            {

                var mid = (int)Math.Floor((double)(left + (right - left) / 2));

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
    }
}
