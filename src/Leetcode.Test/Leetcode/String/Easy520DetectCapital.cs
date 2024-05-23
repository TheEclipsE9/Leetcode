using FluentAssertions;

namespace Leetcode.Test.Leetcode.String
{
    public class Easy520DetectCapital
    {
        [Theory]
        [InlineData("USA", true)]
        [InlineData("leetcode", true)]
        [InlineData("Google", true)]
        [InlineData("RoLe", false)]
        [InlineData("polE", false)]
        public void Test(string input, bool expected)
        {
            DetectCapitalUse(input).Should().Be(expected);
        }

        public bool DetectCapitalUse(string word)
        {
            var capitalCount = 0;
            foreach (var c in word)
            {
                if (Char.IsUpper(c))
                {
                    capitalCount++;
                }
            }

            if (capitalCount == word.Length)
            {
                return true;
            }
            if (capitalCount == 0)
            {
                return true;
            }
            if (capitalCount == 1)
            {
                if (Char.IsUpper(word[0]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
