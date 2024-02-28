namespace LeetCode.Problems
{
    public class Hard4MedianOfTwoSortedArrays : IRunnable
    {
        public void Run()
        {
            var case1 = new 
            {
                nums1 = new int[] { 1, 3 }, 
                nums2 = new int[] { 2 },
            };
            var case2 = new
            {
                nums1 = new int[] { 1, 2 },
                nums2 = new int[] { 3, 4 },
            };
            var case3 = new
            {
                nums1 = new int[] { 2, 3, 4, 5 },
                nums2 = new int[] { 1},
            };

            var resCase1 = FindMedianSortedArrays(case1.nums1, case1.nums2);
            Console.WriteLine($"Case1: {resCase1}");

            var resCase2 = FindMedianSortedArrays(case2.nums1, case2.nums2);
            Console.WriteLine($"Case2: {resCase2}");

            var resCase3 = FindMedianSortedArrays(case3.nums1, case3.nums2);
            Console.WriteLine($"Case3: {resCase3}");
        }

        private double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var totalLength = nums1.Length + nums2.Length;
            var isOdd = totalLength % 2 == 0;

            var medianIndex = (int)((totalLength / 2d) - 0.5);

            if (nums1.Length == 0)
            {
                if (isOdd)
                {
                    var sum = nums2[medianIndex] + nums2[medianIndex + 1];
                    return sum / 2.0;
                }
                else
                {
                    return nums2[medianIndex];
                }
            }

            if (nums2.Length == 0)
            {
                if (isOdd)
                {
                    var sum = nums1[medianIndex] + nums1[medianIndex + 1];
                    return sum / 2.0;
                }
                else
                {
                    return nums1[medianIndex];
                }
            }

            int globalIndex = 0;
            int array1Index = 0;
            int array2Index = 0;

            while (globalIndex != medianIndex)
            {
                globalIndex++;
                
                int? v1 = array1Index >= nums1.Length ? null : nums1[array1Index];
                int? v2 = array2Index >= nums2.Length ? null : nums2[array2Index];

                if (v2 is null || v1 < v2.Value)
                {
                    array1Index++;
                }
                else //if (nums1[array1Index] > nums2[array2Index])
                {
                    array2Index++;
                }
            }

            int? value1 = array1Index >= nums1.Length ? null : nums1[array1Index];
            int? value2 = array2Index >= nums2.Length ? null : nums2[array2Index];

            if (isOdd == false)
            {
                if (value1 is null)
                {
                    return value2.Value;
                }
                if (value2 is null)
                {
                    return value1.Value;
                }

                return value1 > value2 ? value2.Value : value1.Value;
            }

            if (value1 is null)
            {
                return (nums2[array2Index] + nums2[array2Index + 1]) / 2.0;
            }
            if (value2 is null)
            {
                return (nums1[array1Index] + nums1[array1Index + 1]) / 2.0;
            }

            int res = 0;
            if (value1.Value < value2.Value)
            {
                res += value1.Value;
                array1Index++;
            }
            else
            {
                res += value2.Value;
                array2Index++;
            }

            value1 = array1Index >= nums1.Length ? null : nums1[array1Index];
            value2 = array2Index >= nums2.Length ? null : nums2[array2Index];

            if (value1 is null)
            {
                return (res + nums2[array2Index]) / 2.0;
            }
            if (value2 is null)
            {
                return (res + nums1[array1Index]) / 2.0;
            }

            if (value1.Value < value2.Value)
            {
                res += value1.Value;
                array1Index++;
            }
            else
            {
                res += value2.Value;
                array2Index++;
            }

            return res / 2.0;
        }
    }
}
