using FluentAssertions;

namespace Leetcode.Test.NotLeetcode.Array
{
    public class FindMinValue
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 1)]
        [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0)]
        [InlineData(new int[] { 13, 15, 17, 11 }, 11)]
        [InlineData(new int[] { 5, 9, 3, 15, 1, 2 }, 1)]
        [InlineData(new int[] { 11 }, 11)]
        public void Test(int[] array, int expected)
        {
            FindMin(array).Should().Be(expected);
        }

        private int FindMin(int[] array)
        {
            int min = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }
    }
}
