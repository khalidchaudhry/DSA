using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRecursion.Easy
{
    public class _339
    {

        //! BFS approach
        public int DepthSum(IList<NestedInteger> nestedList)
        {
            Queue<NestedInteger> queue = new Queue<NestedInteger>();

            foreach (NestedInteger nestedInteger in nestedList)
            {
                queue.Enqueue(nestedInteger);
            }


            int depth = 1;
            int totalSum = 0;

            while (queue.Count != 0)
            {
                int depthSum = 0;
                int size = queue.Count;
                for (int i = 0; i < size; ++i)
                {
                    NestedInteger dequeue = queue.Dequeue();
                    
                    if (dequeue.IsInteger())
                    {
                        depthSum += dequeue.GetInteger();                     
                    }
                    else
                    {
                        foreach (NestedInteger ni in dequeue.GetList())
                        {
                            queue.Enqueue(ni);
                        }
                    }
                }

                totalSum += (depth * depthSum);
                ++depth;
            }

            return totalSum;
        }

        //! DFS approach 
        public int DepthSum2(IList<NestedInteger> nestedList)
        {

            return DFS(nestedList, 1);
        }

        private int DFS(IList<NestedInteger> nestedList, int depth)
        {
            int sum = 0;

            foreach (NestedInteger ni in nestedList)
            {
                if (ni.IsInteger())
                {
                    sum += ni.GetInteger() * depth;
                }
                else
                {
                    sum += DFS(ni.GetList(), depth + 1);
                }
            }


            return sum;
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
