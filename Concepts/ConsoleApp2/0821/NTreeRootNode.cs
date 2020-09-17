using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2._0821
{
    class NTreeRootNode
    {

        public static void NTreeRootNodeMain(string[] args)
        {
            List<Node> nodes = new List<Node>();
            Node one = new Node(1);
            Node two = new Node(2);
            Node three = new Node(3);
            Node four = new Node(4);
            Node five = new Node(5);
            Node six = new Node(6);

            one.Children = new List<Node>() { two, three, four };
            three.Children = new List<Node>() { five, six };

            nodes.Add(one);
            nodes.Add(two);
            nodes.Add(three);
            nodes.Add(four);
            nodes.Add(five);
            nodes.Add(six);

            NTreeRootNode p = new NTreeRootNode();

            p.RootNode(nodes);

            Console.ReadKey();
        }

        public Node RootNode(List<Node> nodes)
        {
            HashSet<Node> allNodes = new HashSet<Node>();

            foreach (Node node in nodes)
            {
                allNodes.Add(node);
            }

            foreach (Node node in nodes)
            {
                if (node.Children != null)
                {
                    foreach (Node child in node.Children)
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

        public Node RootNode0(List<Node> nodes)
        {
            int totalSum = 0;

            foreach (Node node in nodes)
            {
                totalSum += node.Val;
            }
            foreach (Node node in nodes)
            {
                if (node.Children != null)
                {
                    foreach (Node child in node.Children)
                    {
                        totalSum -= child.Val;
                    }
                }
            }

            Node root = null;
            foreach (Node node in nodes)
            {
                if (node.Val == totalSum)
                {
                    root = node;
                    break;
                }
            }

            return root;
        }
    }
    public class Node
    {
        public Node(int val)
        {
            Val = val;
        }
        public int Val { get; set; }

        public List<Node> Children { get; set; }
    }


}
