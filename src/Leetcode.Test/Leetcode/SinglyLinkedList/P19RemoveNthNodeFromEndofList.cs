using FluentAssertions;

namespace Leetcode.Test.Leetcode.SinglyLinkedList
{
    public class P19RemoveNthNodeFromEndofList
    {
        // Improved way is to have 2 pointers
        // 1sty move pointer on n steps
        // then move both until null/or another condition
        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(
            ListNode head,
            int position,
            int deletedValue)
        {
            RemoveNthFromEnd(head, position)?.val.Should().Be(deletedValue);
        }
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode deleted = null;

            int count = 0;
            ListNode cur = head;
            while (cur is not null)
            {
                count++;
                cur = cur.next;
            }

            var deleteIndex = count - n;
            int curIndex = 0;
            cur = head;
            while (curIndex < deleteIndex - 1)
            {
                curIndex++;
                cur = cur.next;
            }

            if (deleteIndex == 0)
            {
                deleted = head;
                head = head.next;
            }
            else
            {
                deleted = cur.next;
                cur.next = cur.next.next;
            }

            return deleted;
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

            testData.Add(new object[] { head1, 1, 5 });



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

            testData.Add(new object[] { head2, 2, 1 });



            //case 3
            ListNode head3 = new ListNode(1);

            testData.Add(new object[] { head3, 1, 1 });


            return testData;
        }
        #endregion
    }
}
