namespace LeetCode.Problems
{
    internal class ArrayRotation : IRunnable
    {
        public void Run()
        {
            var case1 = new int[] { 1,2,3,4,5,6,};

            var res = Rotate(case1);

            foreach (var val in res)
            {
                Console.Write($"{val}, ");
            }
        }

        public int[] Rotate(int[] arr)
        {
            int inital = arr[0];
            int left = 0;
            int right = inital;

            while (left < right)
            {
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;

                left++;
                right++;
                if (right == arr.Length)
                {
                    right = inital;
                }
            }

            return arr;
        }
    }
}
