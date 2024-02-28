using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class Medium11ContainerWithMostWater : IRunnable
    {
        public void Run()
        {
            var case1 = new int[] { 1, 2, 4, 3 };

            var res1 = MaxArea(case1);
            Console.WriteLine($"Case1: {res1}"); 
        }

        public int MaxArea(int[] height)
        {
            int res = 0;
            int left = 0;
            int right = height.Length - 1;
            while (left < right)
            {
                int h = height[left] > height[right] ? height[right] : height[left];
                int area = (right - left) * h;

                res = res > area ? res : area;

                if (height[left] > height[right])
                {
                    right--;
                }
                else if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                    left++;
                }

            }

            return res;
        }
    }
}
