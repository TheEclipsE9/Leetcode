using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // MyAbsrt a = new MyAbsrt();
        }

        static ref int RefTest(ref int i)
        {
            return ref i;
        }

        interface IMy
        {
            void Test();

            //const int A = 1;

            //static void Print()
            //{
            //    Console.WriteLine("A");
            //}

            //static IMy()
            //{

            //}
        }

        abstract class MyAbsrt : IMy
        {
            public abstract void Test();

            public MyAbsrt()
            {
                
            }
        }
    }
}
