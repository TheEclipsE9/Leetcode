using FluentAssertions;

namespace Leetcode.Test.Leetcode.SinglyLinkedList
{
    public class P876MiddleOfTheLinkedList
    {
        // Fast and slow pointers !!!
        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(
            ListNode head,
            int value)
        {
            GetMiddle(head)?.val.Should().Be(value);
        }
        public ListNode GetMiddle(ListNode head)
        {
            //get count
            int count = 0;
            ListNode cur = head;
            while (cur is not null)
            {
                count++;
                cur = cur.next;
            }

            int middleIndex = count / 2;
            int curentIndex = 0;
            cur = head;
            while (curentIndex != middleIndex)
            {
                cur = cur.next;
                curentIndex++;
            }

            return cur;
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

            testData.Add(new object[] { head1, 3 });



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



            //case 3
            ListNode head3 = new ListNode(1);

            testData.Add(new object[] { head3, 1 });


            return testData;
        }
        #endregion
    }
}
