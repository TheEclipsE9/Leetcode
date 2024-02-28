using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class Easy1470ShuffletheArray : IRunnable
    {
        public void Run()
        {
            var case1 = new
            {
                Arr = new int[] { 1, 2,},//1,2,3,4,4,3,2,1 \\ 1,1,2,2
                Val = 1,
            };

            var res1 = Shuffle(case1.Arr, case1.Val);
            Console.WriteLine($"Case1: {res1}");
        }

        public int[] Shuffle(int[] nums, int n)
        {
            int[] result = new int[2*n];

            int left = 0;
            int right = n;
            int cursor = 0;
            while (left < n)
            {
                result[cursor] = nums[left];
                result[cursor + 1] = nums[right];

                left++;
                right++;

                cursor += 2;
            }

            return result;
        }
    }
}
