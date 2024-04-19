namespace Leetcode.DataStructures
{
    public class DoublyLinkedList
    {
        public D_ListNode head;
        public D_ListNode tail;

        public int legth;

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            legth = 0;
        }
    }

    public class D_ListNode
    {
        public int data;
        public D_ListNode previous;
        public D_ListNode next;
        public D_ListNode(int data)
        {
            this.data = data;
        }
    }
}
