﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dojo
{
    public static class StringProblems
    {
        public static bool IsPalindrome(string parameter)
        {
            return parameter == parameter.Aggregate(string.Empty, (current, t) => t + current);

        }

        public static string ReverseString(string toReverse)
        {
            return toReverse.Aggregate(string.Empty, (s, c) => c + s);
        }

        public static string ReverseStringLooping(string toReverse)
        {
            var toReturn = new StringBuilder();
            foreach (var character in toReverse)
            {
                toReturn.Insert(0, character);
            }

            return toReturn.ToString();
        }

        public static string ReverseSentence(string sentence)
        {
            var reversedSentence = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse();
            return string.Join(' ', reversedSentence);
        }

        public static string ReverseEachWord(string sentence)
        {
            var result = sentence.Split(' ').Select(ReverseString);
            return string.Join(' ', result);
        }

        public static string RemoveDuplicates(string duplicate)
        {
            var charTracker = new Dictionary<char, int>();
            var finalString = new StringBuilder();
            foreach (var character in duplicate.Where(character => !charTracker.ContainsKey(character)))
            {
                charTracker[character] = 1;
                finalString.Append(character);
            }

            return finalString.ToString();
        }

        public static string RemoveDuplicatesLinq(string duplicates)
        {
            return new string(duplicates.Distinct().ToArray());
        }

        public static string FindAllPossibleSubsetOfString(string str)
        {
            var index = 0;  
            var finalResult = new StringBuilder();

            while (index < str.Length)
            {
                var tempString = BuildString(str[index], str.Substring(index + 1));
                finalResult.Append($"{tempString} ");
                index++;
            }

            return finalResult.ToString();

        }

        private static string BuildString(char a, string str)
        {
            var subStringLength = 1;

            var finalString = new StringBuilder();

            while (subStringLength <= str.Length)
            {
                var tempString = str.Substring(0, subStringLength)
                    .Aggregate(a.ToString(), (current, c) => current + c);

                subStringLength++;

                finalString.Append($"{tempString} ");
            }

            return finalString.ToString();
        }
    }
}