using System;
using System.Collections.Generic;
using System.Linq;

namespace dojo
{
    public static class UnclassifiedAlgorithms
    {
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
        private static readonly Dictionary<int, int> Cache = new Dictionary<int, int>();

    }
}
