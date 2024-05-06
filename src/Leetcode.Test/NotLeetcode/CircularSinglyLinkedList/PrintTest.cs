﻿using Xunit.Abstractions;

namespace Leetcode.Test.NotLeetcode.CircularSinglyLinkedList
{
    public class PrintTest
    {
        private readonly ITestOutputHelper _output;

        public PrintTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(
            CircularSinglyLinkedList list)
        {
            Print(list);
            _output.WriteLine("");
        }

        private void Print(CircularSinglyLinkedList list)
        {
            if (list.Last is null) return;

            var first = list.Last.Next;
            var cur = first;
            do
            {
                _output.WriteLine($"{cur.Val}->");
                cur = cur.Next;
            } while (cur != first);
        }

        #region DS Def
        public class CircularSinglyLinkedList
        {
            public C_Node Last = null;
        }

        public class C_Node
        {
            public C_Node? Next;
            public int Val;

            public C_Node(int val, C_Node next = null)
            {
                Val = val;
                Next = next;
            }
        }

        #endregion

        public static IEnumerable<object[]> TestData()
        {
            var testData = new List<object[]>();

            //case 1
            CircularSinglyLinkedList list1 = new CircularSinglyLinkedList();

            var node1 = new C_Node(1);
            var node2 = new C_Node(2);
            var node3 = new C_Node(3);
            var node4 = new C_Node(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node1;

            list1.Last = node4;

            testData.Add(new object[] { list1 });

            //case 2
            CircularSinglyLinkedList list2 = new CircularSinglyLinkedList();

            var node2_1 = new C_Node(1);

            node2_1.Next = node2_1;

            list2.Last = node2_1;

            testData.Add(new object[] { list2 });

            //case 2
            CircularSinglyLinkedList list3 = new CircularSinglyLinkedList();

            testData.Add(new object[] { list3 });


            return testData;
        }
    }
}
