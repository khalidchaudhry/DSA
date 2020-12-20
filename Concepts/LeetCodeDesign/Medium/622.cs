using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Medium._622Main
{
    public class _622
    {

        public static void _622Main()
        {
            MyCircularQueue obj = new MyCircularQueue(8);
            bool param_1 = obj.EnQueue(69);
            //var result = obj.Rear();
            //var result2 = obj.Rear();

            var test2 = obj.EnQueue(8);
            var test3 = obj.EnQueue(3);
            var test4 = obj.EnQueue(9);
            var test5 = obj.EnQueue(5);
            //var test6 = obj.Front();
            //var test7 = obj.DeQueue();
            //var test8 = obj.DeQueue();
            //var test9 = obj.DeQueue();
        }



    }
    /// <summary>
    //! Takeawys
    //! Takeaway1: Design classes as independent and isolated as possible. 
    //! Using Doubly linked list
    //! Inserting at front(head) of DLL and removing from back(Tail) of the doubly linked list
    /// </summary>
    public class MyCircularQueue
    {

        /** Initialize your data structure here. Set the size of the queue to be k. */
        public int _size;
        public DLL _dll;
        public MyCircularQueue(int k)
        {
            _dll = new DLL();
            _size = k;
        }

        /** Insert an element into the circular queue. Return true if the operation is successful. */
        public bool EnQueue(int value)
        {
            if (_dll.NodesCount == _size)
                return false;
            else
            {
                _dll.Insert(value);
                return true;
            }
        }

        /** Delete an element from the circular queue. Return true if the operation is successful. */
        public bool DeQueue()
        {

            if (_dll.NodesCount == 0)
                return false;
            else
            {
                _dll.Remove();
                return true;
            }
        }

        /** Get the front item from the queue. */
        public int Front()
        {
            if (_dll.NodesCount == 0)
                return -1;
            else
                return _dll.GetFront();
        }

        /** Get the last item from the queue. */
        public int Rear()
        {
            if (_dll.NodesCount == 0)
                return -1;
            else
                return _dll.GetRear();
        }

        /** Checks whether the circular queue is empty or not. */
        public bool IsEmpty()
        {

            if (_dll.NodesCount == 0)
                return true;
            else
                return false;
        }

        /** Checks whether the circular queue is full or not. */
        public bool IsFull()
        {

            if (_dll.NodesCount == _size)
                return true;
            else
                return false;
        }
    }


    public class MyCircularQueue2
    {

        /** Initialize your data structure here. Set the size of the queue to be k. */
        List<int> _items;
        int _size;
        int _head;
        int _tail;
        int _count;
        public MyCircularQueue2(int k)
        {
            _size = k;
            _items = new List<int>(_size);
            //! equivalent of above line. Above statement does not create items in the list . only initializes it with the size
            for (int i = 0; i < _size; ++i)
            {
                _items.Add(0);
            }
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        /** Insert an element into the circular queue. Return true if the operation is successful. */
        public bool EnQueue(int value)
        {
            if (IsFull())
                return false;

            if (!IsEmpty())
                _tail = (1 + _tail) % _size;

            _items[_tail] = value;
            ++_count;

            return true;
        }

        /** Delete an element from the circular queue. Return true if the operation is successful. */
        public bool DeQueue()
        {
            if (IsEmpty())
                return false;

            --_count;

            if (_head!=_tail)//Incase of only one element we no need to move head
                _head = (1 + _head) % _size;
            
            return true;

        }

        /** Get the front item from the queue. */
        public int Front()
        {
            if (IsEmpty()) return -1;
            return _items[_head];
        }

        /** Get the last item from the queue. */
        public int Rear()
        {
            if (IsEmpty()) return -1;
            return _items[_tail];
        }

        /** Checks whether the circular queue is empty or not. */
        public bool IsEmpty()
        {
            if (_count == 0)
                return true;
            return false;
        }

        /** Checks whether the circular queue is full or not. */
        public bool IsFull()
        {
            if (_count == _size)
                return true;
            return false;
        }
    }

    public class DLL
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int NodesCount { get; set; }
        public DLL()
        {
            Head = new Node(0);
            Tail = new Node(0);
            Head.Next = Tail;
            Tail.Previous = Head;
            //! Better to keep nodes count in DLL class rather than in CircularQueue Class
            NodesCount = 0;
        }

        public void Insert(int value)
        {
            Node newNode = new Node(value);

            newNode.Previous = Tail.Previous;
            newNode.Next = Tail;

            Tail.Previous.Next = newNode;

            Tail.Previous = newNode;

            ++NodesCount;

        }
        public void Remove()
        {
            Head.Next = Head.Next.Next;
            Head.Next.Previous = Head;

            --NodesCount;
        }
        public int GetFront()
        {
            return Head.Next.Data;
        }
        public int GetRear()
        {
            return Tail.Previous.Data;
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
