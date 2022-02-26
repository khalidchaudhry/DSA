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
    //! using doubly linked list where it keep track of all the unique number in order
    //! HashMap to keep track of value and corresponding node. I
    /// </summary>
    public class FirstUnique
    {

        Dictionary<int, Node> map;
        DLL dll;
        public FirstUnique(int[] nums)
        {
            map = new Dictionary<int, Node>();
            dll = new DLL();

            for (int i = 0; i < nums.Length; ++i)
            {
                Add(nums[i]);
            }
        }
        public int ShowFirstUnique()
        {
            if (dll.IsEmpty())
                return -1;
            else
                return dll.Head.Next.Data;
        }
        public void Add(int value)
        {

            if (map.ContainsKey(value))
            {
                if (map[value] != null)
                {
                    dll.Remove(map[value]);
                    map[value] = null;
                }
            }
            else
            {
                Node newNode = new Node(value);
                map.Add(value, newNode);
                dll.Add(newNode);
            }
        }
    }

    public class DLL
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public DLL()
        {
            Head = new Node(0);
            Tail = new Node(0);

            Head.Next = Tail;
            Tail.Previous = Head;

        }
        /// <summary>
        //! Add the element to the tail
        /// </summary>

        public void Add(Node node)
        {
            node.Previous = Tail.Previous;
            node.Next = Tail;

            Tail.Previous.Next = node;
            Tail.Previous = node;
        }
        /// <summary>
        //! Remove it from the head
        /// </summary>        
        public void Remove(Node node)
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
        }
        public bool IsEmpty()
        {
            return Head.Next.Next == null ? true : false;
        }
    }

    public class Node
    {
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public int Data { get; set; }
        public Node(int value)
        {
            Data = value;
            Next = null;
            Previous = null;
        }
    }
}


