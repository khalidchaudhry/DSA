using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Medium_644

{
    public class MyCircularDeque
    {

        /** Initialize your data structure here. Set the size of the deque to be k. */
        int size;
        DLL dll;
        public MyCircularDeque(int k)
        {
            dll = new DLL();
            size = k;
        }

        /** Adds an item at the front of Deque. Return true if the operation is successful. */
        public bool InsertFront(int value)
        {
            if (dll.NodesCount == size)
                return false;
            dll.AddAtHead(value);
            return true;
        }

        /** Adds an item at the rear of Deque. Return true if the operation is successful. */
        public bool InsertLast(int value)
        {
            if (dll.NodesCount == size)
                return false;

            dll.AddAtTail(value);
            return true;
        }

        /** Deletes an item from the front of Deque. Return true if the operation is successful. */
        public bool DeleteFront()
        {
            if (dll.NodesCount == 0)
                return false;

            dll.RemoveFromHead();
            return true;
        }

        /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
        public bool DeleteLast()
        {
            if (dll.NodesCount == 0)
                return false;

            dll.RemoveFromTail();
            return true;
        }

        /** Get the front item from the deque. */
        public int GetFront()
        {
            if (dll.NodesCount == 0)
                return -1;

            return dll.GetFromHead();
        }

        /** Get the last item from the deque. */
        public int GetRear()
        {
            if (dll.NodesCount == 0)
                return -1;

            return dll.GetFromTail();
        }

        /** Checks whether the circular deque is empty or not. */
        public bool IsEmpty()
        {

            return dll.NodesCount == 0 ? true : false;
        }

        /** Checks whether the circular deque is full or not. */
        public bool IsFull()
        {
            return dll.NodesCount == size ? true : false;
        }
    }

    public class DLL
    {
        public int NodesCount { get; set; }
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public DLL()
        {
            NodesCount = 0;
            Head = new Node(0);
            Tail = new Node(0);

            Head.Next = Tail;
            Tail.Previous = Head;

        }

        public int GetFromHead()
        {
            return Head.Next.Data;
        }

        public int GetFromTail()
        {
            return Tail.Previous.Data;
        }

        public void AddAtHead(int data)
        {
            Node newNode = new Node(data);
            newNode.Next = Head.Next;
            newNode.Previous = Head;

            Head.Next.Previous = newNode;
            Head.Next = newNode;

            ++NodesCount;

        }

        public void AddAtTail(int data)
        {
            Node newNode = new Node(data);
            newNode.Previous = Tail.Previous;
            newNode.Next = Tail;

            Tail.Previous.Next = newNode;
            Tail.Previous = newNode;

            ++NodesCount;
        }
        public void RemoveFromHead()
        {
            Head.Next = Head.Next.Next;
            Head.Next.Previous = Head;

            --NodesCount;
        }
        public void RemoveFromTail()
        {
            Tail.Previous = Tail.Previous.Previous;
            Tail.Previous.Next = Tail;

            --NodesCount;
        }
    }

    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public Node(int data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
    }
}
