using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLinkedList.Medium
{
    public class _138
    {

        /// <summary>
        //! Two pass solution based on idea in Kuai's class 
        //! First clone the nodes
        //! in second pass set their next and random nodes
        /// </summary>
        public Node CopyRandomList(Node head)
        {

            if (head == null) return null;

            Dictionary<Node, Node> map = new Dictionary<Node, Node>();

            Node ptr = head;
            while (ptr != null)
            {
                map.Add(ptr, new Node(ptr.val));
                ptr = ptr.next;
            }

            foreach (var keyValue in map)
            {
                Node node = keyValue.Key;
                Node cloneNode = keyValue.Value;

                if (node.next != null)
                {
                    cloneNode.next = map[node.next];
                }
                if (node.random != null)
                {
                    cloneNode.random = map[node.random];
                }
            }

            return map[head];


        }
    }

    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
}
