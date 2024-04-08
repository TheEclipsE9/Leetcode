namespace Leetcode.Test.NotLeetcode.SinglyLinkedList
{
    public class InsertIntoSorted
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
            Insert(head, value);
            Assert.True(true);
        }
        public ListNode Insert(ListNode head, int value)
        {
            var newNode = new ListNode(value);
            if (head is null)
            {
                head = newNode;
            }
            else
            {
                if (value < head.val)
                {
                    newNode.next = head;
                    head = newNode;
                    return head;
                }

                ListNode cur = head;
                while (cur is not null && cur.next is not null)
                {
                    if (value <= cur.next.val)
                    {
                        newNode.next = cur.next;
                        break;
                    }
                    cur = cur.next;
                }

                cur.next = newNode;
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
                    val = 2,
                    next = new ListNode
                    {
                        val = 4,
                        next = new ListNode
                        {
                            val = 6,
                            next = new ListNode
                            {
                                val = 7,
                                next = null
                            }
                        }
                    }
                }
            };

            testData.Add(new object[] { head1, 3 });



            //case 2
            ListNode head2 = new ListNode
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

            testData.Add(new object[] { head2, 7 });



            //case 3
            ListNode head3 = new ListNode
            {
                val = 3,
                next = new ListNode
                {
                    val = 5,
                    next = new ListNode
                    {
                        val = 7,
                        next = null
                    }
                }
            };

            testData.Add(new object[] { head3, 0 });


            //case 4
            testData.Add(new object[] { null, 1 });

            return testData;
        }

        #endregion
    }
}
