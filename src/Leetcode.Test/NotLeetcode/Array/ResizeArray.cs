using FluentAssertions;

namespace Leetcode.Test.NotLeetcode.Array
{
    public class ResizeArray
    {
        [Theory]
        [InlineData(new int[] { 1, }, 2, new int[] { 1, 0 })]
        [InlineData(new int[] { 1, 2, 3 }, 2, new int[] { 1, 2 })]
        [InlineData(new int[] { 1, 2, 3 }, 6, new int[] { 1, 2, 3, 0, 0, 0 })]
        public void Test(int[] array, int newSize, int[] expected)
        {
            Resize(ref array, newSize);
            array.Should().Equal(expected);
        }

        private void Resize(ref int[] array, int newSize)
        {
            var newArray = new int[newSize];

            for (int i = 0; i < array.Length; i++)
            {
                if (i < newArray.Length)
                {
                    newArray[i] = array[i];
                }
            }

            array = newArray;
        }
    }
}
