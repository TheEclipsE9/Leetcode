using FluentAssertions;

namespace Leetcode.Test.Leetcode.String
{
    public class Easy1071GreatestCommonDivisorofStrings
    {
        [Theory]
        [InlineData("ABCABC", "ABC", "ABC")]
        [InlineData("ABABAB", "ABAB", "AB")]
        [InlineData("LEET", "CODE", "")]
        public void Test(string str1, string str2, string expected)
        {
            var res = GcdOfStrings(str1, str2);
            res.Should().Be(expected);
        }

        public string GcdOfStrings(string str1, string str2)
        {

            return "";
        }
    }
}
