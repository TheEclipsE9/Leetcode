using FluentAssertions;

namespace Leetcode.Test.Easy.SinglyLinkedList
{
    public class P83RemoveDuplicatesfromSortedList
    {
        // Improved way is to have 2 pointers
        // 1sty move pointer on n steps
        // then move both until null/or another condition
        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(
            ListNode head)
        {
            DeleteDuplicates(head);
            Assert.True(true);
        }
        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode prev = null;
            ListNode cur = head;
            while (cur is not null)
            {
                if (prev?.val != cur.val)
                {
                    prev = cur;
                    cur = cur.next;
                    continue;
                }

                prev.next = cur.next;
                cur = cur.next;
            }

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
            ListNode head1 = new ListNode
            {
                val = 1,
                next = new ListNode
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
                                val = 3,
                                next = null
                            }
                        }
                    }
                }
            };

            testData.Add(new object[] { head1});



            //case 2
            ListNode head2 = new ListNode
            {
                val = 1,
                next = new ListNode
                {
                    val = 1,
                    next = new ListNode
                    {
                        val = 1,
                        next = new ListNode
                        {
                            val = 1,
                            next = new ListNode
                            {
                                val = 1,
                                next = null
                            }
                        }
                    }
                }
            };

            testData.Add(new object[] { head2});



            //case 3
            ListNode head3 = new ListNode
            {
                val = 1,
                next = new ListNode
                {
                    val = 1,
                    next = new ListNode
                    {
                        val = 1,
                        next = new ListNode
                        {
                            val = 1,
                            next = new ListNode
                            {
                                val = 2,
                                next = null
                            }
                        }
                    }
                }
            };

            testData.Add(new object[] { head3});


            return testData;
        }
        #endregion
    }
}
