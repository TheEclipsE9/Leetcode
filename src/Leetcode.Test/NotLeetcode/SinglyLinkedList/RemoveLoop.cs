using FluentAssertions;

namespace Leetcode.Test.NotLeetcode.SinglyLinkedList
{
    public class RemoveLoop
    {
        //values unique
        // count >= 1
        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(
            ListNode head)
        {
            RemoveLoopFunction(head);
            Assert.True(true);
        }
        public ListNode RemoveLoopFunction(ListNode head)
        {
            if (head is null)
            {
                return head;
            }
            ListNode fast = head;
            ListNode slow = head;
            ListNode beforeSlow = null;

            while (fast is not null && fast.next is not null)
            {
                beforeSlow = slow;
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    break;
                }
            }
            if (fast is null || fast.next is null)//no cylce if true
            {
                return head;
            }
            ListNode temp = head;

            while (temp != slow)
            {
                beforeSlow = beforeSlow.next;
                temp = temp.next;
                slow = slow.next;
            }

            beforeSlow.next = null;

            return head;
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


            testData.Add(new object[] { head1 });



            //case 2
            var head2 = new ListNode(1);
            var _1node2 = new ListNode(2);

            head2.next = _1node2;
            _1node2.next = head2;

            testData.Add(new object[] { head2 });


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
            testData.Add(new object[] { head3 });

            //case4
            testData.Add(new object[] { new ListNode(1)});

            return testData;
        }
        #endregion
    }
}
