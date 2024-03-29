using System.Collections.Generic;

namespace Leetcode.DataStructures
{
    public class SinglyLinkedList<T>
    {
        public SinglyLinkedListNode<T>? Head;

        public void DeleteLast()
        {
            var beforeLastNode = Head;
            if(beforeLastNode is null)
            {
                return;
            }
            if (beforeLastNode.Next is null)
            {
                Head = null;
                return;
            }

            while (beforeLastNode.Next?.Next is not null)
            {
                beforeLastNode = beforeLastNode.Next;
            }

            beforeLastNode.Next = null;
        }

        public void DeleteFirst()
        {
            if (Head is null)
            {
                return;
            }
            Head = Head.Next;
        }

        public void InsertAt(T value, int index)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            if (index == 0)
            {
                newNode.Next = Head;
                Head = newNode;
                return;
            }

            SinglyLinkedListNode<T> nodeBefore = GetAt(index - 1);
            if (nodeBefore is null)
            {
                throw new IndexOutOfRangeException();
            }

            newNode.Next = nodeBefore.Next;
            nodeBefore.Next = newNode;
        }

        public SinglyLinkedListNode<T>? GetAt(int index)
        {
            int currentIndex = 0;
            var current = Head;

            while (true)
            {
                if (currentIndex == index)
                {
                    return current;
                }
                if (current is null)
                {
                    throw new IndexOutOfRangeException();
                }

                currentIndex++;
                current = current.Next;
            }
        }

        public void InsertAtTheEnd(T value)
        {
            var node = new SinglyLinkedListNode<T>(value);

            var last = GetLast();
            if (last is null)
            {
                Head = node;
            }
            else
            {
                last.Next = node;
            }
        }

        public SinglyLinkedListNode<T>? GetLast()
        {
            var current = Head;
            if (current is null)
            {
                return null;
            }
            while (true)
            {
                if (current.Next is null)
                {
                    break;
                }
                current = current.Next;
            }

            return current;
        }

        public void InsertAtTheBeginning(SinglyLinkedListNode<T> node)
        {
            node.Next = Head;

            Head = node;
        }

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

/*
Yes, you're absolutely correct. Your understanding is spot on.

In C#, when you write node.Next = Head;, you're indeed passing a copy of the reference stored in Head to node.Next. 
Therefore, node.Next now holds a reference to the same object that Head was pointing to.

Then, when you update Head with Head = node;, you're changing the reference stored in Head to point to a new object (the new head node). 
However, this change doesn't affect node.Next, because node.Next holds a copy of the reference that Head held at the time of the assignment.

So, your understanding is correct: the assignment node.Next = Head; 
copies the reference from Head to node.Next, and subsequent changes to Head won't affect node.
Next because it's just a copy of the reference, not the original reference itself.
*/