using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class Easy27RemoveElement : IRunnable
    {
        public void Run()
        {
            var case1 = new
            {
                Arr = new int[] { 3, 2, 2, 3 },//{ 3, 2, 2, 3 } - 3,//0,1,2,2,3,0,4,2 -- 2 || 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 \\ 0,1,2,2,3,0,4,2
                Val = 3,
            };

            var res1 = RemoveElement(case1.Arr, case1.Val);
            Console.WriteLine($"Case1: {res1}");
        }

        public int RemoveElement(int[] nums, int val)
        {
            if(nums.Length == 0) return 0;

            int left = 0;
            int right = nums.Length - 1;
            while(left <= right)
            {
                if (nums[right] == val)
                {
                    right--;
                    continue;
                }

                if (nums[left] == val)
                {
                    nums[left] = nums[right];
                    nums[right] = val;
                }
                left++;
            }

            return left;
        }
    }
}
