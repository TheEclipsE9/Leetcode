using FluentAssertions;
using Leetcode.DataStructures;

namespace Leetcode.Test.NotLeetcode.SinglyLinkedList
{
    public class InsertAtTheBeginning
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(
            SinglyLinkedList<int> list, 
            SinglyLinkedListNode<int> toInsert,
            int expected)
        {
            list.InsertAtTheBeginning(toInsert);

            list.Head.Data = expected;
        }

        public static IEnumerable<object[]> TestData()
        {
            var testData = new List<object[]>();

            //case 1
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

            var insert1 = new SinglyLinkedListNode<int>(-5);
            testData.Add(new object[] { linkedList1, insert1, -5 });


            //case 2
            SinglyLinkedList<int> linkedList2 = new SinglyLinkedList<int>();

            linkedList2.Head = new SinglyLinkedListNode<int>(0);

            var insert2 = new SinglyLinkedListNode<int>(-1);
            testData.Add(new object[] { linkedList2, insert2, -1 });


            //case 3
            SinglyLinkedList<int> linkedList3 = new SinglyLinkedList<int>();

            linkedList3.Head = new SinglyLinkedListNode<int>(0);

            var fst3 = new SinglyLinkedListNode<int>(1);
            var snd3 = new SinglyLinkedListNode<int>(2);

            linkedList3.Head.Next = fst3;
            fst3.Next = snd3;

            var insert3 = new SinglyLinkedListNode<int>(-3);
            testData.Add(new object[] { linkedList3, insert3, - 3 });


            //case 4
            SinglyLinkedList<int> linkedList4 = new SinglyLinkedList<int>();

            var insert4 = new SinglyLinkedListNode<int>(-4);
            testData.Add(new object[] { linkedList4, insert4, - 4 });


            //case 5
            SinglyLinkedList<int> linkedList5 = new SinglyLinkedList<int>();
            linkedList5.Head = new SinglyLinkedListNode<int>(1);

            var insert5 = new SinglyLinkedListNode<int>(-7);
            testData.Add(new object[] { linkedList5, insert5, -7 });


            return testData;
        }
    }
}
