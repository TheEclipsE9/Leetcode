namespace Leetcode.Test.Leetcode.Array
{
    public class Easy661ImageSmoother
    {
        // Method to provide test data
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { new int[][] { new int[] { 1, 1, 1 }, new int[] { 1, 0, 1 }, new int[] { 1, 1, 1 } } };
            yield return new object[] { new int[][] { new int[] { 2, 3, 4 }, new int[] { 5, 6, 7 }, new int[] { 8, 9, 10 }, new int[] { 11, 12, 13 }, new int[] { 14, 15, 16 } } };
            yield return new object[] { new int[][] { new int[] { 2, 3 } } };
        }

        // Test method with MemberData attribute
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Test(int[][] img)
        {
            // Call the method under test
            ImageSmoother(img);
            // Add assertions to verify the expected outcomes
        }

        public int[][] ImageSmoother(int[][] img)
        {
            var result = new int[img.Length][];

            for (int y = 0; y < img.Length; y++)
            {
                result[y] = new int[img[y].Length];
                for (int x = 0; x < img[y].Length; x++)
                {
                    int neighborsSum = 0;
                    int neighborsCount = 0;
                    for (int _y = y - 1; _y <= y + 1; _y++)
                    {
                        for (int _x = x - 1; _x <= x + 1; _x++)
                        {
                            if (_x == -1 || _x == img[y].Length || _y == -1 || _y == img.Length)
                            {
                                continue;
                            }
                            neighborsCount++;
                            neighborsSum += img[_y][_x];
                        }
                    }
                    
                    result[y][x] = neighborsSum / neighborsCount;
                }
            }

            return result;
        }
    }
}
