using FluentAssertions;

namespace Leetcode.Test.Leetcode.Array
{
    public class Easy977SquaresofaSortedArray
    {
        [Theory]
        [InlineData(new int[] {1,2,3}, new int[] { 1, 4, 9 })]
        [InlineData(new int[] { -4, -1, 0, 3, 10 }, new int[] { 0, 1, 9, 16, 100 })]
        [InlineData(new int[] { -7, -3, 2, 3, 11 }, new int[] { 4, 9, 9, 49, 121 })]
        [InlineData(new int[] { -5, -4, -3, -2 }, new int[] { 4, 9, 16, 25 })]
        public void Test(int[] nums, int[] result)
        {
            M(nums).Should().Equal(result);
        }

        private int[] M(int[] nums)
        {
            int length = nums.Length;
            int[] squares = new int[length];

            int cur = 0;
            while (cur < length)
            {
                int curValue = nums[cur];
                squares[cur] = curValue * curValue;
                cur++;
            }

            cur = length - 1;
            int left = 0, right = length - 1;
            while (left < right)
            {
                int curLeft = squares[left];
                int curRight = squares[right];
                if (curLeft > curRight)
                {
                    nums[cur] = curLeft;
                    left++;
                }
                else
                {
                    nums[cur] = curRight;
                    right--;
                }

                cur--;
            }

            nums[cur] = squares[left];
            return nums;

        }
    }
}
