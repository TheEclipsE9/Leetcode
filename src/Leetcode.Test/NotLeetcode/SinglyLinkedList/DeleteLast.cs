using FluentAssertions;
using Leetcode.DataStructures;

namespace Leetcode.Test.NotLeetcode.SinglyLinkedList
{
    public class DeleteLast
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(
            SinglyLinkedList<int> list,
            int expected)
        {
            list.DeleteLast();
            list.GetLast()?.Data.Should().Be(expected);
        }

        public static IEnumerable<object[]> TestData()
        {
            var testData = new List<object[]>();

            //case 1
            SinglyLinkedList<int> linkedList1 = new SinglyLinkedList<int>();

            testData.Add(new object[] { linkedList1, null });



            //case 2
            SinglyLinkedList<int> linkedList2 = new SinglyLinkedList<int>();

            linkedList2.Head = new SinglyLinkedListNode<int>(0);

            var fst2 = new SinglyLinkedListNode<int>(1);
            var snd2 = new SinglyLinkedListNode<int>(2);
            var trd2 = new SinglyLinkedListNode<int>(3);
            var fth2 = new SinglyLinkedListNode<int>(4);

            linkedList2.Head.Next = fst2;
            fst2.Next = snd2;
            snd2.Next = trd2;
            trd2.Next = fth2;


            testData.Add(new object[] { linkedList2, 3 });



            //case 3
            SinglyLinkedList<int> linkedList3 = new SinglyLinkedList<int>();

            linkedList3.Head = new SinglyLinkedListNode<int>(0);


            testData.Add(new object[] { linkedList3, null });



            return testData;
        }
    }
}
