using System.Text;

namespace LeetCode.Problems
{
    internal class Medium289GameOfLife : IRunnable
    {
        public void Run()
        {
            var case1 =
                new int[][] {
                    new int[] { 0, 1, 0},
                    new int[] { 0, 0, 1},
                    new int[] { 1, 1, 1},
                    new int[] { 0, 0, 0},
                };

            var N = case1.Length;
            var M = case1[0].Length;


            GameOfLife(case1);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write(case1[i][j]);
                }
                Console.WriteLine();
            }

            string case2 = "000_111_000";

            var case2IntArr = StringToJagIntArray(case2);

            var r = JagIntArrayToString(case2IntArr);
        }

        private void GameOfLife(int[][] board)
        {
            var N = board.Length;
            var M = board[0].Length;

            int[][] futureGen = new int[N][];
            for (int i = 0; i < N; i++)
            {
                futureGen[i] = new int[M];
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    //cur cell
                    int curCellValue = board[i][j];
                    int aliveNeighborsCount = 0;
                    for (int k = -1; k <= 1; k++)
                    {
                        for (int m = -1; m <= 1; m++)
                        {
                            //position of cell for checking
                            var posX = i + k;
                            var posY = j + m;
                            if (posX < 0 || posY < 0 ||
                                posX > N - 1 || posY > M -1)
                            {
                                continue;
                            }
                            aliveNeighborsCount += board[posX][posY];
                        }
                    }

                    //as k & m can be 0 then it means that is current cell value is inside aliveNeighborsCount
                    aliveNeighborsCount -= curCellValue;


                    if (curCellValue == 1)//cell is alive
                    {
                        if (aliveNeighborsCount < 2 || aliveNeighborsCount > 3)
                        {
                            futureGen[i][j] = 0;
                        }
                        else
                        {
                            futureGen[i][j] = 1;
                        }
                    }
                    else//cell is dead
                    {
                        if (aliveNeighborsCount == 3)
                        {
                            futureGen[i][j] = 1;
                        }
                        else
                        {
                            futureGen[i][j] = 0;
                        }
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    board[i][j] = futureGen[i][j];
                }
            }
        }

        private int[][] StringToJagIntArray(string str)
        {
            string[] arr = str.Split("_");

            var N = arr.Length;
            var M = arr[0].Length;

            var result = new int[N][];
            for (int i = 0; i < N; i++)
            {
                result[i] = new int[M];
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                { 
                    var cur = arr[i][j];
                    result[i][j] = (int)Char.GetNumericValue(cur);
                }
            }

            return result;
        }

        private string JagIntArrayToString(int[][] arr)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[0].Length; j++)
                {
                    sb.Append(arr[i][j]);
                }
                sb.Append('_');
            }

            return sb.ToString();
        }
    }
}
