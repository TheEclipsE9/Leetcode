// See https://aka.ms/new-console-template for more information
using Leetcode.DataStructures;

Console.WriteLine("Hello, World!");

#region SinglyLinkedListNode

#region Print

{
    SinglyLinkedList<int> linkedList = new SinglyLinkedList<int>();

    linkedList.Head = new SinglyLinkedListNode<int>(0);

    var fst = new SinglyLinkedListNode<int>(1);
    var snd = new SinglyLinkedListNode<int>(2);
    var trd = new SinglyLinkedListNode<int>(3);
    var fth = new SinglyLinkedListNode<int>(4);

    linkedList.Head.Next = fst;
    fst.Next = snd;
    snd.Next = trd;
    trd.Next = fth;

    linkedList.Print();
}

#endregion

#endregion
