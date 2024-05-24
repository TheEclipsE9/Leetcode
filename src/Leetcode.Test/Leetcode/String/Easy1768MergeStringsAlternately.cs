using FluentAssertions;
using Leetcode.Test.Leetcode.SinglyLinkedList;

namespace Leetcode.Test.Leetcode.String
{
    public class Easy1768MergeStringsAlternately
    {
        [Theory]
        [InlineData("abc", "pqr", "apbqcr")]
        [InlineData("ab", "pqrs", "apbqrs")]
        [InlineData("abcd", "pq", "apbqcd")]
        public void Test(string word1, string word2, string expected)
        {
            var res = MergeAlternately(word1, word2);
            res.Should().Be(expected);
        }

        //Also use single pointer i, i < res.lenght
        //inside for check if i < w1.Lenght add from w1,
        //if i < w2.lenght add from word 2
        //increase i
        //use string builder to append values to end of the word, not by index

        public string MergeAlternately(string word1, string word2)
        {
            char[] res = new char[word1.Length + word2.Length];

            int p1 = 0, p2 = 0;
            for (int i = 0; i < res.Length;)
            {
                if (p1 < word1.Length)
                {
                    res[i] = word1[p1];
                    p1++;
                    i++;
                }
                if (p2 < word2.Length)
                {
                    res[i] = word2[p2];
                    p2++;
                    i++;
                }
            }
            return string.Concat(res);
        }

        public string MergeAlternately_My_stupid(string word1, string word2)
        {
            char[] res = new char[word1.Length + word2.Length];

            int p1 = 0, p2 = 0;

            for (int i = 0; i < res.Length; i++)
            {
                if(i % 2 == 0)
                {
                    if (p1 < word1.Length)
                    {
                        res[i] = word1[p1];
                        p1++;
                    }
                    else
                    {
                        res[i] = word2[p2];
                        p2++;
                    }
                }
                else
                {
                    if (p2 < word2.Length)
                    {
                        res[i] = word2[p2];
                        p2++;
                    }
                    else
                    {
                        res[i] = word1[p1];
                        p1++;
                    }
                }
            }

            return string.Concat(res);
        }
    }
}
