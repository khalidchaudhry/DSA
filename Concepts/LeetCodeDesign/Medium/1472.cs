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
            var test=History.Back(1);
            Console.ReadLine();
        }


    }

    /// <summary>
    //! using doubly linked list 
    /// </summary>
    public class BrowserHistory
    {
        Node _history;
        Node _curr;
        public BrowserHistory(string homepage)
        {
            _history = new Node(homepage);
            _curr = _history;
        }

        public void Visit(string url)
        {
            _curr.Next = null; // clears up all the forward history.
            _curr.Next = new Node(url);
            _curr.Next.Previous = _curr;
            _curr = _curr.Next;

        }

        public string Back(int steps)
        {
            while (_curr.Previous != null && steps > 0)
            {
                _curr = _curr.Previous;
                --steps;
            }

            return _curr.Value;
        }

        public string Forward(int steps)
        {
            while (_curr.Next != null && steps > 0)
            {
                _curr = _curr.Previous;
                --steps;
            }

            return _curr.Value;

        }
    }




    public class Node
    {
        public string Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(string value)
        {
            Value = value;
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
