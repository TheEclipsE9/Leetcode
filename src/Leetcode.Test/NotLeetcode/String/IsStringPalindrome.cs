using FluentAssertions;

namespace Leetcode.Test.NotLeetcode.String
{
    public class IsStringPalindrome
    {
        [Theory]
        [InlineData("madam", true)]
        [InlineData("kallak", true)]
        [InlineData("kalK", false)]
        [InlineData("k", true)]
        [InlineData("ka", false)]
        public void Test(string input, bool expected)
        {
            IsPalindrome(input).Should().Be(expected);
        }

        private bool IsPalindrome(string s)
        {
            int l = 0;
            int r = s.Length - 1;

            while (l < r)
            {
                if (s[l] != s[r])
                {
                    return false;
                }
                l++;
                r--;
            }

            return true;
        }
    }
}
