using Xunit.Abstractions;

namespace Leetcode.Test.NotLeetcode.DoublyLinkedList
{
    public class RemoveLastTest
    {
        private readonly ITestOutputHelper _output;

        public RemoveLastTest(ITestOutputHelper output)
        {
            _output = output;
        }
        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(
            DoublyLinkedList list)
        {
            Print(list);
            _output.WriteLine("");
            RemoveLast(list);
            Print(list);
        }

        private void RemoveLast(DoublyLinkedList list)
        {
            if (list.tail is null) return;
            if (list.head == list.tail)//count 1
            {
                list.head = null;
                list.tail = null;
                return;
            }

            list.tail = list.tail.previous;
            list.tail.next = null;
        }



        #region DS Def
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

            testData.Add(new object[] { list1 });

            //case 2
            DoublyLinkedList list2 = new DoublyLinkedList();

            testData.Add(new object[] { list2 });

            //case 3
            DoublyLinkedList list3 = new DoublyLinkedList();

            var node = new D_ListNode(4);
            list3.head = node;
            list3.tail = node;

            testData.Add(new object[] { list3 });

            return testData;
        }
    }
}
