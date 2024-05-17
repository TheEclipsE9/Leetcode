using Microsoft.VisualBasic;

namespace Leetcode.Test.Leetcode.SinglyLinkedList
{
    public class Medium2AddTwoNumbers
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(
            ListNode l1,
            ListNode l2)
        {
            AddTwoNumbers(l1, l2);
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode newHead = new ListNode(-1);
            ListNode temp = newHead;
            int rest = 0;
            while (l1 is not null && l2 is not null)
            {
                var sum = l1.val + l2.val + rest;
                rest = sum / 10;

                temp.next = new ListNode(sum % 10);
                temp = temp.next;

                l1 = l1.next;
                l2 = l2.next;
            }

            if (l1 is not null)
            {
                while (l1 is not null)
                {
                    var sum = l1.val + rest;
                    rest = sum / 10;
                    temp.next = new ListNode(sum % 10);
                    temp = temp.next;

                    l1 = l1.next;
                }
            }
            else if (l2 is not null)
            {
                while (l2 is not null)
                {
                    var sum = l2.val + rest;
                    rest = sum / 10;
                    temp.next = new ListNode(sum % 10);
                    temp = temp.next;

                    l2 = l2.next;
                }
            }

            if (rest != 0)
            {
                temp.next = new ListNode(rest);
            }

            return newHead.next;
        }

        public ListNode AddTwoNumbers_GPT(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode p = l1, q = l2, curr = dummyHead;
            int carry = 0;
            while (p != null || q != null)
            {
                int x = p != null ? p.val : 0;
                int y = q != null ? q.val : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;
                if (p != null) p = p.next;
                if (q != null) q = q.next;
            }
            if (carry > 0)
            {
                curr.next = new ListNode(carry);
            }
            return dummyHead.next;
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
            ListNode head1_1 = new ListNode
            {
                val = 2,
                next = new ListNode
                {
                    val = 4,
                    next = new ListNode
                    {
                        val = 3,
                        next = null
                    }
                }
            };
            ListNode head1_2 = new ListNode
            {
                val = 5,
                next = new ListNode
                {
                    val = 6,
                    next = new ListNode
                    {
                        val = 4,
                        next = null
                    }
                }
            };


            testData.Add(new object[] { head1_1, head1_2 });

            return testData;
        }
        #endregion
    }
}
