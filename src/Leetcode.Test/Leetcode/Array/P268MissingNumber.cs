using FluentAssertions;

namespace Leetcode.Test.Leetcode.Array
{
    public class P268MissingNumber
    {
        [Theory]
        [InlineData(new int[] { 0, 1, 3 }, 2)]
        [InlineData(new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }, 8)]
        [InlineData(new int[] { 0, 1 }, 2)]
        [InlineData(new int[] { 2, 1 }, 0)]
        [InlineData(new int[] { 1 }, 0)]
        public void Test(int[] input, int expected)
        {
            FindMissingNumber(input).Should().Be(expected);
        }

        private int FindMissingNumber(int[] nums)
        {
            int missingNumber = -1;

            HashSet<int> numsInArray = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                numsInArray.Add(nums[i]);
            }

            for (int i = 0; i <= nums.Length; i++)
            {
                if (numsInArray.Add(i))
                {
                    missingNumber = i;
                }
            }

            return missingNumber;
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 3 }, 2)]
        [InlineData(new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }, 8)]
        [InlineData(new int[] { 0, 1 }, 2)]
        [InlineData(new int[] { 2, 1 }, 0)]
        [InlineData(new int[] { 1 }, 0)]
        public void Test_no_extra_space(int[] input, int expected)
        {
            FindMissingNumber_no_extra_space(input).Should().Be(expected);
        }
        private int FindMissingNumber_no_extra_space(int[] nums)
        {
            int missing = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                missing += nums[i];
                missing -= i + 1;
            }

            return Math.Abs(missing);
        }
    }
}
