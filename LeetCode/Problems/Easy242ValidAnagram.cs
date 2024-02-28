namespace LeetCode.Problems
{
    public class Easy242ValidAnagram : IRunnable
    {
        public void Run()
        {
            var case1 = new { S = "aacc", T = "ccac" };
            System.Console.WriteLine(case1.S);
            System.Console.WriteLine(case1.T);

            var res = IsAnagram(case1.S, case1.T);

            System.Console.WriteLine(res);
        }

        public bool IsAnagram(string s, string t) 
        {
            if (s.Length != t.Length) return false;

            Dictionary<char, int> letters = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (letters.ContainsKey(s[i]))
                {
                     letters[s[i]]++;
                     continue;
                }

                letters.Add(s[i], 1);
            }

            for (int i = 0; i < t.Length; i++)
            {
                if (letters.ContainsKey(t[i]))
                {
                    var value = letters[t[i]];
                    if (value == 0) return false;

                    letters[t[i]]--;

                    continue;
                }
                return false;
            }

            return true;
        }
    }
}