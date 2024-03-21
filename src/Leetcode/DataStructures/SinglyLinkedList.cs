namespace Leetcode.DataStructures
{
    public class SinglyLinkedList<T>
    {
        public SinglyLinkedListNode<T>? Head;

        public int Length()
        {
            int length = 0;
            var current = this.Head;
            while (current is not null)
            {
                length++;
                current = current.Next;
            }

            return length;
        }

        public void Print()
        {
            var current = this.Head;
            while (current is not null)
            {
                Console.WriteLine($"{current.Data}");
                current = current.Next;
            }
        }
    }
    public class SinglyLinkedListNode<T>
    {
        public T Data;
        public SinglyLinkedListNode<T>? Next;

        public SinglyLinkedListNode(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
