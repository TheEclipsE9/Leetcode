using FluentAssertions;
using Leetcode.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Test.Leetcode.SinglyLinkedList.P206ReverseLinkedList;

namespace Leetcode.Test.Leetcode.SinglyLinkedList
{
    // Hint 1 For every node we need to update its next
    // Hint 2 To do it we need to keep previous node
    // Hint 3 To iterate we need to keep next node

    public class P206ReverseLinkedList
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(
            ListNode head,
            int value)
        {
            ReverseList(head)?.val.Should().Be(value);
        }
        public ListNode ReverseList(ListNode head)
        {
            if (head is null)
            {
                return null;
            }
            ListNode prev = null;
            ListNode cur = head;

            while (cur.next is not null)
            {
                cur = cur.next;
                head.next = prev;
                prev = head;
                head = cur;
            }

            head.next = prev;

            return head;
        }

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

        public static IEnumerable<object[]> TestData()
        {
            var testData = new List<object[]>();

            //case 1
            ListNode head1 = new ListNode
            {
                val = 1,
                next = new ListNode
                {
                    val = 2,
                    next = new ListNode
                    {
                        val = 3,
                        next = new ListNode
                        {
                            val = 4,
                            next = new ListNode
                            {
                                val = 5,
                                next = null
                            }
                        }
                    }
                }
            };

            testData.Add(new object[] { head1, 5 });



            //case 2
            ListNode head2 = new ListNode
            {
                val = 1,
                next = new ListNode
                {
                    val = 2,
                    next = null
                }
            };

            testData.Add(new object[] { head2, 2 });



            //case 2
            ListNode head3 = null;

            testData.Add(new object[] { head3, null });


            return testData;
        }
    }
}
