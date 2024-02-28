using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class Easy35SearchInsertPosition : IRunnable
    {
        public void Run()
        {
            var case1 = new { Nums = new int[] { 3,5,6,7}, target =6 };

            var res = SearchInsert(case1.Nums, case1.target);
            Console.WriteLine(res);
        }
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            int cur = 0;
            while (left <= right)
            {
                cur = (left + right) / 2;

                if (target == nums[cur])
                {
                    return cur;
                }

                if (target < nums[cur] )
                {
                    right = cur - 1;
                }
                else
                {
                    left = cur + 1;
                }
            }

            return left;
        }
    }
}
