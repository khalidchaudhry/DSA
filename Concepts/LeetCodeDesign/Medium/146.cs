using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Medium_146
{
    public class _146
    {

        public static void _146Main()
        {
            LRUCache cache = new LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Get(1);

            Console.ReadLine();
        }
    }
    /// <summary>
    /// https://leetcode.com/problems/lru-cache/discuss/45911/Java-Hashtable-%2B-Double-linked-list-(with-a-touch-of-pseudo-nodes)
    /// https://leetcode.com/problems/lru-cache/discuss/600088/3-Java-Solutions-Clean-Code
    ///  // # <image url="$(SolutionDir)\Images\146.png"  scale="0.7"/>
    /// </summary>

    public class LRUCache
    {

        public Dictionary<int, Node> _map;
        public DLL _dll;
        public int _capacity;
        public LRUCache(int capacity)
        {
            _map = new Dictionary<int, Node>();
            _dll = new DLL();
            _capacity = capacity;
        }
        public int Get(int key)
        {
            if (!_map.ContainsKey(key))
                return -1;//! to return -1 this is considered as bad practice. We should through an exception in this case 
                          //! what if user  asks to put -1 as value for some key 

            _dll.MoveToHead(_map[key]);

            return _map[key].Value;

        }
        public void Put(int key, int value)
        {
            if (_map.ContainsKey(key))
            {
                _map[key].Value = value;
                _dll.MoveToHead(_map[key]);
            }
            else
            {
                Node node = new Node(key, value);
                _map.Add(key, node);
                _dll.AddNode(node);

                if (_map.Count > _capacity)
                {
                    Node leastRecent = _dll.PopTail();
                    _map.Remove(leastRecent.Key);
                }
            }
        }
    }


    public class DLL
    {
        Node Head { get; set; }
        Node Tail { get; set; }

        public DLL()
        {
            Head = new Node(-1, -1);
            Tail = new Node(-1, -1);

            Head.Next = Tail;
            Tail.Prev = Head;
        }

        //! Always add node to the head of the DLL
        public void AddNode(Node newNode)
        {
            //! dealing with the node that is currently infront of Head
            Head.Next.Prev = newNode;
            newNode.Next = Head.Next;
            newNode.Prev = Head;
            Head.Next = newNode;
        }

        //! Removing any node from the DLL
        public void RemoveNode(Node node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }
        public void MoveToHead(Node node)
        {
            RemoveNode(node);
            AddNode(node);

        }
        public Node PopTail()
        {
            Node nodeToReturn = Tail.Prev;
            RemoveNode(nodeToReturn);
            return nodeToReturn;
        }


    }
    public class Node
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public Node Prev { get; set; }
        public Node Next { get; set; }
        public Node(int key, int value)
        {
            Key = key;
            Value = value;
            Prev = null;
            Next = null;
        }

    }
}
