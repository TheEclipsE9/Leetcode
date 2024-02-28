using LeetCode.Problems;

namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            IRunnable runner = new Easy242ValidAnagram();

            runner.Run();
        }
    }
}