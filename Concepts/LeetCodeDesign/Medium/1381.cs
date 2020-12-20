using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Medium
{
    public class _1381
    {



    }

    /// <summary>
    //!Key idea: Visualize stack as list. It will give push and pop operation in O(1)  time. 
    //! Take aways
    //! Take away: Not to over think the problem initially.
    /// </summary>
    public class CustomStack
    {

        List<int> list;
        int size;
        public CustomStack(int maxSize)
        {
            list = new List<int>();
            size = maxSize;
        }
        public void Push(int x)
        {
            if (list.Count == size)
                return;
            //! Amortized 0(1)
            list.Add(x);
        }

        public int Pop()
        {
            if (list.Count == 0)
                return -1;

            int toReturn = list.ElementAt(list.Count - 1);
            //!0(1)
            list.RemoveAt(list.Count - 1);
            return toReturn;
        }

        public void Increment(int k, int val)
        {

            for (int i = 0; i < list.Count && k > 0; ++i)
            {
                list[i] = list[i] + val;
                --k;
            }
        }
    }

    /// <summary>    
    //! Based on idea discussed in Kua's class
    //! O(1) for all the operations
    //! Idea: Only  do increment  whenever someone pops it. 
    //!1  Whenever push, always  append 0 to Adjustments array
    //!2. When Increment go to the adjustment array corresponding index(K-1) and add increment value to it.
    //!3. When pops , if adjustment array!=0 then add the element to be return and add it previous adjustment element
    /// </summary>
    public class CustomStack1
    {
        List<int> list;
        List<int> adj;
        int size;
        public CustomStack1(int maxSize)
        {
            list = new List<int>();
            adj = new List<int>();
            size = maxSize;
        }
        public void Push(int x)
        {
            if (list.Count == size)
                return;

            list.Add(x);
            adj.Add(0);
        }

        public int Pop()
        {
            if (list.Count == 0)
                return -1;

            int toReturn = list[list.Count - 1];
            toReturn += adj[adj.Count - 1];
            //!When adjustment element count are more then 1 only then we will be able to add it
            if (adj.Count > 1)
            {
                adj[adj.Count - 2] += adj[adj.Count - 1];
            }

            list.RemoveAt(list.Count - 1);
            adj.RemoveAt(adj.Count - 1);

            return toReturn;
        }

        public void Increment(int k, int val)
        {
            if (adj.Count == 0) return;
            //! incase k is greater than number of elements in list , simply  set last element and returns the result
            if (k > adj.Count)
            {
                adj[adj.Count - 1] += val;
                return;
            }

            adj[k - 1] += val;
        }

    }   
}
