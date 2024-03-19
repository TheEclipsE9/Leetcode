using FluentAssertions;

namespace Leetcode.Test.Easy.Array
{
    public class P283MoveZeroes
    {
        [Theory]
        [InlineData(new int[] { 0, 1, 0, 3, 12 }, new int[] { 1, 3, 12, 0, 0 })]
        [InlineData(new int[] { 1, 0, 0, 3, 12 }, new int[] { 1, 3, 12, 0, 0 })]
        [InlineData(new int[] { 1, 3, 12, 0, 0 }, new int[] { 1, 3, 12, 0, 0 })]
        [InlineData(new int[] { 0}, new int[] { 0 })]
        [InlineData(new int[] { 1}, new int[] { 1 })]
        public void Test(int[] array, int[] expected)
        {
            MoveZeroes(array);

            array.Should().Equal(expected);
        }

        private void MoveZeroes(int[] nums)
        {
            int left = 0;//zeroElement
            int right = 0;//nonZeroElement

            while (right < nums.Length)
            {
                if (nums[left] != 0)
                {
                    left++;
                    right = left;
                    continue;
                }

                if (nums[right] == 0)
                {
                    right++;
                    continue;
                }


                (nums[left], nums[right]) = (nums[right], nums[left]);

                left++;
                right++;
            }
        }
    }
}
