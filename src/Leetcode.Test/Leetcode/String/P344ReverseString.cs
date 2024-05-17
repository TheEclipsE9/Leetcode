using FluentAssertions;

namespace Leetcode.Test.Leetcode.String
{
    public class P344ReverseString
    {
        [Theory]
        [InlineData(new char[] { 'h', 'e', 'l', 'l', 'o' }, new char[] { 'o', 'l', 'l', 'e', 'h' })]
        public void Test(char[] s, char[] expected)
        {
            ReverseString(s);

            s.Should().Equal(expected);
        }

        private void ReverseString(char[] s)
        {
            int left = 0;
            int rigth = s.Length - 1;

            while (left < rigth)
            {
                (s[left], s[rigth]) = (s[rigth], s[left]);
                left++;
                rigth--;
            }
        }
    }
}
