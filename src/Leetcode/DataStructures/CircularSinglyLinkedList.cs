namespace Leetcode.DataStructures
{
    public class CircularSinglyLinkedList
    {
        public C_Node Last;
        public int Lenght;
    }

    public class C_Node
    {
        public C_Node? Next;
        public int Val;

        public C_Node(int val, C_Node next = null)
        {
            Val = val;
            Next = next;
        }
    }
}
