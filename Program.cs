using System;

namespace dojo
{
    internal class Program
    {
        private static void Main()
        {
            const string sentence = "hello my name is George. Oliver is my son";

            Console.WriteLine(StringProblems.ReverseSentenceAndEachWordInThatSentence(sentence));
        }


    }

}
