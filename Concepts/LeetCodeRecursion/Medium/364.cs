using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRecursion.Medium
{
    public class _364
    {
        /// <summary>
        //! Very similar to question 104 and 559
        //! Calculating MaxDepth using BFS and again doing BFS for answer 
        /// </summary>
        public int DepthSumInverse(IList<NestedInteger> nestedList)
        {
            int depth = MaxDepth(nestedList);

            Queue<NestedInteger> queue = new Queue<NestedInteger>();

            foreach (NestedInteger nestedInteger in nestedList)
            {
                queue.Enqueue(nestedInteger);
            }

            int totalSum = 0;
            while (queue.Count != 0)
            {
                int depthSum = 0;
                int size = queue.Count;
                for (int i = 0; i < size; ++i)
                {
                    NestedInteger dequeue = queue.Dequeue();
                    if (!dequeue.IsInteger())
                    {
                        foreach (NestedInteger ni in dequeue.GetList())
                        {
                            queue.Enqueue(ni);
                        }
                    }
                    else
                    {
                        totalSum += dequeue.GetInteger() * depthSum;
                    }
                }
                --depth;
            }

            return totalSum;
        }
        /// <summary>
        //! //! Very similar to question 104 and 559
        //! Calculating Depth using DFS and then doing BFS for answer 
        /// </summary>
        public int DepthSumInverse2(IList<NestedInteger> nestedList)
        {

            int maxDepth = CalculateDepth(nestedList);

            Queue<NestedInteger> queue = new Queue<NestedInteger>();
            foreach (NestedInteger nestedInteger in nestedList)
            {
                queue.Enqueue(nestedInteger);
            }

            int depthSumInverse = 0;
            while (queue.Count != 0)
            {
                int count = queue.Count;
                while (count != 0)
                {
                    NestedInteger dequeue = queue.Dequeue();
                    if (dequeue.IsInteger())
                    {
                        depthSumInverse += dequeue.GetInteger() * maxDepth;
                    }
                    else
                    {
                        foreach (NestedInteger nestedInteger in dequeue.GetList())
                        {
                            queue.Enqueue(nestedInteger);
                        }
                    }
                    --count;
                }
                --maxDepth;

            }
            return depthSumInverse;
        }

        /// <summary>
        //! Calculating Depth using DFS 
        /// </summary>
        private int CalculateDepth(IList<NestedInteger> nestedList)
        {
            //!incase empty or 0 count , returns 0.
            //! Always think about the base case and what will happen if its not there 
            if (nestedList == null || nestedList.Count == 0)
                return 0;

            int maxDepth = 0;
            foreach (NestedInteger item in nestedList)
            {
                if (!item.IsInteger())
                {
                    maxDepth = Math.Max(maxDepth, CalculateDepth(item.GetList()));
                }
            }
            return maxDepth + 1;
        }

        /// <summary>
        //! Calculating Depth using BFS 
        /// </summary>
        private int MaxDepth(IList<NestedInteger> nestedList)
        {
            Queue<NestedInteger> queue = new Queue<NestedInteger>();

            foreach (NestedInteger nestedInteger in nestedList)
            {
                queue.Enqueue(nestedInteger);
            }

            int depth = 0;
            while (queue.Count != 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; ++i)
                {
                    NestedInteger dequeue = queue.Dequeue();
                    if (!dequeue.IsInteger())
                    {
                        foreach (NestedInteger ni in dequeue.GetList())
                        {
                            queue.Enqueue(ni);
                        }
                    }
                }
                ++depth;
            }

            return depth;
        }
    }

    public interface NestedInteger
    {

        // Constructor initializes an empty nested list.
        ///public NestedInteger();

        // Constructor initializes a single integer.
        //public NestedInteger(int value);

        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        bool IsInteger();

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        int GetInteger();

        // Set this NestedInteger to hold a single integer.
        //public void SetInteger(int value);

        // Set this NestedInteger to hold a nested list and adds a nested integer to it.
        //public void Add(NestedInteger ni);

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        IList<NestedInteger> GetList();
    }
}
