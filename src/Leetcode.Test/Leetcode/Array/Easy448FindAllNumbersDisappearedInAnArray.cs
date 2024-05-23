using FluentAssertions;
using System.Linq;

namespace Leetcode.Test.Leetcode.Array
{
    public class Easy448FindAllNumbersDisappearedInAnArray
    {
        // Method to provide test data
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { new int[] { 1, 1}, new int[] { 2} };
            yield return new object[] { new int[] { 4, 3, 2, 7, 8, 2, 3, 1 }, new int[] { 5, 6} };
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Test(int[] input, int[] expected)
        {
            var res = FindDisappearedNumbers(input);
            res.Should().Equal(expected);
        }

        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            List<int> res = new();

            for(int i = 0; i < nums.Length; i++)
            {
                var markIndex = Math.Abs(nums[i]) - 1;
                nums[markIndex] = -Math.Abs(nums[markIndex]);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    res.Add(i + 1);
                }
            }

            return res;
        }

        public IList<int> FindDisappearedNumbers_norm(int[] nums)
        {
            List<int> res = new();

            HashSet<int> set = new();

            for(int i = 0; i < nums.Length; i++)
            {
                set.Add(nums[i]);
            }

            for (int i = 1; i <= nums.Length; i++)
            {
                if (set.Contains(i) == false)
                {
                    res.Add(i);
                }
            }

            return res;
        }

        public IList<int> FindDisappearedNumbers_slow_and_memory_strange(int[] nums)
        {
            List<int> res = new();

            Dictionary<int, int> dict = new();

            for (int i = 1; i <= nums.Length; i++)
            {
                dict.Add(i, 0);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]] = dict[nums[i]] + 1;
                }
            }

            for (int i = 1; i <= dict.Count; i++)
            {
                if (dict[i] == 0)
                {
                    res.Add(i);
                }
            }

            return res;
        }

        public IList<int> FindDisappearedNumbers_strange(int[] nums)//time exception
        {
            List<int> res = new();

            HashSet<int> set = new ();
            for(int i = 0; i < nums.Length;i++)
            {
                set.Add(nums[i]);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 1; j <= i + 1; j++)
                {
                    if (!set.Contains(j))
                    {
                        set.Add(j);
                        res.Add(j);
                    }
                }
            }

            return res;
        }
    }
}
