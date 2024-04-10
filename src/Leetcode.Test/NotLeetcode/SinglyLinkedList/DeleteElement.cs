namespace Leetcode.Test.NotLeetcode.SinglyLinkedList
{
    public class DeleteElement
    {
        //values unique
        // count >= 1
        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(
            ListNode head,
            int value)
        {
            RemoveElement(head, value);
            Assert.True(true);
        }
        public ListNode RemoveElement(ListNode head, int val)
        {
            if (head.val == val)
            {
                head = head.next;
                return head;
            }

            ListNode cur = head;
            while (cur.next is not null)
            {
                if (cur.next.val == val)
                {
                    break;
                }
                cur = cur.next;
            }
            cur.next = cur.next?.next;

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
                        val = 3,
                        next = null
                    }
                }
            };

            testData.Add(new object[] { head1, 1 });



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
                            val = 11,
                            next = new ListNode
                            {
                                val = 5,
                                next = new ListNode
                                {
                                    val = 7,
                                    next = new ListNode
                                    {
                                        val = 9,
                                        next = null
                                    }
                                }
                            }
                        }
                    }
                }
            };

            testData.Add(new object[] { head2, 11 });


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
            testData.Add(new object[] { head3, 3 });

            //case 3
            ListNode head4 = new ListNode
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

            testData.Add(new object[] { head4, 9 });


            return testData;
        }
        #endregion
    }
}
