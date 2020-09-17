using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNoCategory.Medium
{
    public class _1506
    {
        public static void _1506Main()
        {
            List<Node> nodes = new List<Node>();
            Node one = new Node(1);
            Node two = new Node(2);
            Node three = new Node(3);
            Node four = new Node(4);
            Node five = new Node(5);
            Node six = new Node(6);

            one.children = new List<Node>() { two, three, four };
            three.children = new List<Node>() { five, six };

            nodes.Add(one);
            nodes.Add(two);
            nodes.Add(three);
            nodes.Add(four);
            nodes.Add(five);
            nodes.Add(six);                     
            
            _1506 NArrayRoot = new _1506();

            var ans=NArrayRoot.RootNode0(nodes);

            Console.ReadLine();
           
        }
        public Node RootNode0(List<Node> tree)
        {
            int xor = 0;

            foreach (Node node in tree)
            {
                xor ^= node.val;
            }
            foreach (Node node in tree)
            {
                if (node.children != null)
                {
                    foreach (Node child in node.children)
                    {
                        xor ^= child.val;
                    }
                }
            }


            Node root = null;
            foreach (Node node in tree)
            {
                if (node.val == xor)
                {
                    root = node;
                    break;
                }
            }
            return root;
        }
        public Node RootNode1(List<Node> nodes)
        {
            int totalSum = 0;

            foreach (Node node in nodes)
            {
                totalSum += node.val;
            }
            foreach (Node node in nodes)
            {
                if (node.children != null)
                {
                    foreach (Node child in node.children)
                    {
                        totalSum -= child.val;
                    }
                }
            }

            Node root = null;
            foreach (Node node in nodes)
            {
                if (node.val == totalSum)
                {
                    root = node;
                    break;
                }
            }
            return root;
        }

        public Node RootNode2(List<Node> nodes)
        {
            HashSet<Node> allNodes = new HashSet<Node>();

            foreach (Node node in nodes)
            {
                allNodes.Add(node);
            }

            foreach (Node node in nodes)
            {
                if (node.children != null)
                {
                    foreach (Node child in node.children)
                    {
                        if (allNodes.Contains(node))
                        {
                            allNodes.Remove(node);
                        }
                    }
                }
            }

            return nodes.First();
        }


    }

    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node()
        {
            val = 0;
            children = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            children = new List<Node>();
        }

        public Node(int _val, List<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}
