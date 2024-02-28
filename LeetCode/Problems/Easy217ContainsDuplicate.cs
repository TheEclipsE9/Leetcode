using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class Easy217ContainsDuplicate : IRunnable
    {
        public void Run()
        {
            var case1 = new int[] {  };

            var res1 = ContainsDuplicate(case1);
            Console.WriteLine($"Case1: {res1}");
        }

        public bool ContainsDuplicate(int[] nums)
        {
            Dictionary<int, string> duplicates = new Dictionary<int, string>();
            foreach (int num in nums)
            {
                if (duplicates.ContainsKey(num))
                {
                    return true;
                }
                duplicates.Add(num, string.Empty);
            }
            return false;
        }
    }
}
