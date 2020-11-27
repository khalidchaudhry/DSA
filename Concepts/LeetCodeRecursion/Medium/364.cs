using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRecursion.Medium
{
    public class _364
    {
        public int DepthSumInverse(IList<NestedInteger> nestedList)
        {
            Queue<NestedInteger> queue = new Queue<NestedInteger>();

            foreach (NestedInteger nestedInteger in nestedList)
            {
                queue.Enqueue(nestedInteger);
            }

            int depth = 1;           
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

            foreach (NestedInteger nestedInteger in nestedList)
            {
                queue.Enqueue(nestedInteger);
            }
            
            int totalSum = 0;
            --depth; //! becuase above queue will contain one more depth as it will increase it before exiting while loop
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
                        depthSum += dequeue.GetInteger();
                    }
                }

                totalSum += (depth * depthSum);
                --depth;
            }

            return totalSum;


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
