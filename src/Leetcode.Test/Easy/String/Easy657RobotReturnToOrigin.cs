using FluentAssertions;

namespace Leetcode.Test.Easy.String
{
    public class Easy657RobotReturnToOrigin
    {
        [Theory]
        [InlineData("UD", true)]
        [InlineData("LL", false)]
        public void Test(string moves, bool expected)
        {
            JudgeCircle(moves).Should().Be(expected);
        }

        public bool JudgeCircle(string moves)
        {
            int x = 0;
            int y = 0;

            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'U':
                        y = y + 1;
                        break;
                    case 'D':
                        y = y - 1;
                        break;
                    case 'L':
                        x = x + 1;
                        break;
                    case 'R':
                        x = x - 1;
                        break;
                    default:
                        throw new ArgumentException("Unsupported move!");
                }
            }

            return x == 0 && y == 0;
        }

        public bool JudgeCircle_Slow(string moves)
        {
            Dictionary<char, int> movesCounter = new()
            {
                { 'U', 0},
                { 'D', 0},
                {'L',0 },
                {'R',0 }
            };

            foreach (var move in moves)
            {
                movesCounter[move]++;
            }

            return movesCounter['U'] == movesCounter['D'] && movesCounter['L'] == movesCounter['R'];
        }
    }
}
