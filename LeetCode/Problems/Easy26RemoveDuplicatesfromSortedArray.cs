using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class Easy26RemoveDuplicatesfromSortedArray : IRunnable
    {
        public void Run()
        {
            var case1 = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };

            var res1 = RemoveDuplicates(case1);
            Console.WriteLine($"Case1: {res1}");
        }

        public int RemoveDuplicates(int[] nums)
        {
            int k = 1;
            int left = 0;
            int right = 1;
            while (right < nums.Length )
            {
                if (nums[left] == nums[right])
                {
                    right++;
                    continue;
                }

                k++;
                left++;
                nums[left] = nums[right];
                right++;
            }

            return k;
        }
    }
}
