using FluentAssertions;
using Leetcode.DataStructures;

namespace Leetcode.Test.NotLeetcode.SinglyLinkedList
{
    public class FindLength
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(SinglyLinkedList<int> list, int expected)
        {
            GetLength(list).Should().Be(expected);
        }

        public int GetLength(SinglyLinkedList<int> list)
        {
            var current = list.Head;
            int length = 0;
            while (current != null)
            {
                length++;
                current = current.Next;
            }

            return length;
        }

        public static IEnumerable<object[]> TestData()
        {
            var testData = new List<object[]>();

            SinglyLinkedList<int> linkedList1 = new SinglyLinkedList<int>();

            linkedList1.Head = new SinglyLinkedListNode<int>(0);

            var fst1 = new SinglyLinkedListNode<int>(1);
            var snd1 = new SinglyLinkedListNode<int>(2);
            var trd1 = new SinglyLinkedListNode<int>(3);
            var fth1 = new SinglyLinkedListNode<int>(4);

            linkedList1.Head.Next = fst1;
            fst1.Next = snd1;
            snd1.Next = trd1;
            trd1.Next = fth1;

            testData.Add(new object[] { linkedList1, 5});



            SinglyLinkedList<int> linkedList2 = new SinglyLinkedList<int>();

            linkedList2.Head = new SinglyLinkedListNode<int>(0);

            testData.Add(new object[] { linkedList2, 1 });



            SinglyLinkedList<int> linkedList3 = new SinglyLinkedList<int>();

            linkedList3.Head = new SinglyLinkedListNode<int>(0);

            var fst3 = new SinglyLinkedListNode<int>(1);
            var snd3 = new SinglyLinkedListNode<int>(2);

            linkedList3.Head.Next = fst3;
            fst3.Next = snd3;

            testData.Add(new object[] { linkedList3, 3 });



            SinglyLinkedList<int> linkedList4 = new SinglyLinkedList<int>();

            testData.Add(new object[] { linkedList4, 0 });


            SinglyLinkedList<int> linkedList5 = new SinglyLinkedList<int>();
            linkedList5.Head = new SinglyLinkedListNode<int>(1);

            testData.Add(new object[] { linkedList5, 1 });


            return testData;
        }
    }
}
