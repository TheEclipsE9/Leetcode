using FluentAssertions;

namespace Leetcode.Test.NotLeetcode.Array
{
    public class SecondLargestNumber
    {
        [Theory]
        [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 6)]
        [InlineData(new int[] { 13, 15, 17, 11 }, 15)]
        [InlineData(new int[] { 5, 9, 3, 15, 1, 2 }, 9)]
        [InlineData(new int[] { 15, 9, 3, 15, 1, 2 }, 9)]
        [InlineData(new int[] { 15, 9 }, 9)]
        public void Test(int[] array, int expected)
        {
            FindSecondLargest(array).Should().Be(expected);
        }

        private int FindSecondLargest(int[] array)
        {
            int max = int.MinValue;
            int secondMax = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    secondMax = max;
                    max = array[i];
                }
                if (array[i] > secondMax && array[i] != max)
                {
                    secondMax = array[i];
                }
            }

            return secondMax;
        }
    }
}
