using FluentAssertions;

namespace Leetcode.Test.Leetcode.Array
{
    public class Easy1436DestinationCity
    {
        [Fact]
        public void Test()
        {
            IList<IList<string>> input = new List<IList<string>>()
            {
                new List<string> { "London", "New York"},
                new List<string> { "Lima", "Sao Paulo"},
                new List<string> { "New York", "Lima" }
            };

            var expected = "Sao Paulo";

            DestCity(input).Should().Be(expected);
        }
        public string DestCity(IList<IList<string>> paths)
        {
            var dict = new Dictionary<string, string>();
            foreach (var path in paths)
            {
                dict.Add(path[0], path[1]);
            }

            string cur = paths[0][0];
            string result = cur;
            while (dict.TryGetValue(cur, out cur))
            {
                result = cur ?? result;
            }

            return result;
        }
    }
}
