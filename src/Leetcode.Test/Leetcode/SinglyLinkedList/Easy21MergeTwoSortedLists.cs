namespace Leetcode.Test.Leetcode.SinglyLinkedList
{
    public class Easy21MergeTwoSortedLists
    {
        //values unique
        // count >= 1
        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(
            ListNode head1,
            ListNode head2)
        {
            MergeTwoLists(head1, head2);
            Assert.True(true);
        }
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode newHead = new ListNode(0);
            var tail = newHead;

            while (list1 is not null && list2 is not null)
            {
                if (list1.val <= list2.val)
                {
                    tail.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    tail.next = list2;
                    list2 = list2.next;
                }
                tail = tail.next;
            }
            if (list1 is not null)
            {
                tail.next = list1;
            }
            else
            {
                tail.next = list2;
            }

            return newHead.next;
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
                val = 1,
                next = new ListNode
                {
                    val = 2,
                    next = new ListNode
                    {
                        val = 4,
                        next = null
                    }
                }
            };
            ListNode head1_2 = new ListNode
            {
                val = 1,
                next = new ListNode
                {
                    val = 3,
                    next = new ListNode
                    {
                        val = 4,
                        next = null
                    }
                }
            };


            testData.Add(new object[] { head1_1, head1_2 });

            //case 2
            ListNode head2_1 = null;
            ListNode head2_2 = null;


            testData.Add(new object[] { head2_1, head2_2 });

            //case 3
            ListNode head3_1 = null;
            ListNode head3_2 = new ListNode(0);


            testData.Add(new object[] { head3_1, head3_2 });

            //case 4
            ListNode head4_1 = new ListNode
            {
                val = 1,
                next = null
            };
            ListNode head4_2 = new ListNode
            {
                val = 1,
                next = new ListNode
                {
                    val = 3,
                    next = new ListNode
                    {
                        val = 4,
                        next = null
                    }
                }
            };


            testData.Add(new object[] { head4_1, head4_2 });
            //case 5
            ListNode head5_1 = new ListNode(2);
            ListNode head5_2 = new ListNode(1);


            testData.Add(new object[] { head5_1, head5_2 });

            return testData;
        }
        #endregion
    }
}
