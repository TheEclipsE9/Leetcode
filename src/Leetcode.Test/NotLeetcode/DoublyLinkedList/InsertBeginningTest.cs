using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Leetcode.Test.NotLeetcode.DoublyLinkedList
{
    public class InsertBeginningTest
    {
        private readonly ITestOutputHelper _output;

        public InsertBeginningTest(ITestOutputHelper output)
        {
            _output = output;
        }
        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(
            DoublyLinkedList list,
            int val)
        {
            Print(list);
            _output.WriteLine("");
            Insert(list, val);
            Print(list);
        }

        private void Insert(DoublyLinkedList list, int val)
        {
            var newNode = new D_ListNode(val);

            if (list.head is null || list.tail is null)
            {
                list.head = newNode;
                list.tail = newNode;
            }
            else
            {
                newNode.next = list.head;
                list.head.previous = newNode;

                list.head = newNode;
            }
        }

        private void Print(DoublyLinkedList list)
        {
            var cur = list.head;
            _output.WriteLine("null->");
            while (cur is not null)
            {
                _output.WriteLine($"<-{cur.val}->");
                cur = cur.next;
            }
            _output.WriteLine("<-null");
        }


        #region DS Def
        public class DoublyLinkedList
        {
            public D_ListNode head;
            public D_ListNode tail;

            public DoublyLinkedList()
            {
                head = null;
                tail = null;
            }

            public void Print(ITestOutputHelper _output)
            {
                var cur = head;
                _output.WriteLine("null->");
                while (cur is not null)
                {
                    _output.WriteLine($"<-{cur.val}->");
                    cur = cur.next;
                }
                _output.WriteLine("<-null");
            }
        }

        public class D_ListNode
        {
            public int val;
            public D_ListNode previous;
            public D_ListNode next;
            public D_ListNode(int data)
            {
                this.val = data;
            }
        }

        #endregion

        public static IEnumerable<object[]> TestData()
        {
            var testData = new List<object[]>();

            //case 1
            DoublyLinkedList list1 = new DoublyLinkedList();

            var node1 = new D_ListNode(1);
            list1.head = node1;
            list1.tail = node1;

            var node2 = new D_ListNode(2);

            node1.next = node2;
            node2.previous = node1;
            list1.tail = node2;

            var node3 = new D_ListNode(3);

            node2.next = node3;
            node3.previous = node2;
            list1.tail = node3;

            testData.Add(new object[] { list1, 4 });



            return testData;
        }
    }
}
