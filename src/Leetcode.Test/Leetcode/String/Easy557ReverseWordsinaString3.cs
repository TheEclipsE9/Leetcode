using FluentAssertions;

namespace Leetcode.Test.Leetcode.String
{
    public class Easy557ReverseWordsinaString3
    {
        [Theory]
        [InlineData("Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc")]
        [InlineData("Mr Ding", "rM gniD")]
        public void Test(string input, string output)
        {
            M(input).Should().Be(output);
        }

        private string M(string input)
        {
            var result = input.ToCharArray();

            int left = 0;
            int right = 0;
            int cur = 0;
            while (cur < result.Length)
            {
                if (!char.IsWhiteSpace(result[cur]))
                {
                    cur++;
                    continue;
                }

                right = cur - 1;

                while (left < right)
                {
                    (result[left], result[right]) = (result[right], result[left]);

                    left++;
                    right--;
                }

                left = cur + 1;
                cur++;
            }

            right = cur - 1;
            while (left < right)
            {
                (result[left], result[right]) = (result[right], result[left]);

                left++;
                right--;
            }

            return new string(result);
        }
    }
}
