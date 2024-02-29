namespace LeetCode.Test.Easy.Array
{
    public class Problem1920BuildArrayFromPermutation
    {
        public int[] BuildArray(int[] nums)//Space O(n)
        {
            var result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = nums[nums[i]];
            }

            return result;
        }

        public int[] BuildArray_ConstSpace(int[] nums)//Space O(1) -- ?
        {
            var result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = nums[nums[i]];
            }

            return result;
        }

        [Theory]
        [InlineData(new int[] { 0, 2, 1, 5, 3, 4 }, new int[] { 0, 1, 2, 4, 5, 3 })]
        [InlineData(new int[] { 5, 0, 1, 2, 3, 4 }, new int[] { 4, 5, 0, 1, 2, 3 })]
        [InlineData(new int[] { 0 }, new int[] { 0 })]
        [InlineData(new int[] { 0, 1 }, new int[] { 0, 1 })]
        public void Test(int[] nums, int[] expected)
        {
            BuildArray(nums).Should().Equal(expected);

            BuildArray_ConstSpace(nums).Should().Equal(expected);
        }
    }
}
