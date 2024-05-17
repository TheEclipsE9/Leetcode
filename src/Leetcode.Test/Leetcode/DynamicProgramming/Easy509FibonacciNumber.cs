using FluentAssertions;

namespace Leetcode.Test.Leetcode.DynamicProgramming
{
    public class Easy509FibonacciNumber
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(4, 3)]
        [InlineData(10, 55)]
        public void Test(int n, int expected)
        {
            Fib(n).Should().Be(expected);
        }

        public int Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            return Fib(n - 1) + Fib(n - 2);
        }
    }
}
