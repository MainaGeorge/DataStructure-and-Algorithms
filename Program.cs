namespace dojo
{
    internal class Program
    {
        private static void Main()
        {
            var numbers = new[,] { { 2, 3, 4 }, { 5, 6, 7 } };

            ArrayProblems.JoinTwoArraysToOneMultiDimensionalReadingColumnsFirst(numbers);
            ArrayProblems.EmptyATwoDimensionalArrayIntoAOneDimensional(numbers);

        }


    }

}
