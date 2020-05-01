using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.LinkedList
{
    public class _8
    {
        public ListNode PointToLastItem(ListNode node, int item)
        {
            if (node == null)
                return null;
            else
            {
                ListNode p = PointToLastItem(node.next, item);
                if (p != null)
                    return p;
                else
                {
                    if (node.val == item)
                    {
                        return node;
                    }
                    else
                    {
                        return null;
                    }
                }


            }
        }

    }
}
