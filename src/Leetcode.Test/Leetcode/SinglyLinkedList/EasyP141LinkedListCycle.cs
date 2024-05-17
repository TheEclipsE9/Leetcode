using FluentAssertions;

namespace Leetcode.Test.Leetcode.SinglyLinkedList
{
    public class EasyP141LinkedListCycle
    {
        //values unique
        // count >= 1
        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(
            ListNode head,
            bool expected)
        {
            HasCycle(head).Should().Be(expected);
            HasCycleMemoryImproved(head).Should().Be(expected);
        }
        public bool HasCycle(ListNode head)//memory O(n)
        {
            ListNode cur = head;
            HashSet<ListNode> counter = new HashSet<ListNode>();

            while (cur is not null)
            {
                if (counter.Contains(cur))
                {
                    return true;
                }
                else
                {
                    counter.Add(cur);
                }

                cur = cur.next;
            }

            return false;
        }

        //fast and slow pointers
        public bool HasCycleMemoryImproved(ListNode head)//memory O(1)
        {
            ListNode fast = head;
            ListNode slow = head;
            while (fast is not null && fast.next is not null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    return true;
                }
            }

            return false;
        }

        #region DS Definition

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        #endregion

        #region TestData
        public static IEnumerable<object[]> TestData()
        {
            var testData = new List<object[]>();

            //case 1
            var head1 = new ListNode(3);
            var _1node = new ListNode(2);
            var _2node = new ListNode(0);
            var _3node = new ListNode(4);

            head1.next = _1node;
            _1node.next = _2node;
            _2node.next = _3node;
            _3node.next = _1node;


            testData.Add(new object[] { head1, true });



            //case 2
            var head2 = new ListNode(1);
            var _1node2 = new ListNode(2);

            head2.next = _1node2;
            _1node2.next = head2;

            testData.Add(new object[] { head2, true });


            //case 3
            ListNode head3 = new ListNode
            {
                val = 1,
                next = new ListNode
                {
                    val = 2,
                    next = new ListNode
                    {
                        val = 3,
                        next = null
                    }
                }
            };
            testData.Add(new object[] { head3, false });


            return testData;
        }
        #endregion
    }
}
