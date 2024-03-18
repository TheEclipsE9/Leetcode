using FluentAssertions;

namespace Leetcode.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            bool a = true;
            a.Should().BeTrue();
        }
    }
}