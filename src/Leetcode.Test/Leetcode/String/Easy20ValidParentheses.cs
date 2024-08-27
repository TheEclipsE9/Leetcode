using FluentAssertions;

namespace Leetcode.Test.Leetcode.String
{
    public class Easy20ValidParentheses
    {
        [Theory]
        [InlineData("()", true)]
        [InlineData("({[]})", true)]
        [InlineData("(){}[]", true)]
        [InlineData("})", false)]
        [InlineData("(", false)]
        [InlineData("({}", false)]
        public void Test(string s, bool result)
        {
            M(s).Should().Be(result);
        }

        private bool M(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c is '(' or '{' or '[')
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0) return false;
                    var openChar = stack.Pop();
                    switch (openChar)
                    {
                        case '(':
                            if (c is not ')') return false;
                            break;
                        case '{':
                            if (c is not '}') return false;
                            break;
                        case '[':
                            if (c is not ']') return false;
                            break;
                        default:
                            return false;
                    }
                }
            }
            if (stack.Count != 0) return false;

            return true;
        }
    }
}
