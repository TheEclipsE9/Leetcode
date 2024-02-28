namespace LeetCode.Problems
{
    internal class Medium6ZigzagConversion : IRunnable
    {
        public void Run()
        {
            var case1 = new { S = "PAYPALISHIRING", NumRows = 5};

            var res1 = Convert(case1.S, case1.NumRows);
            Console.WriteLine($"Case1: {res1}");
        }

        public string Convert(string s, int numRows)
        {
            if (numRows == 1 || numRows == s.Length)
            {
                return s;
            }

            var numCols = GetColumnsCount(s.Length, numRows);

            var matrix = new char[numRows, numCols];

            int row = 0;
            int col = 0;

            int direction = 1;
            for (int i = 0; i < s.Length; i++)
            {
                var ch = s[i];
                matrix[row, col] = ch;

                row += direction;

                if (direction == -1)
                {
                    col++;
                }

                if (row == numRows)
                {
                    col++;
                    row -= 2;
                    direction = -1;
                }

                if (row == 0)
                {
                    direction = 1;
                }
            }

            char[] res = new char[s.Length];
            int index = 0;
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (matrix[i,j] == 0)
                    {
                        continue;
                    }
                    res[index] = matrix[i,j];
                    index++;
                }
            }

            return new string(res);
        }

        private int GetColumnsCount(int length, int numOfRows)
        {
            int fullColumnsCount = length / numOfRows;

            int betweenColumnsCount = (numOfRows - 2) * (fullColumnsCount - 1);

            int restColumnsCount = length - (fullColumnsCount * numOfRows + betweenColumnsCount);
            restColumnsCount = restColumnsCount > 0 ? restColumnsCount : 0;

            return fullColumnsCount + betweenColumnsCount + restColumnsCount;
        }
    }
}
