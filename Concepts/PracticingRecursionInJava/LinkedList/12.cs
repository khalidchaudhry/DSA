using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _12
    {
        /// <summary>
        /// Write a method to return samllest data value in nonempty linked list
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int Minimum(ListNode node)
        {
            if (node == null)
            {
                return int.MaxValue;
            }

            return Math.Min(node.val,Minimum(node.next));

        }


    }
}
