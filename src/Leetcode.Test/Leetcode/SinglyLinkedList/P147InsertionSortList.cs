namespace Leetcode.Test.Leetcode.SinglyLinkedList
{
    public class P147InsertionSortList
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
            InsertionSortList(head);
            Assert.True(true);
        }
        public ListNode InsertionSortList(ListNode head)
        {
            ListNode newNode = head.next;
            head.next = null;

            while (newNode is not null)
            {
                var temp = newNode.next;
                newNode.next = null;
                ListNode cur = head;

                if (newNode.val <= cur.val)
                {
                    newNode.next = head;
                    head = newNode;
                }
                else
                {
                    while (cur.next is not null)
                    {
                        if (newNode.val <= cur.next.val)
                        {
                            newNode.next = cur.next;
                            break;
                        }
                        cur = cur.next;
                    }
                    cur.next = newNode;
                }

                newNode = temp;
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
                val = 4,
                next = new ListNode
                {
                    val = 2,
                    next = new ListNode
                    {
                        val = 1,
                        next = new ListNode
                        {
                            val = 3,
                            next = null
                        }
                    }
                }
            };

            testData.Add(new object[] { head1, 3 });



            //case 2
            ListNode head2 = new ListNode
            {
                val = -1,
                next = new ListNode
                {
                    val = 5,
                    next = new ListNode
                    {
                        val = 3,
                        next = new ListNode
                        {
                            val = 4,
                            next = new ListNode
                            {
                                val = 0,
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
                val = 4,
                next = new ListNode
                {
                    val = 2,
                    next = new ListNode
                    {
                        val = 1,
                        next = new ListNode
                        {
                            val = 8,
                            next = null
                        }
                    }
                }
            };

            testData.Add(new object[] { head3, 3 });


            return testData;
        }

        #endregion
    }
}
