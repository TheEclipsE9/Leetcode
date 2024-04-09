namespace Leetcode.Test.Easy.SinglyLinkedList
{
    public class P203RemoveLinkedListElements
    {
        // Improved way is to have 2 pointers
        // 1sty move pointer on n steps
        // then move both until null/or another condition
        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(
            ListNode head,
            int value)
        {
            RemoveElements(head, value);
            Assert.True(true);
        }
        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode cur = head;
            ListNode prev = null;
            while (cur is not null)
            {
                if (cur.val == val)
                {
                    if (prev is null)
                    {
                        head = cur.next;
                        cur = head;
                        continue;
                    }
                    else
                    {
                        prev.next = cur.next;
                        cur = cur.next;
                        continue;
                    }

                }
                prev = cur;
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
                val = 5,
                next = new ListNode
                {
                    val = 5,
                    next = new ListNode
                    {
                        val = 5,
                        next = null
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
                    next = new ListNode
                    {
                        val = 6,
                        next = new ListNode
                        {
                            val = 3,
                            next = new ListNode
                            {
                                val = 4,
                                next = new ListNode
                                {
                                    val = 5,
                                    next = new ListNode
                                    {
                                        val = 6,
                                        next = null
                                    }
                                }
                            }
                        }
                    }
                }
            };

            testData.Add(new object[] { head2, 5 });


            //case 3
            ListNode head3 = null;

            testData.Add(new object[] { head3, 3 });


            return testData;
        }

        #endregion
    }
}
