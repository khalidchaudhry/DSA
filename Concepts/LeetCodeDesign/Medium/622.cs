using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Medium
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
    //! Using Doubly linked list    
    /// </summary>
    public class MyCircularQueue
    {

        /** Initialize your data structure here. Set the size of the queue to be k. */
        DoublyLinkedListNode _head;
        DoublyLinkedListNode _tail;
        int _count;
        int _capacity;
        public MyCircularQueue(int k)
        {
            _head = new DoublyLinkedListNode(int.MaxValue);
            _tail = new DoublyLinkedListNode(int.MaxValue);
            _head.Next = _tail;
            _tail.Prev = _head;
            _count = 0;
            _capacity = k;
        }

        /** Insert an element into the circular queue. Return true if the operation is successful. */
        public bool EnQueue(int value)
        {
            if (IsFull()) return false;

            DoublyLinkedListNode newNode = new DoublyLinkedListNode(value);
            _head.Next.Prev = newNode;
            newNode.Next = _head.Next;
            _head.Next = newNode;
            newNode.Prev = _head;

            ++_count;
            return true;
        }

        /** Delete an element from the circular queue. Return true if the operation is successful. */
        public bool DeQueue()
        {
            if (IsEmpty()) return false;

            _tail.Prev.Prev.Next = _tail;
            _tail.Prev = _tail.Prev.Prev;

            --_count;
            return true;
        }

        /** Get the front item from the queue. */
        public int Front()
        {
            if (IsEmpty()) return -1;

            return _tail.Prev.Value;

        }

        /** Get the last item from the queue. */
        public int Rear()
        {
            if (IsEmpty()) return -1;
            return _head.Next.Value;
        }

        /** Checks whether the circular queue is empty or not. */
        public bool IsEmpty()
        {
            if (_count == 0) return true;
            return false;

        }

        /** Checks whether the circular queue is full or not. */
        public bool IsFull()
        {
            if (_count == _capacity) return true;
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



    public class DoublyLinkedListNode
    {
        public DoublyLinkedListNode Prev { get; set; }
        public DoublyLinkedListNode Next { get; set; }

        public int Value { get; set; }
        public DoublyLinkedListNode(int value)
        {
            Value = value;
            Prev = null;
            Next = null;
        }
    }
}
