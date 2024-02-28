namespace LeetCode.Test.Easy.Array
{
    public class Problem1929ConcatenationOfArray
    {
        public int[] GetConcatenation(int[] nums)
        {
            var result = new int[nums.Length * 2];

            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = nums[i];
                result[i + nums.Length] = nums[i];
            }

            return result;
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 1 }, new int[] { 1, 2, 1, 1, 2, 1 })]
        [InlineData(new int[] { 1, 3, 2, 1 }, new int[] { 1, 3, 2, 1, 1, 3, 2, 1 })]
        [InlineData(new int[] { 1 }, new int[] { 1, 1})]
        public void Test(int[] nums, int[] expected)
        {
            GetConcatenation(nums).Should().Equal(expected);
        }
    }
}
