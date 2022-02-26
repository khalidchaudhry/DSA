using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Medium
{
    public class _1472
    {
        public static void _1472Main()
        {

            BrowserHistory History = new BrowserHistory("leetcode.com");

            History.Visit("google.com");
            History.Visit("facebook.com");
            History.Visit("youtube.com");
            var test = History.Back(1);
            Console.ReadLine();
        }


    }

    /// <summary>
    //! Takeaways
    //!Takeaway1: Whenever we need to go forward and backword in constant time, doubly linked list is a way to go
    //! 
    /// </summary>
    public class BrowserHistory
    {

        DLL _dll;
        public BrowserHistory(string homepage)
        {
            _dll = new DLL();
            _dll.Add(homepage);
        }

        public void Visit(string url)
        {
            _dll.Add(url);
        }

        public string Back(int steps)
        {
            return _dll.GetCurrValueBack(steps);
        }

        public string Forward(int steps)
        {
            return _dll.GetCurrValueForward(steps);
        }
    }

    public class DLL
    {
        private Node _head;
        private Node _tail;
        private Node _curr;
        public DLL()
        {
            _head = new Node(string.Empty);
            _tail = new Node(string.Empty);
            _head.Next = _tail;
            _tail.Prev = _head;
            _curr = _head;
        }
        public void Add(string url)
        {
            Node newNode = new Node(url);

            newNode.Next = _tail;
            newNode.Prev = _curr;
            _curr.Next.Prev = newNode;
            _curr.Next = newNode;

            _curr = newNode;
        }
        public string GetCurrValueBack(int steps)
        {
            while (steps != 0 && _curr.Prev.Prev != null)
            {
                _curr = _curr.Prev;
                --steps;
            }
            return _curr.Value;
        }
        public string GetCurrValueForward(int steps)
        {
            while (steps != 0 && _curr.Next.Next != null)
            {
                _curr = _curr.Next;
                --steps;
            }
            return _curr.Value;
        }
    }

    public class Node
    {
        public string Value;
        public Node Next;
        public Node Prev;
        public Node(string value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
    }

    /// <summary>
    /// https://leetcode.com/problems/design-browser-history/discuss/674486/Two-Stacks-Pretty-code.
    //! Using stack
    /// </summary>
    public class BrowserHistory2
    {
        Stack<string> history;
        Stack<string> forward;
        public BrowserHistory2(string homepage)
        {
            history = new Stack<string>();
            history.Push(homepage);
            forward = new Stack<string>();
        }

        public void Visit(string url)
        {
            forward = new Stack<string>();
            history.Push(url);
        }

        public string Back(int steps)
        {
            while (history.Count > 1 && steps > 0)
            {
                string pop = history.Pop();
                forward.Push(pop);
                --steps;
            }
            return history.Peek();
        }

        public string Forward(int steps)
        {
            while (steps > 0 && forward.Count > 0)
            {
                string pop = forward.Pop();
                history.Push(pop);
                --steps;
            }

            return history.Peek(); //! peek it from history since its the one that will contain atleast on element 
        }
    }

    /**
     * Your BrowserHistory object will be instantiated and called as such:
     * BrowserHistory obj = new BrowserHistory(homepage);
     * obj.Visit(url);
     * string param_2 = obj.Back(steps);
     * string param_3 = obj.Forward(steps);
     */



}
