using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Medium_1429
{
    public class _1429
    {

    }


    /// <summary>
    //! Based on idea in Kua's class
    //! using doubly linked list
    /// </summary>
    public class FirstUnique
    {
        Dictionary<int, DoublyLinkedList> _map;
        DoublyLinkedList _head;
        DoublyLinkedList _tail;
        public FirstUnique(int[] nums)
        {
            _head = new DoublyLinkedList(int.MaxValue);
            _tail = new DoublyLinkedList(int.MaxValue);
            _head.Next = _tail;
            _tail.Previous = _head;

            foreach (int num in nums)
            {
                Insert(num);
            }
        }

        public int ShowFirstUnique()
        {
            if (_head.Next.Next != null) //!  this is the case when linked list contains more than 3 nodes. 
            {
                return _head.Next.Value;
            }
            return -1;
        }

        public void Add(int value)
        {
            Insert(value);
        }

        private void Insert(int num)
        {
            if (_map.ContainsKey(num)) 
            {
                if (_map[num] != null)//! if the key has already been deleted. No need to delete it insert. Its duplicate anyway
                {
                    DoublyLinkedList nodeToDelete = _map[num];
                    nodeToDelete.Previous.Next = nodeToDelete.Next;
                    nodeToDelete.Next.Previous = nodeToDelete.Previous;
                    _map[num] = null;
                }
            }
            else
            {
                DoublyLinkedList nodeToAdd = new DoublyLinkedList(num);
                _tail.Previous.Next = nodeToAdd;
                nodeToAdd.Previous = _tail.Previous;

                nodeToAdd.Next = _tail;
                _tail.Previous = nodeToAdd;

                _map.Add(num, nodeToAdd);
            }
        }
    }

    public class DoublyLinkedList
    {
        public int Value { get; set; }
        public DoublyLinkedList Next { get; set; }
        public DoublyLinkedList Previous { get; set; }
        public DoublyLinkedList(int value)
        {
            Value = value;
            Previous = null;
            Next = null;
        }
    }


}


